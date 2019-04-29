using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace Catharsium.Calendar.Google.Tests
{
    public class MockEventsResource : EventsResource
    {
        public InsertRequest InsertRequestSubstitute { get; set; }


        public MockEventsResource(IClientService clientService) : base(clientService)
        {
        }


        public override InsertRequest Insert(Event body, string calendarId)
        {
            return this.InsertRequestSubstitute;
        }
    }
}