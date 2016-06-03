using System;
using System.Diagnostics;

namespace TH.Commons
{
    public class SecurityService : ISecurityService
    {
        public bool Validate(string givenSignature, string privateKey, Guid token, params object[] items)
        {
            var input = token.ToString("N") + string.Join("", items);
            var encodedSignature = CalculateSignature(privateKey, input);
            Debug.WriteLine("Encoded signature: {0} - given {1}", encodedSignature, givenSignature.ToLowerInvariant());
            return String.Equals(encodedSignature, givenSignature, StringComparison.InvariantCultureIgnoreCase);
        }

        public string CalculateSignature(string privateKey, params object[] items)
        {
            var input = string.Join("", items).ToLowerInvariant();
            return HmacEncoder.EncodeSha256(privateKey, input).ToLowerInvariant();
        }
    }
}