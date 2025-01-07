using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.facade.employee;
using Food_Ordering_System.src.main.appl.facade.employee.impl;
using Food_Ordering_System.src.main.data.employee.dao;
using Food_Ordering_System.src.main.data.employee.dao.impl;

namespace Food_Ordering_System.src.main
{
    internal class EmployeeInfoMgtApplication
    {
        private employeeFacade employeeFacade;

        public EmployeeInfoMgtApplication()
        {
            employeeDao employeeDaoImpl = new employeeDaoImpl();
            this.employeeFacade = new employeeFacadeImpl(employeeDaoImpl);
        }

        public employeeFacade getEmployeeFacade() => employeeFacade;
    }
}
