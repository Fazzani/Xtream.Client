using System;

namespace Xtream.Client
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Unix TimeStamp to DateTime
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(this string text)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (string.IsNullOrEmpty(text))
                return dtDateTime;
            return dtDateTime.AddSeconds(Convert.ToInt32(text));
        }
    }
}
