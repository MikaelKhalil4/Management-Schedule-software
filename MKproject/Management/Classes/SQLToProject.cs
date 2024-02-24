using System;
using System.Data;
using System.Data.SqlClient;

namespace MKproject.Management
{
    internal class SQLToProject
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

      

        //client_balance
        public static DataTable GetClientBalanceSpecificOrLastInsert(int? ClientId)
        {

            String query = @"SELECT
                       cl.ID,  cl.bundle_id,b.bundle_name, cl.product_id, cl.purchase_date, cl.original_offre, cl.offre, cl.amount_paid, cl.balance, cl.session_left_days, cl.due_date,  cl.is_freezed,cl.is_expired,  cu.Currency_Name, cu.Symbol,            
                      CASE
                       WHEN cl.bundle_id IS NOT NULL THEN b.bundle_name
                          WHEN cl.product_id IS NOT NULL THEN p.product_name
                          ELSE 'Others' 
                       END AS Description  
                        FROM client_balance cl  
                        JOIN
                        Currencies cu ON cl.Currency_Name = cu.Currency_Name
                        LEFT JOIN
                        bundles b ON cl.bundle_id = b.bundle_id
                        LEFT JOIN
                        products p ON cl.product_id = p.product_id ";

            SqlCommand cmd = null;
            if (ClientId != null)
            {
                query += " Where cl.client_id = @client_id ORDER BY purchase_date ASC";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@client_id", ClientId);
            }
            else
            {
                query += " WHERE cl.ID = (SELECT MAX(ID) FROM client_balance)";
                cmd = new SqlCommand(query, con);
            }


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;
        }
        public static (double, double) GetClientBalanceSpecificItem(int ClientBalanceId)
        {
            string query = "Select amount_paid,balance from client_balance WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ClientBalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return ((double)dt.Rows[0]["amount_paid"], Convert.ToDouble(dt.Rows[0]["balance"]));

        }
        public static DataTable GetClientBalanceNotExpiredPackage(int? clientID)
        {
            string query = @"Select	ID,client_id,bundle_name,session_left_days,due_date,is_freezed,balance
                            from client_balance as c ,bundles  as b
                              where session_left_days is not null And is_expired='false' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='"+ (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;

        }


        //client_struct
        public static DataTable GetAttendance()
        {

            string query = "SELECT execute_date from client_attendance  ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetLAstInsertedAttendance()
        {
            int Id;
            con.Open();
            string getLastIdQuery = "SELECT Max(attendance_id) FROM client_attendance";
            using (SqlCommand command = new SqlCommand(getLastIdQuery, con))
            {
                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return Id;
        }
        public static DataTable GetAllClientAttendance(int? ClientId)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT cs.client_id,cs.execute_date      
            FROM client_attendance cs,client c
            WHERE cs.client_id = c.client_id  AND execute_date IS NOT NULL ";
           if (ClientId != null)
            {
                query+= " And cs.client_id='" + ClientId + "'";
            }


            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            con.Close();          
            adapter.Fill(dt);
            return dt;
        }

        //required_visible_fields     
        public static DataTable GetAllVisibleFields()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields ORDER BY design_index ASC";//la2n ma badna n3adil 3l full name w el phone number
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetChildParentVisibleFields()
        {

            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields WHERE Fields IN ('FullName','PhoneNumber','Adress')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        //Albums
        public static DataTable GetAlbums()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Albums order by Album_id DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public static bool IsAlbumAlreadyExists(string albumName,string oldname)//oldname exist only in case of update mode
        {
            int count;
            string query;
            query= "SELECT COUNT(*) FROM Albums WHERE AlbumType = @AlbumName";
            if (oldname != null)
            {
                query+= " And AlbumType !='"+ oldname + "'";
            }
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            count = (int)command.ExecuteScalar();
            con.Close();
            return count > 0;
        }



        //finance
        public static DataTable GetIncome()
        {
            string query = @"SELECT f.id,f.id_client_balance,f.amount_paid,f.payment_date,cb.bundle_id,cb.bundle_id,cb.product_id
                                from finance f,client c,client_balance cb 
                               WHERE f.id_client_balance=cb.ID AND cb.client_id=c.client_id";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }




    }
}
