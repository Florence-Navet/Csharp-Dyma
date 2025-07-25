using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Ton expression régulière
        string pattern = @"^[\w+\-*/=_]+@[\w_]{1,20}\.[A-Za-z]{2,5}$";

        // Quelques exemples à tester
        string[] emails = {
            "toto-2@truc.com",     // valide
            "a1+@serveur.net",     // valide
            "@truc.com",           // invalide
            "toto@truc.c",         //invalide
            "toto@truc.commune",   // invalide
            "toto@truc!com"        // invalide
        };

        Console.WriteLine("🔍 Vérification des adresses e-mail :\n");

        foreach (string email in emails)
        {
            bool isValid = Regex.IsMatch(email, pattern);
            Console.WriteLine($"{email,-25} => {(isValid ? "Valide" : "Invalide")}");
        }
    }
}
