using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	public class BookingHotelSearchController : Controller
	{
		public async Task<IActionResult> Index()
		{

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=EUR&dest_id=-1456928&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
				Headers =
	{
		{ "X-RapidAPI-Key", "f17dd9c7acmsh2c0383aa76c3580p161142jsn5e9959d34d68" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");  //index te hata alıyordum noktaları replace ettim boşluk olarak.. index te double işlmleri..
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.results);
			}
			
		}

        [HttpGet]
        public IActionResult GetCityDestID() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p) //Şehir ID bulma işlemleri.. search location kısmı 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"), //{p} yerine paris yazıyodu.. name = dışarıdan verilen değer oalrak bulacagım şehrin id sini
                Headers =
    {
        { "X-RapidAPI-Key", "cb5ee15da1mshb46d59d679af3abp1fe84cjsn167590fdc0cc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}
