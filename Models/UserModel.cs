using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace DropShip.Models
{
    public class User
    {
    [Key]
    public int UserId {get;set;}

    [Required]
    [MinLength(2)]
    public string FirstName {get;set;}
    
    [Required]
    [MinLength(2)]
    public string LastName {get;set;}
    
    [Required]
    [EmailAddress]
    public string Email {get;set;}

    [DataType(DataType.Password)]
    [Required]
    public string Password {get;set;}

    //site controls
    public bool Admin {get;set;}

    //shipping info
    [DataType(DataType.PhoneNumber)]
    public string MobilePhone {get;set;}
    public string Street {get;set;}
    public string Postal {get;set;}
    public string City {get;set;}
    public string State {get;set;}
    //end
    public List<Order> Orders {get;set;}
    public List<Cart> Carts {get;set;}
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string Confirm {get;set;}
    }
}