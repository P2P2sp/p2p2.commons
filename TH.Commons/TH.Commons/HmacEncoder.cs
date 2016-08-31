using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TH.Commons
{
    public class HmacEncoder
    {
        public static string EncodeSha256(string key, string input)
        {
            using (var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(key)))
            {
                var byteArray = Encoding.ASCII.GetBytes(input);
                return hmac
                    .ComputeHash(byteArray)
                    .Aggregate("", (s, e) => s + $"{e:x2}", s => s);
            }
        }
    }
}
