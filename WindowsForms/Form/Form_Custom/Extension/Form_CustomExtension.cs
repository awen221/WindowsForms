using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

using WindowsForm;

namespace WindowsForms.Form_Custom.Extension
{
    using Form = System.Windows.Forms.Form;

    static public class Form_CustomExtension
    {

        /// <summary>在現有標題文字後端加上檔案版本號碼</summary>
        /// <param name="form"></param>
        static public void FormTitleAppendFileVersion(this Form form)
        {
            FileVersionInfo fv = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            form.Text += " Version : " + fv.FileVersion;
        }

        /// <summary>
        /// 為formMidParent建立不重複的MdiChildForm
        /// </summary>
        /// <typeparam name="T">MdiChildForm class</typeparam>
        /// <param name="formParent">formParent</param>
        /// <param name="Tform">MdiChildForm instance</param>
        static public void CreateMdiChildFormIsUnique<T>(this Form formMidParent, ref T Tform) where T : Form, new()
        {
            WindowsFormFunc.CreateMdiChildFormIsUnique<T>(ref Tform, formMidParent);
        }

        /// <summary>GetFormResourceManager</summary>
        /// <param name="form"></param>
        /// <returns>ResourceManager</returns>
        static public ResourceManager GetFormResourceManager(this Form form)
        {
            Type type;
            type = form.GetType();
            string sRes = type.Namespace + "." + type.Name;
            ResourceManager res = new ResourceManager(sRes, Assembly.GetAssembly(type));
            return res;
        }

        /// <summary>
        /// disable form直到func完成,執行忙碌工作時使用,MdiChildForm使用時Form會有back到最底層的問題,慢慢都轉成USERCONTROL介面,此FUNC慢慢淘汰
        /// </summary>
        /// <param name="form"></param>
        /// <param name="func"></param>
        static public void DisableFormOnBusy_delegate_VoidNoArg(this Form form, Control_Custom.Control_Custom.DisableControlOnBusy_delegate_Func_Void_Class.Func_Void func)
        {
            Control_Custom.Control_Custom.DisableControlOnBusy_delegate_Func_Void(form, func);
        }

    }

}