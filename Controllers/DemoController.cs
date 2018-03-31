using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_fwdays_2018.Controllers
{
    public class DemoController : Controller
    {
        [HttpGet]
        [Route("api/demo/ping")]
        public string Ping() => "Pong";

        [HttpGet]
        [Route("api/demo/exit/{code}")]
        public void Exit(int code) => Environment.Exit(code);

        [HttpGet]
        [Route("api/demo/load")]
        public void Load()
        {
            var end = DateTime.Now.AddSeconds(10);
            while (end > DateTime.Now) {}
        }
    }
}
