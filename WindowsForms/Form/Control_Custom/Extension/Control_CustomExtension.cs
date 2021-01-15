namespace WindowsForms.Control_Custom.Extension
{
    using System.Windows.Forms;

    static public class Control_CustomExtension
    {
        static public void DisableControlOnBusy_delegate_VoidNoArg(this Control control, Control_Custom.DisableControlOnBusy_delegate_Func_Void_Class.Func_Void func)
        {
            Control_Custom.DisableControlOnBusy_delegate_Func_Void(control, func);
        }
    }
}
