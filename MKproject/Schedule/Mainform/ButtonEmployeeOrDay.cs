using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Schedule
{

    internal class ButtonEmployeeOrDay : Button
    {
        public  ClassEmployee DesiredEmployee { get; set; }
        public DateTime? DesiredDate { get; set; }
        public bool IsClicked { get; set; }
        public ButtonEmployeeOrDay()
        {
              
            this.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.AutoSize = true;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle= FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
         
        }
        public void SetDefaultModeDesign()
        {
            //BackColor = Program.BoldColor;
            if (DesiredEmployee != null)
            {
                ForeColor = Color.White;
            }
            else if (DesiredDate != null)
            {
                if (((DateTime)DesiredDate).Date == DateTime.Now.Date)
                {
                    ForeColor = Color.White;

                }
                else if (((DateTime)DesiredDate).Date < DateTime.Now.Date)
                {
                    ForeColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    ForeColor = Color.Black;

                }
            }
        }
        public void SetActiveModeDesign()
        {
            //BackColor = Color.FromArgb(2, 162, 111);
            if (DesiredEmployee != null)
            {
                ForeColor = Color.FromArgb(211, 211, 211);
            }
            else if(DesiredDate!=null)
            {
                if (((DateTime)DesiredDate).Date == DateTime.Now.Date)
                {
                    ForeColor = Color.FromArgb(211, 211, 211);
                }
               
                else
                {
                    ForeColor = Program.BoldColor;
                }
            }
        }

       
    }
   
}
