using ComparateurListes;
using System;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static ComparateurListes.DAL;

namespace ComparateurListes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Etudiant> ens1 = DAL.GetEtudiants("Etudiants1.csv");
            HashSet<Etudiant> ens2 = DAL.GetEtudiants("Etudiants2.csv");

            // Étudiants dans le fichier 1 mais pas dans le fichier 2
             var diff1 = new HashSet<Etudiant>(ens1);
            diff1.ExceptWith(ens2);


            Console.WriteLine("Etudiants présents seulement dans le fichier numéro 1 : \n");
            foreach (Etudiant e in diff1) Console.WriteLine(e);


            // Étudiants dans le fichier 2 mais pas dans le fichier 1
            var diff2 = new HashSet<Etudiant>(ens2);
            diff2.ExceptWith(ens1);


            Console.WriteLine("Etudiants présents seulement dans le fichier numéro 2 : \n");
            foreach (Etudiant e in diff2) Console.WriteLine(e);


            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();


        }
    }
}
