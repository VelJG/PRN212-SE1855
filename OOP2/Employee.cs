using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Employee
    {
        public int Id { get; set; }
        public string IdCard { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public virtual double calSalary()
        {
            return 4000000;
        }
        public override string ToString()
        {
            return Id+"\t"+IdCard+"\t"+Name+"\t"+DOB.ToString("dd/MM/yyyy")+"\t"+calSalary();
        }
    }
}
