using Assignment.Data.Common;

namespace Assignment.Data
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int GenderId { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual  Department Department { get; set; }

    }
}
