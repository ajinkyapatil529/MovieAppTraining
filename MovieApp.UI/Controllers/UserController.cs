using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using MovieApp.Entity;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _iConfiguration;
        public UserController(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }

        public async Task<IActionResult> ShowUserDetails()
        {
            using(HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "User/SelectUser";
                using(var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Can not fetch data";
                    }
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                //API URL:http://localhost:18518/api/User/Register
                StringContent body = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registred Successfully.";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Can not Register..!!";
                    }
                }
                return View();
            }
        }
    }


}

