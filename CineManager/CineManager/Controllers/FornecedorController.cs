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
using Microsoft.AspNetCore.Routing;

namespace CineManager.Controllers
{
    [Authorize]
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FornecedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static Fornecedor FornecedorEstatico { get; set; }

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).ToListAsync());
        }

        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            if(FornecedorEstatico == null) {
                FornecedorEstatico = new Fornecedor();
            }
            return View(FornecedorEstatico);
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                FornecedorEstatico = fornecedor;
                return RedirectToAction("Create");
            }
            return View(fornecedor);
        }

        [HttpGet]
        public IActionResult CreateEndereco() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromForm] Endereco end) {
            if(ModelState.IsValid) {
                FornecedorEstatico.ListaEndereco.Add(end);
                return RedirectToAction("Create");
            }
            return View(end);
        }

        [HttpGet]
        public IActionResult CreateTelefone() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTelefone([FromForm] Telefone tel) {
            if (ModelState.IsValid) {
                FornecedorEstatico.ListaTelefone.Add(tel);
                return RedirectToAction("Create");
            }
            return View(tel);
        }
        
        [HttpGet]
        public IActionResult CreateEmail() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmail([FromForm] Email email) {
            if (ModelState.IsValid) {
                FornecedorEstatico.ListaEmail.Add(email);
                return RedirectToAction("Create");
            }
            return View(email);
        }

        [HttpGet]
        public IActionResult CadastrarFornecedor() {
            _context.Fornecedor.Add(FornecedorEstatico);
            FornecedorEstatico = new Fornecedor();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewTelefone() {
            ViewBag.listaEnd = FornecedorEstatico.ListaEndereco;
            ViewBag.MostrarContinuar = (FornecedorEstatico.ListaEndereco.Count > 0);
            return View("AddEndereco");
        }

        [HttpGet]
        public IActionResult CancelarCadastro() {
            FornecedorEstatico = new Fornecedor();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AdicionarFornecedor() {
            Fornecedor forn = FornecedorEstatico;
            _context.Fornecedor.Add(forn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Fornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}
