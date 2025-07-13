using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public class HTMLWriter
    {
        public static void GénérerPage(List<Livre> livres, string chemin)
        {
            using StreamWriter writer = new (chemin, false, Encoding.UTF8);


            writer.WriteLine("<html lang=\"fr\">");
            writer.WriteLine("<head>");
            writer.WriteLine("   <meta charset=\"UTF-8\">");
            writer.WriteLine("   <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            writer.WriteLine("   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            writer.WriteLine("   <title>Bibliothèque</title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            foreach (Livre livre in livres)
            {
                writer.WriteLine("   <div style=\"display: grid; grid-template-columns: 200px 150px 1fr; grid-gap: .5rem; font-size:1.3rem;\">");
                writer.WriteLine($"      <img src=\"{livre.NomImage}\" width=\"200px\"/>");
                writer.WriteLine("      <div style=\"font-weight: bold; text-align: right;\">");
                writer.WriteLine("         <p>ISBN :</p>");
                writer.WriteLine("         <p>Titre :</p>");
                writer.WriteLine("         <p>Auteur :</p>");
                writer.WriteLine("         <p>Publication :</p>");
                writer.WriteLine("         <p>Description :</p>");
                writer.WriteLine("      </div>");
                writer.WriteLine("      <div>");
                writer.WriteLine($"         <p>{livre.ISBN}</p>");
                writer.WriteLine($"         <p>{livre.Titre}</p>");
                writer.WriteLine($"         <p>{livre.Auteur}</p>");
                writer.WriteLine($"         <p>{livre.DatePublication:dd/MM/yy}</p>");
                writer.WriteLine($"         <p>{livre.Description}</p>");
                writer.WriteLine("      </div>");
                writer.WriteLine("   </div>");
                writer.WriteLine("<hr/>");
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");



        }
    }
}
