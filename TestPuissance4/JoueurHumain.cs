using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestPuissance4
{
    public class JoueurHumain : Joueur
    {
        public JoueurHumain(int numeroJoueur, string nomJoueur) : base(numeroJoueur, nomJoueur){ Score = 0; }

        public override void Jouer(Grille grille, Puissance4 jeu)
        {
            int colonne = 0;
            int ligne = 0;
            bool rester = true;
            do
            {
                Console.Clear();
                jeu.AfficherTitre(false);
                Console.WriteLine($"{jeu.Joueur1.NomJoueur} : {jeu.Joueur1.Score}, {jeu.Joueur2.NomJoueur} : {jeu.Joueur2.Score} \n");
                grille.Afficher();
                

                if (this.NumeroJoueur == 1)
                {
                    if (jeu.Joueur2 is JoueurHumain)
                    {
                        Console.WriteLine($"Tour de {this.NomJoueur}");
                    }
                }
                else
                {
                    if (jeu.Joueur1 is JoueurHumain)
                    {
                        Console.WriteLine($"Tour de {this.NomJoueur}");
                    }
                }

                var input = Console.ReadKey();
                
                if (input.Key == ConsoleKey.NumPad1)
                {
                    colonne = 0;
                }
                else if (input.Key == ConsoleKey.NumPad2)
                {
                    colonne = 1;
                }
                else if (input.Key == ConsoleKey.NumPad3)
                {
                    colonne = 2;
                }
                else if (input.Key == ConsoleKey.NumPad4)
                {
                    colonne = 3;
                }
                else if (input.Key == ConsoleKey.NumPad5)
                {
                    colonne = 4;
                }
                else if (input.Key == ConsoleKey.NumPad6)
                {
                    colonne = 5;
                }
                else if (input.Key == ConsoleKey.NumPad7)
                {
                    colonne = 6;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    if (colonne < grille.Tableau.GetLength(0) && colonne >= 0)
                    {
                        ligne = grille.GetLigne(colonne);
                        if (ligne >= 0)
                        {
                            rester = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine(" | Saisie incorrecte");
                    }
                }

            } while (rester);
            grille.Positionner(ligne, colonne, NumeroJoueur);
        }
    }
}
