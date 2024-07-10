using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        public string GoalsTimeline { get; set; }
        public string Smoking { get; set; }
        public string Alcohol { get; set; }
        public string ExerciseHistory { get; set; }
        public string SleepPattern { get; set; }
        public string StressLevel { get; set; }
        public string BoxingSkills { get; set; }


        public enum enumDynamicFields//ejabre ballish men 1 aw 101 kermel el labels
        {
            //Dynamic

            [StringValue("Height")]
            Height = 101,
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


        public override int InsertClientToSQL()
        {
            ClientId = base.InsertClientToSQL();

            foreach (PropertyInfo property in typeof(ClassClientCustom).GetProperties())
            {
                if (property.DeclaringType == typeof(ClassClientCustom) && property.GetValue(this) != null)
                {
                    string propertyName = property.Name;
                    object propertyValue = property.GetValue(this);

                    int fieldId = SQLToProject.GetFieldIdByEnumName(propertyName);

                    ProjectToSQL.InsertClientField(ClientId, fieldId, propertyValue.ToString());

                }
            }
            return ClientId;
        }
        public override void UpdateClientToSQL(bool PicisChanged)
        {
            base.UpdateClientToSQL(PicisChanged);

            foreach (PropertyInfo property in typeof(ClassClientCustom).GetProperties())
            {
                if (property.DeclaringType == typeof(ClassClientCustom))
                {
                    string propertyName = property.Name;
                    object propertyValue = property.GetValue(this);

                    int fieldId = SQLToProject.GetFieldIdByEnumName(propertyName);
                    bool IsClientFieldContentExists = SQLToProject.GetFieldContentOfSpecificCleint(ClientId, fieldId);


                    if (property.GetValue(this) == null || String.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        if (IsClientFieldContentExists)
                            ProjectToSQL.DeleteClientField(ClientId, fieldId);
                    }
                    else
                    {
                        if (!IsClientFieldContentExists)
                        {
                            ProjectToSQL.InsertClientField(ClientId, fieldId, propertyValue.ToString());
                        }
                        else
                        {
                            ProjectToSQL.UpdateClientField(ClientId, fieldId, propertyValue.ToString());
                        }
                    }                
                }
            }

        }
        public static ClassClientCustom CreateClientObject(int ClientID)
        {

            DataTable dt = ClassClient.GetAllClientsInfoSQL(ClientID);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassClientCustom client = new ClassClientCustom();


            client.ClientId = Convert.ToInt32(datarow["client_id"]);//noway ykun bel db fi client ma endo clientid

            //original info
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
            client.MaritalStatus = datarow["marital_status"] is DBNull ? null : (string)datarow["marital_status"];
            client.KnowAboutUs = datarow["know_about_us"] is DBNull ? null : (string)datarow["know_about_us"];


            //business info
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




            //dynamic info
            DataTable dtDynamicFields = ClassClientCustom.GetAllClientsDynamicField(ClientID);
            foreach (DataRow row in dtDynamicFields.Rows)
            {
                string fieldName = row["Fields"].ToString();
                string content = row["content"].ToString();
                // Map fieldName to properties using if statements
                if (fieldName == enumDynamicFields.Height.ToString())
                {
                    client.Height = content;
                }
                else if (fieldName == enumDynamicFields.Weight.ToString())
                {
                    client.Weight = content;
                }
                else if (fieldName == enumDynamicFields.BodyShapeTarget.ToString())
                {
                    client.BodyShapeTarget = content;
                }
                else if (fieldName == enumDynamicFields.MuscleFocusOn.ToString())
                {
                    client.MuscleFocusOn = content;
                }
                else if (fieldName == enumDynamicFields.Injuries.ToString())
                {
                    client.Injuries = content;
                }
                else if (fieldName == enumDynamicFields.Hand.ToString())
                {
                    client.Hand = content;
                }
                else if (fieldName == enumDynamicFields.SessionPerWeek.ToString())
                {
                    client.SessionPerWeek = Convert.ToInt32(content);

                }
                else if (fieldName == enumDynamicFields.GoalsTimeline.ToString())
                {
                    client.GoalsTimeline = content;
                }
                else if (fieldName == enumDynamicFields.Alcohol.ToString())
                {
                    client.Alcohol = content;
                }
                else if (fieldName == enumDynamicFields.Smoking.ToString())
                {
                    client.Smoking = content;
                }
                else if (fieldName == enumDynamicFields.ExerciseHistory.ToString())
                {
                    client.ExerciseHistory = content;
                }
                else if (fieldName == enumDynamicFields.SleepPattern.ToString())
                {
                    client.SleepPattern = content;
                }
                else if (fieldName == enumDynamicFields.StressLevel.ToString())
                {
                    client.StressLevel = content;
                }
                else if (fieldName == enumDynamicFields.BoxingSkills.ToString())
                {
                    client.BoxingSkills = content;
                }
            }

            return client;

        }
        public static DataTable GetAllClientsDynamicField(int clientId)
        {
            DataTable dt = new DataTable();


            string query = @"
                SELECT cf.client_id, rf.Fields, cf.content 
                FROM client_fields cf
                JOIN required_visible_fields rf ON cf.fields_id = rf.fields_id
                WHERE cf.client_id = @clientId";


            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            adapter.Fill(dt);

            return dt;
        }



        public static void CreationOfTheFieldInitially()
        {
            DataTable dtRegistrationFields = SQLToProject.GetAllVisibleFields();

            // Insert enumStaticFields
            foreach (enumStaticFields field in Enum.GetValues(typeof(enumStaticFields)))
            {
                if (!FieldExistsInDataTable(dtRegistrationFields, field.ToString()))
                {
                    ProjectToSQL. InsertField(field.ToString(), true, false, true);
                }
            }
            // Insert enumDynamicFields
            foreach (enumDynamicFields field in Enum.GetValues(typeof(enumDynamicFields)))
            {
                if (!FieldExistsInDataTable(dtRegistrationFields, field.ToString()))
                {
                    ProjectToSQL.InsertField(field.ToString(), true, false, false);
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
      

    }
}
