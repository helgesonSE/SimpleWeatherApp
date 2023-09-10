using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.WeatherClasses;
using Engine.ViewModels;
using Engine.Factories;

namespace SimpleWeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Session _session;
        public MainWindow()
        {
            InitializeComponent();
            _session = new Session();
            DataContext = _session;
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GenerateWeather_Click(object sender, RoutedEventArgs e)
        {
            _session.CreateReportFor(LocationSearchBox.Text);
            //_session.currentWeatherReport = ReportFactory.CreateWeatherClassFor(LocationSearchBox.Text);
            if (_session.currentWeatherReport == null)
                SearchMessageLabel.Content = "Location could not be found";
            else if (_session.hasPreviousSearch == true)
                SearchMessageLabel.Content = "No new weather data\nfor that location";
            else
                SearchMessageLabel.Content = "";
            LocationSearchBox.Text = "";
        }

        private void LocationSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
