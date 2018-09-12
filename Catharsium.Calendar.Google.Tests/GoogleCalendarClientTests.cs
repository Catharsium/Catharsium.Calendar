using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using static Google.Apis.Calendar.v3.EventsResource;

namespace Catharsium.Calendar.Google.Tests
{
    [TestClass]
    public class GoogleCalendarClientTests
    {
        [TestMethod]
        public void GetEvents()
        {
            //var calendarService = new MockCalendarService();
            var eventsResource = new MockEventsResource(null);
            var calendarService = Substitute.For<CalendarService>();
            
            calendarService.Events.Returns(eventsResource);
            
            var factory = Substitute.For<IGoogleCalendarServiceFactory>();
            factory.CreateService().Returns(calendarService);
            var target = new GoogleCalendarClient(factory);

            var actual = target.GetEvents();
            Assert.IsNotNull(actual);
        }


        public class MockEventsResource : EventsResource
        {
            public MockEventsResource(IClientService service) : base(service)
            {
            }

            public override ListRequest List(string calendarId)
            {
                var listRequest = new MockListRequest();
                return listRequest;
            }
        }



        public class MockListRequest : ListRequest
        {
            public MockListRequest(IClientService service, string calendarId) : base(service, calendarId)
            {
            }

            public override Execute()
        }
    }
}