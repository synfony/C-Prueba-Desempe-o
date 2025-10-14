
public class MedicService : IMedicService
{
    private List<Medic> medics = new List<Medic>();

    // RegisterMedic(): reads from console and adds a new doctor
    public void RegisterMedic()
    {
        Console.WriteLine("\n🩺 Registrar nuevo medico");
        string name = Helper.ReadNonEmptyLine("Nombre: ");
        string document = Helper.ReadNonEmptyLine("Documento: ");

        // check duplicate first (uses ValidationHelper which prints message on failure)
        if (Helper.ValidationHelper.IsDocumentDuplicate(medics, document))
            return;

        string phone = Helper.ReadNonEmptyLine("Telefono: ");
        if (!Helper.ValidationHelper.IsValidPhone(phone))
            return;

        string email = Helper.ReadNonEmptyLine("Email: ");
        if (!Helper.ValidationHelper.IsValidEmail(email))
            return;

        string specialty = Helper.ReadNonEmptyLine("Especialidad: ");

        Guid id = Guid.NewGuid();
        Medic medic = new Medic(id, name, document, phone, email, specialty);
        medics.Add(medic);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Medico {medic.Name} ha sido registrado exitosamente");
        Console.ResetColor();
    }

    // ReadMedic(): list all medics
    public void ReadMedic()
{
    Console.WriteLine("\n📋 --- Lista de Médicos ---");

    if (medics.Count == 0)
    {
        Console.WriteLine("⚠️ No hay médicos registrados todavía.");
        return;
    }

    Console.Write("🔍 Ingrese una especialidad para filtrar (o presione ENTER para ver todos): ");
    string filtro = Console.ReadLine()?.Trim() ?? "";

    IEnumerable<Medic> medicsToShow;

    if (string.IsNullOrWhiteSpace(filtro))
    {
        medicsToShow = medics;
    }
    else
    {
        medicsToShow = medics.Where(m => 
            m.Specialty != null && 
            m.Specialty.Contains(filtro, StringComparison.OrdinalIgnoreCase)
        );

        if (!medicsToShow.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n⚠️ No se encontraron médicos con la especialidad '{filtro}'.");
            Console.ResetColor();
            return;
        }
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    foreach (var m in medicsToShow)
    {
        PersonService.MedicInfo(m);
    }
    Console.ResetColor();
}

    // FindMedic(): find by document and show details
    public void FindMedic()
    {
        Console.WriteLine("\n🔎 Encontrar Medico");
        string document = Helper.ReadNonEmptyLine("ingresar documento: ");
        var medic = medics.FirstOrDefault(m => m.Document == document);
        if (medic == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Medico no encontrado.");
            Console.ResetColor();
            return;
        }

        PersonService.MedicInfo(medic);

    }

    // UpdateMedic(): prompt document, update fields
    public void UpdateMedic()
    {
        Console.WriteLine("\n✏️ Actualizar Medico");
        string document = Helper.ReadNonEmptyLine("Ingresar documento: ");
        var medic = medics.FirstOrDefault(m => m.Document == document);
        if (medic == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Medico no encontrado.");
            Console.ResetColor();
            return;
        }

        // For fields: read and validate
        string newPhone = Helper.ReadNonEmptyLine($"Nuevo telefono (current: {medic.Cellphone}): ");
        if (!Helper.ValidationHelper.IsValidPhone(newPhone))
            return;

        string newEmail = Helper.ReadNonEmptyLine($"Nuevo email (current: {medic.Gmail}): ");
        if (!Helper.ValidationHelper.IsValidEmail(newEmail))
            return;

        string newSpecialty = Helper.ReadNonEmptyLine($"Nueva especialidad (current: {medic.Specialty}): ");

        medic.Cellphone = newPhone;
        medic.Gmail = newEmail;
        medic.Specialty = newSpecialty;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✏️ Medico {medic.Name} Actualizado con exito!");
        Console.ResetColor();
    }

    // DeleteMedic(): prompt document and delete
    public void DeleteMedic()
    {
        Console.WriteLine("\n🗑️ Borrar medico");
        string document = Helper.ReadNonEmptyLine("Ingresar documento: ");
        var medic = medics.FirstOrDefault(m => m.Document == document);
        if (medic == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Medico no encontrado.");
            Console.ResetColor();
            return;
        }

        medics.Remove(medic);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"🗑️ Medico {medic.Name} borrado con exito!");
        Console.ResetColor();
    }

    public List<Medic> GetAllMedics()
{
    return medics;
}

}
