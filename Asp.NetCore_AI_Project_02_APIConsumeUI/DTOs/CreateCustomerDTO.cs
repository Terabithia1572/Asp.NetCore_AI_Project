namespace Asp.NetCore_AI_Project_02_APIConsumeUI.DTOs
{
    public class CreateCustomerDTO
    {
        
        public string CustomerName { get; set; } // Müşteri Adı
        public string CustomerSurname { get; set; } // Müşteri Soyadı
        public decimal CustomerBalance { get; set; } // Müşteri Bakiyesi
    }
}
