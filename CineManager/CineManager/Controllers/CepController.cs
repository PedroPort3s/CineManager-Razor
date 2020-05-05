using CineManager.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CineManager.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cep = Models.Cep.Busca("82840250");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }
    }
}
