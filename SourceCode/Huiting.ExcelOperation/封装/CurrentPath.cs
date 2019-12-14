using System;
using System.Collections.Generic;
using System.Text;

namespace Huiting.ExcelOperation
{
  public static class CurrentPath
    {
        /// <summary>
        /// 获取当前模块运行的DLL
        /// </summary>
        /// <returns></returns>
        static public string GetCurRunPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度

            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }

            _FolderPath = _FolderPath.Replace(@"/", @"\");
            return _FolderPath;
        }

    }
}
