namespace Catharsium.Calendar.Google.Core.Entities.Models.Events
{
    public class Reminder
    {
        public virtual string Method { get; set; }
        public virtual int? Minutes { get; set; }
        public virtual string ETag { get; set; }
    }
}