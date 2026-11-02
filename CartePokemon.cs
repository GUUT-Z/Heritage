using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public class CartePokemon : Carte
    {
        public int PointsDeVie { get; private set; }
        public TypePokemon Type { get; }
        public int EnergiesAttachees { get; private set; }
        public List<Attaque> Attaques { get; } = new List<Attaque>();

        public bool EstKO
        {
            get
            {
                if(PointsDeVie <= 0) 
                    return true;
                return false;
            }
        }

        public CartePokemon(string nom, string description, Rarete rarete, int pv, TypePokemon type) 
            : base(nom, description, rarete)
        {
            PointsDeVie = pv;
            Type = type;
        }

        public void AttacherEnergie()
        {
            EnergiesAttachees += 1;
        }

        public int Attaquer(Attaque attaque, Joueur adversaire)
        {
            int degats = attaque.Degats;
            adversaire.PokemonActif.RecevoirDegats(degats);
            return degats;
        }

        public void RecevoirDegats(int degats)
        {
            if (degats < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(degats),
                    "Les dégâts ne peuvent pas être négatifs."
                );
            }

            PointsDeVie -= degats;

            if (PointsDeVie < 0)
            {
                PointsDeVie = 0;
            }
        }
    }
}
