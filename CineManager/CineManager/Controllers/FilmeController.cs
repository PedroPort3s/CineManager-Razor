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
using PdfSharpCore.Drawing;
using System.IO;

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
            return View(await _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).
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
        public async Task<IActionResult> Create([FromForm] FilmeGenTipo filmeGenTipo)
        {
            if (ModelState.IsValid)
            {
                filmeGenTipo.Genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.GeneroId);
                filmeGenTipo.TipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.TipoFilmeId);

                _context.Add(filmeGenTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmeGenTipo);
        }

        // GET: Filme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeGenTipo = await _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).
                    FirstOrDefaultAsync(x => x.Id == id);
            if (filmeGenTipo == null)
            {
                return NotFound();
            }
            ViewBag.ListaTipoFilmes = await _context.TipoFilmes.ToListAsync();
            ViewBag.ListaGeneros = await _context.Generos.ToListAsync();
            return View(filmeGenTipo);
        }

        // POST: Filme/Edit/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] FilmeGenTipo filmeGenTipo)
        {
            if (id != filmeGenTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    filmeGenTipo.Genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.Filme.GeneroId);
                    filmeGenTipo.TipoFilme = await _context.TipoFilmes.FirstOrDefaultAsync(x => x.Id == filmeGenTipo.Filme.TipoFilmeId);
                    _context.Update(filmeGenTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filmeGenTipo.Id))
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
            return View(filmeGenTipo);
        }

        // GET: Filme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeGenTipo = await _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).
                   FirstOrDefaultAsync(x => x.Id == id);
            if (filmeGenTipo == null)
            {
                return NotFound();
            }

            return View(filmeGenTipo);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmeGenTipo = await _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).
                FirstOrDefaultAsync(x => x.Id == id);

            if (filmeGenTipo == null)
            {
                return NotFound();
            }

            _context.ListaFilmeGenTipo.Remove(filmeGenTipo);
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

                var logo = @"C:\Users\pedri\Desktop\CineManager\CineManager\CineManager\CineManager\wwwroot\logo-cm-ps.png";

                var qtdPaginas = doc.PageCount;

                textFormatter.DrawString(qtdPaginas.ToString(), new XFont("Arial", 10), corFonte,
                    new XRect(578, 825, page.Width, page.Height));

                XImage imagem = XImage.FromFile(logo);
                graphics.DrawImage(imagem, 20, 5, 300, 50);

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

                List<FilmeGenTipo> listaFilmes = _context.ListaFilmeGenTipo.Include(x => x.Filme).Include(x => x.Genero).Include(x => x.TipoFilme).ToList();


                var alturarDatalhesItens = 160;
                
                foreach (FilmeGenTipo f in listaFilmes)
                {
                    textFormatter.DrawString(f.Filme.Titulo.ToString(), fonteDetalheDescricao, corFonte,
                        new XRect(15, alturarDatalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(f.Filme.Duracao.ToString(), fonteDetalheDescricao, corFonte,
                        new XRect(220, alturarDatalhesItens, page.Width, page.Height));

                    textFormatter.DrawString(f.Filme.Lancamento.ToString().Substring(0,10), fonteDetalheDescricao, corFonte,
                        new XRect(290, alturarDatalhesItens, page.Width, page.Height));

                    textFormatter.DrawString(f.Filme.EmCartazAte.ToString().Substring(0, 10), fonteDetalheDescricao, corFonte,
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
