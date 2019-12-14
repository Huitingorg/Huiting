using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class HWVDataGridViewColumnEditor : UITypeEditor
    {
        //弹出模式
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
                return UITypeEditorEditStyle.Modal;

            return base.GetEditStyle(context);
        }

        //弹出时机
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                //MyCustomTypeDescriptor<HWVPropertyAttribute> myctD = context.Instance as MyCustomTypeDescriptor<HWVPropertyAttribute>;
                //IPageOwner PageOwner = myctD.SelectObject as IPageOwner;
                DataGridViewColumnNode dgvc = value as DataGridViewColumnNode;

                FrmTreeHeadColumnsEdit fciqe = new FrmTreeHeadColumnsEdit(dgvc);
                fciqe.StartPosition = FormStartPosition.CenterScreen;
                if (fciqe.ShowDialog() == DialogResult.OK)
                {
                    value = fciqe.RootColumn;
                    return value;
                }
            }
            return base.EditValue(context, provider, value);
        }
    }
}
