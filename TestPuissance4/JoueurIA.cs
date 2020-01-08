using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPuissance4
{
    public class JoueurIA : Joueur
    {
        private Random _randomSeed;
        private List<int> _colonnesToEventuallyPlay = new List<int>();
        private int _niveau;
        private Random RandomSeed { get => _randomSeed; }
        private List<int> ColonnesToEventuallyPlay { get => _colonnesToEventuallyPlay; set => _colonnesToEventuallyPlay = value; }
        public int Niveau { get => _niveau; set => _niveau = value; }
        
        public JoueurIA(int numeroJoueur, string nomJoueur, int niveauIA) : base(numeroJoueur, nomJoueur)
        {
            this._randomSeed = new Random();
            this._niveau = niveauIA;
            this._score = 0;
            System.Threading.Thread.Sleep(20);
        }
        public override void Jouer(Grille grille, Puissance4 jeu)
        {
            int ThinkLevel = 0;
            int ThinkTime = 0;
            int StrategyDice = RandomSeed.Next(1, 101);
            int colonne = 0;
            int ligne = 0;
            int timeout = 30;
            bool rester = true;
            do
            {
                int NumeroJoueurAdverse = 0;

                if (NumeroJoueur == 1)
                {
                    NumeroJoueurAdverse = 2;
                }
                else if (NumeroJoueur == 2)
                {
                    NumeroJoueurAdverse = 1;
                }
                
                if (Niveau == -1)
                {
                    if (this.AnalyserJoueur(this.NumeroJoueur, grille))
                    {
                        colonne = ColonnesToEventuallyPlay[RandomSeed.Next(ColonnesToEventuallyPlay.Count)];
                    }
                    else
                    {
                        int[] TableauDesComptes = new int[grille.NbColonnes];
                        int BestScore = 0;
                        for (int i = 0; i < grille.NbColonnes; i++)
                        {
                            ligne = grille.GetLigne(i);
                            int undercolor = 0;
                            int count = 0;
                            for (int j = ligne; j < grille.NbLignes ; j++)
                            {
                                if (j + 1 < grille.NbLignes)
                                {
                                    if (undercolor == 0)
                                    {
                                        undercolor = grille.Tableau[i, j + 1];
                                        count++;
                                    }
                                    else
                                    {
                                        if (grille.Tableau[i, j + 1] == undercolor)
                                        {
                                            count++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            TableauDesComptes[i] = count;
                            if (count > BestScore)
                            {
                                BestScore = count;
                            }
                        }

                        int index = 0;
                        foreach (var compte in TableauDesComptes)
                        {
                            if (compte == BestScore)
                            {
                                ColonnesToEventuallyPlay.Add(index);
                            }
                            index++;
                        }

                        colonne = ColonnesToEventuallyPlay[RandomSeed.Next(ColonnesToEventuallyPlay.Count)];
                    }
                   
                }


                ligne = grille.GetLigne(colonne);
                if (ligne >= 0)
                {
                    rester = false;
                }
                else
                {
                    if (timeout > 0)
                    {
                        timeout--;
                    }
                    else
                    {
                        do
                        {
                            colonne = RandomSeed.Next(0, grille.Tableau.GetLength(0));
                            ligne = grille.GetLigne(colonne);
                        } while (ligne < 0);
                        rester = false;
                    }
                }
            } while (rester);
            

            grille.Positionner(ligne, colonne, NumeroJoueur);
            ColonnesToEventuallyPlay.Clear();
        }

        
        private bool AnalyserJoueur(int numJoueur, Grille plateau)
        {
            ColonnesToEventuallyPlay.Clear();
            for (int colonne = 0; colonne < plateau.NbColonnes; colonne++)
            {
                int ligne = plateau.GetLigne(colonne);

                if (ligne >= 0)
                {
                    plateau.Positionner(ligne, colonne, numJoueur);
                    if (plateau.TesterGagner() > 0)
                    {
                        ColonnesToEventuallyPlay.Add(colonne);
                    }
                    plateau.Positionner(ligne, colonne, 0);
                    plateau.ColonneCaseGagnanteDebut = -1;
                    plateau.LigneCaseGagnanteDebut = -1;
                    plateau.VictoryType = -1;
                }
            }

            if (ColonnesToEventuallyPlay.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
