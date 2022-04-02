using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    public class TipoDeCambioController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://currency-converter5.p.rapidapi.com/currency/convert?format=json&from=USD&to=CRC&amount=1"),
				Headers =
	{
		{ "X-RapidAPI-Host", "currency-converter5.p.rapidapi.com" },
		{ "X-RapidAPI-Key", "4c4bf45819msh35fa5072608ba65p143e19jsn55bc272e4d48" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
			}
			return View();
        }
    }
}
