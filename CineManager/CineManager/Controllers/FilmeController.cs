using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using CineManager.Models;

namespace CineManager.Controllers
{
    public class FilmeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filme
        public async Task<IActionResult> Index()
        {
            InserirDados();
            return View(await _context.Filme.Include(x => x.ListaGenero).Include(x => x.ListaTipoFilme).ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.ListaGenero).Include(x => x.ListaTipoFilme).
                    FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filme/Create
        public IActionResult Create()
        {
            ViewBag.ListaTipoFilmes = _context.TipoFilmes.ToList();
            ViewBag.ListaGeneros = _context.Generos.ToList();
            return View();
        }

        // POST: Filme/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Filme filme)
        {
            if (ModelState.IsValid)
            {
                Genero genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == filme.GeneroId);
                TipoFilme tipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == filme.TipoFilmeId);

                filme.ListaGenero.Add(genero);
                filme.ListaTipoFilme.Add(tipoFilme);
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.ListaGenero).Include(x => x.ListaTipoFilme).
                    FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            ViewBag.ListaTipoFilmes = await _context.TipoFilmes.ToListAsync();
            ViewBag.ListaGeneros = await _context.Generos.ToListAsync();
            return View(filme);
        }

        // POST: Filme/Edit/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Genero genero = await _context.Generos.FirstOrDefaultAsync(x=>x.Id == filme.ListaGenero[0].Id);
                    TipoFilme tipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == filme.ListaTipoFilme[0].Id);
                    filme.ListaGenero[0].Nome = genero.Nome;
                    filme.ListaTipoFilme[0].NomeTipoFilme = tipoFilme.NomeTipoFilme;
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
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
            return View(filme);
        }

        // GET: Filme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.ListaGenero).Include(x => x.ListaTipoFilme).
                   FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.Include(x => x.ListaGenero).Include(x => x.ListaTipoFilme).
                FirstOrDefaultAsync(x => x.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }

        public void InserirDados()
        {
            Genero genero = _context.Generos.FirstOrDefault(x => x.Nome.Equals("Ação"));
            if (genero == null)
            {
                Genero obj1 = new Genero();
                obj1.Nome = "Ação";
                _context.Generos.Add(obj1);

                Genero obj2 = new Genero();
                obj2.Nome = "Comédia";
                _context.Generos.Add(obj2);

                Genero obj3 = new Genero();
                obj3.Nome = "Romance";
                _context.Generos.Add(obj3);

                TipoFilme obj4 = new TipoFilme();
                obj4.NomeTipoFilme = "2D";
                _context.TipoFilmes.Add(obj4);

                TipoFilme obj5 = new TipoFilme();
                obj5.NomeTipoFilme = "3D";
                _context.TipoFilmes.Add(obj5);

                TipoFilme obj6 = new TipoFilme();
                obj6.NomeTipoFilme = "4D";
                _context.TipoFilmes.Add(obj6);

                TipoSala obj7 = new TipoSala();
                obj7.Tipo = "2D";
                _context.TipoSala.Add(obj7);

                TipoSala obj8 = new TipoSala();
                obj8.Tipo = "3D";
                _context.TipoSala.Add(obj8);

                TipoSala obj9 = new TipoSala();
                obj9.Tipo = "4D";
                _context.TipoSala.Add(obj9);
                _context.SaveChanges();
            }
        }
    }

}
