using Backend.DAL;
using Backend.Entities;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    public class OrdenesController : Controller
    {
        IOrdenDAL OrdenDAL;
        IClienteDAL ClienteDAL;

        public OrdenesController()
        {
            OrdenDAL = new OrdenDAL();
            ClienteDAL = new ClienteDAL();
        }

        private OrdenViewModel parseToVM(Orden orden)
        {
            return new OrdenViewModel
            {
                DireccionCompleta = orden.DireccionCompleta,
                Estado = orden.Estado,
                FechaCreacion = orden.FechaCreacion,
                FechaEntrega = orden.FechaEntrega,
                Id = orden.Id,
                IdCliente = orden.IdCliente,
                PrecioTotal = orden.PrecioTotal,
            };
        }

        // GET: OrdenesController
        public ActionResult Index()
        {
            Cliente cliente = ClienteDAL.GetByEmail(User.Identity.Name);
            IEnumerable ordenes = cliente.Ordens;
            List<OrdenViewModel> ordenesVM = new List<OrdenViewModel>();
            foreach(Orden orden in ordenes)
            {
                ordenesVM.Add(parseToVM(orden));
            }

            return View(ordenesVM);
        }

        // GET: OrdenesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
