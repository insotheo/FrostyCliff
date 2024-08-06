using FrostyCliff.Core;
using FrostyCliff.Core.WindowSettings;

namespace TestPingPong
{
    internal class MyGame : Game
    {
        public MyGame() : base(1280, 720, "Demo ping pong",
            true, WindowBorderType.Resizable, WindowState.Normal)
        {
            
        }

        protected override void OnResized()
        {
            Log.Trace($"width = {WindowWidth} ; height = {WindowHeight}");
        }

        protected override void OnClosing()
        {
            Log.Info("Goodbye");
        }

    }
}
