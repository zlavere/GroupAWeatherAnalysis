﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class DatePickerConverter:IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            var dateTime = (DateTime) value;
            return new DateTimeOffset(dateTime);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dateTimeOffset = (DateTimeOffset) value;
            return dateTimeOffset.DateTime;
        }
    }
}
