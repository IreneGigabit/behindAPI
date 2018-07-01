using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvMasterDetails.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index() {
            return View();
        }

        public ActionResult getProductCategories() {
            List<Category> categories = new List<Category>();

            using (MyDatabaseEntities db = new MyDatabaseEntities()) {
                categories = db.Categories.OrderBy(a => a.CategoryName).ToList();
            }

            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult getProducts(int categoryID) {
            List<Product> products = new List<Product>();

            using (MyDatabaseEntities db = new MyDatabaseEntities()) {
                products = db.Products.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
            }

            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult save(OrderMaster order) {
            bool status = false;
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(order.OrderDateString, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate) {
                order.OrderDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(order);
            if (isValidModel) {
                using (MyDatabaseEntities dc = new MyDatabaseEntities()) {
                    dc.OrderMasters.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }

    }
}
