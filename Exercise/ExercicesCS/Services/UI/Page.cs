using System;

namespace Services.UI
{
    public abstract class Page : IPage
    {
        public IPage? Parente { get; set; }

        public string Titre { get; set; } = string.Empty;

        public virtual void Afficher()
        {
            Console.WriteLine(Titre);
            Console.WriteLine("-----------------------");
            Executer();
        }

        public abstract void Executer();
    }
}
