using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class ClassDAO
    {
        public static DataTable GetClassList()
        {
            string sql = @"SELECT * FROM dbo.Class";
            return DBContext.DBContext.GetDataBySQL(sql);
        }

        public static int GetClassListByCode(string classCode)
        {
            string sql = @"SELECT COUNT(*) FROM dbo.Class WHERE class_code = '" + classCode + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        
        public static int InsertClass(string ClassCode)
        {
            string sql = "INSERT INTO dbo.Class VALUES  ( @code )";
            SqlParameter param = new SqlParameter("@code", SqlDbType.VarChar);
            param.Value = ClassCode;
            return DBContext.DBContext.ExecuteSQL(sql, param);
        }
        public static int InsertStudentToClass(int ClassID, int StudentID)
        {
            string sql = "INSERT INTO dbo.Student_Class VALUES( @stuid, @classid )";
            SqlParameter param = new SqlParameter("@stuid", SqlDbType.Int);
            SqlParameter param1 = new SqlParameter("@classid", SqlDbType.Int);
            param.Value = StudentID;
            param1.Value = ClassID;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1);
        }
    }
}