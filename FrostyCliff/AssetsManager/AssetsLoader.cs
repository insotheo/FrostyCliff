using FrostyCliff.Core;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FrostyCliff.AssetsManager
{
    public static class AssetsLoader
    {
        private static string _encryptionKey;
        private static string _packagePath;

        public static void CreateInstance(string pathToPackage, string key)
        {
            if(key.Length != 32)
            {
                Log.Error("Decryption key length is not equal to 32!");
                return;
            }
            if (!File.Exists(pathToPackage))
            {
                Log.Error($"Assets package not found at \"{pathToPackage}\"");
                return;
            }
            _encryptionKey = key;
            _packagePath = pathToPackage;
        }

        public static Asset Load(string path)
        {
            try
            {
                using (FileStream packageStream = new FileStream(_packagePath, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(packageStream))
                    {
                        while (packageStream.Position < packageStream.Length)
                        {
                            string filePath = reader.ReadString();
                            int fileLength = reader.ReadInt32();
                            byte[] encryptedContent = reader.ReadBytes(fileLength);
                            MemoryStream decryptedStream = DecryptFile(encryptedContent);

                            if (filePath.Equals(path, StringComparison.OrdinalIgnoreCase))
                            {
                                return new Asset(decryptedStream);
                            }
                        }
                    }
                }
                throw new FileNotFoundException($"File not found at \"{path}\"");
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }

        public static bool IsInited() => !(_encryptionKey == null || _packagePath == null);

        private static MemoryStream DecryptFile(byte[] encryptedContent)
        {
            using(Aes aes = Aes.Create())
            {
                using(MemoryStream ms = new MemoryStream(encryptedContent))
                {
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length);
                    aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
                    aes.IV = iv;

                    MemoryStream decryptedStream = new MemoryStream();
                    using(CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cs.CopyTo(decryptedStream);
                    }
                    decryptedStream.Position = 0;
                    return decryptedStream;
                }
            }
        }

    }
}
