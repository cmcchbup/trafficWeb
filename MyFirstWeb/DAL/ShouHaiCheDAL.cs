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
	public partial class ShouHaiCheDAL
	{
        public ShouHaiChe Add
			(ShouHaiChe shouHaiChe)
		{
				string sql ="INSERT INTO ShouHaiChe (CarId, CarOwnerName, CarOwnerPeopleId, CarType, CarColor, CarBrand, CarPhoto)  VALUES (@CarId, @CarOwnerName, @CarOwnerPeopleId, @CarType, @CarColor, @CarBrand, @CarPhoto)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CarId", ToDBValue(shouHaiChe.CarId)),
						new SqlParameter("@CarOwnerName", ToDBValue(shouHaiChe.CarOwnerName)),
						new SqlParameter("@CarOwnerPeopleId", ToDBValue(shouHaiChe.CarOwnerPeopleId)),
						new SqlParameter("@CarType", ToDBValue(shouHaiChe.CarType)),
						new SqlParameter("@CarColor", ToDBValue(shouHaiChe.CarColor)),
						new SqlParameter("@CarBrand", ToDBValue(shouHaiChe.CarBrand)),
						new SqlParameter("@CarPhoto", ToDBValue(shouHaiChe.CarPhoto)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return shouHaiChe;				
		}

        public int DeleteByCarId(string carId)
		{
            string sql = "DELETE ShouHaiChe WHERE CarId = @CarId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CarId", carId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(ShouHaiChe shouHaiChe)
        {
            string sql =
                "UPDATE ShouHaiChe " +
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
				new SqlParameter("@CarId", shouHaiChe.CarId)
					,new SqlParameter("@CarOwnerName", ToDBValue(shouHaiChe.CarOwnerName))
					,new SqlParameter("@CarOwnerPeopleId", ToDBValue(shouHaiChe.CarOwnerPeopleId))
					,new SqlParameter("@CarType", ToDBValue(shouHaiChe.CarType))
					,new SqlParameter("@CarColor", ToDBValue(shouHaiChe.CarColor))
					,new SqlParameter("@CarBrand", ToDBValue(shouHaiChe.CarBrand))
					,new SqlParameter("@CarPhoto", ToDBValue(shouHaiChe.CarPhoto))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public ShouHaiChe GetByCarId(string carId)
        {
            string sql = "SELECT * FROM ShouHaiChe WHERE CarId = @CarId";
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
		
		public ShouHaiChe ToModel(SqlDataReader reader)
		{
			ShouHaiChe shouHaiChe = new ShouHaiChe();

			shouHaiChe.CarId = (string)ToModelValue(reader,"CarId");
			shouHaiChe.CarOwnerName = (string)ToModelValue(reader,"CarOwnerName");
			shouHaiChe.CarOwnerPeopleId = (string)ToModelValue(reader,"CarOwnerPeopleId");
			shouHaiChe.CarType = (string)ToModelValue(reader,"CarType");
			shouHaiChe.CarColor = (string)ToModelValue(reader,"CarColor");
			shouHaiChe.CarBrand = (string)ToModelValue(reader,"CarBrand");
			shouHaiChe.CarPhoto = (string)ToModelValue(reader,"CarPhoto");
			return shouHaiChe;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM ShouHaiChe";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<ShouHaiChe> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by CarId) rownum FROM ShouHaiChe) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<ShouHaiChe> GetAll()
		{
			string sql = "SELECT * FROM ShouHaiChe";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<ShouHaiChe> ToModels(SqlDataReader reader)
		{
			var list = new List<ShouHaiChe>();
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
