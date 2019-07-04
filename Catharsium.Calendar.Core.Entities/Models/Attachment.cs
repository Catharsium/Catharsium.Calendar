namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Attachment
    {
        public virtual string ETag { get; set; }
        public virtual string FileId { get; set; }
        public virtual string FileUrl { get; set; }
        public virtual string Title { get; set; }
        public virtual string MimeType { get; set; }
        public virtual string IconLink { get; set; }
    }
}