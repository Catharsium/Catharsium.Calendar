namespace Catharsium.Clients.GoogleCalendar.Models;

public class Person
{
    public virtual string Id { get; set; }
    public virtual string Email { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual bool? Self { get; set; }
}