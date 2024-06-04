
using CustomizedTools;
using System;
using System.Data;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class RelatedChildrens : Form
    {
        bool IsFromSchedule;
        public ClientManagementProfile ParentFormClientMang { get; set; }
      
        public RelatedChildrens(string ChildOrParentPhoneNumber, bool Parent,bool isFromSchedule)
        {
            InitializeComponent();
            IsFromSchedule = isFromSchedule;
            FillClients(ChildOrParentPhoneNumber, Parent);

            this.Opacity = 0;
            this.TopMost = true;
        }

        private void RelatedChildrens_Load(object sender, EventArgs e)
        {
            dataGridViewChildren.ClearSelection();
        }
        void FillClients(string ChildOrParentPhoneNumber, bool Parent)
        {
            DataTable dt = new DataTable();
            if (Parent)
            {

                dt.Clear();
                dt = ClassClient.GetLinkedChildrenSQL(ChildOrParentPhoneNumber);
            }
            else
            {
                dt.Clear();
                dt = ClassClient.GetLinkedPArentsSQL(ChildOrParentPhoneNumber);
            }

            if (dt.Rows.Count > 0)
            {
                dataGridViewChildren.DataSource = dt;

                foreach (DataGridViewColumn col in dataGridViewChildren.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dataGridViewChildren.ApplyStyle1();///ejbare foe el alignemnet

                dataGridViewChildren.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewChildren.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
                dataGridViewChildren.RowTemplate.MinimumHeight = 40; // Set minimum row height

                dataGridViewChildren.Columns["client_id"].Visible = false;
                dataGridViewChildren.Columns["Full Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewChildren.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
        }

    
        private void dataGridViewChildren_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!IsFromSchedule)
                {
                    object idValue = dataGridViewChildren.Rows[e.RowIndex].Cells["client_id"].Value;
                    if (idValue != DBNull.Value)
                    {
                        int id = Convert.ToInt32(idValue);
                        SearchCurrentClient searchform = (SearchCurrentClient)Program.HomeForm.menu.ActivatedForm;

                        Program.HomeForm.buttonBackHome_Click(null, EventArgs.Empty);//ejbare  abel FocusOnADesiredRow,lieanno inside of it aam yenaamal reset lal datatable, go check

                        searchform.FocusOnADesiredRow(id);
                        this.Close();
                    }
                }
                else
                {
                    CustomMessageBox.Show("Can't Navigate unless it was from the Home Page ", CustomMessageBox.Type.OkInfo);
                }
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                this.Select();
            }
            Opacity += .1;
        }

        private void RelatedChildrens_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void RelatedChildrens_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                this.Close();
            }
        }

      
    }
}
