using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class ZhaoShiZheDAL
	{
        public ZhaoShiZhe Add
			(ZhaoShiZhe zhaoShiZhe)
		{
				string sql ="INSERT INTO ZhaoShiZhe (Name, Sex, Nation, JiGuan, BirthDay, PeopleId, ZhunJiaCheXing, JiaShiZhengHao, ChuLingRiQi, ContactWay, Address, Photo)  output inserted.Id VALUES (@Name, @Sex, @Nation, @JiGuan, @BirthDay, @PeopleId, @ZhunJiaCheXing, @JiaShiZhengHao, @ChuLingRiQi, @ContactWay, @Address, @Photo)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Name", ToDBValue(zhaoShiZhe.Name)),
						new SqlParameter("@Sex", ToDBValue(zhaoShiZhe.Sex)),
						new SqlParameter("@Nation", ToDBValue(zhaoShiZhe.Nation)),
						new SqlParameter("@JiGuan", ToDBValue(zhaoShiZhe.JiGuan)),
						new SqlParameter("@BirthDay", ToDBValue(zhaoShiZhe.BirthDay)),
						new SqlParameter("@PeopleId", ToDBValue(zhaoShiZhe.PeopleId)),
						new SqlParameter("@ZhunJiaCheXing", ToDBValue(zhaoShiZhe.ZhunJiaCheXing)),
						new SqlParameter("@JiaShiZhengHao", ToDBValue(zhaoShiZhe.JiaShiZhengHao)),
						new SqlParameter("@ChuLingRiQi", ToDBValue(zhaoShiZhe.ChuLingRiQi)),
						new SqlParameter("@ContactWay", ToDBValue(zhaoShiZhe.ContactWay)),
						new SqlParameter("@Address", ToDBValue(zhaoShiZhe.Address)),
						new SqlParameter("@Photo", ToDBValue(zhaoShiZhe.Photo)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE ZhaoShiZhe WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(ZhaoShiZhe zhaoShiZhe)
        {
            string sql =
                "UPDATE ZhaoShiZhe " +
                "SET " +
			" Name = @Name" 
                +", Sex = @Sex" 
                +", Nation = @Nation" 
                +", JiGuan = @JiGuan" 
                +", BirthDay = @BirthDay" 
                +", PeopleId = @PeopleId" 
                +", ZhunJiaCheXing = @ZhunJiaCheXing" 
                +", JiaShiZhengHao = @JiaShiZhengHao" 
                +", ChuLingRiQi = @ChuLingRiQi" 
                +", ContactWay = @ContactWay" 
                +", Address = @Address" 
                +", Photo = @Photo" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", zhaoShiZhe.Id)
					,new SqlParameter("@Name", ToDBValue(zhaoShiZhe.Name))
					,new SqlParameter("@Sex", ToDBValue(zhaoShiZhe.Sex))
					,new SqlParameter("@Nation", ToDBValue(zhaoShiZhe.Nation))
					,new SqlParameter("@JiGuan", ToDBValue(zhaoShiZhe.JiGuan))
					,new SqlParameter("@BirthDay", ToDBValue(zhaoShiZhe.BirthDay))
					,new SqlParameter("@PeopleId", ToDBValue(zhaoShiZhe.PeopleId))
					,new SqlParameter("@ZhunJiaCheXing", ToDBValue(zhaoShiZhe.ZhunJiaCheXing))
					,new SqlParameter("@JiaShiZhengHao", ToDBValue(zhaoShiZhe.JiaShiZhengHao))
					,new SqlParameter("@ChuLingRiQi", ToDBValue(zhaoShiZhe.ChuLingRiQi))
					,new SqlParameter("@ContactWay", ToDBValue(zhaoShiZhe.ContactWay))
					,new SqlParameter("@Address", ToDBValue(zhaoShiZhe.Address))
					,new SqlParameter("@Photo", ToDBValue(zhaoShiZhe.Photo))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public ZhaoShiZhe GetById(int id)
        {
            string sql = "SELECT * FROM ZhaoShiZhe WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
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
		
		public ZhaoShiZhe ToModel(SqlDataReader reader)
		{
			ZhaoShiZhe zhaoShiZhe = new ZhaoShiZhe();

			zhaoShiZhe.Id = (int)ToModelValue(reader,"Id");
			zhaoShiZhe.Name = (string)ToModelValue(reader,"Name");
			zhaoShiZhe.Sex = (string)ToModelValue(reader,"Sex");
			zhaoShiZhe.Nation = (string)ToModelValue(reader,"Nation");
			zhaoShiZhe.JiGuan = (string)ToModelValue(reader,"JiGuan");
			zhaoShiZhe.BirthDay = (DateTime)ToModelValue(reader,"BirthDay");
			zhaoShiZhe.PeopleId = (string)ToModelValue(reader,"PeopleId");
			zhaoShiZhe.ZhunJiaCheXing = (string)ToModelValue(reader,"ZhunJiaCheXing");
			zhaoShiZhe.JiaShiZhengHao = (string)ToModelValue(reader,"JiaShiZhengHao");
			zhaoShiZhe.ChuLingRiQi = (DateTime)ToModelValue(reader,"ChuLingRiQi");
			zhaoShiZhe.ContactWay = (string)ToModelValue(reader,"ContactWay");
			zhaoShiZhe.Address = (string)ToModelValue(reader,"Address");
			zhaoShiZhe.Photo = (string)ToModelValue(reader,"Photo");
			return zhaoShiZhe;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM ZhaoShiZhe";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<ZhaoShiZhe> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM ZhaoShiZhe) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<ZhaoShiZhe> GetAll()
		{
			string sql = "SELECT * FROM ZhaoShiZhe";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<ZhaoShiZhe> ToModels(SqlDataReader reader)
		{
			var list = new List<ZhaoShiZhe>();
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
