using FrostyCliff.Core;
using CSCore;
using CSCore.SoundOut;
using System;
using System.IO;
using FrostyCliff.AssetsManager;
using CSCore.Codecs.WAV;

namespace FrostyCliff.AudioSystem
{
    public class Audio : IDisposable
    {
        private ISoundOut _soundOut;
        private IWaveSource _waveStream;
        private float _volume;

        public Audio(Asset asset)
        {
            if(asset == null)
            {
                Log.Error("Asset is null!");
                return;
            }
            loadAudio(asset.GetStream());
            _volume = 1.0f;
        }

        public float Volume
        {
            get => _volume;
            set => _volume = Core.Math.Clamp(value, 0.0f, 2.0f);
        }

        internal void Play()
        {
            _waveStream.Position = 0;
            _soundOut = new WasapiOut();
            _soundOut.Initialize(_waveStream);
            _soundOut.Volume = _volume;
            _soundOut.Play();

            AudiosHandler.AddISoundOut(_soundOut);
            AudiosHandler.AddIWaveSource(_waveStream);
        }

        internal void Stop() => _soundOut.Stop();

        internal void Pause() => _soundOut.Pause();

        internal bool IsPlaying() => _soundOut?.PlaybackState == PlaybackState.Playing ? true : false;

        public void Dispose()
        {
            _soundOut?.Stop();
            _soundOut?.Dispose();
            _waveStream?.Dispose();

            AudiosHandler.SoundOuts.Remove(_soundOut);
            AudiosHandler.WaveSources.Remove(_waveStream);
        }

        private void loadAudio(MemoryStream ms)
        {
            if (ms == null)
            {
                Log.Error($"Can't load audio from null asset!");
                return;
            }

            _waveStream = new WaveFileReader(ms);
            AudiosHandler.AddIWaveSource(_waveStream);
        }
    }
}
