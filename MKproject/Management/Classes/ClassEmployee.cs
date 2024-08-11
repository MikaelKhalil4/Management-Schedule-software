using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
using System.Windows.Documents;
using GlobalFunctions;
using MKproject.Schedule;
using System.Data.SQLite;
using System.Windows.Forms;


namespace MKproject.Management
{
    public class ClassEmployee
    {
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

        public string Access { get; set; }
        public bool Status { get; set; }

        //Related table employee_availability
        public string Availability { get; set; }
        public int? Rank { get; set; }
        public bool IsScheduleMember { get; set; }

        public bool IsOwner { get; set; }//by default its false

        //additional
        public bool IsChecked { get; set; }//for the design Frontend used


        public bool CanAccesSchedule { get; set; }
        public bool CanEditPastAppSchedule { get; set; }
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




        public static bool CheckIfOwnerExist()
        {
            var cmd = Program.CreateCommand("select employee_id from employee where is_owner=1");
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.conOpen();
            cmd.ExecuteNonQuery();
            Program.con.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int CheckIfEmployeeExist(string Pass)
        {
            var cmd = Program.CreateCommand("select employee_id from employee where password=@pass And status=1");
            cmd.AddWithValue("@pass", Pass);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.conOpen();
            cmd.ExecuteNonQuery();
            Program.con.Close();
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["employee_id"]);
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
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }
        public static DataTable GetAllEmployeesInfo(int EmployeeID)
        {
            var cmd = Program.CreateCommand("select * from employee where employee_id=@employee_id");
            cmd.AddWithValue("@employee_id", Convert.ToInt64(EmployeeID));
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static string GetEmployeeFullName(int EmployeeID)
        {
            var cmd = Program.CreateCommand("select first_name  ,last_name  from employee where employee_id=@employee_id");
            cmd.AddWithValue("@employee_id", EmployeeID);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return ((string)dt.Rows[0]["first_name"] + " " + (string)dt.Rows[0]["last_name"]);

        }
        public static DataTable GetAllEmployeesOrLAstInseted(bool AllOrLastInsered)
        {
            string query = "select employee_id ,first_name  ,last_name ,phone_number,password ,access ,status,is_schedule_member,availability,rank,is_owner from employee ";

            if (AllOrLastInsered)
            {
                query += " ORDER by status DESC,employee_id DESC";
            }
            else
            {
                query += " where  employee_id=(Select MAX(employee_id) from employee)";
            }
            var cmd = Program.CreateCommand(query);
            Program.conOpen();
            cmd.ExecuteNonQuery();
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.con.Close();
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

            var command = Program.CreateCommand(query);
            command.AddWithValue("@PhoneNumber", PhoneNumber);

            if (employeeid != null)
            {
                command.AddWithValue("@EmployeeId", Convert.ToInt32(employeeid));
            }
            Program.conOpen();
            int count = Convert.ToInt32(command.ExecuteScalar());
            Program.con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public static int GetOwnerId()
        {
            string query = "SELECT employee_id FROM employee WHERE is_owner=1";

            var command = Program.CreateCommand(query);
            Program.conOpen();
            int OwnerID = Convert.ToInt32(command.ExecuteScalar());
            Program.con.Close();
            return OwnerID;
        }
        public static int GetLastRank(int empId)
        {
            var cmd = Program.CreateCommand("select MAX(rank) from employee Where employee_id!=@employee_id");
            cmd.AddWithValue("@employee_id", empId);
            Program.conOpen();

            var MAxRank = cmd.ExecuteScalar();
            Program.con.Close();
            if (MAxRank == DBNull.Value)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(MAxRank);
            }
        }

        public List<(int, int)> GetRanks(int empId)
        {

            List<(int, int)> ranks = new List<(int, int)>();
            var command = Program.CreateCommand("SELECT employee_id,rank FROM employee where rank is not null and employee_id!=@employee_id ORDER BY rank ASC");
            command.AddWithValue("@employee_id", empId);
            var adapter = Program.CreateDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ranks.Add((Convert.ToInt32(dr["employee_id"]), Convert.ToInt32(dr["rank"])));
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
                var command = Program.CreateCommand("UPDATE employee SET rank = @rank WHERE employee_id = @employee_id");
                command.AddWithValue("@employee_id", normalizedRanks[i].Item1);
                command.AddWithValue("@rank", normalizedRanks[i].Item2);
                Program.conOpen();
                command.ExecuteNonQuery();
                Program.con.Close();

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


            employee.EmployeeId = Convert.ToInt32(datarow["employee_id"]);
            employee.Fname = datarow["first_name"] is DBNull ? null : (string)datarow["first_name"];
            employee.Lname = datarow["last_name"] is DBNull ? null : (string)datarow["last_name"];
            employee.PhoneNumber = datarow["phone_number"] is DBNull ? null : (string)datarow["phone_number"];
            employee.Password = datarow["password"] is DBNull ? null : (string)datarow["password"];
            employee.Access = datarow["access"] is DBNull ? null : (string)datarow["access"];
            employee.Status = Convert.ToBoolean(datarow["status"]);

            employee.IsScheduleMember = Convert.ToBoolean(datarow["is_schedule_member"]);
            employee.Availability = datarow["availability"] is DBNull ? null : (string)datarow["availability"];
            employee.Rank = datarow["rank"] is DBNull ? null : Convert.ToInt32(datarow["rank"]);


            return employee;
        }
        public void SetEmployeeAccess()
        {
            if (Access != null)
            {
                if (Access.ToString().Contains(Features.enumFeatures.Schedule.GetStringValue()))
                    CanAccesSchedule = true;
                if (Access.ToString().Contains(Features.enumFeatures.EditPastAppSchedule.GetStringValue()))
                    CanEditPastAppSchedule = true;
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
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.conOpen();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Program.con.Close();
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


            string query = "INSERT INTO employee (first_name, last_name, phone_number, password, access, clearcash_date, status,is_schedule_member,availability,rank,is_owner) " +
                         "VALUES (@first_name, @last_name, @phone_number, @password, @access, @clearcash_date, @Status,@is_schedule_member,@availability,@rank,@is_owner)";

            var command = Program.CreateCommand(query);
            command.AddWithValue("@first_name", Fname);
            command.AddWithValue("@last_name", Lname);
            command.AddWithValue("@phone_number", PhoneNumber);
            command.AddWithValue("@password", Password);
            command.AddWithValue("@is_owner", IsOwner);


            if (Access == null)
            {
                command.AddWithValue("@access", DBNull.Value);
            }
            else
            {
                command.AddWithValue("@access", Access);
            }

            command.AddWithValue("@Status", Status);
            command.AddWithValue("@clearcash_date", DBNull.Value);
            command.AddWithValue("@is_schedule_member", IsScheduleMember);

            if (IsScheduleMember)
            {
                Availability = GetInitialAvailabilty();
                Rank = GetLastRank(EmployeeId) + 1;


                command.AddWithValue("@availability", Availability);
                command.AddWithValue("@rank", Rank);

            }
            else
            {
                Availability = null;
                Rank = null;

                command.AddWithValue("@availability", DBNull.Value);
                command.AddWithValue("@rank", DBNull.Value);

            }



            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();



            if (IsScheduleMember)
            {

                DateTime Today = DateTime.Now.Date;
                if (Schedule.SQLToProject.CheckIfHistoryExistsToday(Today))
                {
                    int LastInsertedId = Convert.ToInt32(((DataTable)GetAllEmployeesOrLAstInseted(false)).Rows[0]["employee_id"]);
                    Schedule.ProjectToSql.InsertHistoryEmployeeavailibility(Today, LastInsertedId, Convert.ToInt32(Rank), Availability);

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
                           "is_schedule_member=@is_schedule_member ,availability=@availability  ,rank=@rank " +
                           "WHERE employee_id = @employee_id";

            // Create a SQL command with parameters

            var command = Program.CreateCommand(query);
            command.AddWithValue("@first_name", Fname);
            command.AddWithValue("@last_name", Lname);
            command.AddWithValue("@phone_number", PhoneNumber);
            command.AddWithValue("@password", Password);
            if (Access == null)
            {
                command.AddWithValue("@access", DBNull.Value);
            }
            else
            {
                command.AddWithValue("@access", Access);
            }
            command.AddWithValue("@Status", Status);
            command.AddWithValue("@employee_id", EmployeeId);
            command.AddWithValue("@is_schedule_member", IsScheduleMember);



            if (IsScheduleMember)//ma32oul tkun true, w yerjaa true again, so ma men ghayir el old results
            {
                bool IsBecomingAScheduleMember = false;


                if (Rank == null)
                {
                    IsBecomingAScheduleMember = true;
                    Rank = GetLastRank(EmployeeId) + 1;
                }

                //eza ma feto foe bel condtion , btenzal their old value
                command.AddWithValue("@rank", Rank);




                if (Availability == null)
                {
                    Availability = GetInitialAvailabilty();
                }


                command.AddWithValue("@availability", Availability);//means ken eendo old value


                if (IsBecomingAScheduleMember)
                {
                    DateTime Today = DateTime.Now.Date;
                    if (Schedule.SQLToProject.CheckIfHistoryExistsToday(Today))
                    {
                        Schedule.ProjectToSql.InsertHistoryEmployeeavailibility(Today, EmployeeId, Convert.ToInt32(Rank), Availability);
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

                if (Availability != null)//means ken eendo availabiity
                {
                    command.AddWithValue("@availability", Availability);
                }
                else
                {
                    command.AddWithValue("@availability", DBNull.Value);
                }


                Rank = null;//ejbare tahet el condition foe
                command.AddWithValue("@rank", DBNull.Value);//i need to reOrder the others rank , ta yozbato


            }

            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();

        }
        public void DeleteEmployee()
        {
            if (IsScheduleMember)//ma32oul tkun true, w yerjaa true again, so ma men ghayir el old results
            {
                UpdateRanks(NormalizeRanks(GetRanks(EmployeeId)));
                Schedule.ProjectToSql.DeleteHistoryEmployee(DateTime.Now.Date, EmployeeId);
            }
            var cmd = Program.CreateCommand("Delete FROM employee where employee_id='" + EmployeeId + "'");
            Program.conOpen();
            cmd.ExecuteNonQuery();
            Program.con.Close();
        }

        public bool CheckIfEmployeeHasAppointments()
        {
            string query = @"
            Select Count(*) from employee as b
            where employee_id='" + EmployeeId + "' And Exists(Select * from appointments as a where a.employee_id = b.employee_id AND DATE(a.start_time) >= DATE('now')) ";
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.conOpen();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Program.con.Close();
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


            var cmd = Program.CreateCommand(query );
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Program.conOpen();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Program.con.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        string GetInitialAvailabilty()
        {
            string Availabilty = "";
            for (int i = 0; i < 7; i++)
            {
                Availabilty += "/";
            }
            if (Availabilty.Length > 0 && Availabilty.EndsWith("/"))
            {
                Availabilty = Availabilty.Substring(0, Availabilty.Length - 1);
            }
            return Availabilty;
        }








        //Schedule    
        public static List<ClassEmployee> GetEmployeeScheduleMemberASC()
        {
            //Select employee id where status = schedule bhatoun bi datatable breja3 ba3mil for loop baeetiya la kel list
            var command = Program.CreateCommand("SELECT *" +
                           "FROM employee " +
                           "WHERE is_schedule_member = 1 " +//1 means true
                           "ORDER BY rank ASC");



            var adapter = Program.CreateDataAdapter(command);
            DataTable dt = new DataTable();
            // Fill the DataTable with the results of the query
            adapter.Fill(dt);

            // If you want to execute the query without returning the DataTable, you can use cmd.ExecuteNonQuery()
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();

            List<ClassEmployee> ListEmployeeSchedule = DataTableToList(dt);
            return ListEmployeeSchedule;
        }
        public ClassEmployee Copy()//This Copy wont work fi Property eza fi  reference-type Properties (classes or list)/ eenda it s own methode, check ClassAppointment
        {
            return (ClassEmployee)this.MemberwiseClone();
        }




    }
}
