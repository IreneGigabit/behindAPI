using DatatableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatatableCRUD.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		public ActionResult Index() {
			return View();
		}

		public ActionResult GetEmployees() {
			using (MyDatabaseEntities db = new MyDatabaseEntities()) {
				var employees = db.Employees.OrderBy(a => a.FirstName).ToList();
				return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public ActionResult Save(int id) {
			using (MyDatabaseEntities db = new MyDatabaseEntities()) {
				var v = db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
				return View(v);
			}
		}

		[HttpPost]
		public ActionResult Save(Employee emp) {
			bool status = false;
			if (ModelState.IsValid) {
				using (MyDatabaseEntities db = new MyDatabaseEntities()) {
					if (emp.EmployeeId > 0) {
						//Edit
						var v = db.Employees.Where(a => a.EmployeeId == emp.EmployeeId).FirstOrDefault();
						if (v != null) {
							v.FirstName = emp.FirstName;
							v.LastName = emp.LastName;
							v.EmailID = emp.EmailID;
							v.City = emp.City;
							v.Country = emp.Country;
						}
					} else {
						//Save
						db.Employees.Add(emp);
					}
					db.SaveChanges();
					status = true;
				}
			}

			return new JsonResult { Data = new { status = status } };
		}

		[HttpGet]
		public ActionResult Delete(int id) {
			using (MyDatabaseEntities db = new MyDatabaseEntities()) {
				var v = db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
				if (v != null) {
					return View(v);
				} else {
					return HttpNotFound();
				}
			}
		}

		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteEmployee(int id) {
			bool status = false;
			using (MyDatabaseEntities db = new MyDatabaseEntities()) {
				var v = db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
				if (v != null) {
					db.Employees.Remove(v);
					db.SaveChanges();
					status = true;
				}
			}
			return new JsonResult { Data = new { status = status } };
		}
	}
}
