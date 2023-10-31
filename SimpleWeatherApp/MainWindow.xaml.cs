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
            _session.CreateReportFor(LocationSearchBox.Text);
            LocationSearchBox.Text = "";
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            //A previous search adress should always get results, so we do not check for null results here for now. Will proof further on. Aside from that,
            //this command performs the same actions as GenerateWeather_Click.
            _session.CreateReportFor(_session.LiveWeatherReport.address);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LocationSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
