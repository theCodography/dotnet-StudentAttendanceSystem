using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class ScheduleDAO
    {
        public static int GetScheduleExist(int teacherID, int slot, DateTime teachingDate)
        {
            string sql = @"SELECT COUNT(*) 
                           FROM dbo.Class_Schedule
                           WHERE teacher_id=" + teacherID + " AND slot=" + slot + " AND teaching_date='" + teachingDate + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public static DataTable GetSubject()
        {
            string sql = @"SELECT * FROM dbo.Subjects";
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static int InsertSchedule(int classID, DateTime teachingDate, int slot, int subID, int teacherID)
        {
            string sql = "INSERT INTO dbo.Class_Schedule VALUES  ( @classID,  @teachingDate,  @slot, @subID, @teacherID )";
            SqlParameter param = new SqlParameter("@classID", SqlDbType.Int);
            SqlParameter param1 = new SqlParameter("@teachingDate", SqlDbType.DateTime);
            SqlParameter param2 = new SqlParameter("@slot", SqlDbType.Int);
            SqlParameter param3 = new SqlParameter("@subID", SqlDbType.Int);
            SqlParameter param4 = new SqlParameter("@teacherID", SqlDbType.Int);
            param.Value = classID;
            param1.Value = teachingDate;
            param2.Value = slot;
            param3.Value = subID;
            param4.Value = teacherID;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1, param2, param3, param4);
        }
    }
}