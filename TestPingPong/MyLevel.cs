using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.LevelsManagement;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D();

        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
            player.RendererObject = new Rectangle2D(new Color(0, 0, 0, 0.5f));
            LevelsPawns.Add(player);
        }

        protected override void OnUpdate(double deltaTime)
        {
            
        }

    }
}
