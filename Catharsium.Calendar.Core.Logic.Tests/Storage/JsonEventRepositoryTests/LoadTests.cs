using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Storage;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic.Tests.Storage.JsonEventRepositoryTests
{
    [TestClass]
    public class LoadTests : TestFixture<JsonEventRepository>
    {
        //[TestMethod]
        //public void Load_()
        //{
        //    var fileName = "My file name";
        //    var jsonSerializer = Substitute.For<JsonSerializer>();
        //    var file = Substitute.For<IFile>();
        //    this.GetDependency<IFileFactory>().CreateFile

        //    var expected = new List<Event>();
        //    jsonSerializer.Deserialize(Arg.Any<JsonTextReader>(), typeof(IEnumerable<Event>)).Returns(expected);
        //    this.SetDependency(jsonSerializer);

        //    var actual = this.Target.Load(fileName);
        //    Assert.AreEqual(expected, actual);
        //}

        //public IEnumerable<Event> Load(string fileName)
        //{
        //    var file = this.fileFactory.CreateFile($@"{this.options.SerializationFolder}\{fileName}.json");
        //    using (var textReader = new JsonTextReader(file.OpenText()))
        //    {
        //        return (IEnumerable<Event>)this.jsonSerializer.Deserialize(textReader, typeof(IEnumerable<Event>));
        //    }
        //}
    }
}