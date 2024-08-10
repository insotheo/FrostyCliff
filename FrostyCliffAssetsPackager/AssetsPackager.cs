using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FrostyCliffAssetsPackager
{
    internal static class AssetsPackager
    {

        internal static void CreatePackage(string name, string key, string initFolder, string saveFolder)
        {
            try
            {
                if (!Directory.Exists(initFolder) || !Directory.Exists(saveFolder))
                {
                    throw new DirectoryNotFoundException("Save folder or init folder directory doesn't exist!");
                }
                if(key.Length != 32)
                {
                    throw new Exception("Key length is not 32 chars!");
                }

                Console.WriteLine("-------------------------");

                string packagePath = Path.Combine(saveFolder, name + ".fcpack");
                using(FileStream packageStream = new FileStream(packagePath, FileMode.Create))
                {
                    using(BinaryWriter writer = new BinaryWriter(packageStream))
                    {
                        foreach(string file in Directory.GetFiles(initFolder, "*.*", SearchOption.AllDirectories))
                        {
                            string relativePath = Path.GetRelativePath(initFolder, file);
                            Console.WriteLine($"Encrypting {relativePath}...");

                            byte[] encryptedContent = EncryptFile(file, key);
                            writer.Write(relativePath);
                            writer.Write(encryptedContent.Length);
                            writer.Write(encryptedContent);
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Assets package \"{name}\" created at \"{packagePath}\"!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static byte[] EncryptFile(string filePath, string key)
        {
            using(Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();
                byte[] iv = aes.IV;
                using(MemoryStream ms =  new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);
                    using(CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using(FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            fs.CopyTo(cs);
                        }
                    }
                    return ms.ToArray();
                }
            }
        }


    }
}
