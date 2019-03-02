using System.IO;
using System.Threading;
using Catharsium.Calendar.Google.Core.Entities.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarServiceFactory : IGoogleCalendarServiceFactory
    {
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private readonly string applicationName;


        public GoogleCalendarServiceFactory(string applicationName)
        {
            this.applicationName = applicationName;
        }


        public CalendarService CreateService()
        {
            UserCredential credential;

            using (var stream = new FileStream(@"E:\OneDrive\Code\Security\Google Calendar\Credentials Catharsium.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                                Scopes,
                                "Catharsium",
                                CancellationToken.None,
                                new FileDataStore(credPath, true)).Result;
            }
            return new CalendarService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });
        }
    }
}