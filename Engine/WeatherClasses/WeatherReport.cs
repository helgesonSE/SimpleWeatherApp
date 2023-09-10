using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.WeatherClasses
{
    public class CurrentConditions : BaseNotificationClass
    {
        private string _datetime;
        private double _temp;
        private double _precip;
        private double _windspeed;
        private double _winddir;
        private string _conditions;
        public string datetime
        {
            get { return _datetime; }
            set
            {
                _datetime = value;
                OnPropertyChanged("datetime");
            }
        }
        public double temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged("temp");
            }
        }
        public double precip
        {
            get { return _precip; }
            set
            {
                _precip = value;
                OnPropertyChanged("precip");
            }
        }
        public double windspeed
        {
            get { return _windspeed; }
            set
            {
                _windspeed = value;
                OnPropertyChanged("windspeed");
            }
        }
        public double winddir
        {
            get { return _winddir; }
            set
            {
                _winddir = value - 90;
                OnPropertyChanged("windir");
            }
        }
        public string conditions
        {
            get { return _conditions; }
            set
            {
                _conditions = value;
                OnPropertyChanged("conditions");
            }
        }

    }

    public class WeatherReport : BaseNotificationClass
    {
        private string _address;
        private CurrentConditions _currentConditions;
        public string address
        {
            get { return _address; }
            set
            {
                _address = value;
                //OnPropertyChanged("address");
            }
        }
        public CurrentConditions currentConditions
        {
            get { return _currentConditions; }
            set
            {
                _currentConditions = value;
                //OnPropertyChanged("currentConditions");
            }
        }

        public WeatherReport()
        {
            currentConditions = new CurrentConditions();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
