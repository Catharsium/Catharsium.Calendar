using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using static Google.Apis.Calendar.v3.EventsResource;

namespace Catharsium.Calendar.Google.Tests._Mocks
{
    public class MockEventInsertRequest : InsertRequest
    {
        public Event Body { get; }


        public MockEventInsertRequest(IClientService service, Event body, string calendarId) : base(service, body, calendarId)
        {
            this.Body = body;
        }


        public new Event Execute()
        {
            return this.Body;
        }
    }
}