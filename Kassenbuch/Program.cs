using System;
using System.Diagnostics;

namespace Kassenbuch
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var booking = new Booking();
            try
            {
                booking = CmdPortal.ConvertArgs(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Arguments");
            }

            Bookings.Add(booking);

            Bookings.OnPrint += x => Debug.WriteLine(x);
            Bookings.OnPrint += Console.WriteLine;
            Bookings.List(2, 2009);
        }
    }

}