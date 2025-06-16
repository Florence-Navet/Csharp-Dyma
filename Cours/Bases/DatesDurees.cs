using System;

namespace DatesDurees
{
    internal class DureesEtDates
    {
        public void AfficherDatesEtDurees()
        {
            Console.WriteLine("Affichage dates/heures");
            //dates/heures
            DateTime dt0 = new DateTime();
            DateTime dt1 = new DateTime(2030, 6, 21);
            DateTime dt2= new DateTime(2030, 12, 25, 22, 30, 0);
            DateTime dt3 = new DateTime(2030, 12, 25, 22, 30, 0,DateTimeKind.Utc);
            DateTime dt4 = DateTime.Today;
            DateTime dt5 = DateTime.Now;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", dt0, dt1, dt2, dt3,dt4, dt5);
            Console.WriteLine();
            Console.WriteLine("Affichage durees");
            //durees
            TimeSpan ts0 = new TimeSpan();
            TimeSpan ts1 = new TimeSpan(3, 0, 0);
            TimeSpan ts2 = new TimeSpan(4, 23, 41, 38);
            TimeSpan ts3 = new TimeSpan(4, 23, 41, 62);

            Console.WriteLine("{0}\n{1}\n{2}\n{3}", ts0, ts1, ts2, ts3);
            Console.WriteLine();

            //Dates/heures avec décalages au temps UTC
            DateTimeOffset dt09 = new DateTimeOffset(dt0, ts0);
            DateTimeOffset dt01 = new DateTimeOffset(dt1, ts1);
            DateTimeOffset dt02 = new DateTimeOffset(dt2, ts1);

            Console.WriteLine("{0}\n{1}\n{2}", dt09, dt01, dt02);
            Console.WriteLine();

            //dates seules
            DateOnly do0 = new DateOnly();
            DateOnly do1 = new DateOnly(2030, 09, 22);
            DateOnly do2 = DateOnly.FromDateTime(DateTime.Today);

            Console.WriteLine("{0}\n{1}\n{2}", do0, do1, do2);
            Console.WriteLine();

            //heures seules
            TimeOnly to0 = new TimeOnly();
            TimeOnly to1 = new TimeOnly(14, 55, 20);
            TimeOnly to2 = TimeOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("{0}\n{1}\n{2}", to0, to1, to2);
            Console.WriteLine();


            Console.WriteLine("------------------------------");


        }
    }

}
