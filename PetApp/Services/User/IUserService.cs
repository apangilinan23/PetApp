namespace PetApp.Services.User
{
    public interface IUserService
    {
        public bool ValidateUser(string username, string password);
    }
}
