using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class CaseInfoBLL
    {
        public CaseInfo Add(CaseInfo caseInfo)
        {
            return new CaseInfoDAL().Add(caseInfo);
        }

        public int DeleteByCaseId(string caseId)
        {
            return new CaseInfoDAL().DeleteByCaseId(caseId);
        }

		public int Update(CaseInfo caseInfo)
        {
            return new CaseInfoDAL().Update(caseInfo);
        }
        

        public CaseInfo GetByCaseId(string caseId)
        {
            return new CaseInfoDAL().GetByCaseId(caseId);
        }
		public int GetTotalCount()
		{
			return new CaseInfoDAL().GetTotalCount();
		}
		
		public IEnumerable<CaseInfo> GetPagedData(int minrownum,int maxrownum)
		{
			return new CaseInfoDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<CaseInfo> GetAll()
		{
			return new CaseInfoDAL().GetAll();
		}
    }
}
