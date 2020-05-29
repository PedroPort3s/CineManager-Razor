using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using CineManager.Models;
using Microsoft.EntityFrameworkCore.Query;
using CineManager.ViewModels;
using CineManager.Util;

namespace CineManager.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.Include(x => x.ListaTelefones).Include(x => x.ListaEnderecos).ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefones).
                Include(x => x.ListaEnderecos).FirstOrDefaultAsync(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] FuncionarioViewModel funcionarioVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    funcionarioVm.Funcionario.Endereco.Cep = RetirarCaracteres.RetirarMascara(funcionarioVm.Funcionario.Endereco.Cep);
                    funcionarioVm.Funcionario.ListaEnderecos.Add(funcionarioVm.Funcionario.Endereco);

                    funcionarioVm.Funcionario.Cpf = Convert.ToInt64(RetirarCaracteres.RetirarMascara(funcionarioVm.cpf));

                    funcionarioVm.Funcionario.Telefone = new Telefone();

                    funcionarioVm.Funcionario.Telefone.Numero = Convert.ToInt64(RetirarCaracteres.RetirarMascara(funcionarioVm.telefone));
                    funcionarioVm.Funcionario.Telefone.DDD = Convert.ToInt32(RetirarCaracteres.RetirarMascara(funcionarioVm.ddd));
                    funcionarioVm.Funcionario.Telefone.DDI = "+55";

                    if (RetirarCaracteres.RetirarMascara(funcionarioVm.Funcionario.Telefone.Numero.ToString()).Length == 9)
                    {
                        funcionarioVm.Funcionario.Telefone.Tipo = "Celular";
                    }
                    else if (RetirarCaracteres.RetirarMascara(funcionarioVm.Funcionario.Telefone.Numero.ToString()).Length == 8)
                    {
                        funcionarioVm.Funcionario.Telefone.Tipo = "Fixo";
                    }

                    funcionarioVm.Funcionario.ListaTelefones.Add(funcionarioVm.Funcionario.Telefone);

                    _context.Add(funcionarioVm.Funcionario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("Teste Sweet Alert");
                }
            }
            catch (Exception)
            {
                return View();
            }

            return View(funcionarioVm);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefones).
                Include(x => x.ListaEnderecos).FirstOrDefaultAsync(x => x.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefones)
                .Include(x => x.ListaEnderecos).FirstOrDefaultAsync(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefones)
                .Include(x => x.ListaEnderecos).FirstOrDefaultAsync(x => x.Id == id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
    }
}
