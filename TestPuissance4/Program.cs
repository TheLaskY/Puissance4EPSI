using System;


	public static class TestPuissance4
{

	public static void affiche_grille()
	{
		/*
		 * Affiche la grille pour le ou les joueurs.
		 */

		int col;
		int lgn;

		Console.Write('\n');

		for (col = 1; col <= DefineConstants.P4_COLONNES; ++col)
		{
			Console.Write("  {0:D} ", col);
		}

		Console.Write('\n');
		Console.Write('+');

		for (col = 1; col <= DefineConstants.P4_COLONNES; ++col)
		{
			Console.Write("---+");
		}

		Console.Write('\n');

		for (lgn = 0; lgn < DefineConstants.P4_LIGNES; ++lgn)
		{
			Console.Write('|');

			for (col = 0; col < DefineConstants.P4_COLONNES; ++col)
			{
				if (char.IsLetter((char) grille[col, lgn]))
				{
					Console.Write(" {0} |", grille[col, lgn]);
				}
				else
				{
					Console.Write(" {0} |", ' ');
				}
			}

			Console.Write('\n');
			Console.Write('+');

			for (col = 1; col <= DefineConstants.P4_COLONNES; ++col)
			{
				Console.Write("---+");
			}

			Console.Write('\n');
		}

		for (col = 1; col <= DefineConstants.P4_COLONNES; ++col)
		{
			Console.Write("  {0:D} ", col);
		}

		Console.Write('\n');
	}
	public static void calcule_position(int coup, position pos)
	{
		/*
		 * Traduit le coup joué en un numéro de colonne et de ligne.
		 */

		int lgn;

		pos.colonne = coup;

		for (lgn = DefineConstants.P4_LIGNES - 1; lgn >= 0; --lgn)
		{
			if (grille[pos.colonne, lgn] == ' ')
			{
				pos.ligne = lgn;
				break;
			}
		}
	}
	public static uint calcule_nb_jetons_depuis_vers(position pos, int dpl_hrz, int dpl_vrt, int jeton)
	{
		/*
		 * Calcule le nombre de jetons adajcents identiques depuis une position donnée en se
		 * déplaçant de `dpl_hrz` horizontalement et `dpl_vrt` verticalement.
		 * La fonction s'arrête si un jeton différent ou une case vide est rencontrée ou si
		 * les limites de la grille sont atteintes.
		 */

		position tmp = new position();
		uint nb = 1;

		tmp.colonne = pos.colonne + dpl_hrz;
		tmp.ligne = pos.ligne + dpl_vrt;

		while (TestPuissance4.position_valide(tmp) != 0)
		{
			if (grille[tmp.colonne, tmp.ligne] == jeton)
			{
				++nb;
			}
			else
				break;

			tmp.colonne += dpl_hrz;
			tmp.ligne += dpl_vrt;
		}

		return nb;
	}
	public static uint calcule_nb_jetons_depuis(position pos, int jeton)
	{
		/*
		 * Calcule le nombre de jetons adjacents en vérifant la colonne courante,
		 * de la ligne courante et des deux obliques courantes.
		 * Pour ce faire, la fonction calcule_nb_jeton_depuis_vers() est appelé à
		 * plusieurs reprises afin de parcourir la grille suivant la vérification
		 * à effectuer.
		 */

		uint max;

		max = TestPuissance4.calcule_nb_jetons_depuis_vers(pos, 0, 1, jeton);
		max = TestPuissance4.umax(max, TestPuissance4.calcule_nb_jetons_depuis_vers(pos, 1, 0, jeton) + TestPuissance4.calcule_nb_jetons_depuis_vers(pos, -1, 0, jeton) - 1);
		max = TestPuissance4.umax(max, TestPuissance4.calcule_nb_jetons_depuis_vers(pos, 1, 1, jeton) + TestPuissance4.calcule_nb_jetons_depuis_vers(pos, -1, -1, jeton) - 1);
		max = TestPuissance4.umax(max, TestPuissance4.calcule_nb_jetons_depuis_vers(pos, 1, -1, jeton) + TestPuissance4.calcule_nb_jetons_depuis_vers(pos, -1, 1, jeton) - 1);

		return max;
	}
	public static int coup_valide(int col)
	{
		/*
		 * Si la colonne renseignée est inférieure ou égal à zéro
		 * ou que celle-ci est supérieure à la longueur du tableau
		 * ou que la colonne indiquée est saturée
		 * alors le coup est invalide.
		 */

		if (col <= 0 || col > DefineConstants.P4_COLONNES || grille[col - 1, 0] != ' ')
		{
			return 0;
		}

		return 1;
	}

	public static int demande_action(ref int coup)
	{
		/*
		 * Demande l'action à effectuer au joueur courant.
		 * S'il entre un chiffre, c'est qu'il souhaite jouer.
		 * S'il entre la lettre « Q » ou « q », c'est qu'il souhaite quitter.
		 * S'il entre autre chose, une nouvelle saisie sera demandée.
		 */

		string c;
		int ret = DefineConstants.ACT_ERR;
		if (coup != 1)
		{
			c=Console.ReadLine();
			if (c != "1")
			{
				Console.WriteLine( "Erreur lors de la saisie\n");
				return ret;
			}
			if (c == "2")
			{
				Console.WriteLine("Debugg");
			}

			switch (c)
			{
				case "Q":
				case "q":
					ret = DefineConstants.ACT_QUITTER;
					break;
				default:
					ret = DefineConstants.ACT_NOUVELLE_SAISIE;
					break;
			}
		}
		else
		{
			ret = DefineConstants.ACT_JOUER;
		}

		return ret;
	}

	public static int grille_complete()
	{
		/*
		 * Détermine si la grille de jeu est complète.
		 */

		int col;
		int lgn;

		for (col = 0; col < DefineConstants.P4_COLONNES; ++col)
		{
			for (lgn = 0; lgn < DefineConstants.P4_LIGNES; ++lgn)
			{
				if (grille[col, lgn] == ' ')
				{
					return 0;
				}
			}
		}

		return 1;
	}
	public static void initialise_grille()
	{
		/*
		 * Initalise les caractères de la grille.
		 */

		int col;
		int lgn;

		for (col = 0; col < DefineConstants.P4_COLONNES; ++col)
		{
			for (lgn = 0; lgn < DefineConstants.P4_LIGNES; ++lgn)
			{
				grille[col, lgn] = (char)' ';
			}
		}
	}
	public static int position_valide(position pos)
	{
		/*
		 * Vérifie que la position fournie est bien comprise dans la grille.
		 */

		int ret = 1;

		if (pos.colonne >= DefineConstants.P4_COLONNES || pos.colonne < 0)
		{
			ret = 0;
		}
		else if (pos.ligne >= DefineConstants.P4_LIGNES || pos.ligne < 0)
		{
			ret = 0;
		}

		return ret;
	}
	public static int statut_jeu(position pos, int jeton)
	{
		/*
		 * Détermine s'il y a lieu de continuer le jeu ou s'il doit être
		 * arrêté parce qu'un joueur a gagné ou que la grille est complète.
		 */

		if (TestPuissance4.grille_complete() != 0)
		{
			return DefineConstants.STATUT_EGALITE;
		}
		else if (TestPuissance4.calcule_nb_jetons_depuis(pos, jeton) >= 4)
		{
			return DefineConstants.STATUT_GAGNE;
		}

		return DefineConstants.STATUT_OK;
	}
	public static uint umax(uint a, uint b)
	{
		/*
		 * Retourne le plus grand des deux arguments.
		 */

		return (a > b) ? a : b;
	}

	public static int[,] grille = new int[DefineConstants.P4_COLONNES, DefineConstants.P4_LIGNES];


	static int Main()
	{
		int statut;
		int jeton = DefineConstants.J1_JETON;

		TestPuissance4.initialise_grille();
		TestPuissance4.affiche_grille();

		while (true)
		{
			position pos = new position();
			int action = 0;
			int coup = 0;

			Console.Write("Joueur {0:D} : ", (jeton == DefineConstants.J1_JETON) ? 1 : 2);

			action = demande_action(ref action);

			if (action == DefineConstants.ACT_ERR)
			{
				return 1;
			}
			else if (action == DefineConstants.ACT_QUITTER)
			{
				return 0;
			}
			else if (action == DefineConstants.ACT_NOUVELLE_SAISIE || TestPuissance4.coup_valide(coup) == 0)
			{
				Console.WriteLine("Vous ne pouvez pas jouer à cet endroit\n");
				continue;
			}

			TestPuissance4.calcule_position(coup - 1, pos);
			grille[pos.colonne, pos.ligne] = jeton;
			TestPuissance4.affiche_grille();
			statut = TestPuissance4.statut_jeu(pos, jeton);

			if (statut != DefineConstants.STATUT_OK)
				break;

			jeton = (jeton == DefineConstants.J1_JETON) ? DefineConstants.J2_JETON : DefineConstants.J1_JETON;
		}

		if (statut == DefineConstants.STATUT_GAGNE)
		{
			Console.Write("Le joueur {0:D} a gagné\n", (jeton == DefineConstants.J1_JETON) ? 1 : 2);
		}
		else if (statut == DefineConstants.STATUT_EGALITE)
		{
			Console.Write("Égalité\n");
		}

		return 0;
	}
}

public class position
{
	public int colonne;
	public int ligne;
}

public static partial class DefineConstants
{
	public const int P4_COLONNES = 7;
	public const int P4_LIGNES = 6;
	public const char J1_JETON = 'O';
	public const char J2_JETON = 'X';
	public const int ACT_ERR = 0;
	public const int ACT_JOUER = 1;
	public const int ACT_NOUVELLE_SAISIE = 2;
	public const int ACT_QUITTER = 3;
	public const int STATUT_OK = 0;
	public const int STATUT_GAGNE = 1;
	public const int STATUT_EGALITE = 2;
}
