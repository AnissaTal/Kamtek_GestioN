using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class Commande
    {
        public int Id { get; set; }

        public int RefContrat { get; set; }

        public DateTime DateCommande { get; set; }

        public virtual ICollection<LigneCommande> LigneCommande { get; set; }


    }
}
