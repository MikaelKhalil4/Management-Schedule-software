using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace MKproject.Schedule
{
    public partial class ChooseService : Form
    {
        UCBundlesOutput uCBundlesOutput;
        FlowLayoutPanel FLPAvailablePackages;
        Label LabelNoDataRecorded;

        public List<ClassBundles> BundleList = new List<ClassBundles>();
        public UCClientApp ParentFormucClientApp { get; set; }


        public ChooseService(UCClientApp uc)
        {
            InitializeComponent();
            ParentFormucClientApp = uc;

            labelFullName.Text = ParentFormucClientApp.DesiredAppointmentUCClientApp.DesiredClient.Fname + " " + ParentFormucClientApp.DesiredAppointmentUCClientApp.DesiredClient.Lname;
            SetUCSlidebutton();
            if (ParentFormucClientApp.PackageRemainingsDt.Rows.Count == 0)
            {
                ucSlideButton.button2_Click(this, new EventArgs());
            }
            else
            {
                ucSlideButton.button1_Click(this, new EventArgs());

            }

        }
        void SetUCSlidebutton()
        {
            ucSlideButton.Button1Clicked += UcSlideButton_Button1Clicked; ;
            ucSlideButton.Button2Clicked += UcSlideButton_Button2Clicked; ;
        }



        private void UcSlideButton_Button1Clicked(object sender, EventArgs e)
        {
            if (ucSlideButton.ClickedButton != ucSlideButton.button1)
            {



                TLPglobal.RowStyles[3].Height = 0;
                if (uCBundlesOutput != null)
                {
                    TLPglobal.Controls.Remove(uCBundlesOutput);
                }

                if (ParentFormucClientApp.PackageRemainingsDt.Rows.Count > 0)
                {
                    //kermel l LabelNoDataRecorded
                    if (TLPglobal.Controls.Contains(LabelNoDataRecorded))
                    {
                        LabelNoDataRecorded.Dispose();
                        LabelNoDataRecorded = null;
                    }
                    if (FLPAvailablePackages == null)
                    {
                        FLPAvailablePackages = new FlowLayoutPanel();
                        FLPAvailablePackages.Dock = DockStyle.Fill;
                        FLPAvailablePackages.FlowDirection = FlowDirection.LeftToRight;
                        FLPAvailablePackages.AutoScroll = true;
                        FLPAvailablePackages.Padding = new Padding(0);
                        for (int i = 0; i < ParentFormucClientApp.PackageRemainingsDt.Rows.Count; i++)//since it s a flp
                        {
                            DataRow DesiredRow = ParentFormucClientApp.PackageRemainingsDt.Rows[i];
                            if (DesiredRow["bundle_id"] != DBNull.Value && DesiredRow["session_left_days"] != DBNull.Value)//since we have a condition on session left, which mean we re talking abt bundles or session nor products
                            {
                                CreateUCPackage(DesiredRow);
                            }
                        }
                    }
                    TLPglobal.Controls.Add(FLPAvailablePackages, 0, 2);
                }
                else
                {
                    if (LabelNoDataRecorded == null)
                    {
                        CreateTheNoLabelData();
                    }
                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 2);
                }

            }
        }
        public void CreateUCPackage(DataRow DesiredRow)
        {

            UCBundlePackage bundlePackage = new UCBundlePackage(true, DesiredRow);
            bundlePackage.UCMouseClick += BundlePackage_UCMouseClick; ;
            bundlePackage.Margin = new Padding(132, 0, 0, 10);
            FLPAvailablePackages.Controls.Add(bundlePackage);

        }

        private void BundlePackage_UCMouseClick(object sender, EventArgs e)
        {
            UCBundlePackage DesiredBundPackage = (UCBundlePackage)sender;
            ParentFormucClientApp.FillObjectOfNewChosenBundles(null);
            ParentFormucClientApp.FillObjectOfAvailablePackage(DesiredBundPackage.DesiredRow);
            ParentFormucClientApp.SetDesignMode(true, false);
            this.Close();
        }

      

        private void UcSlideButton_Button2Clicked(object sender, EventArgs e)
        {
            if (ucSlideButton.ClickedButton != ucSlideButton.button2)
            {
                TLPglobal.RowStyles[3].Height = 42;
                if (FLPAvailablePackages != null)
                {
                    TLPglobal.Controls.Remove(FLPAvailablePackages);
                }
                if (LabelNoDataRecorded != null)
                {
                    TLPglobal.Controls.Remove(LabelNoDataRecorded);
                }
                if (uCBundlesOutput == null)
                {

                    uCBundlesOutput = new UCBundlesOutput(this);        
                    uCBundlesOutput.Dock = DockStyle.Fill;
                    uCBundlesOutput.Margin = new Padding(15, 5, 15, 0);                 
                }
                TLPglobal.Controls.Add(uCBundlesOutput, 0, 2);
            }
        }
        private void buttonChoose_Click(object sender, EventArgs e)
        {

            ParentFormucClientApp.FillObjectOfAvailablePackage(null);
            if (BundleList.Count > 0)
            {
                ParentFormucClientApp.FillObjectOfNewChosenBundles(new List<ClassBundles>(BundleList));
            }
            else
            {
                ParentFormucClientApp.FillObjectOfNewChosenBundles(null);
            }

            ParentFormucClientApp.SetDesignMode(true, false);
            this.Close();
        }


        void CreateTheNoLabelData()
        {
            LabelNoDataRecorded = new Label();
            LabelNoDataRecorded.Text = "No Remainning Packages";
            LabelNoDataRecorded.Font = new Font("Segoe UI", 17, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);
            LabelNoDataRecorded.BackColor = Color.FromArgb(150, Color.WhiteSmoke.R, Color.WhiteSmoke.G, Color.WhiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(15, 5, 15, 15);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
