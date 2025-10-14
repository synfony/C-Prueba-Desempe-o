public class Medic : Person
{
    public string Specialty { get; set; }

    public Medic(Guid id, string name, string document, string cellphone, string email, string specialty) 
    : base(id, name, document, cellphone, email)
    {
        Specialty = specialty;
    }
}
