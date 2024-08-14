
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Xps.Serialization;
using GlobalFunctions;
using MKproject.Schedule;
using static MKproject.ClassClientCustom;

namespace MKproject.Management
{

    public partial class TransferData : Form
    {
        //public static string DataLocationOld = "Data Source=MKpc;Initial Catalog=MK-ELKdataNew;Integrated Security=True;";
        //SqlConnection conOld = new SqlConnection(DataLocationOld);

        public static string DataLocationNew = "Data Source=  C:\\Users\\USER\\Documents\\Foxdb\\Fox.db";
        SQLiteConnection conNew = new SQLiteConnection(DataLocationNew);



        public TransferData()
        {
            InitializeComponent();
            //using (SqlConnection conOld = new SqlConnection(DataLocationOld))
            //using (SQLiteConnection conNew = new SQLiteConnection(DataLocationNew))
            //{
            //    //conOld.Open();
            //    conNew.Open();
            //    // Query to get the client data
            //    string queryClientData = @"
            //    SELECT client_id, weight, height, body_shape_target, muscles_focus_on, injuries, hand, 
            //           sessions_per_week, timeline_goals, exercise_history, sleep_patterns, 
            //           stress_levels, smoking_consumption, alcohol_consumption, fighting_skills 
            //    FROM client";

            //    using (SQLiteCommand command = new SQLiteCommand(queryClientData, conNew))
            //    {
            //        using (SQLiteDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int clientId = reader.GetInt32(0);

            //                InsertClientField(conNew, clientId, enumDynamicFields.Weight, reader["weight"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.Height, reader["height"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.BodyShapeTarget, reader["body_shape_target"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.MuscleFocusOn, reader["muscles_focus_on"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.Injuries, reader["injuries"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.Hand, reader["hand"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.SessionPerWeek, reader["sessions_per_week"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.GoalsTimeline, reader["timeline_goals"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.ExerciseHistory, reader["exercise_history"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.SleepPattern, reader["sleep_patterns"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.StressLevel, reader["stress_levels"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.Smoking, reader["smoking_consumption"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.Alcohol, reader["alcohol_consumption"].ToString());
            //                InsertClientField(conNew, clientId, enumDynamicFields.BoxingSkills, reader["fighting_skills"].ToString());
            //            }
            //        }
            //    }
            //}

            //UpdateDate(DataLocationNew);


            // Transfer data
            //TransferCurrencies(conOld, conNew);
            //TransferAlbums(conOld, conNew);
            //TransferBundles(conOld, conNew);
            //TransferClients(conOld, conNew);
            //TransferEmployees(conOld, conNew);
            //TransferClientBalances(conOld, conNew);
            //TransferAppointments(conOld, conNew);
            //TransferClientServicesAttendance(conOld, conNew);
            //TransferFinance(conOld, conNew);
            //TransferArchive(conOld, conNew);
            //TransferAppointmentHasBundles(conOld, conNew);
            //TransferReminders(conOld, conNew);
            //TransferRequiredVisibleFields(conOld, conNew);
            //TransferHistoryEmployeeAvailability(conOld, conNew);
            //TransferProducts(conOld, conNew);
        }

        //private static void InsertClientField(SQLiteConnection connection, int clientId, enumDynamicFields field, string content)
        //{
        //    if (string.IsNullOrWhiteSpace(content))
        //    {
        //        return;
        //    }
        //    // Get the field ID from the required_visible_fields table
        //    int fieldId = GetFieldId(connection, field.ToString());

        //    string insertQuery = "INSERT INTO client_fields (client_id, fields_id, content) VALUES (@client_id, @fields_id, @content)";
        //    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
        //    {
        //        insertCommand.Parameters.AddWithValue("@client_id", clientId);
        //        insertCommand.Parameters.AddWithValue("@fields_id", fieldId);
        //        insertCommand.Parameters.AddWithValue("@content", content);

        //        insertCommand.ExecuteNonQuery();
        //    }
        //}

        //private static int GetFieldId(SQLiteConnection connection, string fieldName)
        //{
        //    string query = "SELECT fields_id FROM required_visible_fields WHERE Fields = @fieldName";
        //    using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //    {
        //        command.Parameters.AddWithValue("@fieldName", fieldName);
        //        return Convert.ToInt32(command.ExecuteScalar());
        //    }
        //}



        //static void UpdateDate(string connectionString)
        //{
        //    using (SQLiteConnection conNew = new SQLiteConnection(connectionString))
        //    {
        //        conNew.Open();

        //        string selectQuery = "SELECT client_id, last_time_searched FROM client";
        //        SQLiteCommand cmd = new SQLiteCommand(selectQuery, conNew);
        //        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            DateTime originalDate;
        //            if (DateTime.TryParse(dr["last_time_searched"].ToString(), out originalDate))
        //            {
        //                //Convert the date to the desired format
        //                string formattedDate = originalDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff");

        //                //Update the date in the database
        //                string updateQuery = "UPDATE client SET last_time_searched = @newDate WHERE client_id = @client_id";
        //                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conNew))
        //                {
        //                    updateCmd.Parameters.AddWithValue("@newDate", formattedDate);
        //                    updateCmd.Parameters.AddWithValue("@client_id", dr["client_id"]);
        //                    updateCmd.ExecuteNonQuery();
        //                }
        //            }
        //        }

        //        conNew.Close();
        //    }

        //}

            //private static void TransferAlbums(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = "SELECT Album_id, AlbumType FROM Albums";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int albumId = Convert.ToInt32(row["Album_id"]);
            //        string albumType = Convert.ToString(row["AlbumType"]);

            //        string insertQuery = "INSERT INTO Albums (Album_id, AlbumType) VALUES (@Album_id, @AlbumType)";
            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@Album_id", albumId);
            //            insertCmd.Parameters.AddWithValue("@AlbumType", albumType);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferCurrencies(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = "SELECT id, Currency_Name, Symbol FROM Currencies";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int currencyId = Convert.ToInt32(row["id"]);
            //        string currencyName = Convert.ToString(row["Currency_Name"]);
            //        string symbol = row["Symbol"] != DBNull.Value ? Convert.ToString(row["Symbol"]) : null;

            //        string insertQuery = "INSERT INTO Currencies (currency_id, Currency_Name, Symbol) VALUES (@currency_id, @Currency_Name, @Symbol)";
            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@currency_id", currencyId);
            //            insertCmd.Parameters.AddWithValue("@Currency_Name", currencyName);
            //            insertCmd.Parameters.AddWithValue("@Symbol", symbol);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferBundles(SqlConnection conOld, SQLiteConnection conNew)

            //{
            //    string selectQuery = "SELECT bundle_id, bundle_name, description, sessions_numb, bundle_type, price, status, is_member_ship FROM bundles";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int bundleId = Convert.ToInt32(row["bundle_id"]);
            //        string bundleName = Convert.ToString(row["bundle_name"]);
            //        string description = row["description"] != DBNull.Value ? Convert.ToString(row["description"]) : null;
            //        int? sessionsNumb = row["sessions_numb"] != DBNull.Value ? Convert.ToInt32(row["sessions_numb"]) : null;
            //        string bundleType = Convert.ToString(row["bundle_type"]);
            //        double price = Convert.ToDouble(row["price"]);
            //        int status = Convert.ToInt32(row["status"]);
            //        int isMemberShip = Convert.ToInt32(row["is_member_ship"]);
            //        string duration = "01:00:00";

            //        string insertQuery = "INSERT INTO bundles (bundle_id, bundle_name, description, sessions_numb, bundle_type, price, status, is_member_ship, duration) VALUES (@bundle_id, @bundle_name, @description, @sessions_numb, @bundle_type, @price, @status, @is_member_ship, @duration)";
            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@bundle_id", bundleId);
            //            insertCmd.Parameters.AddWithValue("@bundle_name", bundleName);
            //            insertCmd.Parameters.AddWithValue("@description", description);
            //            insertCmd.Parameters.AddWithValue("@sessions_numb", sessionsNumb);
            //            insertCmd.Parameters.AddWithValue("@bundle_type", bundleType);
            //            insertCmd.Parameters.AddWithValue("@price", price);
            //            insertCmd.Parameters.AddWithValue("@status", status);
            //            insertCmd.Parameters.AddWithValue("@is_member_ship", isMemberShip);
            //            insertCmd.Parameters.AddWithValue("@duration", duration);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferClients(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT client_id, name, family_name, phone_number, gender, job, adress, insta_user, date_of_birth, 
            //       IsChild, IsParent, AlbumType, profile_image_path, password, save_date, check_in, Registration_Date, 
            //       total_balance, total_payment, last_time_searched, weight, height, body_shape_target, muscles_focus_on, 
            //       injuries, hand, sessions_per_week, special_note, email, know_about_us, marital_status, 
            //       scheduling_and_availability, timeline_goals, exercise_history, sleep_patterns, stress_levels, 
            //       smoking_consumption, alcohol_consumption, fighting_skills 
            //FROM client";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int clientId = row["client_id"] != DBNull.Value ? Convert.ToInt32(row["client_id"]) : default;
            //        string name = row["name"] != DBNull.Value ? Convert.ToString(row["name"]) : null;
            //        string familyName = row["family_name"] != DBNull.Value ? Convert.ToString(row["family_name"]) : null;
            //        string phoneNumber = row["phone_number"] != DBNull.Value ? Convert.ToString(row["phone_number"]) : null;
            //        string gender = row["gender"] != DBNull.Value ? Convert.ToString(row["gender"]) : null;
            //        string job = row["job"] != DBNull.Value ? Convert.ToString(row["job"]) : null;
            //        string address = row["adress"] != DBNull.Value ? Convert.ToString(row["adress"]) : null;
            //        string instaUser = row["insta_user"] != DBNull.Value ? Convert.ToString(row["insta_user"]) : null;
            //        string dateOfBirth = row["date_of_birth"] != DBNull.Value ? Convert.ToString(row["date_of_birth"]) : null;
            //        int isChild = row["IsChild"] != DBNull.Value ? Convert.ToInt32(row["IsChild"]) : default;
            //        int isParent = row["IsParent"] != DBNull.Value ? Convert.ToInt32(row["IsParent"]) : default;
            //        string albumType = row["AlbumType"] != DBNull.Value ? Convert.ToString(row["AlbumType"]) : null;
            //        string profileImagePath = row["profile_image_path"] != DBNull.Value ? Convert.ToString(row["profile_image_path"]) : null;
            //        string password = row["password"] != DBNull.Value ? Convert.ToString(row["password"]) : null;
            //        string saveDate = row["save_date"] != DBNull.Value ? Convert.ToString(row["save_date"]) : null;
            //        string checkIn = row["check_in"] != DBNull.Value ? Convert.ToString(row["check_in"]) : null;
            //        string registrationDate = row["Registration_Date"] != DBNull.Value ? Convert.ToString(row["Registration_Date"]) : null;
            //        double totalBalance = row["total_balance"] != DBNull.Value ? Convert.ToDouble(row["total_balance"]) : default;
            //        double totalPayment = row["total_payment"] != DBNull.Value ? Convert.ToDouble(row["total_payment"]) : default;
            //        string lastTimeSearched = row["last_time_searched"] != DBNull.Value ? Convert.ToString(row["last_time_searched"]) : null;
            //        string weight = row["weight"] != DBNull.Value ? Convert.ToString(row["weight"]) : null;
            //        string height = row["height"] != DBNull.Value ? Convert.ToString(row["height"]) : null;
            //        string bodyShapeTarget = row["body_shape_target"] != DBNull.Value ? Convert.ToString(row["body_shape_target"]) : null;
            //        string musclesFocusOn = row["muscles_focus_on"] != DBNull.Value ? Convert.ToString(row["muscles_focus_on"]) : null;
            //        string injuries = row["injuries"] != DBNull.Value ? Convert.ToString(row["injuries"]) : null;
            //        string hand = row["hand"] != DBNull.Value ? Convert.ToString(row["hand"]) : null;
            //        int sessionsPerWeek = row["sessions_per_week"] != DBNull.Value ? Convert.ToInt32(row["sessions_per_week"]) : default;
            //        string specialNote = row["special_note"] != DBNull.Value ? Convert.ToString(row["special_note"]) : null;
            //        string email = row["email"] != DBNull.Value ? Convert.ToString(row["email"]) : null;
            //        string knowAboutUs = row["know_about_us"] != DBNull.Value ? Convert.ToString(row["know_about_us"]) : null;
            //        string maritalStatus = row["marital_status"] != DBNull.Value ? Convert.ToString(row["marital_status"]) : null;
            //        string schedulingAndAvailability = row["scheduling_and_availability"] != DBNull.Value ? Convert.ToString(row["scheduling_and_availability"]) : null;
            //        string timelineGoals = row["timeline_goals"] != DBNull.Value ? Convert.ToString(row["timeline_goals"]) : null;
            //        string exerciseHistory = row["exercise_history"] != DBNull.Value ? Convert.ToString(row["exercise_history"]) : null;
            //        string sleepPatterns = row["sleep_patterns"] != DBNull.Value ? Convert.ToString(row["sleep_patterns"]) : null;
            //        string stressLevels = row["stress_levels"] != DBNull.Value ? Convert.ToString(row["stress_levels"]) : null;
            //        string smokingConsumption = row["smoking_consumption"] != DBNull.Value ? Convert.ToString(row["smoking_consumption"]) : null;
            //        string alcoholConsumption = row["alcohol_consumption"] != DBNull.Value ? Convert.ToString(row["alcohol_consumption"]) : null;
            //        string fightingSkills = row["fighting_skills"] != DBNull.Value ? Convert.ToString(row["fighting_skills"]) : null;


            //        string insertQuery = @"
            //    INSERT INTO client (client_id, name, family_name, phone_number, gender, job, adress, insta_user, date_of_birth, 
            //                        IsChild, IsParent, AlbumType, profile_image_path, password, save_date, check_in, Registration_Date, 
            //                        total_balance, total_payment, last_time_searched, weight, height, body_shape_target, muscles_focus_on, 
            //                        injuries, hand, sessions_per_week, special_note, email, know_about_us, marital_status, 
            //                        scheduling_and_availability, timeline_goals, exercise_history, sleep_patterns, stress_levels, 
            //                        smoking_consumption, alcohol_consumption, fighting_skills) 
            //    VALUES (@client_id, @name, @family_name, @phone_number, @gender, @job, @adress, @insta_user, @date_of_birth, 
            //            @IsChild, @IsParent, @AlbumType, @profile_image_path, @password, @save_date, @check_in, @Registration_Date, 
            //            @total_balance, @total_payment, @last_time_searched, @weight, @height, @body_shape_target, @muscles_focus_on, 
            //            @injuries, @hand, @sessions_per_week, @special_note, @email, @know_about_us, @marital_status, 
            //            @scheduling_and_availability, @timeline_goals, @exercise_history, @sleep_patterns, @stress_levels, 
            //            @smoking_consumption, @alcohol_consumption, @fighting_skills)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId);
            //            insertCmd.Parameters.AddWithValue("@name", name);
            //            insertCmd.Parameters.AddWithValue("@family_name", familyName);
            //            insertCmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            //            insertCmd.Parameters.AddWithValue("@gender", gender);
            //            insertCmd.Parameters.AddWithValue("@job", job);
            //            insertCmd.Parameters.AddWithValue("@adress", address);
            //            insertCmd.Parameters.AddWithValue("@insta_user", instaUser);
            //            insertCmd.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
            //            insertCmd.Parameters.AddWithValue("@IsChild", isChild);
            //            insertCmd.Parameters.AddWithValue("@IsParent", isParent);
            //            insertCmd.Parameters.AddWithValue("@AlbumType", albumType);
            //            insertCmd.Parameters.AddWithValue("@profile_image_path", profileImagePath);
            //            insertCmd.Parameters.AddWithValue("@password", password);
            //            insertCmd.Parameters.AddWithValue("@save_date", saveDate);
            //            insertCmd.Parameters.AddWithValue("@check_in", checkIn);
            //            insertCmd.Parameters.AddWithValue("@Registration_Date", registrationDate);
            //            insertCmd.Parameters.AddWithValue("@total_balance", totalBalance);
            //            insertCmd.Parameters.AddWithValue("@total_payment", totalPayment);
            //            insertCmd.Parameters.AddWithValue("@last_time_searched", lastTimeSearched);
            //            insertCmd.Parameters.AddWithValue("@weight", weight);
            //            insertCmd.Parameters.AddWithValue("@height", height);
            //            insertCmd.Parameters.AddWithValue("@body_shape_target", bodyShapeTarget);
            //            insertCmd.Parameters.AddWithValue("@muscles_focus_on", musclesFocusOn);
            //            insertCmd.Parameters.AddWithValue("@injuries", injuries);
            //            insertCmd.Parameters.AddWithValue("@hand", hand);
            //            insertCmd.Parameters.AddWithValue("@sessions_per_week", sessionsPerWeek);
            //            insertCmd.Parameters.AddWithValue("@special_note", specialNote);
            //            insertCmd.Parameters.AddWithValue("@email", email);
            //            insertCmd.Parameters.AddWithValue("@know_about_us", knowAboutUs);
            //            insertCmd.Parameters.AddWithValue("@marital_status", maritalStatus);
            //            insertCmd.Parameters.AddWithValue("@scheduling_and_availability", schedulingAndAvailability);
            //            insertCmd.Parameters.AddWithValue("@timeline_goals", timelineGoals);
            //            insertCmd.Parameters.AddWithValue("@exercise_history", exerciseHistory);
            //            insertCmd.Parameters.AddWithValue("@sleep_patterns", sleepPatterns);
            //            insertCmd.Parameters.AddWithValue("@stress_levels", stressLevels);
            //            insertCmd.Parameters.AddWithValue("@smoking_consumption", smokingConsumption);
            //            insertCmd.Parameters.AddWithValue("@alcohol_consumption", alcoholConsumption);
            //            insertCmd.Parameters.AddWithValue("@fighting_skills", fightingSkills);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferEmployees(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT employee_id, first_name, last_name, phone_number, password, cash, clearcash_date, 
            //       status, access
            //FROM employee";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int employeeId = Convert.ToInt32(row["employee_id"]);
            //        string firstName = Convert.ToString(row["first_name"]);
            //        string lastName = Convert.ToString(row["last_name"]);
            //        string phoneNumber = Convert.ToString(row["phone_number"]);
            //        string password = Convert.ToString(row["password"]);
            //        double cash = Convert.ToDouble(row["cash"]);
            //        string clearCashDate = Convert.ToString(row["clearcash_date"]);
            //        int status = Convert.ToInt32(row["status"]);
            //        string access = Convert.ToString(row["access"]);
            //        int? isScheduleMember = null;
            //        string availability = null;
            //        int? rank = null;

            //        string insertQuery = @"
            //    INSERT INTO employee (employee_id, first_name, last_name, phone_number, password, cash, clearcash_date, 
            //                          status, access, is_schedule_member, availability, rank) 
            //    VALUES (@employee_id, @first_name, @last_name, @phone_number, @password, @cash, @clearcash_date, 
            //            @status, @access, @is_schedule_member, @availability, @rank)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@employee_id", employeeId);
            //            insertCmd.Parameters.AddWithValue("@first_name", firstName);
            //            insertCmd.Parameters.AddWithValue("@last_name", lastName);
            //            insertCmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            //            insertCmd.Parameters.AddWithValue("@password", password);
            //            insertCmd.Parameters.AddWithValue("@cash", cash);
            //            insertCmd.Parameters.AddWithValue("@clearcash_date", clearCashDate);
            //            insertCmd.Parameters.AddWithValue("@status", status);
            //            insertCmd.Parameters.AddWithValue("@access", access);
            //            insertCmd.Parameters.AddWithValue("@is_schedule_member", isScheduleMember);
            //            insertCmd.Parameters.AddWithValue("@availability", availability);
            //            insertCmd.Parameters.AddWithValue("@rank", rank);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferClientBalances(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT ID, client_id, bundle_id, product_id, purchase_date, original_offre, offre, 
            //       amount_paid, balance, session_left_days, isbundle_membership, due_date, is_freezed, is_expired 
            //FROM client_balance";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int clientBalanceId = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : default;
            //        int clientId = row["client_id"] != DBNull.Value ? Convert.ToInt32(row["client_id"]) : default;
            //        int? bundleId = row["bundle_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["bundle_id"]) : null;
            //        int? productId = row["product_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["product_id"]) : null;
            //        string purchaseDate = row["purchase_date"] != DBNull.Value ? Convert.ToString(row["purchase_date"]) : null;
            //        string originalOffre = row["original_offre"] != DBNull.Value ? Convert.ToString(row["original_offre"]) : null;
            //        string offre = row["offre"] != DBNull.Value ? Convert.ToString(row["offre"]) : null;
            //        double amountPaid = row["amount_paid"] != DBNull.Value ? Convert.ToDouble(row["amount_paid"]) : default;
            //        double balance = row["balance"] != DBNull.Value ? Convert.ToDouble(row["balance"]) : default;
            //        int sessionLeftDays = row["session_left_days"] != DBNull.Value ? Convert.ToInt32(row["session_left_days"]) : default;
            //        int isBundleMembership = row["isbundle_membership"] != DBNull.Value ? Convert.ToInt32(row["isbundle_membership"]) : default;
            //        string dueDate = row["due_date"] != DBNull.Value ? Convert.ToString(row["due_date"]) : null;
            //        int isFreezed = row["is_freezed"] != DBNull.Value ? Convert.ToInt32(row["is_freezed"]) : default;
            //        int isExpired = row["is_expired"] != DBNull.Value ? Convert.ToInt32(row["is_expired"]) : default;


            //        string insertQuery = @"
            //    INSERT INTO client_balance (client_balance_id, client_id, bundle_id, product_id, purchase_date, 
            //                                original_offre, offre, amount_paid, balance, session_left_days, 
            //                                isbundle_membership, due_date, is_freezed, is_expired) 
            //    VALUES (@client_balance_id, @client_id, @bundle_id, @product_id, @purchase_date, @original_offre, 
            //            @offre, @amount_paid, @balance, @session_left_days, @isbundle_membership, @due_date, 
            //            @is_freezed, @is_expired)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@client_balance_id", clientBalanceId);
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId);
            //            insertCmd.Parameters.AddWithValue("@bundle_id", bundleId.HasValue ? (object)bundleId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@product_id", productId.HasValue ? (object)productId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@purchase_date", purchaseDate);
            //            insertCmd.Parameters.AddWithValue("@original_offre", originalOffre);
            //            insertCmd.Parameters.AddWithValue("@offre", offre);
            //            insertCmd.Parameters.AddWithValue("@amount_paid", amountPaid);
            //            insertCmd.Parameters.AddWithValue("@balance", balance);
            //            insertCmd.Parameters.AddWithValue("@session_left_days", sessionLeftDays);
            //            insertCmd.Parameters.AddWithValue("@isbundle_membership", isBundleMembership);
            //            insertCmd.Parameters.AddWithValue("@due_date", dueDate);
            //            insertCmd.Parameters.AddWithValue("@is_freezed", isFreezed);
            //            insertCmd.Parameters.AddWithValue("@is_expired", isExpired);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferAppointments(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT appointment_id, client_id, employee_id, is_package_mode, client_balance_id, 
            //       title, start_time, end_time, Note, is_completed, is_canceled 
            //FROM appointments";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int appointmentId = row["appointment_id"] != DBNull.Value ? Convert.ToInt32(row["appointment_id"]) : default;
            //        int? clientId = row["client_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["client_id"]) : null;
            //        int employeeId = row["employee_id"] != DBNull.Value ? Convert.ToInt32(row["employee_id"]) : default;
            //        int isPackageMode = row["is_package_mode"] != DBNull.Value ? Convert.ToInt32(row["is_package_mode"]) : default;
            //        int? clientBalanceId = row["client_balance_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["client_balance_id"]) : null;
            //        string title = row["title"] != DBNull.Value ? Convert.ToString(row["title"]) : null;
            //        string startTime = row["start_time"] != DBNull.Value ? Convert.ToString(row["start_time"]) : null;
            //        string endTime = row["end_time"] != DBNull.Value ? Convert.ToString(row["end_time"]) : null;
            //        string note = row["Note"] != DBNull.Value ? Convert.ToString(row["Note"]) : null;
            //        int isCompleted = row["is_completed"] != DBNull.Value ? Convert.ToInt32(row["is_completed"]) : default;
            //        int isCanceled = row["is_canceled"] != DBNull.Value ? Convert.ToInt32(row["is_canceled"]) : default;


            //        string insertQuery = @"
            //    INSERT INTO appointments (appointment_id, client_id, employee_id, is_package_mode, client_balance_id, 
            //                               title, start_time, end_time, Note, is_completed, is_canceled) 
            //    VALUES (@appointment_id, @client_id, @employee_id, @is_package_mode, @client_balance_id,
            //            @title, @start_time, @end_time, @Note, @is_completed, @is_canceled)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId.HasValue ? (object)clientId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@employee_id", employeeId);
            //            insertCmd.Parameters.AddWithValue("@is_package_mode", isPackageMode);
            //            insertCmd.Parameters.AddWithValue("@client_balance_id", clientBalanceId.HasValue ? (object)clientBalanceId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@title", title);
            //            insertCmd.Parameters.AddWithValue("@start_time", startTime);
            //            insertCmd.Parameters.AddWithValue("@end_time", endTime);
            //            insertCmd.Parameters.AddWithValue("@Note", note);
            //            insertCmd.Parameters.AddWithValue("@is_completed", isCompleted);
            //            insertCmd.Parameters.AddWithValue("@is_canceled", isCanceled);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferClientServicesAttendance(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT attendance_id, client_id, execute_date 
            //FROM client_attendance";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int attendanceId = Convert.ToInt32(row["attendance_id"]);
            //        int clientId = Convert.ToInt32(row["client_id"]);
            //        string executeDate = Convert.ToString(row["execute_date"]);

            //        string insertQuery = @"
            //    INSERT INTO client_services_attendance (attendance_id, client_id, client_balance_id, appointment_id, execute_date) 
            //    VALUES (@attendance_id, @client_id, @client_balance_id, @appointment_id, @execute_date)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@attendance_id", attendanceId);
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId);
            //            insertCmd.Parameters.AddWithValue("@client_balance_id", DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@appointment_id", DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@execute_date", executeDate);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferFinance(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT id, id_client_balance, AlbumType, amount_paid, payment_date 
            //FROM finance";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int financeId = Convert.ToInt32(row["id"]);
            //        int clientBalanceId = Convert.ToInt32(row["id_client_balance"]);
            //        string albumType = row["AlbumType"] != DBNull.Value ? Convert.ToString(row["AlbumType"]) : null;
            //        double amountPaid = Convert.ToDouble(row["amount_paid"]);
            //        string paymentDate = Convert.ToString(row["payment_date"]);

            //        string insertQuery = @"
            //    INSERT INTO finance (finance_id, client_balance_id, AlbumType, amount_paid, payment_date) 
            //    VALUES (@finance_id, @client_balance_id, @AlbumType, @amount_paid, @payment_date)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@finance_id", financeId);
            //            insertCmd.Parameters.AddWithValue("@client_balance_id", clientBalanceId);
            //            insertCmd.Parameters.AddWithValue("@AlbumType", albumType);
            //            insertCmd.Parameters.AddWithValue("@amount_paid", amountPaid);
            //            insertCmd.Parameters.AddWithValue("@payment_date", paymentDate);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferArchive(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT archive_id, client_id, employee_id, id_client_balance, attendance_id, action, 
            //       action_type, date, amount_paid, is_moneyOrsession_offre, previousBalanceOrSession_Offre 
            //FROM archive";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int archiveId = row["archive_id"] != DBNull.Value ? Convert.ToInt32(row["archive_id"]) : default;
            //        int clientId = row["client_id"] != DBNull.Value ? Convert.ToInt32(row["client_id"]) : default;
            //        int employeeId = row["employee_id"] != DBNull.Value ? Convert.ToInt32(row["employee_id"]) : default;
            //        int clientBalanceId = row["id_client_balance"] != DBNull.Value ? Convert.ToInt32(row["id_client_balance"]) : default;
            //        int? attendanceId = row["attendance_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["attendance_id"]) : null;
            //        string action = row["action"] != DBNull.Value ? Convert.ToString(row["action"]) : null;
            //        string actionType = row["action_type"] != DBNull.Value ? Convert.ToString(row["action_type"]) : null;
            //        string date = row["date"] != DBNull.Value ? Convert.ToString(row["date"]) : null;
            //        double amountPaid = row["amount_paid"] != DBNull.Value ? Convert.ToDouble(row["amount_paid"]) : default;
            //        int isMoneyOrSessionOffre = row["is_moneyOrsession_offre"] != DBNull.Value ? Convert.ToInt32(row["is_moneyOrsession_offre"]) : default;
            //        string previousBalanceOrSessionOffre = row["previousBalanceOrSession_Offre"] != DBNull.Value ? Convert.ToString(row["previousBalanceOrSession_Offre"]) : null;


            //        string insertQuery = @"
            //    INSERT INTO archive (archive_id, client_id, employee_id, client_balance_id, attendance_id, appointment_id, 
            //                         action, action_type, date, amount_paid, is_moneyOrsession_offre, previousBalanceOrSession_Offre) 
            //    VALUES (@archive_id, @client_id, @employee_id, @client_balance_id, @attendance_id, @appointment_id, 
            //            @action, @action_type, @date, @amount_paid, @is_moneyOrsession_offre, @previousBalanceOrSession_Offre)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@archive_id", archiveId);
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId);
            //            insertCmd.Parameters.AddWithValue("@employee_id", employeeId);
            //            insertCmd.Parameters.AddWithValue("@client_balance_id", clientBalanceId);
            //            insertCmd.Parameters.AddWithValue("@attendance_id", attendanceId.HasValue ? (object)attendanceId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@appointment_id", DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@action", action);
            //            insertCmd.Parameters.AddWithValue("@action_type", actionType);
            //            insertCmd.Parameters.AddWithValue("@date", date);
            //            insertCmd.Parameters.AddWithValue("@amount_paid", amountPaid);
            //            insertCmd.Parameters.AddWithValue("@is_moneyOrsession_offre", isMoneyOrSessionOffre);
            //            insertCmd.Parameters.AddWithValue("@previousBalanceOrSession_Offre", previousBalanceOrSessionOffre);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferAppointmentHasBundles(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT app_bundle_id, appointment_id, bundle_id 
            //FROM appointment_has_bundles";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int appBundleId = Convert.ToInt32(row["app_bundle_id"]);
            //        int appointmentId = Convert.ToInt32(row["appointment_id"]);
            //        int bundleId = Convert.ToInt32(row["bundle_id"]);

            //        string insertQuery = @"
            //    INSERT INTO appointment_has_bundles (app_bundle_id, appointment_id, bundle_id) 
            //    VALUES (@app_bundle_id, @appointment_id, @bundle_id)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@app_bundle_id", appBundleId);
            //            insertCmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            //            insertCmd.Parameters.AddWithValue("@bundle_id", bundleId);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferReminders(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT reminder_id, client_id, reminder, repeat, starttime, is_checked 
            //FROM reminder";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int reminderId = Convert.ToInt32(row["reminder_id"]);
            //        int? clientId = row["client_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["client_id"]) : null;
            //        string reminderText = Convert.ToString(row["reminder"]);
            //        string repeat = Convert.ToString(row["repeat"]);
            //        string startTime = Convert.ToString(row["starttime"]);
            //        int isChecked = Convert.ToInt32(row["is_checked"]);

            //        string insertQuery = @"
            //    INSERT INTO reminder (reminder_id, client_id, reminder, repeat, starttime, is_checked) 
            //    VALUES (@reminder_id, @client_id, @reminder, @repeat, @starttime, @is_checked)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@reminder_id", reminderId);
            //            insertCmd.Parameters.AddWithValue("@client_id", clientId.HasValue ? (object)clientId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@reminder", reminderText);
            //            insertCmd.Parameters.AddWithValue("@repeat", repeat);
            //            insertCmd.Parameters.AddWithValue("@starttime", startTime);
            //            insertCmd.Parameters.AddWithValue("@is_checked", isChecked);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferRequiredVisibleFields(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT id, Fields, Visible, Required 
            //FROM required_visible_fields";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int fieldsId = Convert.ToInt32(row["id"]);
            //        string fields = Convert.ToString(row["Fields"]);
            //        int visible = Convert.ToInt32(row["Visible"]);
            //        int required = Convert.ToInt32(row["Required"]);

            //        string insertQuery = @"
            //    INSERT INTO required_visible_fields (fields_id, Fields, Visible, Required) 
            //    VALUES (@fields_id, @Fields, @Visible, @Required)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@fields_id", fieldsId);
            //            insertCmd.Parameters.AddWithValue("@Fields", fields);
            //            insertCmd.Parameters.AddWithValue("@Visible", visible);
            //            insertCmd.Parameters.AddWithValue("@Required", required);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferHistoryEmployeeAvailability(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT history_id, employee_id, history_date, rank, availability 
            //FROM history_employee_availability";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int historyId = Convert.ToInt32(row["history_id"]);
            //        int? employeeId = row["employee_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["employee_id"]) : null;
            //        string historyDate = Convert.ToString(row["history_date"]);
            //        int rank = Convert.ToInt32(row["rank"]);
            //        string availability = Convert.ToString(row["availability"]);

            //        string insertQuery = @"
            //    INSERT INTO history_employee_availability (history_id, employee_id, history_date, rank, availability) 
            //    VALUES (@history_id, @employee_id, @history_date, @rank, @availability)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@history_id", historyId);
            //            insertCmd.Parameters.AddWithValue("@employee_id", employeeId.HasValue ? (object)employeeId.Value : DBNull.Value);
            //            insertCmd.Parameters.AddWithValue("@history_date", historyDate);
            //            insertCmd.Parameters.AddWithValue("@rank", rank);
            //            insertCmd.Parameters.AddWithValue("@availability", availability);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //private static void TransferProducts(SqlConnection conOld, SQLiteConnection conNew)
            //{
            //    string selectQuery = @"
            //SELECT product_id, product_name, product_price, status 
            //FROM products";
            //    DataTable dataTable = new DataTable();

            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conOld))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            //    {
            //        dataAdapter.Fill(dataTable);
            //    }

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        int productId = Convert.ToInt32(row["product_id"]);
            //        string productName = Convert.ToString(row["product_name"]);
            //        double productPrice = Convert.ToDouble(row["product_price"]);
            //        int status = Convert.ToInt32(row["status"]);

            //        string insertQuery = @"
            //    INSERT INTO products (product_id, product_name, product_price, status) 
            //    VALUES (@product_id, @product_name, @product_price, @status)";

            //        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conNew))
            //        {
            //            insertCmd.Parameters.AddWithValue("@product_id", productId);
            //            insertCmd.Parameters.AddWithValue("@product_name", productName);
            //            insertCmd.Parameters.AddWithValue("@product_price", productPrice);
            //            insertCmd.Parameters.AddWithValue("@status", status);
            //            insertCmd.ExecuteNonQuery();
            //        }
            //    }
            //}

        }
}
