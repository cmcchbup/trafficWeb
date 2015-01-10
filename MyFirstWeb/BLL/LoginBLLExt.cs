using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class LoginBLL
    {
        public Login login(string UserName, string Password)
        {
            return new LoginDAL().Login(UserName, Password);
        }

        public int Exit(string userName)
        {
            return new LoginDAL().ExitName(userName);
        }
    }
}
