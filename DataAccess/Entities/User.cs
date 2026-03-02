using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Web_Api_Amazon.Entities  // <- тут твій namespace
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountType { get; set; }

        // Orders made by user
        public ICollection<Order> Orders { get; set; }

    // Cart items
    public ICollection<CartItem> CartItems { get; set; }

    // Favorite products
    public ICollection<FavoriteItem> FavoriteItems { get; set; }

    // Saved for later products
    public ICollection<SavedForLaterItem> SavedForLaterItems { get; set; }

}
