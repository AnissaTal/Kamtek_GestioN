using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamtek_GestioN.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public virtual ICollection<Article>Article { get; set; }
    }
}
