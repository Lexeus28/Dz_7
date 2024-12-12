using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_File_7
{
    public class Employee
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Employee Supervisor { get; set; }

        public Employee(string name, string role, Employee supervisor = null)
        {
            Name = name;
            Role = role;
            Supervisor = supervisor;
        }
        public bool AcceptsTaskFrom(Employee assigner)
        {
            if (Supervisor == null)
                return false;

            if (Supervisor == assigner)
                return true;

            return Supervisor.AcceptsTaskFrom(assigner);
        }

        public override string ToString()
        {
            return $"{Name} ({Role})";
        }
    }
}
