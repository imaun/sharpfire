namespace SharpFire.Models
{
    public class MediafireToken
    {
        public string action { get; set; }
        public string session_token { get; set; }
        public string secret_key { get; set; }
        public string time { get; set; }
        public string ekey { get; set; }
        public string pkey { get; set; }
        public string result { get; set; }
        public string current_api_version { get; set; }
    }

    public class MediafireTokenResult
    {
        public MediafireToken response { get; set; }
    }

    public enum MediafireTokenVersion {
        Version1 = 1,
        Version2 = 2
    }


}
