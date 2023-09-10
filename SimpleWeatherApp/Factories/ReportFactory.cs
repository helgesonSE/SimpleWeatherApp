using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Factories
{
    public class ReportFactory
    {
        public static WeatherReport CreateWeatherClassFor(string location)
        {
            WebClient web = new WebClient();
            string jsonString = web.DownloadString("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Stockholm/2023-09-09/2023-09-09?unitGroup=metric&elements=datetime%2Ctemp%2Cprecip%2Cwindspeed%2Cwinddir%2Cconditions&include=current&key=FN8HKXRP359JYANWM9LPMBBH3&contentType=json");

            return JsonConvert.DeserializeObject<WeatherReport>(jsonString);
        }
    }
}
