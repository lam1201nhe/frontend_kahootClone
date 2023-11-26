using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.impl
{
    public class AccountRepository : IAccountRepository
    {
        public void AccountIsExisted(string username) => AccountDAO.AccountIsExisted(username);

        public Account FindAccountByUsername(string username) => AccountDAO.FindAccountByUsername(username);

        public List<Account> GetAccounts() => AccountDAO.GetAccounts();

        public void SaveAccount(Account account) => AccountDAO.SaveAccount(account);
    }
}
