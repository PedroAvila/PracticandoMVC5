using AutoMapper;
using Repaso.EntidadesDominio;
using Repaso.ServiciosDominio;
using Repaso.WebApplicationUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso.WebApplicationUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly SdEmpleado _sdEmpleado = new SdEmpleado();

        // GET: Empleado
        public ActionResult Index()
        {
            var list = _sdEmpleado.GetAll();

            var listEmpleadoViewModel = Mapper.Map<List<EmpleadoViewModel>>(list);
            ViewBag.EmpleadoViewModel = listEmpleadoViewModel;
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpleadoViewModel entity)
        {
            var empleado = Mapper.Map<Empleado>(entity);
            _sdEmpleado.Create(empleado);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            var empleado = _sdEmpleado.Single(id);
            if (empleado != null)
            {
                _sdEmpleado.Delete(id);
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}