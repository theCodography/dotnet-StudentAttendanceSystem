using System.Data;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class RoleDAO
    {
        public static DataTable GetRole()
        {
            string sql = @"select * from Role";
            return DBContext.DBContext.GetDataBySQL(sql);
        }
    }
}