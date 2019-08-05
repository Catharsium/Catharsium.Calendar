using Catharsium.Calendar.Google._Configuration;
using Catharsium.Calendar.Google.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Catharsium.Calendar.Google.Client
{
    public class GoogleCalendarClientFactory : ICalendarClientFactory
    {
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private readonly Credentials[] credentialsList;
        private Dictionary<Credentials, CalendarService> CalendarServices { get; set; }

        public string UserName { get; set; }


        public GoogleCalendarClientFactory(Credentials[] credentialsList)
        {
            this.credentialsList = credentialsList;
            this.CalendarServices = new Dictionary<Credentials, CalendarService>();
            foreach (var credentials in this.credentialsList)
            {
                this.CalendarServices[credentials] = this.CreateFor(credentials);
            }
        }


        public string[] GetUserNames()
        {
            return this.credentialsList.Select(c => c.UserName).ToArray();
        }


        public CalendarService Get()
        {
            return this.CalendarServices.FirstOrDefault(c => c.Key.UserName == this.UserName).Value;
        }


        private CalendarService CreateFor(Credentials credentials)
        {
            if (credentials == null)
            {
                return null;
            }

            UserCredential credential;

            using (var stream = new FileStream(credentials.Path, FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    credentials.UserName,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = credentials.ApplicationName
            });
        }
    }
}