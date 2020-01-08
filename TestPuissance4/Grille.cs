using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPuissance4
{
    public class Grille
    {
        private int[,] _tableau;
        private int _nbLignes = 0;
        private int _nbColonnes = 0;
        private int _ligneCaseGagnanteDebut = -1;
        private int _colonneCaseGagnanteDebut = -1;
        private int _victoryType = -1;
        private int _nbTour = 0;
        private int _nbTourMax = 0;
        private ConsoleColor VictoryBackColor = ConsoleColor.DarkRed;
        private ConsoleColor VictoryForeColor = ConsoleColor.Black;
        private ConsoleColor Player1BackColor = ConsoleColor.White;
        private ConsoleColor Player1ForeColor = ConsoleColor.Black;
        private ConsoleColor Player2BackColor = ConsoleColor.White;
        private ConsoleColor Player2ForeColor = ConsoleColor.Black;

        public int[,] Tableau { get => _tableau; set => _tableau = value; } // Tableau[Colonnes, Lignes]
        public int NbLignes { get => _nbLignes; set => _nbLignes = value; }
        public int NbColonnes { get => _nbColonnes; set => _nbColonnes = value; }
        public int LigneCaseGagnanteDebut { get => _ligneCaseGagnanteDebut; set => _ligneCaseGagnanteDebut = value; }
        public int ColonneCaseGagnanteDebut { get => _colonneCaseGagnanteDebut; set => _colonneCaseGagnanteDebut = value; }
        public int VictoryType { get => _victoryType; set => _victoryType = value; }
        public int NbTour { get => _nbTour; set => _nbTour = value; }
        public int NbTourMax { get => _nbTourMax; set => _nbTourMax = value; }

        /// <summary>
        /// Constructeur vide
        /// </summary>
        public Grille()
        {

        }

        /// <summary>
        /// Constructeur semi
        /// </summary>
        public Grille(int NbLignes, int NbColonnes)
        {
            this._nbColonnes = NbColonnes;
            this._nbLignes = NbLignes;
            this._tableau = new int[_nbColonnes, this.NbLignes];
            this.NbTourMax = NbLignes * NbColonnes;
            this.init();
        }

        /// <summary>
        /// Permet de cloner la grille
        /// </summary>
        /// <returns></returns>
        public Grille(Grille other)
        {
            //Grille other = (Grille)this.MemberwiseClone();
            //Grille other = new Grille(this.NbLignes, this.NbColonnes);

            //other.Course_ID = new Course(Course_ID.Course_Id);
            //other.Name = String.Copy(Name);

            this.VictoryBackColor = other.VictoryBackColor;
            this.VictoryForeColor = other.VictoryForeColor;
            this.Player1BackColor = other.Player1BackColor;
            this.Player1ForeColor = other.Player1ForeColor;
            this.Player2BackColor = other.Player2BackColor;
            this.Player2ForeColor = other.Player2ForeColor;
            this.Tableau = other.Tableau;
            this.NbLignes = other.NbLignes;
            this.NbColonnes = other.NbColonnes;
            this.LigneCaseGagnanteDebut = other.LigneCaseGagnanteDebut;
            this.ColonneCaseGagnanteDebut = other.ColonneCaseGagnanteDebut;
            this.VictoryType = other.VictoryType;
            this.NbTour = other.NbTour;
            this.NbTourMax = other.NbTourMax;

            //return other;
            //return this;
        }

        /// <summary>
        /// Permet de vider la grille de ses valeures
        /// </summary>
        public void init() {
            for (int i = 0; i < this.NbColonnes; i++)
            {
                for (int j = 0; j < NbLignes; j++)
                {
                    Tableau[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Permet d'affciher le tableau
        /// </summary>
        public void Afficher()
        {
            string Trait = "      +";
            for (int i = 0; i < NbColonnes; i++)
            {
                Trait += "---+";
            }

            string LigneNb = "      ";
            for (int i = 1; i <= NbColonnes; i++)
            {
                LigneNb += $"  {i} ";
            }


            Console.WriteLine(LigneNb);
            Console.WriteLine(Trait);
            for (int i = 0; i < NbLignes; i++)
            {
                Console.Write($"    {i + 1} |");
                for (int j = 0; j < NbColonnes; j++)
                {
                    bool SpecialColor = true;
                    switch (VictoryType)
                    {
                        case 1:
                            if (j >= ColonneCaseGagnanteDebut && j < ColonneCaseGagnanteDebut + 4 && LigneCaseGagnanteDebut == i)
                            {
                                TextColor.SetForeground(VictoryForeColor);
                                TextColor.SetBackGround(VictoryBackColor);
                            }
                            else
                            {
                                SpecialColor = false;
                            }
                            break;
                        case 2:
                            if (i >= LigneCaseGagnanteDebut && i < LigneCaseGagnanteDebut + 4 && ColonneCaseGagnanteDebut == j)
                            {
                                TextColor.SetForeground(VictoryForeColor);
                                TextColor.SetBackGround(VictoryBackColor);
                            }
                            else
                            {
                                SpecialColor = false;
                            }
                            break;
                        case 3:
                            if ((LigneCaseGagnanteDebut == i && ColonneCaseGagnanteDebut == j) || (LigneCaseGagnanteDebut + 1 == i && ColonneCaseGagnanteDebut + 1 == j) || (LigneCaseGagnanteDebut + 2 == i && ColonneCaseGagnanteDebut + 2 == j) || (LigneCaseGagnanteDebut + 3 == i && ColonneCaseGagnanteDebut + 3 == j))
                            {
                                TextColor.SetForeground(VictoryForeColor);
                                TextColor.SetBackGround(VictoryBackColor);
                            }
                            else
                            {
                                SpecialColor = false;
                            }
                            break;
                        case 4:
                            if ((LigneCaseGagnanteDebut == i && ColonneCaseGagnanteDebut == j) || (LigneCaseGagnanteDebut + 1 == i && ColonneCaseGagnanteDebut - 1 == j) || (LigneCaseGagnanteDebut + 2 == i && ColonneCaseGagnanteDebut - 2 == j) || (LigneCaseGagnanteDebut + 3 == i && ColonneCaseGagnanteDebut - 3 == j))
                            {
                                TextColor.SetForeground(VictoryForeColor);
                                TextColor.SetBackGround(VictoryBackColor);
                            }
                            else
                            {
                                SpecialColor = false;
                            }
                            break;
                        default:
                            SpecialColor = false;
                            TextColor.ResetColor();
                            break;
                    }
                    if (Tableau[j, i] == 1)
                    {
                        if (!SpecialColor)
                        {
                            TextColor.SetForeground(Player1ForeColor);
                            TextColor.SetBackGround(Player1BackColor);
                        }
                        Console.Write(" X ");
                        TextColor.ResetColor();
                    }
                    else if (Tableau[j, i] == 2)
                    {
                        if (!SpecialColor)
                        {
                            TextColor.SetForeground(Player1ForeColor);
                            TextColor.SetBackGround(Player1BackColor);
                        }
                        Console.Write(" O ");
                        TextColor.ResetColor();
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.Write("|");
                }

                Console.Write(Environment.NewLine);
                Console.WriteLine(Trait);
            }
        }

        /// <summary>
        /// Permet de tester s'il y a un gagnant ou non
        /// </summary>
        /// <returns>Le numéro du gagnant</returns>
        public int TesterGagner()
        {

            
            //         1--->
            //     4 2 3
            //    /  |  \
            //   v   v   v


            // Pour chaque cases dans la limite de -3 cases au niveau des lignes, test des combinaisons horizontale
            for (int i = 0; i < NbColonnes - 3; i++)
            {
                for (int j = 0; j < NbLignes; j++)
                {
                    int Couleur = Tableau[i, j];

                    if (Couleur != 0)
                    {
                        bool rester = true;
                        int Incr = 1;
                        int PionsAlignes = 1;

                        // 1
                        do
                        {
                            if (i + Incr < Tableau.GetLength(0) && Couleur == Tableau[i + Incr, j])
                            {
                                Incr++;
                                PionsAlignes++;
                            }
                            else
                            {
                                rester = false;
                            }
                        } while (rester);

                        // Test de victoire horizontale
                        if (PionsAlignes >= 4)
                        {
                            this.ColonneCaseGagnanteDebut = i;
                            this.LigneCaseGagnanteDebut = j;
                            this.VictoryType = 1;
                            return Couleur;
                        }
                    }

                }
            }

            // Pour chaque cases dans la limite de -3 cases au niveau des Colonnes, test des combinaisons verticales
            for (int i = 0; i < NbColonnes; i++)
            {
                for (int j = 0; j < NbLignes - 3; j++)
                {
                    int Couleur = Tableau[i, j];

                    if (Couleur != 0)
                    {
                        bool rester = true;
                        int Incr = 1;
                        int PionsAlignes = 1;
                        
                        // 2
                        do
                        {
                            if (j + Incr < Tableau.GetLength(1) && Couleur == Tableau[i, j + Incr])
                            {
                                Incr++;
                                PionsAlignes++;
                            }
                            else
                            {
                                rester = false;
                            }
                        } while (rester);

                        // Test de victoire verticale
                        if (PionsAlignes >= 4)
                        {
                            this.ColonneCaseGagnanteDebut = i;
                            this.LigneCaseGagnanteDebut = j;
                            this.VictoryType = 2;
                            return Couleur;
                        }
                    }

                }
            }

            // Pour chaque cases dans la limite de -3 cases au niveau des lignes, test des combinaisons diagonales
            for (int i = 0; i < NbColonnes; i++)
            {
                for (int j = 0; j < NbLignes - 3; j++)
                {
                    int Couleur = Tableau[i, j];

                    if (Couleur != 0)
                    {
                        bool rester = true;
                        int Incr = 1;
                        int PionsAlignes = 1;

                        // 3
                        do
                        {
                            if (i + Incr < Tableau.GetLength(0) && /* i + Incr >= 0 && */ j + Incr < Tableau.GetLength(1) && /* j + Incr >= 0 && */ Couleur == Tableau[i + Incr, j + Incr])
                            {
                                Incr++;
                                PionsAlignes++;
                            }
                            else
                            {
                                rester = false;
                            }
                        } while (rester);

                        // Test de victoire verticale
                        if (PionsAlignes >= 4)
                        {
                            this.ColonneCaseGagnanteDebut = i;
                            this.LigneCaseGagnanteDebut = j;
                            this.VictoryType = 3;
                            return Couleur;
                        }

                        rester = true;
                        Incr = 1;
                        PionsAlignes = 1;

                        // 4
                        do
                        {
                            if (i - Incr < Tableau.GetLength(0) && i - Incr >= 0 && j + Incr < Tableau.GetLength(1) && j + Incr >= 0 && Couleur == Tableau[i - Incr, j + Incr])
                            {
                                Incr++;
                                PionsAlignes++;
                            }
                            else
                            {
                                rester = false;
                            }
                        } while (rester);

                        // Test de victoire verticale
                        if (PionsAlignes >= 4)
                        {
                            this.ColonneCaseGagnanteDebut = i;
                            this.LigneCaseGagnanteDebut = j;
                            this.VictoryType = 4;
                            return Couleur;
                        }
                    }

                }
            }


            return 0;

        }

        /// <summary>
        /// Permet de placer un jeton
        /// </summary>
        /// <param name="ligne">Ligne a laquelle il faut placer le jeton</param>
        /// <param name="colonne">Colonne a laquelle il faut placer le jeton</param>
        /// <param name="jeton">Numéro du joueur a qui appartient le joueur</param>
        public void Positionner(int ligne, int colonne, int jeton)
        {
            this.Tableau[colonne, ligne] = jeton;
        }

        /// <summary>
        /// Permet de connaitre la case d'une colonne la plus basse disponible
        /// </summary>
        /// <param name="NumColonne">Numéro de la colonne a tester</param>
        /// <returns>Case d'une colonne la plus basse disponible, si la réponse est -1, cela signifie que la colonne est pleine</returns>
        public int GetLigne(int NumColonne) {
            int ResultatPlusUn;
            for (ResultatPlusUn = 0; ResultatPlusUn < NbLignes; ResultatPlusUn++)
            { if (Tableau[NumColonne, ResultatPlusUn] > 0) { break; } }
            return ResultatPlusUn - 1;
        }

        /// <summary>
        /// Permet de modifier les couleurs de la grille
        /// </summary>
        /// <param name="victoryBackColor"></param>
        /// <param name="victoryForeColor"></param>
        /// <param name="player1BackColor"></param>
        /// <param name="player1ForeColor"></param>
        /// <param name="player2BackColor"></param>
        /// <param name="player2ForeColor"></param>
        public void SetSpecialColors(ConsoleColor victoryBackColor, ConsoleColor victoryForeColor, ConsoleColor player1BackColor, ConsoleColor player1ForeColor, ConsoleColor player2BackColor, ConsoleColor player2ForeColor)
        {
            VictoryBackColor = victoryBackColor;
            VictoryForeColor = victoryForeColor;
            Player1BackColor = player1BackColor;
            Player1ForeColor = player1ForeColor;
            Player2BackColor = player2BackColor;
            Player2ForeColor = player2ForeColor;
        }

        /// <summary>
        /// Incrémente le nombre de coups joués dans la grille
        /// </summary>
        public void IncrementNbTours()
        {
            this.NbTour++;
        }

        /// <summary>
        /// Indique si la grille a encore de l'espace vide
        /// </summary>
        /// <returns>True si la tableau a encore de la place</returns>
        public bool YouCanPlay()
        {
            if (NbTour == NbTourMax)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
