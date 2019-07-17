using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class JsonEventRepository : IEventRepository
    {
        private readonly IFileFactory fileFactory;
        private readonly JsonSerializer jsonSerializer;
        private readonly CalendarCoreLogicConfiguration options;


        public JsonEventRepository(IFileFactory fileFactory, JsonSerializer jsonSerializer, CalendarCoreLogicConfiguration options)
        {
            this.fileFactory = fileFactory;
            this.jsonSerializer = jsonSerializer;
            this.options = options;
        }


        public IEnumerable<Event> LoadAll()
        {
            var directory = this.fileFactory.CreateDirectory($@"{this.options.SerializationFolder}");
            var result = new List<Event>();
            foreach (var file in directory.GetFiles())
            {
                result.AddRange(this.Load(file));
            }
            return result;
        }


        public IEnumerable<Event> Load(string fileName)
        {
            var file = this.fileFactory.CreateFile($@"{this.options.SerializationFolder}\{fileName}.json");
            return this.Load(file);
        }


        private IEnumerable<Event> Load(IFile file)
        {
            using (var textReader = new JsonTextReader(file.OpenText()))
            {
                return (IEnumerable<Event>)this.jsonSerializer.Deserialize(textReader, typeof(IEnumerable<Event>));
            }
        }


        public void Store(IEnumerable<Event> events, string fileName)
        {
            var file = this.fileFactory.CreateFile($@"{this.options.SerializationFolder}\{fileName}.json");
            using (var streamWriter = new StreamWriter(file.OpenWrite()))
            using (var textWriter = new JsonTextWriter(streamWriter))
            {
                this.jsonSerializer.Serialize(textWriter, events);
            }
        }
    }
}