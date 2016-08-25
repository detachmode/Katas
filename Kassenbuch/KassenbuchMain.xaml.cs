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
            Bookings.Add(input);
        }


        private void ButtonList_OnClick(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate != null)
                Bookings.List(DatePicker.SelectedDate.Value.Month, DatePicker.SelectedDate.Value.Year);
            else
                OutputLine("Please select date");
        }
    }

}