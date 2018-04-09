using System;
using System.Resources;

namespace P2P2.Commons
{
    public static class TranslateExtensions
    {
        public static string Translate(this string key, ResourceManager mgr)
        {
            return mgr.GetString(key) ?? key;
        }

        public static string Translate(this Enum key, ResourceManager mgr)
        {
            return mgr.GetString(key.ToString()) ?? key.ToString();
        }
    }
}