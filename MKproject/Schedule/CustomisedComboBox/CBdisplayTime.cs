using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;



namespace MKproject.Schedule
{
    public partial class CBdisplayTime : Form
    {
        //VARIABLES
        public bool Isstarttime;

        ClassAppointment DesiredAppointmentAppForm;
        Appointment AppointmentForm;

        LabelTime targetlabeltimeScroll;//this is for the scroll and for the endtime it's also the highlight
        public LabelTime targetlabeltimeHighlight;//this the highlight for the starttime

        TimeSpan StartTime;
        TimeSpan EndTime;

        //INITIALISE
        public CBdisplayTime()
        {
            InitializeComponent();

        }
        public CBdisplayTime(bool isstarttime, Appointment appointment)
        {
            //Initialise
            Isstarttime = isstarttime;
            AppointmentForm = appointment;
            DesiredAppointmentAppForm = appointment.DesiredAppointmentAppForm;
            StartTime = DesiredAppointmentAppForm.StartTime.TimeOfDay;
            EndTime = DesiredAppointmentAppForm.EndTime.TimeOfDay;
            InitializeComponent();

            bool IsStartTimeCustomed = false;
            if (StartTime.Minutes != 0 && StartTime.Minutes != 15 && StartTime.Minutes != 30 && StartTime.Minutes != 45)//this means that he wrote the time and not pick it
            {
                IsStartTimeCustomed = true;
            }

            bool IsEndTimeCustomed = false;
            if (EndTime.Minutes != 0 && EndTime.Minutes != 15 && EndTime.Minutes != 30 && EndTime.Minutes != 45)//this means that he wrote the time and not pick it
            {
                IsEndTimeCustomed = true;
            }

            //StartTime
            if (Isstarttime)//HSOB STARTTIME = 8:15 AM
            {
                //Getting the labels
                if (appointment.textBoxStartTime.Text != "")
                {
                    textBoxTime.Text = appointment.textBoxStartTime.Text;
                }

                //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                List<LabelTime> ListLabelTime = new List<LabelTime>();


                TimeSpan TimeStart = new TimeSpan(0, 0, 0);//12:00 AM
                TimeSpan[] displaytime = new TimeSpan[97];

                //Getting the first label 
                displaytime[0] = TimeStart;
                LabelTime labeltime = new LabelTime(displaytime[0], this);
                ListLabelTime.Add(labeltime);

                //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the first label
                flowLayoutPanelContainerTime.Controls.Add(labeltime);
                if (labeltime.Time.Subtract(new TimeSpan(0, 30, 0)) == StartTime)//l2ina taba3 lscroll
                {
                    targetlabeltimeScroll = labeltime;
                }
                if (labeltime.Time == StartTime)//l2ina taba3 lhighlight
                {
                    targetlabeltimeHighlight = labeltime;
                }

                //getting the others
                int i = 1;
                TimeSpan timeSpanBreak = new TimeSpan(23, 45, 0);//12:00 AM
                int DifferenceCustomStartTime = 0;//if IsStartTimeCustomed=true: 0 < DifferenceCustomTime < 15 , exemple:  7:05-7:00=5

                while (displaytime[i - 1] != timeSpanBreak)//aala kel halet mamnou3 y2ati3 8:45 aw endtIME HONE HIYE BREAK
                {
                    displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));
                    if (IsStartTimeCustomed)
                    {
                        if (displaytime[i - 1] < StartTime && StartTime < displaytime[i])
                        {
                            DifferenceCustomStartTime = StartTime.Minutes - displaytime[i - 1].Minutes;// 7:05-7:00=5
                            LabelTime labeltimeCustom = new LabelTime(StartTime, this);
                            ListLabelTime.Add(labeltimeCustom);

                            flowLayoutPanelContainerTime.Controls.Add(labeltimeCustom);
                            targetlabeltimeHighlight = labeltimeCustom;


                            LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                            ListLabelTime.Add(labeltime1);
                            flowLayoutPanelContainerTime.Controls.Add(labeltime1);
                        }
                        else
                        {
                            LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                            ListLabelTime.Add(labeltime1);
                            flowLayoutPanelContainerTime.Controls.Add(labeltime1);


                            //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the other labels
                            if (labeltime1.Time.Subtract(new TimeSpan(0, 30, 0)).Add(new TimeSpan(0, DifferenceCustomStartTime, 0)) == StartTime)//l2ina taba3 lscroll
                            {
                                targetlabeltimeScroll = labeltime1;
                            }
                        }
                    }
                    else
                    {
                        LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                        ListLabelTime.Add(labeltime1);
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);


                        //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the other labels
                        if (labeltime1.Time.Subtract(new TimeSpan(0, 30, 0)) == StartTime)//l2ina taba3 lscroll
                        {
                            targetlabeltimeScroll = labeltime1;
                        }
                        if (labeltime1.Time == StartTime)//l2ina taba3 lhighlight
                        {
                            targetlabeltimeHighlight = labeltime1;
                        }
                    }

                    i++;
                }



                //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                if (targetlabeltimeScroll == null)
                {
                    targetlabeltimeScroll = ListLabelTime.Find(labeltime2 => labeltime2.Time == StartTime);
                }
                ScrollToSpecificUserControl(targetlabeltimeScroll);
                RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);


            }

            //EndTime
            else
            {
                if (appointment.textBoxEndTime.Text != "")
                {
                    textBoxTime.Text = appointment.textBoxEndTime.Text;
                }

                //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                List<LabelTime> ListLabelTime = new List<LabelTime>();
                LabelTime labeltime = new LabelTime(StartTime, this);
                ListLabelTime.Add(labeltime);

                //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the first label
                if ((StartTime >= new TimeSpan(23, 0, 0) && IsEndTimeCustomed == false) || (StartTime >= new TimeSpan(23, 15, 0) && IsEndTimeCustomed == true))
                {
                    labeltime.Size = new Size(118, 30);
                    flowLayoutPanelContainerTime.Controls.Add(labeltime);
                    if (labeltime.Time == EndTime)//l2ina taba3 lhighlight
                    {
                        targetlabeltimeHighlight = labeltime;
                    }
                }
                else
                {
                    flowLayoutPanelContainerTime.Controls.Add(labeltime);
                    if (labeltime.Time.Subtract(new TimeSpan(0, 30, 0)) == EndTime)//l2ina taba3 lscroll
                    {
                        targetlabeltimeScroll = labeltime;
                    }
                    if (labeltime.Time == EndTime)//l2ina taba3 lhighlight
                    {
                        targetlabeltimeHighlight = labeltime;
                    }
                }


                int DifferenceCustomStartTime = 0;
                for (int minute = 0; minute <= 45; minute += 15)
                {
                    int nextminute = minute + 15;
                    if (minute < StartTime.Minutes && StartTime.Minutes < nextminute)
                    {
                        DifferenceCustomStartTime = StartTime.Minutes - minute;
                    }
                }



                //Adding The Other labels
                int i = 1;
                TimeSpan timeSpanBreak = new TimeSpan(23, 45, 0);//12:00 AM
                TimeSpan[] displaytime = new TimeSpan[97];

                displaytime[0] = StartTime.Subtract(new TimeSpan(0, DifferenceCustomStartTime, 0));
                int DifferenceCustomEndTime = 0;

                while (displaytime[i - 1] != timeSpanBreak)
                {
                    displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));

                    if (IsEndTimeCustomed)
                    {
                        if (displaytime[i - 1] < EndTime && EndTime < displaytime[i])
                        {
                            DifferenceCustomEndTime = EndTime.Minutes - displaytime[i - 1].Minutes;// 7:05-7:00=5
                            LabelTime labeltimeCustom = new LabelTime(EndTime, this);
                            ListLabelTime.Add(labeltimeCustom);
                            flowLayoutPanelContainerTime.Controls.Add(labeltimeCustom);

                            LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                            ListLabelTime.Add(labeltime1);
                            flowLayoutPanelContainerTime.Controls.Add(labeltime1);

                            //there's no scroll
                            if (StartTime >= new TimeSpan(23, 15, 0))
                            {
                                labeltimeCustom.Size = new Size(118, 30);
                                labeltime1.Size = new Size(118, 30);
                            }
                            //there's scroll
                            else
                            {
                            }
                            targetlabeltimeHighlight = labeltimeCustom;
                        }
                        else
                        {
                            LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                            ListLabelTime.Add(labeltime1);
                            flowLayoutPanelContainerTime.Controls.Add(labeltime1);

                            //there's no scroll
                            if (StartTime >= new TimeSpan(23, 15, 0))
                            {
                                labeltime1.Size = new Size(118, 30);
                               
                            }
                            //there's scroll
                            else
                            {
                                //scrolling into the label that's after the Cutsomlabel(7:05) who has the time by (-30+5) = -25 
                                if (labeltime1.Time.Subtract(new TimeSpan(0, 30, 0)).Add(new TimeSpan(0, DifferenceCustomEndTime, 0)) == EndTime)//l2ina taba3 lscroll
                                {
                                    targetlabeltimeScroll = labeltime1;
                                }
                            }
                        }
                    }
                    else
                    {
                        LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                        ListLabelTime.Add(labeltime1);
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);
                        if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
                        {
                            targetlabeltimeHighlight = labeltime1;
                        }


                        //there's no scroll
                        if (StartTime >= new TimeSpan(23, 0, 0))
                        {
                            labeltime1.Size = new Size(118, 30);
                           
                        }
                        //there's scroll
                        else
                        {
                            //scrolling into the label that's after the label who has the time by -30 min
                            if (labeltime1.Time.Subtract(new TimeSpan(0, 30, 0)) == EndTime)//l2ina taba3 lscroll
                            {
                                targetlabeltimeScroll = labeltime1;
                            }
                        }
                    }

                    i++;
                }

                //if there's no scroll, we just Highlighting targetlabeltimeHighlight
                if (StartTime >= new TimeSpan(23, 0, 0) && IsEndTimeCustomed == false)//aa aal hale mafi scroll ba2a
                {
                    this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * i) + 29);
                    RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);//hone mafi scroll
                }

                else if (StartTime >= new TimeSpan(23, 15, 0) && IsEndTimeCustomed == true)
                {
                    this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * (i+1)) + 29);//+1 because of the CustomedLabel
                    RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);//hone mafi scroll
                }
                //Highlighting targetlabeltimeHighlight and scrolling into targetlabeltimeScroll
                else
                {
                    //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                    if (targetlabeltimeScroll == null)
                    {
                        targetlabeltimeScroll = ListLabelTime.Find(labeltime2 => labeltime2.Time == EndTime);
                    }

                    ScrollToSpecificUserControl(targetlabeltimeScroll);
                    RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);
                }
            }
            new TouchScroll(flowLayoutPanelContainerTime, this);//li2anno bas lendtime fiyo scroll
        }


        //EVENT
        public void flowLayoutPanelContainerTime_MouseEnter(object sender, EventArgs e)
        {
            //RandomFunctionSchedule.HighlightUserControl(null);
        }

        /// <summary>
        /// kello aam nhawlo aal textboxtime hatta men ha tabaee kabsit label ,houwe eza 3ando lformat w sakkar textbox li bel appointment byekhdo eza la2 ma byekhdo
        /// </summary>
        private async void DisplayTime_Deactivate(object sender, EventArgs e)
        {
            //StartTime
            if (Isstarttime)
            {
                //The Type of the text that we need is 7:00PM
                string pattern = @"^(1[012]|[1-9]):[0-5][0-9] (AM|PM)$";//7:00PM
                bool isMatch = Regex.IsMatch(textBoxTime.Text, pattern, RegexOptions.IgnoreCase);

                DateTime dateTime = DateTime.ParseExact(textBoxTime.Text, "h:mm tt", null);
                TimeSpan starttime = dateTime.TimeOfDay;

                //Checking the type of the text
                if (isMatch && starttime <= new TimeSpan(23, 45, 0))
                {
                    //Checking the condition between starttime and endtime
                    if (starttime <= EndTime)
                    {
                        DesiredAppointmentAppForm.StartTime = DesiredAppointmentAppForm.StartTime.Date + starttime;
                        AppointmentForm.textBoxStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");
                    }
                    else
                    {
                        TimeSpan endTime = starttime + AppointmentForm.DifferenceTime;
                        if (endTime > new TimeSpan(23, 45, 0))
                        {
                            endTime = new TimeSpan(23, 45, 0);
                        }

                        //Byekhoud Fared marra difference time watta tetghayar lendtime kermel hek shelna textchanged lal starttime
                        AppointmentForm.textBoxStartTime.TextChanged -= AppointmentForm.textBoxStartTime_TextChanged;

                        DesiredAppointmentAppForm.StartTime = DesiredAppointmentAppForm.StartTime.Date + starttime;
                        AppointmentForm.textBoxStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");

                        DesiredAppointmentAppForm.EndTime = DesiredAppointmentAppForm.EndTime.Date + endTime;
                        AppointmentForm.textBoxEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");

                        AppointmentForm.textBoxStartTime.TextChanged += AppointmentForm.textBoxStartTime_TextChanged;
                    }
                }
            }

            //EndTime
            else
            {
                string pattern = @"^(1[012]|[1-9]):[0-5][0-9] (AM|PM)$";//7:00PM
                bool isMatch = Regex.IsMatch(textBoxTime.Text, pattern, RegexOptions.IgnoreCase);

                DateTime dateTime = DateTime.ParseExact(textBoxTime.Text, "h:mm tt", null);
                TimeSpan endtime = dateTime.TimeOfDay;

                //Checking the type of the text
                if (isMatch && endtime <= new TimeSpan(23, 45, 0))
                {
                    //Checking the condition between starttime and endtime
                    if (endtime >= StartTime)
                    {
                        DesiredAppointmentAppForm.EndTime = DesiredAppointmentAppForm.EndTime.Date + endtime;
                        AppointmentForm.textBoxEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");
                    }
                    else
                    {
                        MessageBox.Show("endtime smaller then starttime");
                    }
                }

            }

            await Task.Delay(1); //kermel to activation lal form li tahta
            this.Close();
        }



        //FUNCTION
        private void ScrollToSpecificUserControl(LabelTime targetlabeltime)
        {
            if (targetlabeltime != null && flowLayoutPanelContainerTime.Controls.Contains(targetlabeltime))
            {
                flowLayoutPanelContainerTime.ScrollControlIntoView(targetlabeltime);
            }
        }


    }
}



///public CBdisplayTime(Appointment form1, string contains, bool boolean, UCMeetingInAppointment form2)
//{
//    isucclient = false;
//    ucmeeting = form2;
//    Isstarttime = boolean;
//    if (Isstarttime)//HSOB STARTTIME = 8:15 AM
//    {
//        InitializeComponent();

//        if (contains != "")
//        {
//            textBoxTime.Text = contains;
//        }
//        TimeSpan TimeStart = new TimeSpan(StartTime.Hours, 0, 0);//8:00 AM
//        TimeSpan[] displaytime = new TimeSpan[97];

//        displaytime[0] = TimeStart;
//        LabelTime labeltime = new LabelTime(displaytime[0], this, Isstarttime);
//        labeltime.Size = new Size(111, 24);
//        flowLayoutPanelContainerTime.Controls.Add(labeltime);

//        if (labeltime.Time == StartTime)//l2ina taba3 lhighlight
//        {
//            targetlabeltimeHighlight = labeltime;
//        }

//        int i = 1;
//        while (displaytime[i - 1] != EndTime && i != 4)//aala kel halet mamnou3 y2ati3 8:45 aw endtIME HONE HIYE BREAK
//        {
//            displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));
//            LabelTime labeltime1 = new LabelTime(displaytime[i], this, Isstarttime);
//            labeltime1.Size = new Size(111, 24);
//            flowLayoutPanelContainerTime.Controls.Add(labeltime1);
//            if (labeltime1.Time == StartTime)//l2ina taba3 lhighlight
//            {
//                targetlabeltimeHighlight = labeltime1;
//            }
//            i++;
//        }
//        this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * i) + 26);
//        RandomFunctionGK.HighlightUserControl(targetlabeltimeHighlight);

//    }


//    else
//    {
//        InitializeComponent();

//        if (contains != "")
//        {
//            textBoxTime.Text = contains;
//        }
//        TimeSpan[] displaytime = new TimeSpan[97];
//        displaytime[0] = StartTime;
//        LabelTime labeltime = new LabelTime(displaytime[0], this, Isstarttime);
//        if (StartTime >= new TimeSpan(23, 0, 0))
//        {
//            labeltime.Size = new Size(111, 24);
//            flowLayoutPanelContainerTime.Controls.Add(labeltime);
//            if (labeltime.Time == EndTime)//l2ina taba3 lhighlight
//            {
//                targetlabeltimeHighlight = labeltime;
//            }
//        }
//        else
//        {
//            flowLayoutPanelContainerTime.Controls.Add(labeltime);
//            if ((labeltime.Time.Subtract(new TimeSpan(0, 30, 0))) == EndTime)//l2ina taba3 lscroll
//            {
//                targetlabeltimeScroll = labeltime;
//            }
//            if (labeltime.Time == EndTime)//l2ina taba3 lhighlight
//            {
//                targetlabeltimeHighlight = labeltime;
//            }
//        }
//        int i = 1;
//        TimeSpan timeSpanBreak = new TimeSpan(23, 45, 0);//12:00 AM

//        while (displaytime[i - 1] != timeSpanBreak)
//        {
//            displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));
//            LabelTime labeltime1 = new LabelTime(displaytime[i], this, Isstarttime);
//            if (StartTime >= new TimeSpan(23, 0, 0))
//            {
//                labeltime1.Size = new Size(111, 24);
//                flowLayoutPanelContainerTime.Controls.Add(labeltime1);
//                if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
//                {
//                    targetlabeltimeHighlight = labeltime1;
//                }
//            }
//            else
//            {
//                flowLayoutPanelContainerTime.Controls.Add(labeltime1);
//                if ((labeltime1.Time.Subtract(new TimeSpan(0, 30, 0))) == EndTime)//l2ina taba3 lscroll
//                {
//                    targetlabeltimeScroll = labeltime1;
//                }
//                if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
//                {
//                    targetlabeltimeHighlight = labeltime1;
//                }
//            }
//            i++;
//        }
//        if (StartTime >= new TimeSpan(23, 0, 0))//aa aal hale mafi scroll ba2a
//        {
//            this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * i) + 26);
//            RandomFunctionGK.HighlightUserControl(targetlabeltimeHighlight);//hone mafi scroll
//        }
//        else
//        {
//            ScrollToSpecificUserControl(targetlabeltimeScroll);
//            RandomFunctionGK.HighlightUserControl(targetlabeltimeHighlight);
//        }
//        new TouchScroll(flowLayoutPanelContainerTime, this);
//    }
//}
