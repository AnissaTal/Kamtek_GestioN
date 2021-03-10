using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Designation { get; set; }

        public string Descriptif { get; set; }

        public string Etat { get; set; }

        public string Photo { get; set; }

        public DateTime DateEntree { get; set; }

        public DateTime DateSortie { get; set; }

        public int Quantite { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}
