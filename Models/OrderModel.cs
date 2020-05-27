using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DropShip.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderNumber {get;set;}

        [Required]
        public int Quantity {get;set;}
        
        //if no account created
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
        //end

        [Required]
        public bool Filled {get;set;}

        [Required]
        public string ShippingMethod {get;set;}

        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public User U { get; set; }
        public Product P { get; set; }
    }
}