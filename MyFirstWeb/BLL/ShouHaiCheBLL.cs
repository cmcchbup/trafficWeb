using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class ShouHaiCheBLL
    {
        public ShouHaiChe Add(ShouHaiChe shouHaiChe)
        {
            return new ShouHaiCheDAL().Add(shouHaiChe);
        }

        public int DeleteByCarId(string carId)
        {
            return new ShouHaiCheDAL().DeleteByCarId(carId);
        }

		public int Update(ShouHaiChe shouHaiChe)
        {
            return new ShouHaiCheDAL().Update(shouHaiChe);
        }
        

        public ShouHaiChe GetByCarId(string carId)
        {
            return new ShouHaiCheDAL().GetByCarId(carId);
        }
		public int GetTotalCount()
		{
			return new ShouHaiCheDAL().GetTotalCount();
		}
		
		public IEnumerable<ShouHaiChe> GetPagedData(int minrownum,int maxrownum)
		{
			return new ShouHaiCheDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<ShouHaiChe> GetAll()
		{
			return new ShouHaiCheDAL().GetAll();
		}
    }
}
