using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.impl
{
    public class UserRepository : IUserRepository
    {
        public User CheckEmailExisted(string email) => UserDAO.CheckEmailExisted(email);

        public User CheckPhoneExisted(string phone) => UserDAO.CheckPhoneExisted(phone);

        public List<User> GetUsers() => UserDAO.GetUsers();

        public void SaveUser(User user) => UserDAO.SaveUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);

        public User GetUserByUserID(int userId) => UserDAO.GetUserByUserID(userId);
    }
}
