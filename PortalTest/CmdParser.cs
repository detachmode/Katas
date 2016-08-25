using System;

namespace PortalTest
{

    class CmdParser
    {
        public static void Parse(string[] args, Action<int, int> onOptionAddNumbers, Action onOptionInteractive, Action<string, Exception> onError)
        {
            if (args.Length == 2)
            {
                try
                {
                    onOptionAddNumbers(int.Parse(args[0]), int.Parse(args[1]));
                }
                catch (FormatException ex)
                {
                    onError("Fehler beim Parsen der Eingabeparameter. " + ex.Message, ex);
                }
            }
            if (args.Length == 0)
            {
                onOptionInteractive();
            }
        }
    }

}