using System;

namespace Kassenbuch
{

    public static class Output
    {
        public static event Action<string> OnOutput;


        public static void OutputLine(string line)
        {
            OnOutput?.Invoke(line);
        }
    }

}