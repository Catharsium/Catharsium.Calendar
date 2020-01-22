using AutoMapper;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Data.Google._Configuration.AutoMapper.Mappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using GoogleEventDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;

namespace Catharsium.Calendar.Data.Google.Tests._Configuration.AutoMapper.Mappers
{
    [TestClass]
    public class DateMapperTests : TestFixture<DateMapper>
    {
        #region Fixture

        private IRuntimeMapper Mapper { get; set; }
        private ResolutionContext Context { get; set; }


        [TestInitialize]
        public void SetupDependencies()
        {
            this.Mapper = Substitute.For<IRuntimeMapper>();
            this.Context = new ResolutionContext(null, this.Mapper);
        }

        #endregion

        [TestMethod]
        public void Resolve_DateField_SetHasTimeToFalse_ReturnsDate()
        {
            var expected = DateTime.Now.Date;
            var input = new GoogleEventDateTime {Date = expected.ToString("yyyy-MM-dd")};
            var output = new Date {HasTime = true};

            var actual = this.Target.Resolve(input, output, DateTime.MaxValue, this.Context);
            Assert.IsFalse(output.HasTime);
            Assert.AreEqual(expected, output.Value);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Resolve_DateTimeField_SetsHasTimeToTrue_ReturnsDateTime()
        {
            var expected = DateTime.Now;
            var input = new GoogleEventDateTime {DateTime = expected};
            var output = new Date {HasTime = false};

            var actual = this.Target.Resolve(input, output, DateTime.MaxValue, this.Context);
            Assert.IsTrue(output.HasTime);
            Assert.AreEqual(expected.Date, output.Value.Date);
            Assert.AreEqual(expected.Hour, output.Value.Hour);
            Assert.AreEqual(expected.Minute, output.Value.Minute);
            Assert.AreEqual(expected.Second, output.Value.Second);
            Assert.AreEqual(output.Value, actual);
        }


        [TestMethod]
        public void Resolve_DateTimeAndDateField_UsesDateTimeField()
        {
            var expected = DateTime.Now;
            var input = new GoogleEventDateTime {
                DateTime = expected,
                Date = DateTime.MinValue.ToString("yyyy-MM-dd")
            };
            var output = new Date {HasTime = true};

            var actual = this.Target.Resolve(input, output, DateTime.MaxValue, this.Context);
            Assert.IsTrue(output.HasTime);
            Assert.AreEqual(expected.Date, output.Value.Date);
            Assert.AreEqual(expected.Hour, output.Value.Hour);
            Assert.AreEqual(expected.Minute, output.Value.Minute);
            Assert.AreEqual(expected.Second, output.Value.Second);
            Assert.AreEqual(output.Value, actual);
        }
    }
}