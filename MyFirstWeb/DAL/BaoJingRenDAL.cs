using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class BaoJingRenDAL
	{
        public BaoJingRen Add
			(BaoJingRen baoJingRen)
		{
				string sql ="INSERT INTO BaoJingRen (CaseId, Name, Sex, PeopleId, BaoJingPhone, ContactWay, Address)  VALUES (@CaseId, @Name, @Sex, @PeopleId, @BaoJingPhone, @ContactWay, @Address)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CaseId", ToDBValue(baoJingRen.CaseId)),
						new SqlParameter("@Name", ToDBValue(baoJingRen.Name)),
						new SqlParameter("@Sex", ToDBValue(baoJingRen.Sex)),
						new SqlParameter("@PeopleId", ToDBValue(baoJingRen.PeopleId)),
						new SqlParameter("@BaoJingPhone", ToDBValue(baoJingRen.BaoJingPhone)),
						new SqlParameter("@ContactWay", ToDBValue(baoJingRen.ContactWay)),
						new SqlParameter("@Address", ToDBValue(baoJingRen.Address)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return baoJingRen;				
		}

        public int DeleteByCaseId(string caseId)
		{
            string sql = "DELETE BaoJingRen WHERE CaseId = @CaseId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", caseId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(BaoJingRen baoJingRen)
        {
            string sql =
                "UPDATE BaoJingRen " +
                "SET " +
			" Name = @Name" 
                +", Sex = @Sex" 
                +", PeopleId = @PeopleId" 
                +", BaoJingPhone = @BaoJingPhone" 
                +", ContactWay = @ContactWay" 
                +", Address = @Address" 
               
            +" WHERE CaseId = @CaseId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", baoJingRen.CaseId)
					,new SqlParameter("@Name", ToDBValue(baoJingRen.Name))
					,new SqlParameter("@Sex", ToDBValue(baoJingRen.Sex))
					,new SqlParameter("@PeopleId", ToDBValue(baoJingRen.PeopleId))
					,new SqlParameter("@BaoJingPhone", ToDBValue(baoJingRen.BaoJingPhone))
					,new SqlParameter("@ContactWay", ToDBValue(baoJingRen.ContactWay))
					,new SqlParameter("@Address", ToDBValue(baoJingRen.Address))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public BaoJingRen GetByCaseId(string caseId)
        {
            string sql = "SELECT * FROM BaoJingRen WHERE CaseId = @CaseId";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@CaseId", caseId)))
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
		
		public BaoJingRen ToModel(SqlDataReader reader)
		{
			BaoJingRen baoJingRen = new BaoJingRen();

			baoJingRen.CaseId = (string)ToModelValue(reader,"CaseId");
			baoJingRen.Name = (string)ToModelValue(reader,"Name");
			baoJingRen.Sex = (string)ToModelValue(reader,"Sex");
			baoJingRen.PeopleId = (string)ToModelValue(reader,"PeopleId");
			baoJingRen.BaoJingPhone = (string)ToModelValue(reader,"BaoJingPhone");
			baoJingRen.ContactWay = (string)ToModelValue(reader,"ContactWay");
			baoJingRen.Address = (string)ToModelValue(reader,"Address");
			return baoJingRen;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM BaoJingRen";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<BaoJingRen> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by CaseId) rownum FROM BaoJingRen) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<BaoJingRen> GetAll()
		{
			string sql = "SELECT * FROM BaoJingRen";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<BaoJingRen> ToModels(SqlDataReader reader)
		{
			var list = new List<BaoJingRen>();
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
