using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaTecnicaNet.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Web.Pages
{
    public class IndexModel : PageModel
    {
        private HttpClient _client;
        private IConfiguration _configuration;

        private string _urlGetCustomers;
        private string _urlGetCustomerByName;

        private string _urlGetProducts;

        [BindProperty]
        public List<Product> Products { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public string CustomerPhone { get; set; }
        public IndexModel(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;

            Products = new List<Product>();

            Config();

            GetData().Wait();
         
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var url = string.Format(_urlGetCustomerByName, CustomerName);
            var respose = await _client.GetAsync(url);

            var result = await respose.Content.ReadAsStringAsync();

            var customer = JsonConvert.DeserializeObject<Customer>(result);

            if (customer == null || customer.CustomerId == 0)
            {
                var newCustomer = GetNewCustomer();

               
            }

            return RedirectToPage("/Privacy");
        }

        private async Task<Customer> GetNewCustomer()
        {
            var customer = new Customer
            {
                CustomerName = CustomerName,
                Phone = CustomerPhone
            };

            var json = JsonConvert.SerializeObject(customer);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var respose = await _client.PostAsync(_urlGetCustomers, data);

            var result = await respose.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Customer>(result);
        }

        private void Config()
        {
            var url = _configuration["Api:Url"];
            //Customer
            var urlCustomerByName = _configuration["Api:Services:Customers:GetCustomerByName"];
            _urlGetCustomers = url + _configuration["Api:Services:Customers:GetAll"];
            _urlGetCustomerByName = url + urlCustomerByName;

            //Products
            _urlGetProducts = url + _configuration["Api:Services:Products:GetAll"];
        }

        private async Task GetData()
        {
            var respose = await _client.GetAsync(_urlGetProducts);

            var result = await respose.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<List<Product>>(result);

            this.Products.AddRange(products);
        }
    }
}
