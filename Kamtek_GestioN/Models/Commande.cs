using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Numéro du contrat")]
        public int RefContrat { get; set; }

        [Display(Name = "Date du commande")]
        [Required(ErrorMessage = "ce champs est obligatoire")]
        public DateTime DateCommande { get; set; }

        public virtual ICollection<LigneCommande> LigneCommande { get; set; }

        

    }
}
