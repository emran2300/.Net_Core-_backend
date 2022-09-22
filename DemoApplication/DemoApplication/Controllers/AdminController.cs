using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using DemoApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DemoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
         private readonly IRepo<Admin, int, bool> _adminRepo;
        public AdminController(IRepo<Admin, int, bool> AdminRepo)
        {
            _adminRepo=AdminRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data =await _adminRepo.Get();
            return Ok(data);
        }
    }
}
