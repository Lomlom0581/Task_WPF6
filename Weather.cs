using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Task_WPF6
{
    public class WeatherControl: DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register(
                nameof(WeatherControl.Temperature), //Имя свойства
                typeof(int), //Тип свойства
                typeof(WeatherControl), //Владелец свойства
                new FrameworkPropertyMetadata(
                    15, //Значение по умолчанию 15 град
                    0, //Опции
                    new PropertyChangedCallback(OnChangeTemperatureProperty),
                    new CoerceValueCallback(CoerceTemperature),
                    true,
                    UpdateSourceTrigger.LostFocus)
                );

        public int Temperature
        {
            get { return (int)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        public int WindDirection = 0;
        public enum Precipitation
        {
            sun,
            cloud,
            rain,
            snow
        }

        public Precipitation precipation = Precipitation.sun;

        public override string ToString()
        {
            return "Temperature=" + Temperature.ToString() + " Wind direction=" + WindDirection + " " + precipation.ToString();
        }

        //Ограничмвает температуру
        private static object CoerceTemperature(DependencyObject o, object BaseValue)
        {
            int v = (int)BaseValue;
            if (v < -50)
                return -50;
            if (v > 50)
                return 50;
            return v;
        }

        // Реакция на изменение температуры
        private static void OnChangeTemperatureProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public static WeatherControl weatherControl = new WeatherControl();
    }

}
