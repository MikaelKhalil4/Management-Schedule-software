using GlobalFunctions;


namespace MKproject.Management
{
    public class ClassOptionsInsideFields//ejbare kell asseme el enum ykuno mawjudin  bel enumYpe classClient
    {
        //global


        public enum UnitHeight
        {
            cm,
            ft,
        }

        public enum UnitWeight
        {
            kg,
            lb,
        }


        //checkboxes and radio
        public enum enumNone
        {
            [StringValue("None")]
            None,
        }

        public enum YesNo
        {
            [StringValue("Yes")]
            Yes,
            [StringValue("No")]
            No
        }
        public enum Gender
        {
            [StringValue("Male")]
            Male,
            [StringValue("Female")]
            Female
        }
        public enum RightLeft

        {
            [StringValue("Right")]
            Right,
            [StringValue("Left")]
            Left
        }
        public enum enumMaritalStatus
        {
            [StringValue("Single")]
            Single,
            [StringValue("Married")]
            Married,
            [StringValue("Have Children")]//add textbox UCPureNumber
            HaveChildren,
        }



        //custom
        public enum Period
        {
            Weeks,
            Months,
            Years
        }


        //checkboxes and radio
        public enum enumHowDidYouKnowAboutUs//checkbox
        {
            [StringValue("Instagram")]
            instagram,//TLPGlobal
            [StringValue("Facebook")]
            Facebook,
            [StringValue("Tiktok")]
            Tiktok,
            [StringValue("Bouche A L'Oreille")]//Add Textbox
            BoucheAOreille,
            [StringValue("Brochure")]
            brochure,
            [StringValue("Gift Voucher")]
            GiftVoucher,
            [StringValue("Novo Club")]
            NovoClub,
            [StringValue("Others")]//Add Textbox
            Others
        }
        public enum enumInsta
        {
            [StringValue("Invitation")]
            Invitation,
            [StringValue("Boosting")]
            Boosting,
            [StringValue("By Searching")]
            BySearching,   
            [StringValue("Customer Mention")]//Add Textbox
            CustomerMention
        }

        public enum enumBodyShapeTarget
        {
            [StringValue("Toned body")]
            tonedbody,
            [StringValue("Build muscles")]
            buildmuscles,
            [StringValue("Burn fat")]
            burnfat
 
        }
        public enum enumMuscleFocusOn
        {
            [StringValue("Entire body")]
            Entirebody,
            [StringValue("Chest")]
            Chest,
            [StringValue("Back")]
            Back,
            [StringValue("Arms")]
            Arms,
            [StringValue("Gluteus")]
            Gluteus,
            [StringValue("Legs")]
            Legs,
            [StringValue("Abs")]
            Abs,
        }
        public enum enumInjuries//checkboxes
        {
            //none badna nzida men el new regis
            [StringValue("Back pain")]
            Backpain,       
            [StringValue("Upper back pain")]
            Upperbackpain,
            [StringValue("Lower back pain")]
            Lowerbackpain,
            [StringValue("Knee pain")]
            Kneepain,
            [StringValue("Left knee pain")]
            Leftkneepain,
            [StringValue("Right knee pain")]
            Rightkneepain,
            [StringValue("Neck pain")]
            Neckpain,
            [StringValue("Others")]//add textbox
            Others

        }
        public enum enumExerciseHistory//checkboxes
        {
            [StringValue("Cardio")]
            Cardio,
            [StringValue("Strenght Training")]
            StrenghtTraining,
            [StringValue("Flexibility And Mobility")]
            FlexibilityAndMobility,
            [StringValue("Others")]//add textbox
            Others
        }
        public enum enumFightingSkills
        {
            [StringValue("Self defense")]
            Selfdefense,
            [StringValue("Relieve stress")]
            Relievestress,
            [StringValue("Increase focus")]
            Increasefocus,
            [StringValue("Reflex")]
            Reflex,
            [StringValue("Learn how to fight")]
            Learnhowtofight
        }
        public enum enumStressLevel
        {
            [StringValue("Not Stressed")]
            NotStressed,
            [StringValue("Low Stress")]
            LowStress,
            [StringValue("Moderate Stress")]
            ModerateStress,
            [StringValue("High Stress")]
            HighStress,
            [StringValue("Very High Stress")]
            VeryHighStress,
            [StringValue("I don't want to answer")]
            Idontwanttoanswer
        }
        public enum enumSessionPerWeek
        {
            [StringValue("1")]
            One,
            [StringValue("2")]
            Two,
            [StringValue("3")]
            Three,
            [StringValue("4")]
            Four,
            [StringValue("5")]
            Five,
            [StringValue("6")]
            Six
        }


    }
}
