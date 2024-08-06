using System;

namespace FrostyCliff.Core
{
    public static class Log
    {

#if DEBUG
        public static bool IsEnabled = true;
#else
        public static bool IsEnabled = false;
#endif

        private static void Write(string message, string sender)
        {
            if (!IsEnabled)
            {
                return;
            }
            Console.WriteLine($"[{DateTime.Now.ToString("T")}] {sender}: \"{message}\"");
        }


        public static void Trace<T>(T message, string sender = "FrostyCliffCore")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Write(message.ToString(), sender);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info<T>(T message, string sender = "FrostyCliffCore")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Write(message.ToString(), sender);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warn<T>(T message, string sender = "FrostyCliffCore")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write(message.ToString(), sender);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error<T>(T message, string sender = "FrostyCliffCore")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (message is Exception ex)
            {
                Write(ex.Message, sender);
            }
            else
            {
                Write(message.ToString(), sender);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
