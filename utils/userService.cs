public class PersonService
{
    public static void PatientInfo(Patient patient)
    {
        Console.WriteLine("----- Información del Paciente-----");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Nombre: {patient.Name}");
        Console.WriteLine($"Documento: {patient.Document}");
        Console.WriteLine($"Telefono: {patient.Cellphone}");
        Console.WriteLine($"Email: {patient.Gmail}");
        Console.WriteLine($"Edad: {patient.Age}");
        Console.ResetColor();

    }

    public static void MedicInfo(Medic medic)
    {
        Console.WriteLine("----- Información del Paciente-----");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Nombre: {medic.Name}");
        Console.WriteLine($"Documento: {medic.Document}");
        Console.WriteLine($"Telefono: {medic.Cellphone}");
        Console.WriteLine($"Email: {medic.Gmail}");
        Console.WriteLine($"Especialidad: {medic.Specialty}");
        Console.ResetColor();
    }

    public static void ShowAppointmentInfo(Appointment appointment)
    {
        
        Console.WriteLine("\n----- Información de la Cita -----");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"🆔 ID: {appointment.Id}");
        Console.WriteLine($"🩺 Médico: {appointment.Medic.Name} ({appointment.Medic.Specialty})");
        Console.WriteLine($"👤 Paciente: {appointment.Patient.Name}, Documento: {appointment.Patient.Document}");
        Console.WriteLine($"📅 Fecha: {appointment.Date}");
        Console.WriteLine($"📋 Estado: {appointment.Status}");
        Console.ResetColor();
        if (!string.IsNullOrWhiteSpace(appointment.Notes))
            Console.WriteLine($"🗒️ Notas: {appointment.Notes}");
    }
}
