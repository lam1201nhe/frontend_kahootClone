using BusinessObjects.Models;

namespace Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void SaveUser(User user);
        void UpdateUser(User user);
        User CheckEmailExisted(string email);
        User CheckPhoneExisted(string phone);
        User GetUserByUserID(int userId);
    }
}