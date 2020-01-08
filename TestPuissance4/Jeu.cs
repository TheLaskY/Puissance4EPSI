using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPuissance4
{
    public class Jeu
    {
        protected string nom;
        protected string titre;

        /// <summary>
        /// Permet d'afficher le titre
        /// </summary>
        /// <param name="Animation">Permet de déclencher ou non l'animation du titre</param>
        public virtual void AfficherTitre(bool Animation)
        {
            Console.WriteLine(this.titre);
            Console.Write(Environment.NewLine);
        }

        //protected string Nom { get => nom; set => nom = value; }
    }
}