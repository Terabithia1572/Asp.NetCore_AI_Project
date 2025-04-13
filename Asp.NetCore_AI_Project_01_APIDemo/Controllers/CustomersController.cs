using Asp.NetCore_AI_Project_01_APIDemo.Context;
using Asp.NetCore_AI_Project_01_APIDemo.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_AI_Project_01_APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly APIContext _apiContext; //burada DP kullandık. Depency Injection ile APIContext sınıfını çağırdık.
      //  Dependency injection kaba tabir ile bir sınıfın/nesnenin bağımlılıklardan kurtulmasını amaçlayan
      //  ve o nesneyi olabildiğince bağımsızlaştıran bir programlama tekniği/prensibidir.

        public CustomersController(APIContext apiContext)
        {
            _apiContext = apiContext;
        } 


        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _apiContext.Customers.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _apiContext.Customers.Add(customer);
            _apiContext.SaveChanges();
            return Ok("Müşteri Başarıyla Eklendi..");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id )
        {
           var values= _apiContext.Customers.Find(id);
            _apiContext.Customers.Remove(values);
            _apiContext.SaveChanges();
            return Ok("Müşteri Başarıyla Silindi..");
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var values = _apiContext.Customers.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _apiContext.Update(customer);
            _apiContext.SaveChanges();
            return Ok("Müşteri Başarıyla Güncellendi..");
        } 
    }
}
