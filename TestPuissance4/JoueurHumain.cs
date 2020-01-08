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
                //try
                //{
                //    Console.WriteLine(" -----------------------------------------");
                //    Console.Write(" | Veuillez saisir une valeur : ");
                //    string input = Console.ReadLine();
                //    colonne = Convert.ToInt32(input) - 1;
                //    //colonne--;

                //    if (colonne < grille.Tableau.GetLength(0) && colonne >= 0)
                //    {
                //        ligne = grille.GetLigne(colonne);
                //        if (ligne >= 0)
                //        {
                //            rester = false;
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine(" | Saisie incorrecte");
                //    }
                //}
                //catch (ReflectionTypeLoadException reflectionEx) when (reflectionEx.InnerException is FormatException)
                //{
                //    Console.WriteLine(" | Veuillez saisir une valeure numérique");
                //}
                //catch (Exception ex) when (ex.InnerException is FormatException)
                //{
                //    Console.WriteLine(" | Veuillez saisir une valeure numérique");

                //}
                //catch (Exception ex)
                //{
                //    if (ex.Message == "Le format de la chaîne d'entrée est incorrect.")
                //    {
                //        Console.WriteLine(" | Veuillez saisir une valeure numérique");
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}


                Console.Clear();
                jeu.AfficherTitre(false);
                Console.WriteLine($"{jeu.Joueur1.NomJoueur} : {jeu.Joueur1.Score}, {jeu.Joueur2.NomJoueur} : {jeu.Joueur2.Score} \n");
                grille.Afficher();
                
                string ligneBtm = "      ";
                string fleche = "^";
                for (int i = 0; i < grille.NbColonnes; i++)
                {
                    if (i == colonne)
                    {
                        ligneBtm += $"  {fleche} ";
                    }
                    else
                    {
                        ligneBtm += $"    ";
                    }
                }

                Console.WriteLine(ligneBtm);

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
                //Console.WriteLine(input.Key);

                

                if (input.Key == ConsoleKey.RightArrow)
                {
                    //Console.WriteLine("Droite");
                    if (colonne < grille.NbColonnes - 1)
                    {
                        colonne++;
                    }
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    //Console.WriteLine("Gauche");
                    if (colonne > 0)
                    {
                        colonne--;
                    }
                }
                // TODO : Rendre ce bazar des touches dynamique
                else if (input.Key == ConsoleKey.NumPad1)
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
                    //Console.WriteLine("Entrer (Hum Hum)");
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

            // Animation
            for (int i = 0; i <= ligne; i++)
            {
                Console.Clear();
                jeu.AfficherTitre(false);
                Console.WriteLine($"{jeu.Joueur1.NomJoueur} : {jeu.Joueur1.Score}, {jeu.Joueur2.NomJoueur} : {jeu.Joueur2.Score} \n");
                grille.Positionner(i, colonne, NumeroJoueur);
                grille.Afficher();
                System.Threading.Thread.Sleep(20);
                grille.Positionner(i, colonne, 0);
            }

            // On place le pion
            Console.Beep();
            grille.Positionner(ligne, colonne, NumeroJoueur);
        }
    }
}
