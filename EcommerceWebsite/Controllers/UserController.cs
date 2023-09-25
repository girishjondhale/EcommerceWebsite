using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        Product_CRUD pcrud;
        Ragister_CRUD ucrud;
        Login_CRUD lcrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public UserController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            pcrud = new Product_CRUD(this.configuration);
            ucrud = new Ragister_CRUD(this.configuration);
            lcrud = new Login_CRUD(this.configuration);
            this.env = env;
        }

        public ActionResult ShowProduct()
        {
            var model = pcrud.GetProduct();
            return View(model);
        }

        public ActionResult Ragister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ragister(Ragister rag)
        {
            try
            {
                int res = ucrud.AddRagister(rag);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Ragister rag)
        {
            try
            {

                var model = lcrud.GetLogin(rag.UserName, rag.Password);
                if (model.UId>0)
                {
                    HttpContext.Session.SetString("userid", model.UId.ToString());
                    HttpContext.Session.SetString("username", model.UserName.ToString());
                    HttpContext.Session.SetString("roleid", model.RoleId.ToString());
                    if (model.RoleId == 0)
                    {
                        return RedirectToAction("Index","Product");
                    }
                    else if (model.RoleId == 1)
                    {
                        return RedirectToAction(nameof(ShowProduct));
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();

            }
        }


        // GET: UserController
        public ActionResult Index()
        {
            return View(pcrud.GetProduct());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
        public ActionResult ProductDescription(int id)
        {
            var model = pcrud.GetProductById(id);
            return View(model);
        }
    }
}
