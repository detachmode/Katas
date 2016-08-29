using System;
using System.Threading;
using System.Windows;

namespace Kassenbuch
{

    internal class GUI
    {
        [STAThread]
        public static void Open()
        {
            Output.OnOutput += Console.WriteLine;
            Output.OnError += x => MessageBox.Show(x);
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
    }

}