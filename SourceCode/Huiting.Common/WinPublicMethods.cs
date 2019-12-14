using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;

namespace Huiting.Common
{
    public class WinPublicMethods
    {

        #region 弹出信息（异常、警告、提示）

        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void ExceptionMessageBox(string strCaption, string strInfo)
        {
            MessageBox.Show(strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="strInfo">信息</param>
        static public void ExceptionMessageBox(string strInfo)
        {
            ErrMessageBox("异常", strInfo);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void ExceptionMessageBox(IWin32Window owner, string strCaption, string strInfo)
        {
            MessageBox.Show(owner, strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strInfo">信息</param>
        static public void ExceptionMessageBox(IWin32Window owner, string strInfo)
        {
            ExceptionMessageBox(owner, "异常", strInfo);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void ErrMessageBox(string strCaption, string strInfo)
        {
            MessageBox.Show(strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="strInfo">信息</param>
        static public void ErrMessageBox(string strInfo)
        {
            ErrMessageBox("错误", strInfo);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void ErrMessageBox(IWin32Window owner, string strCaption, string strInfo)
        {
            MessageBox.Show(owner, strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strInfo">信息</param>
        static public void ErrMessageBox(IWin32Window owner, string strInfo)
        {
            ErrMessageBox(owner, "错误", strInfo);
        }
        /// <summary>
        /// 警告信息提示
        /// </summary>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void WarnMessageBox(string strCaption, string strInfo)
        {
            MessageBox.Show(strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 警告信息提示
        /// </summary>
        /// <param Name="strInfo">信息</param>
        static public void WarnMessageBox(string strInfo)
        {
            WarnMessageBox("警告", strInfo);
        }
        /// <summary>
        /// 警告信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void WarnMessageBox(IWin32Window owner, string strCaption, string strInfo)
        {
            MessageBox.Show(owner, strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 警告信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strInfo">信息</param>
        static public void WarnMessageBox(IWin32Window owner, string strInfo)
        {
            WarnMessageBox(owner, "警告", strInfo);
        }
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void TipsMessageBox(string strCaption, string strInfo)
        {
            MessageBox.Show(strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void DebugMessageBox(string strCaption, string strInfo)
        {
            MessageBox.Show(strInfo, strCaption + " - 调试信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param Name="strInfo">信息</param>
        static public void TipsMessageBox(string strInfo)
        {
            TipsMessageBox("提示", strInfo);
        }
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strCaption">标题</param>
        /// <param Name="strInfo">信息</param>
        static public void TipsMessageBox(IWin32Window owner, string strCaption, string strInfo)
        {
            MessageBox.Show(owner, strInfo, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param Name="owner">容器</param>
        /// <param Name="strInfo">信息</param>
        static public void TipsMessageBox(IWin32Window owner, string strInfo)
        {
            TipsMessageBox(owner, "提示", strInfo);
        }
        /// <summary>
        /// 咨询问题
        /// </summary>
        /// <param Name="QuestionStr"></param>
        /// <returns></returns>
        public static bool AskQuestion(string QuestionStr)
        {
            DialogResult MsgBoxResult;//设置对话框的返回值
            MsgBoxResult = MessageBox.Show(QuestionStr, "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (MsgBoxResult == DialogResult.Yes)
                return true;
            return false;
        }
        /// <summary>
        /// 咨询问题
        /// </summary>
        /// <param Name="owner"></param>
        /// <param Name="QuestionStr"></param>
        /// <returns></returns>
        public static bool AskQuestion(IWin32Window owner, string QuestionStr)
        {
            DialogResult MsgBoxResult;//设置对话框的返回值
            MsgBoxResult = MessageBox.Show(owner, QuestionStr, "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (MsgBoxResult == DialogResult.Yes)
                return true;
            return false;
        }

        #endregion

        #region 保存文件对话框

        /// <summary>
        /// 选择文件
        /// </summary>
        public static string GetFilePath(string Filter)
        {
            OpenFileDialog OpFile = new OpenFileDialog();
            OpFile.Filter = Filter;
            //OpFile.InitialDirectory = Path.GetDirectoryName(PublicMethods.GetAssemblyPath());
            string filePath = "";

            if (OpFile.ShowDialog() == DialogResult.OK)
            {
                if (OpFile.FileNames.Length > 0)
                    filePath = OpFile.FileNames[0];
            }
            else
            {
                return "";
            }
            return filePath;
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        public static string GetFilePath(string Filter, IWin32Window owner)
        {
            OpenFileDialog OpFile = new OpenFileDialog();
            OpFile.Filter = Filter;
            string filePath = "";
            //OpFile.InitialDirectory = Path.GetDirectoryName(PublicMethods.GetAssemblyPath());
            if (OpFile.ShowDialog(owner) == DialogResult.OK)
            {
                if (OpFile.FileNames.Length > 0)
                    filePath = OpFile.FileNames[0];
            }
            else
            {
                return "";
            }
            return filePath;
        }

        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param Name="Filter"></param>
        /// <param Name="FileName"></param>
        /// <param Name="frmParent"></param>
        /// <returns></returns>
        public static string SetFilePath(string Filter, string FileName, IWin32Window owner)
        {
            return SetFilePath(Filter, FileName, "保存", owner);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filter"></param>
        /// <param name="FileName"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public static string SetFilePath(string Filter, string FileName, string Title)
        {
            return SetFilePath(Filter, FileName, Title, null);
        }

        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param Name="Filter"></param>
        /// <param Name="FileName"></param>
        /// <returns></returns>
        public static string SetFilePath(string Filter, string FileName)
        {
            return SetFilePath(Filter, FileName, "保存", null);
        }

        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param Name="Filter"></param>
        /// <param Name="FileName"></param>
        /// <param Name="Title"></param>
        /// <param Name="frmParent"></param>
        /// <returns></returns>
        public static string SetFilePath(string Filter, string FileName, string Title, IWin32Window owner)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = FileName;
            sfd.Filter = Filter;
            sfd.Title = Title;
            DialogResult dr;
            if (owner == null)
                dr = sfd.ShowDialog();
            else
                dr = sfd.ShowDialog(owner);

            if (dr == DialogResult.OK)
                return sfd.FileName;
            else
                return "";
        }

        public static string GetFolderPath(Form frmParent)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(frmParent) == DialogResult.OK)
                return fbd.SelectedPath;
            else
                return "";
        }

        public static string GetFolderPath(Form frmParent, string RootPath)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = RootPath;
            if (fbd.ShowDialog(frmParent) == DialogResult.OK)
                return fbd.SelectedPath;
            else
                return "";
        }

        public static string GetFolderPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;
            else
                return "";
        }

        #endregion

    }
}