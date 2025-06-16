using System;
using System.Dynamic;
using System.Globalization;
using System.Net.WebSockets;

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

            const string erreur = "impossible d'interprêter la chaine en date";
            bool res;

            string sdt10 = "25/12/2030 22:30:45"; //format par defaut de la culture courante(fr-FR)
            res = DateTime.TryParse(sdt10, out DateTime dt10);
            Console.WriteLine(res ? dt10 : erreur);

            string sdt11 = "25 12 2030 22:30:45"; //autre separateur
            res = DateTime.TryParse(sdt11, out DateTime dt11);
            Console.WriteLine(res ? dt11 : erreur);

            string std12 = "12/25/2030 10:30:45 PM";
            res = DateTime.TryParse(std12, CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out DateTime dt12);
            Console.WriteLine(res ? dt12 : erreur);

            string std13 = "2030-12-25 22:30:45";
            res = DateTime.TryParse(std13,CultureInfo.InvariantCulture, out DateTime dt13);
            Console.WriteLine(res ? dt13 : erreur);


            string std14 = "12-25-2030 22:30:45";
            res = DateTime.TryParse(std14, CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out DateTime dt14);
            Console.WriteLine(res ? dt14 : erreur);

            string sdtp = "Mercredi 25 déc. 2030 22:30";
            string format = "dddd dd MMM yyyy HH:mm";
            res = DateTime.TryParseExact(sdtp, format, CultureInfo.GetCultureInfo("fr-FR"),
                DateTimeStyles.AllowInnerWhite, out DateTime dtp);
            Console.WriteLine(res ? dtp : erreur);

            string std0 = "2030-12-25 22:30:45 +04:30";
            res = DateTimeOffset.TryParse(std0, CultureInfo.InvariantCulture, out DateTimeOffset dto);
            Console.WriteLine(res ? dto : erreur);

            string sdo = "2030-12-25";
            res = DateOnly.TryParse(sdo, CultureInfo.InvariantCulture, out DateOnly don);
            Console.WriteLine(res ? don : erreur);

            string sto = "22:30:45";
            res = TimeOnly.TryParse(sto, CultureInfo.InvariantCulture, out TimeOnly stu);
            Console.WriteLine(res ? stu : erreur);




            Console.WriteLine();


            Console.WriteLine("------------------------------");


        }
    }

}
