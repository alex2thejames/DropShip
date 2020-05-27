using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace DropShip.Models
{
    public class UpdateUser
    {
    [MinLength(2)]
    public string FirstName {get;set;}
    
    [MinLength(2)]
    public string LastName {get;set;}
    
    [EmailAddress]
    public string Email {get;set;}

    //shipping info
    [DataType(DataType.PhoneNumber)]
    public string MobilePhone {get;set;}
    public string Street {get;set;}
    public string Postal {get;set;}
    public string City {get;set;}
    public string State {get;set;}
    //end

    [DataType(DataType.Password)]
    public string Password {get;set;}

    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string Confirm {get;set;}
    }
}