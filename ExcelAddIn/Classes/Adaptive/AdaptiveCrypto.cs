using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    class AdaptiveCrypto
    {
        /// <summary>
        /// Calculate the SHA512 hash of an input string
        /// </summary>
        /// <param name="s">The string to be hashed</param>
        /// <returns>Hashed string</returns>
        public static string SHA512EncryptPassword(string s)
        {
            return AdaptiveCrypto.ComputeShaHash(s, 512, false);
        }

        /// <summary>
        /// Hashes a string using one of the sha algorithms - 1, 256 or 512
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="shaVersion">Version of the sha algorythm - Sha1, Sha256, Sha512; defaults to Sha1</param>
        /// <param name="useBase64Encoding">Whether or not use base64 encoding for a returned string</param>
        /// <returns>Hashed string</returns>
        public static string ComputeShaHash(string s, int shaVersion, bool useBase64Encoding = false)
        {

            //get an array of bytes off the string

            byte[] sb = System.Text.Encoding.UTF8.GetBytes(s);

            //container for hashed string
            byte[] ob;

            switch (shaVersion)
            {
                case 1:
                default:
                    using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
                    {
                        ob = sha.ComputeHash(sb);
                    }
                    break;
                case 256:
                    using (SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider())
                    {
                        ob = sha.ComputeHash(sb);
                    }
                    break;
                case 512:
                    using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
                    {
                        ob = sha.ComputeHash(sb);
                    }
                    break;
            }

            if (useBase64Encoding)
            {
                return Convert.ToBase64String(ob);
            }
            else
            {
                //remove the dashes and make string lowercase
                return BitConverter.ToString(ob).Replace("-", "").ToLower();
            }
        }
    }
}
