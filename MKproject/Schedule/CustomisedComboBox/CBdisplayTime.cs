using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;



namespace MKproject.Schedule
{
    public partial class CBdisplayTime : Form
    {
        //VARIABLES
        bool isucclient;
        bool Isstarttime;

        ClassAppointment DesiredAppointment;
        TextBox TextBoxTimeClicked;

        LabelTime targetlabeltimeScroll;//this is for the scroll and for the endtime it's also the highlight
        LabelTime targetlabeltimeHighlight;//this the highlight for the starttime

        TimeSpan StartTime;
        TimeSpan EndTime;

        //INITIALISE
        public CBdisplayTime()
        {
            InitializeComponent();

        }
        public CBdisplayTime(string timetext, bool isstarttime, ClassAppointment desiredAppointment, TextBox textboxtimeclicked)
        {
            //Initialise
            isucclient = true;
            Isstarttime = isstarttime;
            StartTime = desiredAppointment.StartTime.TimeOfDay;
            EndTime = desiredAppointment.EndTime.TimeOfDay;
            TextBoxTimeClicked = textboxtimeclicked;
            DesiredAppointment = desiredAppointment;
            InitializeComponent();


            //StartTime
            if (Isstarttime)//HSOB STARTTIME = 8:15 AM
            {
                //Getting the labels
                if (timetext != "")
                {
                    textBoxTime.Text = timetext;
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
                if (EndTime <= new TimeSpan(0, 45, 0))
                {
                    labeltime.Size = new Size(111, 24);
                    flowLayoutPanelContainerTime.Controls.Add(labeltime);
                    if (labeltime.Time == EndTime)//l2ina taba3 lhighlight
                    {
                        targetlabeltimeHighlight = labeltime;
                    }
                }
                else
                {
                    flowLayoutPanelContainerTime.Controls.Add(labeltime);
                    if (labeltime.Time.Subtract(new TimeSpan(0, 30, 0)) == StartTime)//l2ina taba3 lscroll
                    {
                        targetlabeltimeScroll = labeltime;
                    }
                    if (labeltime.Time == StartTime)//l2ina taba3 lhighlight
                    {
                        targetlabeltimeHighlight = labeltime;
                    }
                }

                //getting the others
                int i = 1;
                while (displaytime[i - 1] != EndTime)//aala kel halet mamnou3 y2ati3 8:45 aw endtIME HONE HIYE BREAK
                {
                    displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));
                    LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                    ListLabelTime.Add(labeltime1);

                    //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the first label
                    if (EndTime <= new TimeSpan(0, 45, 0))
                    {
                        labeltime1.Size = new Size(111, 24);
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);
                        if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
                        {
                            targetlabeltimeHighlight = labeltime1;
                        }
                    }
                    else
                    {
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);
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

                //if there's no scroll, we just Highlighting targetlabeltimeHighlight
                if (EndTime <= new TimeSpan(0, 45, 0))//aa aal hale mafi scroll ba2a
                {
                    this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * i) + 26);
                    RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);//hone mafi scroll
                }

                //Highlighting targetlabeltimeHighlight and scrolling into targetlabeltimeScroll
                else
                {
                    //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                    if (targetlabeltimeScroll == null)
                    {
                        targetlabeltimeScroll = ListLabelTime.Find(labeltime2 => labeltime2.Time == StartTime);
                    }
                    ScrollToSpecificUserControl(targetlabeltimeScroll);
                    RandomFunctionSchedule.HighlightUserControl(targetlabeltimeHighlight);
                }


            }

            //EndTime
            else
            {
                if (timetext != "")
                {
                    textBoxTime.Text = timetext;
                }

                //Kermel a3mil scroll into a label eza ma 2ederna na3mil scroll aal li baeedo bi 30 min
                List<LabelTime> ListLabelTime = new List<LabelTime>();


                TimeSpan[] displaytime = new TimeSpan[97];
                displaytime[0] = StartTime;
                LabelTime labeltime = new LabelTime(displaytime[0], this);
                ListLabelTime.Add(labeltime);

                //Getting targetlabeltimeHighlight and targetlabeltimeScroll to doing it for the first label
                if (StartTime >= new TimeSpan(23, 0, 0))
                {
                    labeltime.Size = new Size(111, 24);
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


                //Adding The Other labels
                int i = 1;
                TimeSpan timeSpanBreak = new TimeSpan(23, 45, 0);//12:00 AM

                while (displaytime[i - 1] != timeSpanBreak)
                {
                    displaytime[i] = displaytime[i - 1].Add(new TimeSpan(0, 15, 0));
                    LabelTime labeltime1 = new LabelTime(displaytime[i], this);
                    ListLabelTime.Add(labeltime1);

                    //Getting targetlabeltimeHighlight and targetlabeltimeScroll
                    //there's no scroll
                    if (StartTime >= new TimeSpan(23, 0, 0))
                    {
                        labeltime1.Size = new Size(111, 24);
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);
                        if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
                        {
                            targetlabeltimeHighlight = labeltime1;
                        }
                    }
                    //there's scroll
                    else
                    {
                        flowLayoutPanelContainerTime.Controls.Add(labeltime1);
                        //scrolling into the label that's before the label who has the time by 30 min
                        if (labeltime1.Time.Subtract(new TimeSpan(0, 30, 0)) == EndTime)//l2ina taba3 lscroll
                        {
                            targetlabeltimeScroll = labeltime1;
                        }
                        //Getting the label time who has the time
                        if (labeltime1.Time == EndTime)//l2ina taba3 lhighlight
                        {
                            targetlabeltimeHighlight = labeltime1;
                        }
                    }


                    i++;
                }

                //if there's no scroll, we just Highlighting targetlabeltimeHighlight
                if (StartTime >= new TimeSpan(23, 0, 0))//aa aal hale mafi scroll ba2a
                {
                    this.Size = new Size(this.Size.Width, ((labeltime.Size.Height) * i) + 26);
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
            RandomFunctionSchedule.HighlightUserControl(null);
        }

        /// <summary>
        /// kello aam nhawlo aal textboxtime hatta men ha tabaee kabsit label ,houwe eza 3ando lformat w sakkar textbox li bel appointment byekhdo eza la2 ma byekhdo
        /// </summary>
        private void DisplayTime_Deactivate(object sender, EventArgs e)
        {
            //StartTime
            if (Isstarttime)
            {
                //The Type of the text that we need is 7:00PM
                string pattern = @"^(1[012]|[1-9]):[0-5][0-9] (AM|PM)$";//7:00PM
                bool isMatch = Regex.IsMatch(textBoxTime.Text, pattern, RegexOptions.IgnoreCase);

                //Checking the type of the text
                if (isMatch)
                {
                    DateTime dateTime = DateTime.ParseExact(textBoxTime.Text, "h:mm tt", null);
                    TimeSpan starttime = dateTime.TimeOfDay;

                    //Checking the condition between starttime and endtime
                    if (starttime <= EndTime)
                    {
                        DesiredAppointment.StartTime = DesiredAppointment.StartTime.Date + starttime;
                        TextBoxTimeClicked.Text = DesiredAppointment.StartTime.ToString("h:mm tt");
                    }
                    else
                    {
                        MessageBox.Show("start time bigger then endtime");
                    }
                }
            }

            //EndTime
            else
            {
                string pattern = @"^(1[012]|[1-9]):[0-5][0-9] (AM|PM)$";//7:00PM
                bool isMatch = Regex.IsMatch(textBoxTime.Text, pattern, RegexOptions.IgnoreCase);

                //Checking the type of the text
                if (isMatch)
                {
                    DateTime dateTime = DateTime.ParseExact(textBoxTime.Text, "h:mm tt", null);
                    TimeSpan endtime = dateTime.TimeOfDay;

                    //Checking the condition between starttime and endtime
                    if (endtime >= StartTime)
                    {
                        DesiredAppointment.EndTime = DesiredAppointment.EndTime.Date + endtime;
                        TextBoxTimeClicked.Text = DesiredAppointment.EndTime.ToString("h:mm tt");
                    }
                    else
                    {
                        MessageBox.Show("endtime smaller then starttime");
                    }
                }

            }


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
