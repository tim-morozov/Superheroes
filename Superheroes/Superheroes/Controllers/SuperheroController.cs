using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        public readonly ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public IActionResult Index()
        {
            List<Superhero> superheroes = _context.Superheroes.Select(s => s).ToList();
            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public IActionResult Details(int id)
        {
            var super = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(super);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero super = new Superhero();
            return View(super);
        }

        // POST: Superhero/Create
        [HttpPost]
        
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var super = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(super);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}