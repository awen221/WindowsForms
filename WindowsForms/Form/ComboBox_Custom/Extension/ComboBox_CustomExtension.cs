using System.Windows.Forms;

namespace WindowsForms.ComboBox_Custom.Extension
{

    static public class ComboBox_CustomExtension
    {
        /// <summary>Set comboBox Selected Index</summary>
        /// <param name="comboBox">comboBox</param>
        static public void SetSelectedIndex(this ComboBox comboBox)
        {
            if (comboBox.SelectedIndex < 0)
            {
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    comboBox.SelectedIndex = -1;
                }

                return;
            }

            if (comboBox.SelectedIndex >= comboBox.Items.Count)
            {
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
                return;
            }
        }
    }

}