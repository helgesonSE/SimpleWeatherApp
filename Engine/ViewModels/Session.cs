using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.WeatherClasses;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public class Session : BaseNotificationClass
    {
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
        public ObservableCollection<WeatherReport> PreviousSearches { get; set; }
        public bool hasPreviousSearch { get; set; }

        public Session()
        {
            currentWeatherReport = new WeatherReport();
            PreviousSearches = new ObservableCollection<WeatherReport>();
            
        }
        public void CreateReportFor(string location)
        {
            currentWeatherReport = ReportFactory.GetWeatherDataFor(location);
            hasPreviousSearch = (PreviousSearches.Any(WeatherReport => WeatherReport.address == location) &&
                                      PreviousSearches.Any(WeatherReport => WeatherReport.currentConditions.datetime ==
                                                                        currentWeatherReport.currentConditions.datetime));
            if (currentWeatherReport != null && hasPreviousSearch == false)                
                PreviousSearches.Add(currentWeatherReport);
        }
    }
}
