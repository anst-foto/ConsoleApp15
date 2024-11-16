namespace ConsoleApp1;

public class Contacts
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Contacts Contacts { get; set; }
}