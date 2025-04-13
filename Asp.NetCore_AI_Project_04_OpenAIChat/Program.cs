using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "burayakeygelecek";
        Console.WriteLine("Lütfen bir soru girin: (örnek 'Merhaba Bugün Hava İzmir'de kaç derece ?')");

        var prompt = Console.ReadLine();
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization",$"Bearer{apiKey}");
        var requestBody = new
        {
            model = "gpt-3.5-turbo", // Modeli belirtiyoruz
            messages = new[] // // Mesajları belirtiyoruz
            {
                new { role = "system", content = "Sen bir yapay zeka asistanısın." }, // Sistem mesajı
                new { role = "user", content = prompt } // Kullanıcıdan gelen mesajı ekliyoruz
            },
            max_tokens = 100, // Yanıtın maksimum token sayısını belirtiyoruz
            temperature = 0.7 // Yanıtın rastgeleliğini belirtiyoruz (0-1 arası değer alır)
        };
        var json = JsonSerializer.Serialize(requestBody); // İsteği JSON formatına çeviriyoruz
        var content=new StringContent(json, System.Text.Encoding.UTF8, "application/json"); // JSON içeriğini StringContent'e çeviriyoruz

        try
        {
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content); 
            var responseString = await response.Content.ReadAsStringAsync(); // Yanıtı string olarak alıyoruz
            if(response.IsSuccessStatusCode)
            {
                var result=JsonSerializer.Deserialize<JsonElement>(responseString); // Yanıtı JSON elementine çeviriyoruz
                var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString(); // Yanıtı alıyoruz
                Console.WriteLine("Yanıt: " + answer); // Yanıtı ekrana yazdırıyoruz
            }
            else
            {
                Console.WriteLine("Hata: " + response.StatusCode); // Hata durumunda durumu ekrana yazdırıyoruz
                Console.WriteLine("Yanıt: " + responseString); // Hata durumunda yanıtı ekrana yazdırıyoruz
            }
        }
        catch (Exception)
        {

          Console.WriteLine("Bir hata oluştu. Lütfen API anahtarınızı kontrol edin."); // Hata durumunda mesaj veriyoruz
        }
    }
}