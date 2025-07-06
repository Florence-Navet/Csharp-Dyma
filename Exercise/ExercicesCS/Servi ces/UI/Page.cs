using System;

namespace Servi_ces.UI
{
    public abstract class Page : IPage
    {
        public IPage Parente { get; set; }

        public string Titre { get; set; }

        public virtual void Afficher()
        {
            Console.WriteLine(Titre);
            Console.WriteLine("-----------------------");
            Executer();
        }

        public abstract void Executer();
    }
}
