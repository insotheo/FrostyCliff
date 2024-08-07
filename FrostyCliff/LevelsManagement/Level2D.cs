using FrostyCliff.Core;
using System;
using System.Collections.Generic;

namespace FrostyCliff.LevelsManagement
{
    public class Level2D : IDisposable
    {
        public List<GamePawn2D> LevelsPawns;

        public Level2D()
        {
            LevelsPawns = new List<GamePawn2D>();
        }

        internal void OnLevelBegin() => OnBegin();
        internal void OnLevelUpdate(double deltaTime) => OnUpdate(deltaTime);

        public void Dispose()
        {
            LevelsPawns.Clear();
            OnDisposed();
        }

        protected virtual void OnBegin() { }
        protected virtual void OnUpdate(double deltaTime) { }
        protected virtual void OnDisposed() { }
    }
}
