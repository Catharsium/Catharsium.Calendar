using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarServiceFactory : IGoogleCalendarServiceFactory
    {
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private static string ApplicationName = "Catharsium.Calendar.Google";

        public CalendarService CreateService()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                                Scopes,
                                "user",
                                CancellationToken.None,
                                new FileDataStore(credPath, true)).Result;
            }
            return new CalendarService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
    }
}