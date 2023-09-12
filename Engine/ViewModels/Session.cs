using Engine.Factories;
using Engine.WeatherClasses;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public class Session : BaseNotificationClass
    {
        //This class keeps the WeatherReport instance which we show to the user (currentWeatherReport). The word "current" is used by variables in WeatherReports.cs,
        //so I will consider a different naming for this. currentWeatherReport communicates to the bindings in the xaml via OnPropertyChanged.
        private WeatherReport _currentWeatherReport;
        public WeatherReport currentWeatherReport
        {
            get { return _currentWeatherReport; }
            set 
            { 
                _currentWeatherReport = value;
                OnPropertyChanged("currentWeatherReport");
            }
        }
        public ObservableCollection<WeatherReport> PreviousSearches { get; set; }   //This list is used by the combobox to display results.
        public bool hasPreviousSearch { get; set; }    //For now. Helps determine what message should be shown to the user in GenerateWeather_Click of the Mainwindow.xaml.cs.

        public Session()
        {
            currentWeatherReport = new WeatherReport();
            PreviousSearches = new ObservableCollection<WeatherReport>();
            
        }
        public void CreateReportFor(string location)
        {
            //Gets weather data for out instance of WeatherReport via the factory. We then check if the readings for that location are different from the ones we have. We cannot
            //know beforehand if the report we get back will have fresher data that the previous one until we actually fetch it.
            currentWeatherReport = ReportFactory.LoadWeatherDataFor(location);
            hasPreviousSearch = (PreviousSearches.Any(WeatherReport => WeatherReport.address == location) &&    //Checks for matching search addresses and times.
                                      PreviousSearches.Any(WeatherReport => WeatherReport.currentConditions.datetime ==
                                                                        currentWeatherReport.currentConditions.datetime));
            if (currentWeatherReport != null && hasPreviousSearch == false) 
            {
                //If there is new weather data for a location, or if it hasnt been searched for, we also create a string to use as a display value in our combobox.
                //The resulting WeatherCLass isntance is added to the list of previous searches.
                _currentWeatherReport.ComboBoxDisplay = $"{_currentWeatherReport.address} - {_currentWeatherReport.currentConditions.datetime}";
                PreviousSearches.Add(currentWeatherReport);
            }
        }
    }
}
