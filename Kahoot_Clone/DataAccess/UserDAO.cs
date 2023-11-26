using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listUsers = context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }
        public static User GetUserByUserID(int userId)
        {
            User user = new User();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    user = context.Users.Where(u => u.UserId == userId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static void SaveUser(User user)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static User CheckEmailExisted(string email)
        {
            User user = new User();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    user = context.Users.SingleOrDefault(u => u.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static User CheckPhoneExisted(string phone)
        {
            User user = new User();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    user = context.Users.SingleOrDefault(u => u.Phone == phone);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

    }
}
