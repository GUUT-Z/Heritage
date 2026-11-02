using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public class CarteDresseur : Carte
    {
        public string Categorie { get; }
        public string Effet { get; }

        public CarteDresseur(string nom, Rarete rarete, string categorie, string effet)
            : base(nom,effet, rarete)
        {
            Categorie = categorie;
            Effet = effet;
        }
    }
}
