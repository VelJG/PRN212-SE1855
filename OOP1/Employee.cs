using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        #region Attribute

        private int _id;
        private string _idCard;
        private string _name;
        private string _email;
        private string _phone;

        #endregion

        #region Constructor
        public Employee()
        {
            this._id = 1;
            this._idCard = "000000";
            this._name = "Mr.Wick";

        }

        public Employee(int _id,string _idCard ,string _name, string _email, string _phone)
        {
            this._id = _id;
            this._idCard = _idCard;
            this._name = _name;
            this._email = _email;
            this._phone = _phone;
        }
        #endregion

        public int Id { get { return _id; } set { _id = value; } }
        public string IdCard { get { return _idCard; } set { _idCard = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email;  } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }

        public void PrintInfo()
        {
            string msg = $"{Id}\t{IdCard}\t{Name}\t{Email}\t{Phone}";
            Console.WriteLine(msg);
        }
        public override string ToString()
        {
            return $"{Id}\t{IdCard}\t{Name}\t{Email}\t{Phone}";
        }
    }
}
