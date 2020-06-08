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
using CineManager.Areas.Identity.Pages.Account.Manage;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.WebUtilities;
using System.IO;
using PdfSharpCore.Drawing;

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

            return View(await _context.Filme.Include(x => x.Generos).
                Include(x => x.TiposFilme).OrderBy(x => x.Lancamento).Where(x => 
                (x.Lancamento < DateTime.Now && x.EmCartazAte > DateTime.Now)).ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.Include(x => x.Generos).ThenInclude(x => x.Genero).Include(x => x.TiposFilme).ThenInclude(x => x.TipoFilme).
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
            List<Genero> listaGeneros = _context.Generos.ToList();
            List<TipoFilme> listaTipos = _context.TipoFilmes.ToList();
            ViewBag.ListaTipos = listaTipos;

            if (listaGeneros.Count > 0)
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
                    Genero genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == generoId);
                    FilmeGenero filmGen = new FilmeGenero();
                    filmGen.Genero = genero;
                    filme.Generos.Add(filmGen);
                }

                foreach (var tipo in filme.ListaTiposJoin.Split(','))
                {
                    int tipoId = Convert.ToInt32(tipo);
                    TipoFilme tipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == tipoId);
                    FilmeTipoFilme filmeTipo = new FilmeTipoFilme();
                    filmeTipo.TipoFilme = tipoFilme;
                    filme.TiposFilme.Add(filmeTipo);
                }


                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filme/Edit/5
        //[Route("Filme/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = _context.Filme.Include(x => x.Generos).ThenInclude(gen => gen.Genero).
                Include(x => x.TiposFilme).ThenInclude(x => x.TipoFilme).FirstOrDefault(x => x.Id == id);


            if (filme == null)
            {
                return NotFound();
            }

            var genSelecionados = new List<int>();
            foreach (var gen in filme.Generos)
            {
                genSelecionados.Add(gen.Genero.Id);
            }

            var tiposSelecionados = new List<int>();

            foreach (var tipo in filme.TiposFilme)
            {
                tiposSelecionados.Add(tipo.TipoFilme.Id);
            }

            filme.ListaGenerosJoinPreserve = string.Join(',', genSelecionados);
            filme.ListaTiposRemove = string.Join(',', tiposSelecionados);

            ViewBag.ListaTipoFilmes = _context.TipoFilmes.ToListAsync();
            ViewBag.ListaGeneros = _context.Generos.ToListAsync();

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
                    foreach (var gen in filme.ListaGenerosJoinPreserve.Split(','))
                    {
                        var genInt = Convert.ToInt32(gen);
                        var filGen = await _context.FilmeGeneros.Include(x => x.Genero).FirstOrDefaultAsync(x => x.Genero.Id == genInt);
                        if (filGen != null)
                        {
                            filme.Generos.Remove(filGen);
                            _context.Remove(filGen);
                        }
                    }

                    //Se editar um filme e não abrir as modais e clicar em salvar, estoura excessão. Precisa tratar!!!

                    foreach (var gen in filme.ListaGenerosJoin.Split(','))
                    {
                        var genInt = Convert.ToInt32(gen);
                        var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == genInt);
                        filme.Generos.Add(new FilmeGenero() { Genero = genero });
                    }

                    foreach (var tipo in filme.ListaTiposRemove.Split(','))
                    {
                        var tipoInt = Convert.ToInt32(tipo);
                        var filmeTipo = await _context.FilmeTiposFilme.Include(x => x.TipoFilme).FirstOrDefaultAsync(x => x.TipoFilme.Id == tipoInt);
                        if (filmeTipo != null)
                        {
                            filme.TiposFilme.Remove(filmeTipo);
                            _context.Remove(filmeTipo);
                        }
                    }

                    foreach (var tipo in filme.ListaTiposJoin.Split(','))
                    {
                        var tipoInt = Convert.ToInt32(tipo);
                        var tipos = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == tipoInt);
                        filme.TiposFilme.Add(new FilmeTipoFilme() { TipoFilme = tipos });
                    }

                    _context.Update(filme);
                    _context.SaveChanges();
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

        public ActionResult DeleteFilme(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).
                   FirstOrDefault(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            foreach (var item in filme.Generos)
            {
                _context.Remove(item);
            }

            foreach (var item in filme.TiposFilme)
            {
                _context.Remove(item);
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); ;
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

            return PartialView("../Shared/Modais/GenerosResult");
        }

        public async Task<ActionResult> GenerosFilmeEdit(int id)
        {
            List<Genero> generos = _context.Generos.ToList();
            var filme = await _context.Filme.Include(x => x.Generos).
             FirstOrDefaultAsync(x => x.Id == id);

            this.ViewBag._ListaGeneros = generos.OrderBy(x => x.Nome);
            var listaGenerosFilme = filme.Generos;
            return PartialView("../Shared/Modais/GenerosResultEdit", listaGenerosFilme);
        }

        public ActionResult GenerosFilmeDetail(int id)
        {
            List<Genero> generos = _context.Generos.ToList();
            var filme = _context.Filme.Include(x => x.Generos).
             FirstOrDefault(x => x.Id == id);

            this.ViewBag._ListaGeneros = generos.OrderBy(x => x.Nome);
            var listaGenerosFilme = filme.Generos;
            return PartialView("../Shared/Modais/GenerosResultDetail", listaGenerosFilme);
        }

        public ActionResult TiposFilme()
        {
            List<TipoFilme> tipos = _context.TipoFilmes.ToList();
            this.ViewBag._ListaTipos = tipos.OrderBy(x => x.NomeTipoFilme);

            return PartialView("../Shared/Modais/TipofilmeResult");
        }

        public async Task<ActionResult> TiposFilmeEdit(int id)
        {
            List<TipoFilme> tipos = _context.TipoFilmes.ToList();
            var filme = await _context.Filme.Include(x => x.TiposFilme).
             FirstOrDefaultAsync(x => x.Id == id);

            this.ViewBag._ListaTipos = tipos.OrderBy(x => x.NomeTipoFilme);

            var listaTipos = filme.TiposFilme;
            return PartialView("../Shared/Modais/TipoFilmeResultEdit", listaTipos);
        }

        public async Task<ActionResult> TiposFilmeDetail(int id)
        {
            List<TipoFilme> tipos = _context.TipoFilmes.ToList();
            var filme = await _context.Filme.Include(x => x.TiposFilme).
             FirstOrDefaultAsync(x => x.Id == id);

            this.ViewBag._ListaTipos = tipos.OrderBy(x => x.NomeTipoFilme);

            var listaTipos = filme.TiposFilme;
            return PartialView("../Shared/Modais/TipoFilmeResultDetail", listaTipos);
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

                TipoFilme objfilme4 = new TipoFilme();
                objfilme4.NomeTipoFilme = "4DX";
                _context.TipoFilmes.Add(objfilme4);

                TipoFilme objfilme5 = new TipoFilme();
                objfilme5.NomeTipoFilme = "IMAX";
                _context.TipoFilmes.Add(objfilme5);

                TipoFilme objfilme6 = new TipoFilme();
                objfilme6.NomeTipoFilme = "Macro XE";
                _context.TipoFilmes.Add(objfilme6);

                TipoFilme objfilme7 = new TipoFilme();
                objfilme7.NomeTipoFilme = "XD";
                _context.TipoFilmes.Add(objfilme7);

                TipoSala objtiposala1 = new TipoSala();
                objtiposala1.Tipo = "2D";
                _context.TipoSala.Add(objtiposala1);

                TipoSala objtiposala2 = new TipoSala();
                objtiposala2.Tipo = "3D";
                _context.TipoSala.Add(objtiposala2);

                TipoSala objtiposala3 = new TipoSala();
                objtiposala3.Tipo = "4D";
                _context.TipoSala.Add(objtiposala3);

                TipoSala objtiposala4 = new TipoSala();
                objtiposala4.Tipo = "4DX";
                _context.TipoSala.Add(objtiposala4);

                TipoSala objtiposala5 = new TipoSala();
                objtiposala5.Tipo = "IMAX";
                _context.TipoSala.Add(objtiposala5);

                TipoSala objtiposala6 = new TipoSala();
                objtiposala6.Tipo = "Macro XE";
                _context.TipoSala.Add(objtiposala6);

                TipoSala objtiposala7 = new TipoSala();
                objtiposala7.Tipo = "XD";
                _context.TipoSala.Add(objtiposala7);

                _context.SaveChanges();
            }
        }

        public FileResult GerarPdf()
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = XGraphics.FromPdfPage(page);
                var corFonte = XBrushes.Black;
                var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var fonteOrganizacao = new XFont("Arial", 10);
                var fonteDescricao = new XFont("Arial", 12, XFontStyle.BoldItalic);
                var titulodetalhes = new XFont("Arial", 14, XFontStyle.Bold);
                var fonteDetalheDescricao = new XFont("Arial", 7);

                //var logo = @"C:\Users\pedri\Desktop\CineManager\CineManager\CineManager\CineManager\wwwroot\logo-cm-ps.png";

                var qtdPaginas = doc.PageCount;

                textFormatter.DrawString(qtdPaginas.ToString(), new XFont("Arial", 10), corFonte,
                    new XRect(578, 825, page.Width, page.Height));

                //XImage imagem = XImage.FromFile(logo);
                //graphics.DrawImage(imagem, 20, 5, 300, 50);

                textFormatter.DrawString("Filmes que ja estiveram disponiveis e estarão futuramente", fonteDescricao, corFonte,
                    new XRect(20, 75, page.Width, page.Height));

                var tituloDetalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                tituloDetalhes.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
                tituloDetalhes.DrawString("Detalhes", titulodetalhes, corFonte, new PdfSharpCore.Drawing.XRect(0, 120, page.Width, page.Height));


                var alturaTituloDetalhesY = 140;
                var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                //titulo
                detalhes.DrawString("Filme", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, alturaTituloDetalhesY, page.Width, page.Height));

                //duração
                detalhes.DrawString("Duração", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(220, alturaTituloDetalhesY, page.Width, page.Height));


                //lançamento
                detalhes.DrawString("Lançamento", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(290, alturaTituloDetalhesY, page.Width, page.Height));

                //em cartaz
                detalhes.DrawString("Em cartaz até", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(430, alturaTituloDetalhesY, page.Width, page.Height));

                List<Filme> listaFilmes = _context.Filme.Include(x => x.Generos).Include(x => x.TiposFilme).ToList();


                var alturarDatalhesItens = 160;

                foreach (Filme f in listaFilmes)
                {
                    textFormatter.DrawString(f.Titulo.ToString(), fonteDetalheDescricao, corFonte,
                        new XRect(15, alturarDatalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(f.Duracao.ToString(), fonteDetalheDescricao, corFonte,
                        new XRect(220, alturarDatalhesItens, page.Width, page.Height));

                    textFormatter.DrawString(f.Lancamento.ToString().Substring(0, 10), fonteDetalheDescricao, corFonte,
                        new XRect(290, alturarDatalhesItens, page.Width, page.Height));

                    textFormatter.DrawString(f.EmCartazAte.ToString().Substring(0, 10), fonteDetalheDescricao, corFonte,
                        new XRect(430, alturarDatalhesItens, page.Width, page.Height));

                    alturarDatalhesItens += 20;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    var contentType = "application/pdf";

                    doc.Save(stream, false);

                    var nomeArquivo = "relatorioFilmes.pdf";

                    return File(stream.ToArray(), contentType, nomeArquivo);
                }
            }
        }

    }
}