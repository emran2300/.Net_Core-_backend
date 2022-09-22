using DemoApplication.Models;

namespace DemoApplication.Interface
{
    public interface IAuth
    {
        public LoginMatch Authenticate(string email, string password);
    }
}
