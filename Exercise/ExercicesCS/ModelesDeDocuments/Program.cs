using System;

namespace ModelesDeDocuments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======Création de documents depuis des modèles========");
            Console.WriteLine();

            // Création du tableau de 3 personnes, la première est null
            Personne?[] personnes = new Personne?[3];
            personnes[0] = null;
            personnes[1] = new Personne { Prenom = "Julien", Nom = "Mousquet" };
            personnes[2] = new Personne { Prenom = "Tristan", Nom = "Mousquet" };

            // 1. Modèle correct avec auteur
            var doc1 = Document.CreerDepuisModele("Modèle A", personnes[1]);
            AfficherDocument(doc1);

            // 2. Modèle correct sans auteur
            var doc2 = Document.CreerDepuisModele("Modèle B", personnes[0]);
            AfficherDocument(doc2);

            // 3. Modèle incorrect avec auteur
            var doc3 = Document.CreerDepuisModele("Modèle C", personnes[2]);
            AfficherDocument(doc3);

            Console.WriteLine();

            // Appel de la méthode qui change la couleur
            AfficherTexte("Appuyez sur une touche pour continuer", ConsoleColor.Cyan);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("======Créer un tableau de 3 noms de modèles avec les valeurs========");
            string[] nomsModèles = { "Modèle A", "Modèle B", "Modèle C" };

            for (int i = 0; i < nomsModèles.Length; i++) {
                var doc = Document.CreerDepuisModele(nomsModèles[i]);
                AfficherDocument(doc);
            }

            Console.WriteLine();

            // Appel de la méthode qui change la couleur
            AfficherTexte("Appuyez sur une touche pour continuer", ConsoleColor.Magenta);
            Console.ReadKey();
            Console.Clear();
             Console.WriteLine("======Créer un tableau de avec une boucle i========");
            for (int i = 0; i < 3; i++)
            {
                var doc = Document.CreerDepuisModele(nomsModèles[i], personnes[i]);
                Console.WriteLine($"Tentative création document {i}: ");
                AfficherDocument(doc);
                Console.WriteLine();
            }






        }

        /// <summary>
        /// Affiche du texte avec une couleur temporaire dans la console
        /// </summary>
        public static void AfficherTexte(string texte, ConsoleColor couleur)
        {
            ConsoleColor consoleOrig = Console.ForegroundColor;
            Console.ForegroundColor = couleur;
            Console.WriteLine(texte);
            Console.ForegroundColor = consoleOrig;
            Console.WriteLine(); // retour à la ligne
        }

        /// <summary>
        /// Affiche un document ou un message si null
        /// </summary>
        static void AfficherDocument(Document? document)
        {
            if (document != null)
            {
                Console.WriteLine("Document créé : ");
                Console.WriteLine($"Pied de page : {document.PiedDePage}");
                Console.WriteLine($"Marges : H: {document.Marges.Haut}cm B= {document.Marges.Bas}cm" +
                    $" G= {document.Marges.Gauche}cm D= {document.Marges.Droite}cm");
            }
            else
            {
                Console.WriteLine("Document introuvable");
            }
        }
    }
}
