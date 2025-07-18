using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
     public class AccountMemberDAO
    {
        private readonly MyStoreContext _context = new MyStoreContext();
        
        public AccountMember Login(string email, string password)
        {
            return _context.AccountMembers
                .FirstOrDefault(m => m.EmailAddress == email && m.MemberPassword == password);
        }
    }
}
