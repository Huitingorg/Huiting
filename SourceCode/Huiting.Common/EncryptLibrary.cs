using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Management;

namespace BDSoft.PTApi
{
    public class EncryptLibrary
    {
        public static string Decrypt(string cipherText, string passPhrase)
        {
            string s = "s@1tVaLueXX*";
            string strHashName = "MD5";
            int iterations = 2;
            string str3 = "@1B2c3D4e5F6g7H8";
            int num2 = 0x100;
            byte[] bytes = Encoding.ASCII.GetBytes(str3);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(s);
            byte[] buffer = Convert.FromBase64String(cipherText);
            byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, strHashName, iterations).GetBytes(num2 / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            stream.Close();
            stream2.Close();
            return Encoding.UTF8.GetString(buffer5, 0, count);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strPlainText"></param>
        /// <returns></returns>
        public static string DecryptDefault(string strPlainText)
        {
            try
            {
                string plainText = "SlOilDbFrameWork";
                string passPhrase = Encrypt(plainText, "@#$%12345");
                return Decrypt(strPlainText, passPhrase);
            }
            catch
            {
                return "";
            }
        }
        public static string Encrypt(string plainText, string passPhrase)
        {
            string s = "s@1tVaLueXX*";
            string strHashName = "MD5";
            int iterations = 2;
            string str3 = "@1B2c3D4e5F6g7H8";
            int num2 = 0x100;
            byte[] bytes = Encoding.ASCII.GetBytes(str3);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(s);
            byte[] buffer = Encoding.UTF8.GetBytes(plainText);
            byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, strHashName, iterations).GetBytes(num2 / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strPlainText"></param>
        /// <returns></returns>
        public static string EncryptDefault(string strPlainText)
        {
            try
            {
                string plainText = "SlOilDbFrameWork";
                string passPhrase = Encrypt(plainText, "@#$%12345");
                return Encrypt(strPlainText, passPhrase);
            }
            catch
            {
                return "";
            }
        }
    }
}
