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

namespace MKproject.Schedule
{
    public partial class ChooseService : Form
    {
        public ChooseService(bool IsPackagesAvailableOrNewService)
        {
            InitializeComponent();
            SetUCSlidebutton();
            if (IsPackagesAvailableOrNewService)
            {
                ucSlideButton.button1_Click(this, new EventArgs());
            }
            else
            {
                ucSlideButton.button2_Click(this, new EventArgs());
            }
        }
        void SetUCSlidebutton()
        {
            ucSlideButton.Button1Clicked += UcSlideButton_Button1Clicked; ;
            ucSlideButton.Button2Clicked += UcSlideButton_Button2Clicked; ;
        }
        private void UcSlideButton_Button1Clicked(object sender, EventArgs e)
        {
            if (uCBundlesOutput != null)
            {

                TLPglobal.Controls.Remove(uCBundlesOutput);
            }

            if (FLPAvailablePackages == null)
            {
                FLPAvailablePackages = new FlowLayoutPanel();
                FLPAvailablePackages.Dock = DockStyle.Fill;
                FLPAvailablePackages.FlowDirection = FlowDirection.TopDown;
                FLPAvailablePackages.AutoScroll = true;
                TLPglobal.Controls.Add(FLPAvailablePackages);
            }

        }

        UCBundlesOutput uCBundlesOutput;
        FlowLayoutPanel FLPAvailablePackages;
        private void UcSlideButton_Button2Clicked(object sender, EventArgs e)
        {
            if (FLPAvailablePackages != null)
            {
                TLPglobal.Controls.Remove(FLPAvailablePackages);
            }
            if (uCBundlesOutput == null)
            {
                uCBundlesOutput = new UCBundlesOutput();
                uCBundlesOutput.ParentFormChooseService = this;
                uCBundlesOutput.Dock = DockStyle.Fill;
               
            }          
            TLPglobal.Controls.Add(uCBundlesOutput);
        }


    }
}
