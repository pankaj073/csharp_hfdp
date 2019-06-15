using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.Observer
{
    #region interfaces
    public interface IDisplayElement
    {
        void Display();
    }
    #endregion


    #region classes
    public class WeatherStats
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
    }

    public class WeatherData : IObservable<WeatherStats>
    {
        List<IObserver<WeatherStats>> observers;
        WeatherStats weatherStats;

        public WeatherData()
        {
            weatherStats = new WeatherStats();
            observers = new List<IObserver<WeatherStats>>();
        }
        public void NotifyObservers()
        {
            foreach(var observer in observers)
            {
                observer.OnNext(weatherStats);
            }
        }
       
        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            weatherStats.Temperature = temperature;
            weatherStats.Humidity = humidity;
            weatherStats.Pressure = pressure;
            MeasurementsChanged();
        }

        public IDisposable Subscribe(IObserver<WeatherStats> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherStats>> _observers;
            private IObserver<WeatherStats> _observer;

            public Unsubscriber(
                List<IObserver<WeatherStats>> observers, 
                IObserver<WeatherStats> observer
                )
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observers != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public float GetTemperature()
        {
            return weatherStats.Temperature;
        }
        public float GetHumidity()
        {
            return weatherStats.Humidity;
        }
        public float GetPressure()
        {
            return weatherStats.Pressure;
        }
    }

    public class CurrentConditionsDisplay : IObserver<WeatherStats>, IDisplayElement
    {
        float temperature;
        float humidity;

        IObservable<WeatherStats> weatherData;

        public CurrentConditionsDisplay(IObservable<WeatherStats> weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Subscribe(this);
        }
        public void Display()
        {
            Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(WeatherStats value)
        {
            temperature = value.Temperature;
            humidity = value.Humidity;
            Display();
        }
    }
    #endregion
}
