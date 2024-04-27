
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public class RandomFunctionSchedule
    {
        public static Label selectedlabeltime = null;

        //HIGHLIGHT:
        public static void HighlightUserControl(Label targetlabel)
        {
            //if (selectedlabeltime != null)//hone bye3ne enno eemelna highlight abel ma nfout aal flow layout panel w selectedlabeltime w targetlabeltime saro henne zetoun bas hone targetlabel sar null w select label akhado
            //{
            //    selectedlabeltime.BackColor = Color.White;
            //}
            if (targetlabel != null)//hone baeed ma fetna aal flowlayout panel bas deghre eemelna highlight moujarad ma bayan lflow layout panel
            {
                targetlabel.BackColor = Color.FromArgb(229, 226, 244);
                selectedlabeltime = targetlabel;
            }
        }


        //TABLE LAYOUT PANEL:
        public static void AddColumnTableLayoutPanel(TableLayoutPanel tablelayoutpanel)
        {
            tablelayoutpanel.ColumnCount++;
            float newColumnPercentage = 100f / (tablelayoutpanel.ColumnCount - 1);//100-11.87
            tablelayoutpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, newColumnPercentage));

            for (int i = 1; i < tablelayoutpanel.ColumnCount - 1; i++)
            {
                tablelayoutpanel.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, newColumnPercentage);
            }
        }
        public static void RemoveColumnTableLayoutPanel(TableLayoutPanel tablelayoutpanel, int position)
        {
          
                tablelayoutpanel.ColumnStyles.RemoveAt(position);
                tablelayoutpanel.ColumnCount--;
                float newColumnPercentage = 100f / (tablelayoutpanel.ColumnCount - 1);//100-11.87

               
                for (int i = 1; i <= tablelayoutpanel.ColumnCount - 1; i++)
                {
                    tablelayoutpanel.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, newColumnPercentage);
                }
        }

        public static void ResizeTableLayoutPanelToPerc(TableLayoutPanel tablelayoutpanel)
        {
            float newColumnPercentage = 100f / (tablelayoutpanel.ColumnCount );//100-11.87
            for (int i = 1; i < tablelayoutpanel.ColumnCount ; i++)
            {
                tablelayoutpanel.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, newColumnPercentage);
            }
        }
        public static void ExpandTableLayoutPanelColumn(TableLayoutPanel tablelayoutpanel, int columnIndex, int NewWidth)
        {
            NewWidth += 10;//kermel ybayin luser controls
            if (columnIndex < 0 || columnIndex >= tablelayoutpanel.ColumnCount)
            {
                return;
            }

           
            tablelayoutpanel.ColumnStyles[columnIndex] = new ColumnStyle(SizeType.Absolute, NewWidth);
        }


        //For the PanelOfReminders
        public static bool IsControlInPanel(Control control, Panel panel)
        {
            foreach (Control panelControl in panel.Controls)
            {
                if (panelControl == control)
                {
                    return true; // The control is in the panel
                }
            }
            return false; // The control is not in the panel
        }
    }
}
