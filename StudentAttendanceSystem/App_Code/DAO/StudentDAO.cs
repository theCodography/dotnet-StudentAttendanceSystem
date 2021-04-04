using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentAttendanceSystem.App_Code.DAO
{
    public class StudentDAO
    {
        public static DataTable GetStudentSchedule(int studentID)
        {
            string sql = @"SELECT C.class_code,S.subject_id, S.subject_code,S.subject_name, T.teacher_name, cs.teaching_date, cs.slot,a.comment,status_description
                           FROM dbo.Class_Schedule AS CS, dbo.Class AS C, dbo.Teacher AS T, dbo.Subjects AS S, dbo.Attendance AS A LEFT JOIN dbo.AttendStatus ON a.isAbsent = status_id
                           WHERE CS.class_id = C.class_id AND cs.subject_id =s.subject_id AND cs.teacher_id =t.teacher_id AND CS.schedule_id =a.schedule_id AND a.student_id = " + studentID;
            return DBContext.DBContext.GetDataBySQL(sql);
        }

        public static DataTable GetStudentByClass(int classID)
        {
            string sql = @"SELECT * FROM dbo.Student AS S, dbo.Student_Class AS SC
                           WHERE s.student_id = sc.student_id AND SC.class_id = " + classID;
            return DBContext.DBContext.GetDataBySQL(sql);
        }

        public static DataTable GetStudentScheduleByWeek(int studentID, int week)
        {
            string sql = @"SELECT C.class_code,S.subject_id, S.subject_code,S.subject_name, T.teacher_name, cs.teaching_date, cs.slot,a.comment,status_description
                           FROM dbo.Class_Schedule AS CS, dbo.Class AS C, dbo.Teacher AS T, dbo.Subjects AS S, dbo.Attendance AS A LEFT JOIN dbo.AttendStatus ON a.isAbsent = status_id
                           WHERE CS.class_id = C.class_id AND cs.subject_id =s.subject_id AND cs.teacher_id =t.teacher_id AND CS.schedule_id =a.schedule_id AND a.student_id = " + studentID + " and DATEPART(WEEK, cs.teaching_date)=" + week;
            return DBContext.DBContext.GetDataBySQL(sql);
        }
        public static DataTable GetStudentNoClass()
        {
            string sql = @"SELECT * FROM dbo.Student WHERE student_id NOT IN 
                            (SELECT S.student_id 
                             FROM dbo.Student AS S, dbo.Student_Class AS SC
                             WHERE S.student_id = sc.student_id)";
            return DBContext.DBContext.GetDataBySQL(sql);
        }

        public static int GetStudentId(string studentEmail)
        {
            string sql = @"SELECT s.student_id 
                           FROM dbo.Account AS A, dbo.Student AS S
                           WHERE a.email = s.email and s.email='" + studentEmail + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public static int GetStudentByCode(string studentCode)
        {
            string sql = @"SELECT COUNT(*) 
                           FROM dbo.Student
                           WHERE student_code='" + studentCode + "'";
            DataTable dt = DBContext.DBContext.GetDataBySQL(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static int InsertStudent(string Email, string Pass, int role, string StudentCode, string StudentName)
        {
            AccountDAO.InsertAccount(Email, Pass, role);
            string sql = "INSERT INTO dbo.Student VALUES  ( @code,  @name,  @email )";
            SqlParameter param = new SqlParameter("@code", SqlDbType.VarChar);
            SqlParameter param1 = new SqlParameter("@name", SqlDbType.NVarChar);
            SqlParameter param2 = new SqlParameter("@email", SqlDbType.VarChar);
            param.Value = StudentCode;
            param1.Value = StudentName;
            param2.Value = Email;
            return DBContext.DBContext.ExecuteSQL(sql, param, param1, param2);
        }
    }
}