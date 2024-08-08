using Silk.NET.Input;
using FrostyCliff.Graphics;
using System.Collections.Generic;
using System.Numerics;

namespace FrostyCliff.InputSystem
{
    public static class Input
    {
        private static HashSet<KeyCode> _keysDown = new HashSet<KeyCode>();
        private static HashSet<KeyCode> _keysUp = new HashSet<KeyCode>();
        private static HashSet<MouseButton> _buttonsDown = new HashSet<MouseButton>();
        private static HashSet<MouseButton> _buttonsUp = new HashSet<MouseButton>();
        private static Vector2D _mousePosition = Vector2D.ZeroVector2D();
        private static Vector2D _mouseWorldPosition = Vector2D.ZeroVector2D();

        public static bool IsKeyDown(KeyCode key) => _keysDown.Contains(key);
        public static bool IsKeyUp(KeyCode key) => _keysUp.Contains(key);
        public static bool IsAnyKeyDown() => _keysDown.Count > 0;
        public static bool IsAnyKeyUp() => _keysUp.Count > 0;
        public static bool IsMouseButtonDown(MouseButton button) => _buttonsDown.Contains(button);
        public static bool IsMouseButtonUp(MouseButton button) => _buttonsUp.Contains(button);
        public static bool IsAnyMouseButtonDown() => _buttonsDown.Count > 0;
        public static bool IsAnyMouseButtonUp() => _buttonsUp.Count > 0;
        public static Vector2D GetMousePosition() => _mousePosition;
        public static Vector2D GetMouseWorldPosition() => _mouseWorldPosition;

        internal static void ClearUp()
        {
            _keysUp.Clear();
            _buttonsUp.Clear();
        }

        internal static void OnWindowKeyDown(IKeyboard keyboard, Key key, int code)
        {
            KeyCode keyCode = (KeyCode)key;
            _keysDown.Add(keyCode);
            _keysUp.Remove(keyCode);
        }

        internal static void OnWindowKeyUp(IKeyboard keyboard, Key key, int code)
        {
            KeyCode keyCode = (KeyCode)key;
            _keysDown.Remove(keyCode);
            _keysUp.Add(keyCode);
        }

        internal static void OnWindowButtonDown(IMouse mouse, Silk.NET.Input.MouseButton button)
        {
            MouseButton mouseButton = (MouseButton)button;
            _buttonsDown.Add(mouseButton);
            _buttonsUp.Remove(mouseButton);
        }

        internal static void OnWindowButtonUp(IMouse mouse, Silk.NET.Input.MouseButton button)
        {
            MouseButton mouseButton = (MouseButton)button;
            _buttonsDown.Remove(mouseButton);
            _buttonsUp.Add(mouseButton);
        }

        internal static void OnWindowMouseMove(IMouse mouse, Vector2 vector)
        {
            _mousePosition.X = vector.X;
            _mousePosition.Y = vector.Y;
        }

        internal static void SetMouseWorldPosition(Vector2D worldPosition) => _mouseWorldPosition = worldPosition;

    }
}
