public class Patient : Person
{
    public int Age { get; set; }

    public Patient(Guid id, string name, string document, string cellphone, string email, int age)
        : base(id, name, document, cellphone, email )
    {
        Age = age;
    }
}