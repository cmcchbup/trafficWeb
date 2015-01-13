using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NET.CLY.Model;

namespace NET.CLY.DAL
{
	public partial class CaseInfoDAL
	{
        public CaseInfo Add
			(CaseInfo caseInfo)
		{
				string sql ="INSERT INTO CaseInfo (CaseId, CaseLevel, CaseSource, CaseDescribe)  VALUES (@CaseId, @CaseLevel, @CaseSource, @CaseDescribe)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CaseId", ToDBValue(caseInfo.CaseId)),
						new SqlParameter("@CaseLevel", ToDBValue(caseInfo.CaseLevel)),
						new SqlParameter("@CaseSource", ToDBValue(caseInfo.CaseSource)),
						new SqlParameter("@CaseDescribe", ToDBValue(caseInfo.CaseDescribe)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return caseInfo;				
		}

        public int DeleteByCaseId(string caseId)
		{
            string sql = "DELETE CaseInfo WHERE CaseId = @CaseId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", caseId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(CaseInfo caseInfo)
        {
            string sql =
                "UPDATE CaseInfo " +
                "SET " +
			" CaseLevel = @CaseLevel" 
                +", CaseSource = @CaseSource" 
                +", CaseDescribe = @CaseDescribe" 
               
            +" WHERE CaseId = @CaseId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", caseInfo.CaseId)
					,new SqlParameter("@CaseLevel", ToDBValue(caseInfo.CaseLevel))
					,new SqlParameter("@CaseSource", ToDBValue(caseInfo.CaseSource))
					,new SqlParameter("@CaseDescribe", ToDBValue(caseInfo.CaseDescribe))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public CaseInfo GetByCaseId(string caseId)
        {
            string sql = "SELECT * FROM CaseInfo WHERE CaseId = @CaseId";
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
		
		public CaseInfo ToModel(SqlDataReader reader)
		{
			CaseInfo caseInfo = new CaseInfo();

			caseInfo.CaseId = (string)ToModelValue(reader,"CaseId");
			caseInfo.CaseLevel = (string)ToModelValue(reader,"CaseLevel");
			caseInfo.CaseSource = (string)ToModelValue(reader,"CaseSource");
			caseInfo.CaseDescribe = (string)ToModelValue(reader,"CaseDescribe");
			return caseInfo;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM CaseInfo";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<CaseInfo> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by CaseId) rownum FROM CaseInfo) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        public IEnumerable<CaseInfo> GetBySql(string sql)
        {
            //string sql = "SELECT * FROM CaseInfo";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }
        public IEnumerable<CaseInfo> GetByLevel(string level)
        {
            string sql = "SELECT * FROM CaseInfo where CaseLevel=@CaseLevel";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@CaseLevel",level)))
            {
                return ToModels(reader);
            }
        }
		public IEnumerable<CaseInfo> GetAll()
		{
			string sql = "SELECT * FROM CaseInfo";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<CaseInfo> ToModels(SqlDataReader reader)
		{
			var list = new List<CaseInfo>();
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
