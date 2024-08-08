using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.InputSystem;
using FrostyCliff.LevelsManagement;
using System.IO;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(0.5f, 0.5f), Rotation = 0 });

        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
            player.RendererObject = new Sprite2D(Path.Combine(Directory.GetCurrentDirectory(), "GameAssets", "logo.png"));
            LevelsPawns.Add(player);
            Log.Info(Math.EuclideanDistance(player.Transform.Position, new Vector2D(1, 1)));
            SetCamera2DZoom(500f);
        }
        
        float speed = 0.01f;
        int deg = 0;

        protected override void OnUpdate(double deltaTime)
        {
            if (Input.IsKeyDown(KeyCode.W))
                GetCamera2D().Position.Y += speed;
            if (Input.IsKeyDown(KeyCode.S))
                GetCamera2D().Position.Y -= speed;
            if (Input.IsKeyDown(KeyCode.D))
                GetCamera2D().Position.X += speed;
            if (Input.IsKeyDown(KeyCode.A))
                GetCamera2D().Position.X -= speed;

            if (Input.IsKeyUp(KeyCode.Z))
                deg += 1;
            if (Input.IsKeyUp(KeyCode.X))
                deg -= 1;

            if (Input.IsKeyDown(KeyCode.M))
            {
                Log.Warn(Input.GetMousePosition());
                Log.Warn(Input.GetMouseWorldPosition());
            }


            player.Transform.Rotation += Math.DegToRad(deg);
        }

    }
}
