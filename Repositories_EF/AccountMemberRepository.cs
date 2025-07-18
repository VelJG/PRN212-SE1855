using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        private readonly AccountMemberDAO _accountMemberDAO = new AccountMemberDAO();
        
        public AccountMember Login(string email, string password)
        {
            return _accountMemberDAO.Login(email, password);
        }
    }
}
