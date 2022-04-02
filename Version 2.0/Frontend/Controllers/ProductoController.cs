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
    public class ProductoController : Controller
    {
        private IProductoDAL productoDAL;

        // GET: ProductoController
        public ActionResult Index()
        {
            List<Producto> productos;
            List<ProductViewModel> lista = new List<ProductViewModel>();
            productoDAL = new ProductoDAL();

            productos = productoDAL.GetAll().ToList();

            ProductViewModel productVM;

            foreach (var item in productos)
            {
                productVM = new ProductViewModel
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    PrecioBase = item.PrecioBase
                };
                lista.Add(productVM);
            }
            
            return View(lista);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            Producto producto;
            productoDAL = new ProductoDAL();
            producto = productoDAL.Get(id);
            
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                productoDAL = new ProductoDAL();
                
                productoDAL.Add(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            productoDAL = new ProductoDAL();

            Producto producto = productoDAL.Get(id);

            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                productoDAL = new ProductoDAL();

                productoDAL.Update(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            productoDAL = new ProductoDAL();
            
            Producto producto = productoDAL.Get(id);

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Producto producto)
        {
            try
            {
                productoDAL = new ProductoDAL();
                productoDAL.Remove(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
