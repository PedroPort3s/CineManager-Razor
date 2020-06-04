using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CineManager.Models;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using System.IO;

namespace CineManager.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public FileResult GerarPdf()
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                var corFonte = PdfSharpCore.Drawing.XBrushes.Black;
                var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var fonteOrganizacao = new PdfSharpCore.Drawing.XFont("Arial", 10);
                var fonteDescricao = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
                var tituloDetalhes = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
                var fonteDetalheDescricao = new PdfSharpCore.Drawing.XFont("Arial", 7);

                var logo = @"C:\Users\pedri\Desktop\CineManager\CineManager\CineManager\CineManager\wwwroot\logo-cm-ps.png";

                var qtdPaginas = doc.PageCount;
                textFormatter.DrawString(qtdPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte,
                    new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));

                XImage imagem = XImage.FromFile(logo);
                graphics.DrawImage(imagem, 20, 5, 300, 50);


                textFormatter.DrawString("Filme : ", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20,75, page.Width, page.Height));


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
