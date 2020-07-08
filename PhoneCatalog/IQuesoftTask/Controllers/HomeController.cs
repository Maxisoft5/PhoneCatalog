using IQuesoftTask.DAL.EF;
using IQuesoftTask.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace IQuesoftTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProducts()
        {
            using (CatalogDbContext context = new CatalogDbContext())
            {
                List<Product> products = context.Set<Product>().ToList();
                return Json(new { data = products }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSellers()
        {
            using (CatalogDbContext context = new CatalogDbContext())
            {
                List<Seller> sellers = context.Set<Seller>().ToList();

                return Json(new { data = sellers }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBranches()
        {
            using (CatalogDbContext context = new CatalogDbContext())
            {
                List<Branch> branches = context.Branches.ToList<Branch>();
                return Json(new { data = branches }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPurchases()
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                List<Purchase> empList = db.Purchases.ToList<Purchase>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddEditProduct(int id = 0)
        {
            if (id == 0)
                return View(new Product());
            else
            {
                using (CatalogDbContext db = new CatalogDbContext())
                {
                    return View(db.Products.Where(x => x.Id == id).FirstOrDefault<Product>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddEditProduct(Product product)
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddEditBranch(int id = 0)
        {
            if (id == 0)
                return View(new Branch());
            else
            {
                using (CatalogDbContext db = new CatalogDbContext())
                {
                    return View(db.Branches.Where(x => x.Id == id).FirstOrDefault<Branch>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddEditBranch(Branch branch)
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddEditSeller(int id = 0)
        {
            if (id == 0)
                return View(new Seller());
            else
            {
                using (CatalogDbContext db = new CatalogDbContext())
                {
                    return View(db.Sellers.Where(x => x.Id == id).FirstOrDefault<Seller>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddEditSeller(Seller seller)
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                db.Sellers.Add(seller);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddEditPurchase(int id = 0)
        {
            if (id == 0)
                return View(new Purchase());
            else
            {
                using (CatalogDbContext db = new CatalogDbContext())
                {
                    return View(db.Purchases.Where(x => x.Id == id).FirstOrDefault<Purchase>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddEditPurchase(Purchase purchase)
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (CatalogDbContext db = new CatalogDbContext())
            {
                Product product = db.Products.Where(x => x.Id == id).FirstOrDefault<Product>();
                db.Products.Remove(product);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [ValidateInput(false)]
        public ActionResult PurchasePartial()
        {
            return PartialView();
        }
        [ValidateInput(false)]
        public ActionResult SellerPartial()
        {
            return PartialView();

        }
        [ValidateInput(false)]
        public ActionResult ProductPartial()
        {
            return PartialView();
        }
        [ValidateInput(false)]
        public ActionResult BranchPartial()
        {
            return PartialView();
        }

    }
}