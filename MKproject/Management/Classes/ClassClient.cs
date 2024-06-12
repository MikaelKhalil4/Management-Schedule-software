using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using GlobalFunctions;
using static MKproject.Management.ClassBundles;
using System.Data.SQLite;

namespace MKproject.Management
{
    public class ClassClient
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        //? bas btonhatt lal int w double ta neoul enno hole can be null, or string image, datetime by default fiyun yehkhdo nullvalues
        //personal
        public int ClientId { get; set; }


        //Static fields
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
        public string Gender { get; set; }
        public string Job { get; set; }
        public string Adress { get; set; }
        public string InstaUserName { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public Image ProfileImage { get; set; }
        public string ProfileImageName { get; set; }
        private DateTime? birthDate;
        public DateTime? BirthDate
        {
            get { return birthDate; }
            set
            {

                birthDate = value;
                if (birthDate != null)
                {
                    Age = RandomFunctions.AgeCalculator((DateTime)birthDate);
                }
                else
                {
                    Age = null;
                }

            }
        }
        public int? Age { get; set; }
        public string MaritalStatus { get; set; }









        //ma hattayna? cz hole deyman fiyun values
        public bool IsParent { get; set; }
        public bool IsChild { get; set; }

        public string AlbumType { get; set; }  //when it null, mean no album


        //business
        public DateTime? SaveDate { get; set; }
        public DateTime? LastVisit { get; set; }//used to know if the client is visitor or none visitor
        public DateTime? RegistrationDate { get; set; }//used to know if the client is member or no


        public string PackagesRemaining;
        public int PackagesStatus;
        public bool PackagesHAsStatus;

        public int TotalAttendance { get; set; }//you should do its logic on reducing
        public int daysLeft { get; set; }//lezim zida bi sql w wen ma ken metel el seeion left    
        public double TotalBalance { get; set; }
        public double TotalPayment { get; set; }




        public enum ClientGender
        {
            All,
            Male,
            Female
        }

        public enum enumStaticFields//most of enum strings are in registation field table  the same string in sql 
        {
            //static
            [StringValue("Profile Image")]
            ProfileImage=1,//kermel el label li bel new register
            [StringValue("Full Name")]
            FullName,
            [StringValue("Phone Number")]
            PhoneNumber,
            [StringValue("Email")]
            Email,
            [StringValue("Gender")]
            Gender,
            [StringValue("Birthday")]
            BirthDate,
            [StringValue("Job")]
            Job,
            [StringValue("Adress")]
            Adress,        
            [StringValue("Insta")]
            InstaUserName,                       
            [StringValue("Marital status")]
            MaritalStatus,
            [StringValue("How did you know about us")]
            HowDidYouKnowAboutUs,
            [StringValue("Note")]
            Note=10000,//lieanno it should come after el custpomize fields
      
            //thats how we access a value
            //Enum.GetName(typeof(ClassClientCustom.Type), ClassClientCustom.Type.) 
            //Enum.GetName(typeof(ClassClientCustom.Type), ClassClientCustom.Type.) 
        }
        public enum enumGender//used for filling the fields
        {
            [StringValue("Male")]
            Male,
            [StringValue("Female")]
            Female
        }
        public enum enumHowDidYouKnowAboutUs//checkbox
        {
            [StringValue("Instagram")]
            instagram,//TLPGlobal
            [StringValue("Facebook")]
            Facebook,
            [StringValue("Tiktok")]
            Tiktok,
            [StringValue("Bouche A L'Oreille")]//Add Textbox
            BoucheAOreille,
            [StringValue("Brochure")]
            brochure,
            [StringValue("Gift Voucher")]
            GiftVoucher,
            [StringValue("Novo Club")]
            NovoClub,
            [StringValue("Others")]//Add Textbox
            Others
        }
        public enum enumInsta
        {
            [StringValue("Invitation")]
            Invitation,
            [StringValue("Boosting")]
            Boosting,
            [StringValue("By Searching")]
            BySearching,
            [StringValue("Customer Mention")]//Add Textbox
            CustomerMention
        }
        public enum enumMaritalStatus
        {
            [StringValue("Single")]
            Single,
            [StringValue("Married")]
            Married,
            [StringValue("Have Children")]//add textbox UCPureNumber
            HaveChildren,
        }




        public ClassClient()
        {

        }


        //select

        public static int GetLastClientIDSQL()
        {
            string getLastClientIdQuery = "SELECT Max(client_id) FROM client";
            SQLiteCommand command = new SQLiteCommand(getLastClientIdQuery, con);
            con.Open();
            int lastClientId = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return lastClientId;

        }
        public static DataTable GetAllClientsSQL()
        {
            string queryClient = "select client_id,name,family_name,phone_number as \"Phone Number\",AlbumType as \"Album\",save_date,check_in,Registration_Date,total_balance,total_payment,IsChild,gender as \"Gender\",job as \"Job\",adress as \"Adress\",last_time_searched from client ORDER  BY last_time_searched  DESC  "; /*ORDER BY check_in DESC*/

            SQLiteCommand cmd = new SQLiteCommand(queryClient, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetAllClientSpecificInfoSQL()
        {
            string queryClient = "select client_id,name,family_name, phone_number as \"Phone Number\",Registration_Date,total_balance from client ORDER BY last_time_searched  DESC  "; /*ORDER BY check_in DESC*/

            SQLiteCommand cmd = new SQLiteCommand(queryClient, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetClientIdFromPhoneNumberSQL(string PhoneNumber)
        {
            string queryClient = "select client_id  from client WHERE phone_number='" + PhoneNumber + "'";

            SQLiteCommand cmd = new SQLiteCommand(queryClient, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["client_id"]);
        }//lezim nekhud into consideration el parent w el child li eendun samephone
        public static DataTable GetAllClientsInfoSQL(int ClientID)
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from client where client_id=@client_id", con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static bool SearchClientPhoneNumberSQL(int? ClientId, string Phone)
        {
            con.Open();
            string checkQuery;
            SQLiteCommand checkCommand = null;
            if (ClientId == null)
            {
                checkQuery = "SELECT COUNT(*) FROM client WHERE phone_number = @PhoneNumber AND IsChild = 0";
                checkCommand = new SQLiteCommand(checkQuery, con);
            }
            else
            {
                checkQuery = "SELECT COUNT(*) FROM client WHERE phone_number = @PhoneNumber AND IsChild = 0 AND client_id!=@client_id";
                checkCommand = new SQLiteCommand(checkQuery, con);
                checkCommand.Parameters.AddWithValue("@client_id", ClientId);

            }
            checkCommand.Parameters.AddWithValue("@PhoneNumber", Phone);


            int count = Convert.ToInt32(checkCommand.ExecuteScalar());
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
        public static int CalculateNumberOfChildrenSQL(string phoneNumber)
        {

            int numberOfChildren = 0;
            con.Open();

            string query = "SELECT COUNT(*) FROM client WHERE phone_number = @phoneNumber AND IsChild = 1";
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            numberOfChildren = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return numberOfChildren;

        }
        public static DataTable GetLinkedChildrenSQL(string ChildOrParentPhoneNumber)
        {
            DataTable dt = new DataTable();
            string query = "SELECT name || ' ' || family_name AS  [Full Name],client_id FROM client WHERE phone_number = @phoneNumber AND IsChild = 1";
            con.Open();
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", ChildOrParentPhoneNumber);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            con.Close();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable GetLinkedPArentsSQL(string ChildOrParentPhoneNumber)
        {
            DataTable dt = new DataTable();
            string query = "SELECT name || ' ' || family_name AS [Full Name],client_id,phone_number FROM client WHERE phone_number = @phoneNumber AND IsParent = 1 ";
            con.Open();
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", ChildOrParentPhoneNumber);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            con.Close();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable GetAllParentsSQL(int? ClientId)
        {

            DataTable dt = new DataTable();
            string query = "SELECT client_id,name,family_name,phone_number as \"Phone Number\",adress as \"Adress\",IsParent FROM Client WHERE IsChild='0' ";
            SQLiteCommand command = null;

            if (ClientId != null)//update form
            {
                query += " AND client_id!=@client_id ";
            }
            query += " ORDER BY last_time_searched  DESC";


            command = new SQLiteCommand(query, con);


            if (ClientId != null)//update form
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
            }


            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable GetSoonBirthdaysSQL()
        {

            // SQL query to select clients with birthdays within 7 days
            string query = @"
     SELECT 
        client_id,  
        name || ' ' || family_name AS Name, 
        date_of_birth AS Birthday
    FROM 
        client 
    WHERE
        date_of_birth IS NOT NULL
        AND (
            (strftime('%m', date_of_birth) > strftime('%m', 'now') 
                OR (strftime('%m', date_of_birth) = strftime('%m', 'now') AND strftime('%d', date_of_birth) >= strftime('%d', 'now')))
            AND
            (strftime('%m', date_of_birth) < strftime('%m', date('now', '+30 days')) 
                OR (strftime('%m', date_of_birth) = strftime('%m', date('now', '+30 days')) AND strftime('%d', date_of_birth) <= strftime('%d', date('now', '+30 days'))))
            OR
            (strftime('%m', 'now') > strftime('%m', date('now', '+30 days')) AND (
                (strftime('%m', date_of_birth) > strftime('%m', 'now') 
                    OR (strftime('%m', date_of_birth) = strftime('%m', 'now') AND strftime('%d', date_of_birth) >= strftime('%d', 'now')))
                OR
                (strftime('%m', date_of_birth) < strftime('%m', date('now', '+30 days')) 
                    OR (strftime('%m', date_of_birth) = strftime('%m', date('now', '+30 days')) AND strftime('%d', date_of_birth) <= strftime('%d', date('now', '+30 days'))))
            ))
        )
    ORDER BY 
        strftime('%m', date_of_birth) ASC, strftime('%d', date_of_birth) ASC
";

            SQLiteCommand command = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
        public static double GetClientTotalBalance(int ClientId)
        {
            double TotalBalance;
            con.Open();
            string getLastClientIdQuery = "SELECT total_balance FROM client where client_id='" + ClientId + "'";
            using (SQLiteCommand command = new SQLiteCommand(getLastClientIdQuery, con))
            {
                TotalBalance = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return TotalBalance;
        }

        //UpdateAndInsert

        public static bool UpdateClientCheckInSQLIfShould(int ClientID, DateTime Date)
        {
            string querySelect = @"SELECT MAX(execute_date) FROM client_services_attendance WHERE client_id = @client_id";
            SQLiteCommand cmdSelect = new SQLiteCommand(querySelect, con);
            cmdSelect.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            DateTime? MaxCheckInDate = cmdSelect.ExecuteScalar() is DBNull ? null : Convert.ToDateTime(cmdSelect.ExecuteScalar());
            con.Close();

            if (MaxCheckInDate == null || MaxCheckInDate < Date)
            {
                string query = "UPDATE client SET check_in=@check_in WHERE client_id=@client_id ";
                SQLiteCommand cmdUpdate = new SQLiteCommand(query, con);
                cmdUpdate.Parameters.AddWithValue("@client_id", ClientID);
                cmdUpdate.Parameters.AddWithValue("@check_in", Date);
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void UpdateClientTotalBalanceSQL(int ClientID, double TotalBalance, bool OverRideOrAdd)
        {
            string query;

            if (OverRideOrAdd)
            {
                query = "UPDATE client SET total_balance=@total_balance where client_id=@client_id";
            }
            else
            {
                query = "UPDATE client SET total_balance = total_balance + @total_balance where client_id=@client_id";
            }

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@total_balance", TotalBalance);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientTotalPaymentSQL(int ClientID, double TotalPayemnt, bool OverRideOrAdd)
        {
            string query;

            if (OverRideOrAdd)
            {
                query = "UPDATE client SET total_payment=@total_payment where client_id=@client_id";
            }
            else
            {
                query = "UPDATE client SET total_payment= total_payment + @total_payment where client_id=@client_id";
            }

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@total_payment", TotalPayemnt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void MakeClientMemberSQL(int ClientID)
        {
            string query = "UPDATE client SET Registration_Date=@Registration_Date  where client_id=@client_id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@Registration_Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientLastsearchedSQL(int ClientID)
        {
            string query = "UPDATE client SET last_time_searched=@last_time_searched  where client_id=@client_id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@last_time_searched", DateTime.Now);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientIsParentSQL(int ClientID, bool IsParent)
        {
            string query = "UPDATE client SET IsParent=@IsParent  where client_id=@client_id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@IsParent", IsParent);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientAlbumSQL(int ClientId, string AlbumName)
        {

            string updateQuery = "UPDATE client " +
                                "SET AlbumType = @AlbumType " +
                                "WHERE client_id = @client_id";
            SQLiteCommand command = new SQLiteCommand(updateQuery, con);
            if (AlbumName != null)
            {
                command.Parameters.AddWithValue("@AlbumType", AlbumName);
            }
            else
            {
                command.Parameters.AddWithValue("@AlbumType", DBNull.Value);
            }
            command.Parameters.AddWithValue("@client_id", ClientId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();


        }
        public static void UpdateAllChildrensPhoneNumberSQL(string OldPhoneNumber, string NewPhoneNumber)
        {
            string query = "UPDATE client SET phone_number=@NewPhoneNumber where phone_number=@OldPhoneNumber ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", NewPhoneNumber);
            cmd.Parameters.AddWithValue("@OldPhoneNumber", OldPhoneNumber);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //when a client purchase eenda connection maa many forms, that swhy
        public static DataTable PurchaseAService(ClassBundles Bundle, DateTime BackOfficeDate, DateTime AttendanceDate, ClassClientCustom Client, int? appointmentId)
        {
            //SQLAndLogic                        
            ActionsEnum actiontype;
            int? AttendanceId;

            ClassClientBalance.InsertToClientBalance(Client.ClientId, Bundle.BundleID, Bundle.EnumBundletype.ToString());
            DataTable dtinserteditem = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(null);
            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one                                            
            int ClientBalanceId = Convert.ToInt32(InsertedRow["client_balance_id"]);

            if (Bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
            {
                actiontype = ActionsEnum.SoloPurchases;
                UpdateClientCheckInSQLIfShould(Client.ClientId, AttendanceDate);
                ProjectToSQL.InsertToClientAttendance(Client.ClientId, ClientBalanceId, appointmentId, AttendanceDate);
                AttendanceId = SQLToProject.GetLAstInsertedAttendance();//ejbare tahet InsertToClientAttendance
            }
            else
            {
                actiontype = ActionsEnum.Purchases;
                AttendanceId = null;
            }

            ClassClientCustom.UpdateClientTotalBalanceSQL(Client.ClientId, -Bundle.Price, false);

            ClassBackOffice backOffice = new ClassBackOffice(Client.ClientId, actiontype, LOGIN.Employee.EmployeeId, ClientBalanceId, null, AttendanceId, appointmentId, null, null, BackOfficeDate);
            backOffice.CreateActionDetails(InsertedRow);
            backOffice.InsertToArchiveSQL();

            ProjectToSQL.InsertToFinance(Convert.ToInt32(InsertedRow["client_balance_id"]), 0, BackOfficeDate, Client.AlbumType);//kermel el count

            if (Client.RegistrationDate == null && Bundle.IsMemberShip == true)
            {
                MakeClientMemberSQL(Client.ClientId);

            }
            return dtinserteditem;
        }
        public static DataTable PurchaseAProduct(ClassProduct product, DateTime Date, ClassClientCustom Client)
        {
            //SQL
            ClassClientBalance.InsertToClientBalance(Client.ClientId, product.ID, null);
            DataTable dtinserteditem = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(null);

            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one                     

            ClassClientCustom.UpdateClientTotalBalanceSQL(Client.ClientId, -product.Price, false);

            ClassBackOffice backOffice = new ClassBackOffice(Client.ClientId, ActionsEnum.Purchases, LOGIN.Employee.EmployeeId, Convert.ToInt32(InsertedRow["client_balance_id"]), null, null, null, null, null, Date);
            backOffice.CreateActionDetails(InsertedRow);
            backOffice.InsertToArchiveSQL();

            ProjectToSQL.InsertToFinance(Convert.ToInt32(InsertedRow["client_balance_id"]), 0, Date, Client.AlbumType);//kermel el count
            return dtinserteditem;
        }



        string ImageName = "Client";//theclient id will be added to t
        public virtual void InsertClientToSQL()
        {


            // Phone number does not exist, proceed with insertion
            string insertQuery = "INSERT INTO client (name, family_name, gender, date_of_birth, phone_number, adress, job, special_note, insta_user, IsChild,IsParent,AlbumType,last_time_searched,save_date,Registration_Date,check_in,total_balance,total_payment,email) " +
                                 "VALUES (@Name, @FamilyName, @Gender, @DateOfBirth,@PhoneNumber, @Adress, @Job, @SpecialNote, @InstaUser, @IsChild,@IsParent,@AlbumType,@last_time_searched,@save_date,@Registration_Date,@check_in,@total_balance,@total_payment,@Email)";

            SQLiteCommand command = new SQLiteCommand(insertQuery, con);

           
            if (Fname == null)
            {

                command.Parameters.AddWithValue("@Name", DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@Name", Fname);


            if (Lname == null)
                command.Parameters.AddWithValue("@FamilyName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@FamilyName", Lname);


            if (Gender == null)
                command.Parameters.AddWithValue("@Gender", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Gender", Gender);


            if (BirthDate == null)
                command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
            else
                command.Parameters.AddWithValue("@DateOfBirth", ((DateTime)BirthDate).ToString("yyyy-MM-dd"));


          

            if (PhoneNumber == null)
                command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
            else
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);


            if (Adress == null)
                command.Parameters.AddWithValue("@Adress", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Adress", Adress);


            if (Job == null)
                command.Parameters.AddWithValue("@Job", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Job", Job);


            if (Note == null)
                command.Parameters.AddWithValue("@SpecialNote", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SpecialNote", Note);


            if (InstaUserName == null)
                command.Parameters.AddWithValue("@InstaUser", DBNull.Value);
            else
                command.Parameters.AddWithValue("@InstaUser", InstaUserName);


            if (Email == null)
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);


          

            command.Parameters.AddWithValue("@IsChild", IsChild);
            command.Parameters.AddWithValue("@IsParent", IsParent);


            if (AlbumType == null)
                command.Parameters.AddWithValue("@AlbumType", DBNull.Value);
            else
                command.Parameters.AddWithValue("@AlbumType", AlbumType);


         



            command.Parameters.AddWithValue("@total_balance", 0);
            command.Parameters.AddWithValue("@total_payment", 0);


            command.Parameters.AddWithValue("@save_date", DateTime.Now);
            command.Parameters.AddWithValue("@check_in", DBNull.Value);
            command.Parameters.AddWithValue("@Registration_Date", DBNull.Value);
            command.Parameters.AddWithValue("@last_time_searched", DateTime.Now);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

           
            if (ProfileImage != null)
            {
                string QueryUpdateImage = "Update client Set  profile_image_path=@profile_image_path where client_id=@client_id ";
                SQLiteCommand commandUpdateImage = new SQLiteCommand(QueryUpdateImage, con);

                int InsertedClientId = GetLastClientIDSQL();
                ImagesFunctions.SaveImage(this.ProfileImage, Program.FolderProfileImagePath, ImageName + InsertedClientId);
                commandUpdateImage.Parameters.AddWithValue("@profile_image_path", ImageName + InsertedClientId);
                commandUpdateImage.Parameters.AddWithValue("@client_id", InsertedClientId);
                con.Open();
                commandUpdateImage.ExecuteNonQuery();
                con.Close();
            }
           

        }
        public virtual void UpdateClientToSQL(bool PicisChanged)
        {
            string UpdateQuery;
            SQLiteCommand command;
            if (PicisChanged)
            {
                UpdateQuery = @"UPDATE client 
                    SET  name = @Name, family_name = @FamilyName, gender = @Gender,date_of_birth = @DateOfBirth,           
                     phone_number = @PhoneNumber, 
                     adress = @Adress, job = @Job, special_note = @SpecialNote, 
                     insta_user = @InstaUser, IsChild = @IsChild, email = @Email,              
                     profile_image_path=@profile_image_path
                     WHERE client_id = @client_id";


                command = new SQLiteCommand(UpdateQuery, con);

                if (ProfileImage == null)
                {
                    ImagesFunctions.DeleteImage(Program.FolderProfileImagePath, ImageName + ClientId);
                    command.Parameters.AddWithValue("@profile_image_path", DBNull.Value);
                }
                else
                {
                    ImagesFunctions.SaveImage(this.ProfileImage, Program.FolderProfileImagePath, ImageName + ClientId);
                    command.Parameters.AddWithValue("@profile_image_path", ImageName + ClientId);
                }
            }
            else
            {
                UpdateQuery = @"UPDATE client 
                    SET  name = @Name, family_name = @FamilyName, gender = @Gender,date_of_birth = @DateOfBirth,                   
                     phone_number = @PhoneNumber, 
                     adress = @Adress, job = @Job, special_note = @SpecialNote, 
                     insta_user = @InstaUser, IsChild = @IsChild, email = @Email                    
                     WHERE client_id = @client_id";

                command = new SQLiteCommand(UpdateQuery, con);

            }


            if (Fname == null)
                command.Parameters.AddWithValue("@Name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Name", Fname);


            if (Lname == null)
                command.Parameters.AddWithValue("@FamilyName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@FamilyName", Lname);


            if (Gender == null)
                command.Parameters.AddWithValue("@Gender", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Gender", Gender);


            if (BirthDate == null)
                command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
            else
                command.Parameters.AddWithValue("@DateOfBirth", ((DateTime)BirthDate).ToString("yyyy-MM-dd"));


         

            if (PhoneNumber == null)
                command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
            else
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);


            if (Adress == null)
                command.Parameters.AddWithValue("@Adress", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Adress", Adress);


            if (Job == null)
                command.Parameters.AddWithValue("@Job", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Job", Job);


            if (Note == null)
                command.Parameters.AddWithValue("@SpecialNote", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SpecialNote", Note);


            if (InstaUserName == null)
                command.Parameters.AddWithValue("@InstaUser", DBNull.Value);
            else
                command.Parameters.AddWithValue("@InstaUser", InstaUserName);


            if (Email == null)
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);


           

            command.Parameters.AddWithValue("@IsChild", IsChild);
            command.Parameters.AddWithValue("@client_id", ClientId);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public  void DeleteClientToSQL()
        {
            //ejbare bi hal order men wara el relation baynetu

            con.Open();

            //kermel el balance
            string QueryDeleteArchive = "DELETE FROM archive WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd1 = new SQLiteCommand(QueryDeleteArchive, con);
            cmd1.ExecuteNonQuery();

            string QueryDeleteFinance = "DELETE FROM finance WHERE client_balance_id IN ( SELECT client_balance_id  FROM client_balance WHERE client_id = '" + ClientId + "')";
            SQLiteCommand cmd2 = new SQLiteCommand(QueryDeleteFinance, con);
            cmd2.ExecuteNonQuery();


            //kermel el appintment
            string QueryDeleteClientAttendace = "DELETE FROM client_services_attendance WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd4 = new SQLiteCommand(QueryDeleteClientAttendace, con);
            cmd4.ExecuteNonQuery();

            string QueryDeleteAppBundles = "DELETE FROM appointment_has_bundles WHERE appointment_id IN ( SELECT appointment_id  FROM appointments WHERE client_id = '" + ClientId + "')";
            SQLiteCommand cmd8 = new SQLiteCommand(QueryDeleteAppBundles, con);
            cmd8.ExecuteNonQuery();

            string QueryDeleteAppointments = "DELETE FROM appointments WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd5 = new SQLiteCommand(QueryDeleteAppointments, con);
            cmd5.ExecuteNonQuery();
            //


            string QueryDeleteClientBalance = "DELETE FROM client_balance WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd3 = new SQLiteCommand(QueryDeleteClientBalance, con);
            cmd3.ExecuteNonQuery();
            //


            string QueryDeleteClientReminders = "DELETE FROM reminder WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd7 = new SQLiteCommand(QueryDeleteClientReminders, con);
            cmd7.ExecuteNonQuery();

            string QueryDeleteClient = "DELETE FROM client WHERE client_id = '" + ClientId + "'";
            SQLiteCommand cmd6 = new SQLiteCommand(QueryDeleteClient, con);
            cmd6.ExecuteNonQuery();


            con.Close();

        }



        public bool CheckIfCLientHasClientBalanceRefrences()
        {
            string query = @"Select Count(*)
                            FROM client as cl
                            where client_id=@client_id
                            And
                            EXISTS (SELECT * FROM client_balance as cb where cl.client_id=cb.client_id)";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@client_id", ClientId);
            con.Open();
            int nb = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (nb > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    
       public static int CalculateNOAttendance(int ClientId)
        {
            DataTable AttendDtt = SQLToProject.GetAllClientAttendance(ClientId);

            // Group by client_id and count sessions
            var groupedData = from row in AttendDtt.AsEnumerable()
                              group row by new
                              {
                                  ClientId = row.Field<Int64>("client_id"),

                              } into grp
                              select new
                              {
                                  ClientId = grp.Key.ClientId,
                                  NumberOfSessions = grp.Count()
                              };

            int TotalAttend = 0;
            foreach (var group in groupedData)
            {
                TotalAttend = group.NumberOfSessions;
            }
            return TotalAttend;
        }

        public ClassClientCustom Copy()//This Copy wont work fi Property eza fi  reference-type Properties (classes or list)/ eenda it s own methode, check ClassAppointment
        {
            return (ClassClientCustom)this.MemberwiseClone();
        }
    }



}
