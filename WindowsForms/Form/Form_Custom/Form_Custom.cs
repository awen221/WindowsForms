using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsForms.Form_Custom
{
    using Form = System.Windows.Forms.Form;
    public class Form_Custom
    {
        /// <summary>
        /// 視窗標題附加檔案版本
        /// </summary>
        /// <param name="form"></param>
        static public void SetTitleAppendFileVersion(Form form)
        {
            string filePath = Assembly.GetEntryAssembly().Location;
            FileVersionInfo fv = FileVersionInfo.GetVersionInfo(filePath);

            form.Text += " Version : " + fv.FileVersion;
        }

        //form.Enabled = false;時MID CHILD FORM會Back到最後面,慢慢淘汰此用法改用UserControl代替
        //abstract public class DisableFormOnBusy_delegate
        //{
        //    abstract protected object FuncRun(object func, params object[] objArray);
        //    public object Run(Form form,object _func, params object[] objArray)
        //    {
        //        FormWindowState keep = form.WindowState;
        //        form.Enabled = false;
        //        try
        //        {
        //            return FuncRun(_func, objArray);
        //        }
        //        finally
        //        {
        //            form.Enabled = true;
        //            form.WindowState = keep;
        //        }
        //    }
        //}
        //public class DisableFormOnBusy_delegate_VoidArgNone : Form_.DisableFormOnBusy_delegate
        //{
        //    public delegate void Func_VoidArgNone();
        //    protected sealed override object FuncRun(object func, params object[] objArray)
        //    {
        //        Func_VoidArgNone f = (Func_VoidArgNone)func;
        //        f();
        //        return null;
        //    }
        //}

        //abstract public class DisableFormOnBusy_delegate
        //{
        //    object func;
        //    public DisableFormOnBusy_delegate(object _func)
        //    {
        //        func = _func;
        //    }
        //    abstract protected void FuncRun(object func,params object[] objArray);

        //    public bool Run(Form form,params object[] objArray)
        //    {
        //        FormWindowState keep = form.WindowState;
        //        try
        //        {
        //            form.Enabled = false;

        //            FuncRun(func,objArray);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //        finally
        //        {
        //            form.Enabled = true;
        //            form.WindowState = keep;
        //        }
        //    }
        //}
        //sealed public class DisableFormOnBusy_delegate_VoidNoArg : DisableFormOnBusy_delegate
        //{
        //    /// <summary>
        //    /// 宣告委派
        //    /// </summary>
        //    public delegate void Func_VoidNoArg();
        //    /// <summary>
        //    /// 繼承建構式
        //    /// </summary>
        //    /// <param name="_func"></param>
        //    public DisableFormOnBusy_delegate_VoidNoArg(Func_VoidNoArg _func) : base(_func) { }
        //    /// <summary>
        //    /// 覆寫委派執行函式
        //    /// </summary>
        //    /// <param name="func"></param>
        //    protected sealed override void FuncRun(object func,params object[] objArray) { ((Func_VoidNoArg)func)(); }
        //}
    }
}