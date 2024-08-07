using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.InputSystem;
using FrostyCliff.LevelsManagement;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(0.5f, 0.5f), Rotation = 0 });

        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
            player.RendererObject = new Rectangle2D(new Color(0, 0, 0, 0.75f));
            LevelsPawns.Add(player);
            Log.Info(Math.EuclideanDistance(player.Transform.Position, new Vector2D(1, 1)));
        }

        float speed = 0.01f;

        protected override void OnUpdate(double deltaTime)
        {
            if (Input.IsKeyDown(KeyCode.W))
                player.Transform.Position.Y += speed;
            if (Input.IsKeyDown(KeyCode.S))
                player.Transform.Position.Y -= speed;
            if (Input.IsKeyDown(KeyCode.D))
                player.Transform.Position.X += speed;
            if (Input.IsKeyDown(KeyCode.A))
                player.Transform.Position.X -= speed;
        }

    }
}
