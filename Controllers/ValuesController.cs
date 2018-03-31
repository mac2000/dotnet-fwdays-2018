using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_fwdays_2018.Controllers
{
    public class ValuesController : Controller
    {
        [HttpGet]
        [Route("api/values/time")]
        public long Time() => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        [HttpGet]
        [Route("api/values/host")]
        public string Host() => Environment.MachineName;
    }
}
