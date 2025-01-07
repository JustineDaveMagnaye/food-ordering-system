using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.model;

namespace Food_Ordering_System.src.main.data.employee.dao
{
    public interface employeeDao
    {
        Employee AddEmployee(Employee employee);
    }
}
