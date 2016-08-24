using System;
using System.Globalization;

//todo: get uncode from cmd args
//byte[] argBytes = System.Text.Encoding.Default.GetBytes(System.String.Join(" ", System.Environment.GetCommandLineArgs()));
//string argString = System.Text.Encoding.UTF8.GetString(argBytes);
//string[] convertedargs = argString.Split(' ');
//var booking = ConvertArgs(new string[] { "1.2.2009", "jlkj", "-1,5" });

namespace Kassenbuch
{

    public static class CmdPortal
    {
        public static Booking ConvertArgs(string[] args)
        {
            var booking = new Booking();
            booking.Date = DateTime.ParseExact(args[0], "d.M.yyyy", CultureInfo.InvariantCulture);
            booking.Text = args[1];

            decimal.TryParse(args[2], out booking.Money);

            return booking;
        }
    }

}