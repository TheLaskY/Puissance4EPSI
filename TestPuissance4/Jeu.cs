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
        
        public virtual void AfficherTitre(bool Animation)
        {
            Console.WriteLine(this.titre);
            Console.Write(Environment.NewLine);
        }
        
    }
}