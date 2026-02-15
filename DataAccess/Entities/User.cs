using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class User : IdentityUser
{
    public string?FirstName { get; set; }
    public string? LastName { get; set; }
    public string? AccountType { get; set; }

    // Orders made by user
    public ICollection<Order> Orders { get; set; }

    // Cart items
    public ICollection<CartItem> CartItems { get; set; }
    
}
