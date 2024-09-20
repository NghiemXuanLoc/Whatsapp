using Microsoft.AspNetCore.Mvc;
using WhatsAppChatbot.Model;
using WhatsAppChatbot.Service;

namespace WhatsAppChatbot.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class WhatsAppController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly WhatsAppService _whatsAppService;

    public WhatsAppController(CustomerService customerService, WhatsAppService whatsAppService)
    {
        _customerService = customerService;
        _whatsAppService = whatsAppService;
    }

    [HttpPost]
    public IActionResult Test()
    {
        var body = Request.Form["Body"];
        
        var customer = _customerService.GetCustomerById(int.Parse(body));

        if (customer == null)
            return NotFound("Không tìm thấy khách hàng.");

        var response = $"Thông tin khách hàng {customer.Name}\n" +
                       $"Địa chỉ: {customer.Address}\n" +
                       $"Tín dụng: {customer.CreditAmount}";

        // Gửi phản hồi qua WhatsApp
        _whatsAppService.SendMessage("", response);

        return Ok();
        
        
    }
    
    
    [HttpPost]
    public IActionResult ReceiveMessage([FromBody] WhatsAppMessageModel model)
    {
        var customer = _customerService.GetCustomerById(model.CustomerId);

        if (customer == null)
            return NotFound("Không tìm thấy khách hàng.");

        var response = $"Thông tin khách hàng {customer.Name}\n" +
                       $"Địa chỉ: {customer.Address}\n" +
                       $"Tín dụng: {customer.CreditAmount}";

        // Gửi phản hồi qua WhatsApp
        _whatsAppService.SendMessage(model.From, response);

        return Ok();
    }
    
    
    [HttpGet]
    public IActionResult Test2()
    {
        Console.Write("Nghiem Xuan Loc");
        return Ok();
        
        
    }
}


