using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UI
{
    public interface IPage
    {
        IPage? Parente { get; set; }

        string Titre { get; set; }

        void Afficher();
        
    }
}
