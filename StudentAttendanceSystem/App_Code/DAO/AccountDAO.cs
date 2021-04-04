using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class AccountDAO
    {
        public static DataTable GetAccount(string email, string pass, int role)
        {
            string sql = @"select * from Account
                           where email = '" + email + @"' and password= '" + pass
                           + "' and role_id=" + role ;
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static DataTable GetAccountRole()
        {
            string sql = @"SELECT * FROM dbo.Account AS A, dbo.Role AS R
                           WHERE a.role_id = r.role_id";
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static DataTable GetAccountByRole(int role)
        {
            string sql = @"SELECT * FROM dbo.Account AS A, dbo.Role AS R
                           WHERE a.role_id = r.role_id AND r.role_id=" + role;
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static int GetAccountListByEmail(string email)
        {
            string sql = @"select COUNT(*) from Account
                           where email = '" + email + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public static int InsertAccount(string Email, string Pass, int role)
        {
            string sql = "INSERT INTO dbo.Account VALUES  ( @email,  @pass,  @role )";
            SqlParameter param = new SqlParameter("@email", SqlDbType.VarChar);
            SqlParameter param1 = new SqlParameter("@pass", SqlDbType.VarChar);
            SqlParameter param2 = new SqlParameter("@role", SqlDbType.Int);
            param.Value = Email;
            param1.Value = Pass;
            param2.Value = role;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1, param2);
        }

        
    }
}