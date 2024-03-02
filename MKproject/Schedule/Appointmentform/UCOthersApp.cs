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
    public partial class UCOthersApp : UserControl
    {
        public UCOthersApp(ClassAppointment desiredappointment)
        {
            InitializeComponent();
            if(desiredappointment.Title != null)
            {
                textBoxOthers.Text = desiredappointment.Title;
            }
        }
    }
}
