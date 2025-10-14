public class AppointmentService : IAppointmentService
{
    private List<Appointment> appointments = new List<Appointment>();
    private MedicService medicService;
    private PatientService patientService;

    public AppointmentService(MedicService medicService, PatientService patientService)
    {
        this.medicService = medicService;
        this.patientService = patientService;
    }

    // ------------------ CREAR CITA ------------------
    public void ScheduleAppointment()
    {
        Console.WriteLine("\n📅 --- Registrar Nueva Cita ---");

        string patientDocument = Helper.ReadNonEmptyLine("Documento del paciente: ");
        var patient = patientService.GetAllPatients().FirstOrDefault(p => p.Document == patientDocument);
        if (patient == null)
        {
            Console.WriteLine("❌ No se encontró un paciente con ese documento.");
            return;
        }

        string medicDocument = Helper.ReadNonEmptyLine("Documento del médico: ");
        var medic = medicService.GetAllMedics().FirstOrDefault(m => m.Document == medicDocument);
        if (medic == null)
        {
            Console.WriteLine("❌ No se encontró un médico con ese documento.");
            return;
        }

        Console.Write("Ingrese la fecha y hora de la cita (formato: yyyy-MM-dd HH:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("⚠️ Fecha no válida. Use el formato correcto.");
            return;
        }

        if (date < DateTime.Now)
        {
            Console.WriteLine("⚠️ No puede agendar citas en una fecha pasada.");
            return;
        }

        // Validar que el médico y el paciente estén disponibles en esa fecha
        bool medicBusy = appointments.Any(a => a.Medic.Document == medicDocument && a.Date == date && a.Status == "Programada");
        bool patientBusy = appointments.Any(a => a.Patient.Document == patientDocument && a.Date == date && a.Status == "Programada");

        if (medicBusy)
        {
            Console.WriteLine("❌ El médico ya tiene una cita programada en esa fecha y hora.");
            return;
        }
        if (patientBusy)
        {
            Console.WriteLine("❌ El paciente ya tiene una cita programada en esa fecha y hora.");
            return;
        }

        string notes = Helper.ReadNonEmptyLine("Notas adicionales (puede dejar vacío): ");

        var appointment = new Appointment(medic, patient, date, notes)
        {
            Id = Guid.NewGuid()
        };

        appointments.Add(appointment);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Cita registrada exitosamente. ID: {appointment.Id}");
        Console.ResetColor();

        PersonService.ShowAppointmentInfo(appointment);

        // 📧 Send Email to the patient
        string subject = "Confirmación de cita médica - Hospital San Vicente";
        string body = $"Hola {patient.Name},\n\n" +
                      $"Tu cita con el Dr. {medic.Name} (especialidad: {medic.Specialty}) " +
                      $"ha sido programada para el {date:dd/MM/yyyy HH:mm}.\n\n" +
                      $"Notas: {notes}\n\n" +
                      "Por favor, llega 10 minutos antes de la hora programada.\n\n" +
                      "Gracias por confiar en el Hospital San Vicente.";

        // Enviar correo solo al paciente (Mailtrap puede limitar varios envíos)
        EmailHelper.SendAppointmentEmail(patient.Gmail, subject, body);

        System.Threading.Thread.Sleep(2000);
    }


        // ------------------ LISTAR CITAS ------------------
    public void ReadAppointments()
    {
        Console.WriteLine("\n📋 --- Lista de Citas ---");

        if (appointments.Count == 0)
        {
            Console.WriteLine("No hay citas registradas.");
            return;
        }

        foreach (var app in appointments)
        {
            Console.WriteLine($"🆔 {app.Id} | {app.Patient.Name} con {app.Medic.Name} | {app.Date:g} | Estado: {app.Status}");
        }
    }

    // ------------------ BUSCAR CITA POR ID ------------------
    public void FindAppointment()
    {
        Console.WriteLine("\n🔎 --- Buscar Cita ---");
        string idInput = Helper.ReadNonEmptyLine("Ingrese el ID de la cita (GUID): ");

        if (!Guid.TryParse(idInput, out Guid id))
        {
            Console.WriteLine("⚠️ ID no válido. Debe ser un GUID válido.");
            return;
        }

        var appointment = appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            Console.WriteLine("❌ No se encontró una cita con ese ID.");
            return;
        }

        PersonService.ShowAppointmentInfo(appointment);
    }

    // ------------------ ACTUALIZAR ESTADO ------------------
    public void UpdateAppointmentStatus()
    {
        Console.WriteLine("\n✏️ --- Actualizar Estado de Cita ---");
        string idInput = Helper.ReadNonEmptyLine("Ingrese el ID de la cita (GUID): ");

        if (!Guid.TryParse(idInput, out Guid id))
        {
            Console.WriteLine("⚠️ ID no válido. Debe ser un GUID válido.");
            return;
        }

        var appointment = appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            Console.WriteLine("❌ No se encontró una cita con ese ID.");
            return;
        }

        Console.WriteLine("Seleccione el nuevo estado:");
        Console.WriteLine("1. Atendida");
        Console.WriteLine("2. Cancelada");
        Console.WriteLine("3. Programada (restaurar)");

        string option = Helper.ReadNonEmptyLine("Opción: ");

        switch (option)
        {
            case "1":
                appointment.Status = "Atendida";
                break;
            case "2":
                appointment.Status = "Cancelada";
                break;
            case "3":
                appointment.Status = "Programada";
                break;
            default:
                Console.WriteLine("⚠️ Opción no válida.");
                return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Estado actualizado correctamente. Nuevo estado: {appointment.Status}");
        Console.ResetColor();
    }

    // ------------------ ELIMINAR CITA ------------------
    public void DeleteAppointment()
    {
        Console.WriteLine("\n🗑️ --- Eliminar Cita ---");
        string idInput = Helper.ReadNonEmptyLine("Ingrese el ID de la cita (GUID): ");

        if (!Guid.TryParse(idInput, out Guid id))
        {
            Console.WriteLine("⚠️ ID no válido. Debe ser un GUID válido.");
            return;
        }

        var appointment = appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            Console.WriteLine("❌ No se encontró una cita con ese ID.");
            return;
        }

        appointments.Remove(appointment);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🗑️ Cita eliminada correctamente.");
        Console.ResetColor();
    }

    // ------------------ MÉTODO OPCIONAL ------------------
    public List<Appointment> GetAllAppointments()
    {
        return appointments;
    }
}
