using System.Windows.Forms;

namespace WindowsForms.Control_Custom
{

    /// <summary>
    /// Control_Custom
    /// </summary>
    public class Control_Custom
    {
        /// <summary>
        /// 執行忙碌工作時禁用元件的功能抽象類
        /// </summary>
        public abstract class DisableControlOnBusy_delegate
        {
            /// <summary>
            /// 參數回傳不同時,供覆寫處理參數與回傳
            /// </summary>
            /// <param name="func"></param>
            /// <param name="objArray"></param>
            /// <returns></returns>
            abstract protected object FuncRun(object func, params object[] objArray);
            /// <summary>
            /// 參數&回傳設計為泛用
            /// </summary>
            /// <param name="control"></param>
            /// <param name="func"></param>
            /// <param name="objArray"></param>
            /// <returns></returns>
            public object Run(Control control, object func, params object[] objArray)
            {
                control.Enabled = false;
                try
                {
                    return FuncRun(func, objArray);
                }
                finally
                {
                    control.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 執行忙碌工作時禁用元件的功能類 void func
        /// </summary>
        public class DisableControlOnBusy_delegate_Func_Void_Class : DisableControlOnBusy_delegate
        {
            /// <summary>
            /// void Func
            /// </summary>
            public delegate void Func_Void();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="func"></param>
            /// <param name="objArray"></param>
            /// <returns></returns>
            protected override object FuncRun(object func, params object[] objArray)
            {
                Func_Void f = (Func_Void)func;
                f();
                return null;
            }
        }
        static public void DisableControlOnBusy_delegate_Func_Void(Control control, DisableControlOnBusy_delegate_Func_Void_Class.Func_Void func)
        {
            new DisableControlOnBusy_delegate_Func_Void_Class().Run(control, func);
        }
    }

    //Example
    class DisableControlOnBusy_delegate_Example
    {
        public delegate bool Func_BoolArgString(string str);
        class DisableControlOnBusy_delegate_Func_BoolArgString : Control_Custom.DisableControlOnBusy_delegate
        {
            protected sealed override object FuncRun(object func, params object[] objArray)
            {
                Func_BoolArgString f = (Func_BoolArgString)func;
                string arg = objArray[0].ToString();
                return f(arg);
            }
        }

        static public void DisableControlOnBusy_delegate_Func_BoolArgString_Func(Control control, Func_BoolArgString func, string str)
        {
            new DisableControlOnBusy_delegate_Func_BoolArgString().Run(control, func, str);
        }
    }

}