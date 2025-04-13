using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_AI_Project_02_APIConsumeUI.Controllers
{
    public class CustomerController : Controller
    {

        //Burada bizim bir DTO'ya ihtiyacımız var neden peki çünkü API kısmında verilerimiz JSON türünde tutuluyor.
        //Bizim API alanında bulunan verilerle bir eşleştirme yapmamız gerekiyor burada tam olarak bize bir DTO lazım olacak.
        //DTO'yu oluşturduktan sonra API'den aldığımız verileri bu DTO'ya map edeceğiz.

        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
