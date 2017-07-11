using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            throw new NotImplementedException();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            var contact = new AzureWebApp.Models.ContactViewModel();
            return View(contact);
        }
        [HttpPost]
        public async  Task<ActionResult> Contact(AzureWebApp.Models.ContactViewModel viewModel)
        {
            //  ViewBag.Message = "Your contact page.";
            using (var htpClient =  new HttpClient())
            {
                await htpClient.PostAsync("https://prod-23.southcentralus.logic.azure.com:443/workflows/6da057d6550f4cd4966af7c90763c466/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=TvYvuAvNs0Np_Kh8nMtKHwQA4dyJolNl_BMugKTt8j4", new StringContent(JsonConvert.SerializeObject(viewModel),System.Text.Encoding.UTF8,"application/json"));


            }

            return View();
        }
    }
}