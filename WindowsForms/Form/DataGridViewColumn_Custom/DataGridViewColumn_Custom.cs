using System.Windows.Forms;

namespace WindowsForms.DataGridViewColumn_Custom
{

    public class DataGridViewColumn_Custom
    {
        static public void SetDataGridViewColumnHide(DataGridViewColumn col)
        {
            col.Visible = false;
            col.ReadOnly = true;
        }
        static public void SetDataGridViewColumnsHide(params DataGridViewColumn[] cols)
        {
            foreach (DataGridViewColumn col in cols) SetDataGridViewColumnHide(col);
        }
    }

}