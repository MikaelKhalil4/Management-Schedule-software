using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GlobalFunctions.ClassGlobalEnum;
using static MKproject.ClassClientCustom;
using static MKproject.Management.ClassClient;

namespace MKproject
{
    public class ClassClientCustomFront
    {

        public ClientManagementProfile ExtentionClientManagementProfile { get; set; }
        public NewRegister ExtentionNewRegister { get; set; }

        public ClassClientCustomFront()
        {

        }




  
        //private UCLabelAndDetail UCWeight;
      
  
        public void UpdateOrCreateUCLabelAndDetail(ref bool NewUCCreated, string FieldName, ClassClientCustom Client, bool isVisible)
        {
            //if (FieldName == enumDynamicFields.Height.ToString())
            //{
            //    NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCHeight, enumDynamicFields.Height.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.Height), isVisible, (int)enumDynamicFields.Height);
            //}
        
        }





        //NEw Register
        //private TLPOtherOptions TLPHeight;
    



      


        public void UpdateOrInsertToSQLAndObj(ref ClassClientCustom UpdatedOrNewClient, ref ClassClientCustom Client)
        {
    
            //if (TLPHeight != null)
            //{
            //    UpdatedOrNewClient.Height = TLPHeight.Value;
            //}
         

            if (Client != null)
            {

                //Client.Height = UpdatedOrNewClient.Height;
          
            }
        }
        public void UpdateOrCreateFields(string FieldName, bool isVisible, bool isRequired, int ControlsWidthInsideFLP, ClassClientCustom Client, FlowLayoutPanel FLPInfo)
        {
            //if (FieldName == enumDynamicFields.Height.ToString())
            //{
            //    if (isVisible)
            //    {
            //        if (TLPHeight == null)
            //        {
            //            TLPHeight = new TLPOtherOptions(enumDynamicFields.Height.GetStringValue(), isRequired, CreateHeightUCDoubleCombo());
            //            TLPHeight.Width = ControlsWidthInsideFLP;
            //            FLPInfo.Controls.Add(TLPHeight);
            //        }
            //        else
            //        {
            //            if (isRequired && !TLPHeight.IsRequired)
            //            {
            //                TLPHeight.IsRequired = true;
            //            }
            //            else if (!isRequired && TLPHeight.IsRequired)
            //            {
            //                TLPHeight.IsRequired = false;
            //            }
            //        }
            //        if (Client != null)
            //        {
            //            TLPHeight.FillDesignValues(Client.Height);
            //        }
            //        TLPHeight.Index = (int)enumDynamicFields.Height;

            //    }
            //    else
            //    {
            //        if (TLPHeight != null)
            //        {

            //            ExtentionNewRegister.Controls.Remove(TLPHeight);
            //            TLPHeight.Dispose();
            //            TLPHeight = null;
            //        }
            //    }
            //}

        }
        public bool CheckRequired(ref bool a, List<Control> RequiredControls)
        {
        

            //if (TLPHeight != null && TLPHeight.ActiveRequiredMode())
            //{
            //    a = false;
            //    RequiredControls.Add(TLPHeight);
            //}
          
            return a;
        }






        //Registation Fields
        public void FormatOriginalDt(DataRow row, string FieldName)
        {

            //Dynamic 
            //if (FieldName == enumDynamicFields.Height.ToString())
            //{
            //    row["design_index"] = (int)enumDynamicFields.Height;
            //    row["FakeFields"] = enumDynamicFields.Height.GetStringValue();
            //}
          

        }
    }
}
