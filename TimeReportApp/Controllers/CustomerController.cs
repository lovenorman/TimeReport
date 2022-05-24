using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TimeReportApp.Models;

namespace TimeReportApp.Controllers
{
    public class CustomerController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7125");
        HttpClient client;

        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        
        public IActionResult Index()//GET
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();

            //Resultate vi får från url vi angett sparas i response
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/customer").Result;
            
            //Om statuscoden är "success"
            if(response.IsSuccessStatusCode)
            {
                //Gör om resultatet till string och spara i "data"
                string data = response.Content.ReadAsStringAsync().Result;

                //Gör om stringen till en lista av typen "CustomerViewModel", sparas i listan som vi skapat ovan
                customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);

                return View(customerList);
            }
            return NotFound();
        }

        
        public IActionResult GetCustomerById(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"api/customer/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                var customer = JsonConvert.DeserializeObject<DetailsCustomerVIewModel>(data);

                return View(customer);
            }

            return NotFound();
        }
    }
}
