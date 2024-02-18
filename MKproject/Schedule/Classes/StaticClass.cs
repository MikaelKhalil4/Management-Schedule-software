
using System;


namespace MKproject.Schedule
{
    public class StaticClass
    {
        public enum AppointmentType
        {
            Member,
            Solo,// bi kun ekhid a specific service
            Others
        }

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
