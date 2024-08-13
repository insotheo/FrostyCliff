using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.InputSystem;
using FrostyCliff.LevelsManagement;
using FrostyCliff.AssetsManager;
using FrostyCliff.AudioSystem;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        GamePawn2D player = new GamePawn2D(new Transform2D { Position = new Vector2D(0, -50), Scale = new Vector2D(1, 1), Rotation = 0 });
        GamePawn2D rect = new GamePawn2D(new Transform2D { Position = new Vector2D(100, 200), Scale = new Vector2D(70, 40), Rotation = 0 });
        GamePawn2D rect2 = new GamePawn2D(new Transform2D { Position = new Vector2D(100, 100), Scale = new Vector2D(50, 50), Rotation = 0 });

        protected override void OnBegin()
        {
            InitPhysicsWorld2D();
            Log.Info("Hello from MyLevel!");

            player.RendererObject = new Sprite2D(AssetsLoader.Load("logo.png"));
            player.Transform.Scale = (player.RendererObject as Sprite2D).GetOriginalTextureScale() / 2;

            rect.RendererObject = new Rectangle2D(new Color(0f, 0.5f, 1f));
            rect2.RendererObject = new Rectangle2D(new Color(0f, 0f, 1f));

            LevelsPawns.Add(player);
            LevelsPawns.Add(rect);
            LevelsPawns.Add(rect2);

            Log.Info(Math.EuclideanDistance(player.Transform.Position, rect.Transform.Position));
            //SetCamera2DZoom(2f);
        }
        
        const float speed = 1f;

        protected override void OnUpdate(double deltaTime)
        {

        }
    }
}
