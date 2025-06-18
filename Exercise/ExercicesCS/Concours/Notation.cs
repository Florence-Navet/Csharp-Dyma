using Concours;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours
{
    public enum Mention { E, P, AB, B, TB }
    internal class Notation
    {
        private static string[] Libelles = { "Échec", "Passable", "Assez bien", "Bien", "Très bien" };

        public static (Mention, string) GetMention(double note)
        {
            Mention mention;

            if (note < 10)
                mention = Mention.E;
            else if (note < 12)
                mention = Mention.P;
            else if (note < 14)
                mention = Mention.AB;
            else if (note < 16)
                mention = Mention.B;
            else
                mention = Mention.TB;

            return (mention, Libelles[(int)mention]);



        

        }

    }
}

