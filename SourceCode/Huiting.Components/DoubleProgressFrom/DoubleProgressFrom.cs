using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huiting.Common;

namespace Huiting.Components
{
    public partial class DoubleProgressFrom : Form
    {

        //string mainTitle;
        //string secondTitle;
        //int mainCurValue;
        //int secondCurValue;
        //int mainMaxValue;
        //int secondMaxValue;

        delegate void DlgMyInvoke(OperateKind operateKind,object Value);
        DlgMyInvoke myInvoke;

        public DoubleProgressFrom()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.CenterParent;
            this.StartPosition = FormStartPosition.CenterScreen;

            myInvoke = new DlgMyInvoke(MyInvokeMethod);
            //MyInvokeMethod=new MyInvoke()

            foreach (Control item in this.Controls)
            {
                Label lbl= item as Label;
                if (lbl == null)
                    continue;
                lbl.Text = "";
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void MyInvokeMethod(OperateKind operateKind, object Value)
        {
            if (Value == null)
                Value = "";

            switch (operateKind)
            {
                case OperateKind.SetMainTitle:
                    lblTitleMain.Text = Value.ToString();
                    break;
                case OperateKind.SetSecondTitle:
                    lblTitleSecond.Text = Value.ToString();
                    break;
                case OperateKind.SetMainCurValue:
                    int mainCurValue = Value.ToInt();
                    progressBarParent.Value = mainCurValue;
                    lblMainCurValue.Text = mainCurValue + "/" + progressBarParent.Maximum;
                    break;
                case OperateKind.SetSecondCurValue:
                    int secondCurValue = Value.ToInt();
                    progressBarChild.Value = secondCurValue;
                    lblSecondCurValue.Text = secondCurValue + "/" + progressBarChild.Maximum;
                    break;
                case OperateKind.SetMainMaxValue:
                    int mainMaxValue = Value.ToInt();
                    if (progressBarParent.Minimum != 0)
                        progressBarParent.Minimum = 0;
                    if (progressBarParent.Maximum != mainMaxValue)
                        progressBarParent.Maximum = mainMaxValue;
                    break;
                case OperateKind.SetSecondMaxValue:
                    int secondMaxValue = Value.ToInt();
                    if (progressBarChild.Minimum != 0)
                        progressBarChild.Minimum = 0;
                    if (progressBarChild.Maximum != secondMaxValue)
                        progressBarChild.Maximum = secondMaxValue;
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        public void ModifyProgress(OperateKind operateKind, object Value)
        {
            //if (Value == null)
            //    Value = "";
            //switch (operateKind)
            //{
            //    case OperateKind.SetMainTitle:
            //        mainTitle = Value.ToString();
            //        break;
            //    case OperateKind.SetSecondTitle:
            //        secondTitle = Value.ToString();
            //        break;
            //    case OperateKind.SetMainCurValue:
            //        mainCurValue = Value.ToInt();
            //        break;
            //    case OperateKind.SetSecondCurValue:
            //        secondCurValue = Value.ToInt();
            //        break;
            //    case OperateKind.SetMainMaxValue:
            //        mainMaxValue = Value.ToInt();
            //        break;
            //    case OperateKind.SetSecondMaxValue:
            //        secondMaxValue = Value.ToInt();
            //        break;
            //    default:
            //        break;
            //}

            this.Invoke(myInvoke, new object[] { operateKind, Value });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray,0,0,this.Width-1,this.Height-1);
        }

        //public void RefreshInterface()
        //{
        //    timer1.Start();
        //}
    }

    [Serializable]
    public enum OperateKind
    {
        //设置主标题
        SetMainTitle,
        SetSecondTitle,
        SetMainCurValue,
        SetSecondCurValue,
        SetMainMaxValue,
        SetSecondMaxValue,
    }
}
