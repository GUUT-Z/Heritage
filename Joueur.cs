using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public class Joueur
    {
        public const int TailleBancMax = 5;
        public string Nom { get;}
        public List<Carte> Deck { get; }
        public List<Carte> Main { get; } = new List<Carte>();
        public CartePokemon PokemonActif { get; private set; }
        public List<CartePokemon> Banc { get; } = new List<CartePokemon>();
        private bool ApiocherceTour;
        private bool EnergieAttacheceTour; 
        public Joueur(string nom, List<Carte> deck)
        {
            Nom = nom;
            Deck = deck;
        }

        public Carte Piocher()
        {
            if (ApiocherceTour)
            {
                throw new InvalidOperationException("Le joueur a déja pioché ce tour.");
            }
            if(Deck.Count == 0)
            {
                throw new InvalidOperationException("Le deck est vide.");
            }
            Carte carte = Deck[0];
            Deck.RemoveAt(0);
            Main.Add(carte);
            ApiocherceTour = true;
            return carte;
            throw new NotImplementedException();
        }

        public void JouerCarte(Carte carte)
        {
            if(!Main.Contains(carte))
            {
                throw new InvalidOperationException("La carte n'est pas dans la main.");
            }
            switch(carte)
            {
                case CartePokemon pokemon:
                    if (PokemonActif == null)
                    {
                        PokemonActif = pokemon;    
                    }
                    else
                    {
                        if(Banc.Count >= TailleBancMax)
                        {
                            throw new InvalidOperationException("Le banc est déja complet");
                        }
                        Banc.Add(pokemon);
                    }
                    break;

                case CarteEnergie energie:
                    if(PokemonActif == null || EnergieAttacheceTour)
                    {
                        throw new InvalidOperationException("");
                    }
                    PokemonActif.AttacherEnergie();
                    EnergieAttacheceTour = true;
                    break;

                case CarteDresseur dresseur:
                    Console.WriteLine(dresseur.Effet);
                    break;
            }
            Main.Remove(carte);
        }

        public int Attaquer(Attaque attaque, Joueur adversaire)
        {
            // 1. Vérifier que les deux joueurs ont un Pokémon actif
            if (PokemonActif == null ||adversaire == null || adversaire.PokemonActif == null)
            {
                throw new InvalidOperationException(
                    "Les deux joueurs doivent avoir un Pokémon actif."
                );
            }

            // 2. Vérifier que l'attaque appartient au Pokémon actif
            if (attaque == null || !PokemonActif.Attaques.Contains(attaque))
            {
                throw new ArgumentException(
                    "Cette attaque n'appartient pas au Pokémon actif."
                );
            }

            // 3. Vérifier les énergies nécessaires
            if (PokemonActif.EnergiesAttachees < attaque.Cout)
            {
                throw new InvalidOperationException(
                    "Pas assez d'énergie pour utiliser cette attaque."
                );
            }

            // 4. Infliger les dégâts
            int degats = attaque.Degats;
            adversaire.PokemonActif.RecevoirDegats(degats);

            // 5. Retourner les dégâts infligés
            return degats;
        }

        public void PasserSonTour()
        {
            ApiocherceTour = false;
            EnergieAttacheceTour = false;
        }
    }   
}
