using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class ShouHaiZheDAL
	{
        public ShouHaiZhe Add
			(ShouHaiZhe shouHaiZhe)
		{
				string sql ="INSERT INTO ShouHaiZhe (Name, Sex, Nation, JiGuan, BirthDay, PeopleId, ZhunJiaCheXing, JiaShiZhengHao, ChuLingRiQi, ContactWay, Address, Photo)  output inserted.Id VALUES (@Name, @Sex, @Nation, @JiGuan, @BirthDay, @PeopleId, @ZhunJiaCheXing, @JiaShiZhengHao, @ChuLingRiQi, @ContactWay, @Address, @Photo)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Name", ToDBValue(shouHaiZhe.Name)),
						new SqlParameter("@Sex", ToDBValue(shouHaiZhe.Sex)),
						new SqlParameter("@Nation", ToDBValue(shouHaiZhe.Nation)),
						new SqlParameter("@JiGuan", ToDBValue(shouHaiZhe.JiGuan)),
						new SqlParameter("@BirthDay", ToDBValue(shouHaiZhe.BirthDay)),
						new SqlParameter("@PeopleId", ToDBValue(shouHaiZhe.PeopleId)),
						new SqlParameter("@ZhunJiaCheXing", ToDBValue(shouHaiZhe.ZhunJiaCheXing)),
						new SqlParameter("@JiaShiZhengHao", ToDBValue(shouHaiZhe.JiaShiZhengHao)),
						new SqlParameter("@ChuLingRiQi", ToDBValue(shouHaiZhe.ChuLingRiQi)),
						new SqlParameter("@ContactWay", ToDBValue(shouHaiZhe.ContactWay)),
						new SqlParameter("@Address", ToDBValue(shouHaiZhe.Address)),
						new SqlParameter("@Photo", ToDBValue(shouHaiZhe.Photo)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE ShouHaiZhe WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(ShouHaiZhe shouHaiZhe)
        {
            string sql =
                "UPDATE ShouHaiZhe " +
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
				new SqlParameter("@Id", shouHaiZhe.Id)
					,new SqlParameter("@Name", ToDBValue(shouHaiZhe.Name))
					,new SqlParameter("@Sex", ToDBValue(shouHaiZhe.Sex))
					,new SqlParameter("@Nation", ToDBValue(shouHaiZhe.Nation))
					,new SqlParameter("@JiGuan", ToDBValue(shouHaiZhe.JiGuan))
					,new SqlParameter("@BirthDay", ToDBValue(shouHaiZhe.BirthDay))
					,new SqlParameter("@PeopleId", ToDBValue(shouHaiZhe.PeopleId))
					,new SqlParameter("@ZhunJiaCheXing", ToDBValue(shouHaiZhe.ZhunJiaCheXing))
					,new SqlParameter("@JiaShiZhengHao", ToDBValue(shouHaiZhe.JiaShiZhengHao))
					,new SqlParameter("@ChuLingRiQi", ToDBValue(shouHaiZhe.ChuLingRiQi))
					,new SqlParameter("@ContactWay", ToDBValue(shouHaiZhe.ContactWay))
					,new SqlParameter("@Address", ToDBValue(shouHaiZhe.Address))
					,new SqlParameter("@Photo", ToDBValue(shouHaiZhe.Photo))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public ShouHaiZhe GetById(int id)
        {
            string sql = "SELECT * FROM ShouHaiZhe WHERE Id = @Id";
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
		
		public ShouHaiZhe ToModel(SqlDataReader reader)
		{
			ShouHaiZhe shouHaiZhe = new ShouHaiZhe();

			shouHaiZhe.Id = (int)ToModelValue(reader,"Id");
			shouHaiZhe.Name = (string)ToModelValue(reader,"Name");
			shouHaiZhe.Sex = (string)ToModelValue(reader,"Sex");
			shouHaiZhe.Nation = (string)ToModelValue(reader,"Nation");
			shouHaiZhe.JiGuan = (string)ToModelValue(reader,"JiGuan");
			shouHaiZhe.BirthDay = (DateTime)ToModelValue(reader,"BirthDay");
			shouHaiZhe.PeopleId = (string)ToModelValue(reader,"PeopleId");
			shouHaiZhe.ZhunJiaCheXing = (string)ToModelValue(reader,"ZhunJiaCheXing");
			shouHaiZhe.JiaShiZhengHao = (string)ToModelValue(reader,"JiaShiZhengHao");
			shouHaiZhe.ChuLingRiQi = (DateTime)ToModelValue(reader,"ChuLingRiQi");
			shouHaiZhe.ContactWay = (string)ToModelValue(reader,"ContactWay");
			shouHaiZhe.Address = (string)ToModelValue(reader,"Address");
			shouHaiZhe.Photo = (string)ToModelValue(reader,"Photo");
			return shouHaiZhe;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM ShouHaiZhe";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<ShouHaiZhe> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM ShouHaiZhe) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<ShouHaiZhe> GetAll()
		{
			string sql = "SELECT * FROM ShouHaiZhe";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<ShouHaiZhe> ToModels(SqlDataReader reader)
		{
			var list = new List<ShouHaiZhe>();
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
        public IEnumerable<ShouHaiZhe> GetByName(string name)
        {
            string sql = "SELECT * FROM ShouHaiZhe where Name=@Name";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Name", name)))
            {
                return ToModels(reader);
            }
        }
        public IEnumerable<ShouHaiZhe> GetByPeopleId(string peopleId)
        {
            string sql = "SELECT * FROM ShouHaiZhe where PeopleId=@PeopleId";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@PeopleId", peopleId)))
            {
                return ToModels(reader);
            }
        }
	}
}
