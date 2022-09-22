using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Repo
{
    public class LoginMatchRepo : IAuth
    {
        private DemoDbContext db;
        public LoginMatchRepo(DemoDbContext db)
        {
            this.db = db;
        }

        public LoginMatch Authenticate(string email, string password)
        {
            return db.LoginMatches.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

    }
}
