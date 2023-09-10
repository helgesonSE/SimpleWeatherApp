using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class CurrentConditions : WeatherReport
{
    public double _winddir;
    public string datetime { get; set; }
    public double temp { get; set; }
    public double precip { get; set; }
    public double windspeed { get; set; }
    public double winddir
    {
        get { return _winddir; }
        set
        {
            _winddir = value - 90;
            OnPropertyChanged("windir");
        }
    }   
public string conditions { get; set; }
}

public class Day : WeatherReport
{
    public double tempmax { get; set; }
    public double tempmin { get; set; }
}

public class WeatherReport : INotifyPropertyChanged
{
    public string address { get; set; }
    public List<Day> days { get; set; }
    public CurrentConditions currentConditions { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}




