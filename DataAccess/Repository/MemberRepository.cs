using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMemberList();

        public Member GetMailAndPassword(string _Email, string _Password)
        {
            return MemberDAO.Instance.GetEmailAndPassword(_Email, _Password);
        }
    }
}
