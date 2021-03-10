using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }

        public DateTime DateEntree { get; set; }

        public virtual ICollection<Article> Article { get; set; }

        public virtual ICollection<Commande> Commande { get; set; }
    }
}
