using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ComparateurListes
{
    internal class DAL
    {
        //comparaison sur les propriétés des objets
        public record class Etudiant(string Nom, string Prenom)
        {

            public override string ToString()
            {
                return Nom + " " + Prenom;
            }
        }


        //comparaisson sur les references d'objets
        /*public class Etudiant
        {
            public Etudiant(string nom, string prénom)
            {
                Nom = nom;
                Prénom = prénom;
            }

            public string Nom { get; }
            public string Prénom { get; }

            public override string ToString()
            {
                return Nom + " " + Prénom;
            }

        }*/

            public static HashSet<Etudiant> GetEtudiants(string nomFichier)
        {
            HashSet<Etudiant> étudiants = new();
            string[] lignes = File.ReadAllLines(nomFichier);

            for (int i = 0; i < lignes.Length; i++)
            {
                string[] infos = lignes[i].Split(';');
                étudiants.Add(new Etudiant(infos[0], infos[1]));
            }
            return étudiants;
        }
    }
}
