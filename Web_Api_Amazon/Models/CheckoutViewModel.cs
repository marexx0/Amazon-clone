using System.ComponentModel.DataAnnotations;

namespace Web_Api_Amazon.Models;

public class CheckoutViewModel
{
    [Required]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = "United States";

    [Required]
    [Display(Name = "Street address")]
    public string AddressLine1 { get; set; } = string.Empty;

    [Display(Name = "Apartment, suite, unit, etc.")]
    public string? AddressLine2 { get; set; }

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    [Display(Name = "State/Province")]
    public string State { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Zip/Postal code")]
    public string PostalCode { get; set; } = string.Empty;

    [Display(Name = "Save this address for future orders")]
    public bool SaveForFutureOrders { get; set; }

    [Display(Name = "Order includes a gift")]
    public bool IncludeGift { get; set; }

    [Display(Name = "Shipping method")]
    public string ShippingMethod { get; set; } = "Standard";

    public bool IsSignedIn { get; set; }
    public List<CheckoutSummaryItemViewModel> Items { get; set; } = new();

    public decimal Subtotal => Items.Sum(item => item.Total);
    public decimal ShippingCost => string.Equals(ShippingMethod, "Express", StringComparison.OrdinalIgnoreCase) ? 9.99m : 0m;
    public decimal Total => Subtotal + ShippingCost;
}

public class CheckoutSummaryItemViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => UnitPrice * Quantity;
}