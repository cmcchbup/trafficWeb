using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class JieJingRenDAL
	{
        public JieJingRen Add
			(JieJingRen jieJingRen)
		{
				string sql ="INSERT INTO JieJingRen (CaseId, Name, PoliceId)  VALUES (@CaseId, @Name, @PoliceId)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CaseId", ToDBValue(jieJingRen.CaseId)),
						new SqlParameter("@Name", ToDBValue(jieJingRen.Name)),
						new SqlParameter("@PoliceId", ToDBValue(jieJingRen.PoliceId)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return jieJingRen;				
		}

        public int DeleteByCaseId(string caseId)
		{
            string sql = "DELETE JieJingRen WHERE CaseId = @CaseId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", caseId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(JieJingRen jieJingRen)
        {
            string sql =
                "UPDATE JieJingRen " +
                "SET " +
			" Name = @Name" 
                +", PoliceId = @PoliceId" 
               
            +" WHERE CaseId = @CaseId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", jieJingRen.CaseId)
					,new SqlParameter("@Name", ToDBValue(jieJingRen.Name))
					,new SqlParameter("@PoliceId", ToDBValue(jieJingRen.PoliceId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public JieJingRen GetByCaseId(string caseId)
        {
            string sql = "SELECT * FROM JieJingRen WHERE CaseId = @CaseId";
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
		
		public JieJingRen ToModel(SqlDataReader reader)
		{
			JieJingRen jieJingRen = new JieJingRen();

			jieJingRen.CaseId = (string)ToModelValue(reader,"CaseId");
			jieJingRen.Name = (string)ToModelValue(reader,"Name");
			jieJingRen.PoliceId = (string)ToModelValue(reader,"PoliceId");
			return jieJingRen;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM JieJingRen";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<JieJingRen> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by CaseId) rownum FROM JieJingRen) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<JieJingRen> GetAll()
		{
			string sql = "SELECT * FROM JieJingRen";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<JieJingRen> ToModels(SqlDataReader reader)
		{
			var list = new List<JieJingRen>();
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
