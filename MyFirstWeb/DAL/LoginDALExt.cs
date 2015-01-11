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
        public Login Login(string UserName, string Password)
        {
            string sql = "select * from Login where UserName=@UserName and Password=@Password";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@UserName", ToDBValue(UserName)),
                new SqlParameter("@Password", ToDBValue(Password))))
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

        public int ExitName(string userName)
        {
            string sql = "select count(*) from Login where UserName=@UserName";
            int Result = (int)SqlHelper.ExecuteScalar(sql, new SqlParameter("@UserName", userName));
            return Result;
        }

        public Login GetByUserName(string UserName)
        {
            string sql = "select * from Login where UserName=@UserName";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@UserName", UserName)))
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

    }
}
