namespace WhatsAppChatbot.Model;

public class Order
{
    public int Id { get; set; }
    
    public string name { get; set; }
    
    public decimal Total { get; set; }

    public int CustomerId { get; set; }
    
    public virtual Customer Customer { get; set; }
}