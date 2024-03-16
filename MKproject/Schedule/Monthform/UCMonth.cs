using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;


namespace MKproject.Schedule
{
    public partial class UCMonth : Form
    {
        //PROPERTIES:
        public DateTime DateUCMonth { get; set; }// kel shi get,te3dil ha2i2e mnstaeemil DateUCMonth

        //VARIABLES:
        DateTime date; int month, year, days; string monthname;//just copies
        public Schedule schedule; public UCDay ucday; public UCCalanderday uccalanderday; public UCCalandermonth uccalandermonth; public UCCalanderyear uccalanderyear;
        public UCDays ucdayOfDateUCDay; public UCDays ucdayOfToday; public LabelMonth labelmonthcopy; public LabelYear labelyearcopy;//for their borders

        public int wichuccalander;//1:uccalanderday  2:uccalandermonth  3:uccalanderyear
        public int NODifferenceYears = 11;
        bool isPickdays = false;


        //INITIALISE:
        ///-CONSTRUCTOR
        public UCMonth(Schedule form, UCDay form1)
        {
            InitializeComponent();
            schedule = form;
            ucday = form1;

            DateUCMonth = DateTime.Now;
            buttonTypeDateChange.Text = "Month";

            uccalanderday = new UCCalanderday(schedule, this, ucday);
            uccalandermonth = new UCCalandermonth(this);
            uccalanderyear = new UCCalanderyear(this);

            uccalanderday.Dock = DockStyle.Fill;
            uccalanderday.Margin = new Padding(0, 0, 20, 20);//(left, top, right, bottom)
            uccalandermonth.Dock = DockStyle.Fill;
            uccalandermonth.Margin = new Padding(0, 0, 20, 20);//(left, top, right, bottom)
            uccalanderyear.Dock = DockStyle.Fill;
            uccalanderyear.Margin = new Padding(0, 0, 20, 20);//(left, top, right, bottom)

            wichuccalander = 1;
            tableLayoutPanelMonth.Controls.Add(uccalanderday, 0, 1);
            EditLabelUCdays();
        }//moujarad ma eftah lschedule



        //EVENTS:
        private void buttonNext_Click_1(object sender, EventArgs e)
        {
            //manna nshouf bi aya uc nehna kermel nshouf shou manna n3adil
            if (wichuccalander == 1)
            {
                if (DateUCMonth.Month != 12)//hone baeed ma eemil next year ella eza sar december sar fi year++
                {
                    DateUCMonth = new DateTime(DateUCMonth.Year, DateUCMonth.Month + 1, 1);
                    EditLabelUCdays();//aa hal kabse bi koun akid deja eemlo display
                }
                else
                {
                    DateUCMonth = new DateTime(DateUCMonth.Year + 1, 1, 1);
                    EditLabelUCdays();//aa hal kabse bi koun akid deja eemlo display

                }
            }
            else if (wichuccalander == 2)
            {
                DateUCMonth = new DateTime(DateUCMonth.Year + 1, 1, 1);
                labelTitle.Text = DateUCMonth.Year.ToString();
                HighlightSelectedMonth();
            }
            else
            {
                DateUCMonth = new DateTime(DateUCMonth.Year + 12, 1, 1);
                labelTitle.Text = DateUCMonth.Year + "-" + (DateUCMonth.Year + NODifferenceYears);
                HighlightNDisplaySelectedYear();
            }
        }
        private void buttonPrevious_Click_1(object sender, EventArgs e)
        {
            if (wichuccalander == 1)
            {
                if (DateUCMonth.Month != 1)//metel taba3 next same concept
                {
                    DateUCMonth = new DateTime(DateUCMonth.Year, DateUCMonth.Month - 1, 1);
                    EditLabelUCdays();//aa hal kabse bi koun akid deja eemlo display

                }
                else
                {
                    DateUCMonth = new DateTime(DateUCMonth.Year - 1, 12, 1);
                    EditLabelUCdays();//aa hal kabse bi koun akid deja eemlo display

                }
            }
            else if (wichuccalander == 2)
            {
                DateUCMonth = new DateTime(DateUCMonth.Year - 1, 1, 1);
                labelTitle.Text = DateUCMonth.Year.ToString();
                HighlightSelectedMonth();
            }
            else
            {
                DateUCMonth = new DateTime(DateUCMonth.Year - 12, 1, 1);
                labelTitle.Text = DateUCMonth.Year + "-" + (DateUCMonth.Year + NODifferenceYears);

                HighlightNDisplaySelectedYear();
            }

        }
        private void buttonTypeDateChange_Click(object sender, EventArgs e)
        {
            if (wichuccalander == 1)
            {
                wichuccalander = 2;
                buttonTypeDateChange.Text = "Year";
                tableLayoutPanelMonth.Controls.Remove(uccalanderday);
                tableLayoutPanelMonth.Controls.Add(uccalandermonth, 0, 1);
                labelTitle.Text = DateUCMonth.Year.ToString();
                HighlightSelectedMonth();

            }
            else if (wichuccalander == 2)
            {
                wichuccalander = 3;
                buttonTypeDateChange.Hide();
                tableLayoutPanelMonth.Controls.Remove(uccalandermonth);
                tableLayoutPanelMonth.Controls.Add(uccalanderyear, 0, 1);
                labelTitle.Text = DateUCMonth.Year + "-" + (DateUCMonth.Year + NODifferenceYears);
                HighlightNDisplaySelectedYear();
            }
        }
        private void UCMonth_Deactivate(object sender, EventArgs e)
        {
            //Just to setUp the ucmonth again when I deactivate it and we will to set it on UCCalanderday
            this.Hide();

            buttonTypeDateChange.Show();

            DateUCMonth = ucday.DateUCDay;

            
        }


        //FUNCTION:
        public void EditLabelUCdays()
        {
            //part 1
            date = DateUCMonth;//copy
            year = DateUCMonth.Year;//copy
            month = DateUCMonth.Month;//copy

            //part 2
            monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labelTitle.Text = monthname + " " + year;
            //part 4
            UCDays[] ucdaysArray = uccalanderday.tableLayoutPanel1.Controls.OfType<UCDays>().ToArray();// jebna indez taba3 42 ucdays,exenple ucdaysArray[0] houwe awa ucdays
            DateTime previousMonth = date.AddMonths(-1);
            DateTime nextMonth = date.AddMonths(+1);
            DateTime startofthemonth = new DateTime(year, month, 1);
            days = DateTime.DaysInMonth(year, month);
            int daysprevious;
            if (month == 1)//1-1=0 or mafi hayda lmonth
            {
                daysprevious = DateTime.DaysInMonth((year - 1), 12);

            }
            else
            {
                daysprevious = DateTime.DaysInMonth(year, (month - 1));
            }
            int firstdayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));
            int daypreviousI;
            int daysnext;
            if (firstdayoftheweek != 0)// hone lfare2 1 baynetoun
            {
                firstdayoftheweek -= 1;//exemple lmonday ken 1 (old) sar 0 (new)
                daypreviousI = daysprevious - firstdayoftheweek + 1;//li2anno bel dayoftheweek men ballish 0 kermel hek +1
                daysnext = 42 - days - firstdayoftheweek;
                int j = 0;//kermel index taba3 ucdaysArray
                for (int i = daypreviousI; i <= daysprevious; i++) //li2anno awal nhar bi ballish aa sunday msh monday
                {
                    ucdaysArray[j].DateUCdays = new DateTime(previousMonth.Year, previousMonth.Month, i);
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.Silver;
                    j++;//kel ma yen3amal edit la ucdays mnente2il la tenye
                }


                for (int i = 1; i <= days; i++)
                {
                    ucdaysArray[j].DateUCdays = new DateTime(year, month, i);
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.FromArgb(119, 132, 234);
                    j++;
                }

                for (int i = 1; i <= daysnext; i++)
                {
                    ucdaysArray[j].DateUCdays = new DateTime(nextMonth.Year, nextMonth.Month, i);
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.Silver;
                    j++;
                }

            }
            else//hone seeta bel nesbe lal new lezim ykoun 6
            {
                firstdayoftheweek = 6;// lsunday ken 0 (old) sar 6 (new)
                daypreviousI = daysprevious - firstdayoftheweek + 1;//li2anno bel dayoftheweek men ballish 0 kermel hek +1
                daysnext = 42 - days - firstdayoftheweek;
                int j = 0;
                for (int i = daypreviousI; i <= daysprevious; i++)
                {
                    ucdaysArray[j].DateUCdays = new DateTime(previousMonth.Year, previousMonth.Month, i);
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.Silver;
                    j++;
                }


                for (int i = 1; i <= days; i++)
                {
                    ucdaysArray[j].DateUCdays = new DateTime(year, month, i);
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.FromArgb(119, 132, 234);
                    j++;

                }

                for (int i = 1; i <= daysnext; i++)
                {
                    ucdaysArray[j].DateUCdays = new DateTime(nextMonth.Year, nextMonth.Month, i);
                    ucdaysArray[j].DateUCdays = nextMonth;
                    ucdaysArray[j].labelDay.Text = Convert.ToString(i);
                    ucdaysArray[j].labelDay.ForeColor = Color.Silver;
                    j++;
                }
            }
            PickUC();
        }//we displayed the ucdays now we just have to edit them
        public void PickUC()
        {
            bool ucdayOfDateUCDayexist = false;
            bool ucdayOfTodayexist = false;

            foreach (UCDays u in uccalanderday.tableLayoutPanel1.Controls.OfType<UCDays>())
            {
                //Hayda lucday eza zabat w akhad today w se2abit 3endo kamen DateUCDay byekoud today bass
                if (u.DateUCdays.Date == DateTime.Now.Date)
                {
                    u.labelDay.BackColor = Color.FromArgb(196, 210, 245); //sdawa luc li na2ayne
                    ucdayOfToday = u;//hala2 eza eemelna shi aal ucdaycopy ha yet2asar kamen u, exemple: disactivatebordercolor
                    ucdayOfTodayexist = true;
                }

                else if (u.DateUCdays.Date == ucday.DateUCDay.Date)
                {
                    u.labelDay.BackColor = Color.FromArgb(229, 226, 244); //sdawa luc li na2ayne
                    ucdayOfDateUCDay = u;//hala2 eza eemelna shi aal ucdaycopy ha yet2asar kamen u, exemple: disactivatebordercolor
                    ucdayOfDateUCDayexist = true;
                }
                else
                {
                    u.labelDay.BackColor = Color.White;
                }
            }
            if(ucdayOfDateUCDayexist == false)
            {
                ucdayOfDateUCDay = null;
            }
            if(ucdayOfTodayexist == false)
            {
                ucdayOfToday = null;
            }
        }//to pick the ucdays by it's date
        public void HighlightSelectedMonth()
        {
            bool labelmonthcopyexist = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = uccalandermonth.tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelMonth m)
                    {
                        if (m.Month == ucday.DateUCDay.Month &&  DateUCMonth.Year == ucday.DateUCDay.Year)
                        {
                            m.BackColor = Color.FromArgb(229, 226, 244); //sdawa luc li na2ayne
                            labelmonthcopy = m;
                            labelmonthcopyexist = true;
                        }
                        else
                        {
                            m.BackColor = Color.White;
                        }
                    }
                   
                }
            }
            if(labelmonthcopyexist == false)
            {
                labelmonthcopy = null;
            }

        }//for uccalandermonth and to pick the LabelMonth by it's month
        private void HighlightNDisplaySelectedYear()
        {
            bool labelyearcopyexist = false;
            int yearint = DateUCMonth.Year;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = uccalanderyear.tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelYear y)
                    {
                        y.Year = yearint;//display
                        yearint++;
                        if (y.Year == ucday.DateUCDay.Year)
                        {
                            y.BackColor = Color.FromArgb(229, 226, 244); //sdawa luc li na2ayne
                            labelyearcopy = y;
                            labelyearcopyexist = true;
                        }
                        else
                        {
                            y.BackColor = Color.White;
                        }
                    }
                }
            }
            if( labelyearcopyexist == false)
            {
                labelyearcopy = null;
            }
        }//for uccalanderyear and edit labelyear.year and to pick the LabelYear by it's year



    }
}


///Today Click Algorithm for month
//private void buttonToday_Click(object sender, EventArgs e)
//{

//    if (wichuccalander == 1)
//    {
//        if (DateTime.Now.Month != DateUCMonth.Month || DateTime.Now.Year != DateUCMonth.Year)
//        {
//            DateUCMonth = DateTime.Now;
//            EditLabelUCdays();//aa hal kabse bi koun akid deja eemlo display
//        }
//        else
//        {
//            DateUCMonth = DateTime.Now;
//            PickUC();
//        }
//    }
//    else if (wichuccalander == 2)
//    {
//        DateUCMonth = DateTime.Now;
//        labelTitle.Text = DateUCMonth.Year.ToString();
//        HighlightSelectedMonth();
//    }
//    else// == 3
//    {
//        DateUCMonth = DateTime.Now;
//        labelTitle.Text = DateUCMonth.Year + "-" + (DateUCMonth.Year + NODifferenceYears);
//        HighlightNDisplaySelectedYear();
//    }

//}



///LOAD But just work when there's borders and we can just close it without disactivating
//private void UCMonth_Load(object sender, EventArgs e)
//{
//    if (wichuccalander == 2)
//    {
//        wichuccalander = 1;
//        tableLayoutPanelMonth.Controls.Remove(uccalandermonth);
//        tableLayoutPanelMonth.Controls.Add(uccalanderday, 0, 1);
//    }
//    else if (wichuccalander == 3)
//    {
//        wichuccalander = 1;
//        tableLayoutPanelMonth.Controls.Remove(uccalanderyear);
//        tableLayoutPanelMonth.Controls.Add(uccalanderday, 0, 1);
//    }
//    EditUCMonth();//every time we open it, it will edit the labels if necessary.
//}//kel ma eftah ucmonth w sakro erjaee eftaho

//public void EditUCMonth()
//{
//    //change DateUCMonth
//    if (DateUCMonth.Date != ucday.DateUCDay.Date)
//    {
//        DateUCMonth = ucday.DateUCDay;
//        EditLabelUCdays();
//    }
//    else//selecting a case in ucmonth
//    {
//        PickUC();
//    }

//}//changing DateUCMonth



///PickUCDay Old Algorythim If I want to keep one of the ucdays colored based on the Dateucmonth
//public void PickUC()
//{
//    foreach (UCDays u in uccalanderday.tableLayoutPanel1.Controls.OfType<UCDays>())
//    {
//        if (u.DateUCdays.Date == DateUCMonth.Date)
//        {
//            u.labelDay.BackColor = Color.FromArgb(229, 226, 244); //sdawa luc li na2ayne

//            if (ucdaycopy == null)//mafi hada ghayro mdawa ma daroure na3moul disactivate la hada
//            {
//                ucdaycopy = u;//hala2 eza eemelna shi aal ucdaycopy ha yet2asar kamen u, exemple: disactivatebordercolor
//            }
//            else if (ucdaycopy == u)//houwe zeto medawa
//            {

//            }
//            else//eza ken fi hada mdawa tene
//            {
//                ucdaycopy.labelDay.BackColor = Color.White;//ucdaycopy byeene ghayro li ken mdawa w hay battil ysir mdawa
//                ucdaycopy = u;
//            }

//        }
//    }
//}//to pick the ucdays by it's date





///
//foreach (UCDays u in uccalanderday.tableLayoutPanel1.Controls.OfType<UCDays>())
//{
//    if (u.DateUCdays.Date == DateUCMonth.Date)
//    {
//        u.labelDay.BackColor = Color.FromArgb(229, 226, 244); //sdawa luc li na2ayne

//        if (ucdaycopy == null)//mafi hada ghayro mdawa ma daroure na3moul disactivate la hada
//        {
//            ucdaycopy = u;//hala2 eza eemelna shi aal ucdaycopy ha yet2asar kamen u, exemple: disactivatebordercolor
//        }
//        else if (ucdaycopy == u)//houwe zeto medawa
//        {

//        }
//        else//eza ken fi hada mdawa tene
//        {
//            ucdaycopy.labelDay.BackColor = Color.White;//ucdaycopy byeene ghayro li ken mdawa w hay battil ysir mdawa
//            ucdaycopy = u;
//        }

//    }
//}