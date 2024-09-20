using WhatsAppChatbot.Model;

namespace WhatsAppChatbot.Controller;

public class CustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public Customer? GetCustomerById(int customerId)
    {
        return _context.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public List<Order> GetCustomerOrders(int customerId)
    {
        return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
    }
}
