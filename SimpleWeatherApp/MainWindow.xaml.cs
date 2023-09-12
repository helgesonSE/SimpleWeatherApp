using System.Windows;
using System.Windows.Controls;
using Engine.ViewModels;

namespace SimpleWeatherApp
{
    //This file contains the interaction logic for the app UI.
    public partial class MainWindow : Window
    {
        private Session _session;
        public MainWindow()
        {
            InitializeComponent();
            _session = new Session();   //We create our instance of the session class. For now it only contains the one weatherclass type and their data.
            DataContext = _session;     //Assigns the xaml datacontext.
        }

        private void GenerateWeather_Click(object sender, RoutedEventArgs e)
        {
            //Sends the user input to our intermediary in the session class. Currently we also check for faulty searches here in order to update elements
            //of the UI, which is hardly a neat solution. It will be moved out of this .cs further on.
            _session.CreateReportFor(LocationSearchBox.Text);

            if (_session.currentWeatherReport == null)
                SearchMessageLabel.Content = "Location could not be found";
            else if (_session.hasPreviousSearch == true)
                SearchMessageLabel.Content = "No new weather data\nfor that location";
            else
                SearchMessageLabel.Content = "";
            LocationSearchBox.Text = "";
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            //A previous search addres should always get results, so we do not check for null results here for now. Will proof further on. Aside from that,
            //this command performs the same actions as GenerateWeather_Click.
            _session.CreateReportFor(_session.currentWeatherReport.address);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LocationSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
