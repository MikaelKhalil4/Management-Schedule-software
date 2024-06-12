using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class ClassEmployeeFront
    {
        //schedule design,front end, in order to use those ejbare the tablelayoutpannel ykuno eendun eaxh row = 15 min
        static public TimeSpan GetTimeFromRow(int row, bool IsEndTIme, TableLayoutPanel DesiredTLP)
        {
            if (IsEndTIme)
            {
                row++;
                //only use lama nekhud el availabilty tb3 el customer, lieanno while drag and drop , fin gher approach kermel nhafiz aal duration : GetEndTimeAfterDragDrop
                //why row++, tkheyal hattet from rows: 0:3 => 00:00 to 00:45(lieanno the code the relative to the startime)
                //roww ++ => 0:4 => 00:00 to 01:00
            }

            int TotalHour = 24;
            int TotalRow = DesiredTLP.RowCount;

            int hours = (row * TotalHour) / TotalRow;

            int remainderRows = row % (TotalRow / TotalHour);
            int minutes = remainderRows * 15;


            TimeSpan result = new TimeSpan(hours, minutes, 0);
            if (hours == 24 && minutes == 0) // Check if the result is exactly 12:00 AM and adjust to 11:59 PM if needed
            {
                result = new TimeSpan(23, 59, 0);
            }

            return result;
        }
        static public int GetRowFromTime(TimeSpan Time, bool IsEndTime, TableLayoutPanel DesiredTLP)
        {
            int TotalHour = 24;
            int TotalRow = DesiredTLP.RowCount;

            int PositionRow = (Time.Hours * TotalRow) / TotalHour;

            //1 Row -> 15 min
            int j = 0;
            for (int i = 0; i <= 45; i += 15)
            {
                if (i <= Time.Minutes && Time.Minutes < (i + 15))
                {
                    PositionRow += j;
                    break;
                }
                j++;
            }

            if (IsEndTime)
            {
                // Adjust for end time
                if (Time.Minutes % 15 == 0 && (Time.Hours != 0 || Time.Minutes != 0))//scd condition eza kenit diff then 00:00
                {
                    PositionRow -= 1;//yaane eza kenit 9:00 ma bet reddele el row tb3 el start time 68 lets say, bet red 67
                }
            }

            return PositionRow;
        }
        static public List<List<int>> GetRowsAvailabilityForTheWholeWeek(string Availability, TableLayoutPanel DesiredTLP)//it will return a list of rows for the entire week,ordered from Monday to sunday
        {
            List<List<int>> dailyRowsAvailability = new List<List<int>> { };
            List<List<TimeSpan>> AllWeekAvailability = GetTimeSpanAvailabiltyofWeek(Availability);
            foreach (List<TimeSpan> DesiredDayAv in AllWeekAvailability)
            {
                List<int> desiredRows = new List<int>();
                foreach (TimeSpan desiredTime in DesiredDayAv)
                {
                    desiredRows.Add(GetRowFromTime(desiredTime, false, DesiredTLP));
                }
                dailyRowsAvailability.Add(desiredRows);
            }
            return dailyRowsAvailability;
        }
        static public List<int> GetRowsAvailabilityofDesiredDay(string Availability, TableLayoutPanel DesiredTLP)//it will return a list of rows OF DESIREDAY
        {
            List<TimeSpan> AllDayAvailability = GetTimeSpanAvailabiltyOfDesiredDay(Availability);
            List<int> desiredRows = new List<int>();
            foreach (TimeSpan desiredTime in AllDayAvailability)
            {
                desiredRows.Add(GetRowFromTime(desiredTime, false, DesiredTLP));
            }
            return desiredRows;
        }


        static public String GetAvailabiltyAsAstringFromWeekAvailability(DateTime Date, string WeekAvaialabilty)
        {
            int dayOfWeekInt = ((int)Date.DayOfWeek + 6) % 7;//lieanno to take into considartion monday the first day: Monday:0 => sunday:6
            string[] HoursOfThedays = WeekAvaialabilty.Split('/');
            return HoursOfThedays[dayOfWeekInt];
        }
        static public List<List<TimeSpan>> GetTimeSpanAvailabiltyofWeek(string availabiltyOfEntireWeek)
        {
            List<List<TimeSpan>> weeklyAvailability = new List<List<TimeSpan>>();


            string[] days = availabiltyOfEntireWeek.Split('/');

            foreach (var day in days)
            {
                List<TimeSpan> dayAvailability = new List<TimeSpan>();


                string[] intervals = day.Split('-');
                foreach (var interval in intervals)
                {
                    if (!string.IsNullOrEmpty(interval))
                    {
                        dayAvailability.Add(TimeSpan.Parse(interval));
                    }
                }

                weeklyAvailability.Add(dayAvailability);
            }

            return weeklyAvailability;
        }
        static public List<TimeSpan> GetTimeSpanAvailabiltyOfDesiredDay(string DesiredDayAvailabality)
        {

            List<TimeSpan> dayAvailability = new List<TimeSpan>();

            if (!string.IsNullOrEmpty(DesiredDayAvailabality))
            {
                string[] intervals = DesiredDayAvailabality.Split('-');
                foreach (var interval in intervals)
                {
                    if (!string.IsNullOrEmpty(interval))
                    {
                        dayAvailability.Add(TimeSpan.Parse(interval));
                    }
                }
            }


            return dayAvailability;
        }
    }
}
