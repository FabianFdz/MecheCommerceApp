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
    public class FeedBackController : Controller
    {
        private IFeedback feedbackDAL;
        private FeedbackViewModel Convertir(Feedback feedback)
        {
            return new FeedbackViewModel 
            { 
                Id = feedback.Id,
                IdProducto = feedback.IdProducto,
                Calificacion = feedback.Calificacion,
                Comentario = feedback.Comentario
            
            };
        }
       
        // GET: FeedBackController
        public ActionResult Index()
        {
            IEnumerable<Feedback> lista;
            lista = feedbackDAL.GetAll();
            List<FeedbackViewModel> feedbacks = new List<FeedbackViewModel>();
            
            foreach (var item in lista)
            {


                feedbacks.Add(Convertir(item));
            }




            return View(feedbacks);
        }

        // GET: FeedBackController/Details/5
        public ActionResult Details(int id)
        {
            Feedback feedback = feedbackDAL.Get(id);
            FeedbackViewModel feedbackViewModel = Convertir(feedback);
            
            return View(feedbackViewModel);
        }

        // GET: FeedBackController/Create
        public ActionResult Create()
        {
            FeedbackViewModel feedback = new FeedbackViewModel { };
            IProductoDAL productoDAL = new ProductoDAL();
            feedback.Productos = productoDAL.GetAll().ToList();

            return View(feedback);
        }

        // POST: FeedBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            try
            {
                feedbackDAL.Add(feedback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedBackController/Edit/5
        public ActionResult Edit(int id)
        {
            FeedbackViewModel feedback = Convertir(feedbackDAL.Get(id));
            IProductoDAL productoDAL = new ProductoDAL();

            List<Producto> lista = productoDAL.GetAll().ToList();
            feedback.Productos = lista;

            return View(feedback);
        }

        // POST: FeedBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Feedback feedback)
        {
            try
            {
                feedbackDAL.Update(feedback);   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedBackController/Delete/5
        public ActionResult Delete(int id)
        {
            FeedbackViewModel feedback = Convertir(feedbackDAL.Get(id));
            IProductoDAL productoDAL = new ProductoDAL();

            List<Producto> lista = productoDAL.GetAll().ToList();
            feedback.Productos = lista;

            return View(feedback);
        }

        // POST: FeedBackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Feedback feedback)
        {
            try
            {
                feedbackDAL.Remove(feedback);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
