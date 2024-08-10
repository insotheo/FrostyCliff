using FrostyCliff.Core;
using FrostyCliff.Graphics;
using FrostyCliff.Physics;
using System;
using System.Collections.Generic;

namespace FrostyCliff.LevelsManagement
{
    public class Level2D : IDisposable
    {
        public List<GamePawn2D> LevelsPawns;
        public PhysicsWorld2D PhysicsWorld;

        private Camera2D _levelsCamera;

        public Level2D()
        {
            LevelsPawns = new List<GamePawn2D>();
            _levelsCamera = new Camera2D();
        }

        internal void OnLevelBegin()
        {
            foreach(GamePawn2D pawn in LevelsPawns)
            {
                pawn.OnPawnBegin();
            }
            OnBegin();
        }

        internal void OnLevelUpdate(double deltaTime)
        {
            if(PhysicsWorld != null)
            {
                PhysicsWorld.Update(deltaTime);
            }
            foreach(GamePawn2D pawn in LevelsPawns)
            {
                pawn.OnPawnUpdate(deltaTime);
            }
            OnUpdate(deltaTime);
        }

        internal Camera2D GetLevelCamera2D() => _levelsCamera;

        public void Dispose()
        {
            LevelsPawns.Clear();
            OnDisposed();
        }

        protected void SetCamera2D(Camera2D camera) => _levelsCamera = camera;
        protected Camera2D GetCamera2D() => _levelsCamera;
        protected void SetCamera2DPosition(Vector2D position) => _levelsCamera.Position = position;
        protected void SetCamera2DZoom(float zoom)
        {
            if(zoom <= 0)
            {
                Log.Error("Zoom less or equal to zero!");
                zoom = 1f;
            }
            _levelsCamera.Zoom = zoom;
        }

        protected virtual void OnBegin() { }
        protected virtual void OnUpdate(double deltaTime) { }
        protected virtual void OnDisposed() { }
    }
}
