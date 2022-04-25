using Backend.DAL;
using Backend.Entities;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> userManager;

        public ClienteController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            Cliente cliente;
            clienteDAL = new ClienteDAL();

            cliente = clienteDAL.GetByEmail(User.Identity.Name);
            ClienteViewModel clienteVM;

            clienteVM = new ClienteViewModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                PrimerApellido = cliente.PrimerApellido,
                SegundoApellido = cliente.SegundoApellido,
                Correo = cliente.Correo,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Provincia = cliente.Provincia,
                Canton = cliente.Canton,
                Distrito = cliente.Distrito
            };

            return View(clienteVM);
        }

        // POST: ClienteController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ClienteViewModel cliente)
        {
            try
            {
                clienteDAL = new ClienteDAL();
                clienteDAL.Update(new Cliente {
                    Canton = cliente.Canton,
                    Correo = cliente.Correo,
                    Direccion = cliente.Direccion,
                    Distrito = cliente.Distrito,
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    PrimerApellido = cliente.PrimerApellido,
                    Provincia = cliente.Provincia,
                    SegundoApellido = cliente.SegundoApellido,
                    Telefono = cliente.Telefono
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
