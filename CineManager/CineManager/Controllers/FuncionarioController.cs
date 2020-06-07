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

        private static bool editPassou { get; set; }
        private static Funcionario mFuncionario { get; set; }
        private static string acaoAtual { get; set; }

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco).ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefone).
                Include(x => x.ListaEndereco).FirstOrDefaultAsync(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            mFuncionario = new Funcionario();
            acaoAtual = "criando";
            return RedirectToAction("CriandoFuncionario");
        }

        public IActionResult CriandoFuncionario() {
            return View(mFuncionario);
        }

        [HttpPost]
        public IActionResult CriandoFuncionario([FromForm] Funcionario funcionario) {
            mFuncionario = funcionario;
            return RedirectToAction("CriandoFuncionario");
        }

        // ADICIONANDO AS COISAS
        public IActionResult AdicionarEnd() {
            return View("Endereco/AdicionarEnd");
        }

        [HttpPost]
        public IActionResult AdicionarEnd([FromForm] Endereco end) {
            if (ModelState.IsValid) {
                mFuncionario.ListaEndereco.Add(end);
                if (acaoAtual == "criando") {
                    return RedirectToAction("CriandoFuncionario");
                } else if (acaoAtual == "editando") {
                    return RedirectToAction("EditandoFuncionario");
                }
            }
            return View(end);
        }

        public IActionResult AdicionarTel() {
            return View("Telefone/AdicionarTel");
        }

        [HttpPost]
        public IActionResult AdicionarTel([FromForm] Telefone tel) {
            if (ModelState.IsValid) {
                if (ModelState.IsValid) {
                    mFuncionario.ListaTelefone.Add(tel);
                    if (acaoAtual == "criando") {
                        return RedirectToAction("CriandoFuncionario");
                    } else if (acaoAtual == "editando") {
                        return RedirectToAction("EditandoFuncionario");
                    }
                }
            }
            return View(tel);
        }
        // FIM ADICIONANDO AS COISAS

        public async Task<IActionResult> CadastrarFuncionario() {
            await _context.Funcionario.AddAsync(mFuncionario);
            await _context.SaveChangesAsync();
            mFuncionario = null;
            acaoAtual = null;
            return RedirectToAction("Index");
        }

        public IActionResult Cancelar() {
            mFuncionario = null;
            acaoAtual = null;
            return RedirectToAction("Index");
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefone).
                Include(x => x.ListaEndereco).FirstOrDefaultAsync(x => x.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            mFuncionario = funcionario;
            acaoAtual = "editando";
            editPassou = false;
            return RedirectToAction("EditandoFuncionario");
        }

        public IActionResult EditandoFuncionario() {
            ViewBag.passando = editPassou;
            return View(mFuncionario);
        }

        [HttpPost]
        public IActionResult EditandoFuncionario([FromForm] Funcionario funcionario) {
            mFuncionario.Rg = funcionario.Rg;
            mFuncionario.Salario = funcionario.Salario;
            mFuncionario.Setor = funcionario.Setor;
            mFuncionario.Telefone = funcionario.Telefone;
            mFuncionario.Turno = funcionario.Turno;
            mFuncionario.Cargo = funcionario.Cargo;
            mFuncionario.Cpf = funcionario.Cpf;
            mFuncionario.NomeCompleto = funcionario.NomeCompleto;
            editPassou = true;
            return RedirectToAction("EditandoFuncionario");
        }

        //INICIO EDITAR
        public IActionResult EditandoEnd(int? id) {
            if (id == null) {
                return NotFound();
            }

            var end = mFuncionario.ListaEndereco.FirstOrDefault(x => x.Id == id);

            if (end == null) {
                return NotFound();
            }
            return View("Endereco/EditandoEnd", end);
        }

        [HttpPost]
        public IActionResult EditandoEnd([FromForm] Endereco end) {
            if (ModelState.IsValid) {
                int endereco = mFuncionario.ListaEndereco.FindIndex(x => x.Id == end.Id);
                mFuncionario.ListaEndereco[endereco].NomeLogradouro = end.NomeLogradouro;
                mFuncionario.ListaEndereco[endereco].TipoEndereco = end.TipoEndereco;
                mFuncionario.ListaEndereco[endereco].TipoLogradouro = end.TipoLogradouro;
                mFuncionario.ListaEndereco[endereco].Numero = end.Numero;
                mFuncionario.ListaEndereco[endereco].Pais = end.Pais;
                mFuncionario.ListaEndereco[endereco].Bairro = end.Bairro;
                mFuncionario.ListaEndereco[endereco].Cep = end.Cep;
                mFuncionario.ListaEndereco[endereco].Cidade = end.Cidade;
                mFuncionario.ListaEndereco[endereco].Complemento = end.Complemento;
                mFuncionario.ListaEndereco[endereco].Estado = end.Estado;

                if (acaoAtual == "editando") {
                    return RedirectToAction("EditandoFuncionario");
                } else if (acaoAtual == "criando") {
                    return RedirectToAction("CriandoFuncionario");
                }
            }
            return View(end);
        }

        public async Task<IActionResult> EditandoTel(int? id) {
            if (id == null) {
                return NotFound();
            }

            Telefone telefone = await _context.Telefone.FirstOrDefaultAsync(x => x.Id == id);
            if (telefone == null) {
                return NotFound();
            }
            return View("Telefone/EditandoTel", telefone);
        }

        [HttpPost]
        public IActionResult EditandoTel([FromForm] Telefone tel) {
            if (ModelState.IsValid) {
                int telefone = mFuncionario.ListaTelefone.FindIndex(x => x.Id == tel.Id);

                mFuncionario.ListaTelefone[telefone].Numero = tel.Numero;
                mFuncionario.ListaTelefone[telefone].Tipo = tel.Tipo;
                mFuncionario.ListaTelefone[telefone].DDD = tel.DDD;
                mFuncionario.ListaTelefone[telefone].DDI = tel.DDI;

                if (acaoAtual == "editando") {
                    return RedirectToAction("EditandoFuncionario");
                } else if (acaoAtual == "criando") {
                    return RedirectToAction("CriandoFuncionario");
                }
            }
            return View(tel);
        }
        //FIM EDITAR

        //INICIO DELETE
        public IActionResult DeletarEnd(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = mFuncionario.ListaEndereco.FirstOrDefault(x => x.Id == id);
            if (_context.Endereco.Contains(obj)) {
                _context.Endereco.Remove(obj);
                _context.SaveChanges();
            }
            mFuncionario.ListaEndereco.Remove(obj);

            if (acaoAtual == "editando") {
                return RedirectToAction("EditandoFuncionario");
            } else if (acaoAtual == "criando") {
                return RedirectToAction("CriandoFuncionario");
            } else {
                throw new Exception("Deu ruim");
            }

        }

        public IActionResult DeletarTel(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = mFuncionario.ListaTelefone.FirstOrDefault(x => x.Id == id);
            if (_context.Telefone.Contains(obj)) {
                _context.Telefone.Remove(obj);
                _context.SaveChanges();
            }
            mFuncionario.ListaTelefone.Remove(obj);

            if (acaoAtual == "editando") {
                return RedirectToAction("EditandoFuncionario");
            } else if (acaoAtual == "criando") {
                return RedirectToAction("CriandoFuncionario");
            } else {
                throw new Exception("Deu ruim");
            }
        }
        //FIM  DELETE

        public async Task<IActionResult> AtualizandoFuncionario() {
            _context.Update(mFuncionario);
            await _context.SaveChangesAsync();
            acaoAtual = null;
            mFuncionario = null;
            return RedirectToAction("Index");
        }


        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null) {
                return NotFound();
            }

            excluirTudoFuncionario(funcionario);

            _context.Remove(funcionario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public void excluirTudoFuncionario(Funcionario funcionario) {
            foreach (Endereco end in funcionario.ListaEndereco) {
                if (_context.Endereco.Contains(end)) {
                    _context.Endereco.Remove(end);
                }
            }
            foreach (Telefone tel in funcionario.ListaTelefone) {
                if (_context.Telefone.Contains(tel)) {
                    _context.Telefone.Remove(tel);
                }
            }
            _context.SaveChanges();
        }
    }
}
