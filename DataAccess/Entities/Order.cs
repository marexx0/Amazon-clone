using Web_Api_Amazon.Entities;
public class Order
{
    public int Id { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }

    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    // Checkout snapshot fields
    public string ShippingMethod { get; set; } = "Standard";
    public string? ShippingAddressLine1 { get; set; }
    public string? ShippingAddressLine2 { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? ShippingCountry { get; set; }

    // Payment snapshot fields (store only safe card metadata)
    public string PaymentMethod { get; set; } = "CreditCard";
    public string? PaymentCardLast4 { get; set; }
    public string? PaymentCardExpiry { get; set; }
    public string? PaymentCardholderName { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
