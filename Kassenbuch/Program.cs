using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
            catch (Exception e)
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