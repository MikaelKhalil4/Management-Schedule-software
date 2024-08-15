using CustomizedTools;
using MKproject.Infrastucture;
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

namespace MKproject.HomeAndMenuAndBackUp
{
    public partial class ResetCredentials : Form
    {
        public ResetCredentials()
        {
            InitializeComponent();
        }

        private async void buttonReset_ClickAsync(object sender, EventArgs e)
        {
            ClassEmployee owner= ClassEmployee.CreateEmployeeObject((ClassEmployee.GetOwnerId()));
       
            Cursor = Cursors.WaitCursor;
            if (await HttpRequestsClass.RegisterClient(UCTextboxTicketID.Value, owner.PhoneNumber))
            {
                CustomMessageBox.Show("Credentials reset successfully. Now we're going to restart the app.", CustomMessageBox.Type.OkInfo);
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                CustomMessageBox.Show("TicketId Is Wrong", CustomMessageBox.Type.Error);
            }

            Cursor = Cursors.Default;
        }
    }
}
