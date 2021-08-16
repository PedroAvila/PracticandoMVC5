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

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(EmpleadoViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var empleado = Mapper.Map<Empleado>(entity);
                _sdEmpleado.Create(empleado);

                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        [HttpGet]
        public JsonResult Single(int id)
        {
            bool result = false;
            var empleado = _sdEmpleado.Single(id);
            if (empleado != null)
            {
                var empleadoVM = new EmpleadoViewModel()
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Direccion = empleado.Direccion,
                    Email = empleado.Email,
                    Telefono = empleado.Telefono
                };
                result = true;
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var entity = _sdEmpleado.Single(id);
            var modelo = Mapper.Map<EmpleadoViewModel>(entity);
            return View("_Update", modelo);
        }

        [HttpPost]
        public ActionResult Update(int id, EmpleadoViewModel entity)
        {
            entity.EmpleadoId = id;
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