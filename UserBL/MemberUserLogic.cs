using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserObject;

namespace UserBL
{
    public class MemberUserLogic
    {
        Connection DAL = new Connection();
        public void InsertUserDetails(MemberUserObject EBO)
        {
            try
            {
                DAL.AddEmpDetails(EBO);
            }
            catch
            {
                throw;
            }
        }
        public void SelectUserDetails(MemberUserObject EBO)
        {
            DAL.IsUserExist(EBO);
        }

    }
}
