using System;


namespace MKproject.Schedule
{
    public class StaticClass
    {
        public static string Member = "Member", Trial = "Trial", Invitation = "Invitation", Meeting = "Meeting";
        static public int? Client_id { get; set; }

        //hone event relation ma3 ucclient wel ucmeeting fa tnaynetoun ha yet3adalo
        static public TimeSpan StartTime { get; set; }
        public static event EventHandler StaticStartTimeChanged;
        public static void OnStaticStartTimeChanged()
        {
            StaticStartTimeChanged?.Invoke(null, EventArgs.Empty);
        }


        static public TimeSpan EndTime { get; set; }
        public static event EventHandler StaticEndTimeChanged;
        public static void OnStaticEndTimeChanged()
        {
            StaticEndTimeChanged?.Invoke(null, EventArgs.Empty);
        }


        static public TimeSpan DifferenceTime { get; set; }
        public static event EventHandler StaticDifferenceTimeChanged;
        public static void OnStaticDifferenceTimeChanged()
        {
            StaticDifferenceTimeChanged?.Invoke(null, EventArgs.Empty);
        }

     


        static public string ClientName { get; set; }
        public static event EventHandler StaticClientNameChanged;
        public static void OnStaticClientNameChanged()
        {
            StaticClientNameChanged?.Invoke(null, EventArgs.Empty);
        }

        static public string ClientType { get; set; }
        public static event EventHandler StaticClientTypeChanged;
        public static void OnStaticClientTypeChanged()
        {
            StaticClientTypeChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
