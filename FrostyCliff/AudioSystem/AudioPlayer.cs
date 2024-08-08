namespace FrostyCliff.AudioSystem
{
    public static class AudioPlayer
    {

        public static void Play(ref Audio audio) => audio.Play();
        public static void Stop(ref Audio audio) => audio.Stop();
        public static void Pause(ref Audio audio) => audio.Pause();
        public static bool IsPlaying(ref Audio audio) => audio.IsPlaying();
        public static void Dispose(ref Audio audio) => audio.Dispose();

        public static void Play(Audio audio) => audio.Play();
        public static void Stop(Audio audio) => audio.Stop();
        public static void Pause(Audio audio) => audio.Pause();
        public static bool IsPlaying(Audio audio) => audio.IsPlaying();
        public static void Dispose(Audio audio) => audio.Dispose();
    }
}
