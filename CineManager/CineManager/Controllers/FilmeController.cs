﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using CineManager.Models;
using Microsoft.AspNetCore.Authorization;
using CineManager.Areas.Identity.Pages.Account.Manage;
using System.Security.Cryptography.X509Certificates;

namespace CineManager.Controllers
{
    //[Authorize(Policy = "CineManeger")]
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
            return View(await _context.Filme.Include(x => x.Generos).
                Include(x => x.TiposFilme).ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).
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
            List<Genero> listaGeneros = _context.Generos.ToList();
            if(listaGeneros.Count > 0)

                listaGeneros.OrderBy(x => x.Nome);
            ViewBag.ListaGeneros = listaGeneros;
            return View();
        }

        // POST: Filme/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Filme filme)
        {
            if (ModelState.IsValid)
            {
                foreach (var gen in filme.ListaGenerosJoin.Split(','))
                {
                    int generoId = Convert.ToInt32(gen);
                    Genero genero = await _context.Generos.FirstOrDefaultAsync(x=>x.Id == generoId);
                    FilmeGenero filmGen = new FilmeGenero();
                    filmGen.Genero = genero;
                    filme.Generos.Add(filmGen);
                }
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

            var filme = await _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).
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
                    //filmeGenTipo.Genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.Filme.GeneroId);
                    //filmeGenTipo.TipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.Filme.TipoFilmeId);
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

            var filme = await _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).
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
            var filme = await _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).
                FirstOrDefaultAsync(x => x.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult GenerosFilme()
        {
            List<Genero> generos = _context.Generos.ToList();
            this.ViewBag._ListaGeneros = generos.OrderBy(x => x.Nome);

            return PartialView("../Shared/GenerosResult");
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
                obj2.Nome = "Animação";
                _context.Generos.Add(obj2);

                Genero obj3 = new Genero();
                obj3.Nome = "Aventura";
                _context.Generos.Add(obj3);

                Genero obj4 = new Genero();
                obj4.Nome = "Cinema de arte";
                _context.Generos.Add(obj4);

                Genero obj5 = new Genero();
                obj5.Nome = "Chanchada";
                _context.Generos.Add(obj5);

                Genero obj6 = new Genero();
                obj6.Nome = "Comédia";
                _context.Generos.Add(obj6);
                Genero obj7 = new Genero();
                obj7.Nome = "Comédia romântica";
                _context.Generos.Add(obj7);

                Genero obj8 = new Genero();
                obj8.Nome = "Comédia dramática";
                _context.Generos.Add(obj8);

                Genero obj9 = new Genero();
                obj9.Nome = "Comédia de ação";
                _context.Generos.Add(obj9);
                Genero obj10 = new Genero();
                obj10.Nome = "Dança";
                _context.Generos.Add(obj10);

                Genero obj11 = new Genero();
                obj11.Nome = "Documentário";
                _context.Generos.Add(obj11);

                Genero obj12 = new Genero();
                obj12.Nome = "Docuficção";
                _context.Generos.Add(obj12);
                Genero obj13 = new Genero();
                obj13.Nome = "Drama";
                _context.Generos.Add(obj13);

                Genero obj14 = new Genero();
                obj14.Nome = "Espionagem";
                _context.Generos.Add(obj14);

                Genero obj15 = new Genero();
                obj15.Nome = "Faroeste";
                _context.Generos.Add(obj15);
                Genero obj16 = new Genero();
                obj16.Nome = "Fantasia científica";
                _context.Generos.Add(obj16);

                Genero obj17 = new Genero();
                obj17.Nome = "Ficção científica";
                _context.Generos.Add(obj17);

                Genero obj18 = new Genero();
                obj18.Nome = "Filmes de guerra";
                _context.Generos.Add(obj18);

                Genero obj19 = new Genero();
                obj19.Nome = "Musical";
                _context.Generos.Add(obj19);

                Genero obj20 = new Genero();
                obj20.Nome = "Filme policial";
                _context.Generos.Add(obj20);

                Genero obj21 = new Genero();
                obj21.Nome = "Romance";
                _context.Generos.Add(obj21);

                Genero obj22 = new Genero();
                obj22.Nome = "Seriado";
                _context.Generos.Add(obj22);

                Genero obj23 = new Genero();
                obj23.Nome = "Suspense";
                _context.Generos.Add(obj23);

                Genero obj24 = new Genero();
                obj24.Nome = "Terror";
                _context.Generos.Add(obj24);
                Genero obj25 = new Genero();
                obj25.Nome = "Pornográfico";
                _context.Generos.Add(obj25);


                TipoFilme objfilme1 = new TipoFilme();
                objfilme1.NomeTipoFilme = "2D";
                _context.TipoFilmes.Add(objfilme1);

                TipoFilme objfilme2 = new TipoFilme();
                objfilme2.NomeTipoFilme = "3D";
                _context.TipoFilmes.Add(objfilme2);

                TipoFilme objfilme3 = new TipoFilme();
                objfilme3.NomeTipoFilme = "4D";
                _context.TipoFilmes.Add(objfilme3);

                TipoSala objtiposala1 = new TipoSala();
                objtiposala1.Tipo = "2D";
                _context.TipoSala.Add(objtiposala1);

                TipoSala objtiposala2 = new TipoSala();
                objtiposala2.Tipo = "3D";
                _context.TipoSala.Add(objtiposala2);

                TipoSala objtiposala3 = new TipoSala();
                objtiposala3.Tipo = "4D";
                _context.TipoSala.Add(objtiposala3);
                _context.SaveChanges();
            }
        }
    }
}