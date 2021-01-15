using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace WindowsForms.DataGridView_Custom
{

    public class DataGridView_Custom
    {
        /// <summary>
        /// 設定DataGridView的col排序模式
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="sortMode"></param>
        static public void DataGridViewSetColumnsSortMode(DataGridView dgv, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn col in dgv.Columns) col.SortMode = sortMode;
        }

        /// <summary>
        /// Converts the DataGridView to DataTable  
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="minRow"></param>
        /// <returns></returns>
        static public DataTable DataGridViewToDataTable(DataGridView dgv, int minRow = 0)
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

        /// <summary>
        /// 從剪貼簿將資料匯入DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="ClipboardDataTableHasColumns">bool</param>
        static public void ImportDataFromClipboard(ref DataGridView dgv,bool ClipboardDataTableHasColumns = false)
        {
            if (dgv.DataSource == null) dgv.DataSource = new BindingSource();
            BindingSource bindingSource = (BindingSource)dgv.DataSource;

            DataTable tmp = (DataTable)bindingSource.DataSource;

            string text = Clipboard.GetText();
            List<string> Clipboard_TextLines = new List<string>(text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));

            tmp.Clear();

            if (ClipboardDataTableHasColumns)
            {
                tmp.Columns.Clear();
                string[] Clipboard_TableColumns = Clipboard_TextLines[0].Split('\t');
                for (int i = 0; i < Clipboard_TableColumns.Length; i++)
                {
                    tmp.Columns.Add(Clipboard_TableColumns[i].ToString());
                }
            }

            foreach (string line in Clipboard_TextLines)
            {
                string[] cells = line.Split(new char[] { '\t' });
                tmp.Rows.Add(cells);
            }

            dgv.DataSource = bindingSource;
            dgv.Refresh();
        }
    }

    /// <summary>
    /// 紀錄原本的排序,在資料變更後維持該排序狀態
    /// </summary>
    public class DataGridViewKeepSort : IDisposable
    {

        /// <summary>
        /// 要處理的DataGridView
        /// </summary>
        DataGridView dataGridView { set; get; }
        /// <summary>
        /// 紀錄已排序的欄位
        /// </summary>
        DataGridViewColumn SortedColumn;
        /// <summary>
        /// 紀錄排序升降冪
        /// </summary>
        SortOrder sortOrder;


        public DataGridViewKeepSort(DataGridView _dataGridView)
        {
            dataGridView = _dataGridView;
            SortedColumn = dataGridView.SortedColumn;
            sortOrder = dataGridView.SortOrder;
        }

        public void Dispose()
        {
            if (SortedColumn == null) return;

            DataGridViewColumn SortColumn = dataGridView.Columns[SortedColumn.Name];
            if (sortOrder == SortOrder.Ascending)
            {
                dataGridView.Sort(SortColumn, ListSortDirection.Ascending);
            }
            else if (sortOrder == SortOrder.Descending)
            {
                dataGridView.Sort(SortColumn, ListSortDirection.Descending);
            }
            else
            {
            }
        }

    }

}