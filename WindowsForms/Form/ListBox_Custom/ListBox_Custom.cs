using System.Windows.Forms;

namespace WindowsForm
{

    public class ListBox_Custom
    {
        /// <summary>Set ListBox Selected Index</summary>
        /// <param name="listBox">ListBox</param>
        static public void SetListBoxSelectedIndex(ListBox listBox)
        {
            if (listBox.SelectedIndex < 0)
            {
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                else
                {
                    listBox.SelectedIndex = -1;
                }

                return;
            }

            if (listBox.SelectedIndex >= listBox.Items.Count)
            {
                listBox.SelectedIndex = listBox.Items.Count - 1;
                return;
            }
        }
    }

}