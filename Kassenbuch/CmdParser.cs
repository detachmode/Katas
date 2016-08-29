using System;
using System.Diagnostics;
using Kassenbuch;

namespace PortalTest
{

    class CmdParser
    {
        public static void Parse(string[] args, Action<string[]> on3CmdParameter, Action onNoCmdParameter,
            Action<string, Exception> onError)
        {
            if (args.Length == 3)
            {
                try
                {
                    on3CmdParameter(args);
                }
                catch (FormatException ex)
                {
                    onError("Fehler beim Parsen der Eingabeparameter. " + ex.Message, ex);
                }
            }
            if (args.Length == 0)
            {
                onNoCmdParameter();
            }
        }
    }

}