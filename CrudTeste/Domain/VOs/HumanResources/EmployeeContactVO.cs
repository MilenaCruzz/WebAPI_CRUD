using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTeste.Domain.VOs.Employee
{
    public class EmployeeContactVO
    {
        public int BusinessEntityID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public string Name { get; set; }
    }
}
