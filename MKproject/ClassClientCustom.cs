using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject
{
    public class ClassClientCustom : ClassClient
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);

        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyShapeTarget { get; set; }
        public string MuscleFocusOn { get; set; }
        public string Injuries { get; set; }
        public string Hand { get; set; }
        public int? SessionPerWeek { get; set; }
        public string KnowAboutUs { get; set; }
        public string GoalsTimeline { get; set; }
        public string Smoking { get; set; }
        public string Alcohol { get; set; }
        public string ExerciseHistory { get; set; }
        public string SleepPattern { get; set; }
        public string StressLevel { get; set; }
        public string FightingSkills { get; set; }


        public enum enumDynamicFields
        {
            //Dynamic
            [StringValue("Height")]
            Height=100,
            [StringValue("Weight")]
            Weight,
            [StringValue("Body Shape Target")]
            BodyShapeTarget,
            [StringValue("Hand")]
            Hand,
            [StringValue("Injuries")]
            Injuries,
            [StringValue("Muscles Focus")]
            MuscleFocusOn,                   
            [StringValue("Sessions/Week")]
            SessionPerWeek,
            [StringValue("Goals Timeline")]
            GoalsTimeline,
            [StringValue("Alcohol")]
            Alcohol,
            [StringValue("Smoking")]
            Smoking,
            [StringValue("Exercise History")]
            ExerciseHistory,
         
            [StringValue("Sleep Pattern")]
            SleepPattern,
            [StringValue("Stress Level")]
            StressLevel,
            [StringValue("Focus on Boxing skills")]
            BoxingSkills,
       
        }

        public enum RightLeft

        {
            [StringValue("Right")]
            Right,
            [StringValue("Left")]
            Left
        }
        //global
        public enum UnitHeight
        {
            cm,
            ft,
        }

        public enum UnitWeight
        {
            kg,
            lb,
        }
      
      

        public enum enumBodyShapeTarget
        {
            [StringValue("Toned body")]
            tonedbody,
            [StringValue("Build muscles")]
            buildmuscles,
            [StringValue("Burn fat")]
            burnfat

        }
        public enum enumMuscleFocusOn
        {
            [StringValue("Entire body")]
            Entirebody,
            [StringValue("Chest")]
            Chest,
            [StringValue("Back")]
            Back,
            [StringValue("Arms")]
            Arms,
            [StringValue("Gluteus")]
            Gluteus,
            [StringValue("Legs")]
            Legs,
            [StringValue("Abs")]
            Abs,
        }
        public enum enumInjuries//checkboxes
        {
            //none badna nzida men el new regis
            [StringValue("Back pain")]
            Backpain,
            [StringValue("Upper back pain")]
            Upperbackpain,
            [StringValue("Lower back pain")]
            Lowerbackpain,
            [StringValue("Knee pain")]
            Kneepain,
            [StringValue("Left knee pain")]
            Leftkneepain,
            [StringValue("Right knee pain")]
            Rightkneepain,
            [StringValue("Neck pain")]
            Neckpain,
            [StringValue("Others")]//add textbox
            Others

        }
        public enum enumExerciseHistory//checkboxes
        {
            [StringValue("Cardio")]
            Cardio,
            [StringValue("Strenght Training")]
            StrenghtTraining,
            [StringValue("Flexibility And Mobility")]
            FlexibilityAndMobility,
            [StringValue("Others")]//add textbox
            Others
        }
        public enum enumFightingSkills
        {
            [StringValue("Self defense")]
            Selfdefense,
            [StringValue("Relieve stress")]
            Relievestress,
            [StringValue("Increase focus")]
            Increasefocus,
            [StringValue("Reflex")]
            Reflex,
            [StringValue("Learn how to fight")]
            Learnhowtofight
        }
        public enum enumStressLevel
        {
            [StringValue("Not Stressed")]
            NotStressed,
            [StringValue("Low Stress")]
            LowStress,
            [StringValue("Moderate Stress")]
            ModerateStress,
            [StringValue("High Stress")]
            HighStress,
            [StringValue("Very High Stress")]
            VeryHighStress,
            [StringValue("I don't want to answer")]
            Idontwanttoanswer
        }
        public enum enumSessionPerWeek
        {
            [StringValue("1")]
            One,
            [StringValue("2")]
            Two,
            [StringValue("3")]
            Three,
            [StringValue("4")]
            Four,
            [StringValue("5")]
            Five,
            [StringValue("6")]
            Six
        }
        //custom
        public enum Period
        {
            Weeks,
            Months,
            Years
        }


        public override void InsertClientToSQL()
        {
            base.InsertClientToSQL();


            //SQLiteCommand command = null;
            //if (MaritalStatus == null)
            //    command.Parameters.AddWithValue("@MaritalStatus", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);


            //if (KnowAboutUs == null)
            //    command.Parameters.AddWithValue("@KnowAboutUs", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@KnowAboutUs", KnowAboutUs);


            //if (GoalsTimeline == null)
            //    command.Parameters.AddWithValue("@TimelineGoals", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@TimelineGoals", GoalsTimeline);

            //if (Smoking == null)
            //    command.Parameters.AddWithValue("@Smoking", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Smoking", Smoking);


            //if (Alcohol == null)
            //    command.Parameters.AddWithValue("@Alcohol", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Alcohol", Alcohol);



            //if (ExerciseHistory == null)
            //    command.Parameters.AddWithValue("@ExerciseHistory", DBNull.Value);
            //else

            //    command.Parameters.AddWithValue("@ExerciseHistory", ExerciseHistory);

            //if (SleepPattern == null)
            //    command.Parameters.AddWithValue("@SleepPattern", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@SleepPattern", SleepPattern);


            //if (StressLevel == null)
            //    command.Parameters.AddWithValue("@StressLevel", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@StressLevel", StressLevel);
            //if (MuscleFocusOn == null)
            //    command.Parameters.AddWithValue("@MusclesFocusOn", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@MusclesFocusOn", MuscleFocusOn);


            //if (Weight == null)
            //    command.Parameters.AddWithValue("@Weight", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Weight", Weight);


            //if (Height == null)
            //    command.Parameters.AddWithValue("@Height", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Height", Height);


            //if (Hand == null)
            //    command.Parameters.AddWithValue("@Hand", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Hand", Hand);



            //if (BodyShapeTarget == null)
            //    command.Parameters.AddWithValue("@BodyShapeTarget", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@BodyShapeTarget", BodyShapeTarget);


            //if (Injuries == null)
            //    command.Parameters.AddWithValue("@Injuries", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Injuries", Injuries);


            //if (SessionPerWeek == null)
            //    command.Parameters.AddWithValue("@SessionsPerWeek", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@SessionsPerWeek", SessionPerWeek);

            //if (FightingSkills == null)
            //    command.Parameters.AddWithValue("@fighting_skills", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@fighting_skills", FightingSkills);

        }
        public override void UpdateClientToSQL(bool PicisChanged)
        {
            base.UpdateClientToSQL(PicisChanged);

            SQLiteCommand command = null;
            //if (MuscleFocusOn == null)
            //    command.Parameters.AddWithValue("@MusclesFocusOn", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@MusclesFocusOn", MuscleFocusOn);


            //if (Weight == null)
            //    command.Parameters.AddWithValue("@Weight", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Weight", Weight);

            //if (Height == null)
            //    command.Parameters.AddWithValue("@Height", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Height", Height);

            //if (Hand == null)
            //    command.Parameters.AddWithValue("@Hand", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Hand", Hand);


            //if (MaritalStatus == null)
            //    command.Parameters.AddWithValue("@MaritalStatus", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);


            //if (KnowAboutUs == null)
            //    command.Parameters.AddWithValue("@KnowAboutUs", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@KnowAboutUs", KnowAboutUs);


            //if (GoalsTimeline == null)
            //    command.Parameters.AddWithValue("@TimelineGoals", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@TimelineGoals", GoalsTimeline);

            //if (Smoking == null)
            //    command.Parameters.AddWithValue("@Smoking", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Smoking", Smoking);


            //if (Alcohol == null)
            //    command.Parameters.AddWithValue("@Alcohol", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Alcohol", Alcohol);


            //if (ExerciseHistory == null)
            //    command.Parameters.AddWithValue("@ExerciseHistory", DBNull.Value);
            //else

            //    command.Parameters.AddWithValue("@ExerciseHistory", ExerciseHistory);

            //if (SleepPattern == null)
            //    command.Parameters.AddWithValue("@SleepPattern", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@SleepPattern", SleepPattern);


            //if (StressLevel == null)
            //    command.Parameters.AddWithValue("@StressLevel", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@StressLevel", StressLevel);


            //if (FightingSkills == null)
            //    command.Parameters.AddWithValue("@fighting_skills", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@fighting_skills", FightingSkills);

            //if (BodyShapeTarget == null)
            //    command.Parameters.AddWithValue("@BodyShapeTarget", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@BodyShapeTarget", BodyShapeTarget);


            //if (Injuries == null)
            //    command.Parameters.AddWithValue("@Injuries", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@Injuries", Injuries);


            //if (SessionPerWeek == null)
            //    command.Parameters.AddWithValue("@SessionsPerWeek", DBNull.Value);
            //else
            //    command.Parameters.AddWithValue("@SessionsPerWeek", SessionPerWeek);

        }
        public static ClassClientCustom CreateClientObject(int ClientID)
        {

            DataTable dt = ClassClientCustom.GetAllClientsInfoSQL(ClientID);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassClientCustom client = new ClassClientCustom();


            client.ClientId = Convert.ToInt32(datarow["client_id"]);//noway ykun bel db fi client ma endo clientid

            //static
            client.Fname = datarow["name"] is DBNull ? null : (string)datarow["name"];
            client.Lname = datarow["family_name"] is DBNull ? null : (string)datarow["family_name"];
            client.PhoneNumber = datarow["phone_number"] is DBNull ? null : (string)datarow["phone_number"];
            client.Gender = datarow["gender"] is DBNull ? null : (string)datarow["gender"];
            client.Job = datarow["job"] is DBNull ? null : (string)datarow["job"];
            client.Adress = datarow["adress"] is DBNull ? null : (string)datarow["adress"];
            client.InstaUserName = datarow["insta_user"] is DBNull ? null : (string)datarow["insta_user"];
            client.Email = datarow["email"] is DBNull ? null : (string)datarow["email"];
            client.Note = datarow["special_note"] is DBNull ? null : (string)datarow["special_note"];
            client.BirthDate = datarow["date_of_birth"] is DBNull ? (DateTime?)null : Convert.ToDateTime(datarow["date_of_birth"]);   //age is being calculated in the set of this prop     
            client.ProfileImageName = datarow["profile_image_path"] is DBNull ? null : (string)datarow["profile_image_path"];
            client.ProfileImage = ImagesFunctions.RetrieveImage(Program.FolderProfileImagePath, client.ProfileImageName);



            //dynamic
            client.Weight = datarow["weight"] is DBNull ? null : (string)datarow["weight"];
            client.Height = datarow["height"] is DBNull ? null : (string)datarow["height"];
            client.BodyShapeTarget = datarow["body_shape_target"] is DBNull ? null : (string)datarow["body_shape_target"];
            client.MuscleFocusOn = datarow["muscles_focus_on"] is DBNull ? null : (string)datarow["muscles_focus_on"];
            client.Injuries = datarow["injuries"] is DBNull ? null : (string)datarow["injuries"];
            client.ExerciseHistory = datarow["exercise_history"] is DBNull ? null : (string)datarow["exercise_history"];
            client.SessionPerWeek = datarow["sessions_per_week"] is DBNull ? null : Convert.ToInt32(datarow["sessions_per_week"]);
            client.Hand = datarow["hand"] is DBNull ? null : (string)datarow["hand"];
            client.SleepPattern = datarow["sleep_patterns"] is DBNull ? null : (string)datarow["sleep_patterns"];
            client.StressLevel = datarow["stress_levels"] is DBNull ? null : (string)datarow["stress_levels"];
            client.KnowAboutUs = datarow["know_about_us"] is DBNull ? null : (string)datarow["know_about_us"];
            client.MaritalStatus = datarow["marital_status"] is DBNull ? null : (string)datarow["marital_status"];
            client.GoalsTimeline = datarow["timeline_goals"] is DBNull ? null : (string)datarow["timeline_goals"];
            client.Smoking = datarow["smoking_consumption"] is DBNull ? null : (string)datarow["smoking_consumption"];
            client.Alcohol = datarow["alcohol_consumption"] is DBNull ? null : (string)datarow["alcohol_consumption"];
            client.FightingSkills = datarow["fighting_skills"] is DBNull ? null : (string)datarow["fighting_skills"];





            client.IsChild = Convert.ToBoolean(datarow["IsChild"]);
            client.IsParent = Convert.ToBoolean(datarow["IsParent"]);
            client.AlbumType = datarow["AlbumType"] is DBNull ? null : (string)datarow["AlbumType"];



            client.SaveDate = datarow["save_date"] is DBNull ? (DateTime?)null : Convert.ToDateTime(datarow["save_date"]);
            client.LastVisit = datarow["check_in"] is DBNull ? (DateTime?)null : Convert.ToDateTime(datarow["check_in"]);
            client.RegistrationDate = datarow["Registration_Date"] is DBNull ? (DateTime?)null : Convert.ToDateTime(datarow["Registration_Date"]);

            //should be calculated and inserted in other forms

            client.TotalAttendance = ClassClientCustom.CalculateNOAttendance(Convert.ToInt32(datarow["client_id"]));//always exist while inserting a new clien


            client.TotalBalance = Convert.ToDouble(datarow["total_balance"]);
            client.TotalPayment = Convert.ToDouble(datarow["total_payment"]);




            return client;

        }




        public static void CreationOfTheFieldInitially()
        {
            DataTable dtRegistrationFields = SQLToProject.GetAllVisibleFields();

            // Insert enumStaticFields
            foreach (enumStaticFields field in Enum.GetValues(typeof(enumStaticFields)))
            {
                if (!FieldExistsInDataTable(dtRegistrationFields, field.ToString()))
                {
                    InsertField( field.ToString(), true, false, true);
                }
            }
            // Insert enumDynamicFields
            foreach (enumDynamicFields field in Enum.GetValues(typeof(enumDynamicFields)))
            {
                if (!FieldExistsInDataTable(dtRegistrationFields, field.ToString()))
                {
                    InsertField(field.ToString(), true, false, false);
                }
            }

        }
        private static bool FieldExistsInDataTable(DataTable dataTable, string fieldName)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Fields"].ToString().Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private static void InsertField( string fieldName, bool visible, bool required, bool isOriginal)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO required_visible_fields (Fields, Visible, Required, IsOriginal) VALUES (@Fields, @Visible, @Required, @IsOriginal)", con);        
                cmd.Parameters.AddWithValue("@Fields", fieldName);
                cmd.Parameters.AddWithValue("@Visible", visible );
                cmd.Parameters.AddWithValue("@Required", required);
                cmd.Parameters.AddWithValue("@IsOriginal", isOriginal);
            con.Open();
                cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}
