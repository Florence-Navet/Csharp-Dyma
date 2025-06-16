using System;

namespace DatesDurees
{
    internal class DureesEtDates
    {
        public void AfficherDatesEtDurees()
        {
            //dates/heures
            DateTime dt0 = new DateTime();
            DateTime dt1 = new DateTime(2030, 6, 21);
            DateTime dt2= new DateTime(2030, 12, 25, 22, 30, 0);
            DateTime dt3 = new DateTime(2030, 12, 25, 22, 30, 0,DateTimeKind.Utc);
            DateTime dt4 = DateTime.Today;
            DateTime dt5 = DateTime.Now;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", dt0, dt1, dt2, dt3,dt4, dt5);
        }
    }

}
