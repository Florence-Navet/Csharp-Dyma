using System;
using CalendrierPerpetuel;

namespace CalendrierPerpetuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le Calendrier Perpetuel !");
            Console.WriteLine();

            int année = DemanderAnnéeUtilisateur();

            var joursFeries = CalculateurCalendrier.CalculerJoursFériésFrançais(année);

            var (heureEte, heureHiver) = CalculateurCalendrier.CalculerChangementsHeures(année);

            Console.WriteLine("\nChangements d'heure pour " + année + " :");
            Console.WriteLine($"Passage à l'heure d'été : {heureEte:dddd dd MMMM yyyy HH:mm}");
            Console.WriteLine($"Passage à l'heure d'hiver : {heureHiver:dddd dd MMMM yyyy HH:mm}");

            Console.WriteLine($"\nDates des débuts de saisons de l'année {année}");
            Console.WriteLine("---------------------------------------------");

            var (printemps, ete, automne, hiver) = CalculateurCalendrier.CalculerDatesDébutsSaisons(année);

            Console.WriteLine($"- printemps : {FormatDate(printemps)}");
            Console.WriteLine($"- été       : {FormatDate(ete)}");
            Console.WriteLine($"- automne   : {FormatDate(automne)}");
            Console.WriteLine($"- hiver     : {FormatDate(hiver)}");

            Console.WriteLine($"\nJours fériés en {année} :");
            Console.WriteLine("------------------------");

            foreach (var (date, libelle) in joursFeries)
            {
                Console.WriteLine($"- {FormatDate(date)} : {libelle}");
            }

            Console.WriteLine("------------------------------------");

            // Saisie date anniversaire
            (int jour, int mois) = DemanderDateAnniversaire();

            try
            {
                var dateAnniversaire = new DateOnly(année, mois, jour);

                string jourSemaine = dateAnniversaire.DayOfWeek switch
                {
                    DayOfWeek.Monday => "lundi",
                    DayOfWeek.Tuesday => "mardi",
                    DayOfWeek.Wednesday => "mercredi",
                    DayOfWeek.Thursday => "jeudi",
                    DayOfWeek.Friday => "vendredi",
                    DayOfWeek.Saturday => "samedi",
                    DayOfWeek.Sunday => "dimanche",
                    _ => "inconnu"
                };

                Console.WriteLine($"\nEn {année}, votre anniversaire sera un {jourSemaine}.");
            }
            catch
            {
                Console.WriteLine($"La date {jour}/{mois} n'existe pas en {année}.");
            }
        }

        // Méthode pour demander une année
        static int DemanderAnnéeUtilisateur()
        {
            int annee;
            while (true)
            {
                Console.Write("Entrez une année : ");
                string saisie = Console.ReadLine();

                if (int.TryParse(saisie, out annee) && annee > 0)
                    return annee;

                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier positif.");
            }
        }

        // Méthode pour formater une date
        static string FormatDate(DateOnly date)
        {
            string jourSemaine = date.DayOfWeek switch
            {
                DayOfWeek.Monday => "lun.",
                DayOfWeek.Tuesday => "mar.",
                DayOfWeek.Wednesday => "mer.",
                DayOfWeek.Thursday => "jeu.",
                DayOfWeek.Friday => "ven.",
                DayOfWeek.Saturday => "sam.",
                DayOfWeek.Sunday => "dim.",
                _ => ""
            };

            string mois = date.Month switch
            {
                1 => "janv.",
                2 => "févr.",
                3 => "mars",
                4 => "avr.",
                5 => "mai",
                6 => "juin",
                7 => "juil.",
                8 => "août",
                9 => "sept.",
                10 => "oct.",
                11 => "nov.",
                12 => "déc.",
                _ => ""
            };

            return $"{jourSemaine} {date.Day} {mois}";
        }

        // ✅ MÉTHODE MANQUANTE : demander JJ/MM
        static (int jour, int mois) DemanderDateAnniversaire()
        {
            while (true)
            {
                Console.Write("Entrez votre date d'anniversaire (format JJ/MM) : ");
                string saisie = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(saisie))
                {
                    var parties = saisie.Split('/');
                    if (parties.Length == 2 &&
                        int.TryParse(parties[0], out int jour) &&
                        int.TryParse(parties[1], out int mois))
                    {
                        try
                        {
                            var testDate = new DateOnly(2000, mois, jour); // Vérification générique
                            return (jour, mois);
                        }
                        catch
                        {
                            // Date invalide
                        }
                    }
                }

                Console.WriteLine("Format invalide. Veuillez entrer une date correcte au format JJ/MM.");
            }
        }
    }
}
