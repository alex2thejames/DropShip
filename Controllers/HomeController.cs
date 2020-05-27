using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DropShip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Square;
using Square.Models;
using Square.Apis;
using Square.Exceptions;
using Microsoft.Extensions.Configuration;

namespace DropShip.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult frontPage()
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(CurrUser != null){
            ViewBag.CurrUser = CurrUser;
            }
            ViewBag.AllProducts = dbContext.Products.ToList();
            return View();
        }

        [HttpGet("/register")]
        public IActionResult RegisterPage()
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(CurrUser != null){
                return Redirect("/");
            }
            return View();
        }

        [HttpGet("/product/{productQuery}")]
        public IActionResult ProductDisplay(string productQuery)
        {
            if(dbContext.Products.FirstOrDefault(p => p.ProductName == productQuery) == null)
            {
                return Redirect("/");
            }
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(CurrUser != null){
                ViewBag.CurrUser = CurrUser;
            }
            Product CurrProduct = dbContext.Products
            .FirstOrDefault(prod => prod.ProductName == productQuery);
            ViewBag.CurrProduct = CurrProduct;
            return View();
        }

        [HttpGet("/settings")]
        public IActionResult settingsPage()
        {   
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            ViewBag.CurrUser = CurrUser;
            ViewBag.AllUsers = dbContext.Users.ToList();
            return View();
        }

        [HttpGet("/settings/changepassword")]
        public IActionResult passwordUpdate()
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            ViewBag.CurrUser = CurrUser;
            return View();
        }

        [HttpGet("/myCart")]
        public IActionResult myCart()
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .Include(user => user.Carts)
            .ThenInclude(carts => carts.P)
            .FirstOrDefault(user => user.UserId == id);
            ViewBag.CurrUser = CurrUser;
            if(CurrUser == null){
                return Redirect("/");
            }
            return View("cartDisplay");
        }

        [HttpGet("/UnfilledOrders")]
        public IActionResult UnfilledOrders()
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .Include(user => user.Carts)
            .ThenInclude(carts => carts.P)
            .FirstOrDefault(user => user.UserId == id);
            ViewBag.CurrUser = CurrUser;
            if(CurrUser == null || CurrUser.Admin == false)
            {
                return Redirect("/");
            }
            // ViewBag.UnfilledOrders = dbContext.Orders.Where(o => o.Filled == false)
            // .Include(orders => orders.U)
            // // .ThenInclude(carts => carts.P)
            // .ToList();
            // ViewBag.UnfilledOrders
            List<DropShip.Models.Order> OrderList = new List<DropShip.Models.Order>(); 
            List<DropShip.Models.Order> OrderListTemp = dbContext.Orders.Where(o => o.Filled == false).ToList();
            foreach(var i in OrderListTemp)
            {
                bool tempContains = false;
                foreach(var j in OrderList)
                {
                    if(j.OrderNumber == i.OrderNumber)
                    {
                        tempContains = true;
                        break;
                    }
                }
                if(tempContains == false)
                {
                    OrderList.Add(i);
                }
            }
            ViewBag.UnfilledOrders = OrderList;
            return View("unfilledOrderDisplay");
        }

        
        // ███████ ██    ██ ███    ██  ██████ ████████ ██  ██████  ███    ██ ███████ 
        // ██      ██    ██ ████   ██ ██         ██    ██ ██    ██ ████   ██ ██      
        // █████   ██    ██ ██ ██  ██ ██         ██    ██ ██    ██ ██ ██  ██ ███████ 
        // ██      ██    ██ ██  ██ ██ ██         ██    ██ ██    ██ ██  ██ ██      ██ 
        // ██       ██████  ██   ████  ██████    ██    ██  ██████  ██   ████ ███████ 

        //login
        public IActionResult LoginProcess(Login logUser)
        {
            if(ModelState.IsValid)
            {   
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == logUser.Email);
                if(userInDb == null)
                {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                ViewBag.AllProducts = dbContext.Products.ToList();
                return View("frontPage");
                }
                var hasher = new PasswordHasher<Login>();

                var result = hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.Password);

                if(result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    ViewBag.AllProducts = dbContext.Products.ToList();
                    return View("frontPage");
                }

                else 
                {
                    HttpContext.Session.SetInt32("logID", userInDb.UserId);
                    return Redirect("/");
                }
            }
            else
            {   
                ViewBag.AllProducts = dbContext.Products.ToList();
                return View("frontPage");
            }
        }

        //register

        // [HttpGet("register")]
        // public IActionResult Register()
        // {
        //     return View();
        // }
        public IActionResult RegisterProcess(User newUser)
        {   
            if(ModelState.IsValid)
            {   
                if(dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("registerPage");
                }
                else 
                {
                    if(Regex.IsMatch(newUser.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"))
                    {
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                        dbContext.Users.Add(newUser);
                        dbContext.SaveChanges();
                        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);
                        HttpContext.Session.SetInt32("logID", userInDb.UserId);
                        return Redirect("/");
                    }
                
                    else
                    {
                        ModelState.AddModelError("Password", "Password Must Contain an Symbol, Number, and One Alphabetical Character");
                        return View("registerPage");
                    }
                }
            }
            else
            {
                return View("registerPage");
            }
        }


        //reset password. Needs work lol
        public IActionResult ResetPassword(Login sender)
        {
            if(dbContext.Users.FirstOrDefault(u => u.Email == sender.Email) != null)
                {
                    // MailMessage mm = new MailMessage();
                    // mm.Subject = "Password Recovery";
                    // mm.To.Add("alex2thejames@gmail.com");
                    // mm.From = new MailAddress("abc@gmail.com");
                    // mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", sender.Email, sender.Password);
                    // mm.IsBodyHtml = true;
                    // SmtpClient smtp = new SmtpClient();
                    // smtp.Host = "smtp.gmail.com";
                    // smtp.EnableSsl = true;
                    // NetworkCredential NetworkCred = new NetworkCredential();
                    // NetworkCred.UserName = "sender@gmail.com";
                    // NetworkCred.Password = "<Password>";
                    // smtp.UseDefaultCredentials = true;
                    // smtp.Credentials = NetworkCred;
                    // smtp.Port = 587;
                    // smtp.Send(mm);
                    return Json("Password has been sent to your email address.");
                }
            else
            {
                ModelState.AddModelError("Email", "Email does not exist!");
                return View("LoginPage");
            }
        }

        public IActionResult UpdateInfo(UpdateUser updatedUser)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            ViewBag.CurrUser = CurrUser;
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(ModelState.IsValid)
            {   
                if(dbContext.Users.FirstOrDefault(u => u.UserId != id && u.Email == updatedUser.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("settingsPage");
                }
                else
                {
                    CurrUser.FirstName = updatedUser.FirstName;
                    CurrUser.LastName = updatedUser.LastName;
                    CurrUser.Email = updatedUser.Email;
                    CurrUser.MobilePhone = updatedUser.MobilePhone;
                    CurrUser.Street = updatedUser.Street;
                    CurrUser.Postal = updatedUser.Postal;
                    CurrUser.City = updatedUser.City;
                    CurrUser.State = updatedUser.State;
                    CurrUser.UpdatedAt = updatedUser.UpdatedAt;
                    dbContext.Users.Update(CurrUser);
                    dbContext.SaveChanges();
                    return Redirect("/settings");
                }
                
            }
            else
            {   
                return View("settingsPage");
            }
        }

        public IActionResult UpdatePassword(UpdatePassword updatedUser)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            ViewBag.CurrUser = CurrUser;
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(ModelState.IsValid)
            {   

                var hasher = new PasswordHasher<UpdatePassword>();

                var result = hasher.VerifyHashedPassword(updatedUser, CurrUser.Password, updatedUser.OldPassword);

                var result2 = hasher.VerifyHashedPassword(updatedUser, CurrUser.Password, updatedUser.Password);

                if(result == 0)
                {
                    ModelState.AddModelError("OldPassword", "Old Password does not match your current password!");
                    return View("passwordUpdate");
                }
                else
                {
                    if(result2 == 0)
                    {
                        if(Regex.IsMatch(updatedUser.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"))
                            {
                                PasswordHasher<UpdatePassword> Hasher = new PasswordHasher<UpdatePassword>();
                                updatedUser.Password = Hasher.HashPassword(updatedUser, updatedUser.Password);
                                CurrUser.Password = updatedUser.Password;
                                dbContext.Users.Update(CurrUser);
                                dbContext.SaveChanges();
                                return Redirect("/settings");







                                ////password has been updated
                            }
                            else
                            {
                                ModelState.AddModelError("Password", "Password Must Contain an Symbol, Number, and One Alphabetical Character");
                                return View("passwordUpdate");
                            }
                    }
                    else
                        {
                            ModelState.AddModelError("Password", "New Password can not be the same as old password!");
                            return View("passwordUpdate");
                        }
                }
            }
            else
            {   
                return View("passwordUpdate");
            }
        }

        [HttpGet("/users/delete/{UserToDeleteId}")]
        public IActionResult DeleteUser(int UserToDeleteId)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(CurrUser.UserId == UserToDeleteId)
            {
                // List<Interest> InterestList = dbContext.Interests.Where(interest => interest.UserId == CurrUser.UserId).ToList();
                // foreach(var i in InterestList)
                // {
                //     dbContext.Interests.Remove(i);
                //     dbContext.SaveChanges();
                // }
                dbContext.Users.Remove(CurrUser);
                dbContext.SaveChanges();
                HttpContext.Session.Clear();
                return Redirect("/");
            }
            else
            {
                if(CurrUser.Admin == false)
                {
                    return Redirect("/");
                }
                else
                {
                    User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.UserId == UserToDeleteId);
                    // List<Interest> InterestList = dbContext.Interests.Where(interest => interest.UserId == RetrievedUser.UserId).ToList();
                    // foreach(var i in InterestList)
                    // {
                    //     dbContext.Interests.Remove(i);
                    //     dbContext.SaveChanges();
                    // }
                    if(RetrievedUser.Admin == true){
                        return Redirect("/settings");
                    }
                    dbContext.Users.Remove(RetrievedUser);
                    dbContext.SaveChanges();
                    return Redirect("/settings");
                }
            }
        }

        public IActionResult AddProduct(Product newProduct)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(CurrUser.Admin == true)
            {
                if(ModelState.IsValid)
                {   
                    if(dbContext.Products.FirstOrDefault(p => p.ProductName == newProduct.ProductName) != null)
                    {
                        ModelState.AddModelError("ProductName", "Product already exists!");
                        return Redirect("/settings");
                    }
                    else 
                    {
                            string FullName = CurrUser.FirstName + " " + CurrUser.LastName;
                            newProduct.AddedBy = FullName;
                            dbContext.Products.Add(newProduct);
                            dbContext.SaveChanges();
                            return Redirect("/settings");
                    }
                }
                else
                {
                    return Redirect("/settings");
                }
            }
            else
            {
                return Redirect("/");
            }
        }
        
        [HttpGet("/products/delete/{ProductToDeleteId}")]
        public IActionResult DeleteProduct(int ProductToDeleteId)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(CurrUser.Admin == false)
            {
                return Redirect("/");
            }
            else
            {
                Product RetrievedProduct = dbContext.Products.FirstOrDefault(product => product.ProductId == ProductToDeleteId);
                dbContext.Products.Remove(RetrievedProduct);
                dbContext.SaveChanges();
                return Redirect("/settings");
            }
        }

        public IActionResult UpdateProduct(UpdateProduct updatedProduct)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            ViewBag.CurrUser = CurrUser;
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(CurrUser.Admin == false)
            {
                return Redirect("/");
            }
            else
            {
                if(ModelState.IsValid)
                {   
                    // if(dbContext.Products.FirstOrDefault(p => p.ProductName == updatedProduct.ProductName) != null)
                    // {
                    //     ModelState.AddModelError("ProductName", "Name already exists!");
                    //     return Redirect("/settings");
                    // }
                    // else
                    // {
                    Product RetrievedProduct = dbContext.Products.FirstOrDefault(product => product.ProductName == updatedProduct.ProductName);
                    RetrievedProduct.ProductName = updatedProduct.ProductName;
                    RetrievedProduct.ProductDescription = updatedProduct.ProductDescription;
                    RetrievedProduct.ProductPrice = updatedProduct.ProductPrice;
                    RetrievedProduct.ProductKeywords = updatedProduct.ProductKeywords;
                    RetrievedProduct.NumberOfImgs = updatedProduct.NumberOfImgs;
                    RetrievedProduct.UpdatedAt = updatedProduct.UpdatedAt;
                    dbContext.Products.Update(RetrievedProduct);
                    dbContext.SaveChanges();
                    return Redirect("/settings");
                    // }
                }
                else
                {   
                    return Redirect("/settings");
                }
            }
        }
        public IActionResult AddToCart(Cart CartEntry)
        {
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(ModelState.IsValid)
            {   
                if(CurrUser == null)
                {
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");
                    System.Console.WriteLine("@@@@@@@@");












                    
                }
                if(CurrUser != null)
                {
                    if(dbContext.Carts.FirstOrDefault(c => c.UserId == CurrUser.UserId && c.ProductId == CartEntry.ProductId) != null)
                    {
                        Cart RetrievedCart = dbContext.Carts.FirstOrDefault(c => c.ProductId == CartEntry.ProductId && c.ProductId == CartEntry.ProductId);
                        RetrievedCart.Quantity += CartEntry.Quantity;
                        RetrievedCart.UpdatedAt = CartEntry.UpdatedAt;
                        dbContext.Carts.Update(RetrievedCart);
                        dbContext.SaveChanges();
                    }
                    else 
                    {
                            CartEntry.UserId = CurrUser.UserId;
                            dbContext.Carts.Add(CartEntry);
                            dbContext.SaveChanges();
                            return Redirect("/");
                    }
                }
                return Redirect("/");
            }
            else
            {
                return Redirect("/");
            }
        }
        public IActionResult SearchProductsAdmin(Search search1)
        {   
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(CurrUser.Admin == false){
                return Redirect("/");
            }
            ViewBag.CurrUser = CurrUser;
            ViewBag.AllUsers = dbContext.Users.ToList();
            if(search1.sTerm == null)
            {
                ViewBag.SearchedProducts = dbContext.Products;
            }
            else{
                ViewBag.SearchedProducts = dbContext.Products
                .Where(product => product.ProductKeywords.Contains(search1.sTerm) || product.ProductName.Contains(search1.sTerm)).ToList();
            }
            return View("settingsPage");
        }

        public IActionResult SearchOrdersAdmin(Search search1)
        {   
            int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
            User CurrUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == id);
            if(HttpContext.Session.GetInt32("logID") == null)
            {
                return Redirect("/");
            }
            if(CurrUser.Admin == false){
                return Redirect("/");
            }
            ViewBag.CurrUser = CurrUser;
            // ViewBag.SearchedOrders = dbContext.Orders.ToList();
            if(search1.sTerm == null || search1.sTerm == "%^&")
            {
                ViewBag.SearchedOrders = dbContext.Orders;
            }
            else{
                ViewBag.SearchedOrders = dbContext.Orders
                .Where(o => o.OrderNumber.ToString() == search1.sTerm || o.U.FirstName.Contains(search1.sTerm) || o.U.LastName.Contains(search1.sTerm) || o.CreatedAt.ToString("MM/dd/yyyy") == search1.sTerm).ToList();
                // .Where(o => o.OrderNumber.ToString() == search1.sTerm || o.CustomerName.Contains(search1.sTerm) || o.CreatedAt.ToString("mm/dd/yyyy") == search1.sTerm).ToList();
            }
            ViewBag.SearchTerm = search1.sTerm;
            if(search1.sTerm == null)
            {
                ViewBag.SearchTerm = "%^&";
            }
            return View("orderSearch");
        }

        public IActionResult FillOrder(int OrderNum, string sTerm2)
        {
            List<DropShip.Models.Order> OrderListTemp = dbContext.Orders.Where(o => o.OrderNumber == OrderNum).ToList();
            foreach(var i in OrderListTemp)
            {
                i.Filled = true;
                dbContext.SaveChanges();
            }
            if(sTerm2 == null)
            {
                return Redirect("/UnfilledOrders");
            }
            else
            {
                Search search2 = new Search();
                search2.sTerm = sTerm2;
                return SearchOrdersAdmin(search2);
            };
        }
        public IActionResult UnfillOrder(int OrderNum, string sTerm2)
        {
            List<DropShip.Models.Order> OrderListTemp = dbContext.Orders.Where(o => o.OrderNumber == OrderNum).ToList();
            foreach(var i in OrderListTemp)
            {
                i.Filled = false;
                dbContext.SaveChanges();
            }
            if(sTerm2 == null)
            {
                return Redirect("/UnfilledOrders");
            }
            else
            {
                Search search2 = new Search();
                search2.sTerm = sTerm2;
                return SearchOrdersAdmin(search2);
            };
        }

        //logout
        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
