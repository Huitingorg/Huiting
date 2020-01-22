using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Reflection;
using System.Drawing.Design;

namespace Huiting.Components
{
    public class HWVDataGridViewColumnConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            DataGridViewColumnNode hwvDataGridViewColumn = value as DataGridViewColumnNode;
            if (hwvDataGridViewColumn == null || hwvDataGridViewColumn.IsLeafColumn == true)
                return "";

            return "复杂表头";
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return false;
        }
    }
}