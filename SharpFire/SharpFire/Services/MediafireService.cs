using SharpFire.Models;
using RestSharp;
using System.IO;
using SharpFire.Tools;

namespace SharpFire.Services
{
    public class MediafireService
    {

        private RestClient _client;

        public MediafireService()
        {
            _client = new RestClient();
        }


        public MediafireTokenVersion TokenVersion { get; set; }

        public MediafireToken SessionToken { get; set; }

        public MediafireAccount Account { get; set; }

        public string Signature {
            get { return MediafireSignature.Build(Account); }
        }


        /// <summary>
        /// Get session token for authenticate user
        /// </summary>
        /// <returns>A Session Token</returns>
        public MediafireToken GetSessionToken() {
            var request = new RestRequest(MediafireInfo.URL_Get_Session_Token, Method.POST);
            request.AddParameter("signature", Signature);
            request.AddParameter("email", Account.Email);
            request.AddParameter("password", Account.Password);
            request.AddParameter("application_key", Account.ApiKey);
            request.AddParameter("application_id", Account.AppId);
            request.AddParameter("token_version", ((int)TokenVersion).ToString());
            request.AddParameter("response_format", MediafireResponseFormat.Json);
            var response = _client.Execute<MediafireTokenResult>(request);
            if (response.Data == null)
                return null;
            SessionToken = response.Data.response;
            return SessionToken;
        }


        /// <summary>
        /// Simple Upload API - be sure to call GetSessionToken before this method
        /// </summary>
        /// <param name="filename">Local File full path to Upload to MediaFire</param>
        public void SimpleUpload(string filename)
        {
            var request = new RestRequest(MediafireInfo.URL_Sample_Upload , Method.POST);
            request.AddParameter("session_token", SessionToken.session_token);
            var stream = File.OpenRead(filename);
            var fileInfo = new FileInfo(filename);
            request.AddFile(fileInfo.Name, filename);
            request.AddParameter("Filedata", stream);
            //request.AddHeader("Filedata", stream);

            var response = _client.Execute(request);
        }

    }
}
