using BusinessObjects.Models;

namespace Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void SaveUser(User user);

    }
}