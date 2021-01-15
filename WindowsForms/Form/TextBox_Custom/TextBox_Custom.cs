using System.Windows.Forms;

namespace WindowsForms.TextBox_Custom
{

    public class TextBox_Custom
    {
        /// <summary>
        /// KeyPressLimitInput
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="allowFun">allowFun</param>
        /// <param name="allowSymbol">allowSymbol</param>
        /// <param name="allowNumber">allowNumber</param>
        /// <param name="allowUpperCaseLetter">allowUpperCaseLetter</param>
        /// <param name="allowLowerCaseLetters">allowLowerCaseLetters</param>
        static public void KeyPressLimitInput(KeyPressEventArgs e, bool allowFun, bool allowSymbol,
            bool allowNumber, bool allowUpperCaseLetter, bool allowLowerCaseLetters)
        {
            if (
                //功能鍵^@, ^A~^Z(不分大小寫; ^M = ENTER; ^H = BACKSPACE; DEL,TAB無法攔截), ^[ = ESC, ^\, ^], ^^, ^_;
                (e.KeyChar >= '\u0000' && e.KeyChar <= '\u001F' && allowFun)
                || 
                //符號段01 " !"#$%&'()*+,-./"
                (e.KeyChar >= ' ' && e.KeyChar <= '/' && allowSymbol)
                || 
                //數字
                (e.KeyChar >= '0' && e.KeyChar <= '9' && allowNumber)
                || 
                //符號段02 ":;<=>?@"
                (e.KeyChar >= ':' && e.KeyChar <= '@' && allowSymbol)
                || 
                //大寫字母
                (e.KeyChar >= 'A' && e.KeyChar <= 'Z' && allowUpperCaseLetter)
                || 
                //符號段03 "[\]^_`"
                (e.KeyChar >= '[' && e.KeyChar <= '`' && allowSymbol)
                || 
                //小寫字母
                (e.KeyChar >= 'a' && e.KeyChar <= 'z' && allowLowerCaseLetters)
                || 
                //符號段04 "{|}~"
                (e.KeyChar >= '{' && e.KeyChar <= '~' && allowSymbol)
                )
            {
                return;
            }
            e.Handled = true;
        }
        /// <summary>
        /// KeyPressLimitInputReturnIsEnter
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="allowFun">允許功能鍵</param>
        /// <param name="allowSymbol">允許符號</param>
        /// <param name="allowNumber">允許數字</param>
        /// <param name="allowUpperCaseLetters">允許大寫字母</param>
        /// <param name="allowLowerCaseLetters">允許小寫字母</param>
        /// <returns>IsEnter</returns>
        static public bool KeyPressLimitInputReturnIsEnter(KeyPressEventArgs e, bool allowFun, bool allowSymbol,
            bool allowNumber, bool allowUpperCaseLetters, bool allowLowerCaseLetters)
        {
            KeyPressLimitInput(e, allowFun, allowSymbol, allowNumber, allowUpperCaseLetters, allowLowerCaseLetters);

            if (e.KeyChar == '\r')
            {
                return true;
            }
            return false;
        }
    }

}