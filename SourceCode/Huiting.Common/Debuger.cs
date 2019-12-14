using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.Common
{
	public class Debuger
	{
		#region 单例模式
		
		private static Debuger instance = new Debuger();

		public static Debuger Instance
		{
			get { return Debuger.instance; }
			set { Debuger.instance = value; }
		}
		private Debuger()
		{

		}

		#endregion


		DateTime dtOld = DateTime.Now;
		DateTime dtNew = DateTime.Now;

		bool showTimeSpan = true;

		public bool ShowTimeSpan
		{
			get { return showTimeSpan; }
			set { showTimeSpan = value; }
		}

		/// <summary>
		/// 开始计时
		/// </summary>
		public void StartTime()
		{
			dtNew = dtOld = DateTime.Now;
		}

		/// <summary>
		/// 打印信息
		/// </summary>
		/// <param name="keyWord">显示信息</param>
		/// <param name="showTimeSpan">是否显示时间差</param>
		public void WriteTimeSpan(string keyWord, bool showTimeSpan = true)
		{
			dtNew = DateTime.Now;
			keyWord = keyWord.Trim();
			if (showTimeSpan)
			{
				Console.Write(keyWord);
				TimeSpan ts = dtNew - dtOld;
				string strFormt = "距离上次时间差：{0}毫秒";
				strFormt = string.Format(strFormt, ts.Milliseconds);

				dtNew = DateTime.Now;
				Console.WriteLine(strFormt);
			}
			else
				Console.WriteLine(keyWord);

			dtOld = dtNew;
		}



	}
}
