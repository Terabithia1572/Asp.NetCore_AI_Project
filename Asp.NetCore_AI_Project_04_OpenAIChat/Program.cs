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
    }
}