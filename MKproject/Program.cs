using CustomizedTools;
using MKproject.Management;
using MKproject.Schedule;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velopack;
using Velopack.Windows;
using Velopack.Locators;
using System.Net.Http;
using Amazon.S3;
using Amazon.S3.Model;

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
        public static ScheduleForm ScheduleFormGlobal;
        //


        public static GreyColor GreyForm;
        public static GreyColor GreyFormJunior;//in case eende 3 forms foe baaed metel bel new register
        public static GreyColor GreyFormJuniorJunior;//in case eende 4 forms foe baaed metel bel new register

        //Tablet/Mikas: Data Source=MKpc;Initial Catalog=MKproject;Integrated Security=True;
        //Mikas: Data Source=MKpc;Initial Catalog=MKproject;User ID=sa;Password=1234
        //Gabs:  Data Source=DESKTOP-MMI74FE\\SQLEXPRESS;Initial Catalog=MKproject; Integrated Security=True
        //Elie:Data Source= C:\\Users\\USER\\Documents\\Foxdb\\Fox.db

        public static string DataLocation;
        public static string FolderProfileImagePath;


        public static string ExecptionString = "Unexpected error:\n";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VelopackApp.Build().WithAfterInstallFastCallback((v) => new Shortcuts().CreateShortcutForThisExe(ShortcutLocation.Desktop)).Run();

            //UpdateMyApp();

            DataLocation = "Data Source=" + AppPaths.DatabasePath;
            FolderProfileImagePath = AppPaths.ProfileImagesPath;

            AppPaths.EnsureDirectoriesExist();
            DatabaseInitializer.InitializeDatabase();


            Currency.Symbol = "$";
            Currency.CurrencyName = "USD";
            ClassClientCustom.CreationOfTheFieldInitially();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm = new LOGIN();
            LoginForm.labelVersion.Text = "v 1.0.4";

            Application.Run(LoginForm);

        }


        public static void UpdateMyApp()
        {
            try
            {
                var mgr = new UpdateManager("http://127.0.0.1:9000/fox-global");

                // check for new version
                var newVersion = mgr.CheckForUpdates();
                if (newVersion == null)
                    return; // no update available

                // download new version
                mgr.DownloadUpdates(newVersion);

                // install new version and restart app
                mgr.ApplyUpdatesAndRestart(newVersion);

                MessageBox.Show("Succeeded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        //         dotnet publish -c Release --self-contained -r win-x86 -o./bin/Publish/win-x86
        //         vpk download s3  --bucket fox-global  --channel win-x86 --endpoint http://127.0.0.1:9000 --keyId 5WjS33bNTytXoNqzPMIN --secret 54fo5ZtU0zYZjRkXV44go56GGxZq0yEH4l06iIJO
        //         vpk pack -u FoxApp -v 1.0.0 -p./bin/Publish/win-x86 -e MKproject.exe  --channel win-x86 --packTitle "Fox" --icon images/foxlogo.ico --splashImage images/foxlogo.ico 
        //         vpk upload s3  --bucket fox-global --channel win-x86 --endpoint http://127.0.0.1:9000 --keyId 5WjS33bNTytXoNqzPMIN --secret 54fo5ZtU0zYZjRkXV44go56GGxZq0yEH4l06iIJO



        //         dotnet publish -c Release --self-contained -r win-x64 -o./bin/Publish/win-x64
        //         vpk download s3  --bucket fox-global --channel win-x64 --endpoint http://127.0.0.1:9000 --keyId 5WjS33bNTytXoNqzPMIN --secret 54fo5ZtU0zYZjRkXV44go56GGxZq0yEH4l06iIJO
        //         vpk pack -u FoxApp -v 1.0.4 -p./bin/Publish/win-x64 -e MKproject.exe  --channel win-x64 --packTitle "Fox" --icon images/foxlogo.ico --splashImage images/foxlogo.ico 
        //         vpk upload s3  --bucket fox-global  --channel win-x64 --endpoint http://127.0.0.1:9000 --keyId 5WjS33bNTytXoNqzPMIN --secret 54fo5ZtU0zYZjRkXV44go56GGxZq0yEH4l06iIJO



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
