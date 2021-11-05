using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClinica.Data;
using MVCClinica.Models;
using MVCClinica.Repository;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            return View("Index", AdmMedico.Listar());  
        }

        [ActionName("Crear")]
        public ActionResult Crear()
        {
            Medico medico = new Medico();
            return View("Crear", medico);
        }

        [HttpPost]
        public ActionResult Crear(Medico medico)
        {
            if (ModelState.IsValid)
            {
                int filasAfectadas = AdmMedico.Insertar(medico);
                if (filasAfectadas > 0)
                {
                    return View("Index", AdmMedico.Listar());
                }
            }

            return View("Crear", medico);
        }
    }
}