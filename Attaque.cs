using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage
{
    public class Attaque
    {
        public string Nom { get; set; }
        public int Degats { get; }
        public int Cout { get; } 

        public Attaque(string nom, int degats, int cout) 
        {
            Nom = nom;
            Degats = degats;
            Cout = cout;
        }

    }
}
