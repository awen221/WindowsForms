using System.Data;
using System.Windows.Forms;

namespace WindowsForms.DataGridView_Custom.Extension
{

    static public class DataGridView_CustomExtension
    {
        /// <summary>
        /// Converts the DataGridView to DataTable  
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="minRow"></param>
        /// <returns></returns>
        static public DataTable ToDataTableEX(this DataGridView dgv, int minRow = 0)
        {
            DataTable dt = new DataTable();
            // Header columns  
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.HeaderText.ToString(), column.ValueType);

                dt.Columns.Add(dc);
            }
            // Data cells  
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value;
                }
                dt.Rows.Add(dr);
            }
            // Related to the bug arround min size when using ExcelLibrary for export  
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }

}
