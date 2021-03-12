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
using Microsoft.AspNetCore.Authorization;
using Kamtek_GestioN.Helpers;

namespace Kamtek_GestioN.Controllers
{
    [Authorize]
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandes
        public IActionResult Index()
        {
            //Pour afficher la Commande en cours
            var commande = SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande");
            ViewBag.commande = commande;
            return View();
        }

        // Méthodes pour Ajouter un article au panier via une ligne de commande
        // Méthode manuelle
        public IActionResult Ajouter(int id)
        {
            // 1. Via l'url, tu récupéres l'id de l'article passé par le bouton ajouter asp-route-id
            // 2. Tu vas créer une instance d'un objet Article
            // !! Tu dois faire un test si id == null et rediriger ça sur la page index des articles
            Article article = _context.Articles.SingleOrDefault(a => a.Id == id);

            // 3. Si la commande n'existe pas, tu vas créer une commande et ajouter une ligne de commande avec un article
            if (SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande") == null)
            {
                List<LigneCommande> commande = new List<LigneCommande>();
                commande.Add(new LigneCommande { 
                    Article = article,
                    DateCreated = DateTime.Now,
                    Quantite = 1 
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "commande", commande);
            }
            else 
            {
                // Sinon tu récupéres la commande en cours et tu mets à jours la commande
                List<LigneCommande> commande = SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande");
                // 4. Tu vérifies si l'article est déjà en commande
                int index = isExist(id);
                if (index != -1)
                {
                    // 5. Si c'est le cas, tu modifies la quantité de la ligne de commande
                    commande[index].Quantite++;
                }
                else
                {
                    // 6. Sinon tu ajoutes l'articles à la commande
                    commande.Add(new LigneCommande {
                        Article = article,
                        DateCreated = DateTime.Now,
                        Quantite = 1
                    });
                }
                // 7. Tu mets à jour la commande 
                SessionHelper.SetObjectAsJson(HttpContext.Session, "commande", commande);
            }

            return RedirectToAction("Index");
        }

        // Méthode manuelle
        public IActionResult Remove(int id)
        {
            List<LigneCommande> commande = SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande");
            int index = isExist(id);
            if (commande[index].Quantite == 1)
            {
                // Si dans la commande, la quantité de ligneCommande à cet index est == 1
                // Tu supprimes la ligneCommande de la commande en cours
                commande.RemoveAt(index);

            }
            else
            {
                // Sinon tu modifies la quantité
                commande[index].Quantite--;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "commande", commande);
            return RedirectToAction("Index");
        }

        // Méthode manuelle
        private int isExist(int id)
        {
            List<LigneCommande> commande = SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande");
            for (int i = 0; i < commande.Count; i++)
            {
                if (commande[i].Article.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }




        // GET: Commandes/Create
        public IActionResult Create()
        {
            var commande = SessionHelper.GetObjectFromJson<List<LigneCommande>>(HttpContext.Session, "commande");
            ViewBag.commande = commande;
            return View();
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
