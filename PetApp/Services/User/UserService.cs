using PetApp.Data;
using System.Text;

namespace PetApp.Services.User
{
    public class UserService : IUserService
    {

        private readonly PetAppContext _context;
        public UserService(PetAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ValidateUser(string username, string password)
        {
            var hashedPassword = Encoding.UTF8.GetBytes(password);

            var user = _context.User
                .FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user == null)
                return false;
            return true;
        }
    }
}
