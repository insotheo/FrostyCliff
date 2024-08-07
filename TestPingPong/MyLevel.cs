using FrostyCliff.Core;
using FrostyCliff.LevelsManagement;

namespace TestPingPong
{
    internal class MyLevel : Level2D
    {
        protected override void OnBegin()
        {
            Log.Info("Hello from MyLevel!");
        }
    }
}
