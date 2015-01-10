using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class ShouHaiZheBLL
    {
        public ShouHaiZhe Add(ShouHaiZhe shouHaiZhe)
        {
            return new ShouHaiZheDAL().Add(shouHaiZhe);
        }

        public int DeleteById(int id)
        {
            return new ShouHaiZheDAL().DeleteById(id);
        }

		public int Update(ShouHaiZhe shouHaiZhe)
        {
            return new ShouHaiZheDAL().Update(shouHaiZhe);
        }
        

        public ShouHaiZhe GetById(int id)
        {
            return new ShouHaiZheDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new ShouHaiZheDAL().GetTotalCount();
		}
		
		public IEnumerable<ShouHaiZhe> GetPagedData(int minrownum,int maxrownum)
		{
			return new ShouHaiZheDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<ShouHaiZhe> GetAll()
		{
			return new ShouHaiZheDAL().GetAll();
		}
    }
}
