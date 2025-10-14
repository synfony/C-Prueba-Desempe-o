public class PatientService : IPatientService
{
    private List<Patient> patients = new List<Patient>();

    // RegisterPatient(): read input and add patient
    public void RegisterPatient()
    {
        Console.WriteLine("\n👤 Registrar Nuevo Paciente");
        string name = Helper.ReadNonEmptyLine("nombre: ");
        string document = Helper.ReadNonEmptyLine("Documento: ");

        if (Helper.ValidationHelper.IsDocumentDuplicate(patients, document))
            return;

        string phone = Helper.ReadNonEmptyLine("Telefono: ");
        if (!Helper.ValidationHelper.IsValidPhone(phone))
            return;

        string email = Helper.ReadNonEmptyLine("Email: ");
        if (!Helper.ValidationHelper.IsValidEmail(email))
            return;

        byte age = Helper.ReadByte("Edad: ");

        Guid id = Guid.NewGuid();
        Patient patient = new Patient(id, name, document, phone, email, age);
        patients.Add(patient);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Paciente {patient.Name} Registrado exitosamente!");
        Console.ResetColor();
    }

    // ReadPatient(): list all patients
    public void ReadPatient()
    {
        Console.WriteLine("\n📋 Lista de Pacientes:");
        if (patients.Count == 0)
        {
            Console.WriteLine("sin pacientes registrados");
            return;
        }

        foreach (var p in patients)
        {
            PersonService.PatientInfo(p);
        }
    }

    // FindPatient(): show details by document
    public void FindPatient()
    {
        Console.WriteLine("\n🔎 Encontrar paciente");
        string document = Helper.ReadNonEmptyLine("Ingresar documento: ");
        var patient = patients.FirstOrDefault(p => p.Document == document);
        if (patient == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Paciente no encontrado.");
            Console.ResetColor();
            return;
        }

        PersonService.PatientInfo(patient);
    }

    // UpdatePatient(): update fields
    public void UpdatePatient()
    {
        Console.WriteLine("\n✏️ Actualizar Paciente");
        string document = Helper.ReadNonEmptyLine("ingresar documento: ");
        var patient = patients.FirstOrDefault(p => p.Document == document);
        if (patient == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Paciente no encontrado.");
            Console.ResetColor();
            return;
        }

        string newPhone = Helper.ReadNonEmptyLine($"Nuevo telefono (current: {patient.Cellphone}): ");
        if (!Helper.ValidationHelper.IsValidPhone(newPhone))
            return;

        string newEmail = Helper.ReadNonEmptyLine($"Nuevo email (current: {patient.Gmail}): ");
        if (!Helper.ValidationHelper.IsValidEmail(newEmail))
            return;

        byte newAge = Helper.ReadByte($"Nueva edad (current: {patient.Age}): ");

        patient.Cellphone = newPhone;
        patient.Gmail = newEmail;
        patient.Age = newAge;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✏️ Paciente {patient.Name} Actualizado con exito!");
        Console.ResetColor();
    }

    // DeletePatient(): delete by document
    public void DeletePatient()
    {
        Console.WriteLine("\n🗑️ Borrar paciente");
        string document = Helper.ReadNonEmptyLine("Ingresar documento: ");
        var patient = patients.FirstOrDefault(p => p.Document == document);
        if (patient == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Paciente no encontrado.");
            Console.ResetColor();
            return;
        }

        patients.Remove(patient);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"🗑️ Paciente {patient.Name} borrado exitosamente!");
        Console.ResetColor();
    }

    // Optional: expose list for other services if needed
    public List<Patient> GetAllPatients() => patients;
}
