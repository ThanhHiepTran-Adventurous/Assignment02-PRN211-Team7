using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        public MemberDAO()
        {
        }

        //-- gọi list từ đb lên
        public IEnumerable<Member> GetMemberList()
        {
            using SalesManagementDBContext dbContext = new SalesManagementDBContext();
            var members = dbContext.Members.ToList();
            return members;
        }

        public Member GetEmailAndPassword(string _Email, string _Password)
        {
            SalesManagementDBContext dbContext = new SalesManagementDBContext();
            Member? member = dbContext.Members.Where(mem => mem.Email == _Email && mem.Password == _Password).FirstOrDefault();
            return member;
        }

        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
