using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.InputSystem;
using FrostyCliff.LevelsManagement;
using FrostyCliff.AssetsManager;
using FrostyCliff.AudioSystem;
using FrostyCliff.Physics;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(1, 1), Rotation = Math.DegToRad(70) });
        GamePawn2D rect = new GamePawn2D(new Transform2D { Position = new Vector2D(100, 200), Scale = new Vector2D(70, 40), Rotation = Math.DegToRad(30) });
        Audio bloodAndWine = new Audio(AssetsLoader.Load("bloodAndWine.wav"));

        protected override void OnBegin()
        {
            InitPhysicsWorld2D();
            Log.Info("Hello from MyLevel!");

            player.RendererObject = new Sprite2D(AssetsLoader.Load("logo.png"));
            player.Transform.Scale = (player.RendererObject as Sprite2D).GetOriginalTextureScale() / 2;

            rect.RendererObject = new Rectangle2D(new Color(1f, 0f, 1f));

            player.CreatePhysicsObject(PhysicsBodyType.Static);
            rect.CreatePhysicsObject(PhysicsBodyType.Kinematic);

            PhysicsWorld.AddPhysicsObject(player);
            PhysicsWorld.AddPhysicsObject(rect);
            
            bloodAndWine.Volume = 2f;

            LevelsPawns.Add(player);
            LevelsPawns.Add(rect);

            Log.Info(Math.EuclideanDistance(player.Transform.Position, rect.Transform.Position));
            //SetCamera2DZoom(2f);
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
