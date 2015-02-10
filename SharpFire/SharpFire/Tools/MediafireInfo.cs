using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace SharpFire.Tools
{
    public static class MediafireInfo
    {
        public const string URL_Get_Session_Token = @"https://www.mediafire.com/api/1.3/user/get_session_token.php";

        public const string URL_Sample_Upload = @"https://www.mediafire.com/api/upload/upload.php";


    }

    public struct MediafireResponseFormat
    {
        public const string Json = "Json";
        public const string Xml = "xml";
    }
}
