using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPuissance4
{
    public class Joueur
    {
        protected int _numeroJoueur = 0;
        protected string _nomJoueur = string.Empty;
        protected int _score = 0;

        public int NumeroJoueur { get => _numeroJoueur; set => _numeroJoueur = value; }
        public string NomJoueur { get => _nomJoueur; set => _nomJoueur = value; }
        public int Score { get => _score; set => _score = value; }

        public Joueur()
        {
        }

        public Joueur(int numeroJoueur, string nomJoueur)
        {
            NumeroJoueur = numeroJoueur;
            NomJoueur = nomJoueur ?? throw new ArgumentNullException(nameof(nomJoueur));
            Score = 0;
        }

        public virtual void Jouer(Grille grille, Puissance4 jeu)
        {

        }
    }
}