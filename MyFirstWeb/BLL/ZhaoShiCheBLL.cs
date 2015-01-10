using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class ZhaoShiCheBLL
    {
        public ZhaoShiChe Add(ZhaoShiChe zhaoShiChe)
        {
            return new ZhaoShiCheDAL().Add(zhaoShiChe);
        }

        public int DeleteByCarId(string carId)
        {
            return new ZhaoShiCheDAL().DeleteByCarId(carId);
        }

		public int Update(ZhaoShiChe zhaoShiChe)
        {
            return new ZhaoShiCheDAL().Update(zhaoShiChe);
        }
        

        public ZhaoShiChe GetByCarId(string carId)
        {
            return new ZhaoShiCheDAL().GetByCarId(carId);
        }
		public int GetTotalCount()
		{
			return new ZhaoShiCheDAL().GetTotalCount();
		}
		
		public IEnumerable<ZhaoShiChe> GetPagedData(int minrownum,int maxrownum)
		{
			return new ZhaoShiCheDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<ZhaoShiChe> GetAll()
		{
			return new ZhaoShiCheDAL().GetAll();
		}
    }
}
