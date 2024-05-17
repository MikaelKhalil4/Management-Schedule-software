using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
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
        public static DataTable GetAllEmployeesOrLAstInseted(bool AllOrLastInsered)
        {
            string query = "select employee_id ,first_name  ,last_name ,phone_number,password ,access ,status,is_schedule_member,availability,rank,is_checked from employee ";

            if (AllOrLastInsered)
            {
                query += " ORDER by status DESC,employee_id DESC";
            }
            else
            {
                query += " where  employee_id=(Select MAX(employee_id) from employee)";
            }
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
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
        public static int GetLastRank(int empId)
        {
            SqlCommand cmd = new SqlCommand("select MAX(rank) from employee Where employee_id!=@employee_id", con);
            cmd.Parameters.AddWithValue("@employee_id", empId);
            con.Open();
            int MAxRank = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return MAxRank;
        }

        public List<(int, int)> GetRanks(int empId)
        {

            List<(int, int)> ranks = new List<(int, int)>();
            SqlCommand command = new SqlCommand("SELECT employee_id,rank FROM employee where rank is not null and employee_id!=@employee_id ORDER BY rank ASC", con);
            command.Parameters.AddWithValue("@employee_id", empId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ranks.Add(((int)dr["employee_id"], (int)dr["rank"]));
            }
            return ranks;
        }
        public List<(int, int)> NormalizeRanks(List<(int, int)> originalRanks)
        {
            List<(int, int)> normalizedRanks = new List<(int, int)>(originalRanks);

            for (int i = 0; i < originalRanks.Count; i++)
            {
                normalizedRanks[i] = (normalizedRanks[i].Item1, i + 1);
            }

            return normalizedRanks;
        }

        public void UpdateRanks(List<(int, int)> normalizedRanks)
        {
            for (int i = 0; i < normalizedRanks.Count; i++)
            {
                SqlCommand command = new SqlCommand("UPDATE employee SET rank = @rank WHERE employee_id = @employee_id", con);
                command.Parameters.AddWithValue("@employee_id", normalizedRanks[i].Item1);
                command.Parameters.AddWithValue("@rank", normalizedRanks[i].Item2);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }
        }



        public static ClassEmployee CreateEmployeeObject(int employeeID)//in case of one employee
        {

            DataTable dt;
            dt = ClassEmployee.GetAllEmployeesInfo(employeeID);

            DataRow datarow = dt.Rows[0];//since we re expecting one row of return
            ClassEmployee employee = DataTableRowToObject(datarow);

            return employee;
        }
        private static List<ClassEmployee> DataTableToList(DataTable dt)//in case of mutiple employees
        {
            List<ClassEmployee> list = new List<ClassEmployee>();

            foreach (DataRow datarow in dt.Rows)
            {
                ClassEmployee employee = DataTableRowToObject(datarow);
                list.Add(employee);
            };
            return list;
        }
        private static ClassEmployee DataTableRowToObject(DataRow datarow)
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

            employee.IsScheduleMember = (bool)datarow["is_schedule_member"];
            employee.Availability = datarow["availability"] is DBNull ? null : (string)datarow["availability"];
            employee.Rank = datarow["rank"] is DBNull ? null : (int)datarow["rank"];
            employee.IsChecked = datarow["is_checked"] is DBNull ? null : (bool)datarow["is_checked"];


            return employee;
        }
        public void SetEmployeeAccess()
        {
            if (Access != null)
            {
                if (Access.ToString().Contains(Features.enumFeatures.Schedule.GetStringValue()))
                    CanAccesSchedule = true;
                if (Access.ToString().Contains(Features.enumFeatures.EditOffres.GetStringValue()))
                    CanEditOffre = true;
                if (Access.ToString().Contains(Features.enumFeatures.Transactions.GetStringValue()))
                    CanAccessTransaction = true;
                if (Access.ToString().Contains(Features.enumFeatures.ServicesProductsEmployees.GetStringValue()))
                    CanAccessSevicesProductsEmployees = true;
                if (Access.ToString().Contains(Features.enumFeatures.Statistics.GetStringValue()))
                    CanAccessStatistics = true;
                if (Access.ToString().Contains(Features.enumFeatures.RegistrationFields.GetStringValue()))
                    CanEditRegistrationFields = true;
                if (Access.ToString().Contains(Features.enumFeatures.DeleteClients.GetStringValue()))
                    CanDeleteClient = true;
                if (Access.ToString().Contains(Features.enumFeatures.EditClients.GetStringValue()))
                    CanInsertOrEditClients = true;
            }
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


            string query = "INSERT INTO employee (first_name, last_name, phone_number, password, access, clearcash_date, status,is_schedule_member,availability,rank,is_checked) " +
                         "VALUES (@first_name, @last_name, @phone_number, @password, @access, @clearcash_date, @Status,@is_schedule_member,@availability,@rank,@is_checked)";

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
            command.Parameters.AddWithValue("@clearcash_date", DBNull.Value);
            command.Parameters.AddWithValue("@is_schedule_member", IsScheduleMember);

            if (IsScheduleMember)
            {
                Availability = GetFullAvailabilty();
                Rank = GetLastRank(EmployeeId) + 1;
                IsChecked = true;

                command.Parameters.AddWithValue("@availability", Availability);
                command.Parameters.AddWithValue("@rank", Rank);
                command.Parameters.AddWithValue("@is_checked", IsChecked);


            }
            else
            {
                Availability = null;
                Rank = null;
                IsChecked = null;

                command.Parameters.AddWithValue("@availability", DBNull.Value);
                command.Parameters.AddWithValue("@rank", DBNull.Value);
                command.Parameters.AddWithValue("@is_checked", DBNull.Value);
            }
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            if (IsScheduleMember)
            {

                DateTime Today = DateTime.Now.Date;
                if (Schedule.SQLToProject.CheckIfHistoryExistsToday(Today))
                {
                    int LastInsertedId = (int)((DataTable)GetAllEmployeesOrLAstInseted(false)).Rows[0]["employee_id"];
                    Schedule.ProjectToSql.InsertHistoryEmployeeavailibility(Today, LastInsertedId, (int)Rank, Availability);
                }
            }
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
                           "status = @Status, " +
                           "is_schedule_member=@is_schedule_member ,availability=@availability  ,rank=@rank , is_checked=@is_checked " +
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
            command.Parameters.AddWithValue("@is_schedule_member", IsScheduleMember);



            if (IsScheduleMember)//ma32oul tkun true, w yerjaa true again, so ma men ghayir el old results
            {
                bool IsBecomingAScheduleMember = false;


                if (Availability == null && Rank == null && IsChecked == null)
                {
                    IsBecomingAScheduleMember = true;

                    Availability = GetFullAvailabilty();
                    Rank = GetLastRank(EmployeeId) + 1;
                    IsChecked = true;

                }
                //eza ma feto foe bel condtion , btenzal their old value
                command.Parameters.AddWithValue("@availability", Availability);
                command.Parameters.AddWithValue("@rank", Rank);
                command.Parameters.AddWithValue("@is_checked", IsChecked);



                if (IsBecomingAScheduleMember)
                {
                    DateTime Today = DateTime.Now.Date;
                    if (Schedule.SQLToProject.CheckIfHistoryExistsToday(Today))
                    {
                        Schedule.ProjectToSql.InsertHistoryEmployeeavailibility(Today, EmployeeId, (int)Rank, Availability);
                    }
                }
            }
            else//
            {
                if (Rank != null)//means ken eendo rank,ken schedule member
                {
                    UpdateRanks(NormalizeRanks(GetRanks(EmployeeId)));//hone ma aam naamil reset lal datagrid tb3 el employees , cz ma bi hemna, bas bi hemna eza eendoun the right rank aw ma eendun, bas bi hemna eza NUll or no 
                    Schedule.ProjectToSql.DeleteHistoryEmployee(DateTime.Now.Date, EmployeeId);
                }

                Availability = null;
                Rank = null;//ejbare tahet el condition foe
                IsChecked = null;

                command.Parameters.AddWithValue("@availability", DBNull.Value);
                command.Parameters.AddWithValue("@rank", DBNull.Value);//i need to reOrder the others rank , ta yozbato
                command.Parameters.AddWithValue("@is_checked", DBNull.Value);


            }

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteEmployee()
        {
            if (IsScheduleMember)//ma32oul tkun true, w yerjaa true again, so ma men ghayir el old results
            {
                UpdateRanks(NormalizeRanks(GetRanks(EmployeeId)));
                Schedule.ProjectToSql.DeleteHistoryEmployee(DateTime.Now.Date, EmployeeId);
            }
            SqlCommand cmd = new SqlCommand("Delete employee where employee_id='" + EmployeeId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool CheckIfEmployeeHasAppointments()
        {
            string query = @"
            Select Count(*) from employee as b
            where employee_id='" + EmployeeId + "' And Exists(Select* from appointments as a where a.employee_id = b.employee_id AND CAST(a.start_time AS DATE) >= CAST(GETDATE() AS DATE) ) ";
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

        string GetFullAvailabilty()
        {
            string Availabilty = "";
            for (int i = 0; i < 7; i++)
            {
                //j is a reference for the hours of the day
                for (int j = 0; j < 24; j++)
                {
                    Availabilty += j.ToString() + "-";
                }
                Availabilty += "/";

            }

            return Availabilty;
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
