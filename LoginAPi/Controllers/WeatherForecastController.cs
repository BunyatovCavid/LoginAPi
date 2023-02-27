using LoginAPi.Crud;
using LoginAPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Login login;
        public WeatherForecastController()
        {
            login = new Login();
        }
        [HttpGet]
        public string Get([FromQuery]LoginModel model)
        {
            var return_value = login.CheckLogin(model);
            return return_value;
        }
    }
}
