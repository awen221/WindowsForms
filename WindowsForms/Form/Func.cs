using System;
using System.Data;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsForms
{
    using Form = System.Windows.Forms.Form;
    public class WindowsFormFunc
    {

        #region 只有AutoUpdate用到
        
        //非public的Func參考用,不建議呼叫,耦合度太高

        /// <summary>自動滾動到最底部</summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        static void AutoScrollToBottomOn_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ScrollBars = ScrollBars.Vertical;
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }
        #endregion

        /// <summary>Clipboard Excel Data Paste To DataGridView把剪貼簿的內容逐行貼至dataGridView</summary>
        /// <param name="dataGridView"></param>
        static public void ClipboardPasteToDataGridView(DataGridView dataGridView)
        {
            string clipboard = Clipboard.GetText();
            string[] lines = clipboard.Split('\n');

            //取得目前的行列數
            int currentRow = dataGridView.CurrentCell.RowIndex;
            int currentColumn = dataGridView.CurrentCell.ColumnIndex;
            int rowCount = dataGridView.Rows.Count;

            DataGridViewCell CurrentCell;
            //增加列數
            if (lines.Length > rowCount - currentRow)
            {
                int cut = lines.Length - (rowCount - currentRow);

                dataGridView.Rows.Add(cut);
            }
            //將值寫入到DataGridView
            foreach (string line in lines)
            {
                string[] cells = line.Split('\t');
                if (cells.Length > 0)
                {
                    for (int i = 0; i < cells.Length; i++)
                    {
                        //處理儲存格
                        CurrentCell = dataGridView[currentColumn + i, currentRow];
                        string value = cells[i];
                        CurrentCell.Value = value;
                    }
                    currentRow++;
                }
            }
        }

        static public DataTable ClipboardToDataTable()
        {
            string clipboard = Clipboard.GetText();
            string[] lines = clipboard.Split('\n');

            int rowsCount = lines.Length;
            int columnsCount = lines[0].Split('\t').Length;

            DataTable dt = new DataTable();
            DataColumn[] dataColumns = new DataColumn[columnsCount];
            for(int i=0;i< columnsCount;i++)
            {
                dataColumns[i] = new DataColumn();
            }
            dt.Columns.AddRange(dataColumns);

            for (int i = 0; i < rowsCount; i++)
            {
                dt.Rows.Add(lines[i].Split('\t'));
            }

            return dt;
        }

        /// <summary>OnFormClosingToHideForm</summary>
        /// <param name="e">FormClosingEventArgs</param>
        static public void OnFormClosingToHideForm(Form from,FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                from.Hide();
            }
        }

        /// <summary>CreateMdiChildFormIsUnique</summary>
        /// <typeparam name="T_ChildForm">MdiChild Type</typeparam>
        /// <param name="MdiChild">MdiChild</param>
        /// <param name="MdiParent">MdiChild</param>
        static public bool CreateMdiChildFormIsUnique<T_ChildForm>(ref T_ChildForm MdiChild, Form MdiParent)
            where T_ChildForm : Form, new()
        {
            if (MdiChild != null)
            {
                if (MdiChild.IsMdiChild)
                {
                    MdiChild.BringToFront();
                    MdiChild.Focus();
                    return false;
                }
            }

            MdiChild = new T_ChildForm();
            MdiChild.MdiParent = MdiParent;
            MdiChild.Show();

            return true;
        }

        /// <summary>GetFormResourceManager 
        /// 繼承Form時取用GetFormResourceManager時必須指定該Form類別</summary>
        /// <typeparam name="FormT">FormT</typeparam>
        /// <returns>ResourceManager</returns>
        static public ResourceManager GetFormResourceManager<FormT>() where FormT : Form
        {
            Type type = typeof(FormT);
            string sRes = type.Namespace + "." + type.Name;
            ResourceManager res = new ResourceManager(sRes, Assembly.GetAssembly(type));
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        static public bool MessageBox_OKCancel(string text,string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }

}