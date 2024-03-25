using GlobalFunctions;
using Microsoft.VisualBasic;
using MKproject.Schedule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class ClassClientBalance//mainly used bel schedule , when we re selection a ervice
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        public int ClientBalanceID { get; set; }
        public int ClientId { get; set; }
        public int? BundleId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string OriginalOffre { get; set; }
        public string Offre { get; set; }
        public double? AmountPaid { get; set; }
        public double? Balance { get; set; }
        public string CurrencyName { get; set; }
        public int? SessionLeftDays { get; set; }//null if not package of session
        public bool? IsBundleMembership { get; set; }

        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                if (value != null)
                {
                    DaysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)DueDate);
                    if (DaysLeft < 0)
                    {
                        DaysLeft = 0;
                    }
                }

            }
        }

        public bool? IsFreezed { get; set; }
        public bool? IsExpired { get; set; }




        //additional
        public int? DaysLeft { get; set; }//btenjeb men wara Due Date w DateTime.Now bel Set tb3 El Due Dtae

        //View 
        public string ClientBalanceSessionLeftDetails { get; set; }//additional,  it a string that describe the service,if package: adde baaed eendo session w masare,if solo: service name,
        //public string ClientBalanceBalanceDetails { get; set; }//additional, null if not package, its a string: currency + Balance
        //public string ClientBalanceFullDetails { get; set; }

        //Select
        public static DataTable GetClientBalanceSpecificOrLastInsert(int? ClientId)
        {

            String query = @"SELECT
                       cl.client_balance_id,  cl.bundle_id,b.bundle_name, cl.product_id, cl.purchase_date, cl.original_offre, cl.offre, cl.amount_paid, cl.balance, cl.session_left_days, cl.due_date,  cl.is_freezed,cl.is_expired,  cu.Currency_Name, cu.Symbol,            
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
                        products p ON cl.product_id = p.product_id WHERE 1=1 ";

            if (ClientId != null)
            {
                query += " And cl.client_id ='" + ClientId + "' ORDER BY purchase_date ASC ";
            }
            else
            {
                query += " And cl.client_balance_id = (SELECT MAX(client_balance_id) FROM client_balance) ";
            }


            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            ClassClientBalance.FormatClientBalanceDt(dtClientBalance);
            return dtClientBalance;
        }
        public static (double, double) GetClientBalanceSpecificItem(int ClientBalanceId)
        {
            string query = "Select amount_paid,balance from client_balance WHERE client_balance_id=@client_balance_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return ((double)dt.Rows[0]["amount_paid"], Convert.ToDouble(dt.Rows[0]["balance"]));

        }
        public static DataTable GetClientBalanceNotExpiredPackage(int? clientID)
        {
            string query = @"Select	c.client_balance_id,c.client_id,c.bundle_id,b.bundle_name as Description,c.session_left_days,c.due_date,c.is_freezed,c.balance                           
                            from client_balance as c ,bundles  as b
                              where session_left_days is not null And is_expired='false' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;

        }
        public static DataTable GetClientBalanceAllInfoSql(int BalanceId)
        {
            SqlCommand cmd = new SqlCommand("select * from client_balance where client_balance_id=@client_balance_id", con);
            cmd.Parameters.AddWithValue("@client_balance_id", BalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static (int?, int?, DateTime?, int? SessionLeftDays) GetBundleIdProductIdueDateSessions(int ClientBalanceId)
        {
            SqlCommand cmd = new SqlCommand("select bundle_id,product_id,due_date,session_left_days from client_balance where client_balance_id=@client_balance_id", con);
            cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int? BundleId = dt.Rows[0]["bundle_id"] is DBNull ? null : (int)dt.Rows[0]["bundle_id"];
            int? productId = dt.Rows[0]["product_id"] is DBNull ? null : (int)dt.Rows[0]["product_id"];
            DateTime? DueDate = dt.Rows[0]["due_date"] is DBNull ? null : (DateTime)dt.Rows[0]["due_date"];
            int? SessionLeftDays = dt.Rows[0]["session_left_days"] is DBNull ? null : (int)dt.Rows[0]["session_left_days"];
            return (BundleId, productId, DueDate, SessionLeftDays);
        }

        //Insert and update
        public static void InsertToClientBalance(int clientid, int catgeoryid, string bundleType) //bundleType for packages , NULL FOR product
        {

            //try
            //{
            //if (RandomFunctions.IsInternetConnected())
            //{
            //    //we still need to do it for the product
            string BundleType;
            string OriginalOffre;
            int? NOSessionOrDays;//gonna be used in description
            double originalprice;
            bool IsExpired = false;
            string query = @"INSERT into  client_balance
                  (client_id,bundle_id,product_id,purchase_date,original_offre,offre,amount_paid,balance,Currency_Name,session_left_days,isbundle_membership,due_date,is_freezed,is_expired) 
                                                              VALUES 
                  (@client_id,@bundle_id,@product_id,@purchase_date,@original_offre,@offre,@amount_paid,@balance,@Currency_Name,@session_left_days,@isbundle_membership,@due_date,@is_freezed,@is_expired)";

            SqlCommand cmd = new SqlCommand(query, con);


            if (bundleType != null)//bundles
            {
                bool IsMemberShip;
                (originalprice, NOSessionOrDays, IsMemberShip) = ClassBundles.FindBundleDetails(catgeoryid);

                if (bundleType == ClassBundles.enumBundle.Days.ToString())
                {
                    cmd.Parameters.AddWithValue("@session_left_days", NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@is_freezed", false);

                    DateTime duedate = DateTime.Now.AddDays((int)NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@due_date", duedate);

                    BundleType = ClassBundles.Days;
                    OriginalOffre = originalprice + "/" + Convert.ToInt16(NOSessionOrDays) + " " + BundleType;

                    if (originalprice == 0 && NOSessionOrDays == 0)//which is impossible , lieanno bel setup tb3 package mafi eendo hek option
                    {
                        IsExpired = true;
                    }
                }
                else if (bundleType == ClassBundles.enumBundle.Sessions.ToString())
                {

                    cmd.Parameters.AddWithValue("@session_left_days", NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);

                    BundleType = ClassBundles.Session;//hone fi "sess"
                    OriginalOffre = originalprice + "/" + Convert.ToInt16(NOSessionOrDays) + " " + BundleType;

                    if (originalprice == 0 && NOSessionOrDays == 0)//which is impossible , lieanno bel setup tb3 package mafi eendo hek option
                    {
                        IsExpired = true;
                    }
                }
                else//solo
                {
                    cmd.Parameters.AddWithValue("@session_left_days", DBNull.Value);
                    cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);
                    OriginalOffre = originalprice.ToString();

                    if (originalprice == 0)//possible
                    {
                        IsExpired = true;
                    }
                }
                cmd.Parameters.AddWithValue("@bundle_id", catgeoryid);
                cmd.Parameters.AddWithValue("@isbundle_membership", IsMemberShip);
                cmd.Parameters.AddWithValue("@product_id", DBNull.Value);




            }
            else//product
            {
                (originalprice) = ClassProduct.FindProductDetails(catgeoryid);
                if (originalprice == 0)//possible
                {
                    IsExpired = true;
                }


                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@product_id", catgeoryid);

                //
                OriginalOffre = originalprice.ToString();
                //


                cmd.Parameters.AddWithValue("@session_left_days", DBNull.Value);
                cmd.Parameters.AddWithValue("@isbundle_membership", DBNull.Value);
                cmd.Parameters.AddWithValue("@bundle_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@purchase_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@amount_paid", 0);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);

            if (originalprice == 0)
                cmd.Parameters.AddWithValue("@balance", originalprice);
            else
                cmd.Parameters.AddWithValue("@balance", -originalprice);

            cmd.Parameters.AddWithValue("@original_offre", OriginalOffre);
            cmd.Parameters.AddWithValue("@offre", OriginalOffre);

            cmd.Parameters.AddWithValue("@is_expired", IsExpired);//since deyman shu ma neshtre , mnehstri bel initial price, later on mnaamil el updates     

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
            //}     
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //CustomMessageBox.Show(Program.ExecptionString + ex.Message, CustomMessageBox.Type.Ok);
            //}
        }
        public static void UpdateClientBalanceAndInsertingFinanceOnPay(DataTable DesiredRowsDt, int AffectedRow, List<(double, int)> ListFinanceUpdates, DateTime Date, String AlbumType)
        {
            //client info retrieval IsMember & Album Type only meanwhile because later on they willl be already existes in the parent form


            for (int i = 0; i < AffectedRow; i++)
            {
                bool IsExpired = Convert.ToBoolean(DesiredRowsDt.Rows[i]["is_expired"]);
                string queryUpdate = "";
                //client_balance update
                if (IsExpired)
                {
                    queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid,is_expired=@is_expired WHERE  client_balance_id=@client_balance_id";
                }
                else
                {
                    queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid WHERE  client_balance_id=@client_balance_id";
                }

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
                cmdUpdate.Parameters.AddWithValue("@client_balance_id", DesiredRowsDt.Rows[i]["client_balance_id"]);
                cmdUpdate.Parameters.AddWithValue("@balance", DesiredRowsDt.Rows[i]["balance"]);
                cmdUpdate.Parameters.AddWithValue("@amount_paid", DesiredRowsDt.Rows[i]["amount_paid"]);
                cmdUpdate.Parameters.AddWithValue("@is_expired", DesiredRowsDt.Rows[i]["is_expired"]);
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
            }



            for (int i = 0; i < ListFinanceUpdates.Count; i++)
            {
                var Tuple = ListFinanceUpdates[i];
                ProjectToSQL.InsertToFinance(Tuple.Item2, Tuple.Item1, Date, AlbumType);
            }


        }


        public static void UpdateClientBalanceOnEditingOffre(int ID, string UpdatedOffre, double UpdatedBalance, bool isExpired)//isexpired mawjude cz ma3woul ykun gher bundle
        {
            string query = "";
            if (isExpired)
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
            }
            else
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance WHERE client_balance_id=@client_balance_id ";
            }
            SqlCommand cmdUpdate = new SqlCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);
            cmdUpdate.Parameters.AddWithValue("@balance", UpdatedBalance);
            cmdUpdate.Parameters.AddWithValue("@offre", UpdatedOffre);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientBalanceOnEditingSessions(int ID, int UpdatedSessionOrDaysLeft, string newoffre, DateTime? Newduedate, bool isExpired)//isexpired mesh mawjude cz bas bundle hone
        {
            string query = "";
            SqlCommand cmdUpdate = null;
            if (newoffre != null)//Updating mode
            {
                if (Newduedate == null)
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SqlCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                }
                else//days, w baddak now tkammil men hone, shuf el save points
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,due_date=@due_date,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SqlCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                    //
                    DateTime DueDate = (DateTime)Newduedate;
                    cmdUpdate.Parameters.AddWithValue("@due_date", Newduedate);

                }

            }
            else//reducing a session mode
            {
                if (Newduedate == null)//mafi reduce session lal bundle days that s why ma hattayna else
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,is_expired=@is_expired  WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SqlCommand(query, con);
                }
            }

            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionOrDaysLeft);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();


        }
        public static void UpdateClientBalanceOnFreezingDays(int ID, int UpdatedSessionOrDaysLeft, DateTime? Newduedate)
        {
            string query = "";
            SqlCommand cmdUpdate = null;
            bool IsFreezing;
            if (Newduedate == null)//freezing mode
            {
                query = "UPDATE client_balance SET session_left_days=@session_left_days,is_freezed=@is_freezed WHERE client_balance_id=@client_balance_id ";
                cmdUpdate = new SqlCommand(query, con);
                //
                IsFreezing = true;
            }
            else//reactivation mode
            {

                query = "UPDATE client_balance SET session_left_days=@session_left_days,due_date=@due_date,is_freezed=@is_freezed WHERE client_balance_id=@client_balance_id ";
                cmdUpdate = new SqlCommand(query, con);
                //
                DateTime DueDate = (DateTime)Newduedate;
                cmdUpdate.Parameters.AddWithValue("@due_date", Newduedate);
                //
                IsFreezing = false;


            }
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionOrDaysLeft);
            cmdUpdate.Parameters.AddWithValue("@is_freezed", IsFreezing);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);

            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateIsexpiredClientBalanceRemoveUC(int ID, bool isExpired)
        {
            string query = "UPDATE client_balance SET is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
            SqlCommand cmdUpdate = new SqlCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }

        public static void ReduceSessionFromPackageOfSessions(int ClientId, int DesiredClientBalanceId, int UpdatedSessionLeft, int? AppointmentId)
        {
            //Sql update
            DateTime Date = DateTime.Now;
            ClassClientBalance.UpdateClientBalanceOnEditingSessions(DesiredClientBalanceId, UpdatedSessionLeft, null, null, false);//lieanno this function onlykermel el package sessiosns                   
            ClassClient.UpdateClientCheckInSQL(ClientId, Date);
            ProjectToSQL.InsertToClientAttendance(ClientId, DesiredClientBalanceId, AppointmentId);

            ClassBackOffice backOffice = new ClassBackOffice(ClientId, ActionsEnum.SessionDone, LOGIN.Employee.EmployeeId, DesiredClientBalanceId, null, SQLToProject.GetLAstInsertedAttendance(), AppointmentId, null, null, Date);
            DataTable dt = ClassClientBalance.GetClientBalanceAllInfoSql(DesiredClientBalanceId);//ma ela aaze bas mafina baleha, kermel CreateActionDetails, el clean code
            backOffice.CreateActionDetails(dt.Rows[0]);
            backOffice.InsertToArchiveSQL();
        }

        public static void DeleteClientBalance(int DesiredClientBalanceId)
        {
            //Eza ghayaret shi hone make sure tghayir also bel classClient on delete client
            con.Open();

            //hole el 4 ejbare bhal order kermel needir nemhe client balance
            string QueryDeleteArchive = "DELETE FROM archive WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SqlCommand cmd1 = new SqlCommand(QueryDeleteArchive, con);
            cmd1.ExecuteNonQuery();

            string QueryDeleteFinance = "DELETE FROM finance WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SqlCommand cmd2 = new SqlCommand(QueryDeleteFinance, con);
            cmd2.ExecuteNonQuery();

            string QueryDeleteAppointments = "DELETE FROM appointments WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SqlCommand cmd5 = new SqlCommand(QueryDeleteAppointments, con);
            cmd5.ExecuteNonQuery();

            string QueryDeleteClientBalance = "DELETE FROM client_balance WHERE client_balance_id ='" + DesiredClientBalanceId + "'";
            SqlCommand cmd3 = new SqlCommand(QueryDeleteClientBalance, con);
            cmd3.ExecuteNonQuery();


            con.Close();

        }



        public static string SetPackageRemainingsFormat(DataRow dtrow)
        {
            string PackageRemainings = dtrow["Description"] + ": ";//Description = Bundle Name
            if (dtrow["due_date"] != DBNull.Value)
            {
                if ((bool)dtrow["is_freezed"] == false)//only packgae of days not freezed
                {
                    int daysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)dtrow["due_date"]);
                    if (daysLeft < 0)
                    {
                        daysLeft = 0;
                    }
                    PackageRemainings += daysLeft + " Days Left";//tene wahde - awwal wahde
                }
                else//package days freezed
                {
                    PackageRemainings += (int)dtrow["session_left_days"] + " Days Left(Freezed)";
                }
            }
            else//package sesiosn
            {
                PackageRemainings += (int)dtrow["session_left_days"] + " Session Left";
            }
            return PackageRemainings;
        }







        //kermel el design display tb3 clientBalance bel datatgridView
        public static void FormatClientBalanceDt(DataTable DtClientBalanceOriginal)
        {

            DtClientBalanceOriginal.Columns.Add("AutoIncrementColumn", typeof(int));
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrement = true;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementSeed = 1;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementStep = 1;
            int currentAutoIncrementValue = 1;

            foreach (DataRow row in DtClientBalanceOriginal.Rows)
            {
                row["AutoIncrementColumn"] = currentAutoIncrementValue;
                currentAutoIncrementValue++;
            }
            DtClientBalanceOriginal.PrimaryKey = new DataColumn[] { DtClientBalanceOriginal.Columns["client_balance_id"] };

            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("AutoIncrementColumn"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("Description");//description bas kermel el design 
            newIndex = 1; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("purchase_date"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("due_date"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("original_offre"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("offre"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("amount_paid"); // Replace with the actual column name
            newIndex = 6; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("balance"); // Replace with the actual column name
            newIndex = 7; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

        }
        public static void FixCellsFormat(DataGridView DesiredDatagrid, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DesiredDatagrid.Rows.Count && e.ColumnIndex < DesiredDatagrid.Columns.Count)
            {
                if (e.Value == DBNull.Value || e.Value == null)
                {
                    e.Value = "N/A";
                }
                else
                {
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "balance")
                    {
                        e.Value = Program.SetBalanceFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "amount_paid")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "original_offre")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());// $ + 350/ 20 sess
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "offre")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "due_date")
                    {
                        e.Value = ((DateTime)e.Value).ToString("MMMM/dd/yyyy");
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "purchase_date")
                    {
                        e.Value = ((DateTime)e.Value).ToString("MMMM/dd/yyyy");
                    }
                }

            }
            //Design Display
            if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "balance")
            {

                DataGridViewCell cell = DesiredDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (Convert.ToDouble(cell.Value) != 0)
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.SelectionForeColor = Color.Black;
                }
            }
        }
        public static void FormatDatagridview(DataGridView DesiredDataGrid, bool IsProfile)
        {
            foreach (DataGridViewColumn col in DesiredDataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DesiredDataGrid.Columns["client_balance_id"].Visible = false;
            DesiredDataGrid.Columns["bundle_id"].Visible = false;
            DesiredDataGrid.Columns["bundle_name"].Visible = false;
            DesiredDataGrid.Columns["product_id"].Visible = false;
            DesiredDataGrid.Columns["session_left_days"].Visible = false;
            DesiredDataGrid.Columns["is_freezed"].Visible = false;
            DesiredDataGrid.Columns["is_expired"].Visible = false;
            DesiredDataGrid.Columns["Currency_Name"].Visible = false;
            DesiredDataGrid.Columns["Symbol"].Visible = false;
            DesiredDataGrid.Columns["due_date"].Visible = false;

            if (IsProfile)
            {
                DesiredDataGrid.Columns["PayOrEdit"].DisplayIndex = DesiredDataGrid.ColumnCount - 2;
                DesiredDataGrid.Columns["Transactions"].DisplayIndex = DesiredDataGrid.ColumnCount - 1;
            }

            ///

            DesiredDataGrid.Columns["AutoIncrementColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DesiredDataGrid.Columns["Description"].FillWeight = 13;
            DesiredDataGrid.Columns["purchase_date"].FillWeight = 20;
            DesiredDataGrid.Columns["original_offre"].FillWeight = 17;
            DesiredDataGrid.Columns["offre"].FillWeight = 17;
            DesiredDataGrid.Columns["amount_paid"].FillWeight = 9;
            DesiredDataGrid.Columns["balance"].FillWeight = 12;
            DesiredDataGrid.Columns["due_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            DesiredDataGrid.Columns["balance"].HeaderText = "Balance";
            DesiredDataGrid.Columns["AutoIncrementColumn"].HeaderText = "ID";
            DesiredDataGrid.Columns["original_offre"].HeaderText = "Offre";
            DesiredDataGrid.Columns["offre"].HeaderText = "Deal";
            DesiredDataGrid.Columns["amount_paid"].HeaderText = "Paid";
            DesiredDataGrid.Columns["purchase_date"].HeaderText = "PurchaseDate";
        }


        //new function with sql
        public static List<ClassClientBalance> GetClientBalanceListNotExpiredPackage(int? clientID)
        {
            List<ClassClientBalance> ClientBalanceList = new List<ClassClientBalance> { };

            string query = @"Select	*                           
                            from client_balance 
                              where session_left_days is not null And is_expired='false' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            foreach (DataRow dr in dtClientBalance.Rows)
            {
                ClientBalanceList.Add(CreateClientBalanceObject((int)dr["client_balance_id"]));
            }
            return ClientBalanceList;
        }


        public static ClassClientBalance CreateClientBalanceObject(int ClientBalanceId)
        {
            DataTable dt;
            dt = GetClientBalanceAllInfoSql(ClientBalanceId);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassClientBalance DesiredClientBalance = new ClassClientBalance();

            DesiredClientBalance.ClientBalanceID = (int)datarow["client_balance_id"];
            DesiredClientBalance.ClientId = (int)datarow["client_id"];
            DesiredClientBalance.BundleId = datarow["bundle_id"] is DBNull ? null : (int)datarow["bundle_id"];
            DesiredClientBalance.ProductId = datarow["product_id"] is DBNull ? null : (int)datarow["product_id"];
            DesiredClientBalance.PurchaseDate = datarow["purchase_date"] is DBNull ? null : (DateTime)datarow["purchase_date"];
            DesiredClientBalance.OriginalOffre = datarow["original_offre"] is DBNull ? null : (string)datarow["original_offre"];
            DesiredClientBalance.Offre = datarow["offre"] is DBNull ? null : (string)datarow["offre"];
            DesiredClientBalance.AmountPaid = datarow["amount_paid"] is DBNull ? null : (double)datarow["amount_paid"];
            DesiredClientBalance.Balance = datarow["balance"] is DBNull ? null : (double)datarow["balance"];
            DesiredClientBalance.CurrencyName = datarow["Currency_Name"] is DBNull ? null : (string)datarow["Currency_Name"];
            DesiredClientBalance.SessionLeftDays = datarow["session_left_days"] is DBNull ? null : (int)datarow["session_left_days"];
            DesiredClientBalance.IsBundleMembership = datarow["isbundle_membership"] is DBNull ? null : (bool)datarow["isbundle_membership"];
            DesiredClientBalance.DueDate = datarow["due_date"] is DBNull ? null : (DateTime)datarow["due_date"];
            DesiredClientBalance.IsFreezed = datarow["is_freezed"] is DBNull ? null : (bool)datarow["is_freezed"];
            DesiredClientBalance.IsExpired = datarow["is_expired"] is DBNull ? null : (bool)datarow["is_expired"];



            return DesiredClientBalance;

        }
        public void SetStringDetailsIfBundle()
        {
            //Number Of Sessions or days
            if (BundleId != null)
            {
                string ServiceName;
                ServiceName = ClassBundles.FindBundleName((int)BundleId);

                string Details = "";
                //sessionleft
                if (DueDate == null)//package of sessions
                {
                    Details = SessionLeftDays + " sess";
                }
                else if (DueDate != null)//package of days
                {

                    Details = DaysLeft + " days";//tene wahde - awwal wahde

                    if (IsFreezed == true)

                    {
                        Details += " (Freezed)";
                    }

                }
                ClientBalanceSessionLeftDetails = ServiceName + ": " + Details;
            }
        }

        public ClassClientBalance Copy()
        {
            return (ClassClientBalance)this.MemberwiseClone();
        }
    }
}

