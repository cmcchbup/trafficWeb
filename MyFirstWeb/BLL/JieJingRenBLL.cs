using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class JieJingRenBLL
    {
        public JieJingRen Add(JieJingRen jieJingRen)
        {
            return new JieJingRenDAL().Add(jieJingRen);
        }

        public int DeleteByCaseId(string caseId)
        {
            return new JieJingRenDAL().DeleteByCaseId(caseId);
        }

		public int Update(JieJingRen jieJingRen)
        {
            return new JieJingRenDAL().Update(jieJingRen);
        }
        

        public JieJingRen GetByCaseId(string caseId)
        {
            return new JieJingRenDAL().GetByCaseId(caseId);
        }
		public int GetTotalCount()
		{
			return new JieJingRenDAL().GetTotalCount();
		}
		
		public IEnumerable<JieJingRen> GetPagedData(int minrownum,int maxrownum)
		{
			return new JieJingRenDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<JieJingRen> GetAll()
		{
			return new JieJingRenDAL().GetAll();
		}
    }
}
