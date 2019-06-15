using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.Observer
{
    #region interfaces
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface IDisplayElement
    {
        void Display();
    }
    #endregion

    #region classes
    public class WeatherData : ISubject
    {
        List<IObserver> observers;
        float temperature;
        float humidity;
        float pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }
        public void NotifyObservers()
        {
            foreach(var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            observers.RemoveAt(i);
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        float temperature;
        float humidity;

        ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void Display()
        {
            Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }
    }
    #endregion
}
