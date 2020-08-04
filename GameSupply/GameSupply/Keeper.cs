using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    static class Keeper
    {
        const string str = "По Мурманску гуляет полосатый бегемот, в день съедая по 2 пары носок.";
        private static string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }
            var p = r;
            while (p.Length < n)
            {
                p += p;
            }
            return p.Substring(0, n);
        }
        private static string Cipher(string text, string secretKey, bool encoding = true)
        {
            if (!encoding)
                text = FromHexString(text);
            var currentKey = GetRepeatKey(secretKey, text.Length);

            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }
            if (encoding)
                res = ToHexString(res);
            return res;
        }
        public static string Encrypt(string plainText, string password = str)
            => Cipher(plainText, password);
        public static string Decrypt(string encryptedText, string password = str)
            => Cipher(encryptedText, password, false);
        private static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }
    }
}
