//ifelswitch

using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Echanges
{
    internal class Toto
    {
        public void DonnerAge()
        {
            //ifelswitch

            //using System.ComponentModel.Design;
            //using System.Net.Http.Headers;
            //using System.Security.Cryptography.X509Certificates;

            Console.WriteLine("Bonjour ! Comment t'appelles-tu ?");

            //pour recup�rer donn�es utilisateur
            string? rep = Console.ReadLine();

            Console.WriteLine("Bonjour " + rep + "!");


            Console.WriteLine("Quel est ton ann�e de naissance ?");


            string repAnn = Console.ReadLine();

            int anneeNais = int.Parse(repAnn);



            int age = DateTime.Today.Year - anneeNais;

            Console.WriteLine(anneeNais);



            Console.WriteLine($"{rep},tu vas avoir {age} ans en {DateTime.Today.Year}.");


            if (age < 25)
            {
                Console.WriteLine("Ta tranche d'age est : moins de 25 ans");
            }
            else if (age >= 25 && age < 40)
            {
                Console.WriteLine("Ta tranche d'age est :25 - 40 ans.");
            }
            else if (age >= 40 && age < 55)
            {
                Console.WriteLine("Ta tranche d'age est : 40 - 55 ans.");
            }
            else
            {
                Console.WriteLine("Ta tanche d'age est : plus de 55 ans.");
            }

            Console.WriteLine();

            if (anneeNais >= 1900 && anneeNais <= DateTime.Today.Year)

            {
                string tranche1 = string.Empty;
                if (age < 25)
                {
                    tranche1 = "moins de 25 ans";
                }
                else if (age >= 25 && age < 40)
                {
                    tranche1 = "25 - 40 ans";
                }
                else if (age >= 40 && age < 55)
                {
                    tranche1= "40 - 55 ans";
                }
                else
                {
                    tranche1 = "pluse de 55 ans";
                }
                Console.WriteLine($"Ta tranche d'age est : {tranche1}.");

            }
            else
            {
                Console.WriteLine($"Ton ann�e de  naissance doit �tre comprise entre 1900 et {DateTime.Today.Year}");
            }

            Console.WriteLine();



            string tranche = age switch
            {
                < 25 => "moins de 25 ans",
                < 40 => "25 - 40 ans",
                < 55 => "40 - 55 ans",
                _ => "plus de 55 ans"
            };


            Console.WriteLine($"La tranche d'age est : {tranche}.");



            Console.WriteLine();



            Console.WriteLine("As-tu un bon de reduction (O/N) ?");
            rep = Console.ReadLine();

            bool reduc = false;
            if (rep == "O")
            {
                reduc = true;
            }
            else
            {
                reduc = false;
            }
            //Operateur ternaire
            //bool reduc = (rep == "O") ? true : false;


            Console.ReadLine();

            Console.WriteLine("Je suis un test");
            Console.WriteLine("Je suis un test2");



            Console.WriteLine($"Demndez un chifre en 1 et 10 :");
            string input = Console.ReadLine();
            //int x = int.Parse(input);
            if (int.TryParse(input, out int x))
            {
                if (x <= 1)
                {
                    Console.WriteLine("Tu es un noob");
                }
                else
                {
                    Console.WriteLine("Tu es le meilleur");
                }
            }
            else
            {
                Console.WriteLine("Entrée non valide.");
            }

            //string tranche = string.Empty;
            //switch (age)
            //{
            //    case < 25:
            //        tranche = "moins de 25 ans";
            //        break;

            //    case < 40:
            //        tranche = " 25 - 40 ans";
            //        break;


            //    case < 55;
            //        tranche = "40 - 55 ans":
            //        break;

            //    default:
            //        tranche = "plus de 55 ans";
            //        break;
            //}












        }
    }
}