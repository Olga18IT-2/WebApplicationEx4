using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication
{
    public static class SignGeneration
    {
        public static string GetSign(string login)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] hash = provider.ComputeHash(Encoding.Default.GetBytes(login));
            return BitConverter.ToString(hash).ToLower().Replace("-", "");
        }
    }
}