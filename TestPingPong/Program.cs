using FrostyCliff.Core;
using TestPingPong;

class Program
{
    static void Main()
    {
        Log.Info("Hello, World!");
        using(MyGame game = new MyGame())
        {
            game.Run();
        }
    }
}