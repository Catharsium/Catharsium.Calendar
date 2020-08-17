using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Storage
{
    public class JsonCalendarStorage : ICalendarStorage
    {
        private readonly IFileFactory fileFactory;
        private readonly IJsonFileReader jsonFileReader;
        private readonly IJsonFileWriter jsonFileWriter;
        private readonly CalendarCoreLogicConfiguration options;


        public JsonCalendarStorage(
            IFileFactory fileFactory,
            IJsonFileReader jsonFileReader,
            IJsonFileWriter jsonFileWriter,
            CalendarCoreLogicConfiguration options)
        {
            this.fileFactory = fileFactory;
            this.jsonFileReader = jsonFileReader;
            this.jsonFileWriter = jsonFileWriter;
            this.options = options;
        }


        public async Task<IEnumerable<Event>> LoadAll()
        {
            return await Task.Run<IEnumerable<Event>>(() => {
                var directory = this.fileFactory.CreateDirectory($@"{this.options.SerializationFolder}");
                var result = new List<Event>();
                foreach (var file in directory.GetFiles()) {
                    result.AddRange(this.Load(file));
                }

                return result;
            });
        }


        public async Task<IEnumerable<Event>> Load(string fileName)
        {
            return await Task.Run(() => {
                var file = this.fileFactory.CreateFile($@"{this.options.SerializationFolder}\{fileName}.json");
                return this.Load(file);
            });
        }


        private IEnumerable<Event> Load(IFile file)
        {
            return this.jsonFileReader.ReadFrom<IEnumerable<Event>>(file);
        }


        public async Task Store(IEnumerable<Event> events, string fileName)
        {
            await Task.Run(() => this.jsonFileWriter.Write(events, $@"{this.options.SerializationFolder}\{fileName}.json"));
        }
    }
}