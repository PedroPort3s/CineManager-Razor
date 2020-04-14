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
    public class SessaoController : Controller
    {
        //Injeção de dependencia do banco de dados
        private readonly ApplicationDbContext _context;

        public SessaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessao.Any(e => e.Id == id);
        }

        // GET: Sessao
        //Método de ação que retorna a View Index da pasta Sessão
        public async Task<IActionResult> Index()
        {
            //Envia a lista de sessões para a view Index
            return View(await _context.Sessao.Include(x => x.Filme).Include(x => x.Sala).ToListAsync());
        }

        // GET: Sessao/Details/5
        //Método de ação que retorna a view Details da pasta Sessão 
        public async Task<IActionResult> Details(int? id)
        {
            // Confere se o Id é nulo
            if (id == null)
            {
                return NotFound();
            }
            // Faz uma busca no banco de dados a partir do Id que recebeu como parâmetro
            var sessao = await _context.Sessao.Include(x =>x.Filme).Include(x=>x.Sala).Include(x=>x.Filme.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            // Confere se a sessão é nula
            if (sessao == null)
            {
                return NotFound();
            }

            // Envia para a view Details a sessão encontrada no banco de dados
            return View(sessao);
        }

        // GET: Sessao/Create
        // Método de ação que retorna a view Create da pasta Sessão
        public IActionResult Create()
        {
            // Envia para a view Create duas listas contendo todas as salas e filmes encontrados no banco de dados
            ViewBag.ListaSalas = _context.Sala.ToList();
            ViewBag.ListaFilmes= _context.Filme.ToList();
            return View();
        }

        // POST: Sessao/Create
        // Salvando a sessão que recebeu como parâmetro no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Sessao sessao)
        {
            // Confere se as validações estão corretas
            if (ModelState.IsValid)
            {
                _context.Sessao.Add(sessao);
                await _context.SaveChangesAsync();
                // Redireciona para a action Index
                return RedirectToAction(nameof(Index));
            }
            // Redireciona para a Action Create
            return RedirectToAction(nameof(Create));
        }

        // GET: Sessao/Edit/5
        // Método de ação que retorna a view Edit da pasta Sessão 
        public async Task<IActionResult> Edit(int? id)
        {
            // Confere se o id é nulo
            if (id == null)
            {
                return NotFound();
            }

            // Faz uma consulta no banco trazendo a sessão
            var sessao = await _context.Sessao.Include(x => x.Filme).Include(x => x.Sala).FirstOrDefaultAsync(x=>x.Id == id);

            // Confere se a sessão é nula
            if (sessao == null)
            {
                return NotFound();
            }

            // Envia para a View Edit duas Viewbags contendo duas listas das salas e filmes encontrados no banco de dados
            ViewBag.ListaSalas = _context.Sala.ToList();
            ViewBag.ListaFilmes = _context.Filme.ToList();

            // Retorna a sessão encontrada para a view Edit
            return View(sessao);
        }

        // POST: Sessao/Edit/5
        // Salva as alterações da sessão 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Sessao sessao)
        {
            // Confere se o id do parâmetro e da sessão são diferentes
            if (id != sessao.Id)
            {
                return NotFound();
            }
            // Confere se as validações estão corretas
            if (ModelState.IsValid)
            {
                // Uma barreira final, para evitar qualquer erro na hora de salvar as alterações
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.Id))
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
            return View(sessao);
        }

        // GET: Sessao/Delete/5
        // Método de ação que retorna a view Delete da pasta Sessão
        public async Task<IActionResult> Delete(int? id)
        {
            // Confere se o Id é nulo
            if (id == null)
            {
                return NotFound();
            }

            // Faz uma busca no banco pela sessão, filme, sala e gênero do filme
            var sessao = await _context.Sessao.Include(x => x.Filme).Include(x => x.Sala).Include(x => x.Filme.Genero).FirstOrDefaultAsync(m => m.Id == id);
            // Confere se a sessão é nula
            if (sessao == null)
            {
                return NotFound();
            }
          
            // Retorna a view com a sessão encontrada no banco de dados
            return View(sessao);
        }

        // POST: Sessao/Delete/5
        // Método que confirma a sessão que será excluída através do id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessao = await _context.Sessao.FindAsync(id);
            _context.Sessao.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
