using System;
using Silk.NET.Windowing;
using FrostyCliff.Core.WindowSettings;

namespace FrostyCliff.Core
{
    public abstract class Game : IDisposable
    {
        private int _windowWidth;
        protected int WindowWidth => _windowWidth;

        private int _windowHeight;
        protected int WindowHeight => _windowHeight;

        private IWindow _window;

        protected Game(int width, int height, string title, bool VSync = false, WindowBorderType border = WindowBorderType.Resizable, WindowSettings.WindowState state = WindowSettings.WindowState.Normal)
        {
            _windowWidth = width;
            _windowHeight = height;

            WindowOptions windowOptions = WindowOptions.Default;
            windowOptions.Size = new Silk.NET.Maths.Vector2D<int>(width, height);
            windowOptions.Title = title;
            windowOptions.VSync = VSync;
            windowOptions.WindowBorder = (WindowBorder)border;
            windowOptions.WindowState = (Silk.NET.Windowing.WindowState)state;

            _window = Window.Create(windowOptions);

        }



        public void Run()
        {
            if(_window == null)
            {
                Log.Error("Window is null");
                return;
            }
            _window.Run();
        }

        public void Dispose()
        {
            _window.Dispose();
        }

        #region WindowSettingsAndInfo
        protected void SetVSync(bool vsync) => _window.VSync = vsync;
        protected bool GetVSync() => _window.VSync;

        protected void SetWindowBorderType(WindowBorderType type) => _window.WindowBorder = (WindowBorder)type;
        protected WindowBorderType GetWindowBorderType() => (WindowBorderType)_window.WindowBorder;

        protected void SetWindowState(WindowSettings.WindowState state) => _window.WindowState = (Silk.NET.Windowing.WindowState)state;
        protected WindowSettings.WindowState GetWindowState() =>(WindowSettings.WindowState)_window.WindowState;
        #endregion
    }
}
