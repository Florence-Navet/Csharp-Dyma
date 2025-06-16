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
            Console.WriteLine("######################################");


            DateTimeOffset dt03 = new DateTimeOffset(2030, 1, 31, 22, 45, 58, new TimeSpan(0, 0, 0));
            Console.WriteLine($"DateTimeOffset: {dt03}");

            Console.WriteLine("\nRécupération des différentes parties :");

            Console.WriteLine($"Date : {dt03.Date}");
            Console.WriteLine($"TimeOfDay : {dt03.TimeOfDay}");
            Console.WriteLine($"Offset : {dt03.Offset}");
            

            Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}:{6}", 
                dt03.Year, dt03.Month, dt03.Day, dt03.Hour, dt03.Minute, dt03.Second, dt03.Millisecond);

            Console.WriteLine("\nRécupération de la partie date/ Heure dans differents systems de temps :");


            Console.WriteLine($"DateTime : {dt01.DateTime}");
            Console.WriteLine($"LocalDateTime : {dt01.LocalDateTime}");
            Console.WriteLine($"UtcDatetime : {dt01.UtcDateTime}");
            
            //recupération du jour dans la semaine ou l'année
            Console.WriteLine(dt03.DayOfWeek);  // Thursday
            Console.WriteLine(dt03.DayOfYear);   // 31


            //DateTimeOffset.MinValue
            //DateTimeOffset.MaxValue

            //Methode

            DateTimeOffset dto1 = new DateTimeOffset(2030, 1, 31, 22, 45, 58, new TimeSpan());
            Console.WriteLine(dto1);   // 31/01/2030 22:45:58 +00:00

            DateTimeOffset dto2 = dto1.AddYears(-1).AddMonths(-1).AddHours(-1);
            Console.WriteLine(dto2);   // 31/12/28 21:45:58 +00:00


            //exemple d'ajout de temps
            TimeSpan ts9 = new TimeSpan(1, 1, 1, 1); // 1j, 1h, 1min, 1s
            Console.WriteLine(dto1 + ts9);   // 01/02/30 23:46:59 +00:00
            Console.WriteLine(dto1 - ts9);   // 30/01/30 21:44:57 +00:00

            Console.WriteLine("\nComparaisons:");
            TimeSpan tsDecalage = new TimeSpan(3, 0, 0);
            DateTimeOffset dto3 = new DateTimeOffset(dto1.DateTime, tsDecalage);
            Console.WriteLine(dto3 < dto1);  // True

            Console.WriteLine("\nConversion dans un systeme de temps différents");
            DateTimeOffset dto11 = new DateTimeOffset(2030, 1, 31, 22, 45, 58, new TimeSpan());
            Console.WriteLine(dto11);                     // 31/01/30 22:45:58 +00:00
            Console.WriteLine(dto11.ToLocalTime());       // 31/01/30 23:45:58 +01:00
            Console.WriteLine(dto11.ToUniversalTime());   // 31/01/30 22:45:58 +00:00

            Console.WriteLine(dto11.DateTime);            // 31/01/30 22:45:58
            Console.WriteLine(dto11.LocalDateTime);       // 31/01/30 23:45:58
            Console.WriteLine(dto11.UtcDateTime);         // 31/01/30 22:45:58

            //------------------------------------
            Console.WriteLine("\ncas particulier du passage à l'heure d'été");
            // Date/heure correspondant au passage à l'heure d'été en Fance
            DateTime dt = new DateTime(2030, 3, 31, 2, 0, 0); // 31/03/2030 à 2:00
            TimeSpan ts = new TimeSpan(1, 0, 0); // décalage de 1h par rapport au temps UTC
            DateTimeOffset dtoHeureEté = new DateTimeOffset(dt, ts);

            Console.WriteLine(dtoHeureEté.ToLocalTime());      // 31/03/30 03:00:00 +02:00
            Console.WriteLine(dtoHeureEté.ToUniversalTime());  // 31/03/30 01:00:00 +00:00









            Console.WriteLine("######################################");







        }
    }

}
