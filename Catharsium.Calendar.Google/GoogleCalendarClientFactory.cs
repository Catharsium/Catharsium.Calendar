using System.IO;
using System.Threading;
using Catharsium.Calendar.Google.Core.Entities.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Catharsium.Calendar.Google
{
    public class GoogleCalendarClientFactory : ICalendarClientFactory
    {
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private readonly string applicationName;
        private readonly string credentialsPath;
        private readonly string userName;


        public GoogleCalendarClientFactory(string credentialsPath, string applicationName, string userName)
        {
            this.credentialsPath = credentialsPath;
            this.applicationName = applicationName;
            this.userName = userName;
        }


        public CalendarService CreateClient()
        {
            UserCredential credential;

            using (var stream = new FileStream(this.credentialsPath, FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                                Scopes,
                                this.userName,
                                CancellationToken.None,
                                new FileDataStore(credPath, true)).Result;
            }
            return new CalendarService(new BaseClientService.Initializer {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });
        }
    }
}