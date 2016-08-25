using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Kassenbuch
{

    public class Booking
    {
        public DateTime Date;
        public decimal Money;
        public string Text;
    }


    public static class Bookings
    {
        private const string Csvfilename = @"./booking.csv";
        public static event Action<string> OnPrint;


        public static void Add(Booking booking)
        {
            var bookingstring = CreateBookingString(booking);
            InsertBooking(bookingstring);
        }


        public static void List(int month, int year)
        {
            var bookings = GetBookingsFromCSV();
            var filteredBookings = FilterBookings(bookings, month, year);
            var formattedLines = FormatSplittedLine(filteredBookings);
            PrintLine(formattedLines);
        }


        private static IEnumerable<Booking> FilterBookings(IEnumerable<Booking> bookings, int month, int year)
        {
            return bookings.Where(booking => booking.Date.Month == month && booking.Date.Year == year);
        }


        private static IEnumerable<Booking> GetBookingsFromCSV()
        {
            var lines = GetLineFromCSV();

            IEnumerable<string[]> splittedLine = lines.Select(x => x.Split(';')).ToList();

            //todo: wie kann ich das geyieldede weiter yielden ohne for each?
            var bookings = ConvertToBooking(splittedLine);
            foreach (var booking in bookings)
            {
                yield return booking;
            }
        }


        private static IEnumerable<Booking> ConvertToBooking(IEnumerable<string[]> splittedLine)
        {
            foreach (var strings in splittedLine)
            {
                var booking = new Booking();
                booking.Date = DateTime.ParseExact(strings[0], "d.M.yyyy", CultureInfo.InvariantCulture);
                booking.Text = strings[1];
                decimal.TryParse(strings[2], out booking.Money);
                yield return booking;
            }
        }


        private static IEnumerable<string> FormatSplittedLine(IEnumerable<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                var str = "";
                str += booking.Date.ToShortDateString();
                str += "\t";
                str += booking.Text;
                str += "\t";
                str += booking.Money;
                yield return str;
            }
        }


        private static void PrintLine(IEnumerable<string> formattedLines)
        {
            foreach (var s in formattedLines)
            {
                OnPrint?.Invoke(s);
            }
        }


        private static IEnumerable<string> GetLineFromCSV()
        {
            using (var reader = File.OpenText(Csvfilename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
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