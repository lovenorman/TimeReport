using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
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

                var customer = JsonConvert.DeserializeObject<DetailsCustomerViewModel>(data);

                return View(customer);
            }

            return NotFound();
        }


        public IActionResult NewCustomer()
        {
            var model = new NewCustomerViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewCustomer(NewCustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = new
                {
                    Name = model.Name,
                    Address = model.Address
                };
     
                var json = JsonConvert.SerializeObject(customer);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(baseAddress + "api/customer", data);

                return RedirectToAction("Index");
            }
            return NotFound();
        }
        
        public IActionResult EditCustomer(int id)
        {
            //Var den ska hämta ifrån
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"api/customer/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                //Datan hämtas som Json
                string data = response.Content.ReadAsStringAsync().Result;

                //Deserializar till en "EitCustomerViewModel"
                var model = JsonConvert.DeserializeObject<EditCustomerViewModel>(data);

                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(int id, EditCustomerViewModel editCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new EditCustomerViewModel();
                newCustomer.Name = editCustomerViewModel.Name;
                newCustomer.Address = editCustomerViewModel.Address;

                var json = JsonConvert.SerializeObject(newCustomer);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(baseAddress + $"api/customer/{id}", data);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
