using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class LigneCommande
    {
        public int Id { get; set; }

        public int Quantite { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Article Article { get; set; }

       
    }
}
