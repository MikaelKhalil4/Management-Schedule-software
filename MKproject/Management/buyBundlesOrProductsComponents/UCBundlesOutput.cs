using GlobalFunctions;
using MKproject.Schedule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static MKproject.Management.ClassBundles;


namespace MKproject.Management
{
    public partial class UCBundlesOutput : UserControl
    {
        public BuyBundleOrProudct ParentFormBuy { get; set; }
        public ChooseService ParentFormChooseService { get; set; }

        public UCBundlesOutput(ChooseService parentFormChooseService)//baatneha in argument for the reason , in the load event we re using it
        {
            InitializeComponent();

            dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
            DataTable dtBundle = ClassBundles.RetrieveAllBundleStatusOn();
            FormatdtBundles(dtBundle);
            FormatDatagridViewBundles(dtBundle);

            ParentFormChooseService = parentFormChooseService;

        }



        public void FormatdtBundles(DataTable dt)
        {
            dt.Columns.Add("ColumnCheck", typeof(bool));
            dt.Columns.Add("Membership", typeof(string));
            dt.Columns.Add("BundleDetails", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
              
                if ((bool)row["is_member_ship"] == true)
                {
                    row["Membership"] = "MemberShip";
                }
                else
                {
                    row["Membership"] = "Not MemberShip";
                }

                row["ColumnCheck"] = false;
                row["BundleDetails"] = row["sessions_numb"] + " " + row["bundle_type"];
            }

            //ordering
            int columnIndexToMove;
            int newIndex;


            columnIndexToMove = dt.Columns.IndexOf("ColumnCheck"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("bundle_name"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("description"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("BundleDetails"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("price"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("Membership"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);
        }

        private void dataGridViewBundles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }
                else
                {
                    //text display
                    if (dataGridViewBundles.Columns[e.ColumnIndex].Name == "price")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                }
            }
        }


        public void FormatDatagridViewBundles(DataTable dtBundles)
        {
            dataGridViewBundles.DataSource = dtBundles;

            dataGridViewBundles.Columns["is_member_ship"].Visible = false;
            dataGridViewBundles.Columns["Currency_Name"].Visible = false;
            dataGridViewBundles.Columns["bundle_id"].Visible = false;
            dataGridViewBundles.Columns["sessions_numb"].Visible = false;
            dataGridViewBundles.Columns["status"].Visible = false;
            dataGridViewBundles.Columns["bundle_type"].Visible = false;

            dataGridViewBundles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBundles.RowTemplate.MinimumHeight = 40; // Set minimum row height

            dataGridViewBundles.Columns["Membership"].FillWeight = 20;
            dataGridViewBundles.Columns["ColumnCheck"].FillWeight = 8;
            dataGridViewBundles.Columns["bundle_name"].FillWeight = 22;
            dataGridViewBundles.Columns["BundleDetails"].FillWeight = 22;
            dataGridViewBundles.Columns["price"].FillWeight = 11;
            dataGridViewBundles.Columns["description"].FillWeight = 15;

        }

        private void UCBundlesOutput_Load(object sender, EventArgs e)
        {
            if (ParentFormChooseService != null && ParentFormChooseService.ParentFormucClientApp.DesiredAppointment.ChosenServicesList != null)
            {
                SelectChosenServices();
            }
            dataGridViewBundles.ClearSelection();
        }

        public void SelectChosenServices()
        {
            foreach (DataGridViewRow row in dataGridViewBundles.Rows)
            {
                foreach (ClassBundles bundle in ParentFormChooseService.ParentFormucClientApp.DesiredAppointment.ChosenServicesList)
                {
                    if (bundle.ID == (int)row.Cells["bundle_id"].Value)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);
                        row.Cells["ColumnCheck"].Value = true;

                        ParentFormChooseService.BundleList.Add(bundle);

                    }
                }
            }
        }

        private void dataGridViewBundles_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClassBundles Bundle = null;
            Bundle = new ClassBundles();
            FillingBundleDetails(dataGridViewBundles.Rows[e.RowIndex], Bundle);


            if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
            {
                dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
                dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
                dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);


                //Design
                if (ParentFormBuy != null)//only in buy product
                {
                    ParentFormBuy.AddItem(Bundle, null);
                }
                else if (ParentFormChooseService != null)
                {
                    ParentFormChooseService.BundleList.Add(Bundle);
                }

            }
            else if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
            {
                dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;


                //design
                if (ParentFormBuy != null)//only in buyproduct
                {
                    ParentFormBuy.RemoveButton(Bundle.ID, Bundle.Price);
                    //list
                    ParentFormBuy.BundleList.RemoveAll(p => p.ID == Bundle.ID);
                }
                else if (ParentFormChooseService != null)
                {
                    ParentFormChooseService.BundleList.RemoveAll(p => p.ID == Bundle.ID);
                }
            }
        }


        void FillingBundleDetails(DataGridViewRow DesiredRow, ClassBundles Bundle)
        {
            Bundle.ID = Convert.ToInt16(DesiredRow.Cells["bundle_id"].Value);
            Bundle.Name = DesiredRow.Cells["bundle_name"].Value.ToString();
            Bundle.Description = DesiredRow.Cells["description"].Value.ToString();

            if (DesiredRow.Cells["bundle_type"].Value.ToString() != ClassBundles.bundle.Solo.ToString())
            {
                Bundle.SessionDaysNumber = Convert.ToInt16(RandomFunctions.ExtractDigits(Convert.ToString(DesiredRow.Cells["sessions_numb"].Value)));
            }
            else//eza kenit solo
            {
                Bundle.SessionDaysNumber = null;
            }


            Bundle.Price = Convert.ToDouble(RandomFunctions.ExtractDigits(Convert.ToString(DesiredRow.Cells["price"].Value)));

            if ((bool)DesiredRow.Cells["is_member_ship"].Value)
            {
                Bundle.IsMemberShip = true;
            }
            else
            {
                Bundle.IsMemberShip = false;
            }

            string bundletype = DesiredRow.Cells["bundle_type"].Value.ToString();

            if (bundletype == ClassBundles.bundle.Sessions.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Sessions;
            }
            else if (bundletype == ClassBundles.bundle.Days.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Days;
            }
            else if (bundletype == ClassBundles.bundle.Solo.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Solo;
            }

            Bundle.Qty = 1;
        }


        //        //to select one row only
        //        else if(ParentFormChooseService!=null)
        //        {
        //            if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
        //            {
        //                dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
        //                dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
        //                dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);
        //                if (LastRowSelected != null)
        //                {
        //                    LastRowSelected.DefaultCellStyle.BackColor = Color.White;
        //                    LastRowSelected.Cells["ColumnCheck"].Value = false;
        //                }
        //    LastRowSelected = dataGridViewBundles.Rows[e.RowIndex];

        //            }
        //            else if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
        //{
        //    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
        //    dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.White;
        //    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
        //    dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        //}
        //        }





    }
}
