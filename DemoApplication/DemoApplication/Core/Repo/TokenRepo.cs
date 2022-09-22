using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Core.Repo
{
    public class TokenRepo : IRepo<Token,string,Token>
    {
        private DemoDbContext db;
        public TokenRepo(DemoDbContext db)
        {
            this.db = db;
        }

        public async Task<Token> Create(Token obj)
        {
            var re = await db.Tokens.AddAsync(obj);
            await db.SaveChangesAsync();
            return re.Entity;
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Token>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Token> Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Token obj)
        {
            var exist = db.Tokens.FirstOrDefault(x => x.AutoToken.Equals(obj.AutoToken));
            if(exist != null)
            {
                db.Entry(exist).CurrentValues.SetValues(obj);
                _ = db.SaveChanges();
                return true;
            }
            return false;
        }

        public Token CreateAt(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
