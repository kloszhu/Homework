
using HomeWork.Service.Customer;
using Microsoft.AspNetCore.Mvc;
namespace HomeWork.API.Controllers;

[ApiController]

public class CustomerController : ControllerBase
{

    private ICustomerService customerService;

    public CustomerController(ICustomerService customerService)
    {
        this.customerService = customerService;
    }

    /// <summary>
    /// 1Update Score
    /// </summary>
    /// <returns></returns>
    [HttpPost("/customer/{customerid}/score/{score}")]
    public IActionResult UpdateScore([FromRoute]long customerid, [FromRoute] int score )
    {
        if (score>1000)
        {
            throw new Exception("out of range ");
        }
        else if (score<-1000)
        {
            throw new Exception("out of range ");
        }
        return Ok(customerService.UpdateScore(customerid, score));
    }
}