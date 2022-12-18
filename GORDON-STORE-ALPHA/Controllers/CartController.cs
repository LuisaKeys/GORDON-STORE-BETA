using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persistencia.Context;

using GORDON_STORE_ALPHA.Models.Cart;
using GORDON_STORE_ALPHA.Models;
using GORDON_STORE_ALPHA.Models.ViewModels;
using Modelo.Cadastro;
using GORDON_STORE_ALPHA.Context;

namespace GORDON_STORE_ALPHA.Controllers
{
    public class CartController : Controller
    {
        private ContextCart context = new ContextCart();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            // Init the cart list
            var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            // Check if cart is empty
            if (cart.Count == 0 || Session["cart"] == null)
            {
                ViewBag.Message = "Your cart is empty.";
                return View();
            }

            // Calculate total and save to ViewBag

            double total = 0;

            foreach (var item in cart)
            {
                total += item.Total;
            }

            ViewBag.GrandTotal = total;

            // Return view with list
            return View(cart);
        }
        public ActionResult CartPartial()
        {
            // Init CartVM
            CartVM model = new CartVM();

            // Init quantity
            int qty = 0;

            // Init price
            double preco = 0;

            // Check for cart session
            if (Session["cart"] != null)
            {
                // Get total qty and price
                var list = (List<CartVM>)Session["cart"];

                foreach (var produto in list)
                {
                    qty += produto.Quantidade;
                    preco += produto.Quantidade * produto.Preco;
                }
                model.Quantidade = qty;
                model.Preco = preco;
            }
            else
            {
                // Or set qty and price to 0
                model.Quantidade = 0;
                model.Preco = 0;
            }

            // Return partial view with model
            return PartialView(model);
        }
        public ActionResult AddToCartPartial(long id)
        {
            // Init CartVM list
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            // Init CartVM
            CartVM model = new CartVM();

            using (EFContext context = new EFContext())
            {
                // Get the product
                Produto produto = context.Produtos.Find(id);

                // Check if the product is already in cart
                var produtoInCart = cart.FirstOrDefault(x => x.ProdutoId == id);

                // If not, add new
                if (produtoInCart == null)
                {
                    cart.Add(new CartVM()
                    {
                        ProdutoId = produto.ProdutoId,
                        ProdutoNome = produto.Nome,
                        Quantidade = 1,
                        Preco = produto.Preco,
                        Image = produto.NomeArquivo
                    });
                }
                else
                {
                    // If it is, increment
                    produtoInCart.Quantidade++;
                }
            }

            // Get total qty and price and add to model

            int qty = 0;
            double preco = 0;

            foreach (var item in cart)
            {
                qty += item.Quantidade;
                preco += item.Quantidade * item.Preco;
            }

            model.Quantidade = qty;
            model.Preco = preco;

            // Save cart back to session
            Session["cart"] = cart;

            // Return partial view with model
            return PartialView(model);
        }

        // GET: /Cart/IncrementProduct
        public JsonResult IncrementProduct(long produtoId)
        {
            // Init cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (EFContext context = new EFContext())
            {
                // Get cartVM from list
                CartVM model = cart.FirstOrDefault(x => x.ProdutoId == produtoId);

                // Increment qty
                model.Quantidade++;

                // Store needed data
                var result = new { qty = model.Quantidade, preco = model.Preco };

                // Return json with data
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: /Cart/DecrementProduct
        public ActionResult DecrementProduct(long produtoId)
        {
            // Init cart
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (EFContext context = new EFContext())
            {
                // Get model from list
                CartVM model = cart.FirstOrDefault(x => x.ProdutoId == produtoId);

                // Decrement qty
                if (model.Quantidade > 1)
                {
                    model.Quantidade--;
                }
                else
                {
                    model.Quantidade = 0;
                    cart.Remove(model);
                }

                // Store needed data
                var result = new { qty = model.Quantidade, price = model.Preco };

                // Return json
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: /Cart/RemoveProduct
        public void RemoveProduct(long produtoId)
        {
            // Init cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (EFContext context = new EFContext())
            {
                // Get model from list
                CartVM model = cart.FirstOrDefault(x => x.ProdutoId == produtoId);

                // Remove model from list
                cart.Remove(model);
            }
        }

        public ActionResult PaypalPartial()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            return PartialView(cart);
        }

        // POST: /Cart/MakeOrder
        [HttpPost]
        public void MakeOrder()
        {
            // Get cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            // Get username
            string username = User.Identity.Name;

            int orderId = 0;

            //using (EFContext context = new EFContext())
            //{

                // Init OrderDTO
                Order orderDTO = new Order();

                // Get user id
                var q = db.Users.FirstOrDefault(x => x.Email == username);
                string userId = q.Id;

                // Add to OrderDTO and save
                orderDTO.UserId = userId;
                orderDTO.CreatedAt = DateTime.Now;

                context.Orders.Add(orderDTO);

                context.SaveChanges();

                // Get inserted id
                orderId = orderDTO.OrderId;

                // Init OrderDetailsDTO
                OrderDetails orderDetailsDTO = new OrderDetails();

                // Add to OrderDetailsDTO
                foreach (var item in cart)
                {
                    orderDetailsDTO.OrderId = orderId;
                    orderDetailsDTO.UserId = userId;
                    orderDetailsDTO.ProdutoId = item.ProdutoId;
                    orderDetailsDTO.Quantidade = item.Quantidade;

                    context.OrderDetails.Add(orderDetailsDTO);

                    context.SaveChanges();
                }
            //}

            //// Email admin
            //var client = new SmtpClient("smtp.mailtrap.io", 2525)
            //{
            //    Credentials = new NetworkCredential("37e1ec9ba32cc9", "19e410e27f856e"),
            //    EnableSsl = true
            //};
            //client.Send("admin@example.com", "admin@example.com", "New Order ", "You a new order. Order SN is: " + orderId);



            // Reset session
            Session["cart"] = null;
        }
    }
}