using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Aop.Api.Domain;

namespace Common.F2FPay
{
    /// <summary>
    /// 高级加密标准（英语：Advanced Encryption Standard，缩写：AES），在密码学中又称Rijndael加密法，是美国联邦政府采用的一种区块加密标准。
    /// 这个标准用来替代原先的DES，已经被多方分析且广为全世界所使用。经过五年的甄选流程，高级加密标准由美国国家标准与技术研究院（NIST）
    /// 于2001年11月26日发布于FIPS PUB 197，并在2002年5月26日成为有效的标准。2006年，高级加密标准已然成为对称密钥加密中最流行的算法之一。
    /// </summary>
    public class AES
    {

        private string _iv = string.Empty;
        private string _key = string.Empty;

        #region 属性
        
        /// <summary>
        /// 获取密钥
        /// </summary>
        private  string Key
        {
            get
            {
                if (string.IsNullOrEmpty(this._key))
                {
                    throw new Exception("AES加密未设置密钥key");
                }
                return this._key;
            }
        }

        public AES SetKey(string key)
        {
            this._key = key;
            return this;
        }
        /// <summary>
        /// 获取向量
        /// </summary>
        public  string IV
        {
            get
            {
                if (string.IsNullOrEmpty(_iv))
                {
                    throw new Exception("AES加密未设置向量iv的值");
                }
                return this._iv;
            }
        }

        public AES SetIV(string iv)
        {
            this._iv = iv;
            return this;
        }

        #endregion

        #region Encrypt加密
        
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <returns>密文</returns>
        public  string Encrypt(string plainStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(this.Key);
            byte[] bIV = Encoding.UTF8.GetBytes(this.IV);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(byteArray, 0, byteArray.Length);
                    cStream.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(mStream.ToArray());
                }
            }
            aes.Clear();
            return encrypt;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public  string Encrypt(string plainStr, bool returnNull)
        {
            string encrypt = this.Encrypt(plainStr);
            return returnNull ? encrypt : (encrypt ?? String.Empty);
        }

        #endregion

        #region Decrypt解密
        
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        public  string Decrypt(string encryptStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(this.Key);
            byte[] bIV = Encoding.UTF8.GetBytes(this.IV);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(byteArray, 0, byteArray.Length);
                    cStream.FlushFinalBlock();
                    decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                }
            }
            aes.Clear();
            return decrypt;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public  string Decrypt(string encryptStr, bool returnNull)
        {
            string decrypt = Decrypt(encryptStr);
            return returnNull ? decrypt : (decrypt ?? String.Empty);
        }

        #endregion
    }
}
