using System.Windows.Forms;

namespace WindowsForms.OpenFileDialog_Custom.Extension
{

    static public class OpenFileDialog_CustomExtension
    {
        static public string ShowDialog_OpenExcelFile_(this OpenFileDialog f, bool Multiselect = false)
        {
            string fileName = string.Empty;
            if (ShowDialog_OpenExcelFile(f, Multiselect))
            {
                fileName = f.FileName;
            }
            return fileName;
        }

        static public bool ShowDialog_OpenExcelFile(this OpenFileDialog f, bool Multiselect = false)
        {
            const string xlsFilter = "Excel File|*.xlsx;*.xls|All Files|*.*";
            f.Filter = xlsFilter;
            f.Multiselect = Multiselect;

            if (f.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
    }

}