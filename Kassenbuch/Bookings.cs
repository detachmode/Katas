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


        public static void Add(Booking booking)
        {
            var bookingstring = CreateBookingString(booking);
            InsertBooking(bookingstring);
            Output.OutputLine("Saved: " + string.Join(" ", booking.Date, booking.Text, booking.Money));
        }


        public static void List(int month, int year)
        {
            Output.OutputLine("\n--- List ---\n");
            var bookings = GetBookingsFromCSV();
            var filteredBookings = FilterBookings(bookings, month, year);
            var formattedLines = FormatSplittedLine(filteredBookings);
            PrintLine(formattedLines);
        }


        public static Booking Convert(string[] args)
        {
            var booking = new Booking();
            booking.Date = DateTime.ParseExact(args[0], "d.M.yyyy", CultureInfo.InvariantCulture);
            booking.Text = args[1];
            booking.Money = decimal.Parse(args[2]);

            return booking;
        }


        internal static void Add(string[] args)
        {
            try
            {
                var booking = Convert(args);
                Add(booking);
            }
            catch (Exception)
            {
                Output.OutputLine("Invalid Arguments");
            }
        }


        private static IEnumerable<Booking> FilterBookings(IEnumerable<Booking> bookings, int month, int year)
        {
            return bookings.Where(booking => booking.Date.Month == month && booking.Date.Year == year);
        }


        private static IEnumerable<Booking> GetBookingsFromCSV()
        {
            var lines = GetLinesFromCSV();

            var splittedLine = lines.Select(x => x.Split(';'));

            return splittedLine.Select(Convert);

            //    //todo: wie kann ich das geyieldede weiter yielden ohne for each?
            //    return ConvertToBooking(splittedLine);
        }


        private static IEnumerable<Booking> ConvertToBooking(IEnumerable<string[]> splittedLine)
        {
            foreach (var strings in splittedLine)
            {
                var booking = new Booking();
                booking.Date = DateTime.ParseExact(strings[0], "d.M.yyyy", CultureInfo.InvariantCulture);
                booking.Text = strings[1];
                booking.Money = decimal.Parse(strings[2], CultureInfo.InvariantCulture.NumberFormat);

                yield return booking;
            }
        }


        private static IEnumerable<string> FormatSplittedLine(IEnumerable<Booking> bookings)
        {
            return bookings.Select(booking => string.Join("\t",
                booking.Date.ToShortDateString(),
                booking.Text,
                booking.Money
                ));
        }


        private static void PrintLine(IEnumerable<string> formattedLines)
        {
            formattedLines.ToList().ForEach(Output.OutputLine);
        }


        private static IEnumerable<string> GetLinesFromCSV()
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