using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class AccountMemberService: IAccountMemberService
    {
        private readonly IAccountMemberRepository _accountMemberRepository = new AccountMemberRepository();
        
        public AccountMember Login(string email, string password)
        {
            return _accountMemberRepository.Login(email, password);
        }
    }
}
