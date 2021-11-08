using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClinica.Data;
using MVCClinica.Models;
using MVCClinica.Repository;
using MVCClinica.Filter;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            return View("Index", AdmMedico.Listar());  
        }

        public ActionResult Detalle(int id)
        {
            Medico medico = AdmMedico.Detalle(id);
            if (medico != null)
            {
                return View("Detalle", medico);
            }
            else
                return HttpNotFound();
        }

        [ActionName("Crear")]
        public ActionResult Crear()
        {
            Medico medico = new Medico();
            return View("Crear", medico);
        }

        [MyFilterAction]
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

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Medico medico = AdmMedico.Buscar(id);
            if (medico != null)
            {
                return View("Editar", medico);
            }
            else
                return HttpNotFound();
            
        }

        [HttpPost]
        [ActionName("Editar")]
        public ActionResult EditarConfirmed(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Editar(medico);
                return RedirectToAction("Index");
            }

            return View("Editar", medico);
        }

        public ActionResult Eliminar(int id)
        {
            Medico medico = AdmMedico.Detalle(id);

            if (medico != null)
            {
                return View("Eliminar", medico);
            }
            else 
                return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirmed(int id)
        {
            Medico medico = AdmMedico.Detalle(id);

            if (medico != null)
            {
                AdmMedico.Eliminar(medico);
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();

        }

        public ActionResult TraerPorEspecialidad(string especialidad)
        {

            if (especialidad != null)
            {
                ViewBag.Especialidad = especialidad;
                return View("Index", AdmMedico.ListarPorEspecialidad(especialidad));
            }
            else
                return RedirectToAction("Index");    
        }

        public ActionResult TraerPorNombreYApellido(string nombre, string apellido)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Apellido = apellido;

            return View();
        }

    }
}