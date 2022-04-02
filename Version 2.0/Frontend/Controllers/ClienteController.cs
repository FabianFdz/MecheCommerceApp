using Backend.DAL;
using Backend.Entities;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class ClienteController : Controller
    {
        IClienteDAL clienteDAL;

        // GET: ClienteController
        public ActionResult Index()
        {
            List<Cliente> clientes;
            List<ClienteViewModel> lista = new List<ClienteViewModel>();
            clienteDAL = new ClienteDAL();

            clientes = clienteDAL.GetAll().ToList();
            ClienteViewModel clienteVM;

            foreach (var item in clientes)
            {
                clienteVM = new ClienteViewModel
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    PrimerApellido = item.PrimerApellido,
                    SegundoApellido = item.SegundoApellido,
                    Correo = item.Correo,
                    Telefono = item.Telefono,
                    Usuario = item.Usuario,
                    Pass = item.Pass,
                    Direccion = item.Direccion,
                    Provincia = item.Provincia,
                    Canton = item.Canton,
                    Distrito = item.Distrito
                 };
                lista.Add(clienteVM);
            }

            return View(lista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.Get(id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                clienteDAL = new ClienteDAL();
                clienteDAL.Add(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.Get(id);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                clienteDAL = new ClienteDAL();
                clienteDAL.Update(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.Get(id);
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                clienteDAL = new ClienteDAL();
                clienteDAL.Remove(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
