using BusinessObjects.Models;

namespace Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        void SaveAccount();
        void FindAccountByUsername(string username);
        void AccountIsExisted(string username);
    }
}