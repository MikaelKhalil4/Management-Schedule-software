using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
    public class FiltersDataTable
    {
        //this filter won t work , in case there were empty values in it
        public static DataTable FilterDatatableIfContainsIgnoringCapitals(string DesiredColumnName, String DesiredTarget, DataTable Originaldt)
        {

            var filteredData = Originaldt.AsEnumerable();
            if (!string.IsNullOrEmpty(DesiredTarget))
            {
                filteredData = filteredData.Where(row =>
                {
                    var columnValue = row[DesiredColumnName];
                    if (columnValue == DBNull.Value)
                    {
                        return false;
                    }
                    else
                    {                  
                        string stringValue = columnValue.ToString();
                        return stringValue.IndexOf(DesiredTarget, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                });
            }
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
            return filteredDataTable;

        }

        public static DataTable FilterDatatableIFStringEquality(string DesiredColumnName,String DesiredTarget, DataTable Originaldt)
        {
            var filteredData = Originaldt.AsEnumerable();
            filteredData = filteredData.Where(row => row.Field<string>(DesiredColumnName) == DesiredTarget);
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
            return filteredDataTable;
        }

        public static DataTable FilterDatatableIF2StringEquality(string DesiredColumnName, String DesiredTarget1, String DesiredTarget2, DataTable Originaldt)
        {

            var filteredData = Originaldt.AsEnumerable();
            filteredData = filteredData.Where(row => (row.Field<string>(DesiredColumnName) == DesiredTarget1 || row.Field<string>(DesiredColumnName) == DesiredTarget2));
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
            return filteredDataTable;
        }

        public static DataTable FilterDatatableIFIntEquality(string DesiredColumnName, int DesiredTarget, DataTable Originaldt)
        {

            var filteredData = Originaldt.AsEnumerable();
            filteredData = filteredData.Where(row => Convert.ToInt16(row.Field<Int64>(DesiredColumnName)) == DesiredTarget);
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : Originaldt.Clone();
            return filteredDataTable;
        }
        public static DataTable FilterDatatableDateThisMonth(string DesiredColumnName, DataTable DesiredDataTable)
        {

            var filteredData = DesiredDataTable.AsEnumerable();
            filteredData = filteredData.Where(row => row.Field<string>(DesiredColumnName) != null && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Month == DateTime.Now.Month && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Year == DateTime.Now.Year);            
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : DesiredDataTable.Clone();
            return filteredDataTable;
        }
        public static DataTable FilterDatatableDateLastMonth(string DesiredColumnName, DataTable DesiredDataTable)
        {

            var filteredData = DesiredDataTable.AsEnumerable();
            filteredData = filteredData.Where(row => row.Field<string>(DesiredColumnName) != null && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Month == DateTime.Now.AddMonths(-1).Month && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Year == DateTime.Now.Year);          
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : DesiredDataTable.Clone();
            return filteredDataTable;
        }
        public static DataTable FilterDatatableDateThisYear(string DesiredColumnName, DataTable DesiredDataTable)
        {

            var filteredData = DesiredDataTable.AsEnumerable();
            filteredData = filteredData.Where(row => row.Field<string>(DesiredColumnName) != null && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Year == DateTime.Now.Year);           
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : DesiredDataTable.Clone();
            return filteredDataTable;
        }
        public static DataTable FilterDatatableDateLastYear(string DesiredColumnName, DataTable DesiredDataTable)
        {

            var filteredData = DesiredDataTable.AsEnumerable();
            filteredData = filteredData.Where(row => row.Field<string>(DesiredColumnName) != null && Convert.ToDateTime(row.Field<string>(DesiredColumnName)).Year == DateTime.Now.AddYears(-1).Year);         
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : DesiredDataTable.Clone();
            return filteredDataTable;
        }
        public static DataTable FilterDatatableDateCustomDate(string DesiredColumnName, DataTable DesiredDataTable, DateTime startDate, DateTime endDate)
        {

            var filteredData = DesiredDataTable.AsEnumerable();
            filteredData = filteredData.Where(row => Convert.ToDateTime(row.Field<string>(DesiredColumnName)) >= startDate && Convert.ToDateTime(row.Field<string>(DesiredColumnName)) <= endDate);
            DataTable filteredDataTable = filteredData.Any() ? filteredData.CopyToDataTable() : DesiredDataTable.Clone();
            return filteredDataTable;

        }         
      

       
    }
}


