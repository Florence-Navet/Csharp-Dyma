using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEtendues
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Renvoie une date correspond au premier jour du mois de la date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>premiere jour du mois de la date</returns>
        public static DateTime GetBeginnigOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }


        /// <summary>
        /// Renvoie une date correspondant au dernier jour du mois
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetEndOfTheMonth(this DateTime date)
        {
            var endOfTheMonth = new DateTime(date.Year, date.Month, 1)
            .AddMonths(1)
            .AddDays(-1);
       

            return endOfTheMonth;
        }

        /// <summary>
        /// renvoie le nb d'années écoulées entre date et date jour
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetAge (this DateTime date)
        {
            int ans = DateTime.Today.Year - date.Year;
            if (DateTime.Today.Month < date.Month ||
                DateTime.Today.Month == date.Month && DateTime.Today.Day < date.Day)
                ans--;

            return ans;

        }

        public static DateTime AddWorkedDays(this DateTime date, int nbDays)
        {
            int addDays = 0;
            DateTime currentDate = date;
            int direction;

            if (nbDays >= 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            while (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                currentDate = currentDate.AddDays(direction);
            }

            while (addDays < Math.Abs(nbDays))
            {
                currentDate = currentDate.AddDays(direction);

                if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    addDays++;
                }
            }
            return currentDate;
        }

    }
}
