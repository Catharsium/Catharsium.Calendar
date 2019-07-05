using Google.Apis.Calendar.v3.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Catharsium.Calendar.Core.Logic.Output
{
    public class EventJsonWriter
    {
        public void Write(IEnumerable<Event> events)
        {
            using (var file = File.CreateText(@"D:\test.json"))
            {
                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                serializer.Serialize(file, events);
            }
        }
    }
}