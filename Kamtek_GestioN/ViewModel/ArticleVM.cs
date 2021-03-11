using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.ViewModel
{
    public class ArticleVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Désignation")]
        public string Designation { get; set; }


        public string Descriptif { get; set; }

        public string Etat { get; set; }

        public string Photo { get; set; }

        [Display(Name = "Date d'entrée")]
        public DateTime DateEntree { get; set; }

        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }

        [Display(Name = "Quantité")]
        public int Quantite { get; set; }

        [Display(Name = "Catégorie")]
        public int IdCategorie { get; set; }
    }


}

