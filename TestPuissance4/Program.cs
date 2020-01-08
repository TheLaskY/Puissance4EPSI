using System;

namespace TestPuissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                
                Console.WriteLine("Mode de jeu 1 : PvP");
                Console.WriteLine("Mode de jeu 2 : PvIA");
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
                        joueur2 = new JoueurIA(2, "Player 2 (AI-1) [O]", -1);
                        break;
                }

                Puissance4 Jeu = new Puissance4(joueur1, joueur2);
                Jeu.Demarrer();

            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine + $"/!\\ - Erreur fatale ({ex.Data}) : {ex.Message} - /!\\");
            }
        }
    }
}