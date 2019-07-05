using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;

namespace Catharsium.Calendar.Core.Logic.Output
{
    public class EventJsonSerializer : IEventJsonSerializer
    {
        private readonly JsonSerializer jsonSerializer;


        public EventJsonSerializer(JsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
        }


        public void Serialize(IEnumerable<Event> events)
        {
            using (var file = File.CreateText(@"D:\test.json")) {
                this.jsonSerializer.Serialize(file, events);
            }
        }
    }
}