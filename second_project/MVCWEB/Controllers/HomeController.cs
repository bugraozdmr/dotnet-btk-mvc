using System.Text.Json.Serialization;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVCWEB.Controllers;

public class HomeController : Controller
{
    // programda başlatılmalı IHttp
    private readonly IHttpClientFactory _client;

    public HomeController(IHttpClientFactory client)
    {
        _client = client;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var client = _client.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7081/api/products");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // Newtonsoft.json
            var values = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonData);
            return View(values);
        }
        
        return View();
    }
}