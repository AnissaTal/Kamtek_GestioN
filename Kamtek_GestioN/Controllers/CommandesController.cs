using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kamtek_GestioN.Data;
using Kamtek_GestioN.Models;
using Microsoft.AspNetCore.Http;

namespace Kamtek_GestioN.Controllers
{
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public string UserSession { get; set; } // Session utilisateur en cours
        public const string CartSessionKey = "UserId"; // pour créer une clé de session de l'utilisateur

        public CommandesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandes
        public async Task<IActionResult> Index()
        {
            //C'est pour afficher toutes les commandes 
            return View(await _context.Commandes.ToListAsync());
        }


        // GET: Commandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //pour les details de chaque commande 
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: Commandes/Create
        public IActionResult Create(int id)
        {
            // Permet à des articles d'être inclus dans le panier d'achat en fonction de l'id récupérer dans l'url

            // Récupérer l'article depuis la base de donnée
            UserSession = GetUserId();

            // Tu récupéres la ligne de commande pour l'utilisateur actuel et l'article par 
            // rapport à l'id que tu récupéres dans l'url
            var ligneCommande = _context.LigneCommandes.SingleOrDefault(
                c => c.UserId == UserSession && c.Article.Id == id
                );

            if (ligneCommande == null)
            {
                // Si la ligne de commande n'existe pas ou est nul
                // Tu crées une nouvelle instance de ligne de commande 
                ligneCommande = new LigneCommande
                {
                    LigneId = Guid.NewGuid().ToString(),
                    UserId = UserSession,
                    Article = _context.Articles.SingleOrDefault(a => a.Id == id),
                    Quantite = 1,
                    DateCreated = DateTime.Now
                };

                _context.LigneCommandes.Add(ligneCommande);
            }
            else
            {
                // Si l'article existe déjà dans le panier
                // Tu ajoutes un à la quantité
                ligneCommande.Quantite++;
            }
            _context.SaveChanges();

            ViewBag.ligneCommande = _context.LigneCommandes.Include(x => x.Article).Where(
                y => y.UserId == UserSession
                ).ToList();

            return View();
        }

        private string GetUserId()
        {
            // Penses à ajouter services.AddSessions() et app.UseSession() dans startup.cs
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(CartSessionKey)))
            {
                // Si la session de l'utilisateur est null ou vide, 
                // Tu crées une session random 
                Guid tempUserId = Guid.NewGuid();
                // Tu injectes ça dans la cartSessionKey
                HttpContext.Session.SetString(CartSessionKey, tempUserId.ToString());
                // tu retournes l'userId
                return HttpContext.Session.GetString(CartSessionKey);
            }
            return HttpContext.Session.GetString(CartSessionKey);
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefContrat,DateCommande")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefContrat,DateCommande")] Commande commande)
        {
            if (id != commande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            _context.Commandes.Remove(commande);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }
    }
}
