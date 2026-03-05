namespace Web_Api_Amazon.Models;

public class OrderCompleteViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = "Standard";
    public string PaymentMethod { get; set; } = "CreditCard";
    public string TransactionId { get; set; } = string.Empty;
    public List<OrderCompleteItemViewModel> Items { get; set; } = new();

    public decimal Subtotal => Items.Sum(item => item.LineTotal);
    public decimal ShippingCost => string.Equals(ShippingMethod, "Express", StringComparison.OrdinalIgnoreCase) ? 9.99m : 0m;
    public decimal Total => Subtotal + ShippingCost;
    public DateTime EstimatedDeliveryDate => OrderDate.AddDays(string.Equals(ShippingMethod, "Express", StringComparison.OrdinalIgnoreCase) ? 3 : 6);

    public string DisplayPaymentMethod => PaymentMethod switch
    {
        "PayPal" => "PayPal",
        "ApplePay" => "Apple Pay",
        _ => "Credit / debit card"
    };
}

public class OrderCompleteItemViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => UnitPrice * Quantity;
}

public class OrderCompletionContext
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = "Standard";
    public string PaymentMethod { get; set; } = "CreditCard";
}