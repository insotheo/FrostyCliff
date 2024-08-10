using System;

namespace FrostyCliffAssetsPackager
{
    class Program
    {
        static void Main()
        {
            string packageName, encryptionKey, initFolder, saveFolder;
            Console.WriteLine("Welcome to FrostyCliffAssetsPackager!");
            Console.Write("Enter the name of new package: ");
            packageName = Console.ReadLine();
            Console.Write($"Enter the ecnryption key for {packageName}(32 CHARS!!!): ");
            encryptionKey = Console.ReadLine();
            Console.Write("Enter the path to folder with assets: ");
            initFolder = Console.ReadLine();
            Console.Write("Enter the path to folder where to save package: ");
            saveFolder = Console.ReadLine();

            AssetsPackager.CreatePackage(packageName, encryptionKey, initFolder, saveFolder);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
