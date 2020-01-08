using System;

namespace TestPuissance4
{



    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextColor.PrintDemo();
                Console.Clear();

                Console.WriteLine("P = Player, IA2 = IA de niveau 2, v = versus");
                Console.WriteLine("Mode de jeu 1 : PvP");
                Console.WriteLine("Mode de jeu 2 : PvIA1");
                Console.WriteLine("Mode de jeu 3 : PvIA2");
                Console.WriteLine("Mode de jeu 4 : PvIA3");
                Console.WriteLine("Mode de jeu 5 : PvIA4");
                Console.WriteLine("Mode de jeu 6 : IA3vIA4");
                Console.WriteLine("Mode de jeu 7 : PvIA-1 (L'IA demandée par Mr.Chevalier)");
                Console.WriteLine("Mode de jeu 8 : IA4vIA-1");
                int input = 0;

                bool rester = true;
                do
                {
                    Console.Write("Veuillez choisir un mode de jeu : ");

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input <= 0 || input > 8)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            rester = false;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Saisie invalide.");
                    }
                } while (rester);

                Joueur joueur1 = new Joueur();
                Joueur joueur2 = new Joueur();

                switch (input)
                {
                    case 1:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurHumain(2, "Player 2 [O]");
                        break;
                    case 2:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurIA(2, "Player 2 (AI1) [O]", 1);
                        break;
                    case 3:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurIA(2, "Player 2 (AI2) [O]", 2);
                        break;
                    case 4:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurIA(2, "Player 2 (AI3) [O]", 3);
                        break;
                    case 5:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurIA(2, "Player 2 (AI4) [O]", 4);
                        break;
                    case 6:
                        joueur1 = new JoueurIA(1, "Player 1 (AI3) [X]", 3);
                        joueur2 = new JoueurIA(2, "Player 2 (AI4) [O]", 4);
                        break;
                    case 7:
                        joueur1 = new JoueurHumain(1, "Player 1 [X]");
                        joueur2 = new JoueurIA(2, "Player 2 (AI-1) [O]", -1);
                        break;
                    case 8:
                        joueur1 = new JoueurIA(1, "Player 1 (AI4) [X]", 4);
                        joueur2 = new JoueurIA(2, "Player 2 (AI-1) [O]", -1);
                        break;
                }

                Puissance4 Jeu = new Puissance4(joueur1, joueur2);
                Jeu.Demarrer();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(Environment.NewLine + $"/!\\ - Erreur fatale ({ex.Data}) : {ex.Message} - /!\\");
                TextColor.PrintWithColor(
                    Environment.NewLine + $"/!\\ - Erreur fatale ({ex.Data}) : {ex.Message} - /!\\", ConsoleColor.Black,
                    ConsoleColor.Red, true);
                Console.ReadKey();
            }

            //Console.ReadKey();
        }
    }
}