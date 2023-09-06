using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Policy;
using System.Net;
using Newtonsoft.Json;

namespace SimpleWeatherApp.View
{
    public class Session
    {

        public WeatherReport currentWeatherReport; 

        public Session()
        {
            currentWeatherReport = new WeatherReport();
        }
        public void CreateWeatherClass()
        {
            WebClient web = new WebClient();
            string jsonString = web.DownloadString("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Stockholm/2023-09-06/2023-09-06?unitGroup=metric&elements=datetime%2Ctemp%2Cprecip%2Cconditions%2Cicon&include=current&key=FN8HKXRP359JYANWM9LPMBBH3&contentType=json");

            //Det här är metoden som fungerar
            WeatherReport myDeserializedClass = JsonConvert.DeserializeObject<WeatherReport>(jsonString);
            Console.WriteLine(myDeserializedClass.address);
            Console.WriteLine(myDeserializedClass.currentConditions.conditions);

            dynamic weatherMiddleMan = JsonConvert.DeserializeObject<dynamic>(jsonString);
            Console.WriteLine(weatherMiddleMan.currentConditions.conditions);
        }
    }
}
