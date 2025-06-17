using System;

namespace Span
{
    internal class ProprietesSpan
    {
        public void AfficherSpan()
        {
            TimeSpan ts1 = new TimeSpan(2, 23, 45, 50);
            Console.WriteLine(ts1);

            Console.WriteLine("Propriétés Days, Hours, Minutes, ...");
            Console.WriteLine($"{ts1.Days}:{ts1.Hours}:{ts1.Minutes}:{ts1.Seconds}");
            //---------------------------------------------------------------------------
            Console.WriteLine($"TotalDays : {ts1.TotalDays}");
            Console.WriteLine($"TotalHours : {ts1.TotalHours}");
            Console.WriteLine($"TotalMinutes : {ts1.TotalMinutes}");

            //-------------------valeurs constantes-------------------------
            Console.WriteLine(TimeSpan.Zero);
            Console.WriteLine(TimeSpan.MinValue);
            Console.WriteLine(TimeSpan.MaxValue);
            Console.WriteLine(TimeSpan.TicksPerDay);

            Console.WriteLine("Methodes FromDays, FromHours, FromMinutes");
            Console.WriteLine(TimeSpan.FromDays(2.990255));    // 2.23:45:58.032
            Console.WriteLine(TimeSpan.FromHours(71.7661111)); // 2.23:45:57.999
            Console.WriteLine(TimeSpan.FromMinutes(4305.9667)); // 2.23:45:58.002

            //-------------------------------------------------------------
            Console.WriteLine("\nAjoute ou retire un autre un interval de temps");
            TimeSpan ts22 = new TimeSpan(1, 9, 10, 20);
            TimeSpan ts23 = new TimeSpan(1, 1, 1, 1); // 1.01:01:01
            Console.WriteLine(ts22.Add(ts23));       // 2.10:11:21
            Console.WriteLine(ts22.Subtract(ts23));  // 08:09:19
            Console.WriteLine(ts22 + ts23);   // 2.10:11:21
            Console.WriteLine(ts22 - ts23);   // 08:09:19

            //-----------------------------------------------------------
            Console.WriteLine("\nMethodes negate, duration, mulliply ou divide");
            TimeSpan ts24 = new TimeSpan(1, 9, 10, 20);
            Console.WriteLine(ts1.Negate());    // -1.9:10:20
            Console.WriteLine(ts1.Duration());  // 1.9:10:20
            Console.WriteLine(ts1.Multiply(2)); // 2.18:20:40
            Console.WriteLine(ts1.Divide(2));   // 16:35:10

            //--------------------------------------------------------
            TimeSpan ts31 = new TimeSpan(1, 9, 10, 20);
            Console.WriteLine(ts31.Negate());    // -1.9:10:20
            Console.WriteLine(ts31.Duration());  // 1.9:10:20
            Console.WriteLine(ts31.Multiply(2)); // 2.18:20:40
            Console.WriteLine(ts31.Divide(2));   // 16:35:10


        }
    }
}
