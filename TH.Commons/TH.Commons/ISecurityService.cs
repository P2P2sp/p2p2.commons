using System;

namespace TH.Commons
{
    public interface ISecurityService
    {
        bool Validate(string givenSignature, string privateKey, Guid token, params object[] items);
        string CalculateSignature(string privateKey, params object[] items);
    }
}