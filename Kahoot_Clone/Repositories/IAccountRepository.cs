﻿using BusinessObjects.Models;

namespace Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        void SaveAccount(Account account);
        Account FindAccountByUsername(string username);
        void AccountIsExisted(string username);
    }
}