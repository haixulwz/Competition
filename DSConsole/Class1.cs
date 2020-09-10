using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DSConsole
{
    public class Class1
    {
        /// <summary> 
        /// DES解密字符串 
        /// </summary> 
        /// <param name="decryptString">待解密的字符串</param> 
        /// <param name="decryptKey">解密密钥,要求为16位,和加密密钥相同</param> 
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns> 

        public static string DecryptDES(string str, string key = "AbcBypal")
        {
            try
            {

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                //// 密钥
                //provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                //// 偏移量
                //provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.Mode = CipherMode.ECB;
                byte[] buffer = new byte[str.Length / 2];
                for (int i = 0; i < (str.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                    buffer[i] = (byte)num2;

                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Close();
                return Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
            }
            catch (Exception e) 
            {
                return "";
            }

        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
