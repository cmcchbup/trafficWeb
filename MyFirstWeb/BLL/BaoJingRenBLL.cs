using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class BaoJingRenBLL
    {
        public BaoJingRen Add(BaoJingRen baoJingRen)
        {
            return new BaoJingRenDAL().Add(baoJingRen);
        }

        public int DeleteByCaseId(string caseId)
        {
            return new BaoJingRenDAL().DeleteByCaseId(caseId);
        }

		public int Update(BaoJingRen baoJingRen)
        {
            return new BaoJingRenDAL().Update(baoJingRen);
        }
        

        public BaoJingRen GetByCaseId(string caseId)
        {
            return new BaoJingRenDAL().GetByCaseId(caseId);
        }
		public int GetTotalCount()
		{
			return new BaoJingRenDAL().GetTotalCount();
		}
		
		public IEnumerable<BaoJingRen> GetPagedData(int minrownum,int maxrownum)
		{
			return new BaoJingRenDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<BaoJingRen> GetAll()
		{
			return new BaoJingRenDAL().GetAll();
		}
    }
}
