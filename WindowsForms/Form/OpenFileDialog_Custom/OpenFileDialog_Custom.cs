using System.Windows.Forms;

namespace WindowsForms.OpenFileDialog_Custom
{
    public class OpenFileDialog_Custom
    {
        /// <summary>
        /// 開啟EXCEL的OpenFileDialog
        /// </summary>
        /// <returns>file name</returns>
        static public string GetOpenExcelFile(bool Multiselect = false)
        {
            const string xlsFilter = "Excel File|*.xlsx;*.xls|All Files|*.*";

            string fileName = string.Empty;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = xlsFilter;
            f.Multiselect = Multiselect;

            if (f.ShowDialog() == DialogResult.OK)
            {
                fileName = f.FileName;
            }

            return fileName;
        }
    }
}