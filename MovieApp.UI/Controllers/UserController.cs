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
using System.Text;

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
            //fetch API, AXIOS API,HTTPClient
            //HTTP Req/response
            //using System.Net.Http.HTTPClient
            using (HttpClient client = new HttpClient())
            {
                //API URL:http://localhost:18518/api/User/SelectUsers
                string endpoint = _iConfiguration["WebApiUrl"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
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
                string endpoint = _iConfiguration["WebApiUrl"] + "User/Register";
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

