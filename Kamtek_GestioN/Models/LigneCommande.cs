using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class LigneCommande
    {
        [Key]
        public string LigneId { get; set; }

        public string UserId { get; set; }

        public int Quantite { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Article Article { get; set; }

       
    }
}
