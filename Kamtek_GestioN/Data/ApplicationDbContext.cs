using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Kamtek_GestioN.Models;

namespace Kamtek_GestioN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kamtek_GestioN.Models.Article> Articles { get; set; }
       
       
        public DbSet<Kamtek_GestioN.Models.Categorie> Categories { get; set; }
       
       
        public DbSet<Kamtek_GestioN.Models.Utilisateur> Utilisateurs { get; set; }
       
       
        public DbSet<Kamtek_GestioN.Models.Commande> Commande { get; set; }
    }
}
