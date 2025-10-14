using System.Data.Common;

public class MenuService
{
    // New instances 
    private static IMedicService medicService = new MedicService();
    private static IPatientService patientService = new PatientService();

    private static AppointmentService appointmentService = new AppointmentService(
    (MedicService)medicService, 
    (PatientService)patientService
);

    public static void Main()
    {
// ------------------- OBJETOS DE EJEMPLO -------------------

// Crear médico de ejemplo
Medic medicEjemplo = new Medic(
    id: Guid.NewGuid(),
    name: "Dr. Juan Pérez",
    document: "M001",
    cellphone: "3124567890",
    email: "juanperez@hospital.com",
    specialty: "Cardiología"
);

// Crear paciente de ejemplo
Patient patientEjemplo = new Patient(
    id: Guid.NewGuid(),
    name: "Carlos Gómez",
    document: "P001",
    cellphone: "3009876543",
    email: "carlosgomez@mail.com",
    age: 35
);

// Crear cita de ejemplo (asociando ambos)
Appointment citaEjemplo = new Appointment(
    medic: medicEjemplo,
    patient: patientEjemplo,
    date: DateTime.Now.AddDays(2).AddHours(10),
    notes: "Control general de rutina"
)
{
    Id = Guid.NewGuid()
};

// ------------------- GUARDAR EN LISTAS -------------------

// Agregar médico y paciente a sus servicios
((MedicService)medicService).GetAllMedics().Add(medicEjemplo);
((PatientService)patientService).GetAllPatients().Add(patientEjemplo);

// Agregar cita a su servicio
appointmentService.GetAllAppointments().Add(citaEjemplo);

// ------------------- MOSTRAR INFORMACIÓN -------------------
Console.WriteLine("\n✅ Datos de ejemplo cargados correctamente:");
PersonService.MedicInfo(medicEjemplo);
PersonService.PatientInfo(patientEjemplo);
PersonService.ShowAppointmentInfo(citaEjemplo);


        bool salir = false;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🏥 Bienvenido al Sistema de Gestión del Hospital San Vicente");
        Console.ResetColor();

        while (!salir)
        {
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Gestionar Médicos");
            Console.WriteLine("2. Gestionar Pacientes");
            Console.WriteLine("3. Gestionar citas");
            Console.WriteLine("4. Salir");

            string opcion = Helper.ReadNonEmptyLine("Seleccione una opción: ");

            switch (opcion)
            {
                case "1":
                    MenuMedicos();
                    break;
                case "2":
                    MenuPacientes();
                    break;
                case "3":
                    MenuCitas();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("\n👋 Saliendo del sistema... ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida, por favor intente nuevamente.");
                    break;
            }
        }
    }

    // ---------------------- MENÚ OF THE MEDICS ---------------------- //
    private static void MenuMedicos()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine("\n--- 🩺 MENÚ DE MÉDICOS ---");
            Console.WriteLine("1. Registrar médico");
            Console.WriteLine("2. Listar médicos");
            Console.WriteLine("3. Buscar médico");
            Console.WriteLine("4. Actualizar médico");
            Console.WriteLine("5. Eliminar médico");
            Console.WriteLine("6. Volver al menú principal");

            string opcion = Helper.ReadNonEmptyLine("Seleccione una opción: ");

            switch (opcion)
            {
                case "1":
                    medicService.RegisterMedic();
                    break;
                case "2":
                    medicService.ReadMedic();
                    break;
                case "3":
                    medicService.FindMedic();
                    break;
                case "4":
                    medicService.UpdateMedic();
                    break;
                case "5":
                    medicService.DeleteMedic();
                    break;
                case "6":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida, por favor intente nuevamente.");
                    break;
            }
        }
    }

    // ---------------------- MENU OF PATIENTS ---------------------- //
    private static void MenuPacientes()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine("\n--- 👤 MENÚ DE PACIENTES ---");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Buscar paciente");
            Console.WriteLine("4. Actualizar paciente");
            Console.WriteLine("5. Eliminar paciente");
            Console.WriteLine("6. Volver al menú principal");

            string opcion = Helper.ReadNonEmptyLine("Seleccione una opción: ");

            switch (opcion)
            {
                case "1":
                    patientService.RegisterPatient();
                    break;
                case "2":
                    patientService.ReadPatient();
                    break;
                case "3":
                    patientService.FindPatient();
                    break;
                case "4":
                    patientService.UpdatePatient();
                    break;
                case "5":
                    patientService.DeletePatient();
                    break;
                case "6":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida, por favor intente nuevamente.");
                    break;
            }
        }
    }

    // ---------------------- MENÚ DE CITAS ---------------------- //
    private static void MenuCitas()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine("\n--- 📅 MENÚ DE CITAS ---");
            Console.WriteLine("1. Agendar cita");
            Console.WriteLine("2. Listar todas las citas");
            Console.WriteLine("3. Buscar cita por ID");
            Console.WriteLine("4. Actualizar estado de cita");
            Console.WriteLine("5. Eliminar cita");
            Console.WriteLine("6. Volver al menú principal");

            string opcion = Helper.ReadNonEmptyLine("Seleccione una opción: ");

            switch (opcion)
            {
                case "1":
                    appointmentService.ScheduleAppointment();
                    break;
                case "2":
                    appointmentService.ReadAppointments();
                    break;
                case "3":
                    appointmentService.FindAppointment();
                    break;
                case "4":
                    appointmentService.UpdateAppointmentStatus();
                    break;
                case "5":
                    appointmentService.DeleteAppointment();
                    break;
                case "6":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida, por favor intente nuevamente.");
                    break;
            }
        }
    }
}
