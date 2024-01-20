using System.Data;
using System.Data.SqlClient;

namespace CIE206_ExampleProject.Models
{
	public class DB
	{
		private string connectionString;
        private SqlConnection con = new SqlConnection();

		IConfiguration config;
		public DB(IConfiguration config)
		{
			this.config = config;
            connectionString = config.GetConnectionString("CompanyDB");	//get constring from appsettings.json
            con.ConnectionString = connectionString;
		}

		//////////// USER /////////////////

		public string AddUser(string username, string password, bool isAdmin = false)
		{
			string query = $"insert into [User](Username,Password) values('{username}', '{password}')";
			SqlCommand cmd = new SqlCommand(query, con);
			string res = "";

			try
			{
				con.Open();
				res = cmd.ExecuteNonQuery().ToString();

			} catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
				res = ex.Message;
			}
			finally
			{
				con.Close();
			}
			return res;
		}
		public bool ValidateUser(string username, string pass)
		{
			string query = $"select count(*) from [User] where Username='{username}' and Password='{pass}'";
			SqlCommand cmd = new SqlCommand(query, con);

			try {
				con.Open();
				int res = (int)cmd.ExecuteScalar();
				if (res == 1)
				{
					return true;
				}
			}
			catch (SqlException err)
			{
				Console.WriteLine(err);
			}
			finally
			{
				con.Close();
			}
			return false;
		}

		//////////// ADMIN /////////////////
		public DataTable ReadTable(string table)
		{
			DataTable dt = new DataTable();
			string query = "select * from Employee";
			SqlCommand cmd = new SqlCommand(query, con);

			try
			{
				con.Open();
				dt.Load(cmd.ExecuteReader());

			}
			catch (SqlException err)
			{
				Console.WriteLine(err.Message);
			}
			finally
			{
				con.Close();
			}
			return dt;
		}

		public string AddEmployee(Employee emp)
		{
			string query = $"insert into Employee(fname, minit, lname, ssn, bdate) " +
				$"values('{emp.Fname}', '{emp.Minit}', '{emp.Lname}', '{emp.SSN}','{emp.BirthDate}')";

			SqlCommand cmd = new SqlCommand(query, con);
			string res = "";    // this is for storing error messages (if any) and returning them from the function 

			try
			{
				con.Open();
				res = cmd.ExecuteNonQuery().ToString();
			}
			catch (SqlException err)
			{
				Console.WriteLine(err.Message);
				res = err.Message;
			}
			finally
			{
				con.Close();
			}
			return res;
		}

		public string DeleteEmployee(string ssn)
		{
			string msg = "";
			string query = $"delete from Employee where SSN={ssn}";
			SqlCommand cmd = new SqlCommand(query, con);
			try
			{
				con.Open();
				msg = cmd.ExecuteNonQuery().ToString();

			}
			catch (SqlException err)
			{
				msg = err.Message;
			}
			finally
			{
				con.Close();
			}
			return msg;
		}

		public string UpdateEmployee(Employee emp)
		{
			string msg = "";
			string query = $"update Employee set fname='{emp.Fname}', lname='{emp.Lname}', minit='{emp.Minit}' where SSN={emp.SSN}";
			SqlCommand cmd = new SqlCommand(query, con);

			try
			{
				con.Open();
				msg = cmd.ExecuteNonQuery().ToString();

			}
			catch (SqlException err)
			{
				msg = err.Message;
			}
			finally
			{
				con.Close();
			}
			return msg;
		}

		public Employee? getEmployee(string ssn)
		{
			string msg = "";
			string query = $"select * from Employee where SSN={ssn}";
			SqlCommand cmd = new SqlCommand(query, con);
			DataTable dt = new DataTable();

			Employee employee = new Employee();

			try
			{
				con.Open();
				dt.Load(cmd.ExecuteReader());

				// handle not found employee
				if (dt.Rows.Count == 0)
				{
					msg = "No employee with this ssn found";
					Console.WriteLine(msg);
					return null;
				}

				// transfer data from returned datatable into employee object
				employee.SSN = dt.Rows[0]["SSN"].ToString();
				employee.Fname = dt.Rows[0]["fname"].ToString();
				employee.Lname = dt.Rows[0]["lname"].ToString();
				employee.Minit = ((string)dt.Rows[0]["minit"])[0];  // minit is coming from db as string, but it's a char in the Employee.cs, so I'm just converting from string to char here.

			}
			catch (SqlException err)
			{
				msg = err.Message;
				Console.WriteLine(msg);
			}
			finally
			{
				con.Close();
			}
			return employee;

		}

		///////// Dashboard ///////////
		public Dictionary<string, int> getProjectWithWorkers()
		{
			string query = "select p.pname, count(w.essn) as numberOfWorkers" +
				" from WORKS_ON w inner join Project p on w.Pno = p.Pnumber" +
				" group by p.pname";
			SqlCommand cmd = new SqlCommand(query,con);
			DataTable dt = new DataTable();
			Dictionary<string, int> projectNumbersAndWorkers = new Dictionary<string, int>();

            try
			{
				con.Open();
				dt.Load(cmd.ExecuteReader());

				// fill out the data dictionary with its two columns
				foreach(DataRow row in dt.Rows)
				{
					projectNumbersAndWorkers.Add(row["pname"].ToString(), (int)row["numberOfWorkers"]);
                }
            } catch(SqlException err)
			{
				Console.WriteLine(err.Message);
			}
			finally
			{
				con.Close();
			}
			return projectNumbersAndWorkers;
		}

		public Dictionary<string, double> getProjectHours()
		{
			string query = "select p.pname, sum(w.hours) as projectHours " +
				"from WORKS_ON w inner join Project p on w.Pno = p.Pnumber " +
				"group by p.pname";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            Dictionary<string, double> projectHours = new Dictionary<string, double>();

            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

                // fill out the data dictionary with its two columns
                foreach (DataRow row in dt.Rows)
                {
                    projectHours.Add(row["pname"].ToString(), (double)row["projectHours"]);
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                con.Close();
            }
            return projectHours;

        }
    }
}
