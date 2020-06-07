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

namespace CineManager.Controllers {
    [Authorize]
    public class FornecedorController : Controller {
        private readonly ApplicationDbContext _context;

        public FornecedorController(ApplicationDbContext context) {
            _context = context;
        }

        public static Fornecedor FornecedorEstatico { get; set; }
        private static string AcaoAtual { get; set; }
        private static bool jaPassou { get; set; }
        // GET: Fornecedor
        public async Task<IActionResult> Index() {
            return View(await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).ToListAsync());
        }

        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null) {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public IActionResult Create() {
            FornecedorEstatico = new Fornecedor();
            AcaoAtual = "criando";
            return RedirectToAction("CriandoFornecedor");
        }

        public IActionResult CriandoFornecedor() {
            return View(FornecedorEstatico);
        }

        [HttpPost]
        public IActionResult CriandoFornecedor([FromForm] Fornecedor fornecedor) {
            if (ModelState.IsValid) {
                FornecedorEstatico = fornecedor;
                return RedirectToAction("CriandoFornecedor");
            }
            return View(fornecedor);
        }

        // ADICIONANDO AS COISAS
        public IActionResult AdicionarEnd() {
            return View("Endereco/AdicionarEnd");
        }

        [HttpPost]
        public IActionResult AdicionarEnd([FromForm] Endereco end) {
            if (ModelState.IsValid) {
                FornecedorEstatico.ListaEndereco.Add(end);
                if (AcaoAtual == "criando") {
                    return RedirectToAction("CriandoFornecedor");
                } else if (AcaoAtual == "editando") {
                    return RedirectToAction("EditandoFornecedor");
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
                    FornecedorEstatico.ListaTelefone.Add(tel);
                    if (AcaoAtual == "criando") {
                        return RedirectToAction("CriandoFornecedor");
                    } else if (AcaoAtual == "editando") {
                        return RedirectToAction("EditandoFornecedor");
                    }
                }
            }
            return View(tel);
        }

        public IActionResult AdicionarEmail() {
            return View("Email/AdicionarEmail");
        }

        [HttpPost]
        public IActionResult AdicionarEmail([FromForm] Email email) {
            if (ModelState.IsValid) {
                FornecedorEstatico.ListaEmail.Add(email);
                if (AcaoAtual == "criando") {
                    return RedirectToAction("CriandoFornecedor");
                } else if (AcaoAtual == "editando") {
                    return RedirectToAction("EditandoFornecedor");
                }
            }
            return View(email);
        }
        // FIM DO ADICIONANDO AS COISAS

        public async Task<IActionResult> CadastrarFornecedor() {
            await _context.Fornecedor.AddAsync(FornecedorEstatico);
            await _context.SaveChangesAsync();
            FornecedorEstatico = null;
            return RedirectToAction("Index");
        }

        public IActionResult Cancelar() {
            FornecedorEstatico = null;
            AcaoAtual = null;
            return RedirectToAction("Index");
        }

        // GET: Fornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null) {
                return NotFound();
            }

            FornecedorEstatico = fornecedor;
            AcaoAtual = "editando";
            jaPassou = true;
            return RedirectToAction("EditandoFornecedor");
        }

        public IActionResult EditandoFornecedor() {
            ViewBag.passou = jaPassou;
            return View(FornecedorEstatico);
        }

        [HttpPost]
        public IActionResult EditandoFornecedor([FromForm] Fornecedor fornecedor) {
            jaPassou = false;
            FornecedorEstatico.NomeResponsavel = fornecedor.NomeResponsavel;
            FornecedorEstatico.NomeDaEmpresa = fornecedor.NomeDaEmpresa;
            return RedirectToAction("EditandoFornecedor");
        }

        //INICIO EDITAR
        public IActionResult EditandoEnd(int id) {
            
            var end = FornecedorEstatico.ListaEndereco.FirstOrDefault(x => x.Id == id);

            if (end == null) {
                return NotFound();
            }
            return View("Endereco/EditandoEnd", end);
        }

        [HttpPost]
        public IActionResult EditandoEnd([FromForm] Endereco end) {
            if (ModelState.IsValid) {
                int endereco = FornecedorEstatico.ListaEndereco.FindIndex(x => x.Id == end.Id);
                FornecedorEstatico.ListaEndereco[endereco].NomeLogradouro = end.NomeLogradouro;
                FornecedorEstatico.ListaEndereco[endereco].TipoEndereco = end.TipoEndereco;
                FornecedorEstatico.ListaEndereco[endereco].TipoLogradouro = end.TipoLogradouro;
                FornecedorEstatico.ListaEndereco[endereco].Numero = end.Numero;
                FornecedorEstatico.ListaEndereco[endereco].Pais = end.Pais;
                FornecedorEstatico.ListaEndereco[endereco].Bairro = end.Bairro;
                FornecedorEstatico.ListaEndereco[endereco].Cep = end.Cep;
                FornecedorEstatico.ListaEndereco[endereco].Cidade = end.Cidade;
                FornecedorEstatico.ListaEndereco[endereco].Complemento = end.Complemento;
                FornecedorEstatico.ListaEndereco[endereco].Estado = end.Estado;

                if (AcaoAtual == "editando") {
                    return RedirectToAction("EditandoFornecedor");
                } else if (AcaoAtual == "criando") {
                    return RedirectToAction("CriandoFornecedor");
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
                int telefone = FornecedorEstatico.ListaTelefone.FindIndex(x => x.Id == tel.Id);

                FornecedorEstatico.ListaTelefone[telefone].Numero = tel.Numero;
                FornecedorEstatico.ListaTelefone[telefone].Tipo = tel.Tipo;
                FornecedorEstatico.ListaTelefone[telefone].DDD = tel.DDD;
                FornecedorEstatico.ListaTelefone[telefone].DDI = tel.DDI;

                if (AcaoAtual == "editando") {
                    return RedirectToAction("EditandoFornecedor");
                } else if (AcaoAtual == "criando") {
                    return RedirectToAction("CriandoFornecedor");
                }
            }
            return View(tel);
        }

        public async Task<IActionResult> EditandoEmail(int? id) {
            if (id == null) {
                return NotFound();
            }
            Email email = await _context.Email.FirstOrDefaultAsync(x => x.Id == id);
            if (email == null) {
                return NotFound();
            }
            return View("Email/EditandoEmail", email);
        }

        [HttpPost]
        public IActionResult EditandoEmail([FromForm] Email email) {
            if (ModelState.IsValid) {
                int posicaoEmail = FornecedorEstatico.ListaEmail.FindIndex(x => x.Id == email.Id);

                FornecedorEstatico.ListaEmail[posicaoEmail].EnderecoEmail = email.EnderecoEmail;
                if (AcaoAtual == "criando") {
                    return RedirectToAction("CriandoFornecedor");
                } else if (AcaoAtual == "editando") {
                    return RedirectToAction("EditandoFornecedor");
                }
            }
            return View(email);
        }

        //FIM EDITAR

        //INICIO DELETE END, TEL E EMAIL
        public IActionResult DeletarEnd(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = FornecedorEstatico.ListaEndereco.FirstOrDefault(x => x.Id == id);
            if (_context.Endereco.Contains(obj)) {
                _context.Endereco.Remove(obj);
                _context.SaveChanges();
            }
            FornecedorEstatico.ListaEndereco.Remove(obj);

            if (AcaoAtual == "editando") {
                return RedirectToAction("EditandoFornecedor");
            } else if (AcaoAtual == "criando") {
                return RedirectToAction("CriandoFornecedor");
            } else {
                throw new Exception("Deu ruim");
            }

        }

        public IActionResult DeletarTel(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = FornecedorEstatico.ListaTelefone.FirstOrDefault(x => x.Id == id);
            if (_context.Telefone.Contains(obj)) {
                _context.Telefone.Remove(obj);
                _context.SaveChanges();
            }
            FornecedorEstatico.ListaTelefone.Remove(obj);

            if (AcaoAtual == "editando") {
                return RedirectToAction("EditandoFornecedor");
            } else if (AcaoAtual == "criando") {
                return RedirectToAction("CriandoFornecedor");
            } else {
                throw new Exception("Deu ruim");
            }
        }


        public IActionResult DeletarEmail(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = FornecedorEstatico.ListaEmail.FirstOrDefault(x => x.Id == id);
            if (_context.Email.Contains(obj)) {
                _context.Email.Remove(obj);
                _context.SaveChanges();
            }
            FornecedorEstatico.ListaEmail.Remove(obj);

            if (AcaoAtual == "editando") {
                return RedirectToAction("EditandoFornecedor");
            } else if (AcaoAtual == "criando") {
                return RedirectToAction("CriandoFornecedor");
            } else {
                throw new Exception("Deu ruim");
            }
        }
        //FIM DELETE


        public async Task<IActionResult> AtualizandoFornecedor() {
            _context.Update(FornecedorEstatico);
            await _context.SaveChangesAsync();
            AcaoAtual = null;
            FornecedorEstatico = null;
            return RedirectToAction("Index");
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.Include(x => x.ListaTelefone).Include(x => x.ListaEndereco)
                                .Include(x => x.ListaEmail).FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null) {
                return NotFound();
            }

            excluirTudoFornecedor(fornecedor);

            _context.Remove(fornecedor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public void excluirTudoFornecedor(Fornecedor fornecedor) {
            foreach (Endereco end in fornecedor.ListaEndereco) {
                if (_context.Endereco.Contains(end)) {
                    _context.Endereco.Remove(end);
                }
            }
            foreach (Telefone tel in fornecedor.ListaTelefone) {
                if (_context.Telefone.Contains(tel)) {
                    _context.Telefone.Remove(tel);
                }
            }
            foreach (Email email in fornecedor.ListaEmail) {
                if (_context.Email.Contains(email)) {
                    _context.Email.Remove(email);
                }
            }
            _context.SaveChanges();
        }
    }
}
