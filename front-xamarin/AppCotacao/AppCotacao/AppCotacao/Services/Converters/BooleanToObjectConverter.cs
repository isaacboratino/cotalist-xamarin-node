using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppCotacao.Services.Converters
{
    public class BooleanToObjectConverter<T> : IValueConverter
    {
        public T NullObject { set; get; }
        public T FalseObject { set; get; }
        public T TrueObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return this.NullObject;
            else
                return (bool)value ? this.TrueObject : this.FalseObject;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return this.NullObject;
            else
                return ((T)value).Equals(this.TrueObject);
        }
    }
}
