using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hashing
{
    /*
     * Maxwell Robinson
     * 10/22/22
     * 
     * Contains a method to encrypt a password
     */
    public static class Hashing
    {
        /*
         * Returns an encrypted string based on the input given
         */
        public static string hash(string input)
        {
            string output;
            string key = "NotThatSharp";

            byte[] hashedInput = UTF8Encoding.UTF8.GetBytes(input);

            using (MD5CryptoServiceProvider md5Hashing = new MD5CryptoServiceProvider())
            {
                byte[] keyValue = md5Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider parameter = new TripleDESCryptoServiceProvider() 
                    {Key = keyValue, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = parameter.CreateEncryptor();
                    byte[] hashedPar = transform.TransformFinalBlock(hashedInput, 0, hashedInput.Length);
                    output = Convert.ToBase64String(hashedPar, 0, hashedPar.Length);
                }
            }

            return output;
        }
    }
}
