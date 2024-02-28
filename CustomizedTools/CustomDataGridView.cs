using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{
    public class CustomDataGridView : DoubleBufferAndCustomScrollDataGrid
    {
        Color ColorSelection = Color.FromArgb(229, 226, 244);
        Color ColorOnMouseMove = Color.FromArgb(229, 226, 244);//on mouse hover
        Color ColorDefault;//default color mafrud tkun

        private bool isRowColorChangeOnMouseMove;
        public bool IsRowColorChangeonMouseMove
        {
            get { return isRowColorChangeOnMouseMove; }
            set { isRowColorChangeOnMouseMove = value; }
        }


        private bool isSelectRow;
        public bool IsSelectRow
        {
            get { return isSelectRow; }
            set
            {

                isSelectRow = value;
                if (value)
                {
                    this.DefaultCellStyle.SelectionBackColor = ColorSelection;
                }
                else
                {
                    this.DefaultCellStyle.SelectionBackColor = ColorDefault;
                }

            }
        }


      


        public CustomDataGridView()
        {
            ColorDefault = this.DefaultCellStyle.BackColor;
        }
      
        
        
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);
           
                if (!IsSelectRow)
                {
                    if (e.RowIndex > -1)
                    {

                        this.ClearSelection();
                        if (Rows.Count > 0)//ejbare lamma nkun eemlin on mouse click tsakkir
                        {
                            this.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorOnMouseMove;
                        }
                    }
                }
            

        }
        protected override void OnSelectionChanged(EventArgs e)
        {
            // If you want to retain the base behavior, call the base method
            base.OnSelectionChanged(e);
            if (!IsSelectRow)
            {
                this.ClearSelection();
            }

        }
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
        }

        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseMove(e);

                if (IsRowColorChangeonMouseMove)
                {
                    if (e.RowIndex > -1)
                    {
                        DataGridViewCellStyle style1 = new DataGridViewCellStyle();
                        style1.BackColor = ColorOnMouseMove;
                        if (e.RowIndex > -1)
                        {
                            this.Rows[e.RowIndex].DefaultCellStyle = style1;
                        }
                    }
                }
        }
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            if (IsRowColorChangeonMouseMove)
            {
              
                    if (e.RowIndex > -1)
                    {
                        DataGridViewCellStyle style2 = new DataGridViewCellStyle();
                        style2.BackColor = ColorDefault;
                        if (e.RowIndex > -1)
                        {
                            this.Rows[e.RowIndex].DefaultCellStyle = style2;
                        }
                    }
                
            }
        }
   
        public void ApplyStyle1()
        {
            Color HeaderColor = Color.FromArgb(109, 122, 224);

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            // Alternating rows style
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle
            {
                BackColor = Color.White
            };
            AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            // Background color and border style
            BackgroundColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;






            // Column headers style
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = HeaderColor,
                Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                SelectionBackColor = HeaderColor,
                SelectionForeColor = System.Drawing.Color.White,
                WrapMode = System.Windows.Forms.DataGridViewTriState.False
            };
            ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            EnableHeadersVisualStyles = false;
            ColumnHeadersHeight = 50;
            ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Cursor
            Cursor = System.Windows.Forms.Cursors.Hand;



            DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(255, 64, 64, 64), // A=255, R=64, G=64, B=64
                SelectionBackColor = ColorSelection,
                SelectionForeColor = Color.FromArgb(255, 64, 64, 64), // Same as ForeColor
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Regular, GraphicsUnit.Point, 1),
                WrapMode = DataGridViewTriState.False,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            // Misc settings

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowTemplate.MinimumHeight = 40;
            ReadOnly = true;
            RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            RowHeadersVisible = false;
            RowHeadersWidth = 60;
            RowTemplate.DividerHeight = 1;
            RowTemplate.Height = 40;
            RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        }
    
    }

}
