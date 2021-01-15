using System.Data;
using System.Windows.Forms;

namespace WindowsForms.TabControl_Custom
{
    public class TabControl_Custom
    {
        /// <summary>
        /// DataSetToTab
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tabControl"></param>
        static public void ImportDataSet(DataSet dataSet, TabControl tabControl)
        {
            tabControl.TabPages.Clear();

            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable dataTable = dataSet.Tables[i];
                DataGridView dataGridView = new DataGridView();

                dataGridView.DataSource = dataTable;
                dataGridView.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(dataTable.TableName);
                tabControl.TabPages[i].Controls.Add(dataGridView);

                dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
    }
}