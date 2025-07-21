using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SaisieAutomatisée
{

    public static class ClientExtensions
    {
        //faot saisir les valeurs des propriétés de l'entité en gérant les erreurs de validation
        public static void SaisirValeursPropriétés(this Client client)
        {
            PropertyInfo[] props = client.GetType().GetProperties();

            foreach (PropertyInfo p in props)
            {

                // renvoie une valeur par defaut si la valeur est nulle
                string prompt = p.GetCustomAttribute<DisplayAttribute>()?.GetPrompt() ?? p.Name;

                bool ok;

                do
                {
                    ok = false;
                    Console.WriteLine(prompt + " : ");
                    string rep = Console.ReadLine() ?? "";
                    try
                    {
                        //convertit la valeur saisie dans le type de la propriété
                        object val = Convert.ChangeType(rep, p.PropertyType);
                        //affecte cette valeur à la propriéte
                        p.SetValue(client, val);
                        ok = true;
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("Format de donnée non valide");
                    }
                    catch (TargetInvocationException tie)
                    {
                        Console.WriteLine(tie.InnerException?.Message + "\n");
                            
                    }
                }
                while (!ok);
            }

        }
    }
}