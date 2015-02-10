using System;
using System.Security.Cryptography;
using System.Text;
using SharpFire.Models;

namespace SharpFire.Tools
{
    public static class MediafireSignature
    {
        public static string Build(MediafireAccount account)
        {
            string data = account.Email + account.Password + account.AppId + account.ApiKey;
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash;
            using (SHA1 sha1 = new SHA1Managed())
                hash = sha1.ComputeHash(bytes);
            string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return hashString;
        }

        public static string Build(string email, string password, string appId, string apiKey)
        {
            return Build(new MediafireAccount
            {
                Email = email,
                Password = password,
                AppId = appId,
                ApiKey = apiKey
            });
        }
    }
}
