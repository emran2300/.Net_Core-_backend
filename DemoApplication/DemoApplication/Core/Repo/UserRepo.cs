using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Core.Repo
{
    public class UserRepo : IRepo<User, int, bool>
    {
        private DemoDbContext db;
        public UserRepo(DemoDbContext db)
        {
            this.db = db;
        }
        public Task<bool> Create(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await db.Users.ToListAsync();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
