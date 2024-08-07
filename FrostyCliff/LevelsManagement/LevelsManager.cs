using FrostyCliff.Core;
using System.Collections.Generic;

namespace FrostyCliff.LevelsManagement
{
    public static class LevelsManager
    {

        private static Dictionary<string, Level2D> _levels = new Dictionary<string, Level2D>()
        {
            {"EMPTY_STARTED_LEVEL_BY_FROSTY_CLIFF", new Level2D()}
        };

        private static string _currentLevelName = "EMPTY_STARTED_LEVEL_BY_FROSTY_CLIFF";

        public static void AddNewLevel(string levelName, Level2D level) => _levels.Add(levelName, level);
        public static void RemoveLevel(string name) => _levels.Remove(name);
        public static Level2D GetCurrentLevel() => _levels[_currentLevelName];
        public static string GetCurrentLevelName() => _currentLevelName;
        public static bool IsLevelExist(string name) => _levels.ContainsKey(name);
        public static bool IsLevelExist(Level2D level) => _levels.ContainsValue(level);
        public static void RunLevel(string name)
        {
            if (!IsLevelExist(name))
            {
                Log.Error($"Level \"{name}\" doesn't exist in current context!");
                return;
            }
            GetCurrentLevel().Dispose();
            _currentLevelName = name;
            _levels[_currentLevelName].OnLevelBegin();
        }

    }
}
