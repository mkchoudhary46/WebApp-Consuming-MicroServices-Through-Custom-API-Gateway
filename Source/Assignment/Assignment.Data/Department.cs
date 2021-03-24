using Assignment.Data.Common;
using System.Collections.Generic;

namespace Assignment.Data
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
