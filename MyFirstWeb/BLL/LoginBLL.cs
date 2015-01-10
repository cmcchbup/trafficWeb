using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class LoginBLL
    {
        public Login Add(Login login)
        {
            return new LoginDAL().Add(login);
        }

        public int DeleteById(int id)
        {
            return new LoginDAL().DeleteById(id);
        }

		public int Update(Login login)
        {
            return new LoginDAL().Update(login);
        }
        

        public Login GetById(int id)
        {
            return new LoginDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new LoginDAL().GetTotalCount();
		}
		
		public IEnumerable<Login> GetPagedData(int minrownum,int maxrownum)
		{
			return new LoginDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<Login> GetAll()
		{
			return new LoginDAL().GetAll();
		}
    }
}
