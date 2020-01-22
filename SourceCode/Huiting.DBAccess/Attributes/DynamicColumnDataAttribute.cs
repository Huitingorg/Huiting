using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Attributes
{
    /// <summary>
    /// 动态列数据特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DynamicColumnDataAttribute : Attribute
    {
        /// <summary>
        /// 文本框数字
        /// </summary>
        /// <param name="isNumber">是否数字</param>
        /// <param name="textBoxEnabled">是否可用</param>
        /// <param name="toolTipDisplay">tooltip是否显示</param>
        /// <param name="toolValue">tooltip是否显示值</param>
        public DynamicColumnDataAttribute(bool isNumber, int length, string textBoxEnabled = null, string toolTipDisplay = null, string toolValue = null)
        {
            IsNumber = isNumber;
            Length = length;
            TextBoxEnabled = textBoxEnabled;
            ToolTipDisplay = toolTipDisplay;
            ToolValue = toolValue;
        }

        /// <summary>
        /// 文本框金额
        /// </summary>
        /// <param name="isAmount">是否金额</param>
        /// <param name="pointNum">几位小数</param>
        /// <param name="textBoxEnabled">是否可用</param>
        /// <param name="toolTipDisplay">tooltip是否显示</param>
        /// <param name="toolValue">tooltip是否显示值</param>
        public DynamicColumnDataAttribute(bool isAmount, string pointNum, string textBoxEnabled = null, string toolTipDisplay = null, string toolValue = null, string lastCostPrice = null)
        {
            IsAmount = isAmount;
            PointNum = pointNum;
            TextBoxEnabled = textBoxEnabled;
            ToolTipDisplay = toolTipDisplay;
            ToolValue = toolValue;
            LastCostPrice = lastCostPrice;
        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <param name="displayValue">显示值</param>
        /// <param name="selectedValue">选中值</param>
        public DynamicColumnDataAttribute(string displayValue, string selectedValue, string comboBoxEnabled = null)
        {
            DisplayValue = displayValue;
            SelectedValue = selectedValue;
            ComboBoxEnabled = comboBoxEnabled;
        }

        /// <summary>
        /// 文本框是否可用
        /// </summary>
        public string TextBoxEnabled { get; }

        /// <summary>
        /// 下拉框是否可用
        /// </summary>
        public string ComboBoxEnabled { get; }

        /// <summary>
        /// 是否数字
        /// </summary>
        public bool IsNumber { get; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// 是否金额
        /// </summary>
        public bool IsAmount { get; }

        /// <summary>
        /// 保留几位小数
        /// </summary>
        public string PointNum { get; }

        /// <summary>
        /// 下拉款显示值
        /// </summary>
        public string DisplayValue { get; }

        /// <summary>
        /// 下拉框选中值
        /// </summary>
        public string SelectedValue { get; }

        /// <summary>
        /// ToolTip是否显示
        /// </summary>
        public string ToolTipDisplay { get; }

        /// <summary>
        /// ToolTip显示值
        /// </summary>
        public string ToolValue { get; }

        /// <summary>
        /// ToolTip显示值2
        /// </summary>
        public string LastCostPrice { get; }
    }
}
