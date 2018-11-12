﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class LowTempConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var conversion = $"The lowest temperature of {(int) value} occurred on:";
            return conversion;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
