using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthouseDev.Api.Managers
{
    public static class JwtCredentials
    {
        public const string Issuer = "http://coding.com";
        public const string Audience = "http://coding.com";
        public const string Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==";

        public static string EncodeAndHash(string password)
        {
            if (string.IsNullOrEmpty(password)) 
                return string.Empty;

            var base64Encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(base64Encode);
        }
    }
}
