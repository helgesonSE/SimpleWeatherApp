using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Engine.WeatherClasses;

namespace Engine.Factories
{
    public class ReportFactory
    {
        public static WeatherReport CreateWeatherClassFor(string location)
        {
            string date = Convert.ToString(DateTime.Now).Substring(0, 10);
            WebClient web = new WebClient();
            string jsonString;

            try
            {
                jsonString = web.DownloadString($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}/{date}/{date}?unitGroup=metric&elements=datetime%2Ctemp%2Cprecip%2Cwindspeed%2Cwinddir%2Cconditions&include=current&key=FN8HKXRP359JYANWM9LPMBBH3&contentType=json");
                return JsonConvert.DeserializeObject<WeatherReport>(jsonString);

            }
            catch (WebException)
            {
                return null;
            }

        }
    }
}
