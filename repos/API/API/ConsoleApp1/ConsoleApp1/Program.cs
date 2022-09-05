using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication5.code
{
    public class KeyGenerator
    {
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            byte[] data = new byte[maxSize];
            using (RNGCryptoServiceProvider crpto = new RNGCryptoServiceProvider())
            {
                crpto.GetNonZeroBytes(data);
            }
            stringBuilder result = new stringBuilder();

            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }
    }
}