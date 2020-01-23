using Catharsium.Calendar.Core.Logic._Configuration.Settings;

namespace Catharsium.Calendar.Core.Logic._Configuration
{
    public class CalendarCoreLogicConfiguration
    {
        public string SerializationFolder { get; set; }
        public CalendarSettings[] CalendarSettings { get; set; }
    }
}