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
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }

    // Changed to a list to support multiple images
    public List<string> PreviewImageUrls { get; set; } = new();

    public string Location { get; set; } = "Vienna, Austria";

    public string PaymentLabel => "Paid";

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