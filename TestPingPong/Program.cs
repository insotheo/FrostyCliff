using FrostyCliff.AssetsManager;
using FrostyCliff.Core;
using TestPingPong;
using System.IO;

class Program
{
    static void Main()
    {
        AssetsLoader.CreateInstance(Path.Combine(Directory.GetCurrentDirectory(), "myassets.fcpack"), "12345678900987654321123456789012");
        Log.Info("Hello, World!");
        using(MyGame game = new MyGame())
        {
            game.Run();
        }
    }
}