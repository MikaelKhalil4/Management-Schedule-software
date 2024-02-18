using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;


namespace MKproject.Schedule
{
    internal class RandomFunctions
    {
       public  static string ExtractDigits(string input)
        {
            string pattern = @"\D"; // Matches any non-digit character
            string digitsOnly = Regex.Replace(input, pattern, ""); // Removes all non-digit characters
            return digitsOnly;
        }
        public static int AgeCalculator(DateTime Birthdate )
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - Birthdate.Year;

            if (currentDate.Month < Birthdate.Month || (currentDate.Month == Birthdate.Month && currentDate.Day < Birthdate.Day))
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
        public static string SetDateFormat(string lastcheck)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Now;
            string Lastvisit;

            if (lastcheck != DBNull.Value.ToString())
            {
                DateTime check_in = Convert.ToDateTime(lastcheck);
                if (check_in.Day == today.Day)
                {
                    Lastvisit = "Today" + " at " + check_in.ToString("HH:mm tt");
                }
                else if (check_in.Day == yesterday.Day)
                {
                    Lastvisit = "Yesterday" + " at " + check_in.ToString("HH:mm tt");
                }
                else Lastvisit = check_in.ToString("MMMM,dd/yyyy");
            }
            else Lastvisit = "00:00";
            return Lastvisit;

        }
        public static DataTable FilterDatatableByName(String FullName,DataTable Originaldt)
        {

            var filteredData = Originaldt.AsEnumerable();
            //string nameText = textBoxViewByName.Text.TrimEnd();
                string[] nameWords = FullName.Split(' ');
                if (nameWords.Length == 1)
                {
                    filteredData = filteredData.Where(row =>
                        (row.Field<string>("name").Contains(nameWords[0]) || row.Field<string>("family_name").Contains(nameWords[0]))

                    );
                }
                else if (nameWords.Length == 2)
                {
                    filteredData = filteredData.Where(row =>
                        (row.Field<string>("name").Contains(nameWords[0]) && row.Field<string>("family_name").Contains(nameWords[1])) ||
                        (row.Field<string>("name").Contains(nameWords[1]) && row.Field<string>("family_name").Contains(nameWords[0])) ||
                        (row.Field<string>("name").Contains(nameWords[0] + " " + nameWords[1])) ||
                        (row.Field<string>("family_name").Contains(nameWords[0] + " " + nameWords[1]))
                    );

                }
                else if (nameWords.Length == 3)
                {
                    filteredData = filteredData.Where(row =>
                         (row.Field<string>("name").Contains(nameWords[0]) && row.Field<string>("family_name").Contains(nameWords[1] + " " + nameWords[2])) ||
                         (row.Field<string>("name").Contains(nameWords[0] + " " + nameWords[1]) && row.Field<string>("family_name").Contains(nameWords[2]))
                    );
                }
                else if (nameWords.Length == 4)
                {
                    filteredData = filteredData.Where(row =>
                         (row.Field<string>("name").Contains(nameWords[0] + " " + nameWords[1]) && row.Field<string>("family_name").Contains(nameWords[2] + " " + nameWords[3]))

                    );
                }

               DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
               return filteredDataTable;
        }
        public static DataTable FilterDatatableByPhoneNumber(String PhoneNumber, DataTable Originaldt)
        {

            var filteredData = Originaldt.AsEnumerable();
            filteredData = filteredData.Where(row =>
                      (row.Field<string>("phone_number").Contains(PhoneNumber)));
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
            return filteredDataTable;
        }


        }
    }
