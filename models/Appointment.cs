public class Appointment
{
    public Guid Id { get; set; }                  // Identificador único de la cita
    public Medic Medic { get; set; }                // Médico asignado
    public Patient Patient { get; set; }            // Paciente asignado
    public DateTime Date { get; set; }              // Fecha y hora de la cita
    public string Status { get; set; }              // Estado: Programada, Cancelada, Atendida
    public string Notes { get; set; }               // Notas opcionales

    public Appointment(Medic medic, Patient patient, DateTime date, string notes = "")
    {
        Id = Id;
        Medic = medic;
        Patient = patient;
        Date = date;
        Status = "Programada";
        Notes = notes;
    }


    
}