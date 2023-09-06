using System.Collections.Generic;

public class CurrentConditions
{
    public string datetime { get; set; }
    public double temp { get; set; }
    public double precip { get; set; }
    public string conditions { get; set; }
}


public class WeatherReport
{
    public string address { get; set; }
    public CurrentConditions currentConditions { get; set; }

}

