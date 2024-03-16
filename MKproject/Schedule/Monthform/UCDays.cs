using GlobalFunctions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCDays : UserControl
    {
        //PROPERTIES:
        public DateTime DateUCdays { get; set; } //date of each case in UCMONTH

        //VARIABLES:
        public Schedule schedule;
        public UCMonth ucmonths;
        public UCDay ucday;


        //INITIALISE
        public UCDays()
        {
            InitializeComponent();
        }

       
        //EVENTS:
        private void UCDays_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ucmonths.DateUCMonth = DateUCdays;
            schedule.UCDaysClick();
            Cursor = Cursors.Default;
        }


        private void labelDays_MouseEnter(object sender, EventArgs e)
        {
            if (ucmonths.ucdayOfDateUCDay != this && ucmonths.ucdayOfToday != this)
            {
                labelDay.BackColor = Color.FromArgb(229, 226, 244);
            }


        }
        private void labelDays_MouseLeave(object sender, EventArgs e)
        {
            if (ucmonths.ucdayOfDateUCDay != this && ucmonths.ucdayOfToday != this)
            {
                labelDay.BackColor = Color.White;
            }
        }
    }
}


/// <summary>
/// mesh 3eyzina li2anno aam nente2il deghre aal ucday
/// </summary>
//private void ChangeUCFocus()//fi hal kabaset aa ucdays byotlaeelo houwe lborder color wel li ken aando lcolor bi rouh
//{
//    if (ucmonths.ucdaycopy != null)
//    {
//        if (ucmonths.ucdaycopy == this)
//        {

//        }
//        else
//        {
//            ucmonths.ucdaycopy.DisactivateBorederColor();
//            ucmonths.ucdaycopy = this;
//            ucmonths.ucdaycopy.ActivateBorederColor();
//        }
//    }
//    else//laken null manno reference la hada fa li mnekbous eele lezim ydawe bi sir reference la hayda
//    {
//        ucmonths.ucdaycopy = this;
//        ucmonths.ucdaycopy.ActivateBorederColor();
//    }
//}



///IN UCDAYCLICK
//ChangeUCFocus(); ma darore nesta3mela li2anno aam bi rouh aal calander day deghre
//  ucmonths.DateUCMonth = DateUCdays;*/ //ma lezim nhotta li2anno fi hal kabasna bi calander month ldays taba3 haydak lmonth bi sir ucday=ucmonths ka date fa eza rje3na aa calander lmonth ma ha ya3mil display lal month lprevious



///When you want to edit the color of the borders
//FUNCTION:
//public void ActivateBorederColor()
//{
//    isHovering = true;
//    // Trigger a repaint by invalidating the TableLayoutPanel
//    tableLayoutPanelForm.Invalidate();

//}
//public void DisactivateBorederColor()
//{
//    isHovering = false;
//    tableLayoutPanelForm.Invalidate();
//}

//DESIGN:
//private void tableLayoutPanelForm_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
//{
//    if (isHovering)
//    {
//        Control control = (Control)sender;
//        using (Pen pen = new Pen(Color.FromArgb(196, 210, 245), 5)) // Set your desired color and thickness
//        {
//            e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
//        }
//    }
//}
//private void tableLayoutPanelForm_MouseEnter(object sender, EventArgs e)
//{
//    ActivateBorederColor();
//}
//private void tableLayoutPanelForm_MouseLeave(object sender, EventArgs e)
//{
//    if (ucmonths.ucdaycopy != this)
//    {
//        DisactivateBorederColor();
//    }
//    else
//    {

//    }
//}