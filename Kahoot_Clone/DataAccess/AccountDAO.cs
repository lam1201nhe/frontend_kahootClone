using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        public static List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listAccounts = context.Accounts.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAccounts;
        }

        public static void SaveAccount(Account account)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Account FindAccountByUsername(string username)
        {
            var account = new Account();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    account = context.Accounts.Where(a => a.Username == username).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public static bool AccountIsExisted(string username)
        {
            var accountExisted = false;
            try
            {
                using (var context = new CloneKahootContext())
                {
                    accountExisted = context.Accounts.Any(a => a.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountExisted;
        }

    }
}
