using POO2.Model;

namespace POO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Compositon et agrégation

            // Composition - appel pour la composition
            Joueur j1 = new Joueur("Riou", "Rémy");
            j1.CreerLicence(75968541, "Olympique lyonnais");

            if (j1.LicenceCourante != null)
                Console.WriteLine($"Licence N° {j1.LicenceCourante.Numero} " +
                    $"délivrée le {j1.LicenceCourante.DateDelivrance}");

            // Agrégation - appel pour l'agregation objet peut exister sans la class
            //on instancie les clubs à ce moment-la
            Club SE = new Club("AS Saint-Etiene");
            Club OL = new Club("Olympique lyonnais");
            Rencontre r = new Rencontre(DateTimeOffset.Now, SE, OL);

            Console.WriteLine($"Rencontre entre les clubs {SE.Nom} et {OL.Nom} le {r.DateRencontre}");
            #endregion

            #region Liste générique
            // Ajout de joueurs à la liste des joueurs d'un club
            OL.Joueurs.Add(j1);
            Joueur j2 = new Joueur("Bonnevie", "Kayne");
            OL.Joueurs.Add(j2);
            Joueur j3 = new Joueur("Silva", "Henrique");//syntaxe plus condense
            OL.Joueurs.Add(j3);

            // Parcourt la liste 
            for (int i = 0; i < OL.Joueurs.Count; i++)
            {
                Console.WriteLine(OL.Joueurs[i].Nom);
            }
            //insertion d'éléments au milieu de la liste
            Joueur j4 = new Joueur("Patenne", "Adeline");
            OL.Joueurs.Insert(0, j4);// ajoute le joueur en 2eme premiere

            // Ajoute un joueur en première position dans la liste
            Joueur j5 = new Joueur("Lopes", "Anthony");
            OL.Joueurs.Insert(0, j5);

            // Supprime le dernier joueur de la liste
            OL.Joueurs.RemoveAt(OL.Joueurs.Count - 1);

           // OL.Joueurs.RemoveRange()Debut et fin en parametre
           //Ol.Joueurs.Remove(J1);
           //Ol.Joueurs.Clear(); on vide la liste

            Console.WriteLine();
            foreach (Joueur joueur in OL.Joueurs)
            {
                Console.WriteLine(joueur.Nom);
            }

            // Récupère tous les joueurs dont le nom commence par Bo
            List<Joueur> liste = OL.Joueurs.FindAll(j => j.Nom.StartsWith("Bo"));

            // Récupère le premier joueur dont le nom commence par Bo
            Joueur? j = OL.Joueurs.Find(j => j.Nom.StartsWith("Bo"));

            // Récupère le dernier joueur dont le nom commence par Bo
            Joueur? j5 = OL.Joueurs.FindLast(j => j.Nom.StartsWith("Bo"));

            // Vérifie si un joueur est présent dans la liste
            bool present = OL.Joueurs.Contains(j3);
            Console.WriteLine($"{j3.Nom}{(present ? "" : " non")} présent dans la liste");

            #endregion
        }
    }
}