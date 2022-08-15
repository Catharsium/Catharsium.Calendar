namespace Catharsium.Clients.GoogleCalendar.Models;

public class Attendee
{
    public virtual string Id { get; set; }
    public virtual string ETag { get; set; }

    public virtual string Email { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual bool? Organizer { get; set; }
    public virtual int? AdditionalGuests { get; set; }
    public virtual bool? Optional { get; set; }
    public virtual string Comment { get; set; }

    public virtual bool? Resource { get; set; }
    public virtual string ResponseStatus { get; set; }
    public virtual bool? Self { get; set; }
}