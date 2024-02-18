using MKproject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject
{
    public partial class Home : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Home()
        {
            InitializeComponent();

        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            Statistics s= new Statistics();
            s.Show();
        }

        private void buttonViewClients_Click(object sender, EventArgs e)
        {
            SearchCurrentClient s = new SearchCurrentClient();
            s.Show();
        }
     
        private void buttonEditPrices_Click(object sender, EventArgs e)
        {
            ViewBundlesAndProducts ed =new ViewBundlesAndProducts();
            ed.Show();
        }
   
        private void button3_Click(object sender, EventArgs e)
        {
            BackOffice b =new BackOffice(null,null,null,null);
            b.Show();
        }

        private void buttonEditEmployee_Click(object sender, EventArgs e)
        {
            ViewEmployee v = new ViewEmployee();
            v.Show();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
