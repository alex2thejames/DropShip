using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace DropShip.Models
{
    public class Product
    {
    [Key]
    public int ProductId {get;set;}

    [Required]
    [MinLength(1)]
    public string ProductName {get;set;}

    [Required]
    [Range(0,999999999,
    ErrorMessage = "Must be a positive number")]
    public int ProductPrice {get;set;}

    public int NumberOfImgs {get;set;}

    public string ProductDescription {get;set;}

    public string ProductKeywords {get;set;}

    public string AddedBy {get;set;}

    public List<Order> Orders {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}