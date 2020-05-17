using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FitNessCompanionApp.Helpers.Converter
{
    class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string base64Representation = value as string;

            if (base64Representation == null)
                return null;

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(System.Convert.FromBase64String(base64Representation));
            bitmap.EndInit();

            return bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
