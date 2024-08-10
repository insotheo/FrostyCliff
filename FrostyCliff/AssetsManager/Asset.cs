using System.IO;

namespace FrostyCliff.AssetsManager
{
    public class Asset
    {
        private MemoryStream _mStream;

        internal Asset(MemoryStream ms)
        {
            _mStream = ms;
            _mStream.Position = 0;
        }

        internal MemoryStream GetStream() => _mStream;

    }
}
