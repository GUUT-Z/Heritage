using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public abstract class Carte
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public Rarete Rarete { get; set; }

        public Carte(string nom, string description, Rarete rarete)
        {
            Nom = nom;
            Description = description;
            Rarete = rarete;
        }

        public virtual string Decrire()
        {
            return Nom+(Rarete) + ":" + Description ;
            throw new NotImplementedException();
        }
    }
}
