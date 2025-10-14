// Clase base
public class Person
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Cellphone { get; set; }
    public string Gmail { get; set; }

    public Person(Guid id,string name, string document, string cellphone, string gmail)
    {
        ID = id; 
        Name = name;
        Document = document;
        Cellphone = cellphone;
        Gmail = gmail;
    }
}
