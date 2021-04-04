using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class TeacherDAO
    {
        public static int GetTeacherId(string teacherEmail)
        {
            string sql = @"SELECT T.teacher_id
                           FROM dbo.Account AS A, dbo.Teacher AS T
                           WHERE t.email = a.email and t.email='" + teacherEmail + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static DataTable GetTeacherSchedule(int teacherID)
        {
            string sql = @"SELECT C.class_id, C.class_code, S.subject_id, S.subject_code,S.subject_name,A.student_id,status_description, CS.teaching_date, CS.slot, Stu.student_name, Stu.student_code
                           FROM dbo.Class_Schedule AS CS, dbo.Class AS C, dbo.Teacher AS T,dbo.Student AS Stu, dbo.Subjects AS S, dbo.Attendance AS A LEFT JOIN dbo.AttendStatus ON a.isAbsent = status_id
                           WHERE CS.class_id = C.class_id AND cs.subject_id =s.subject_id AND a.student_id = Stu.student_id
                           AND cs.teacher_id =t.teacher_id AND CS.schedule_id =a.schedule_id AND T.teacher_id = " + teacherID;
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static int InsertTeacher(string Email, string Pass, int role,  string TeacherName)
        {
            AccountDAO.InsertAccount(Email, Pass, role);
            string sql = "INSERT INTO dbo.Teacher VALUES  ( @name,  @email )";
            SqlParameter param = new SqlParameter("@name", SqlDbType.VarChar);
            SqlParameter param1 = new SqlParameter("@email", SqlDbType.VarChar);
            param.Value = TeacherName;
            param1.Value = Email;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1);
        }
    }
}