using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.InputSystem;
using FrostyCliff.LevelsManagement;
using System.IO;
using FrostyCliff.AudioSystem;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(0.5f, 0.5f), Rotation = 0 });
        Audio bloodAndWine = new Audio(Path.Combine(Directory.GetCurrentDirectory(), "GameAssets", "bloodAndWine.wav"));

        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
            player.RendererObject = new Sprite2D(Path.Combine(Directory.GetCurrentDirectory(), "GameAssets", "logo.png"));
            (player.RendererObject as Sprite2D).ColorMask.Alpha = 0.5f;
            player.Transform.Scale = (player.RendererObject as Sprite2D).GetOriginalTextureScale() / 2;
            bloodAndWine.Volume = 2f;
            LevelsPawns.Add(player);
            Log.Info(Math.EuclideanDistance(player.Transform.Position, new Vector2D(1, 1)));
            SetCamera2DZoom(2f);
        }
        
        float speed = 5f;
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

            if (Input.IsKeyUp(KeyCode.M))
            {
                if(!AudioPlayer.IsPlaying(ref bloodAndWine))
                {
                    AudioPlayer.Play(ref bloodAndWine);
                }
                else
                {
                    AudioPlayer.Stop(ref bloodAndWine);
                }
            }
            if (Input.IsKeyUp(KeyCode.N))
            {
                Log.Info(AudioPlayer.IsPlaying(ref bloodAndWine));
            }

            player.Transform.Rotation += Math.DegToRad(deg);
        }

        protected override void OnDisposed()
        {
            bloodAndWine.Dispose();
        }

    }
}
