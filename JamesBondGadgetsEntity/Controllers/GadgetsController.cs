
using JamesBondGadgetsEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamesBondGadgetsEntity.Controllers
{
    public class GadgetsController : Controller
    { 

        private ApplicationDbContext context;

        public GadgetsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Gadgets
        public ActionResult Index()
        {

            List<GadgetModel> gadgets = context.Gadgets.ToList();

            return View("Index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);
            return View("Details", gadgets);
        }

        public ActionResult Create()
        {
            return View("GadgetForm");
        }
        
        public ActionResult Edit(int id)
        {
            GadgetModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);

            return View("GadgetForm", gadgets);
        }
        
        public ActionResult Delete(int id)
        {
            GadgetModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);
            context.Entry(gadgets).State = EntityState.Deleted;
            context.SaveChanges();

            return Redirect("/Gadgets");
        }
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {

            return View("Details", gadgetModel);
        }

        public ActionResult SearchForm(string searchPhrase)
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            var gadgets = from g in context.Gadgets
                          where g.Name.Contains(searchPhrase)
                          select g;

            return View("Index", gadgets);
        }
        public ActionResult SearchForDescription(string searchPhrase2)
        {
 

            return View("Index");
        }

    }
}