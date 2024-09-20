namespace WhatsAppChatbot.Model;

public class Customer
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public decimal CreditAmount { get; set; }
    
    public List<Order> Orders { get; set; }
}