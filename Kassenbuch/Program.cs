using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using PortalTest;

namespace Kassenbuch
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            CmdParser.Parse(args,
                on3CmdParameter: CmdMode.Start, 
                onNoCmdParameter: GUI.Open,
                onError: Console.WriteLine);
        }
    }

}