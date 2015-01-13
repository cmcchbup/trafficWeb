using System;
using System.Collections.Generic;
using System.Text;
using NET.CLY.DAL;
using NET.CLY.Model;

namespace NET.CLY.BLL
{

    public partial class ZhaoShiZheBLL
    {
        public ZhaoShiZhe Add(ZhaoShiZhe zhaoShiZhe)
        {
            return new ZhaoShiZheDAL().Add(zhaoShiZhe);
        }

        public int DeleteById(int id)
        {
            return new ZhaoShiZheDAL().DeleteById(id);
        }

		public int Update(ZhaoShiZhe zhaoShiZhe)
        {
            return new ZhaoShiZheDAL().Update(zhaoShiZhe);
        }
        

        public ZhaoShiZhe GetById(int id)
        {
            return new ZhaoShiZheDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new ZhaoShiZheDAL().GetTotalCount();
		}
		
		public IEnumerable<ZhaoShiZhe> GetPagedData(int minrownum,int maxrownum)
		{
			return new ZhaoShiZheDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<ZhaoShiZhe> GetAll()
		{
			return new ZhaoShiZheDAL().GetAll();
		}

        public IEnumerable<ZhaoShiZhe> GetByName(string name)
        {
            return new ZhaoShiZheDAL().GetByName(name);
        }
        public IEnumerable<ZhaoShiZhe> GetByPeopleId(string peopleId)
        {
            return new ZhaoShiZheDAL().GetByPeopleId(peopleId);
        }
    }
}
