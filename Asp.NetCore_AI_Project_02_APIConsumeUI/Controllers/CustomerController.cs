using Asp.NetCore_AI_Project_02_APIConsumeUI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp.NetCore_AI_Project_02_APIConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //----------------------------------------------------------------------------------------------------------
        //Burada bizim bir DTO'ya ihtiyacımız var neden peki çünkü API kısmında verilerimiz JSON türünde tutuluyor.
        //Bizim API alanında bulunan verilerle bir eşleştirme yapmamız gerekiyor burada tam olarak bize bir DTO lazım olacak.
        //DTO'yu oluşturduktan sonra API'den aldığımız verileri bu DTO'ya map edeceğiz.
        //----------------------------------------------------------------------------------------------------------
        public async Task< IActionResult> CustomerList()
        {
            var client = _httpClientFactory.CreateClient(); //burada bir client oluşturuyoruz istek yani
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Customers"); //burada API'den alacağımız cevabın yolunu yazıyoruz
                                                                                    //responseMessage adında bir değişken oluşturuyoruz ve bu değişkene API'den gelen cevabı atıyoruz
              if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //burada gelen cevabı string türünde okuyoruz response mesajın içindeki datayı okuyacak
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDTO>>(jsonData); //burada gelen cevabı deserialize ediyoruz yani JSON'dan C# nesnesine çeviriyoruz
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }
    }
}
