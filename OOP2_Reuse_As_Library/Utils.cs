using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Reuse_As_Library
{
    public static class Utils
    {
        public static int CalAge(this Employee employee)
        {
            return DateTime.Now.Year-employee.DOB.Year;
        }
    }
}
