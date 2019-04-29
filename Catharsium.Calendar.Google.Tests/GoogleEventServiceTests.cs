using System;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Catharsium.Calendar.Google.Tests._Mocks;
using Catharsium.Util.Testing;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using static Google.Apis.Calendar.v3.EventsResource;

namespace Catharsium.Calendar.Google.Tests
{
    [TestClass]
    public class GoogleEventServiceTests : TestFixture<GoogleEventService>
    {
        #region Fixture

        private string CalendarId => "My calendar id";

        private IClientService ClientService { get; set; }
        private MockEventsResource EventsResource { get; set; }


        [TestInitialize]
        public void SetupGoogleDependencies()
        {
            var calendarService = Substitute.For<CalendarService>();
            this.GetDependency<ICalendarClientFactory>().CreateClient().Returns(calendarService);
            this.ClientService = Substitute.For<IClientService>();
            this.EventsResource = new MockEventsResource(this.ClientService);
            calendarService.Events.Returns(this.EventsResource);
            this.SetDependency(calendarService);
        }

        #endregion

        [TestMethod]
        [Ignore]
        public void Create_MakesRequest_ReturnsEvent()
        {
            var summary = "My summary";
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(1);
            var googleEvent = new Event();
            var insertRequest = new MockEventInsertRequest(this.ClientService, googleEvent, this.CalendarId);
            this.EventsResource.InsertRequestSubstitute = insertRequest;
            var expected = new Core.Entities.Models.Event();
            this.GetDependency<IMapper>().Map<Core.Entities.Models.Event>(googleEvent).Returns(expected);

            var actual = this.Target.CreateEvent(this.CalendarId, summary, start, end);
            insertRequest.Received().Execute();
            Assert.AreEqual(expected, actual);
        }


        //            public Event CreateEvent(string calendarId, string summary, DateTime start, DateTime end)
        //{
        //    var newEvent = new global::Google.Apis.Calendar.v3.Data.Event
        //    {
        //        Summary = summary,
        //        Start = new global::Google.Apis.Calendar.v3.Data.EventDateTime { DateTime = start },
        //        End = new global::Google.Apis.Calendar.v3.Data.EventDateTime { DateTime = end }
        //    };
        //    var request = this.calendarService.Events.Insert(newEvent, calendarId);
        //    return this.mapper.Map<Event>(request.Execute());
        //}
    }
}
