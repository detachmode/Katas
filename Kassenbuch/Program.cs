using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassenbuch
{
    internal class Program
    {
        public static Booking ConvertArgs(string[] args)
        {
            var booking = new Booking();
            booking.Date = DateTime.ParseExact(args[0], "d.M.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            booking.Text = args[1];
            
            decimal.TryParse(args[2], out booking.Money);

            return booking;
        }


        static void Main(string[] args)
        {
            //byte[] argBytes = System.Text.Encoding.Default.GetBytes(System.String.Join(" ", System.Environment.GetCommandLineArgs()));
            //string argString = System.Text.Encoding.UTF8.GetString(argBytes);
            //string[] convertedargs = argString.Split(' ');
            //var booking = ConvertArgs(new string[] { "1.2.2009", "jlkj", "-1,5" });


            var booking = new Booking();
            try
            {
                booking = ConvertArgs(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Arguments");
            }

            Bookings.Add(booking);
        }
    }
}