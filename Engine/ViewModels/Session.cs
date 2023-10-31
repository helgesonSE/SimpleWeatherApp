using Engine.Factories;
using Engine.WeatherClasses;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public class Session : BaseNotificationClass
    {
        //This class keeps the WeatherReport instance which we show to the user (LiveWeatherReport). LiveWeatherReport communicates to the bindings in the xaml via OnPropertyChanged.
        private WeatherReport _liveWeatherReport;
        private string _searchMessageText;

        public WeatherReport LiveWeatherReport
        {
            get { return _liveWeatherReport; }
            set 
            { 
                _liveWeatherReport = value;
                OnPropertyChanged("liveWeatherReport");
            }
        }
        public string SearchMessageText
        {
            get { return _searchMessageText; }
            set
            {
                _searchMessageText = value;
                OnPropertyChanged("searchMessageText");
            }
        }
        public ObservableCollection<WeatherReport> PreviousSearches { get; set; }   //This list is used by the combobox to display results.
        public Session()
        {
            LiveWeatherReport = new WeatherReport();
            PreviousSearches = new ObservableCollection<WeatherReport>();
            
        }
        public void CreateReportFor(string location)
        {
            //Gets weather data for out instance of WeatherReport via the factory. We then check if the readings for that location are different from the ones we have. We cannot
            //know beforehand if the report we get back will have fresher data that the previous one until we actually fetch it.
            LiveWeatherReport = ReportFactory.LoadWeatherDataFor(location);
            bool HasPreviousSearch = (PreviousSearches.Any(WeatherReport => WeatherReport.address == location) &&    //Checks for matching search addresses and times.
                                      PreviousSearches.Any(WeatherReport => WeatherReport.currentConditions.datetime ==
                                                                        LiveWeatherReport.currentConditions.datetime));
            if (LiveWeatherReport != null && HasPreviousSearch == false)
            {
                //If there is new weather data for a location, or if it hasnt been searched for, we also create a string to use as a display value in our combobox.
                //The resulting WeatherClass instance is added to the list of previous searches. We then check for faulty searches here in order to update elements
                //of the UI. If the WeatherReport was null, we reset the value to an empty WeatherReport.
                _liveWeatherReport.ComboBoxDisplay = $"{_liveWeatherReport.address} - {_liveWeatherReport.currentConditions.datetime}";
                PreviousSearches.Add(LiveWeatherReport);
                SearchMessageText = "";
            }
            else if (LiveWeatherReport == null)
            {
                SearchMessageText = "Location could not be found";
                LiveWeatherReport = new WeatherReport();
            }
            else if (HasPreviousSearch == true)
            {
                SearchMessageText = "No new weather data\nfor that location";
            }
        }
    }
}
