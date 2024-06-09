using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace GlobalFunctions
{
    public class RandomFunctions
    {




        public static string ExtractDigits(string input)
        {
            string pattern = @"\D"; // Matches any non-digit character
            string digitsOnly = Regex.Replace(input, pattern, ""); // Removes all non-digit characters
            return digitsOnly;
        }
        public static int AgeCalculator(DateTime Birthdate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - Birthdate.Year;

            if (currentDate.Month < Birthdate.Month || (currentDate.Month == Birthdate.Month && currentDate.Day <= Birthdate.Day))
            {
                age--;
            }

            return age;
        }
        public static bool CheckIfContainsOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }



        public static string SetStringFullFormat(string input)
        {
            if (input != null)
            {
                input = input.Replace("[", "(")
                             .Replace("]", ")")
                             .Replace("/", Environment.NewLine)
                             .Replace(":", ": ")
                             .Replace("|", ",");

                if (input.EndsWith("/\r\n"))
                    input = input.Substring(0, input.Length - 2);



            }
            return input;
        }
        public static string SetStringFormatSpaceInsteadOflash(string input)
        {
            if (input != null)
            {
                input = input.Replace("/", " ");
            }
            return input;
        }


        //ased string to handle NULLVALUES
        public static string SetDateFormat(string DeisredDate)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Now;
            string Lastvisit;

            if (DeisredDate != DBNull.Value.ToString())
            {
                DateTime check_in = Convert.ToDateTime(DeisredDate);
                if (check_in.Day == today.Day && check_in.Month == today.Month && check_in.Year == today.Year)
                {
                    Lastvisit = "Today" + ", " + check_in.ToString("h:mm tt");
                }
                else if (check_in.Day == yesterday.Day && check_in.Month == yesterday.Month && check_in.Year == yesterday.Year)
                {
                    Lastvisit = "Yesterday" + ", " + check_in.ToString("h:mm tt");
                }
                else Lastvisit = check_in.ToString("MMMM, dd yyyy");
            }
            else
            {
                Lastvisit = null;
            }
            return Lastvisit;
        }
        public static string SetDateFormatWithDayWithoutHour(string DesiredDate)
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            DateTime today = DateTime.Now;
            string Lastvisit;

            if (DesiredDate != DBNull.Value.ToString())
            {
                DateTime check_in = Convert.ToDateTime(DesiredDate);
                if (check_in.Day == today.Day && check_in.Month == today.Month && check_in.Year == today.Year)
                {
                    Lastvisit = "Today";
                }
                else if (check_in.Day == tomorrow.Day && check_in.Month == tomorrow.Month && check_in.Year == tomorrow.Year)
                {
                    Lastvisit = "Tomorrow";
                }
                else Lastvisit = check_in.ToString("dddd, MMMM dd yyyy");
            }
            else
            {
                Lastvisit = null;
            }
            return Lastvisit;

        }
        public static string SetDateFormatWithoutHour(string DesiredDate)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Now;
            string Lastvisit;

            if (DesiredDate != DBNull.Value.ToString())
            {
                DateTime check_in = Convert.ToDateTime(DesiredDate);
                if (check_in.Day == today.Day && check_in.Month == today.Month && check_in.Year == today.Year)
                {
                    Lastvisit = "Today";
                }
                else if (check_in.Day == yesterday.Day && check_in.Month == yesterday.Month && check_in.Year == yesterday.Year)
                {
                    Lastvisit = "Yesterday";
                }
                else Lastvisit = check_in.ToString("MMMM,dd yyyy");
            }
            else
            {
                Lastvisit = null;
            }
            return Lastvisit;

        }

        public static int GetDaysDifference(DateTime startDate, DateTime endDate)
        {
            DateTime startDateOnly = startDate.Date;
            DateTime endDateOnly = endDate.Date;

            TimeSpan timeSpan = endDateOnly - startDateOnly;
            return timeSpan.Days;
        }




        public static void SetWidth(UserControl MainUserControl, Control DesiredControl, Label labelTitle)
        {
            int maxWidth = 0;

            int itemWidth = TextRenderer.MeasureText(DesiredControl.Text, DesiredControl.Font).Width;
            maxWidth = Math.Max(maxWidth, itemWidth);

            int labelwidth = TextRenderer.MeasureText(labelTitle.Text, labelTitle.Font).Width;

            if (labelwidth < maxWidth)
                MainUserControl.Width = maxWidth + SystemInformation.VerticalScrollBarWidth + 5;
            else
                MainUserControl.Width = labelwidth + SystemInformation.VerticalScrollBarWidth + 5;
        }


        /// <summary>
        /// what's likely happening is that the MeasureText method is determining
        /// that "Any String" doesn't fit within the given width  without wrapping,
        ///so it wraps the text to the next line, leading to a reduced width measurement
        /// and a heightened height measurement.     
        public static int CalculateDesiredHeight(Control DesiredControl, int ControlWidth)
        {
          
            int desiredHeight;
            using (Graphics g = DesiredControl.CreateGraphics())
            {
                ControlWidth -= 4;
                SizeF textSize = g.MeasureString(DesiredControl.Text, DesiredControl.Font, ControlWidth <= 0 ? 1 : ControlWidth);//-12 kermel el spaces aa shmel w el yamin
                desiredHeight = (int)Math.Ceiling(textSize.Height) + DesiredControl.Padding.Top + DesiredControl.Padding.Bottom;
            }
            return desiredHeight;
        }
        public static int CalculateDesiredWidth(Control desiredControl, int controlHeight)
        {
            using (Graphics g = desiredControl.CreateGraphics())
            {
                string[] words = desiredControl.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int longestWordWidth = 0;
                foreach (var word in words)
                {
                    int wordWidth = (int)g.MeasureString(word, desiredControl.Font).Width;
                    if (wordWidth > longestWordWidth)
                    {
                        longestWordWidth = wordWidth; // Find the longest word
                    }
                }

                // Encourage wrapping by starting with a width just enough for the longest word
                int minWidth = longestWordWidth + 10; // Adding a small buffer
                int maxWidth = (int)g.MeasureString(desiredControl.Text, desiredControl.Font).Width; // Max width to fit all text in one line
                int bestFitWidth = maxWidth;

                while (minWidth <= maxWidth)
                {
                    int testWidth = (minWidth + maxWidth) / 2;
                    Size proposedSize = new Size(testWidth, int.MaxValue);
                    Size textSize = TextRenderer.MeasureText(g, desiredControl.Text, desiredControl.Font, proposedSize, TextFormatFlags.WordBreak);

                    int linesNeeded = textSize.Height / (TextRenderer.MeasureText(g, "Wg", desiredControl.Font, proposedSize, TextFormatFlags.SingleLine).Height);

                    if (linesNeeded == 2 && textSize.Height <= controlHeight)
                    {
                        bestFitWidth = testWidth; // This width fits the text within exactly two lines
                        maxWidth = testWidth - 1; // Adjust to find the narrowest width that fits this criteria
                    }
                    else if (linesNeeded > 2 || textSize.Height > controlHeight)
                    {
                        minWidth = testWidth + 1; // Increase width to reduce the number of lines
                    }
                    else
                    {
                        maxWidth = testWidth - 1; // Decrease width to promote wrapping
                    }
                }

                return bestFitWidth+3;
            }
        }



        public static void FixedFont(Control DesiredControl, FontStyle? fontStyle)//this function is made to the text fit a fix width label by changing it s font
        {
            int Constant = 2;
            int DesiredLabelHeight = RandomFunctions.CalculateDesiredHeight(DesiredControl, DesiredControl.Width - Constant);
            while (DesiredLabelHeight > DesiredControl.Height)//men dall nzaghir el font ta tse3 bel label
            {
                float newSize = DesiredControl.Font.Size - 1;
                if (fontStyle != null)
                {
                    DesiredControl.Font = new Font(DesiredControl.Font.FontFamily, newSize, (FontStyle)fontStyle);//most of the case lamma tkun bold

                }
                else
                {
                    DesiredControl.Font = new Font(DesiredControl.Font.FontFamily, newSize);
                }
                DesiredLabelHeight = RandomFunctions.CalculateDesiredHeight(DesiredControl, DesiredControl.Width - Constant);
            }

        }

        public static float MeasureLabelText(Label label)
        {
            using (Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font);
                return size.Width;
            }
        }


        public static bool IsInternetConnected()
        {
            try
            {
                //fi meshkle layering baddak tzabeta
                //if (Features.IsOnline)
                //{
                //    InternetTest();

                //}
                return true;//cz if  it's offline or online w ma sar fi exceptoion so it s true             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);//in case no connection
            }

        }
        public static void InternetTest()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com", 5000);
                    if (result.Status != IPStatus.Success)
                    {
                        throw new Exception("No internet connection. Please check your network.");//in case la2oit el pc internet bas mesh meshye
                    }
                }
            }
            catch
            {

                throw new Exception("No internet connection. Please check your network.");//in case sar fi crach bel ping, w ma nbaat el mssg, yane eza maken el device connected men el asel
            }
        }


    }

    //related lal enum
    public class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }

    public static class EnumExtensions//this class exists in mkproject.classes
                                      //wen maken lamma aayit la GetStringValue exp:myEnumValue.GetStringValue()/deghre hayda el class huwwe extention la kell enum in  this class,
                                      //yaane all enums eendun acces aale
    {
        public static string GetStringValue(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            var attribute = (StringValueAttribute)Attribute.GetCustomAttribute(field, typeof(StringValueAttribute));
            return attribute == null ? value.ToString() : attribute.Value;//If the attribute is found, it returns its value; otherwise, it returns the enum value as a string.
        }


        //this how to use it in main:
        //CustomEnum myEnumValue = CustomEnum.Value1;
        //string customString = myEnumValue.GetStringValue();
    }


}
