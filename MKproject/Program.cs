using CustomizedTools;
using System;
using System.Drawing;
using System.IO;
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



        //Cashed Forms
        public static MKproject.Management.ClientManagementProfile clientManagementProfile;      
        public static MKproject.Management.NewRegister NewRegisterForm;
        public static MKproject.Management.LOGIN LoginForm;  
        //


        public static GreyColor GreyForm;
        public static GreyColor GreyFormJunior;//in case eende 3 forms foe baaed metel bel new register

        //Mikas: Data Source=MKpc;Initial Catalog=MKproject;User ID=sa;Password=1234
        //Gabs:  Data Source=DESKTOP-MMI74FE\\SQLEXPRESS;Initial Catalog=MKproject2; Integrated Security=True

        public static string DataLocation = "Data Source=MKpc;Initial Catalog=MKproject;User ID=sa;Password=1234";
        public static string FolderProfileImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProfileImages");
        public static string ExecptionString = "Unexpected error:\n";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MKproject.Management.Currency.GetCurrency();
            MKproject.Management.Features.GetFeatures();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm = new MKproject.Management.LOGIN();
            Application.Run(LoginForm);       
        }      
    }
}
