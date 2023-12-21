using System.Globalization;

namespace Core.Application.Extensions
{
    public static class DatetTimeExtensions
    {
        //CultureInfo türkçe karakterleri biraya getirmek için yazıldı.
        public static string ToPrettyDate(this DateTime date, CultureInfo culture)
        {
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            return date.ToString("yyyyMMdd", culture);
        }
    }
}
