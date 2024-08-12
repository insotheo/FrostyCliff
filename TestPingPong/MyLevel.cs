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
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, 0), Scale = new Vector2D(1, 1), Rotation = 0 });
        GamePawn2D rect = new GamePawn2D(new Transform2D { Position = new Vector2D(100, 200), Scale = new Vector2D(70, 40), Rotation = 0 });

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

            LevelsPawns.Add(player);
            LevelsPawns.Add(rect);

            Log.Info(Math.EuclideanDistance(player.Transform.Position, rect.Transform.Position));
            //SetCamera2DZoom(2f);
        }
        
        const float speed = 5f;

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

        }
    }
}
