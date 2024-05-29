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
        public ClassEmployee DesiredEmployee { get; set; }
        public DateTime? DesiredDate { get; set; }
        public bool IsClicked { get; set; }


        Color PAstDaysDefaultForeColor = Color.FromArgb(120, 120, 120);
        Color FutureDayDefaultForeColor = Color.Black;
        Color PresentDayDefaultForeColor = Color.White;



        public ButtonEmployeeOrDay()
        {

            this.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.AutoSize = true;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Flat;
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
                    ForeColor = PresentDayDefaultForeColor;

                }
                else if (((DateTime)DesiredDate).Date < DateTime.Now.Date)
                {
                    ForeColor = PAstDaysDefaultForeColor;
                }
                else
                {
                    ForeColor = FutureDayDefaultForeColor;

                }
            }
        }
        public void SetActiveModeDesign()
        {
        
            if (DesiredEmployee != null)
            {
                ForeColor = Color.FromArgb(211, 211, 211);
            }
            else if (DesiredDate != null)
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

     
        public void SetButtonDesignBehavor(bool IsDayOrWeek, bool ISBlocked)
        {

            if (IsDayOrWeek && !ISBlocked)
            {

                BackColor = Color.FromArgb(119, 132, 234);
                FlatAppearance.MouseOverBackColor = BackColor;
                FlatAppearance.MouseDownBackColor = BackColor;
                ForeColor = Color.White;
            }
            else if (IsDayOrWeek && ISBlocked)
            {
                BackColor = Color.Transparent;
                FlatAppearance.MouseOverBackColor = BackColor;
                FlatAppearance.MouseDownBackColor = BackColor;
            }
            else
            {

                BackColor = Color.Transparent;
                FlatAppearance.MouseOverBackColor = BackColor;
                FlatAppearance.MouseDownBackColor = BackColor;

                if (((DateTime)DesiredDate).Date == DateTime.Now.Date)//present
                {

                    Image = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "oval-Small.png");
                    ForeColor = PresentDayDefaultForeColor;
                }
                else if (((DateTime)DesiredDate).Date < DateTime.Now.Date)//past
                {
                    ForeColor = PAstDaysDefaultForeColor;
                }
                else//future
                {
                    ForeColor = FutureDayDefaultForeColor;
                }
            }
        }

    }
}
