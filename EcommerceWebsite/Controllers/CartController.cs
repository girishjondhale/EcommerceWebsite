using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    public class CartController : Controller
    {
        IConfiguration configuration;
        Product_CRUD productCrud;
        Ragister_CRUD registerCrud;
        CartCRUD cartCRUD;
        public CartController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new Product_CRUD(this.configuration);
            cartCRUD = new CartCRUD(this.configuration);
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }




        // Get: CartController/Create
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            try
            {
                Cart cart = new Cart();
                string uid = HttpContext.Session.GetString("userid");
                cart.Uid = Convert.ToInt32(uid);
                cart.Id = id;
                cart.Quantity = 1;
                int result = cartCRUD.AddTOCart(cart);
                if (result == 1)
                    return RedirectToAction(nameof(ViewCart));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CartController/Edit/5

        public ActionResult ViewCart()
        {
            string uid = HttpContext.Session.GetString("userid");
            var model = cartCRUD.ViewCart(Convert.ToInt32(uid));

            return View(model);
        }


        // GET: CartController/Delete/5
        public ActionResult RemoveCart(int id)
        {


            try
            {
                var result = cartCRUD.DeleteCart(id);

                return RedirectToAction(nameof(ViewCart));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


    }
}
 

