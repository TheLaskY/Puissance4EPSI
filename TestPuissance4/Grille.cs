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

        public int[,] Tableau { get => _tableau; set => _tableau = value; } // Tableau[Colonnes, Lignes]
        public int NbLignes { get => _nbLignes; set => _nbLignes = value; }
        public int NbColonnes { get => _nbColonnes; set => _nbColonnes = value; }
        public int LigneCaseGagnanteDebut { get => _ligneCaseGagnanteDebut; set => _ligneCaseGagnanteDebut = value; }
        public int ColonneCaseGagnanteDebut { get => _colonneCaseGagnanteDebut; set => _colonneCaseGagnanteDebut = value; }
        public int VictoryType { get => _victoryType; set => _victoryType = value; }
        public int NbTour { get => _nbTour; set => _nbTour = value; }
        public int NbTourMax { get => _nbTourMax; set => _nbTourMax = value; }

        
        /// Constructeur vide
        public Grille()
        {

        }

        
        /// Constructeur semi
        public Grille(int NbLignes, int NbColonnes)
        {
            this._nbColonnes = NbColonnes;
            this._nbLignes = NbLignes;
            this._tableau = new int[_nbColonnes, this.NbLignes];
            this.NbTourMax = NbLignes * NbColonnes;
            this.init();
        }

        
        /// Permet de cloner la grille
        public Grille(Grille other)
        {
            //Grille other = (Grille)this.MemberwiseClone();
            //Grille other = new Grille(this.NbLignes, this.NbColonnes);

            //other.Course_ID = new Course(Course_ID.Course_Id);
            //other.Name = String.Copy(Name);
            
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

        
        /// Permet de vider la grille de ses valeures
        public void init() {
            for (int i = 0; i < this.NbColonnes; i++)
            {
                for (int j = 0; j < NbLignes; j++)
                {
                    Tableau[i, j] = 0;
                }
            }
        }

        
        /// Permet d'affciher le tableau
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
                Console.Write("      |");
                for (int j = 0; j < NbColonnes; j++)
                {

                    
                
                    if (Tableau[j, i] == 1)
                    {
                        
                        Console.Write(" X ");
                    }
                    else if (Tableau[j, i] == 2)
                    {
                        
                        Console.Write(" O ");
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
        
        public int TesterGagner()
        {

            


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
        
        public void Positionner(int ligne, int colonne, int jeton)
        {
            this.Tableau[colonne, ligne] = jeton;
        }
        
        /// Permet de connaitre la case d'une colonne la plus basse disponible
        /// Numéro de la colonne a tester
        ///Case d'une colonne la plus basse disponible, si la réponse est -1, cela signifie que la colonne est pleine
        public int GetLigne(int NumColonne) {
            int ResultatPlusUn;
            for (ResultatPlusUn = 0; ResultatPlusUn < NbLignes; ResultatPlusUn++)
            { if (Tableau[NumColonne, ResultatPlusUn] > 0) { break; } }
            return ResultatPlusUn - 1;
        }

        
        
        /// Incrémente le nombre de coups joués dans la grille
        public void IncrementNbTours()
        {
            this.NbTour++;
        }

        
        /// Indique si la grille a encore de l'espace vide
        /// True si la tableau a encore de la place
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
