using System;

namespace Kassenbuch
{

    public static class Output
    {
        public static event Action<string> OnOutput;

        public static event Action<string> OnError;


        public static void OutputError(string msg)
        {
            OnError?.Invoke(msg);
        }

        public static void OutputLine(string line)
        {
            OnOutput?.Invoke(line);
        }
    }

}