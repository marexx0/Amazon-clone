namespace Web_Api_Amazon.Models;

public class ProfileOrdersViewModel
{
    public List<ProfileOrderCardViewModel> Orders { get; set; } = new();
}

public class ProfileOrderCardViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Shipping { get; set; }
    public decimal Tax { get; set; }
    public decimal Total => Subtotal + Shipping + Tax;
    public OrderStatus Status { get; set; }

    public List<string> PreviewImageUrls { get; set; } = new();
    public List<ProfileOrderItemViewModel> Items { get; set; } = new();

    public string Location { get; set; } = "Vienna, Austria";

    public string PaymentLabel => "Paid";
    public string PaymentMethodTitle { get; set; } = "Line card";
    public string PaymentMethodSubtitle { get; set; } = "Visa ending in 4288, expires 08/26";

    public string DeliveryTitle { get; set; } = "Office";
    public string DeliveryAddress { get; set; } = "France, Paris, 75001, 15 Pl. Vendôme";

    public string StatusLabel => Status switch
    {
        OrderStatus.Completed => "Completed",
        OrderStatus.Shipped => "In Transit",
        OrderStatus.Processing => "In Transit",
        OrderStatus.New => "Processing",
        OrderStatus.Pending => "Pending",
        _ => "Processing"
    };
}

public class ProfileOrderItemViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => UnitPrice * Quantity;

    public string PropertyLabel { get; set; } = "Color";
    public string PropertyValue { get; set; } = "White";
}