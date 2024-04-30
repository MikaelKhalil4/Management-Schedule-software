using CustomizedTools;
using MKproject.Management;
using MKproject.Schedule;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace MKproject
{
    internal static class Program
    {
        public static bool IsANewParentAddedOrParentPhoneUpdated;//this variable is used kermel lamma nerjaa aal search(nekbus back men el management), naamil restore men el datatbase 
                                                                 //in 2 cases:1) Lamma naamil add la new parent men el new register,2) lamma naamil update la phone number tabaa parent eendo chiddrens

        //Global Colors:  Soft Gentle  Medium Vibrant Bold
        public static Color SoftColor = Color.FromArgb(238, 241, 254);//used if the backgorund was white
        public static Color MediumColor = Color.FromArgb(196, 210, 245);//used in the background
        public static Color BoldColor = Color.FromArgb(109, 122, 224);//used for buttons/datagrid headers

        public static Color CancleButton = Color.FromArgb(95, 97, 99);//used for buttons/datagrid headers
        //Cashed Forms, Dont Forget if you have attached events to them, to release them, Also Menu And Home
        public static ClientManagementProfile clientManagementProfile;      
        public static NewRegister NewRegisterForm;
        public static LOGIN LoginForm;  
        public static Home HomeForm;
        //


        public static GreyColor GreyForm;
        public static GreyColor GreyFormJunior;//in case eende 3 forms foe baaed metel bel new register

        //Mikas: Data Source=MKpc;Initial Catalog=MKproject;User ID=sa;Password=1234
        //Gabs:  Data Source=DESKTOP-MMI74FE\\SQLEXPRESS;Initial Catalog=MKproject; Integrated Security=True

        public static string DataLocation = " Data Source=MKpc;Initial Catalog=MKproject;User ID=sa;Password=1234";
        public static string FolderProfileImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProfileImages");
        public static string ExecptionString = "Unexpected error:\n";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          Currency.GetCurrency();
          Features.GetFeatures();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm = new LOGIN();
            Application.Run(LoginForm);       
        }



        //some global functions
        public static string SetCashFormat(string cash)
        {
            return Currency.Symbol + cash;
        }
        public static string SetBalanceFormat(string balance)//balance in the parameter it s going to be only a number: -5 0 -100
        {
            if (balance.Contains('-'))
            {
                balance = balance.Substring(1);
                balance = "-" + Currency.Symbol + balance;
            }
            else
            {
                balance = Currency.Symbol + balance;
            }
            return balance;
        }
    }
}
