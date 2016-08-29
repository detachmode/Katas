using System;
using System.Diagnostics;

namespace Kassenbuch
{

    internal class CmdMode
    {
        public static void Start(string[] args)
        {
            Output.OnOutput += Console.WriteLine;
            Output.OnOutput += x => Debug.WriteLine(x);

            Interactions.Add(args);
            Interactions.List(8, 2016);
            
        }
    }

}