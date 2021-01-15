using System.Windows.Forms;

namespace WindowsForms.ComboBox_Custom
{

    public class ComboBox_Custom
    {
        /// <summary>Set comboBox Selected Index</summary>
        /// <param name="comboBox">comboBox</param>
        static public void SetComboBoxSelectedIndex(ComboBox comboBox)
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