using System;
using System.Globalization;
using System.Windows;
using static Kassenbuch.Output;

namespace Kassenbuch
{

    /// <summary>
    ///     Interaction logic for KassenbuchMain.xaml
    /// </summary>
    public partial class KassenbuchMain
    {
        public KassenbuchMain()
        {
            InitializeComponent();
        }


        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var input = new[] {DatePicker.SelectedDate?.Date.ToShortDateString(), zweck.Text, betrag.Text};
            Interactions.Add(input);
        }


        private void ButtonList_OnClick(object sender, RoutedEventArgs e)
        {
            Parse(onParsed: Interactions.List, errorOutput: OutputError);
        }


        private void Parse(Action<int, int> onParsed, Action<string> errorOutput)
        {
            string errormsg = "";
            int month;
            var parsesuccess = int.TryParse(monthTextbox.Text, out month);
            if (!parsesuccess)
                errormsg += "Could not parse month\n";

            int year;
            parsesuccess = int.TryParse(yearTextbox.Text, out year);
            if (!parsesuccess)
                errormsg += "Could not parse year\n";

            if (string.IsNullOrEmpty(errormsg))
            {
                onParsed(month, year);
            }
            else
            {
                errorOutput(errormsg);
            }
        }
    }

}