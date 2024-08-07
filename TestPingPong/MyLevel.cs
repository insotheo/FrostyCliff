using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.LevelsManagement;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(1, 1), Rotation = 0 });

        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
            player.RendererObject = new Rectangle2D(new Color(0, 0, 0, 0.75f));
            LevelsPawns.Add(player);
        }

        protected override void OnUpdate(double deltaTime)
        {
            player.Transform.Rotation += 3.1415926f / 4;
        }

    }
}
