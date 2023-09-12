using Newtonsoft.Json;
using System.Net;
using Engine.WeatherClasses;

namespace Engine.Factories
{
    public class ReportFactory
    {
        public static WeatherReport LoadWeatherDataFor(string location)
        {
            //We use the location string and trimmed parts of DateTime to build an URL. The URL is used to get weather data as a .json which can be deserialized into our weatherreport classes.
            //Data is loaded from https://www.visualcrossing.com/weather/weather-data-services#

            string date = Convert.ToString(DateTime.Now).Substring(0, 10);
            string jsonString;

            WebClient web = new WebClient();

            try
            {
                jsonString = web.DownloadString($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}/{date}/{date}?unitGroup=metric&elements=datetime%2Ctemp%2Cprecip%2Cwindspeed%2Cwinddir%2Cconditions&include=current&key=FN8HKXRP359JYANWM9LPMBBH3&contentType=json");
                return JsonConvert.DeserializeObject<WeatherReport>(jsonString);
            }
            catch (WebException)    
            {
                //If no weather data is found (for a location), return null, which in turn gets a message of this to the user. There may be several more reasons why no data
                //gets loaded, so this will need to be refined further on.
                return null;
            }
        }
    }
}
