using System.Data;
using ConsoleApp1;
using Npgsql;

const string connectionString =
    "Server=localhost;Port=5432;Database=test_db;User Id=postgres;Password=1234;Search Path=public";
var db = new NpgsqlConnection(connectionString);

const string sql = """
                   SELECT table_persons.id AS id,
                          table_persons.name AS name,
                          table_contacts.email AS email,
                          table_contacts.phone AS phone
                   FROM table_persons
                       JOIN table_contacts 
                           ON table_persons.id = table_contacts.person_id;
                   """;
db.Open();
var command = new NpgsqlCommand(sql, db);
var result = command.ExecuteReader();
var persons = new List<Person>();
if (result.HasRows)
{
    while (result.Read())
    {
        var person = new Person
        {
            Id = result.GetInt32("id"),
            Name = result.GetString("name"),
            Contacts = new Contacts
            {
                Email = result.GetString("email"),
                Phone = result.GetString("phone")
            }
        };
        persons.Add(person);
    }
}
db.Close();

foreach (var person in persons)
{
    Console.WriteLine($"{person.Id} \t {person.Name} \t {person.Contacts.Email} \t {person.Contacts.Phone}");
}