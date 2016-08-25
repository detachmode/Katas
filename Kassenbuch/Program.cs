using System;
using System.Diagnostics;
using System.Threading;

namespace Kassenbuch
{

    internal class Program
    {
        [STAThread]
        public static void OpenGui()
        {
            var thread = new Thread(() =>
            {
                var mainwindow = new KassenbuchMain();
                mainwindow.Width = 400;
                mainwindow.Height = 400;
                mainwindow.ShowDialog();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }


        private static void Main(string[] args)
        {
            Output.OnOutput += Console.WriteLine;
            Output.OnOutput += x => Debug.WriteLine(x);

            OpenGui();
            Cmd(args);
        }


        private static void Cmd(string[] args)
        {
            Bookings.Add(args);
            Bookings.List(2, 2009);
        }
    }

}