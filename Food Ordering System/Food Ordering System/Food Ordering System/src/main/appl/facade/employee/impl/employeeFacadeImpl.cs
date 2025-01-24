using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.model;
using Food_Ordering_System.src.main.data.account;
using Food_Ordering_System.src.main.data.employee.dao;

namespace Food_Ordering_System.src.main.appl.facade.employee.impl
{
    internal class employeeFacadeImpl : employeeFacade
    {
        private employeeDao employeeDao;

        public employeeFacadeImpl(employeeDao employeeDao) { this.employeeDao = employeeDao; }

        public Employee AddEmployee(Employee employee)
        {
            return employeeDao.AddEmployee(employee);
            throw new NotImplementedException();
        }
    }
}
