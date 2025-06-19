using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours

{

    [Flags] internal enum Statuts { Aucun = 0, Etranger = 1, Boursier = 2, Admis = 4 }

    internal class DAL
    {
        public static (string nomComplet, double moyenne, Statuts statut)[]? Etudiants;
        public const int NbAdmis = 50;

        public static void AfficherEtudiants()
        {
            Program.AfficherTexte("Liste des étudiants :\n", ConsoleColor.Green);

            foreach (var (nom, moyenne, statut) in Etudiants ?? Array.Empty<(string, double, Statuts)>())
            {
                Console.WriteLine($"{nom} : {moyenne} / 20");
            }

        }


        //charge le f iche des étudiants dans de tableau de tuples
        public static void ChargerDonnees(string chemin)
        {
            string[] lignes = File.ReadAllLines(chemin);
            Etudiants = new (string, double, Statuts)[lignes.Length - 1];

            for (int i = 1; i < lignes.Length; i++) // Commencer à 1 pour sauter l'en-tête
            {
                string[] infos = lignes[i].Split(';');
                string nomComplet = infos[1] + " " + infos[0]; // Prénom Nom
                double moyenne = double.Parse(infos[4].Replace(',', '.'), CultureInfo.InvariantCulture);

                Statuts st = Statuts.Aucun;
                if (infos[2] == "O") st |= Statuts.Etranger;
                if (infos[3] == "O") st |= Statuts.Boursier;
                if (moyenne >= 12) st |= Statuts.Admis;

                Etudiants[i - 1] = (nomComplet, moyenne, st);
            }
        }
        public static string[] RemplacerEtudiantsAdmis(params string[] noms)
        {
            // Initialise le tableau et le compteur de remplaçants
            string[] remplaçants = new string[noms.Length];
            int cptRemp = 0;

            if (Etudiants == null) return remplaçants;

            // Pour chaque étudiant à remplacer
            for (int n = 0; n < noms.Length; n++)
            {
                // On recherche l'étudiant dans la liste
                for (int i = 0; i < NbAdmis; i++)
                {
                    if (Etudiants[i].nomComplet == noms[n])
                    {
                        // On enlève le statut admis de l'étudiant
                        Etudiants[i].statut ^= Statuts.Admis;

                        // On ajoute le statut Admis au premier non admis
                        // et on enregistre son nom dans le tableau des remplaçants
                        Etudiants[NbAdmis + cptRemp].statut |= Statuts.Admis;
                        remplaçants[n] = Etudiants[NbAdmis + cptRemp].nomComplet;

                        // On incrémente le compteurs de remplaçants et on sort de la boucle
                        cptRemp++;
                        break;
                    }
                }
            }
            return remplaçants;
        }




        //public static List<string> RemplacerEtudiantsAdmis(params string[] nomsSortants)
        //{
        //    List<string> nouveauxAdmis = new();
        //    if (Etudiants == null)
        //    {
        //        Console.WriteLine("Aucune donnée étudiante n’a été chargée.");
        //        return nouveauxAdmis;
        //    }

        //    // Liste pour bloquer le retour des désistés
        //    var sortantsSet = new HashSet<string>(
        //        nomsSortants.Select(n => n.Trim()),
        //        StringComparer.OrdinalIgnoreCase
        //    );

        //    foreach (string nomSortant in nomsSortants)
        //    {
        //        bool sortantTrouvé = false;
        //        for (int i = 0; i < Etudiants.Length; i++)
        //        {
        //            if (Etudiants[i].nomComplet.Equals(nomSortant.Trim(), StringComparison.OrdinalIgnoreCase))
        //            {
        //                sortantTrouvé = true;

        //                if (Etudiants[i].statut.HasFlag(Statuts.Admis))
        //                {
        //                    Etudiants[i].statut &= ~Statuts.Admis;

        //                    // Chercher un remplaçant
        //                    bool remplaçantTrouvé = false;
        //                    for (int j = 0; j < Etudiants.Length; j++)
        //                    {
        //                        if (!Etudiants[j].statut.HasFlag(Statuts.Admis) &&
        //                            Etudiants[j].moyenne >= 10 &&
        //                            !sortantsSet.Contains(Etudiants[j].nomComplet))
        //                        {
        //                            Etudiants[j].statut |= Statuts.Admis;
        //                            nouveauxAdmis.Add(Etudiants[j].nomComplet);
        //                            //Console.WriteLine($"Remplacement de {nomSortant} par {Etudiants[j].nomComplet}");
        //                            remplaçantTrouvé = true;
        //                            break;
        //                        }
        //                    }

        //                    if (!remplaçantTrouvé)
        //                        Console.WriteLine($"Aucun remplaçant trouvé pour {nomSortant}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"{nomSortant} n’était pas admis → aucun remplacement effectué");
        //                }

        //                break;
        //            }
        //        }

        //        if (!sortantTrouvé)
        //            Console.WriteLine($"Étudiant '{nomSortant}' introuvable dans la liste");
        //    }

        //    return nouveauxAdmis;
        //}



    }
}
