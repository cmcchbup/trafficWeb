//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class ZhaoShiCheDAL
	{
        public ZhaoShiChe Add
			(ZhaoShiChe zhaoShiChe)
		{
				string sql ="INSERT INTO ZhaoShiChe (CarId, CarOwnerName, CarOwnerPeopleId, CarType, CarColor, CarBrand, CarPhoto)  VALUES (@CarId, @CarOwnerName, @CarOwnerPeopleId, @CarType, @CarColor, @CarBrand, @CarPhoto)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CarId", ToDBValue(zhaoShiChe.CarId)),
						new SqlParameter("@CarOwnerName", ToDBValue(zhaoShiChe.CarOwnerName)),
						new SqlParameter("@CarOwnerPeopleId", ToDBValue(zhaoShiChe.CarOwnerPeopleId)),
						new SqlParameter("@CarType", ToDBValue(zhaoShiChe.CarType)),
						new SqlParameter("@CarColor", ToDBValue(zhaoShiChe.CarColor)),
						new SqlParameter("@CarBrand", ToDBValue(zhaoShiChe.CarBrand)),
						new SqlParameter("@CarPhoto", ToDBValue(zhaoShiChe.CarPhoto)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return zhaoShiChe;				
		}

        public int DeleteByCarId(string carId)
		{
            string sql = "DELETE ZhaoShiChe WHERE CarId = @CarId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CarId", carId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(ZhaoShiChe zhaoShiChe)
        {
            string sql =
                "UPDATE ZhaoShiChe " +
                "SET " +
			" CarOwnerName = @CarOwnerName" 
                +", CarOwnerPeopleId = @CarOwnerPeopleId" 
                +", CarType = @CarType" 
                +", CarColor = @CarColor" 
                +", CarBrand = @CarBrand" 
                +", CarPhoto = @CarPhoto" 
               
            +" WHERE CarId = @CarId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CarId", zhaoShiChe.CarId)
					,new SqlParameter("@CarOwnerName", ToDBValue(zhaoShiChe.CarOwnerName))
					,new SqlParameter("@CarOwnerPeopleId", ToDBValue(zhaoShiChe.CarOwnerPeopleId))
					,new SqlParameter("@CarType", ToDBValue(zhaoShiChe.CarType))
					,new SqlParameter("@CarColor", ToDBValue(zhaoShiChe.CarColor))
					,new SqlParameter("@CarBrand", ToDBValue(zhaoShiChe.CarBrand))
					,new SqlParameter("@CarPhoto", ToDBValue(zhaoShiChe.CarPhoto))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public ZhaoShiChe GetByCarId(string carId)
        {
            string sql = "SELECT * FROM ZhaoShiChe WHERE CarId = @CarId";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@CarId", carId)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public ZhaoShiChe ToModel(SqlDataReader reader)
		{
			ZhaoShiChe zhaoShiChe = new ZhaoShiChe();

			zhaoShiChe.CarId = (string)ToModelValue(reader,"CarId");
			zhaoShiChe.CarOwnerName = (string)ToModelValue(reader,"CarOwnerName");
			zhaoShiChe.CarOwnerPeopleId = (string)ToModelValue(reader,"CarOwnerPeopleId");
			zhaoShiChe.CarType = (string)ToModelValue(reader,"CarType");
			zhaoShiChe.CarColor = (string)ToModelValue(reader,"CarColor");
			zhaoShiChe.CarBrand = (string)ToModelValue(reader,"CarBrand");
			zhaoShiChe.CarPhoto = (string)ToModelValue(reader,"CarPhoto");
			return zhaoShiChe;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM ZhaoShiChe";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<ZhaoShiChe> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by CarId) rownum FROM ZhaoShiChe) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<ZhaoShiChe> GetAll()
		{
			string sql = "SELECT * FROM ZhaoShiChe";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<ZhaoShiChe> ToModels(SqlDataReader reader)
		{
			var list = new List<ZhaoShiChe>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
}
