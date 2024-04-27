using MKproject.Schedule;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{

    public class TouchScroll
    {
        public static bool MoveHoldClick = false;
        private Point mouseDownPoint;

        VScrollBar vScrollBar { get; set; }

        TableLayoutPanelBuffered PanelUCDay;
        FlowLayoutPanel PanelCBTime;
        TableLayoutPanelBuffered PanelAvailibility;
        Panel Panelreminder;
        Panel Panelclientreminder;

        ScheduleForm schedule;
        UCDay ucday;
        CBdisplayTime cbdisplaytime;
        AvailabilityLayout availabilityLayout;
        ClientReminder clientreminder;


        private void MouseMoveFunctionRBR(TableLayoutPanelBuffered Panel)//scroll ROW BY ROW:RBR  
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);
            MoveHoldClick = true;
            //parentPanelT.AutoScrollPosition = new Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y);
            Panel.rowHeight = Panel.GetRowHeights()[0]; // Assuming a static row height for simplicity

            if (Cursor.Position.Y - mouseDownPoint.Y > 0)
            {
                // Scrolling up
                Panel.currentRow = Math.Max(0, Panel.currentRow - 1);
            }
            else
            {
                // Scrolling down
                Panel.currentRow = Math.Min(Panel.RowCount - Panel.GetVisibleRowsCount(), Panel.currentRow + 1);
            }

            // Ensure we're not exceeding the maximum allowable value
            int newValue = Panel.currentRow * Panel.rowHeight;

            Panel.AutoScroll = false;
            Panel.VerticalScroll.Value = Math.Min(newValue, Panel.VerticalScroll.Maximum);//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi,  that s why ha nestaamil autoscroll w nkhabbiya                                                                                  
            vScrollBar.Value = Math.Min(newValue, Panel.VerticalScroll.Maximum);
            Panel.AutoScroll = true;

            mouseDownPoint = Cursor.Position;
        }
        private void MouseMoveFunction(Panel Panel)
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);
            MoveHoldClick = true;
            Point currAutoS = Panel.AutoScrollPosition;
            Panel.AutoScrollPosition = new Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y);
            mouseDownPoint = Cursor.Position;
        }


        public TouchScroll(TableLayoutPanelBuffered panelUCDay, UCDay form1, VScrollBar vscroll)
        {
            PanelUCDay = panelUCDay;
            ucday = form1;
            vScrollBar = vscroll;
            AssignEventPanelUCDay(PanelUCDay);//ha hayrouh menna appointments w yejo
        }
        /// <summary>
        /// hek kermel lcontrol li fiyo event yenshel w yerjaee yenhot lal kel
        /// </summary>
        private void AssignEventPanelUCDay(Control control)
        {
            control.MouseDown += MouseDownPanelUCDay;
            control.MouseMove += MouseMovePanelUCDay;
            control.MouseUp += MouseUpPanelUCDay;
            foreach (Control child in control.Controls)
            {
                AssignEventPanelUCDay(child);
            }
        }
        public void ReAssignEventPanelUCDay(Control control)
        {
            control.MouseDown -= MouseDownPanelUCDay;
            control.MouseMove -= MouseMovePanelUCDay;
            control.MouseUp -= MouseUpPanelUCDay;

            foreach (Control child in control.Controls)
            {
                ReAssignEventPanelUCDay(child);
            }
            AssignEventPanelUCDay(control);
        }
        public void MouseMovePanelUCDay(object sender, MouseEventArgs e)
        {
            //Point currAutoS = parentPanelT.AutoScrollPosition;
            if (Math.Abs(Cursor.Position.Y - mouseDownPoint.Y) >= PanelUCDay.rowHeight / 2)
            {
                if (e.Button != MouseButtons.Left)
                {
                    return;
                }

                if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
                {
                    return;
                }


                MouseMoveFunctionRBR(PanelUCDay);


                Control control = sender as Control;
                if ((control is UCTime) || control == PanelUCDay)
                {

                }
                else if ((control is FlowLayoutPanel) || (control is TableLayoutPanel))//the other are inside ucappointment
                {
                    if (control.BackColor == ucday.DisableColorFLP)
                    {

                    }
                    else
                    {
                        control.BackColor = ucday.StaticColorFLP;
                    }
                }
                else if (control is UCappointment)
                {
                    UCappointment ucappointments = (UCappointment)control;
                    if (ucappointments.TLPGlobal.BackColor == ucday.DisableColorTBUca)
                    {

                    }
                    else
                    {
                        ucappointments.TLPGlobal.BackColor = ucday.StaticColorTBUca;
                    }

                }
                else//lbe2e ha ykoun taba3 haw jouwet UCappointments
                {
                    if (control.Parent.BackColor == ucday.DisableColorTBUca)
                    {

                    }
                    else
                    {
                        control.Parent.BackColor = ucday.StaticColorTBUca;
                    }
                }

                //Console.WriteLine("Value: " + PanelUCDay.VerticalScroll.Value + "\nValueCust: " + vScrollBar.Value + "\nMax= " + PanelUCDay.VerticalScroll.Maximum + "\nMaxCust " + vScrollBar.Maximum + "\n");
            }
        }
        public void MouseDownPanelUCDay(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = Cursor.Position;
            }

        }
        public void MouseUpPanelUCDay(object sender, MouseEventArgs e)
        {
            MoveHoldClick = false;
        }



        public TouchScroll(FlowLayoutPanel panelCBTime, CBdisplayTime combobox)
        {
            PanelCBTime = panelCBTime;
            cbdisplaytime = combobox;
            AssignEventPanelCBTime(panelCBTime);
        }
        private void AssignEventPanelCBTime(Control control)
        {
            control.MouseDown += MouseDownPanelCBTime;
            control.MouseMove += MouseMovePanelCBTime;
            control.MouseUp += MouseUpPanelCBTime;
            foreach (Control child in control.Controls)
            {
                AssignEventPanelCBTime(child);
            }
        }
        private void MouseMovePanelCBTime(object sender, MouseEventArgs e)
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
            {
                return;
            }

            MouseMoveFunction(PanelCBTime);
            Control control = sender as Control;
            if (control is LabelTime)
            {
                LabelTime labeltime = (LabelTime)control;
                if(cbdisplaytime.targetlabeltimeHighlight.Time != labeltime.Time)
                {
                    control.BackColor = Color.White;
                }
            }

        }
        private void MouseDownPanelCBTime(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownPoint = Cursor.Position;

            }
        }
        private void MouseUpPanelCBTime(object sender, MouseEventArgs e)
        {
            MoveHoldClick = false;
        }


        public TouchScroll(Panel panelreminder, ScheduleForm form)
        {
            Panelreminder = panelreminder;
            schedule = form;
            AssignEventPanelreminder(panelreminder);
        }
        private void AssignEventPanelreminder(Control control)
        {
            control.MouseDown += MouseDownPanelreminder;
            control.MouseMove += MouseMovePanelreminder;
            control.MouseUp += MouseUpPanelreminder;
            foreach (Control child in control.Controls)
            {
                AssignEventPanelreminder(child);
            }
        }
        public void ReAssignEventPanelreminder(Control control)
        {
            control.MouseDown -= MouseDownPanelreminder;
            control.MouseMove -= MouseMovePanelreminder;
            control.MouseUp -= MouseUpPanelreminder;

            foreach (Control child in control.Controls)
            {
                ReAssignEventPanelreminder(child);
            }
            AssignEventPanelreminder(control);
        }
        private void MouseMovePanelreminder(object sender, MouseEventArgs e)
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
            {
                return;
            }

            MouseMoveFunction(Panelreminder);
            //Control control = sender as Control;
            //if (control is LabelTime)
            //{
            //    control.BackColor = Color.White;
            //}

        }
        private void MouseDownPanelreminder(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownPoint = Cursor.Position;

            }
        }
        private void MouseUpPanelreminder(object sender, MouseEventArgs e)
        {
            MoveHoldClick = false;
        }



        public TouchScroll(Panel panelclientreminder, ClientReminder form)
        {
            Panelclientreminder = panelclientreminder;
            clientreminder = form;
            AssignEventPanelclientreminder(Panelclientreminder);
        }
        private void AssignEventPanelclientreminder(Control control)
        {
            control.MouseDown += MouseDownPanelclientreminder;
            control.MouseMove += MouseMovePanelclientreminder;
            control.MouseUp += MouseUpPanelclientreminder;
            foreach (Control child in control.Controls)
            {
                AssignEventPanelclientreminder(child);
            }
        }
        public void ReAssignEventPanelclientreminder(Control control)
        {
            control.MouseDown -= MouseDownPanelclientreminder;
            control.MouseMove -= MouseMovePanelclientreminder;
            control.MouseUp -= MouseUpPanelclientreminder;

            foreach (Control child in control.Controls)
            {
                ReAssignEventPanelclientreminder(child);
            }
            AssignEventPanelclientreminder(control);
        }
        private void MouseMovePanelclientreminder(object sender, MouseEventArgs e)
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
            {
                return;
            }

            MouseMoveFunction(Panelclientreminder);
            //Control control = sender as Control;
            //if (control is LabelTime)
            //{
            //    control.BackColor = Color.White;
            //}

        }
        private void MouseDownPanelclientreminder(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownPoint = Cursor.Position;

            }
        }
        private void MouseUpPanelclientreminder(object sender, MouseEventArgs e)
        {
            MoveHoldClick = false;
        }



        public TouchScroll(TableLayoutPanelBuffered panelAvailibility, AvailabilityLayout form1, VScrollBar vscroll)
        {
            PanelAvailibility = panelAvailibility;
            availabilityLayout = form1;
            vScrollBar = vscroll;
            AssignEventPanelAvailibility(panelAvailibility);
        }
        private void AssignEventPanelAvailibility(Control control)
        {
            control.MouseDown += MouseDownPanelAvailibility;
            control.MouseMove += MouseMovePanelAvailibility;
            control.MouseUp += MouseUpPanelAvailibility;
            foreach (Control child in control.Controls)
            {
                AssignEventPanelAvailibility(child);
            }
        }
        private void MouseMovePanelAvailibility(object sender, MouseEventArgs e)
        {
            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);
            //Point currAutoS = parentPanelT.AutoScrollPosition;
            if (Math.Abs(Cursor.Position.Y - mouseDownPoint.Y) >= PanelAvailibility.rowHeight / 2)
            {

                if (e.Button != MouseButtons.Left)
                {
                    return;
                }

                if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
                {
                    return;
                }

                MouseMoveFunctionRBR(PanelAvailibility);

                Control control = sender as Control;
                if (control is Panel && control.BackColor == Color.FromArgb(229, 226, 244))
                {
                    control.BackColor = Color.White;
                }
                //Console.WriteLine("Value: " + PanelAvailibility.VerticalScroll.Value + "\nValueCust: " + vScrollBar.Value + "\nMax= " + PanelAvailibility.VerticalScroll.Maximum + "\nMaxCust " + vScrollBar.Maximum + "\n");
            }
        }
        private void MouseDownPanelAvailibility(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownPoint = Cursor.Position;

            }
        }
        private void MouseUpPanelAvailibility(object sender, MouseEventArgs e)
        {
            MoveHoldClick = false;
        }






    }
}

