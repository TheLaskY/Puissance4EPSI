using System;

namespace TestPuissance4
{
    public class Puissance4 : Jeu
    {
        private Joueur _joueur1;
        private Joueur _joueur2;

        public Puissance4(Joueur joueur1, Joueur joueur2)
        {
            this.nom = "Puissance 4";
            this.titre = "-------------------------------------------" + "\n" + " P U I S S A N C E   IV : T H E   G A M E" + "\n" + "-------------------------------------------";
            this.Joueur1 = joueur1;
            this.Joueur2 = joueur2;
        }

        // Accesseurs
        public string Nom { get => this.nom;/* set => this.nom = value;*/ }
        public Joueur Joueur1 { get => _joueur1; set => _joueur1 = value; }
        public Joueur Joueur2 { get => _joueur2; set => _joueur2 = value; }

        /// <summary>
        /// Permet de démarrer le jeu
        /// </summary>
        public void Demarrer()
        {
            this.AfficherTitre(true);
            bool Rejouer = false;
            bool FinParVictoire = true;
            do
            {
                Grille plateau = new Grille(6, 7);
                //Grille plateau = new Grille(4, 9);

                //plateau.Positionner(5, 0, 2);
                //plateau.Positionner(4, 3, 1);
                //plateau.Positionner(3, 3, 2);
                //plateau.Positionner(2, 3, 1);
                //plateau.Positionner(1, 3, 2);
                //plateau.Positionner(0, 3, 1);
                //plateau.NbTour = 6;

                Console.Clear();
                this.AfficherTitre(false);
                Console.WriteLine($"{this.Joueur1.NomJoueur} : {this.Joueur1.Score}, {this.Joueur2.NomJoueur} : {this.Joueur2.Score}\n");

                //JoueurHumain joueur1 = new JoueurHumain(1, "Player 1");
                //JoueurIA joueur2 = new JoueurIA(2, "Player 2 (AI)", 4);
                //JoueurIA joueur1 = new JoueurIA(1, "Player 1 (AI)", 4);

                int gagnant = 0;
                bool victoire = false;

                // On tire au hasard le joueur qui commence :
                Random randomSeed = new Random();
                bool TourDuJoueur1 = Convert.ToBoolean(randomSeed.Next(0, 2));
                
                do
                {
                    if (plateau.YouCanPlay())
                    {
                        Console.Clear();
                        this.AfficherTitre(false);
                        Console.WriteLine($"{this.Joueur1.NomJoueur} : {this.Joueur1.Score}, {this.Joueur2.NomJoueur} : {this.Joueur2.Score}\n");
                        plateau.Afficher();
                        //Console.Write(Environment.NewLine);
                        if (TourDuJoueur1)
                        {
                            Joueur1.Jouer(plateau, this);
                            TourDuJoueur1 = false;
                        }
                        else
                        {
                            Joueur2.Jouer(plateau, this);
                            TourDuJoueur1 = true;
                        }
                        plateau.IncrementNbTours();

                        gagnant = plateau.TesterGagner();
                        if (gagnant > 0)
                        {
                            victoire = true;
                        }
                    }
                    else
                    {
                        victoire = true;
                        FinParVictoire = false;
                    }
                } while (!victoire);
                Console.Clear();
                //this.AfficherTitre(false);

                string resultat;

                if (FinParVictoire)
                {
                    var victoryType = plateau.VictoryType;

                    // Boucle d'animation (3 est ici le nombre de clognotement)
                    for (int i = 0; i < 3; i++)
                    {
                        plateau.VictoryType = -1;
                        Console.Clear();
                        this.AfficherTitre(false);
                        Console.WriteLine($"{this.Joueur1.NomJoueur} : {this.Joueur1.Score}, {this.Joueur2.NomJoueur} : {this.Joueur2.Score}\n");
                        plateau.Afficher();
                        System.Threading.Thread.Sleep(10);
                        plateau.VictoryType = victoryType;
                        Console.Clear();
                        this.AfficherTitre(false);
                        Console.WriteLine($"{this.Joueur1.NomJoueur} : {this.Joueur1.Score}, {this.Joueur2.NomJoueur} : {this.Joueur2.Score}\n");
                        plateau.Afficher();
                        Console.Beep();
                        System.Threading.Thread.Sleep(10);
                    }

                    resultat = " |  ";
                    switch (gagnant)
                    {
                        case 1:
                            resultat += "Victoire";
                            this.Joueur1.Score++;
                            break;
                        case 2:
                            resultat += "Defaite";
                            this.Joueur2.Score++;
                            break;
                        default:
                            resultat += "Victoire d'un joueur non-déclaré"; break;
                    }
                    switch (plateau.VictoryType)
                    {
                        case 1:
                            resultat += $" en ({plateau.ColonneCaseGagnanteDebut + 1},{plateau.LigneCaseGagnanteDebut + 1}) de type {plateau.VictoryType} (Horizontal)"; break;
                        case 2:
                            resultat += $" en ({plateau.ColonneCaseGagnanteDebut + 1},{plateau.LigneCaseGagnanteDebut + 1}) de type {plateau.VictoryType} (Vertical)"; break;
                        case 3:
                            resultat += $" en ({plateau.ColonneCaseGagnanteDebut + 1},{plateau.LigneCaseGagnanteDebut + 1}) de type {plateau.VictoryType} (Diagonal de haut-gauche a bas-droite)"; break;
                        case 4:
                            resultat += $" en ({plateau.ColonneCaseGagnanteDebut + 1},{plateau.LigneCaseGagnanteDebut + 1}) de type {plateau.VictoryType} (Diagonal de haut-droite a bas-gauche)"; break;
                        default: break;
                    }
                    resultat += "  |";
                }
                else
                {
                    this.AfficherTitre(false);
                    Console.WriteLine($"{this.Joueur1.NomJoueur} : {this.Joueur1.Score}, {this.Joueur2.NomJoueur} : {this.Joueur2.Score}\n");
                    plateau.Afficher();
                    resultat = " |  Egalite  |";
                }

                

                

                // Affichage du resultat de la partie
                Console.Write(Environment.NewLine);

                string ligne = " ";
                for (int i = 0; i < resultat.Length - 1; i++)
                {
                    ligne += "-";
                }

                Console.WriteLine(ligne);
                Console.WriteLine(resultat);
                Console.WriteLine(ligne);
                //Console.ReadKey();


                // --- ZONE REJOUER ---
                //Console.Clear();
                //this.AfficherTitre(false);
                Console.Write(Environment.NewLine);
                Console.Write("Voulez vous rejouer ? (y/n)");

                bool InputIsValid = false;
                string Input = string.Empty;
                while (!InputIsValid)
                {
                    if (this.Joueur1 is JoueurHumain || this.Joueur2 is JoueurHumain)
                    {
                        Input = Console.ReadLine();
                    }
                    else
                    {
                        Input = "y";
                    }
                    switch (Input)
                    {
                        case "y":
                        case "Y":
                            Rejouer = true;
                            InputIsValid = true;
                            break;
                        case "n":
                        case "N":
                            Rejouer = false;
                            InputIsValid = true;
                            break;
                        default:
                            Console.Write("Erreur, veuillez rentrer \"y\" ou \"n\" : ");
                            break;
                    }
                }

                plateau.init();

            } while (Rejouer);
        }

        public override void AfficherTitre(bool Animation)
        {
            if (Animation)
            {
                string ligne = "------------------------------------------";
                string ligneFifty = string.Empty;
                //bool On = true;
                for (int i = 0; i < ligne.Length/4; i++)
                {
                    ligneFifty += "----";
                    Console.WriteLine(ligneFifty);
                    //if (On)
                    //{
                    //    Console.WriteLine(" P U I S S A N C E   IV : T H E   G A M E ");
                    //    On = false;
                    //}
                    //else
                    //{
                    //    Console.WriteLine(" P U I S S A N C E   IV :");
                    //    On = true;
                    //}
                    Console.Write(" P U I S S A N C E   IV : T H E   ");
                    if (i >= ligne.Length / (4 * 5))
                    {
                        Console.Write("G ");
                    }
                    if (i >= (ligne.Length * 2) / (4 * 5))
                    {
                        Console.Write("A ");
                    }
                    if (i >= (ligne.Length * 3) / (4 * 5))
                    {
                        Console.Write("M ");
                    }
                    if (i >= (ligne.Length * 2) / (4 * 5))
                    {
                        Console.Write("E ");
                    }
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(ligneFifty);
                    //Console.WriteLine($"({i})");
                    System.Threading.Thread.Sleep(20);
                    Console.Clear();
                }
                base.AfficherTitre(Animation);
                //System.Threading.Thread.Sleep(500);
            }
            else
            {
                base.AfficherTitre(Animation);
            }
        }
    }
}
