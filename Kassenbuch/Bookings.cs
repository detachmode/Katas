using System;
using System.Globalization;
using System.IO;

namespace Kassenbuch
{
    public class Booking
    {
        public DateTime Date;
        public decimal Money;
        public string Text;
    }


    public class Bookings
    {
        private const string Csvfilename = @"./booking.csv";


        public static void Add(Booking booking)
        {
            var bookingstring = CreateBookingString(booking);
            InsertBooking(bookingstring);
        }


        private static string CreateBookingString(Booking booking)
        {
            var str = "";
            str += booking.Date.Date.ToShortDateString();
            str += ";" + booking.Text;
            str += ";" + booking.Money.ToString("0.00", CultureInfo.InvariantCulture);
            return str;
        }


        private static void InsertBooking(string bookingstring)
        {
            using (var writer = File.AppendText(Csvfilename))
            {
                writer.WriteLine(bookingstring);
            }
        }
    }
}