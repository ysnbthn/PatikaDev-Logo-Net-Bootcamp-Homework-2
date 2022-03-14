﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet] // Add option to add app-version to header on swagger 
        public IActionResult Home()// [FromHeader(Name = "app-version")] string appVersion
        {
            return Ok("success");
        }

        [HttpPost("/login")]
        public IActionResult Login()
        {
            return Ok("success");
        }

        [HttpPost("/register")]
        public IActionResult Register()
        {
            return Ok("success");
        }

    }
}
