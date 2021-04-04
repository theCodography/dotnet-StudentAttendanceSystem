using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class CheckAttendDAO
    {
        public static int UpdateAttend(int status,DateTime date, int slot, int stuid)
        {
            string sql = "UPDATE A SET isAbsent = @status FROM (dbo.Class_Schedule AS CS INNER JOIN dbo.Attendance AS A ON A.schedule_id = CS.schedule_id) WHERE cs.teaching_date = @date AND CS.slot=@slot AND A.student_id = @stuid";
            SqlParameter param = new SqlParameter("@status", SqlDbType.Int);
            SqlParameter param1 = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter param2= new SqlParameter("@slot", SqlDbType.Int);
            SqlParameter param3 = new SqlParameter("@stuid", SqlDbType.Int);
            param.Value = status;
            param1.Value = date;
            param2.Value = slot;
            param3.Value = stuid;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1,param2,param3);
        }
    }
}