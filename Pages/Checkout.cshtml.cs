using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Square;
using Square.Models;
using Square.Apis;
using Square.Exceptions;
using Square.Authentication;
using Square.Utilities;
using Square.Http;
using System.Linq;
using DropShipModels = DropShip.Models;
using DropShip.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace csharp_checkout.Pages
{
    public class CheckoutModel : PageModel
    {
        private DropShipModels.MyContext dbContext;

        private SquareClient client;
        private readonly string locationId;
        // public Square.Models.CreateCheckoutRequest createCheckoutRequest { get; set; }
        public CreateCheckoutRequest createCheckoutRequest {get;set;}

        public CheckoutModel( Microsoft.Extensions.Configuration.IConfiguration configuration, DropShipModels.MyContext context)
        {
            dbContext = context;
            
        // Get environment
            Square.Environment environment = configuration["AppSettings:Environment"] == "sandbox" ?
            Square.Environment.Sandbox : Square.Environment.Production;

        // Build base client
            client = new SquareClient.Builder()
            .Environment(environment)
            .AccessToken(configuration["AppSettings:AccessToken"])
            .Build();

            locationId = configuration["AppSettings:LocationId"];
        }

        public IActionResult OnPost()
        {
            ICheckoutApi checkoutApi = client.CheckoutApi;
            try
            {
                var rand = new Random();
                int rand1 = rand.Next(100000,999999);
                int id = HttpContext.Session.GetInt32("logID").GetValueOrDefault();
                DropShipModels.User CurrUser = dbContext.Users
                .FirstOrDefault(user => user.UserId == id);
                if(CurrUser != null){
                    var RetrievedCart = dbContext.Carts.Where(c => c.UserId == CurrUser.UserId)
                    .Include(carts => carts.P)
                    .ToList();
                    string OrderNumberTemp = id.ToString() + '-' + rand1.ToString();
                    string ProductBoughtListTemp = "";

                    List<OrderLineItem> lineItems = new List<OrderLineItem>();
                    foreach(var j in RetrievedCart){
                        Money ItemPrice = new Money.Builder()
                        .Amount(j.P.ProductPrice * 100)
                        .Currency("USD")
                        .Build();

                        OrderLineItem LineItem = new OrderLineItem.Builder(j.Quantity.ToString())
                        .Name(j.P.ProductName)
                        .BasePriceMoney(ItemPrice)
                        .Note("Order Number     " + OrderNumberTemp)
                        .Build();

                        lineItems.Add(LineItem);
                        dbContext.Carts.Remove(j);
                        dbContext.SaveChanges();
                        ProductBoughtListTemp += j.P.ProductName + " x " + j.Quantity +  ", ";
                    }
                    ProductBoughtListTemp = ProductBoughtListTemp.Remove(ProductBoughtListTemp.Length - 1, 1);
                    ProductBoughtListTemp = ProductBoughtListTemp.Remove(ProductBoughtListTemp.Length - 1, 1);
                    DropShipModels.Order newOrder = new DropShipModels.Order();
                    newOrder.UserId = id;
                    newOrder.OrderNumber = OrderNumberTemp.ToString();
                    newOrder.ProductBoughtList = ProductBoughtListTemp;
                    newOrder.Filled = false;
                    newOrder.ShippingMethod = "Standard";
                    dbContext.Orders.Add(newOrder);
                    dbContext.SaveChanges();
                // create line items for the order.

                // create Order object with line items
                Order order = new Order.Builder(locationId)
                .LineItems(lineItems)
                .Build();

                // create order request with order
                CreateOrderRequest orderRequest = new CreateOrderRequest.Builder()
                .Order(order)
                .Build();

                // create checkout request with the previously created order
                CreateCheckoutRequest createCheckoutRequest = new CreateCheckoutRequest.Builder(
                    Guid.NewGuid().ToString(),
                    orderRequest)
                .AskForShippingAddress(true)
                // .RedirectUrl("www.google.com")
                .PrePopulateBuyerEmail(CurrUser.Email)
                .MerchantSupportEmail("inflateLLC@google.com")
                .Build();
                // create checkout response, and redirect to checkout page if successful
                CreateCheckoutResponse response = checkoutApi.CreateCheckout(locationId, createCheckoutRequest);
                return Redirect(response.Checkout.CheckoutPageUrl);
                }

                else{
                    if(HttpContext.Session.GetString("TempCart") != null){
                        var cartStr = HttpContext.Session.GetString("TempCart");
                        List<List<int>> cart1  = JsonConvert.DeserializeObject<List<List<int>>>(cartStr);
                        string OrderNumberTemp = "0-" + rand1.ToString();
                        string ProductBoughtListTemp = "";

                        List<OrderLineItem> lineItems = new List<OrderLineItem>();
                        foreach(var k in cart1){
                            string ProdName = dbContext.Products.FirstOrDefault(p => p.ProductId == k[0]).ProductName;
                            Money ItemPrice = new Money.Builder()
                            .Amount(dbContext.Products.FirstOrDefault(p => p.ProductId == k[0]).ProductPrice * 100)
                            .Currency("USD")
                            .Build();

                            OrderLineItem LineItem = new OrderLineItem.Builder(k[1].ToString())
                            .Name(ProdName)
                            .BasePriceMoney(ItemPrice)
                            .Note("Order Number     " + OrderNumberTemp)
                            .Build();

                            lineItems.Add(LineItem);
                            ProductBoughtListTemp += ProdName + " x " + k[1].ToString() +  ", ";
                        }
                        DropShipModels.User tempUser = dbContext.Users.FirstOrDefault(user => user.Password == "Temp");
                        ProductBoughtListTemp = ProductBoughtListTemp.Remove(ProductBoughtListTemp.Length - 1, 1);
                        ProductBoughtListTemp = ProductBoughtListTemp.Remove(ProductBoughtListTemp.Length - 1, 1);
                        DropShipModels.Order newOrder = new DropShipModels.Order();
                        newOrder.UserId = tempUser.UserId;
                        newOrder.OrderNumber = OrderNumberTemp.ToString();
                        newOrder.ProductBoughtList = ProductBoughtListTemp;
                        newOrder.Filled = false;
                        newOrder.ShippingMethod = "Standard";
                        dbContext.Orders.Add(newOrder);
                        dbContext.SaveChanges();
                    // create line items for the order
                    // This example assumes the order information is retrieved and hard coded
                    // You can find different ways to retrieve order information and fill in the following lineItems object.

                    // create Order object with line items
                    Order order = new Order.Builder(locationId)
                    .LineItems(lineItems)
                    .Build();

                    // create order request with order
                    CreateOrderRequest orderRequest = new CreateOrderRequest.Builder()
                    .Order(order)
                    .Build();
                    // create checkout request with the previously created order
                    // var tempPerson = new Person();
                    CreateCheckoutRequest createCheckoutRequest = new CreateCheckoutRequest.Builder(
                        Guid.NewGuid().ToString(),
                        orderRequest)
                    .AskForShippingAddress(true)
                    .MerchantSupportEmail("inflateLLC@google.com")
                    .Build();
                    // create checkout response, and redirect to checkout page if successful
                    CreateCheckoutResponse response = checkoutApi.CreateCheckout(locationId, createCheckoutRequest);
                    return Redirect(response.Checkout.CheckoutPageUrl);
                    }
                    else {
                        return Redirect("/");
                    }
                }
            }
            catch (ApiException e)
            {
                return RedirectToPage("Error", new { error = e.Message});
            }
        }
    }
}
