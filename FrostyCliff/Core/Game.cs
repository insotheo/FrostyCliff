using System;
using Silk.NET.Windowing;
using FrostyCliff.Core.WindowSettings;
using Silk.NET.OpenGL;
using Silk.NET.Input;
using FrostyCliff.InputSystem;

namespace FrostyCliff.Core
{
    public abstract class Game : IDisposable
    {
        private int _windowWidth;
        protected int WindowWidth => _windowWidth;

        private int _windowHeight;
        protected int WindowHeight => _windowHeight;

        private IWindow _window;
        private GL _gl;

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

            _window.Load += OnWindowLoad;
            _window.Update += OnWindowUpdate;
            _window.Resize += OnWindowResize;
            _window.Closing += WindowClosing;
        }

        private void OnWindowLoad()
        {
            IInputContext inputContext = _window.CreateInput();
            for(int i = 0; i < inputContext.Keyboards.Count; i++)
            {
                inputContext.Keyboards[i].KeyDown += Input.OnWindowKeyDown;
                inputContext.Keyboards[i].KeyUp += Input.OnWindowKeyUp;
            }
            for(int i = 0; i < inputContext.Mice.Count; i++)
            {
                inputContext.Mice[i].MouseDown += Input.OnWindowButtonDown;
                inputContext.Mice[i].MouseUp += Input.OnWindowButtonUp;
                inputContext.Mice[i].MouseMove += Input.OnWindowMouseMove;
            }

            _gl = _window.CreateOpenGL();
            OnBegin();
        }

        private void OnWindowUpdate(double deltaTime)
        {
            Input.ClearUp();
        }

        private void OnWindowResize(Silk.NET.Maths.Vector2D<int> size)
        {
            _windowWidth = size.X;
            _windowHeight = size.Y;
            _gl.Viewport(_window.Size);
            OnResized();
        }

        private void WindowClosing() => OnClosing();

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

        #region WindowEvents

        protected virtual void OnBegin() { }
        protected virtual void OnResized() { }
        protected virtual void OnClosing() { }

        #endregion

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
