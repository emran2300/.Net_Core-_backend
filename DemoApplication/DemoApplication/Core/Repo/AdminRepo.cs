using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DemoApplication.Repo
{
    public class AdminRepo : IRepo<Admin,int,bool>
    {
        private DemoDbContext db;
        public AdminRepo(DemoDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(Admin obj)
        {
            await db.Admins.AddAsync(obj);
            _ = db.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Admin>> Get()
        {
            return await db.Admins.ToListAsync();
        }

        public Task<Admin> Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin obj)
        {
            throw new NotImplementedException();
        }
    }
}
