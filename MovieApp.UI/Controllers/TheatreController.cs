using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class TheatreController : Controller
    {
        IConfiguration _iConfiguration;
        public TheatreController(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }

        public async Task<IActionResult> ShowTheatre()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "Theatre/Select";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(data);
                        return View(theatreModel);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTheatre()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTheatre(TheatreModel theatreModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
            string endpoint = _iConfiguration["WebApiUrl"] + "Theatre/Add";
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theatre Added ";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Can not add";
                    }
                }
                return View();
            }
        }


        public async Task<IActionResult> DeleteTheatre(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "Theatre/GetTheatreById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteTheatre(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent body = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "Theatre/DeleteTheatre?theatreId=" + theatreModel.TheatreId;
                using (var response = await client.DeleteAsync(endpoint))//,body
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deletion Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Deletion Unsuccessful";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> UpdateTheatre(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "Theatre/GetTheatreById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateTheatre(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Updation Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration Unsuccessful";
                    }
                }
            }
            return View();
        }

    }
}
