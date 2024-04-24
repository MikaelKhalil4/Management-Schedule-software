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

namespace MKproject.Management
{
    public class ClassClient
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        //? bas btonhatt lal int w double ta neoul enno hole can be null, or string image, datetime by default fiyun yehkhdo nullvalues
        //personal
        public int ClientId { get; set; }

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
        public string MaritalStatus { get; set; }
        public string KnowAboutUs { get; set; }

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
        //ma hattayna? cz hole deyman fiyun values
        public bool IsParent { get; set; }
        public bool IsChild { get; set; }


        public string AlbumType { get; set; }  //when it null, mean no album

        public Image ProfileImage { get; set; }
        public string ProfileImageName { get; set; }

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

        //sport
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyShapeTarget { get; set; }
        public string MuscleFocusOn { get; set; }
        public string Injuries { get; set; }
        public string Hand { get; set; }
        public int? SessionPerWeek { get; set; }
        public string Note { get; set; }
        public string GoalsTimeline { get; set; }
        public string Smoking { get; set; }
        public string Alcohol { get; set; }
        public string ExerciseHistory { get; set; }
        public string SleepPattern { get; set; }
        public string StressLevel { get; set; }
        public string FightingSkills { get; set; }







        public enum ClientGender
        {
            All,
            Male,
            Female
        }

        public enum enumType//most of enum strings are in registation field table  the same string in sql 
        {
            //personal

            [StringValue("Full Name")]
            FullName,
            FirstName,
            LastName,
            [StringValue("Phone Number")]
            PhoneNumber,
            [StringValue("Gender")]
            Gender,
            [StringValue("Job")]
            Job,
            [StringValue("Adress")]
            Adress,
            [StringValue("Insta")]
            InstaUserName,
            [StringValue("Birthday")]
            BirthDate,
            [StringValue("Age")]
            Age,
            IsChild,
            IsParent,
            [StringValue("New Album")]//hal el wahide li mesg mawjude bel registartion fields bas shelneha lieano eeyzina
            Album,
            [StringValue("Image")]
            FaceImage,
            [StringValue("Email")]
            Email,
            [StringValue("Marital status")]
            MaritalStatus,
            [StringValue("How did you know about us")]
            HowDidYouKnowAboutUs,
            [StringValue("Notes")]
            Note,

            //buisness
            LastVisit,
            RegistrationDate,
            SessionNumber,
            SessionLeft,

            //sport
            [StringValue("Height")]
            Height,
            [StringValue("Weight")]
            Weight,
            [StringValue("Body Shape Target")]
            BodyShapeTarget,
            [StringValue("Muscles Focus")]
            MuscleFocusOn,
            [StringValue("Injuries")]
            Injuries,
            [StringValue("Hand")]
            Hand,
            [StringValue("Sessions/Week")]
            SessionPerWeek,
            Levels,
            levelFeedback,
            Vision,
            [StringValue("Goals Timeline")]
            GoalsTimeline,
            [StringValue("Smoking")]
            Smoking,
            [StringValue("Alcohol")]
            Alcohol,
            [StringValue("Exercise History")]
            ExerciseHistory,
            [StringValue("Sleep Pattern")]
            SleepPattern,
            [StringValue("Stress Level")]
            StressLevel,
            [StringValue("Focus on Boxing skills")]
            BoxingSkills,


            //thats how we access a value
            //Enum.GetName(typeof(ClassClient.Type), ClassClient.Type.) 
            //Enum.GetName(typeof(ClassClient.Type), ClassClient.Type.) 
        }




        public ClassClient()
        {

        }


        //select
        public static int GetLastClientIDSQL()
        {

            int lastClientId;
            con.Open();
            string getLastClientIdQuery = "SELECT Max(client_id) FROM client";
            using (SqlCommand command = new SqlCommand(getLastClientIdQuery, con))
            {
                lastClientId = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return lastClientId;
        }
        public static DataTable GetAllClientsSQL()
        {
            string queryClient = "select client_id,name,family_name,phone_number as \"Phone Number\",AlbumType as \"Album\",save_date,check_in,Registration_Date,total_balance,total_payment,IsChild,gender as \"Gender\",job as \"Job\",adress as \"Adress\",last_time_searched from client ORDER  BY last_time_searched  DESC  "; /*ORDER BY check_in DESC*/

            SqlCommand cmd = new SqlCommand(queryClient, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetAllClientSpecificInfoSQL()
        {
            string queryClient = "select client_id,name,family_name, phone_number as \"Phone Number\",Registration_Date,total_balance from client ORDER BY last_time_searched  DESC  "; /*ORDER BY check_in DESC*/

            SqlCommand cmd = new SqlCommand(queryClient, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetClientIdFromPhoneNumberSQL(string PhoneNumber)
        {
            string queryClient = "select client_id  from client WHERE phone_number='" + PhoneNumber + "'";

            SqlCommand cmd = new SqlCommand(queryClient, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (int)dt.Rows[0]["client_id"];
        }//lezim nekhud into consideration el parent w el child li eendun samephone
        public static DataTable GetAllClientsInfoSQL(int ClientID)
        {
            SqlCommand cmd = new SqlCommand("select * from client where client_id=@client_id", con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static bool SearchClientPhoneNumberSQL(int? ClientId, string Phone)
        {
            con.Open();
            string checkQuery;
            SqlCommand checkCommand = null;
            if (ClientId == null)
            {
                checkQuery = "SELECT COUNT(*) FROM client WHERE phone_number = @PhoneNumber AND IsChild = 0";
                checkCommand = new SqlCommand(checkQuery, con);
            }
            else
            {
                checkQuery = "SELECT COUNT(*) FROM client WHERE phone_number = @PhoneNumber AND IsChild = 0 AND client_id!=@client_id";
                checkCommand = new SqlCommand(checkQuery, con);
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
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            numberOfChildren = (int)command.ExecuteScalar();
            con.Close();
            return numberOfChildren;

        }
        public static DataTable GetLinkedChildrenSQL(string ChildOrParentPhoneNumber)
        {
            DataTable dt = new DataTable();
            string query = "SELECT CONCAT(name, ' ', family_name) AS  [Full Name],client_id FROM client WHERE phone_number = @phoneNumber AND IsChild = 1";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", ChildOrParentPhoneNumber);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            con.Close();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable GetLinkedPArentsSQL(string ChildOrParentPhoneNumber)
        {
            DataTable dt = new DataTable();
            string query = "SELECT CONCAT(name, ' ', family_name) AS [Full Name],client_id,phone_number FROM client WHERE phone_number = @phoneNumber AND IsParent = 1 ";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@phoneNumber", ChildOrParentPhoneNumber);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            con.Close();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable GetAllParentsSQL(int? ClientId)
        {

            DataTable dt = new DataTable();
            string query = "SELECT client_id,name,family_name,phone_number as \"Phone Number\",adress as \"Adress\",IsParent FROM Client WHERE IsChild='false' ";
            SqlCommand command = null;

            if (ClientId != null)//update form
            {
                query += " AND client_id!=@client_id ";
            }
            query += " ORDER BY last_time_searched  DESC";


            command = new SqlCommand(query, con);


            if (ClientId != null)//update form
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
            }


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }
        public static  DataTable GetSoonBirthdaysSQL()
        {

            // SQL query to select clients with birthdays within 7 days
            string query = @"DECLARE @Today DATE = GETDATE();
                    DECLARE @In14Days DATE = DATEADD(DAY, 30, @Today);
                    SELECT 
                      client_id,  
                      CONCAT(name, ' ', family_name) AS Name, 
                      date_of_birth AS Birthday
                    FROM 
                       client 
                    WHERE
                    date_of_birth IS NOT NULL
                    AND (
                   (MONTH(date_of_birth) > MONTH(@Today) OR (MONTH(date_of_birth) = MONTH(@Today) AND DAY(date_of_birth) >= DAY(@Today)))
                   AND
                   (MONTH(date_of_birth) < MONTH(@In14Days) OR (MONTH(date_of_birth) = MONTH(@In14Days) AND DAY(date_of_birth) <= DAY(@In14Days)))
                   OR
                   (MONTH(@Today) > MONTH(@In14Days) AND (
                 (MONTH(date_of_birth) > MONTH(@Today) OR (MONTH(date_of_birth) = MONTH(@Today) AND DAY(date_of_birth) >= DAY(@Today)))
                   OR
                 (MONTH(date_of_birth) < MONTH(@In14Days) OR (MONTH(date_of_birth) = MONTH(@In14Days) AND DAY(date_of_birth) <= DAY(@In14Days)))
                ))
                 )
                ORDER BY 
              MONTH(date_of_birth) ASC , DAY(date_of_birth) ASC
              ";

            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
        public static double GetClientTotalBalance(int ClientId)
        {
            double TotalBalance;
            con.Open();
            string getLastClientIdQuery = "SELECT total_balance FROM client where client_id='"+ ClientId + "'";
            using (SqlCommand command = new SqlCommand(getLastClientIdQuery, con))
            {
                TotalBalance = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return TotalBalance;
        }

        //UpdateAndInsert

        public static void UpdateClientCheckInSQL(int ClientID, DateTime Date)
        {
            string query = "UPDATE client SET check_in=@check_in WHERE client_id=@client_id ";

            SqlCommand cmdUpdate = new SqlCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_id", ClientID);
            cmdUpdate.Parameters.AddWithValue("@check_in", Date);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateClientTotalBalanceSQL(int ClientID, double TotalBalance,bool OverRideOrAdd)
        {
            string query;

            if (OverRideOrAdd)
            {
                query = "UPDATE client SET total_balance=@total_balance where client_id=@client_id";
            }
            else
            {
                query = "UPDATE client SET total_balance+=@total_balance where client_id=@client_id";
            }

            SqlCommand cmd = new SqlCommand(query, con);
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
                query = "UPDATE client SET total_payment+=@total_payment where client_id=@client_id";
            }

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@total_payment", TotalPayemnt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void MakeClientMemberSQL(int ClientID)
        {
            string query = "UPDATE client SET Registration_Date=@Registration_Date  where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Registration_Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientLastsearchedSQL(int ClientID)
        {
            string query = "UPDATE client SET last_time_searched=@last_time_searched  where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@last_time_searched", DateTime.Now);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientIsParentSQL(int ClientID, bool IsParent)
        {
            string query = "UPDATE client SET IsParent=@IsParent  where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, con);
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
            SqlCommand command = new SqlCommand(updateQuery, con);
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
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", NewPhoneNumber);
            cmd.Parameters.AddWithValue("@OldPhoneNumber", OldPhoneNumber);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //when a client purchase eenda connection maa many forms, that swhy
        public static DataTable PurchaseAService(ClassBundles Bundle, DateTime Date, ClassClient Client, int? appointmentId)
        {
            //SQLAndLogic                        
            string action;
            ActionsEnum actiontype;
            int? AttendanceId;

            ClassClientBalance.InsertToClientBalance(Client.ClientId, Bundle.BundleID, Bundle.EnumBundletype.ToString());
            DataTable dtinserteditem = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(null);
            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one                                            
            int ClientBalanceId = (int)InsertedRow["client_balance_id"];

            if (Bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
            {
                actiontype = ActionsEnum.SoloPurchases;
                UpdateClientCheckInSQL(Client.ClientId, Date);
                ProjectToSQL.InsertToClientAttendance(Client.ClientId, ClientBalanceId, appointmentId);
                AttendanceId = SQLToProject.GetLAstInsertedAttendance();//ejbare tahet InsertToClientAttendance
            }
            else
            {
                actiontype = ActionsEnum.Purchases;
                AttendanceId = null;
            }

            ClassClient.UpdateClientTotalBalanceSQL(Client.ClientId, -Bundle.Price, false);

            ClassBackOffice backOffice = new ClassBackOffice(Client.ClientId, actiontype, LOGIN.Employee.EmployeeId, ClientBalanceId, null, AttendanceId, appointmentId, null, null, Date);
            backOffice.CreateActionDetails(InsertedRow);
            backOffice.InsertToArchiveSQL();

            ProjectToSQL.InsertToFinance((int)InsertedRow["client_balance_id"], 0, Date, Client.AlbumType);//kermel el count
         
            if (Client.RegistrationDate == null && Bundle.IsMemberShip == true)
            {
                MakeClientMemberSQL(Client.ClientId);

            }
            return dtinserteditem;
        }
        public static DataTable PurchaseAProduct(ClassProduct product, DateTime Date, ClassClient Client)
        {
            //SQL
            ClassClientBalance.InsertToClientBalance(Client.ClientId, product.ID, null);
            DataTable dtinserteditem = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(null);

            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one                     

            ClassClient.UpdateClientTotalBalanceSQL(Client.ClientId, -product.Price, false);

            ClassBackOffice backOffice = new ClassBackOffice(Client.ClientId, ActionsEnum.Purchases, LOGIN.Employee.EmployeeId, (int)InsertedRow["client_balance_id"], null, null, null, null, null, Date);
            backOffice.CreateActionDetails(InsertedRow);
            backOffice.InsertToArchiveSQL();

            ProjectToSQL.InsertToFinance((int)InsertedRow["client_balance_id"], 0, Date, Client.AlbumType);//kermel el count
            return dtinserteditem;
        }



        string ImageName = "Client";//theclient id will be added to t
        public void InsertClientToSQL()
        {


            // Phone number does not exist, proceed with insertion
            string insertQuery = "INSERT INTO client (name, family_name, gender, date_of_birth, muscles_focus_on, weight, height, hand, body_shape_target, injuries, sessions_per_week, phone_number, adress, job, special_note, insta_user, IsChild,IsParent,AlbumType,last_time_searched,save_date,Registration_Date,check_in,total_balance,total_payment,email,marital_status,know_about_us,timeline_goals,smoking_consumption,alcohol_consumption,exercise_history,sleep_patterns,stress_levels,profile_image_path,fighting_skills) " +
                                 "VALUES (@Name, @FamilyName, @Gender, @DateOfBirth, @MusclesFocusOn, @Weight, @Height, @Hand, @BodyShapeTarget, @Injuries, @SessionsPerWeek, @PhoneNumber, @Adress, @Job, @SpecialNote, @InstaUser, @IsChild,@IsParent,@AlbumType,@last_time_searched,@save_date,@Registration_Date,@check_in,@total_balance,@total_payment,@Email,@MaritalStatus,@KnowAboutUs,@TimelineGoals,@Smoking,@Alcohol,@ExerciseHistory,@SleepPattern,@StressLevel,@profile_image_path,@fighting_skills)";

            SqlCommand command = new SqlCommand(insertQuery, con);

            if (ProfileImage != null)
            {
                int InsertedClientId = GetLastClientIDSQL() + 1;
                ImagesFunctions.SaveImage(this.ProfileImage, Program.FolderProfileImagePath, ImageName + InsertedClientId);
                command.Parameters.AddWithValue("@profile_image_path", ImageName + InsertedClientId);
            }
            else
            {
                command.Parameters.AddWithValue("@profile_image_path", DBNull.Value);
            }

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
                command.Parameters.AddWithValue("@DateOfBirth", BirthDate);


            if (MuscleFocusOn == null)
                command.Parameters.AddWithValue("@MusclesFocusOn", DBNull.Value);
            else
                command.Parameters.AddWithValue("@MusclesFocusOn", MuscleFocusOn);


            if (Weight == null)
                command.Parameters.AddWithValue("@Weight", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Weight", Weight);


            if (Height == null)
                command.Parameters.AddWithValue("@Height", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Height", Height);


            if (Hand == null)
                command.Parameters.AddWithValue("@Hand", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Hand", Hand);



            if (BodyShapeTarget == null)
                command.Parameters.AddWithValue("@BodyShapeTarget", DBNull.Value);
            else
                command.Parameters.AddWithValue("@BodyShapeTarget", BodyShapeTarget);


            if (Injuries == null)
                command.Parameters.AddWithValue("@Injuries", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Injuries", Injuries);


            if (SessionPerWeek == null)
                command.Parameters.AddWithValue("@SessionsPerWeek", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SessionsPerWeek", SessionPerWeek);


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


            if (MaritalStatus == null)
                command.Parameters.AddWithValue("@MaritalStatus", DBNull.Value);
            else
                command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);


            if (KnowAboutUs == null)
                command.Parameters.AddWithValue("@KnowAboutUs", DBNull.Value);
            else
                command.Parameters.AddWithValue("@KnowAboutUs", KnowAboutUs);


            if (GoalsTimeline == null)
                command.Parameters.AddWithValue("@TimelineGoals", DBNull.Value);
            else
                command.Parameters.AddWithValue("@TimelineGoals", GoalsTimeline);

            if (Smoking == null)
                command.Parameters.AddWithValue("@Smoking", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Smoking", Smoking);


            if (Alcohol == null)
                command.Parameters.AddWithValue("@Alcohol", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Alcohol", Alcohol);



            if (ExerciseHistory == null)
                command.Parameters.AddWithValue("@ExerciseHistory", DBNull.Value);
            else

                command.Parameters.AddWithValue("@ExerciseHistory", ExerciseHistory);

            if (SleepPattern == null)
                command.Parameters.AddWithValue("@SleepPattern", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SleepPattern", SleepPattern);


            if (StressLevel == null)
                command.Parameters.AddWithValue("@StressLevel", DBNull.Value);
            else
                command.Parameters.AddWithValue("@StressLevel", StressLevel);

            command.Parameters.AddWithValue("@IsChild", IsChild);
            command.Parameters.AddWithValue("@IsParent", IsParent);


            if (AlbumType == null)
                command.Parameters.AddWithValue("@AlbumType", DBNull.Value);
            else
                command.Parameters.AddWithValue("@AlbumType", AlbumType);


            if (FightingSkills == null)
                command.Parameters.AddWithValue("@fighting_skills", DBNull.Value);
            else
                command.Parameters.AddWithValue("@fighting_skills", FightingSkills);



            command.Parameters.AddWithValue("@total_balance", 0);
            command.Parameters.AddWithValue("@total_payment", 0);


            command.Parameters.AddWithValue("@save_date", DateTime.Now);
            command.Parameters.AddWithValue("@check_in", DBNull.Value);
            command.Parameters.AddWithValue("@Registration_Date", DBNull.Value);
            command.Parameters.AddWithValue("@last_time_searched", DateTime.Now);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateClientToSQL(bool PicisChanged)
        {
            string UpdateQuery;
            SqlCommand command;
            if (PicisChanged)
            {
                UpdateQuery = @"UPDATE client 
                    SET  name = @Name, family_name = @FamilyName, gender = @Gender,date_of_birth = @DateOfBirth, muscles_focus_on = @MusclesFocusOn,
                     weight = @Weight, height = @Height, hand = @Hand,
                     body_shape_target = @BodyShapeTarget, injuries = @Injuries, 
                     sessions_per_week = @SessionsPerWeek, phone_number = @PhoneNumber, 
                     adress = @Adress, job = @Job, special_note = @SpecialNote, 
                     insta_user = @InstaUser, IsChild = @IsChild, email = @Email, 
                     marital_status = @MaritalStatus, know_about_us = @KnowAboutUs, 
                     timeline_goals = @TimelineGoals, smoking_consumption = @Smoking, 
                     alcohol_consumption = @Alcohol, exercise_history = @ExerciseHistory, 
                     sleep_patterns = @SleepPattern, stress_levels = @StressLevel ,profile_image_path=@profile_image_path,fighting_skills = @fighting_skills 
                     WHERE client_id = @client_id";


                command = new SqlCommand(UpdateQuery, con);

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
                    SET  name = @Name, family_name = @FamilyName, gender = @Gender,date_of_birth = @DateOfBirth, muscles_focus_on = @MusclesFocusOn,
                     weight = @Weight, height = @Height, hand = @Hand, 
                     body_shape_target = @BodyShapeTarget, injuries = @Injuries, 
                     sessions_per_week = @SessionsPerWeek, phone_number = @PhoneNumber, 
                     adress = @Adress, job = @Job, special_note = @SpecialNote, 
                     insta_user = @InstaUser, IsChild = @IsChild, email = @Email, 
                     marital_status = @MaritalStatus, know_about_us = @KnowAboutUs, 
                     timeline_goals = @TimelineGoals, smoking_consumption = @Smoking, 
                     alcohol_consumption = @Alcohol, exercise_history = @ExerciseHistory, 
                     sleep_patterns = @SleepPattern, stress_levels = @StressLevel,fighting_skills = @fighting_skills 
                     WHERE client_id = @client_id";

                command = new SqlCommand(UpdateQuery, con);

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
                command.Parameters.AddWithValue("@DateOfBirth", BirthDate);


            if (MuscleFocusOn == null)
                command.Parameters.AddWithValue("@MusclesFocusOn", DBNull.Value);
            else
                command.Parameters.AddWithValue("@MusclesFocusOn", MuscleFocusOn);


            if (Weight == null)
                command.Parameters.AddWithValue("@Weight", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Weight", Weight);

            if (Height == null)
                command.Parameters.AddWithValue("@Height", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Height", Height);

            if (Hand == null)
                command.Parameters.AddWithValue("@Hand", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Hand", Hand);




            if (BodyShapeTarget == null)
                command.Parameters.AddWithValue("@BodyShapeTarget", DBNull.Value);
            else
                command.Parameters.AddWithValue("@BodyShapeTarget", BodyShapeTarget);


            if (Injuries == null)
                command.Parameters.AddWithValue("@Injuries", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Injuries", Injuries);


            if (SessionPerWeek == null)
                command.Parameters.AddWithValue("@SessionsPerWeek", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SessionsPerWeek", SessionPerWeek);


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


            if (MaritalStatus == null)
                command.Parameters.AddWithValue("@MaritalStatus", DBNull.Value);
            else
                command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);


            if (KnowAboutUs == null)
                command.Parameters.AddWithValue("@KnowAboutUs", DBNull.Value);
            else
                command.Parameters.AddWithValue("@KnowAboutUs", KnowAboutUs);


            if (GoalsTimeline == null)
                command.Parameters.AddWithValue("@TimelineGoals", DBNull.Value);
            else
                command.Parameters.AddWithValue("@TimelineGoals", GoalsTimeline);

            if (Smoking == null)
                command.Parameters.AddWithValue("@Smoking", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Smoking", Smoking);



            if (Alcohol == null)
                command.Parameters.AddWithValue("@Alcohol", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Alcohol", Alcohol);


            if (ExerciseHistory == null)
                command.Parameters.AddWithValue("@ExerciseHistory", DBNull.Value);
            else

                command.Parameters.AddWithValue("@ExerciseHistory", ExerciseHistory);

            if (SleepPattern == null)
                command.Parameters.AddWithValue("@SleepPattern", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SleepPattern", SleepPattern);


            if (StressLevel == null)
                command.Parameters.AddWithValue("@StressLevel", DBNull.Value);
            else
                command.Parameters.AddWithValue("@StressLevel", StressLevel);


            if (FightingSkills == null)
                command.Parameters.AddWithValue("@fighting_skills", DBNull.Value);
            else
                command.Parameters.AddWithValue("@fighting_skills", FightingSkills);

            command.Parameters.AddWithValue("@IsChild", IsChild);
            command.Parameters.AddWithValue("@client_id", ClientId);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteClientToSQL()
        {
            //ejbare bi hal order men wara el relation baynetu

            con.Open();

            //kermel el balance
            string QueryDeleteArchive = "DELETE FROM archive WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd1 = new SqlCommand(QueryDeleteArchive, con);
            cmd1.ExecuteNonQuery();

            string QueryDeleteFinance = "DELETE FROM finance WHERE client_balance_id IN ( SELECT client_balance_id  FROM client_balance WHERE client_id = '" + ClientId + "')";
            SqlCommand cmd2 = new SqlCommand(QueryDeleteFinance, con);
            cmd2.ExecuteNonQuery();


            //kermel el appintment
            string QueryDeleteClientAttendace = "DELETE FROM client_services_attendance WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd4 = new SqlCommand(QueryDeleteClientAttendace, con);
            cmd4.ExecuteNonQuery();

            string QueryDeleteAppBundles = "DELETE FROM appointment_has_bundles WHERE appointment_id IN ( SELECT appointment_id  FROM appointments WHERE client_id = '" + ClientId + "')";
            SqlCommand cmd8 = new SqlCommand(QueryDeleteAppBundles, con);
            cmd8.ExecuteNonQuery();

            string QueryDeleteAppointments = "DELETE FROM appointments WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd5 = new SqlCommand(QueryDeleteAppointments, con);
            cmd5.ExecuteNonQuery();
            //


            string QueryDeleteClientBalance = "DELETE FROM client_balance WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd3 = new SqlCommand(QueryDeleteClientBalance, con);
            cmd3.ExecuteNonQuery();
            //


            string QueryDeleteClientReminders = "DELETE FROM reminder WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd7 = new SqlCommand(QueryDeleteClientReminders, con);
            cmd7.ExecuteNonQuery();

            string QueryDeleteClient = "DELETE FROM client WHERE client_id = '" + ClientId + "'";
            SqlCommand cmd6 = new SqlCommand(QueryDeleteClient, con);
            cmd6.ExecuteNonQuery();


            con.Close();

        }








        public static ClassClient CreateClientObject(int ClientID)
        {

            DataTable dt = ClassClient.GetAllClientsInfoSQL(ClientID);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassClient client = new ClassClient();


            client.ClientId = (int)datarow["client_id"];//noway ykun bel db fi client ma endo clientid
            client.Fname = datarow["name"] is DBNull ? null : (string)datarow["name"];
            client.Lname = datarow["family_name"] is DBNull ? null : (string)datarow["family_name"];
            client.PhoneNumber = datarow["phone_number"] is DBNull ? null : (string)datarow["phone_number"];
            client.Gender = datarow["gender"] is DBNull ? null : (string)datarow["gender"];
            client.Job = datarow["job"] is DBNull ? null : (string)datarow["job"];
            client.Adress = datarow["adress"] is DBNull ? null : (string)datarow["adress"];
            client.InstaUserName = datarow["insta_user"] is DBNull ? null : (string)datarow["insta_user"];
            client.Email = datarow["email"] is DBNull ? null : (string)datarow["email"];

            client.KnowAboutUs = datarow["know_about_us"] is DBNull ? null : (string)datarow["know_about_us"];

            client.MaritalStatus = datarow["marital_status"] is DBNull ? null : (string)datarow["marital_status"];


            client.BirthDate = datarow["date_of_birth"] is DBNull ? (DateTime?)null : (DateTime)datarow["date_of_birth"];   //age is being calculated in the set of this prop     
            client.IsChild = (Boolean)datarow["IsChild"];
            client.IsParent = (Boolean)datarow["IsParent"];
            client.AlbumType = datarow["AlbumType"] is DBNull ? null : (string)datarow["AlbumType"];


            client.ProfileImageName = datarow["profile_image_path"] is DBNull ? null : (string)datarow["profile_image_path"];
            client.ProfileImage = ImagesFunctions.RetrieveImage(Program.FolderProfileImagePath, client.ProfileImageName);


            client.SaveDate = datarow["save_date"] is DBNull ? (DateTime?)null : (DateTime)datarow["save_date"];
            client.LastVisit = datarow["check_in"] is DBNull ? (DateTime?)null : (DateTime)datarow["check_in"];
            client.RegistrationDate = datarow["Registration_Date"] is DBNull ? (DateTime?)null : (DateTime)datarow["Registration_Date"];

            //should be calculated and inserted in other forms

            client.TotalAttendance = CalculateNOAttendance((int)datarow["client_id"]);//always exist while inserting a new clien


            client.TotalBalance = (double)datarow["total_balance"];
            client.TotalPayment = (double)datarow["total_payment"];


            client.Weight = datarow["weight"] is DBNull ? null : (string)datarow["weight"];
            client.Height = datarow["height"] is DBNull ? null : (string)datarow["height"];

            client.BodyShapeTarget = datarow["body_shape_target"] is DBNull ? null : (string)datarow["body_shape_target"];

            client.MuscleFocusOn = datarow["muscles_focus_on"] is DBNull ? null : (string)datarow["muscles_focus_on"];

            client.Injuries = datarow["injuries"] is DBNull ? null : (string)datarow["injuries"];

            client.ExerciseHistory = datarow["exercise_history"] is DBNull ? null : (string)datarow["exercise_history"];



            client.SessionPerWeek = datarow["sessions_per_week"] is DBNull ? (int?)null : (int)datarow["sessions_per_week"];
            client.Hand = datarow["hand"] is DBNull ? null : (string)datarow["hand"];

            client.Note = datarow["special_note"] is DBNull ? null : (string)datarow["special_note"];
            client.SleepPattern = datarow["sleep_patterns"] is DBNull ? null : (string)datarow["sleep_patterns"];
            client.StressLevel = datarow["stress_levels"] is DBNull ? null : (string)datarow["stress_levels"];
            client.GoalsTimeline = datarow["timeline_goals"] is DBNull ? null : (string)datarow["timeline_goals"];
            client.Smoking = datarow["smoking_consumption"] is DBNull ? null : (string)datarow["smoking_consumption"];
            client.Alcohol = datarow["alcohol_consumption"] is DBNull ? null : (string)datarow["alcohol_consumption"];
            client.FightingSkills = datarow["fighting_skills"] is DBNull ? null : (string)datarow["fighting_skills"];
            return client;

        }
        static int CalculateNOAttendance(int ClientId)
        {
            DataTable AttendDtt = SQLToProject.GetAllClientAttendance(ClientId);

            // Group by client_id and count sessions
            var groupedData = from row in AttendDtt.AsEnumerable()
                              group row by new
                              {
                                  ClientId = row.Field<int>("client_id"),

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

        public ClassClient Copy()//This Copy wont work fi Property eza fi  reference-type Properties (classes or list)/ eenda it s own methode, check ClassAppointment
        {
            return (ClassClient)this.MemberwiseClone();
        }
    }



}
