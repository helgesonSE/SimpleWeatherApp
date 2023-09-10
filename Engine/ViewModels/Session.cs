using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.WeatherClasses;

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
        public Session()
        {
            currentWeatherReport = new WeatherReport();
            //currentWeatherReport = ReportFactory.CreateWeatherClassFor("Stockholm");
            //currentWeatherReport = CreateWeatherClassFor();
        }
        //public WeatherReport CreateWeatherClassFor()
        //{
        //    WebClient web = new WebClient();
        //    string jsonString = web.DownloadString("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Stockholm/2023-09-08/2023-09-08?unitGroup=metric&elements=datetime%2Ctemp%2Cprecip%2Cconditions&include=current&key=FN8HKXRP359JYANWM9LPMBBH3&options=nonulls&contentType=json");

        //    return JsonConvert.DeserializeObject<WeatherReport>(jsonString);
        //}
    }
}
