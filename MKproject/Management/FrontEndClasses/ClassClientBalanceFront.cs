using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class ClassClientBalanceFront
    {

        //kermel el design display tb3 clientBalance bel datatgridView
        public static void FormatClientBalanceDt(DataTable DtClientBalanceOriginal)
        {

            DtClientBalanceOriginal.Columns.Add("AutoIncrementColumn", typeof(int));
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrement = true;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementSeed = 1;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementStep = 1;
            int currentAutoIncrementValue = 1;

            foreach (DataRow row in DtClientBalanceOriginal.Rows)
            {
                row["AutoIncrementColumn"] = currentAutoIncrementValue;
                currentAutoIncrementValue++;
            }
            DtClientBalanceOriginal.PrimaryKey = new DataColumn[] { DtClientBalanceOriginal.Columns["client_balance_id"] };

            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("AutoIncrementColumn"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("Description");//description bas kermel el design 
            newIndex = 1; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("purchase_date"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("due_date"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("original_offre"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("offre"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("amount_paid"); // Replace with the actual column name
            newIndex = 6; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("balance"); // Replace with the actual column name
            newIndex = 7; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

        }
        public static void FixCellsFormat(DataGridView DesiredDatagrid, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DesiredDatagrid.Rows.Count && e.ColumnIndex < DesiredDatagrid.Columns.Count)
            {
                if (e.Value == DBNull.Value || e.Value == null)
                {
                    e.Value = "N/A";
                }
                else
                {
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "balance")
                    {
                        e.Value = Program.SetBalanceFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "amount_paid")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "original_offre")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());// $ + 350/ 20 sess
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "offre")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "due_date")
                    {
                        e.Value = (Convert.ToDateTime(e.Value)).ToString("MMMM/dd/yyyy");
                    }
                    if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "purchase_date")
                    {
                        e.Value = (Convert.ToDateTime(e.Value)).ToString("MMMM/dd/yyyy");
                    }
                }

            }
            //Design Display
            if (DesiredDatagrid.Columns[e.ColumnIndex].Name == "balance")
            {

                DataGridViewCell cell = DesiredDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (Convert.ToDouble(cell.Value) != 0)
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.SelectionForeColor = Color.Black;
                }
            }
        }
        public static void FormatDatagridview(DataGridView DesiredDataGrid, bool IsProfile)
        {
            foreach (DataGridViewColumn col in DesiredDataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DesiredDataGrid.Columns["client_balance_id"].Visible = false;
            DesiredDataGrid.Columns["bundle_id"].Visible = false;
            DesiredDataGrid.Columns["bundle_name"].Visible = false;
            DesiredDataGrid.Columns["product_id"].Visible = false;
            DesiredDataGrid.Columns["session_left_days"].Visible = false;
            DesiredDataGrid.Columns["is_freezed"].Visible = false;
            DesiredDataGrid.Columns["is_expired"].Visible = false;
            DesiredDataGrid.Columns["due_date"].Visible = false;

            if (IsProfile)
            {
                DesiredDataGrid.Columns["PayOrEdit"].DisplayIndex = DesiredDataGrid.ColumnCount - 2;
                DesiredDataGrid.Columns["Transactions"].DisplayIndex = DesiredDataGrid.ColumnCount - 1;
            }

            ///

            DesiredDataGrid.Columns["AutoIncrementColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DesiredDataGrid.Columns["Description"].FillWeight = 13;
            DesiredDataGrid.Columns["purchase_date"].FillWeight = 20;
            DesiredDataGrid.Columns["original_offre"].FillWeight = 17;
            DesiredDataGrid.Columns["offre"].FillWeight = 17;
            DesiredDataGrid.Columns["amount_paid"].FillWeight = 9;
            DesiredDataGrid.Columns["balance"].FillWeight = 12;
            DesiredDataGrid.Columns["due_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            DesiredDataGrid.Columns["balance"].HeaderText = "Balance";
            DesiredDataGrid.Columns["AutoIncrementColumn"].HeaderText = "ID";
            DesiredDataGrid.Columns["original_offre"].HeaderText = "Offre";
            DesiredDataGrid.Columns["offre"].HeaderText = "Deal";
            DesiredDataGrid.Columns["amount_paid"].HeaderText = "Paid";
            DesiredDataGrid.Columns["purchase_date"].HeaderText = "PurchaseDate";
        }
    }
}
