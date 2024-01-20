using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace ChartExample.Models
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=DESKTOP-1DD8VBL;Initial Catalog=SurveyProject;Integrated Security=True";
            con = new SqlConnection(conStr);
        }

        public DataTable getStudentInfoTable()
        {
            DataTable dt = new DataTable();
            string query = "Select * from student_info";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e) {
                throw e;
            }
            finally { con.Close(); }

            return dt;
        }

        public StudentInfo StudentInfoById(string id)
        {
            StudentInfo student = new StudentInfo();
            string query = "Select * from student_info where id= " + id;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());

                foreach(DataRow row in dt.Rows)
                {
                    student.Fname = row["First Name"].ToString();
                    student.Lname = row["Last Name"].ToString();
                    student.Email = row["Email"].ToString();
                    student.Section = Int16.Parse(row["section"].ToString());
                    student.CodeEditor = row["code_editor"].ToString();
                }
                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { con.Close(); }

            return student;
        }

        public Dictionary<string, int> getCodeEditors()
        {
            DataTable dt = new DataTable();
            List<string> codeEditorsList = new List<string>();
            Dictionary<string,int> labelsAndCounts = new Dictionary<string,int>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetCodeEditors", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while ( sdr.Read())
                {
                    //codeEditorsList.Add(sdr["code_editor"].ToString());
                    labelsAndCounts.Add(sdr["code_editor"].ToString(), (int)sdr["count"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { con.Close(); }

            return labelsAndCounts;
        }
    }
}
