using EmployeeCardList.Data;
using EmployeeCardList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCardList.Controllers
{
    public class EmployeeCardListController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();

            EmployeeDAO employeeDao = new EmployeeDAO();

            employee = employeeDao.FetchAll();


            return View("Index", employee);
        }

        public ActionResult Details(int Id)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            EmployeeModel employee = employeeDao.FetchOne(Id);
            ViewBag.StrMsg = "Employee Card";
            return View("Details", employee);
        }

        public ActionResult Create()
        {
            ViewBag.StrMsg = "Create Employee Card!";
            return View("EmployeeForm", new EmployeeModel());
        }
        
        public ActionResult Edit(int id)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            EmployeeModel employee = employeeDao.FetchOne(id);
            ViewBag.StrMsg = "Edit Employee Card!";
            return View("EmployeeForm" , employee);
        }
        
        public ActionResult Delete(int id)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            employeeDao.Delete(id);
            List<EmployeeModel> employee = employeeDao.FetchAll();
            return View("Index", employee);
        }
        public ActionResult ProcessCreate(EmployeeModel employeeModel)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            employeeDao.CreateOrUpdate(employeeModel);
            ViewBag.StrMsg = "Saved Successfully!";
            return View("Details", employeeModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForEmployee(string searchPhrase)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            List<EmployeeModel> SearchResult = employeeDao.SearchForName(searchPhrase);

            return View("Index", SearchResult);
        }
        

    }
}