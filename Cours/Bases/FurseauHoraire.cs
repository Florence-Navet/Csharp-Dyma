using System;
using System.Collections.Generic;
using System.Linq;

namespace FuseauHoraire
{
    internal class DifferentsFuseauxHoraires
    {
        public void AfficherFuseaux()
        {
            Console.WriteLine("Id" + new string(' ', 29) + " | E | Nom standard" + new string(' ', 19) + "| Décalage");
            Console.WriteLine(new string('-', 85)); // Correction : parenthèse fermante manquante

            List<TimeZoneInfo> tzis = TimeZoneInfo.GetSystemTimeZones().ToList();

            foreach (TimeZoneInfo tzi in tzis)
            {
                string desc = $"{tzi.Id,-31} | {(tzi.SupportsDaylightSavingTime ? 'O' : 'N')} | {tzi.StandardName,-31} | {tzi.BaseUtcOffset}";
                Console.WriteLine(desc);
            }

            Console.WriteLine();

            int avecHeureEte = tzis.Count(t => t.SupportsDaylightSavingTime);
            int sansHeureEte = tzis.Count - avecHeureEte;

            Console.WriteLine("{0} fuseau(x) avec heure d'été et {1} sans", avecHeureEte, sansHeureEte);

            /// <summary>
            /// Convertit des dates/heures vers un autre fuseau horaire
            /// </summary>
            /// 

            Console.WriteLine();
            Console.WriteLine("Ajout du temps à une date locale");

            DateTimeOffset dto = new DateTimeOffset(2030, 3, 30, 23, 0, 0, new TimeSpan(1, 0, 0));

            // Convertit cette date/heure en temps UTC et lui ajoute le temps souhaité
            TimeSpan ajout = new TimeSpan(7, 30, 0);
            DateTimeOffset dto2 = dto.ToUniversalTime().Add(ajout);

            // Reconvertit le résultat en temps local
            dto2 = dto2.ToLocalTime();

            // Affiche le résultat
            Console.WriteLine($"{dto} + {ajout} = {dto2}");
            // 30/03/30 23:00:00 +01:00 + 7:30 = 31/03/30 07:30:00 +02:00
            // Le passage à l'heure d'été a bien été intégré
        }


    }
}
