using FrostyCliff.Core;
using FrostyCliff.Core.WindowSettings;
using FrostyCliff.Graphics;
using FrostyCliff.LevelsManagement;

namespace TestPingPong
{
    internal class MyGame : Game
    {
        public MyGame() : base(1280, 720, "Demo ping pong", new Color(0.6f, 0.45f, 0.7f),
            true, WindowBorderType.Resizable, WindowState.Normal)
        {
            LevelsManager.AddNewLevel("MyLevel", new MyLevel());
        }

        protected override void OnBegin()
        {
            LevelsManager.RunLevel("MyLevel");
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
