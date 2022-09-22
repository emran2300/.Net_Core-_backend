using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Services
{
    public class AdminService
    {
        private readonly DemoDbContext db;
        private readonly IRepo<Admin,int,bool> AdminRepo;

        //public async Task<IActionResult> GetAdmin()
        //{
        //    //var data = await AdminRepo.Get();
        //    //var sdata = new List<AdminModel>();
        //    //foreach(var item in data)
        //    //{
        //    //    sdata.Add(new AdminModel()
        //    //    {
        //    //        Id = item.Id,
        //    //        Name = item.Name,
        //    //        Email = item.Email,
        //    //        Password = item.Password,
        //    //        Type = item.Type,

        //    //    });
        //    //}

        //    //return (IActionResult)data;
        //}
    }
}
