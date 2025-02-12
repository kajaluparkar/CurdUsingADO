﻿using CurdUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace CurdUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBContextEmployee db = new DBContextEmployee();
            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    DBContextEmployee db = new DBContextEmployee();
                    bool check = db.AddEmployees(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Inserted SuccessFully !!!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }
                return View();

            }
            catch
            {
                return View();
            }   

        }

        public ActionResult Edit(int id)
        {
            DBContextEmployee db = new DBContextEmployee();
            var row = db.GetEmployees().Find(modal => modal.Id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id,Employee emp)
        {

            try
            {
                if (ModelState.IsValid == true)
                {
                    DBContextEmployee db = new DBContextEmployee();
                    bool check = db.UpdateEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Updated Successfully !!!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            catch { return View(); }


        }
        public ActionResult Delete(int id)
        {
            DBContextEmployee db = new DBContextEmployee();
            var row = db.GetEmployees().Find(modal => modal.Id == id);

            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id ,Employee emp)
        {
            try
            {
               
                    DBContextEmployee db = new DBContextEmployee();
                    bool check = db.DeleteEmployee(id);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Deleted Successfully !!!";
                        return RedirectToAction("Index");
                    }
                

                return View();

            }
            catch {
                return View(); 
            }
        }

        public ActionResult Details(int id)
        {
            DBContextEmployee db = new DBContextEmployee();
            var row = db.GetEmployees().Find(modal => modal.Id == id);

            return View(row);
        }
    }
}