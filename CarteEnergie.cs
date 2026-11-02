using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public class CarteEnergie : Carte
    {
        public TypePokemon Type { get; }

        public CarteEnergie(string nom, TypePokemon type) 
            : base (nom, "Carte énergie", Rarete.Commune)
        {
            Type= type;
        }
    }
}
