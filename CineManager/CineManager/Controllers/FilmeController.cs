using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using CineManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace CineManager.Controllers {
    [Authorize(Policy = "CineManeger")]
    public class FilmeController : Controller {
        private readonly ApplicationDbContext _context;

        public FilmeController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Filme
        public async Task<IActionResult> Index() {
            InserirDados();
            return View(await _context.Filme.Include(x => x.ListaGeneros).Include(x => x.ListaTipoFilmes).ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.ListaGeneros).ThenInclude(x => x.Genero).Include(x => x.ListaTipoFilmes).
                    FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null) {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filme/Create
        public IActionResult Create() {
            ViewBag.ListaTipoFilmes = _context.TipoFilme.ToList();
            ViewBag.ListaGeneros = _context.Genero.ToList();
            return View();
        }

        // POST: Filme/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Filme filme) {
            if (ModelState.IsValid) {

                foreach(int idGen in filme.idGeneros) {
                    Genero gen = _context.Genero.FirstOrDefault(x => x.Id == idGen);
                    filme.ListaGeneros.Add(new FilmeGenero() { Genero = gen });
                }

                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filme/Edit/5
        public IActionResult Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var filme = _context.Filme.Include(x => x.ListaGeneros).ThenInclude(gen => gen.Genero).Include(x => x.ListaTipoFilmes).
                    FirstOrDefault(x => x.Id == id);

            List<int> genPreenchidos = new List<int>();
            foreach(FilmeGenero gen in filme.ListaGeneros) {
                genPreenchidos.Add(gen.Genero.Id);
            }

            List<int> genExcluir = new List<int>();
            foreach (FilmeGenero gen in filme.ListaGeneros) {
                genExcluir.Add(gen.Id);
            }


            ViewBag.generosSelecionados = genPreenchidos;
            filme.filmeGenExcluir = String.Join(',', genExcluir);
            if (filme == null) {
                return NotFound();
            }
            ViewBag.ListaTipoFilmes = _context.TipoFilme.ToList();
            ViewBag.ListaGeneros = _context.Genero.ToList();
            return View(filme);
        }

        // POST: Filme/Edit/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Filme filme) {
            if (id != filme.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    foreach (string filmeGenString in filme.filmeGenExcluir.Split(',')) {
                        var filmeGenInt = Convert.ToInt32(filmeGenString);
                        var filmeGen = _context.FilmeGenero.Include(x => x.Genero).FirstOrDefault(x => x.Id == filmeGenInt);
                        _context.Remove(filmeGen);
                    }
                    foreach(int idGen in filme.idGeneros) {
                        var gen = _context.Genero.FirstOrDefault(x => x.Id == idGen);
                        filme.ListaGeneros.Add(new FilmeGenero() { Genero = gen});
                    }
                    _context.Update(filme);
                    _context.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    if (!FilmeExists(filme.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filme/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.ListaTipoFilmes).Include(x => x.ListaGeneros).
                   FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null) {
                return NotFound();
            }

            foreach(var gen in filme.ListaGeneros) {
                _context.Remove(gen);
            }

            foreach(var tipo in filme.ListaTipoFilmes) {
                _context.Remove(tipo);
            }

            _context.Remove(filme);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id) {
            return _context.Filme.Any(e => e.Id == id);
        }

        public void InserirDados() {
            Genero genero = _context.Genero.FirstOrDefault(x => x.Nome.Equals("Ação"));
            if (genero == null) {
                Genero obj1 = new Genero();
                obj1.Nome = "Ação";
                _context.Genero.Add(obj1);

                Genero obj2 = new Genero();
                obj2.Nome = "Comédia";
                _context.Genero.Add(obj2);

                Genero obj3 = new Genero();
                obj3.Nome = "Romance";
                _context.Genero.Add(obj3);

                _context.Genero.Add(new Genero() {
                    Nome = "Comédia romantica"
                });
                _context.Genero.Add(new Genero() {
                    Nome = "Comédia com terror"
                });
                _context.Genero.Add(new Genero() {
                    Nome = "Terror"
                });
                _context.Genero.Add(new Genero() {
                    Nome = "PORN"
                });
                _context.Genero.Add(new Genero() {
                    Nome = "Aventura"
                });
                _context.Genero.Add(new Genero() {
                    Nome = "Historia"
                });



                TipoFilme obj4 = new TipoFilme();
                obj4.NomeTipoFilme = "2D";
                _context.TipoFilme.Add(obj4);

                TipoFilme obj5 = new TipoFilme();
                obj5.NomeTipoFilme = "3D";
                _context.TipoFilme.Add(obj5);

                TipoFilme obj6 = new TipoFilme();
                obj6.NomeTipoFilme = "4D";
                _context.TipoFilme.Add(obj6);

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
