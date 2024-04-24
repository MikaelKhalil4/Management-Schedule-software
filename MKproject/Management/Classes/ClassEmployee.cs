using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Documents;
using GlobalFunctions;
using MKproject.Schedule;
using static MKproject.Management.ClassOptionsInsideFields;

namespace MKproject.Management
{
    public class ClassEmployee
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        public int EmployeeId { get; set; }

        private string fname;

        public string Fname
        {
            get { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fname.ToLower()); }
            set { fname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }
        private string lname;

        public string Lname
        {
            get { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lname.ToLower()); }
            set { lname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }


        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public double? Cash { get; set; }

        public DateTime? ClearCashDate { get; set; }
        public string Access { get; set; }
        public bool Status { get; set; }

        //Related table employee_availability
        public string Availability { get; set; }
        public int? Rank { get; set; }
        public bool? IsChecked { get; set; }
        public bool IsScheduleMember { get; set; }


        //additional
        public bool CanAccesSchedule { get; set; }
        public bool CanEditOffre { get; set; }
        public bool CanAccessStatistics { get; set; }
        public bool CanAccessSevicesProductsEmployees { get; set; }
        public bool CanAccessTransaction { get; set; }
        public bool CanInsertOrEditClients { get; set; }
        public bool CanDeleteClient { get; set; }
        public bool CanEditRegistrationFields { get; set; }



        public ClassEmployee()
        {

        }





        public static int CheckIfEmployeeExist(string Pass)
        {
            SqlCommand cmd = new SqlCommand("select employee_id from employee where password=@pass And status=1", con);
            cmd.Parameters.AddWithValue("@pass", Pass);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                return ((int)dt.Rows[0]["employee_id"]);
            }
            else
            {
                return -1;
            }
        }
        public static DataTable GetActiveEmployees()
        {
            DataTable dt = new DataTable();
            string query = "SELECT first_name,last_name FROM employee ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }
        public static DataTable GetAllEmployeesInfo(int EmployeeID)
        {
            SqlCommand cmd = new SqlCommand("select * from employee where employee_id=@employee_id", con);
            cmd.Parameters.AddWithValue("@employee_id", EmployeeID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static string GetEmployeeFullName(int EmployeeID)
        {
            SqlCommand cmd = new SqlCommand("select first_name  ,last_name  from employee where employee_id=@employee_id", con);
            cmd.Parameters.AddWithValue("@employee_id", EmployeeID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return ((string)dt.Rows[0]["first_name"] + " " + (string)dt.Rows[0]["last_name"]);

        }
        public static DataTable GetAllEmployees()
        {
            string query = "select employee_id ,first_name  ,last_name ,phone_number,password ,access ,status from employee ORDER by status DESC,employee_id DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable GetLastInsertEmployee()
        {
            string Query = "Select employee_id ,first_name  ,last_name ,phone_number,password ,access ,status from employee where  employee_id=(Select MAX(employee_id) from employee)";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static bool SearchEmployeePhoneNumber(int? employeeid, string PhoneNumber)
        {
            string query;
            if (employeeid != null)
            {
                query = "SELECT COUNT(*) FROM employee WHERE phone_number = @PhoneNumber AND employee_id != @EmployeeId";
            }
            else
            {
                query = "SELECT COUNT(*) FROM employee WHERE phone_number = @PhoneNumber";
            }

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

            if (employeeid != null)
            {
                command.Parameters.AddWithValue("@EmployeeId", (int)employeeid);
            }
            con.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



        public static ClassEmployee CreateEmployeeObject(int employeeID)
        {

            DataTable dt;
            dt = ClassEmployee.GetAllEmployeesInfo(employeeID);

            DataRow datarow = dt.Rows[0];//since we re expecting one row of return
            ClassEmployee employee = DataTableRowToObject(datarow);

            return employee;
        }
        public static ClassEmployee DataTableRowToObject(DataRow datarow)
        {
            ClassEmployee employee = new ClassEmployee();

            employee.EmployeeId = (int)datarow["employee_id"];
            employee.Fname = datarow["first_name"] is DBNull ? null : (string)datarow["first_name"];
            employee.Lname = datarow["last_name"] is DBNull ? null : (string)datarow["last_name"];
            employee.PhoneNumber = datarow["phone_number"] is DBNull ? null : (string)datarow["phone_number"];
            employee.Password = datarow["password"] is DBNull ? null : (string)datarow["password"];
            employee.Access = datarow["access"] is DBNull ? null : (string)datarow["access"];
            employee.ClearCashDate = datarow["clearcash_date"] is DBNull ? (DateTime?)null : (DateTime)datarow["clearcash_date"];
            employee.Status = (Boolean)datarow["status"];
            employee.Cash = (double)datarow["cash"];


            if (employee.Access != null)
            {
                if (employee.Access.ToString().Contains(Features.enumFeatures.EditOffres.GetStringValue()))
                    employee.CanEditOffre = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.Transactions.GetStringValue()))
                    employee.CanAccessTransaction = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.ServicesProductsEmployees.GetStringValue()))
                    employee.CanAccessSevicesProductsEmployees = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.Statistics.GetStringValue()))
                    employee.CanAccessStatistics = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.RegistrationFields.GetStringValue()))
                    employee.CanEditRegistrationFields = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.DeleteClients.GetStringValue()))
                    employee.CanDeleteClient = true;
                if (employee.Access.ToString().Contains(Features.enumFeatures.EditClients.GetStringValue()))
                    employee.CanInsertOrEditClients = true;
            }

            return employee;
        }
        public bool CheckIfPAsswordExist(string OldPass)
        {
            string query = " Select Count(*) from employee where password='" + Password + "'";
            if (OldPass != null)
            {
                query += " And password!='" + OldPass + "'";
            }
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void InsertEmployee()
        {

            string query = "INSERT INTO employee (first_name, last_name, phone_number, password, access, clearcash_date, status) " +
                         "VALUES (@first_name, @last_name, @phone_number, @password, @access, @clearcash_date, @Status)";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@first_name", Fname);
            command.Parameters.AddWithValue("@last_name", Lname);
            command.Parameters.AddWithValue("@phone_number", PhoneNumber);
            command.Parameters.AddWithValue("@password", Password);
            if (Access == null)
            {
                command.Parameters.AddWithValue("@access", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@access", Access);
            }

            command.Parameters.AddWithValue("@Status", 1);
            command.Parameters.AddWithValue("@clearcash_date", DBNull.Value);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployee()
        {
            //sql
            string query = "UPDATE employee " +
                           "SET first_name = @first_name, " +
                           "last_name = @last_name, " +
                           "phone_number = @phone_number, " +
                           "password = @password, " +
                           "access = @access, " +
                           "status = @Status " +
                           "WHERE employee_id = @employee_id";

            // Create a SQL command with parameters

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@first_name", Fname);
            command.Parameters.AddWithValue("@last_name", Lname);
            command.Parameters.AddWithValue("@phone_number", PhoneNumber);
            command.Parameters.AddWithValue("@password", Password);
            if (Access == null)
            {
                command.Parameters.AddWithValue("@access", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@access", Access);
            }
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@employee_id", EmployeeId);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteEmployee()
        {

            SqlCommand cmd = new SqlCommand("Delete employee where employee_id='" + EmployeeId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool CheckIfEmployeeHasReferences()
        {
            string query = @"
            Select Count(*) from employee as b
            where employee_id='" + EmployeeId + "' And (" +
            " Exists(Select* from archive as a where a.employee_id = b.employee_id) " +
            "Or" +
            " Exists(Select* from appointments as a where a.employee_id = b.employee_id) )";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //Schedule

        //Display
        public static List<ClassEmployee> GetEmployeeScheduleMemberASC()
        {
            //Select employee id where status = schedule bhatoun bi datatable breja3 ba3mil for loop baeetiya la kel list
            SqlCommand command = new SqlCommand("SELECT *" +
                           "FROM employee " +
                           "WHERE is_schedule_member = 1" +//1 means true
                           "ORDER BY rank ASC", con);



            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            // Fill the DataTable with the results of the query
            adapter.Fill(dt);

            // If you want to execute the query without returning the DataTable, you can use cmd.ExecuteNonQuery()
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            List<ClassEmployee> ListEmployeeSchedule = DataTableToList(dt);
            return ListEmployeeSchedule;
        }

        public static List<ClassEmployee> DataTableToList(DataTable dt)
        {
            List<ClassEmployee> list = new List<ClassEmployee>();

            foreach (DataRow datarow in dt.Rows)
            {
                ClassEmployee employee = DataTableRowToObject(datarow);
                list.Add(employee);
            };
            return list;
        }



        //Update
        public static void UpdateEmployeeScheduleMemberSQL(int Employee_id, string Availability)
        {
            //Where employee_id w b3adil aal availability
            SqlCommand command = new SqlCommand("UPDATE employee SET availability=@availability  WHERE employee_id = @employee_id", con);

            command.Parameters.AddWithValue("@availability", Availability);
            command.Parameters.AddWithValue("@employee_id", Employee_id);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateRankNIsCheckedEmployeeScheduleMemberSQL(List<ClassEmployee> ListEmployeeSchedule)
        {
            //Hone lezim ysir yaeetine list w baeemil for loop where employee_id w aa 2asesa baeemil update rank and is checked
            for (int i = 0; i < ListEmployeeSchedule.Count; i++)
            {
                SqlCommand command = new SqlCommand("UPDATE employee SET rank = @rank, is_checked = @is_checked WHERE employee_id = @employee_id", con);

                // Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@employee_id", ListEmployeeSchedule[i].EmployeeId);
                command.Parameters.AddWithValue("@rank", ListEmployeeSchedule[i].Rank);
                command.Parameters.AddWithValue("@is_checked", ListEmployeeSchedule[i].IsChecked);

                // Open the connection and execute the command
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
