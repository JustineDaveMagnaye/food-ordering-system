using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.facade.account;
using Food_Ordering_System.src.main.appl.facade.account.impl;
using Food_Ordering_System.src.main.data.account;

namespace Food_Ordering_System.src.main
{
    internal class AccountInfoMgtApplication
    {
        private accountFacade accountFacade;

        public AccountInfoMgtApplication() {
            accountDao accountDaoImpl = new accountDaoImpl();
            this.accountFacade = new accountFacadeImpl(accountDaoImpl);
        }

        public accountFacade GetAccountFacade() => accountFacade;

    }
}
