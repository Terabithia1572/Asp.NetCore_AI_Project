using Asp.NetCore_AI_Project_03_RapidAPI.ViewModels;
using Newtonsoft.Json;

var client = new HttpClient();
List<APISeriesViewModel> apiSeriesViewModel = new();

var request = new HttpRequestMessage
{
    Method = HttpMethod.Get, //Methodun Türü
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"), //İstek yapılacak URL
    Headers = //istek nerden yapılıyor 1.si API KEy 2.si istek yapılacak Sunucu
    {
        { "x-rapidapi-key", "44a9b3ca28msh4dc1bc7bb828d5ap18c256jsn9125f1e0404c" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode(); //Başarılı bir istek yapıldığında
    var body = await response.Content.ReadAsStringAsync(); //İçeriği string olarak oku
    apiSeriesViewModel=JsonConvert.DeserializeObject<List<APISeriesViewModel>>(body); //İçeriği deserialize et
    foreach (var series in apiSeriesViewModel)
    {
        Console.WriteLine(series.title);
    }
    Console.WriteLine();
}
Console.ReadLine();