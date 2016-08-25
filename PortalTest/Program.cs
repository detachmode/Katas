using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTest
{
    class Program
    {
        static CommandlineUi ui = new CommandlineUi();
        private static event Action<string, Exception> HandleError;
        private static event Action<string> PrintMessage;
        static void Main(string[] args)
        {

            HandleError += ui.HandleError;
            PrintMessage += ui.PrintMessage;

            try
            {
                CmdParser.Parse(args, ExecuteOptionAdd, ExecuteOptionInteractive, ui.HandleError);
            }
            catch (Exception ex)
            {
                HandleError("Leider gab es ein Problem. " + ex.Message, ex);
            }
        }


        private static void ExecuteOptionInteractive()
        {
            var numbers = ui.ReadNumbers();
            var result = Interactions.Add(numbers.Item1, numbers.Item2);
            PrintMessage(result);
        }


        private static void ExecuteOptionAdd(int x, int y)
        {
            var result = Interactions.Add(x, y);
            PrintMessage(result);
        }
    }
}
