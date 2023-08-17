using BondGadgetCollection.Data;
using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BondGadgetCollection.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();

            GadgetDAO gadgetDao = new GadgetDAO();

            gadgets = gadgetDao.FetchAll();


            return View("Index",gadgets);
        }

        public ActionResult Details(int Id)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            GadgetModel gadget = gadgetDao.FetchOne(Id);

            return View("Details", gadget);
        }

        public ActionResult Create()
        {
            return View("GadgetForm", new GadgetModel());
        }
        
        public ActionResult Edit(int id)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            GadgetModel gadget = gadgetDao.FetchOne(id);
            return View("GadgetForm" , gadget);
        }
        
        public ActionResult Delete(int id)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            gadgetDao.Delete(id);
            List<GadgetModel> gadget = gadgetDao.FetchAll();
            return View("Index",gadget );
        }
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            gadgetDao.CreateOrUpdate(gadgetModel);
            return View("Details", gadgetModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            List<GadgetModel> SearchResult = gadgetDao.SearchForName(searchPhrase);

            return View("Index", SearchResult);
        }
        public ActionResult SearchForDescription(string searchPhrase2)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            List<GadgetModel> SearchResult = gadgetDao.SearchForDescription(searchPhrase2);

            return View("Index", SearchResult);
        }

    }
}