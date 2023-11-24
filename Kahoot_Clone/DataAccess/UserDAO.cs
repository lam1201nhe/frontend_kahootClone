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

        public static bool CheckEmailExisted(string email)
        {
            bool userExists = false;
            try
            {
                using (var context = new CloneKahootContext())
                {
                    userExists = context.Users.Any(u => u.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userExists;
        }

        public static bool CheckPhoneExisted(string phone)
        {
            bool userExists = false;
            try
            {
                using (var context = new CloneKahootContext())
                {
                    userExists = context.Users.Any(u => u.Phone == phone);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userExists;
        }

    }
}
