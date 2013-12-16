using System;

namespace MyBusiness.BookAd.Presentation.Wpf.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Returns true if the DateTime is before midday (i.e. AM)
        /// </summary>
        /// <param name="dateTime">DateTime to check</param>
        /// <returns>True if AM, False if PM</returns>
        public static bool IsBeforeMidday(this DateTime dateTime)
        {
            return dateTime.ToString("tt") == "AM";
        }
    }
}
