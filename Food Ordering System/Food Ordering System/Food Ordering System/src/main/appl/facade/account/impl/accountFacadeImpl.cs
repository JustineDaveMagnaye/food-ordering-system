using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.model;
using Food_Ordering_System.src.main.data.account;

namespace Food_Ordering_System.src.main.appl.facade.account.impl
{
    internal class accountFacadeImpl : accountFacade
    {
        private accountDao accountDao;

        public accountFacadeImpl(accountDao accountDao) { this.accountDao = accountDao; }  
        public Account GetAccountByUsername(string username)
        {
            return accountDao.GetAccountByUsername(username);
            throw new NotImplementedException();
        }

        public int GetAccountCount()
        {
            return accountDao.GetAccountCount();
            throw new NotImplementedException();
        }

        public Account Register(Account account)
        {
            return accountDao.Register(account);
            throw new NotImplementedException();
        }
    }
}
