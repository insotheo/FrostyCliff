using CSCore;
using CSCore.SoundOut;
using System.Collections.Generic;
using System.Linq;

namespace FrostyCliff.AudioSystem
{
    internal static class AudiosHandler
    {
        internal static List<ISoundOut> SoundOuts = new List<ISoundOut>();
        internal static List<IWaveSource> WaveSources = new List<IWaveSource>();

        internal static void AddISoundOut(ISoundOut soundOut)
        {
            if (soundOut != null && !SoundOuts.Contains(soundOut))
            {
                SoundOuts.Add(soundOut);
            }
        }

        internal static void AddIWaveSource(IWaveSource source)
        {
            if (source != null && !WaveSources.Contains(source))
            {
                WaveSources.Add(source);
            }
        }

        internal static void StopAllSounds()
        {
            foreach (var soundOut in SoundOuts.ToList())
            {
                soundOut.Stop();
                soundOut.Dispose();
            }
            SoundOuts.Clear();

            foreach (var waveSource in WaveSources.ToList())
            {
                waveSource.Dispose();
            }
            WaveSources.Clear();
        }

    }
}
