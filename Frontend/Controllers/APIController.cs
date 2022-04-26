using ClienteAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class APIController : Controller
    {
        // GET: APIController
        public ActionResult tipoCambio()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("https://v6.exchangerate-api.com/v6/4da28635168d41f9ab7ec247/pair/USD/CRC/");
                response.EnsureSuccessStatusCode();                
                var content = response.Content.ReadAsStringAsync().Result;
                
                
                var tipoCambio = JsonConvert.DeserializeObject<Models.TipoCambio>(content);
                return View(tipoCambio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: APIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: APIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIController/Create
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

        // GET: APIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: APIController/Edit/5
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

        // GET: APIController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APIController/Delete/5
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
