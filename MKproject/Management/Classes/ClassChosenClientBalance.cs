using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Management
{
    public class ClassChosenClientBalance//mainly used bel schedule , when we re selection a ervice
    {
        public int ClientBalanceID { get; set; }
        public double Balance { get; set; }//null if not package
        public int? SessionLeft { get; set; }//null if not package of session
        public string ClientBalanceSessionLeftDetails { get; set; }//additional,  it a string that describe the service,if package: adde baaed eendo session w masare,if solo: service name,
        public string ClientBalanceDetails { get; set; }//additional, null if not package, its a string: currency + Balance



        public static string SetPackageFormatFromBalance(DataRow dtrow)
        {
           string PackageRemainings = dtrow["bundle_name"] + ": ";
            if (dtrow["due_date"] != DBNull.Value)
            {
                if ((bool)dtrow["is_freezed"] == false)//only packgae of days not freezed
                {
                    int daysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)dtrow["due_date"]);
                    if (daysLeft < 0)
                    {
                        daysLeft = 0;
                    }
                    PackageRemainings += daysLeft + " Days Left";//tene wahde - awwal wahde
                }
                else//package days freezed
                {
                    PackageRemainings += (int)dtrow["session_left_days"] + " Days Left(Freezed)";
                }
            }
            else//package sesiosn
            {
                PackageRemainings += (int)dtrow["session_left_days"] + " Session Left";
            }
            return PackageRemainings;
        }
    }
}
