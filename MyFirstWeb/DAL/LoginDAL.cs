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
	public partial class LoginDAL
	{
        public Login Add
			(Login login)
		{
				string sql ="INSERT INTO Login (Id, UserName, Password, UserType)  VALUES (@Id, @UserName, @Password, @UserType)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Id", ToDBValue(login.Id)),
						new SqlParameter("@UserName", ToDBValue(login.UserName)),
						new SqlParameter("@Password", ToDBValue(login.Password)),
						new SqlParameter("@UserType", ToDBValue(login.UserType)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return login;				
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE Login WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(Login login)
        {
            string sql =
                "UPDATE Login " +
                "SET " +
			" UserName = @UserName" 
                +", Password = @Password" 
                +", UserType = @UserType" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", login.Id)
					,new SqlParameter("@UserName", ToDBValue(login.UserName))
					,new SqlParameter("@Password", ToDBValue(login.Password))
					,new SqlParameter("@UserType", ToDBValue(login.UserType))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public Login GetById(int id)
        {
            string sql = "SELECT * FROM Login WHERE Id = @Id";
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
		
		public Login ToModel(SqlDataReader reader)
		{
			Login login = new Login();

			login.Id = (int)ToModelValue(reader,"Id");
			login.UserName = (string)ToModelValue(reader,"UserName");
			login.Password = (string)ToModelValue(reader,"Password");
			login.UserType = (string)ToModelValue(reader,"UserType");
			return login;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM Login";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<Login> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM Login) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<Login> GetAll()
		{
			string sql = "SELECT * FROM Login";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<Login> ToModels(SqlDataReader reader)
		{
			var list = new List<Login>();
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
