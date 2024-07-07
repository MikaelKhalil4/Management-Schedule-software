using Amazon.S3.Model;
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

        //public string Height { get; set; }
       
        public enum enumDynamicFields //ejabre ballish men 1 aw 101 kermel el labels
        {
            //Dynamic

            //[StringValue("Height")]
            //Height = 101,
       

        }
  

        //public enum UnitHeight
        //{
        //    [StringValue("cm")]
        //    cm,
        //    [StringValue("ft")]
        //    ft,
        //}

       


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

                //if (fieldName == enumDynamicFields.Height.ToString())
                //{
                //    client.Height = content;
                //}
              
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

                    bool IsRequired=false;


                    if (field == enumStaticFields.FullName || field == enumStaticFields.PhoneNumber)
                    {
                        IsRequired = true;
                    }
                  

                    ProjectToSQL. InsertField(field.ToString(), true, IsRequired, true);
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
      


        public static void DBExtention(ref string query)
        {
            query += @"  
                        CREATE TABLE IF NOT EXISTS ""client_auth"" (
	                    ""auth_token""	TEXT NOT NULL UNIQUE,
	                    ""client_id""	INTEGER NOT NULL,
	                    ""is_used""	INTEGER NOT NULL,
	                    ""is_main_device""	INTEGER NOT NULL,
	                    PRIMARY KEY(""auth_token""),
	                    FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id"") ON UPDATE RESTRICT ON DELETE RESTRICT
                    );";
        }

    }
}
