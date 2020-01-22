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
using System.Net;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Microsoft.Win32;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Huiting.Common
{
	public class PublicMethods
	{
		#region 文件读写

		//[MethodDescription(desc)]
		//[MethodDescription(DescriptionAttribute)]
		public static void WriteFile(string FilePath, string Content)
		{
			FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
			try
			{
				using (StreamWriter m_streamWriter = new StreamWriter(fs, System.Text.Encoding.Default))
				{
					m_streamWriter.Flush();
					m_streamWriter.WriteLine(Content);
					m_streamWriter.Flush();
					m_streamWriter.Dispose();
					m_streamWriter.Close();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("写txt类型的文件出错:" + ex.Message);
			}
			finally
			{
				fs.Dispose();
				fs.Close();
			}
		}

		public static string ReadFile(string FilePath)
		{
			string strContent = "";
			try
			{
				FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamReader m_streamReader = new StreamReader(fs);

				//用StreamReader类来读取文件
				m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

				//从数据流中读取每一行，只到文件的最后一行
				strContent = m_streamReader.ReadToEnd();
				m_streamReader.Close();
			}
			catch (Exception ee)
			{
				throw new Exception("读txt类型的文件出错:" + ee.Message);
			}

			return strContent;
		}

		public static byte[] ConvertToByteAry(Image img, System.Drawing.Imaging.ImageFormat ImageFormat)
		{
			using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
			{
				img.Save(ms, ImageFormat);
				return ms.ToArray();
			}
		}

		public static byte[] ReadFileToByteAry(string FileFullName)
		{
			byte[] byteAry;
			using (FileStream fs = new FileStream(FileFullName, FileMode.Open))
			{
				long count = fs.Length;
				byteAry = new byte[count];
				fs.Read(byteAry, 0, (int)count);
				fs.Close();
				fs.Dispose();
			}

			return byteAry;
		}

		public static bool ReadByteAryToFile(byte[] byteAry, string fileFullName, out string errInfo)
		{
			errInfo = "";
			try
			{
				using (FileStream fs = new FileStream(fileFullName, FileMode.OpenOrCreate))
				{
					fs.Write(byteAry, 0, byteAry.Length);
					fs.Flush();
					fs.Close();
					fs.Dispose();

					return true;
				}
			}
			catch (Exception ex)
			{
				errInfo = ex.Message;
				return false;
			}
		}

		public static Bitmap GetBitmapByByteAry(byte[] byteAry)
		{
			MemoryStream ms = new MemoryStream();
			ms.Write(byteAry, 0, byteAry.Length);
			return new Bitmap(ms);
		}

		public static string GetFileNameWithoutPath(string FileName)
		{
			FileInfo fi = new FileInfo(FileName);
			return fi.Name;
		}

		#endregion

		//是否继承了后者
		public static bool IsInheritType(Type baseType, Type derivedType)
		{
			return derivedType.GetInterface(baseType.Name) == null ? false : true;
		}

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		/// <summary>
		/// 根据正则表达式，来获取匹配结果
		/// </summary>
		/// <param Name="Expression">要匹配的字符串</param>
		/// <param Name="Regex">匹配表达式</param>
		/// <param Name="IgnoreCase">为真表示忽略大小写，为假表示区分大小写</param>
		/// <returns>返回获取匹配结果</returns>
		public static string[] GetResultAryByRegex(string strInfo, string regularExpressions, bool IgnoreCase)
		{
			try
			{
				System.Text.RegularExpressions.Regex r;
				if (IgnoreCase)
					r = new System.Text.RegularExpressions.Regex(regularExpressions, RegexOptions.IgnoreCase);
				else
					r = new System.Text.RegularExpressions.Regex(regularExpressions, RegexOptions.IgnoreCase);
				System.Text.RegularExpressions.MatchCollection mc = r.Matches(strInfo);

				if (mc == null)
					return null;

				string[] strTableNames = new string[mc.Count];
				//mc.CopyTo(strTableNames, 0);

				for (int i = 0; i < mc.Count; i++)
				{
					string str = mc[i].Value;
					strTableNames[i] = str.Substring(0, str.Length);
				}

				return strTableNames;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 返回当前程序集的版本,详见AssemblyInfo.cs的[assembly: AssemblyVersion("1.0.*")]
		/// </summary>
		/// <returns></returns>
		public static string GetVersion()
		{
			return Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		/// <summary>
		/// 返回当前程序文件的版本，详见AssemblyInfo.cs的[assembly: AssemblyFileVersion("1.0.*")]
		/// </summary>
		/// <returns></returns>
		public static string GetFileVersion()
		{
			string strFilePath = Application.StartupPath + "\\DBModelManagement.exe";
			string version = System.Reflection.Assembly.LoadFrom(strFilePath).GetName().Version.ToString();
			return version;
		}

		#region 绘制自动换行的文本

		/// <summary>
		/// 绘制文本自动换行（超出区域截断）
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="text">文字</param>
		/// <param Name="font">字体</param>
		/// <param Name="clrFont">字体颜色</param>
		/// <param Name="FontHeight">字体高度</param>
		/// <param Name="rect">矩形范围</param>
		public static void DrawStringWrap(Graphics g, string text, Font font, Color clrFont, Rectangle rect, int FontHeight)
		{
			List<string> textRows = GetLstString(g, font, text, rect.Width);
			int rowHeight = GetTestWordIntHeight(g, font);
			int maxRowCount = rect.Height % rowHeight == 0 ? rect.Height / rowHeight : rect.Height / rowHeight + 1;

			if (maxRowCount < textRows.Count)
			{
				textRows.RemoveRange(maxRowCount, textRows.Count - maxRowCount);
				textRows[textRows.Count - 1] = GetLastLineText(textRows[textRows.Count - 1], font, rect.Width);
			}

			DrawStringWrap(g, textRows, font, clrFont, rect.Location, rect.Width - rect.Location.X, FontHeight);
		}

		/// <summary>
		/// 绘制自动换行的文本
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="textRows">文字队列</param>
		/// <param Name="font">字体</param>
		/// <param Name="clrFont">颜色</param>
		/// <param Name="ptText">颜色</param>
		/// <param Name="intRowWidth">文字宽度</param>
		/// <param Name="intRowHeight">文字高度</param>
		public static void DrawStringWrap(Graphics g, List<string> textRows, Font font, Color clrFont, Point ptText, int intRowWidth, int intRowHeight)
		{
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;
			//添加行限制，如果剩下的空间写不开一行则不写了
			sf.FormatFlags = StringFormatFlags.LineLimit;
			//添加省略号，当前文字过多时
			sf.Trimming = StringTrimming.EllipsisCharacter;

			for (int i = 0; i < textRows.Count; i++)
			{
				Rectangle fontRectanle = new Rectangle(ptText.X, ptText.Y + intRowHeight * i, intRowWidth, intRowHeight);
				g.DrawString(textRows[i], font, new SolidBrush(clrFont), fontRectanle, sf);
				//g.DrawString(textRows[i], font, new SolidBrush(clrFont), new PointF(ptText.X, ptText.Y + intRowHeight * i));
			}
		}

		/// <summary>
		/// 获取最后一行文字，如果文字太长，则添加省略号
		/// </summary>
		/// <param Name="strLastLineText"></param>
		/// <param Name="f"></param>
		/// <param Name="intRowWidth"></param>
		/// <returns></returns>
		public static string GetLastLineText(string strLastLineText, Font f, int intRowWidth)
		{
			string OmissionText = "...";
			Bitmap bmp = new Bitmap(30, 20);
			Graphics g = Graphics.FromImage(bmp);

			int LastLineWidth = (int)Math.Ceiling(g.MeasureString(strLastLineText, f).Width);
			int OmissionWidth = (int)Math.Ceiling(g.MeasureString(OmissionText, f).Width);
			//如果省略词宽度大于最后一行文字宽度，返回最后一行文字（只是因为有可能出现这种情况）
			if (OmissionWidth > LastLineWidth)
				return strLastLineText;
			//如果最后一行文字个数比省略词个数少，返回最后一行文字（只是因为有可能出现这种情况）
			if (strLastLineText.Length < OmissionText.Length)
				return strLastLineText;

			int intStep = 0;
			string strTmpLastLineWidth = strLastLineText;
			int TmpLastLineWidth = LastLineWidth;

			while (TmpLastLineWidth + OmissionWidth > intRowWidth)
			{
				intStep++;
				strTmpLastLineWidth = strLastLineText.Substring(0, strLastLineText.Length - intStep);
				TmpLastLineWidth = (int)Math.Ceiling(g.MeasureString(strTmpLastLineWidth, f).Width);
			}
			strLastLineText = strTmpLastLineWidth + OmissionText;

			g.Dispose();
			bmp.Dispose();

			return strLastLineText;
		}

		/// <summary>
		/// 将文本分行
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="font">字体</param>
		/// <param Name="text">文本</param>
		/// <param Name="intRowWidth">行宽</param>
		/// <returns></returns>
		private static List<string> GetLstString(Graphics g, Font font, string text, int intRowWidth)
		{
			int RowBeginIndex = 0;
			int rowEndIndex = 0;
			int textLength = text.Length;
			List<string> textRows = new List<string>();
			for (int index = 0; index < textLength; index++)
			{
				rowEndIndex = index;
				//是否最后一个字
				if (index == textLength - 1)
				{
					textRows.Add(text.Substring(RowBeginIndex));
				}
				//如果是换行，特殊处理
				else if (rowEndIndex + 1 < text.Length && text.Substring(rowEndIndex, 2) == "\r\n")
				{
					textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
					rowEndIndex = index += 2;
					RowBeginIndex = rowEndIndex;
				}
				else if (g.MeasureString(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex + 1), font).Width > intRowWidth)
				{
					textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
					RowBeginIndex = rowEndIndex;
				}
			}

			return textRows;
		}

		/// <summary>
		/// 将文本分行
		/// </summary>
		/// <param Name="font">字体</param>
		/// <param Name="text">文本</param>
		/// <param Name="intRowWidth">行宽</param>
		/// <returns></returns>
		public static List<string> GetLstString(Font font, string text, int intRowWidth)
		{
			Bitmap bmp = new Bitmap(30, 20);
			Graphics g = Graphics.FromImage(bmp);
			List<string> lstText = GetLstString(g, font, text, intRowWidth);

			g.Dispose();
			bmp.Dispose();

			return lstText;
		}

		public static List<string> GetLstString<T>(IEnumerable<T> lstT, string propertyName)
		{
			List<string> lstStr = new List<string>();
			Type type = typeof(T);
			foreach (T item in lstT)
			{
				object obj = PublicMethods.GetPropertyValue(item, propertyName);
				if (obj == null)
					continue;
				lstStr.Add(obj.ToString());
			}

			return lstStr;
		}

		/// <summary>
		/// 根据当前是否是点选来获取文本队列，如果是点选，则获取全部文本队列，如果不是点选，只获取最多两行文字，多出的两行用省略号
		/// </summary>
		/// <param Name="textRows"></param>
		/// <param Name="font"></param>
		/// <param Name="OmissionText"></param>
		/// <param Name="intRowWidth"></param>
		/// <param Name="bolDotSelected"></param>
		/// <param Name="intTextLimitRowNum"></param>
		/// <returns></returns>
		private static List<string> GetLstString(List<string> textRows, Font font, string OmissionText, int intRowWidth, bool bolDotSelected, int intTextLimitRowNum)
		{
			if (bolDotSelected)
			{
			}
			else
			{
				if (textRows.Count > intTextLimitRowNum && intTextLimitRowNum >= 1)
				{
					textRows.RemoveRange(intTextLimitRowNum, textRows.Count - intTextLimitRowNum);
					textRows[textRows.Count - 1] = GetLastLineText(textRows[textRows.Count - 1], font, intRowWidth);
				}
			}

			return textRows;
		}

		/// <summary>
		/// 返回文字的高度
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="font"></param>
		/// <param Name="strWord"></param>
		/// <returns></returns>
		public static SizeF GetWordSizeF(Graphics g, Font font, string strWord)
		{
			return g.MeasureString(strWord, font);
		}

		public static Size GetWordSize(Graphics g, Font font, string strWord)
		{
			SizeF sf = g.MeasureString(strWord, font);
			return sf.ToSize();
		}

		/// <summary>
		/// 获取word大小
		/// </summary>
		/// <param Name="font"></param>
		/// <param Name="strWord"></param>
		/// <returns></returns>
		public static Size GetWordSize(Font font, string strWord)
		{
			Bitmap bmp = new Bitmap(1, 1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sf = g.MeasureString(strWord, font);
			Size sz = new Size((int)Math.Ceiling(sf.Width), (int)Math.Ceiling(sf.Height));
			g.Dispose();
			g = null;


			return sz;
		}

		/// <summary>
		/// 获取word大小
		/// </summary>
		/// <param Name="font"></param>
		/// <param Name="strWord"></param>
		/// <returns></returns>
		public static SizeF GetWordSizeF(Font font, string strWord)
		{
			Bitmap bmp = new Bitmap(1, 1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF szf = g.MeasureString(strWord, font);
			g.Dispose();
			g = null;

			return szf;
		}

		/// <summary>
		/// 获取自动换行文字的所占范围的大小
		/// </summary>
		/// <param Name="strWord">要实现自动换行的文字</param>
		/// <param Name="font">字体</param>
		/// <param Name="intWidth">宽度</param>
		/// <param Name="sf">要自动换行的文字字体</param>
		/// <returns></returns>
		public static Size GetWordSize(string strWord, Font font, int intWidth, StringFormat sf)
		{
			//先模拟一张同样宽度画布（固定宽度求高度，所以此处与画布高度无关）
			Bitmap bmp = new Bitmap(intWidth, 43);
			Graphics g = Graphics.FromImage(bmp);
			//测量用指定的 System.Drawing.Font 绘制并用指定的 System.Drawing.StringFormat 格式化的指定字符串。
			//此方法返回 System.Drawing.SizeF 结构，该结构表示在 text 参数中指定的、用 font 参数和 stringFormat
			//参数绘制的字符串的大小，单位由 System.Drawing.Graphics.PageUnit 属性指定。
			SizeF szf = g.MeasureString(strWord, font, intWidth, sf);
			int intW = (int)Math.Ceiling(szf.Width);
			int intH = (int)Math.Ceiling(szf.Height);
			Size sz = new Size(intW, intH);
			g.Dispose();
			g = null;

			return sz;
		}

		/// <summary>
		/// 返回浮点型的测试文字行高
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="font"></param>
		/// <returns></returns>
		public static float GetTestWordFloatHeight(Graphics g, Font font)
		{
			//中英文高度不同
			return GetWordSizeF(g, font, "测Ok").Height;
		}

		/// <summary>
		/// 返回整型的测试文字行高
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="font"></param>
		/// <returns></returns>
		public static int GetTestWordIntHeight(Graphics g, Font font)
		{
			return (int)(Math.Ceiling(GetTestWordFloatHeight(g, font)));
		}

		/// <summary>
		/// 返回文字行高
		/// </summary>
		/// <param Name="font"></param>
		/// <param Name="TestText"></param>
		/// <returns></returns>
		public static int GetTestWordIntHeight(Font font)
		{
			Bitmap bmp = new Bitmap(1, 1);
			Graphics g = Graphics.FromImage(bmp);
			int intLineHeight = GetTestWordIntHeight(g, font);

			g.Dispose();
			bmp.Dispose();

			return intLineHeight;
		}
		/// <summary>
		/// 返回文字行高
		/// </summary>
		/// <param Name="font"></param>
		/// <param Name="TestText"></param>
		/// <returns></returns>
		public static float GetTestWordFltHeight(Font font)
		{
			Bitmap bmp = new Bitmap(1, 1);
			Graphics g = Graphics.FromImage(bmp);
			float fltLineHeight = GetTestWordFloatHeight(g, font);

			g.Dispose();
			bmp.Dispose();

			return fltLineHeight;
		}

		#endregion

		#region 获取路径

		/// <summary>
		/// 获取绝对路径
		/// </summary>
		/// <param Name="strFileName"></param>
		/// <returns></returns>
		public static string GetAbsolutePath(string strFileName)
		{
			if (!IsAbsolutePath(strFileName))
			{
				strFileName = AbsolutePath(strFileName);
			}

			return strFileName;
		}

		/// <summary>
		/// 返回绝对路径
		/// </summary>
		/// <param Name="strFileName">文件名</param>
		/// <returns>返回绝对路径</returns>
		private static string AbsolutePath(string strFileName)
		{
			string Path = System.IO.Path.Combine(GetAssemblyPath(), strFileName);
			Path = Path.Replace(@"//", @"\");
			Path = Path.Replace(@"/", @"\");
			return Path;
		}

		/// <summary>
		/// 判断当前路径是否为绝对地址,是返回true,否则相反
		/// </summary>
		/// <param Name="strPathFile">文件地址</param>
		/// <returns></returns>
		public static bool IsAbsolutePath(string strPathFile)
		{
			bool bolflag = false;

			string[] strRegex = { @"[a-zA-Z][:]", "[Hh][Tt][Tt][Pp][:]", "[Hh][Tt][Tt][Pp][Ss][:]", "[Ff][Tt][Pp][:]" };

			for (int i = 0; i < strRegex.Length; i++)
			{
				System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(strRegex[i]);
				System.Text.RegularExpressions.MatchCollection mc = r.Matches(strPathFile);

				if (mc.Count > 0)
				{
					bolflag = true;
					return bolflag;
				}
			}

			return bolflag;
		}

		private static string curAssemblyPath = "";
		/// <summary>
		/// 获取被调用DLL的路径
		/// </summary>
		/// <returns></returns>
		public static string GetAssemblyPath()
		{
			if (string.IsNullOrEmpty(curAssemblyPath))
			{
				string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

				_CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);

				string[] arrSection = _CodeBase.Split(new char[] { '/' });

				string _FolderPath = "";
				for (int i = 0; i < arrSection.Length - 1; i++)
				{
					_FolderPath += arrSection[i] + "/";
				}
				curAssemblyPath = _FolderPath;
			}

			return curAssemblyPath;
		}

		/// <summary>
		/// 创建圆角矩形框
		/// </summary>
		/// <param Name="rect">矩形大小</param>
		/// <param Name="cornerRadius">圆角大小</param>
		/// <returns></returns>
		public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
		{
			GraphicsPath roundedRect = new GraphicsPath();
			if (cornerRadius == 0)
				cornerRadius = 1;
			roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
			roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
			roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
			roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
			roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
			roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
			roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
			roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
			roundedRect.CloseFigure();
			return roundedRect;
		}

		/// <summary>
		/// 以两个正方形为外径为边缘,获取两圆截面(用于滑动到最后时的提示)
		/// </summary>
		/// <param Name="rectOuter"></param>
		/// <param Name="rectInner"></param>
		/// <returns></returns>
		public static GraphicsPath CreateRounded(Rectangle rectOuter, Rectangle rectInner)
		{
			//确保是正方形
			if (rectOuter.Width != rectOuter.Height)
				rectOuter.Height = rectOuter.Width;
			//确保是正方形
			if (rectInner.Width != rectInner.Height)
				rectInner.Height = rectInner.Width;

			int intSideLengthOuter = rectOuter.Height;
			int intSideLengthInner = rectInner.Height;

			GraphicsPath round = new GraphicsPath();

			Point ptOuterStart = new Point(rectOuter.X, rectOuter.Y + rectOuter.Height / 2);
			//round.AddArc(ptOuterStart.X, ptOuterStart.Y, intSideLengthOuter , intSideLengthOuter , 0, 360);
			round.AddArc(rectOuter, 0, 360);

			Point ptInnerStart = new Point(rectInner.X, rectInner.Y + rectInner.Height / 2);
			round.AddLine(ptOuterStart, ptInnerStart);

			round.AddArc(rectInner, 0, 360);

			return round;
		}

		/// <summary>
		/// 获得伪圆角矩形框
		/// </summary>
		/// <param Name="rect"></param>
		/// <param Name="Radius"></param>
		/// <returns></returns>
		public static GraphicsPath GetSmallRoundedRectanglePath(Rectangle rect, int Radius)
		{
			bool bolTest = false;
			GraphicsPath roundedRect = new GraphicsPath();

			//是否测试
			if (bolTest)
			{
				roundedRect.AddLine(rect.X, rect.Y + rect.Height / 2, rect.X + rect.Width / 2, rect.Y);
				roundedRect.AddLine(rect.X + rect.Width / 2, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height / 2);
				roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + rect.Height / 2, rect.X + rect.Width / 2, rect.Y + rect.Height - 1);
			}
			else
			{
				#region 正常裁角，但下面不正确

				////左上角小斜线
				//roundedRect.AddLine(rect.X + Radius, rect.Y, rect.X, rect.Y + Radius);
				////左侧竖线
				//roundedRect.AddLine(rect.X, rect.Y + Radius, rect.X, rect.Y + rect.Height - Radius - 1);
				////左下角小斜线
				//roundedRect.AddLine(rect.X, rect.Y + rect.Height - Radius - 1, rect.X + Radius, rect.Y + rect.Height - 1);
				////下边横线
				//roundedRect.AddLine(rect.X + Radius, rect.Y + rect.Height - 1, rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1);
				////右下角小斜线
				//roundedRect.AddLine(rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1, rect.X + rect.Width - 1, rect.Y + rect.Height - Radius - 1);
				////右侧竖线
				//roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + rect.Height - Radius - 1, rect.X + rect.Width - 1, rect.Y + Radius);
				////右上角小斜线
				//roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + Radius, rect.X + rect.Width - Radius - 1, rect.Y);
				//////上边横线
				////roundedRect.AddLine(rect.X + rect.Width - Radius-1, rect.Y, rect.X + Radius, rect.Y);

				#endregion

				//GraphicsPath 是右边和下边不在计算内,为了显示全部，必须得向下和向右各扩展一像素
				int intExtra = 1;

				Point pt0 = new Point(rect.X + Radius, rect.Y);
				Point pt1 = new Point(rect.X, rect.Y + Radius);
				Point pt2 = new Point(rect.X, rect.Y + rect.Height - Radius - 1);
				Point pt3 = new Point(rect.X + Radius + intExtra, rect.Y + rect.Height - 1 + intExtra);
				Point pt4 = new Point(rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1 + intExtra);
				Point pt5 = new Point(rect.X + rect.Width - 1 + intExtra, rect.Y + rect.Height - Radius - 1);
				Point pt6 = new Point(rect.X + rect.Width - 1 + intExtra, rect.Y + Radius);
				Point pt7 = new Point(rect.X + rect.Width - Radius, rect.Y);

				//左上角小斜线
				roundedRect.AddLine(pt0, pt1);
				//左侧竖线
				roundedRect.AddLine(pt1, pt2);
				//左下角小斜线
				roundedRect.AddLine(pt2, pt3);
				//下边横线
				roundedRect.AddLine(pt3, pt4);
				//右下角小斜线
				roundedRect.AddLine(pt4, pt5);
				//右侧竖线
				roundedRect.AddLine(pt5, pt6);
				//右上角小斜线
				roundedRect.AddLine(pt6, pt7);
				////上边横线
				//roundedRect.AddLine(rect.X + rect.Width - Radius-1, rect.Y, rect.X + Radius, rect.Y);
			}
			roundedRect.CloseFigure();

			return roundedRect;
		}

		public static GraphicsPath GetSmallRoundedRectanglePath2(Rectangle rect, int Radius)
		{
			bool bolTest = false;
			GraphicsPath roundedRect = new GraphicsPath();

			//是否测试
			if (bolTest)
			{
				roundedRect.AddLine(rect.X, rect.Y + rect.Height / 2, rect.X + rect.Width / 2, rect.Y);
				roundedRect.AddLine(rect.X + rect.Width / 2, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height / 2);
				roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + rect.Height / 2, rect.X + rect.Width / 2, rect.Y + rect.Height - 1);
			}
			else
			{
				#region 正常裁角，但下面不正确

				////左上角小斜线
				//roundedRect.AddLine(rect.X + Radius, rect.Y, rect.X, rect.Y + Radius);
				////左侧竖线
				//roundedRect.AddLine(rect.X, rect.Y + Radius, rect.X, rect.Y + rect.Height - Radius - 1);
				////左下角小斜线
				//roundedRect.AddLine(rect.X, rect.Y + rect.Height - Radius - 1, rect.X + Radius, rect.Y + rect.Height - 1);
				////下边横线
				//roundedRect.AddLine(rect.X + Radius, rect.Y + rect.Height - 1, rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1);
				////右下角小斜线
				//roundedRect.AddLine(rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1, rect.X + rect.Width - 1, rect.Y + rect.Height - Radius - 1);
				////右侧竖线
				//roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + rect.Height - Radius - 1, rect.X + rect.Width - 1, rect.Y + Radius);
				////右上角小斜线
				//roundedRect.AddLine(rect.X + rect.Width - 1, rect.Y + Radius, rect.X + rect.Width - Radius - 1, rect.Y);
				//////上边横线
				////roundedRect.AddLine(rect.X + rect.Width - Radius-1, rect.Y, rect.X + Radius, rect.Y);

				#endregion

				//GraphicsPath 是右边和下边不在计算内,为了显示全部，必须得向下和向右各扩展一像素
				int intExtra = 0;

				Point pt0 = new Point(rect.X + Radius, rect.Y);
				Point pt1 = new Point(rect.X, rect.Y + Radius);
				Point pt2 = new Point(rect.X, rect.Y + rect.Height - Radius - 1);
				Point pt3 = new Point(rect.X + Radius + intExtra, rect.Y + rect.Height - 1 + intExtra);
				Point pt4 = new Point(rect.X + rect.Width - Radius - 1, rect.Y + rect.Height - 1 + intExtra);
				Point pt5 = new Point(rect.X + rect.Width - 1 + intExtra, rect.Y + rect.Height - Radius - 1);
				Point pt6 = new Point(rect.X + rect.Width - 1 + intExtra, rect.Y + Radius);
				Point pt7 = new Point(rect.X + rect.Width - Radius, rect.Y);

				//左上角小斜线
				roundedRect.AddLine(pt0, pt1);
				//左侧竖线
				roundedRect.AddLine(pt1, pt2);
				//左下角小斜线
				roundedRect.AddLine(pt2, pt3);
				//下边横线
				roundedRect.AddLine(pt3, pt4);
				//右下角小斜线
				roundedRect.AddLine(pt4, pt5);
				//右侧竖线
				roundedRect.AddLine(pt5, pt6);
				//右上角小斜线
				roundedRect.AddLine(pt6, pt7);
				////上边横线
				//roundedRect.AddLine(rect.X + rect.Width - Radius-1, rect.Y, rect.X + Radius, rect.Y);
			}
			roundedRect.CloseFigure();

			return roundedRect;
		}

		/// <summary>
		/// 绘圆角矩形框
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="pen"></param>
		/// <param Name="rect"></param>
		/// <param Name="cornerRadius"></param>
		public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
			{
				g.DrawPath(pen, path);
			}
		}

		/// <summary>
		/// 绘圆角矩形框
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="pen"></param>
		/// <param Name="rect"></param>
		public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect))
			{
				g.DrawPath(pen, path);
			}
		}

		/// <summary>
		/// 绘圆角矩形框
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="pen"></param>
		/// <param Name="path"></param>
		public static void DrawRoundRectangle(Graphics g, Pen pen, GraphicsPath path)
		{
			g.DrawPath(pen, path);
		}


		/// <summary>
		/// 创建圆角矩形框,此圆角矩形框为左右两侧为半圆
		/// </summary>
		/// <param Name="rect">矩形大小</param>
		/// <returns></returns>
		public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect)
		{
			int cornerRadius = rect.Height / 2;
			GraphicsPath roundedRect = new GraphicsPath();
			roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 90, 180);
			roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
			roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 180);
			roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);

			roundedRect.CloseFigure();
			return roundedRect;
		}

		/// <summary>
		/// 单一色填充圆角矩形框,此圆角矩形框为左右两侧为半圆
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="brush">笔刷</param>
		/// <param Name="rect">矩形</param>
		public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect))
			{
				g.FillPath(brush, path);
			}
		}

		/// <summary>
		/// 单一色填充圆角矩形框,此圆角矩形框为左右两侧为半圆
		/// </summary>
		/// <param Name="g"></param>
		/// <param Name="brush"></param>
		/// <param Name="path"></param>
		public static void FillRoundRectangle(Graphics g, Brush brush, GraphicsPath path)
		{
			g.FillPath(brush, path);
		}

		/// <summary>
		/// 单一色填充圆角矩形框
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="brush">笔刷</param>
		/// <param Name="rect">矩形</param>
		/// <param Name="cornerRadius">圆角大小</param>
		public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
			{
				g.FillPath(brush, path);
			}
		}

		/// <summary>
		/// 线性填充圆角矩形框
		/// </summary>
		/// <param Name="g">绘图图面</param>
		/// <param Name="LGBrush">线性笔刷</param>
		/// <param Name="rect">矩形</param>
		/// <param Name="cornerRadius">圆角大小</param>
		public static void FillRoundRectangle(Graphics g, LinearGradientBrush LGBrush, Rectangle rect, int cornerRadius)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
			{
				g.FillPath(LGBrush, path);
			}
		}


		/// <summary>
		/// 建立带有圆角样式的路径。
		/// </summary>
		/// <param Name="rect">用来建立路径的矩形。</param>
		/// <param Name="_radius">圆角的大小。</param>
		/// <param Name="style">圆角的样式。</param>
		/// <param Name="correction">是否把矩形长宽减 1,以便画出边框。</param>
		/// <returns>建立的路径。</returns>
		public static GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
		{
			GraphicsPath path = new GraphicsPath();
			int radiusCorrection = correction ? 1 : 0;
			switch (style)
			{
				case RoundStyle.None:
					path.AddRectangle(rect);
					break;
				case RoundStyle.All:
					path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Y,
						radius,
						radius,
						270,
						90);
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius, 0, 90);
					path.AddArc(
						rect.X,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						90,
						90);
					break;
				case RoundStyle.Left:
					path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
					path.AddLine(
						rect.Right - radiusCorrection, rect.Y,
						rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
					path.AddArc(
						rect.X,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						90,
						90);
					break;
				case RoundStyle.Right:
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Y,
						radius,
						radius,
						270,
						90);
					path.AddArc(
					   rect.Right - radius - radiusCorrection,
					   rect.Bottom - radius - radiusCorrection,
					   radius,
					   radius,
					   0,
					   90);
					path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
					break;
				case RoundStyle.Top:
					path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Y,
						radius,
						radius,
						270,
						90);
					path.AddLine(
						rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
						rect.X, rect.Bottom - radiusCorrection);
					break;
				case RoundStyle.Bottom:
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						0,
						90);
					path.AddArc(
						rect.X,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						90,
						90);
					path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
					break;
				case RoundStyle.BottomLeft:
					path.AddArc(
						rect.X,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						90,
						90);
					path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
					path.AddLine(
						rect.Right - radiusCorrection,
						rect.Y,
						rect.Right - radiusCorrection,
						rect.Bottom - radiusCorrection);
					break;
				case RoundStyle.BottomRight:
					path.AddArc(
						rect.Right - radius - radiusCorrection,
						rect.Bottom - radius - radiusCorrection,
						radius,
						radius,
						0,
						90);
					path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
					path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
					break;
			}
			path.CloseFigure();

			return path;
		}


		/// <summary>
		/// 建立圆角路径的样式。
		/// </summary>
		public enum RoundStyle
		{
			/// <summary>
			/// 四个角都不是圆角。
			/// </summary>
			None = 0,
			/// <summary>
			/// 四个角都为圆角。
			/// </summary>
			All = 1,
			/// <summary>
			/// 左边两个角为圆角。
			/// </summary>
			Left = 2,
			/// <summary>
			/// 右边两个角为圆角。
			/// </summary>
			Right = 3,
			/// <summary>
			/// 上边两个角为圆角。
			/// </summary>
			Top = 4,
			/// <summary>
			/// 下边两个角为圆角。
			/// </summary>
			Bottom = 5,
			/// <summary>
			/// 左下角为圆角。
			/// </summary>
			BottomLeft = 6,
			/// <summary>
			/// 右下角为圆角。
			/// </summary>
			BottomRight = 7,
		}

		#endregion

		#region 获取注释信息

		public static A GetClassAttribute<T, A>(T TClass)
			where T : Type
			where A : Attribute
		{
			object[] objs2 = TClass.GetCustomAttributes(typeof(A), false);
			if (objs2.Length > 0)
				return objs2[0] as A;

			return null;
		}

		public static A GetPropertyAttribute<T, A>(T TClass)
			where T : Type
			where A : Attribute
		{
			PropertyInfo[] peroperties = TClass.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo property in peroperties)
			{
				object[] objs = property.GetCustomAttributes(typeof(A), false);
				if (objs.Length > 0)
					return objs[0] as A;
			}

			return null;
		}

		public static A[] GetPropertyAttributes<T, A>(T TClass)
			where T : Type
			where A : Attribute
		{
			List<A> lstA = new List<A>();
			PropertyInfo[] peroperties = TClass.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo property in peroperties)
			{
				object[] objs = property.GetCustomAttributes(typeof(A), false);
				if (objs.Length <= 0)
					continue;
				A attribute = objs[0] as A;
				lstA.Add(attribute);
			}

			return lstA.ToArray();
		}

		public static PropertyInfo GetPropertyInfo(object ClassObject, object PropertyObject)
		{
			if (ClassObject == null || PropertyObject == null)
				return null;

			Type type = ClassObject.GetType();
			PropertyInfo[] piAry = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo item in piAry)
			{
				object objPropertyValue = item.GetValue(ClassObject, null);
				if (objPropertyValue == PropertyObject)
					return item;
			}

			return null;
		}

		public static A GetFieldAttribute<T, A>(T TEnum, string FieldName)
			where T : Type
			where A : Attribute
		{
			//System.Reflection.FieldInfo[] fieldAry = TEnum.GetFields(BindingFlags.Public | BindingFlags.Instance);
			System.Reflection.FieldInfo[] fieldAry = TEnum.GetFields();
			foreach (System.Reflection.FieldInfo item in fieldAry)
			{
				if (item.Name == FieldName)
				{
					object[] objAttrAry = item.GetCustomAttributes(typeof(A), false);
					if (objAttrAry.Length > 0)
						return objAttrAry[0] as A;
				}
			}

			return null;
		}

		public static List<A> GetLstPropertyAByLstB<T, A>(List<T> lstT, string PropertyName)
			where T : class
			where A : class
		{
			List<A> lstA = new List<A>();
			foreach (T item in lstT)
			{
				Type typeItem = typeof(T);
				PropertyInfo propertyInfo = typeItem.GetProperty(PropertyName);
				A a = propertyInfo.GetValue(item, null) as A;
				lstA.Add(a);
			}

			return lstA;
		}

		#endregion

		#region 获取不重复的命名

		public static String CreateNewFileName(string DirectoryInfo, string Prefix, string Suffix)
		{
			DirectoryInfo theFolder = new DirectoryInfo(DirectoryInfo);
			FileInfo[] fileInfoAry = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
			List<FileInfo> lstFileInfo = new List<FileInfo>(fileInfoAry);
			List<string> lstName = PublicMethods.GetLstStringByLstT(lstFileInfo, "Name");
			return CreateNewName(lstName.ToArray(), Prefix, Suffix);
		}

		/// <summary>
		/// 检索指定路径，并返回可以创建的默认名称
		/// </summary>
		/// <param Name="FilePath"></param>
		/// <returns></returns>
		public static string CreateNewName(string FilePath, string Prefix, string Suffix)
		{
			List<string> lstStr = new List<string>();

			string[] fileAry = Directory.GetFiles(FilePath, "*" + Suffix);
			return CreateNewName(fileAry, Prefix, Suffix);
		}

		public static string CreateNewName(List<string> lstAry, string Prefix)
		{
			return CreateNewName(lstAry.ToArray(), Prefix, "");
		}



        public static string CreateNewName(string[] fileAry, string Prefix, string Suffix = "")
        {
            int index = CreateNewNameIndex(fileAry, Prefix, Suffix);

            return string.Format(Prefix + "{0}" + Suffix, index);
        }

        public static int CreateNewNameIndex(string[] fileAry, string Prefix, string Suffix = "")
        {
            string RegexStr;

            if (!string.IsNullOrEmpty(Suffix) && !Suffix.StartsWith("."))
                Suffix = "." + Suffix;

            if (string.IsNullOrEmpty(Suffix))
                RegexStr = "^" + Prefix + "[0-9]+";
            else
                RegexStr = "^" + Prefix + "[0-9]+" + Suffix + "$";

            List<int> lstFileNum = new List<int>();
            int intCount = 0;
            for (int i = 0; i < fileAry.Length; i++)
            {
                string fileName = Path.GetFileName(fileAry[i]);
                string[] fileNames = PublicMethods.GetResultAryByRegex(fileName, RegexStr, true);
                //如果小于或等于0，表示不满足要求
                if (fileNames.Length <= 0)
                    continue;
                int intLen = fileNames[0].Length;
                string fileNum = fileNames[0].Substring(Prefix.Length, fileNames[0].Length - Prefix.Length - Suffix.Length);
                int curValue;
                if (int.TryParse(fileNum, out curValue))
                    lstFileNum.Add(curValue);
            }

            if (lstFileNum.Count == 0)
                intCount = 1;
            else
            {
                for (int i = 0; i < lstFileNum.Count; i++)
                {
                    intCount = i + 1;
                    if (!lstFileNum.Contains(intCount))
                        break;
                    if (i == lstFileNum.Count - 1)
                        intCount++;
                }
            }

            return intCount;
        }

        #endregion

        #region 序列化与反序列化

        /// <summary>
        /// 指定除根目录下的序列化路径
        /// </summary>
        public class SerializeBinder : SerializationBinder
		{
			string dllBackUpPath;
			public SerializeBinder(string PDllBackUpPath)
			{
				dllBackUpPath = PDllBackUpPath;
			}

			public override Type BindToType(string assemblyName, string typeName)
			{
				Assembly ass;
				try
				{
					//如果从根目录加载异常，则跳转到备用路径
					ass = Assembly.Load(assemblyName);
				}
				catch (Exception)
				{
					string[] strAry = typeName.Split(new char[] { '.' });
					if (strAry.Length != 2)
						return null;
					string strFile = Path.Combine(dllBackUpPath, strAry[0] + ".dll");
					//从当前项目中找出要反射调用的文件 
					ass = Assembly.LoadFrom(strFile);
				}
				Type t = ass.GetType(typeName);
				return t;
			}
		}

		public static byte[] SerializeBinary(object obj)
		{
			MemoryStream stream = new MemoryStream();
			BinaryFormatter frmt = new BinaryFormatter();
			frmt.Serialize(stream, obj);

			byte[] bb = stream.ToArray();

			stream.Close();
			return bb;
		}

		public static object DeSerializeBinary(byte[] byteAry)
		{
			MemoryStream stream = new MemoryStream(byteAry);
			BinaryFormatter frmt = new BinaryFormatter();
			return frmt.Deserialize(stream);
		}

		public static void SerializeBinary<T>(T c, string file, out string Err)
		{
			Err = "";
			if (!File.Exists(file))
				File.Delete(file);
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(file, FileMode.Create);
				BinaryFormatter b = new BinaryFormatter();
				b.Serialize(fileStream, c);
			}
			catch (Exception ex)
			{
				Err = "SerializeBinary" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
		}

		public static T DeSerializeBinary<T>(string file, out string Err) where T : class
		{
			return DeSerializeBinary<T>(file, "", out Err);
		}

		public static T DeSerializeBinary<T>(string file, string DllBackUpPath, out string Err) where T : class
		{
			Err = "";
			T c = null;
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryFormatter b = new BinaryFormatter();
				if (!string.IsNullOrEmpty(DllBackUpPath))
					b.Binder = new SerializeBinder(DllBackUpPath);
				c = b.Deserialize(fileStream) as T;
				fileStream.Close();
			}
			catch (Exception ex)
			{
				Err = "DeSerializeBinary" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}

			return c;
		}

		public static void SerializeSoap<T>(T c, string file, out string Err)
		{
			Err = "";
			if (!File.Exists(file))
				File.Delete(file);
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(file, FileMode.Create);
				SoapFormatter b = new SoapFormatter();
				b.Serialize(fileStream, c);
			}
			catch (Exception ex)
			{
				Err = "SerializeSoap" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
		}
		public static T DeSerializeSoap<T>(string file, out string Err) where T : class
		{
			return DeSerializeSoap<T>(file, "", out Err);
		}
		public static T DeSerializeSoap<T>(string file, string DllBackUpPath, out string Err) where T : class
		{
			Err = "";
			T c = null;
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
				SoapFormatter b = new SoapFormatter();
				if (!string.IsNullOrEmpty(DllBackUpPath))
					b.Binder = new SerializeBinder(DllBackUpPath);
				c = b.Deserialize(fileStream) as T;
			}
			catch (Exception ex)
			{
				Err += "DeSerializeSoap" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}

			return c;
		}

		public static void SerializeXml<T>(T c, string file, out string Err)
		{
			Err = "";
			if (!File.Exists(file))
				File.Delete(file);
			FileStream fileStream = null;
			try
			{
				XmlSerializer xs = new XmlSerializer(c.GetType());
				fileStream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read);
				xs.Serialize(fileStream, c);
			}
			catch (Exception ex)
			{
				Err = "SerializeXml" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
		}
		public static T DeserializeXml<T>(string file, out string Err) where T : class
		{
			Err = "";
			T c = null;
			FileStream fileStream = null;
			try
			{
				XmlSerializer xs = new XmlSerializer(typeof(T));

				fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
				c = xs.Deserialize(fileStream) as T;
			}
			catch (Exception ex)
			{
				Err = "DeserializeXml" + ex.Message;
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}

			return c;
		}

		#endregion

		#region 两个对象继承了一个共同接口，则用一个对象给另一个对象赋值

		public void SetProperties<T>(T source, T target)
		{
			Type type = typeof(T);
			PropertyInfo[] piAry = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo pi in piAry)
			{
				object objValue = pi.GetValue(source, null);
				pi.SetValue(target, objValue, null);
			}
		}

		#endregion

		public static Dictionary<string, string> GetDictByDataTable(DataTable dt, string propertyKey, string propertyValue)
		{
			Dictionary<string, string> dictTable = new Dictionary<string, string>();
			if (dt.Columns.Contains(propertyKey) == false || dt.Columns.Contains(propertyValue) == false)
				return dictTable;
			foreach (DataRow dr in dt.Rows)
			{
				string key = dr[propertyKey].ToString();
				string value = dr[propertyValue].ToString();

				if (dictTable.ContainsKey(key) == false)
					dictTable.Add(key, value);
			}

			return dictTable;
		}

		public static Dictionary<string, string> GetDictByLstT<T>(IEnumerable<T> LstT, string propertyKey, string propertyValue) where T : class
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			MemberInfo[] miAryKey = null;
			MemberInfo[] miAryValue = null;

			string key = null, value = null;
			foreach (T item in LstT)
			{
				if (miAryKey == null)
					miAryKey = item.GetType().GetMember(propertyKey);
				if (miAryValue == null)
					miAryValue = item.GetType().GetMember(propertyValue);
				if (miAryKey.Length <= 0 || miAryValue.Length <= 0)
					continue;
				switch (miAryKey[0].MemberType)
				{
					case MemberTypes.Field:
						key = ((System.Reflection.FieldInfo)miAryKey[0]).GetValue(item).ToString();
						break;
					case MemberTypes.Property:
						PropertyInfo pi = (PropertyInfo)miAryKey[0];
						object obj = pi.GetValue(item, null);
						if (obj != null)
							key = obj.ToString();
						break;
				}

				switch (miAryValue[0].MemberType)
				{
					case MemberTypes.Field:
						value = ((System.Reflection.FieldInfo)miAryValue[0]).GetValue(item).ToString();
						break;
					case MemberTypes.Property:
						PropertyInfo pi = (PropertyInfo)miAryValue[0];
						object obj = pi.GetValue(item, null);
						if (obj != null)
							value = obj.ToString();
						break;
				}

				if (key == null)
					continue;

				dict.Add(key, value);
			}

			return dict;
		}

		public static string GetStringByLstT<T>(IEnumerable<T> LstT, string PropertyName, string SplitString, string Delimiter) where T : class
		{
			string resultStr = null;
			MemberInfo[] miAry = null;

			foreach (T item in LstT)
			{
				string strValue = null;
				if (miAry == null)
					miAry = item.GetType().GetMember(PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
				if (miAry.Length <= 0)
					continue;
				switch (miAry[0].MemberType)
				{
					case MemberTypes.Field:
						strValue = ((System.Reflection.FieldInfo)miAry[0]).GetValue(item).ToString();
						break;
					case MemberTypes.Property:
						PropertyInfo pi = (PropertyInfo)miAry[0];
						object obj = pi.GetValue(item, null);
						if (obj != null)
							strValue = obj.ToString();
						break;
				}

				if (!string.IsNullOrEmpty(strValue))
				{
					if (!string.IsNullOrEmpty(resultStr))
						resultStr += SplitString;
					resultStr += Delimiter + strValue + Delimiter;
				}
			}

			return resultStr;
		}

		//获取某类型对象中的某个属性值队列
		public static List<string> GetLstStringByLstT<T>(IEnumerable<T> LstT, string PropertyName) where T : class
		{
			List<string> lstResult = new List<string>();
			if (LstT == null)
				return lstResult;

			MemberInfo[] miAry = null;

			foreach (T item in LstT)
			{
				string strValue;
				if (miAry == null)
					miAry = item.GetType().GetMember(PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
				if (miAry.Length <= 0)
					continue;
				switch (miAry[0].MemberType)
				{
					case MemberTypes.Field:
						strValue = ((System.Reflection.FieldInfo)miAry[0]).GetValue(item).ToString();
						lstResult.Add(strValue);
						break;
					case MemberTypes.Property:
						PropertyInfo pi = (PropertyInfo)miAry[0];
						object obj = pi.GetValue(item, null);
						if (obj != null)
						{
							strValue = obj.ToString();
							lstResult.Add(strValue);
						}
						break;
				}
			}

			return lstResult;
		}

		public static List<string> GetLstStringByDataRowAry(DataRow[] rowAry, string ColumnName)
		{
			List<string> lstStr = new List<string>();
			if (rowAry.Length <= 0)
				return lstStr;
			if (rowAry[0].Table.Columns.Contains(ColumnName) == false)
				return lstStr;
			foreach (DataRow dr in rowAry)
				lstStr.Add(dr[ColumnName].ToString());

			return lstStr;
		}

		public static List<double> GetLstDoubleByDataTable(DataTable dt, string fieldName)
		{
			List<double> lstStr = new List<double>();
			if (!dt.Columns.Contains(fieldName))
				return lstStr;

			foreach (DataRow dr in dt.Rows)
			{
				if (dr[fieldName] != DBNull.Value)
					lstStr.Add(dr[fieldName].ToDouble());
			}

			return lstStr;
		}

		public static List<string> GetLstStringByDataTable(DataTable dt, string fieldName)
		{
			List<string> lstStr = new List<string>();
			if (!dt.Columns.Contains(fieldName))
				return lstStr;

			foreach (DataRow dr in dt.Rows)
			{
				if (dr[fieldName] != DBNull.Value)
					lstStr.Add(dr[fieldName].ToString());
			}

			return lstStr;
		}

		public static List<string> GetLstDistinct(List<string> lstExist)
		{
			List<string> lstDistinct = new List<string>();
			foreach (string item in lstExist)
			{
				if (lstDistinct.Contains(item) == false)
					lstDistinct.Add(item);
			}

			return lstDistinct;
		}

		public static bool Contains(List<string> lstParent, List<string> lstChild)
		{
			foreach (string item in lstChild)
			{
				if (lstParent.Contains(item) == false)
					return false;
			}

			return true;
		}

		public static Dictionary<string, T> GetLstAttributeByObject<T>(object selectedObject) where T : Attribute
		{
			Dictionary<string, T> dictAttributes = new Dictionary<string, T>();

			Type type = selectedObject.GetType();
			PropertyInfo[] propertyInfoAry = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

			foreach (PropertyInfo item in propertyInfoAry)
			{
				if (item.IsDefined(typeof(T), true))
				{
					object[] attributes = item.GetCustomAttributes(typeof(T), true);
					T hWBrosableAttibute = (T)attributes[0];
					dictAttributes.Add(item.Name, hWBrosableAttibute);
				}
			}

			return dictAttributes;
		}

		public static T GetAttribute<T>(ICustomAttributeProvider CAP) where T : Attribute
		{
			object[] objAry = CAP.GetCustomAttributes(typeof(T), false);
			if (objAry == null || objAry.Length <= 0)
				return null;
			return objAry[0] as T;
		}

		public static string GetStringByLstObject<T>(List<T> LstStr)
		{
			string str = "";
			foreach (T item in LstStr)
			{
				if (!string.IsNullOrEmpty(str))
					str += ",";
				str += item.ToString();
			}

			return str;
		}

		public static string GetStringByLstString(List<string> LstStr)
		{
			string str = "";
			foreach (string item in LstStr)
			{
				if (!string.IsNullOrEmpty(str))
					str += ",";
				str += item;
			}

			return str;
		}

		public static List<string> GetLstStringByLstANotContainLstB(List<string> lstA, List<string> lstB)
		{
			List<string> lstC = new List<string>();
			foreach (string item in lstA)
			{
				if (lstB.Contains(item) == false)
					lstC.Add(item);
			}

			return lstC;
		}

		public static string GetStringByObjectArray(object[] objArray, string SplitString)
		{
			return GetStringByObjectArray(objArray, SplitString, "");
		}

		public static string GetStringByObjectArray(object[] objArray, string SplitString, string Delimiter)
		{
			string resultStr = "";
			foreach (object item in objArray)
			{
				if (item == null)
					continue;
				if (!string.IsNullOrEmpty(resultStr))
					resultStr += SplitString;
				resultStr += Delimiter + item.ToString() + Delimiter;
			}
			return resultStr;
		}

		public static List<string> GetLstStringByString(string str)
		{
			string[] strAry = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			List<string> lstStr = new List<string>(strAry);

			return lstStr;
		}

		public static bool EqualFileName(string FileName1, string FileName2)
		{
			FileInfo fileInfo1 = new FileInfo(FileName1);
			FileInfo fileInfo2 = new FileInfo(FileName2);
			return fileInfo1.FullName.ToUpper().Trim().Equals(fileInfo2.FullName.ToUpper().Trim());

			
		}

		/// <summary>
		/// 深度克隆
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T DeepClone<T>(T obj)
		{
			try
			{
				using (var ms = new System.IO.MemoryStream())
				{
					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
						new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					bf.Serialize(ms, obj);
					ms.Position = 0;
					return (T)bf.Deserialize(ms);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("未添加序列化标识：" + ex.Message);
			}

			return default(T);
		}

		public static string CreateComponentName(IContainer container, Type type)
		{
			if (container == null)
				return "";
			ComponentCollection cc = container.Components;
			int min = Int32.MaxValue;
			int max = Int32.MinValue;
			int count = 0;

			for (int i = 0; i < cc.Count; i++)
			{
				Component comp = cc[i] as Component;
				if (comp == null)
					continue;
				//如果类型一样
				if (comp.GetType() == type)
				{
					//计数器累加1
					count++;
					//获取组件名称
					string name = comp.Site.Name;
					//如果组件名称和类型名称开头一样 如Form2同Form一样
					if (name.StartsWith(type.Name))
					{
						try
						{
							//获取序号
							int value = Int32.Parse(name.Substring(type.Name.Length));

							if (value < min)
								min = value;

							if (value > max)
								max = value;
						}
						catch (Exception ex)
						{
							throw new Exception("为组件起名错误：" + ex.Message);
							//Trace.WriteLine(ex.ToString());
						}
					}
				}
			}// for

			if (count == 0)
				return type.Name + "1";
			else if (min > 1)
			{
				int j = min - 1;
				return type.Name + j.ToString();
			}
			else
			{
				int j = max + 1;
				return type.Name + j.ToString();
			}
		}

		/// <summary>
		/// 转义字符串中所有正则特殊字符
		/// </summary>
		/// <param name="input">传入字符串</param>
		/// <returns></returns>
		public static string FilterString(string input)
		{
			input = input.Replace("\\", "\\\\");//先替换“\”，不然后面会因为替换出现其他的“\”
			Regex r = new Regex("[\'\"]");
			MatchCollection ms = r.Matches(input);
			List<string> list = new List<string>();
			foreach (Match item in ms)
			{
				if (list.Contains(item.Value))
					continue;
				input = input.Replace(item.Value, "\\" + item.Value);
				list.Add(item.Value);
			}
			return input;
		}

		/// <summary>
		/// 获取文件唯一标识
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string GetMD5FromFile(string fileName)
		{
			FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
			try
			{
				System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] retVal = md5.ComputeHash(file);

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < retVal.Length; i++)
				{
					// sb.Append(retVal[i].ToString("x2"));
					sb.Append(String.Format("{0:X1}", retVal[i]));
				}
				return sb.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				file.Close();
			}

		}

		public static int IndexOf<T>(IEnumerable IEnumerable, T Item)
		{
			IEnumerator enumerator = IEnumerable.GetEnumerator();
			int index = -1;
			while (enumerator.MoveNext())
			{
				index++;
				if (enumerator.Current.Equals(Item))
					return index;
			}

			enumerator.Reset();

			return index;
		}

		public static void RemoveList(IList List, int Start, int End)
		{
			if (End < Start)
				return;
			if (Start >= List.Count)
				return;
			if (Start < 0)
				Start = 0;
			if (End >= List.Count)
				End = List.Count - 1;

			for (int i = End; i >= Start; i--)
				List.RemoveAt(i);
		}

		public static int[] ArraySort(int[] array)
		{
			int temp;
			bool noSwap = true;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[i] > array[j])
					{
						temp = array[i];
						array[i] = array[j];
						array[j] = temp;
						noSwap = false;
					}
				}
				if (noSwap) return array;//没有再发生交换，排序结束
				else noSwap = true;
			}
			return array;
		}

		public static object GetPropertyValue(object obj, string propertyName)
		{
			if (obj == null)
				return "";

			//PropertyInfo pi = GetTargetProperty(obj, propertyName);
			PropertyInfo pi = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
			if (pi == null)
				return "";
			return pi.GetValue(obj, null);
		}

		public static object GetFieldValue(object obj, string fieldName)
		{
			if (obj == null)
				return "";

			FieldInfo pi = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
			if (pi == null)
				return "";
			return pi.GetValue(obj);
		}

		private static PropertyInfo GetTargetProperty(object obj, string propertyName)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo property in properties)
			{
				if (property.Name.ToUpper() == propertyName.ToUpper())
				{
					return property;
				}
			}
			return null;
		}

		public void SetPropertyValue<T>(T t, string propertyName, object propertyValue)
		{
			PropertyInfo pi = typeof(T).GetProperty(propertyName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
			if (pi != null)
				pi.SetValue(t, propertyValue, null);
		}

		#region InvokeWebService

		//动态调用web服务
		public static object InvokeWebService(string url, string methodname, object[] args)
		{
			return InvokeWebService(url, null, methodname, args);
		}


		public static object GetWebServiceInstance(string url, string classname)
		{
			if (url == null)
				return null;

			string @namespace = "HWVDynamicWebServiceCalling";
			if ((classname == null) || (classname == ""))
			{
				classname = GetWsClassName(url);
			}

			try
			{
				//获取WSDL
				WebClient wc = new WebClient();
				Stream stream = wc.OpenRead(url + "?WSDL");
				ServiceDescription sd = ServiceDescription.Read(stream);
				ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
				sdi.AddServiceDescription(sd, "", "");
				CodeNamespace cn = new CodeNamespace(@namespace);

				//生成客户端代理类代码
				CodeCompileUnit ccu = new CodeCompileUnit();
				ccu.Namespaces.Add(cn);
				sdi.Import(cn, ccu);
				CSharpCodeProvider csc = new CSharpCodeProvider();
				//ICodeCompiler icc = csc.CreateCompiler();

				//设定编译参数
				CompilerParameters cplist = new CompilerParameters();
				cplist.GenerateExecutable = false;
				cplist.GenerateInMemory = true;
				cplist.ReferencedAssemblies.Add("System.dll");
				cplist.ReferencedAssemblies.Add("System.XML.dll");
				cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
				cplist.ReferencedAssemblies.Add("System.Data.dll");

				//编译代理类
				CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);// icc.CompileAssemblyFromDom(cplist, ccu);
				if (true == cr.Errors.HasErrors)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
					{
						sb.Append(ce.ToString());
						sb.Append(System.Environment.NewLine);
					}
					throw new Exception(sb.ToString());
				}

				//生成代理实例，并调用方法
				System.Reflection.Assembly assembly = cr.CompiledAssembly;
				Type t = assembly.GetType(@namespace + "." + classname, true, true);
				return Activator.CreateInstance(t);
			}
			catch (Exception ex)
			{
				//throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
				throw new Exception("获取动态web服务调用的类的类型失败：" + ex.Message);
			}
		}

		//public static MethodInfo[] GetWebServiceTypeMethods(Type type, string methodname, object[] args)
		//{
		//    try
		//    {
		//        object obj = Activator.CreateInstance(type);
		//        MethodInfo[] miAry = type.GetMethods(methodname);
		//        return miAry.Invoke(obj, args);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
		//    }
		//}


		public static object InvokeWebService(Type type, string methodname, object[] args)
		{
			try
			{
				object obj = Activator.CreateInstance(type);
				System.Reflection.MethodInfo mi = type.GetMethod(methodname);
				if (mi == null)
					throw new Exception("未找到方法名：" + methodname);
				return mi.Invoke(obj, args);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
			}
		}

		public static object InvokeWebService(string url, string classname, string methodname, object[] args)
		{
			string @namespace = "HWVDynamicWebServiceCalling";
			if ((classname == null) || (classname == ""))
			{
				classname = GetWsClassName(url);
			}

			try
			{
				//获取WSDL
				WebClient wc = new WebClient();
				Stream stream = wc.OpenRead(url + "?WSDL");
				ServiceDescription sd = ServiceDescription.Read(stream);
				ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
				sdi.AddServiceDescription(sd, "", "");
				CodeNamespace cn = new CodeNamespace(@namespace);

				//生成客户端代理类代码
				CodeCompileUnit ccu = new CodeCompileUnit();
				ccu.Namespaces.Add(cn);
				sdi.Import(cn, ccu);
				CSharpCodeProvider csc = new CSharpCodeProvider();
				//ICodeCompiler icc = csc.CreateCompiler();

				//设定编译参数
				CompilerParameters cplist = new CompilerParameters();
				cplist.GenerateExecutable = false;
				cplist.GenerateInMemory = true;
				cplist.ReferencedAssemblies.Add("System.dll");
				cplist.ReferencedAssemblies.Add("System.XML.dll");
				cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
				cplist.ReferencedAssemblies.Add("System.Data.dll");

				//编译代理类
				CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);// icc.CompileAssemblyFromDom(cplist, ccu);
				if (true == cr.Errors.HasErrors)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
					{
						sb.Append(ce.ToString());
						sb.Append(System.Environment.NewLine);
					}
					throw new Exception(sb.ToString());
				}

				//生成代理实例，并调用方法
				System.Reflection.Assembly assembly = cr.CompiledAssembly;
				Type t = assembly.GetType(@namespace + "." + classname, true, true);
				object obj = Activator.CreateInstance(t);
				System.Reflection.MethodInfo mi = t.GetMethod(methodname);
				if (mi == null)
					throw new Exception("未找到方法名：" + methodname);
				return mi.Invoke(obj, args);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
			}
		}

		private static string GetWsClassName(string wsUrl)
		{
			string[] parts = wsUrl.Split('/');
			string[] pps = parts[parts.Length - 1].Split('.');

			return pps[0];
		}
		#endregion

		#region 系统已安装了哪些 .NET Framework 版本

		//系统已安装了哪些 .NET Framework 版本
		public static void GetVersionFromRegistry()
		{
			using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
				RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
			{
				foreach (string versionKeyName in ndpKey.GetSubKeyNames())
				{
					if (versionKeyName.StartsWith("v"))
					{

						RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
						string name = (string)versionKey.GetValue("Version", "");
						string sp = versionKey.GetValue("SP", "").ToString();
						string install = versionKey.GetValue("Install", "").ToString();
						if (install == "") //no install info, must be later.
							Console.WriteLine(versionKeyName + " " + name);
						else
						{
							if (sp != "" && install == "1")
							{
								Console.WriteLine(versionKeyName + " " + name + " SP" + sp);
							}

						}
						if (name != "")
						{
							continue;
						}
						foreach (string subKeyName in versionKey.GetSubKeyNames())
						{
							RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
							name = (string)subKey.GetValue("Version", "");
							if (name != "")
								sp = subKey.GetValue("SP", "").ToString();
							install = subKey.GetValue("Install", "").ToString();
							if (install == "") //no install info, must be later.
								Console.WriteLine(versionKeyName + " " + name);
							else
							{
								if (sp != "" && install == "1")
								{
									Console.WriteLine(" " + subKeyName + " " + name + " SP" + sp);
								}
								else if (install == "1")
								{
									Console.WriteLine(" " + subKeyName + " " + name);
								}

							}

						}

					}
				}
			}

		}


		#endregion

		/// <summary>
		/// 实现数据的四舍五入法
		/// </summary>
		/// <param name="v">要进行处理的数据</param>
		/// <param name="x">保留的小数位数</param>
		/// <returns>四舍五入后的结果</returns>
		public static double Round(double v, int x)
		{
			if (double.IsNaN(v))
				return 0;
			try
			{
				if (v.ToString().Contains("+")) { return (int)v; }
				double dbl = (double)Math.Round((decimal)v, x, MidpointRounding.AwayFromZero);
				if (x <= 0)
					return (int)dbl;
				return dbl;
			}
			catch (Exception)
			{
				return (int)v;
			}

		}

		//获取过滤后的数据表
		public static DataTable GetDataTableBySearchSql(DataTable dt, string searchSql, bool remainOrDelete)
		{

			DataRow[] drAry = dt.Select(searchSql);
			for (int i = dt.Rows.Count - 1; i >= 0; i--)
			{
				DataRow dr = dt.Rows[i];
				if (remainOrDelete)
				{
					if (!drAry.Contains(dr))
						dt.Rows.RemoveAt(i);
				}
				else
				{
					if (drAry.Contains(dr))
						dt.Rows.RemoveAt(i);
				}
			}

			return dt;
		}

		public static List<string> ToLower(List<string> lstStr)
		{
			List<string> lstResult = new List<string>();
			foreach (string item in lstStr)
			{
				lstResult.Add(item.ToLower());
			}

			return lstResult;
		}

		public static int GetMonthDiffAbsolute(DateTime dtA, DateTime dtB)
		{
			int result = GetMonthDiff(dtA, dtB);
			return Math.Abs(result);
		}

		public static int GetMonthDiff(DateTime dtMax, DateTime dtMin)
		{
			int years = dtMax.Year - dtMin.Year;
			int months = dtMax.Month - dtMin.Month;

			return years * 12 + months;
		}


		public static double GetYearDiff(DateTime dtNYMax, DateTime dtNYMin)
		{
			int monthSum = GetMonthDiffAbsolute(dtNYMax, dtNYMin) + 1;
			int years1 = monthSum / 12;
			int months1 = monthSum % 12;

			return years1 + months1 * 1.0 / 12;
		}

		public static string[] GetTableKeyAry(DataTable dt)
		{
			List<string> lstKeyName = new List<string>();
			foreach (DataColumn item in dt.PrimaryKey)
			{
				lstKeyName.Add(item.ColumnName);
			}

			return lstKeyName.ToArray();
		}

		//static string[] DateStringAry = {   "yyyy", 
		//                                    "yyyy/MM", "yyyy-MM", "yyyyMM",
		//                                    "yyyy/M", "yyyy-M", "yyyyM",
		//                                    "MM/yyyy","MM-yyyy","MMyyyy",
		//                                    "M/yyyy", "M-yyyy", "Myyyy",
		//                                    "yyyy/MM/dd", "yyyy-MM-dd", "yyyyMMdd", 
		//                                    "yyyy/M/d", "yyyy-M-d", "yyyyMd", 
		//                                    "MM/dd/yyyy", "MM-dd-yyyy", "MMddyyyy",
		//                                    "M/d/yyyy", "M-d-yyyy", "Mdyyyy",
		//                                    "dd/MM/yyyy","dd-MM-yyyy","ddMMyyyy",
		//                                    "d/M/yyyy","d-M-yyyy","dMyyyy",
		//                                    };

		//根据出现的可能性排序
		static string[] DateStringAry = {   
                                            "yyyyMM",
                                            "yyyy/MM/dd",
                                            "yyyy/MM",
                                            "yyyy", 
                                             "yyyy-MM", 
                                            "yyyy/M", "yyyy-M", "yyyyM",
                                            "MM/yyyy","MM-yyyy","MMyyyy",
                                            "M/yyyy", "M-yyyy", "Myyyy",
                                             "yyyy-MM-dd", "yyyyMMdd", 
                                            "yyyy/M/d", "yyyy-M-d", "yyyyMd", 
                                            "MM/dd/yyyy", "MM-dd-yyyy", "MMddyyyy",
                                            "M/d/yyyy", "M-d-yyyy", "Mdyyyy",
                                            "dd/MM/yyyy","dd-MM-yyyy","ddMMyyyy",
                                            "d/M/yyyy","d-M-yyyy","dMyyyy",
                                            };
		public static bool TryParseExact(string commonNY, out DateTime rightNY)
		{
			rightNY = DateTime.Now;
			if (DateTime.TryParseExact(commonNY, DateStringAry, null, DateTimeStyles.None, out rightNY))
				return true;
			return false;
		}

		public static int CompareTo(double x, double y, int Precision)
		{
			double xx = PublicMethods.Round(x, Precision);
			double yy = PublicMethods.Round(y, Precision);

			if (xx > yy)
				return 1;
			else if (xx == yy)
				return 0;
			else
				return -1;
		}

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

        #region Sql 的 in 处理

        public static string GetSqlPartByLike(string keyWord, List<string> displayItems)
        {
            string sqlPart = null;
            string connectedStr = "or ";

            StringBuilder sb = new StringBuilder();
            displayItems.ForEach(x => sb.Append($" {x} like '%{keyWord}%' or"));
            sb.Remove(sb.Length - connectedStr.Length, connectedStr.Length);

            if (displayItems.Count > 0)
            {
                sqlPart = "and ";
                if (displayItems.Count == 1)
                    sqlPart = $"{sqlPart} {sb.ToString()}";
                else
                    sqlPart = $"{sqlPart} ({sb.ToString()})";
            }

            return sqlPart;
        }

        public static string GetSqlPartByIn(string fieldName, List<string> lstFieldValues, bool isIn)
		{
			int manyTimes = 0;
			int inCount = 500;
			StringBuilder sb = new StringBuilder();
			if (lstFieldValues == null || lstFieldValues.Count <= 0)
				return "";

			SubGetSqlPartStr(fieldName, lstFieldValues, isIn, manyTimes, inCount, ref sb);
			string result = "";
			if (lstFieldValues.Count > inCount)
				result += "(" + sb.ToString() + ")";
			else
				result = sb.ToString();

			return result;
		}

		private static void SubGetSqlPartStr(string fieldName, List<string> lstFieldValues, bool isIn, int manyTimes, int inCount, ref StringBuilder sb)
		{
			bool isOver = false;
			List<string> lstFieldValuesPart = new List<string>();
			for (int i = manyTimes * inCount; i < (manyTimes + 1) * inCount; i++)
			{
				if (lstFieldValues.Count <= i)
				{
					isOver = true;
					break;
				}

				lstFieldValuesPart.Add(lstFieldValues[i]);
			}
			string strFieldValues = PublicMethods.GetStringByObjectArray(lstFieldValuesPart.ToArray(), ",", "'");

			if (sb.Length > 0)
				sb.Append(" or ");
			sb.Append(fieldName);
			if (isIn)
				sb.Append(" in(");
			else
				sb.Append(" not in(");
			sb.Append(strFieldValues);
			sb.Append(")");

			manyTimes++;
			if (isOver)
				return;

			SubGetSqlPartStr(fieldName, lstFieldValues, isIn, manyTimes, inCount, ref sb);
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

		public static Color GetAntiColor(Color clr)
		{
			return Color.FromArgb(255 - clr.R, 255 - clr.G, 255 - clr.B);
		}

		//灰色处理
		public static Bitmap SetGray(Bitmap bitmap)
		{
			//定义锁定bitmap的rect的指定范围区域
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

			//加锁区域像素
			var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

			//位图的首地址
			var ptr = bitmapData.Scan0;

			//stride：扫描行
			int len = bitmapData.Stride * bitmap.Height;

			var bytes = new byte[len];

			//锁定区域的像素值copy到byte数组中
			Marshal.Copy(ptr, bytes, 0, len);

			for (int i = 0; i < bitmap.Height; i++)
			{
				for (int j = 0; j < bitmap.Width * 3; j = j + 3)
				{
					var color = bytes[i * bitmapData.Stride + j + 2] * 0.299
						  + bytes[i * bitmapData.Stride + j + 1] * 0.597
						  + bytes[i * bitmapData.Stride + j] * 0.114;

					bytes[i * bitmapData.Stride + j]
						 = bytes[i * bitmapData.Stride + j + 1]
						 = bytes[i * bitmapData.Stride + j + 2] = (byte)color;
				}
			}

			//copy回位图
			Marshal.Copy(bytes, 0, ptr, len);

			//解锁
			bitmap.UnlockBits(bitmapData);

			return bitmap;
		}

		/// <summary>
		/// 要比对的数值compare
		/// </summary>
		/// <param name="compare">要比对的数值</param>
		/// <param name="var1">参照数值1</param>
		/// <param name="var2">参照数值2</param>
		/// <param name="nearBefore">接近前一个值，还是接近后一个值，仅方法返回falase时有效</param>
		/// <returns></returns>
		public static bool IsBetweenVar1AndVar2(double compare, double var1, double var2, out bool nearBefore)
		{
			nearBefore = false;
			double max, min;

			if (var1 > var2)
			{
				max = var1;
				min = var2;
			}
			else
			{
				max = var2;
				min = var1;
			}

			if (compare > max)
			{
				if (max == var1)
					nearBefore = true;
				else
					nearBefore = false;
				return false;
			}

			if (compare < min)
			{
				if (min == var1)
					nearBefore = true;
				else
					nearBefore = false;
				return false;
			}

			return true;

		}

		public static List<T> RemoveSameElement<T>(List<T> lstSource)
		{
			List<T> lstTarget = new List<T>();
			foreach (T item in lstSource)
			{
				if (lstTarget.Contains(item))
					continue;
				lstTarget.Add(item);
			}

			return lstTarget;
		}

		#region 拼音

		/// <summary> 
		/// 在指定的字符串列表CnStr中检索符合拼音索引字符串 
		/// </summary> 
		/// <param name="CnStr">汉字字符串</param> 
		/// <returns>相对应的汉语拼音首字母串</returns> 
		public static string GetSpellCode(string CnStr)
		{
			string strTemp = "";
			int iLen = CnStr.Length;
			int i = 0;

			for (i = 0; i <= iLen - 1; i++)
			{
				strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
			}

			return strTemp;
		}

		/// <summary> 
		/// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
		/// </summary> 
		/// <param name="CnChar">单个汉字</param> 
		/// <returns>单个大写字母</returns> 
		private static string GetCharSpellCode(string CnChar)
		{
			long iCnChar;

			byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

			//如果是字母，则直接返回 
			if (ZW.Length == 1)
			{
				return CnChar.ToUpper();
			}
			else
			{
				// get the array of byte from the single char 
				int i1 = (short)(ZW[0]);
				int i2 = (short)(ZW[1]);
				iCnChar = i1 * 256 + i2;
			}

			//expresstion 
			//table of the constant list 
			// 'A'; //45217..45252 
			// 'B'; //45253..45760 
			// 'C'; //45761..46317 
			// 'D'; //46318..46825 
			// 'E'; //46826..47009 
			// 'F'; //47010..47296 
			// 'G'; //47297..47613 

			// 'H'; //47614..48118 
			// 'J'; //48119..49061 
			// 'K'; //49062..49323 
			// 'L'; //49324..49895 
			// 'M'; //49896..50370 
			// 'N'; //50371..50613 
			// 'O'; //50614..50621 
			// 'P'; //50622..50905 
			// 'Q'; //50906..51386 

			// 'R'; //51387..51445 
			// 'S'; //51446..52217 
			// 'T'; //52218..52697 
			//没有U,V 
			// 'W'; //52698..52979 
			// 'X'; //52980..53640 
			// 'Y'; //53689..54480 
			// 'Z'; //54481..55289 

			// iCnChar match the constant 
			if ((iCnChar >= 45217) && (iCnChar <= 45252))
			{
				return "A";
			}
			else if ((iCnChar >= 45253) && (iCnChar <= 45760))
			{
				return "B";
			}
			else if ((iCnChar >= 45761) && (iCnChar <= 46317))
			{
				return "C";
			}
			else if ((iCnChar >= 46318) && (iCnChar <= 46825))
			{
				return "D";
			}
			else if ((iCnChar >= 46826) && (iCnChar <= 47009))
			{
				return "E";
			}
			else if ((iCnChar >= 47010) && (iCnChar <= 47296))
			{
				return "F";
			}
			else if ((iCnChar >= 47297) && (iCnChar <= 47613))
			{
				return "G";
			}
			else if ((iCnChar >= 47614) && (iCnChar <= 48118))
			{
				return "H";
			}
			else if ((iCnChar >= 48119) && (iCnChar <= 49061))
			{
				return "J";
			}
			else if ((iCnChar >= 49062) && (iCnChar <= 49323))
			{
				return "K";
			}
			else if ((iCnChar >= 49324) && (iCnChar <= 49895))
			{
				return "L";
			}
			else if ((iCnChar >= 49896) && (iCnChar <= 50370))
			{
				return "M";
			}

			else if ((iCnChar >= 50371) && (iCnChar <= 50613))
			{
				return "N";
			}
			else if ((iCnChar >= 50614) && (iCnChar <= 50621))
			{
				return "O";
			}
			else if ((iCnChar >= 50622) && (iCnChar <= 50905))
			{
				return "P";
			}
			else if ((iCnChar >= 50906) && (iCnChar <= 51386))
			{
				return "Q";
			}
			else if ((iCnChar >= 51387) && (iCnChar <= 51445))
			{
				return "R";
			}
			else if ((iCnChar >= 51446) && (iCnChar <= 52217))
			{
				return "S";
			}
			else if ((iCnChar >= 52218) && (iCnChar <= 52697))
			{
				return "T";
			}
			else if ((iCnChar >= 52698) && (iCnChar <= 52979))
			{
				return "W";
			}
			else if ((iCnChar >= 52980) && (iCnChar <= 53640))
			{
				return "X";
			}
			else if ((iCnChar >= 53689) && (iCnChar <= 54480))
			{
				return "Y";
			}
			else if ((iCnChar >= 54481) && (iCnChar <= 55289))
			{
				return "Z";
			}
			else return ("?");
		}

		#endregion

		public static bool Contains(DataRow dr, List<string> lstExcludeColumn, string findStr)
		{
			foreach (DataColumn dc in dr.Table.Columns)
			{
				if (lstExcludeColumn.Contains(dc.ColumnName.ToLower()))
					continue;
				if (dr[dc.ColumnName] == DBNull.Value)
					continue;
				string drValue = dr[dc.ColumnName].ToString();
				if (drValue.Contains(findStr))
					return true;
			}

			return false;
		}

		public static Process GetAnotherProcessWithSameName(Process curProcess)
		{
			Process processTarget = null;
			//获取当前所有进程中名称为curProcess.ProcessName的队列
			Process[] processes = Process.GetProcessesByName(curProcess.ProcessName);
			string curModuleFileName = curProcess.MainModule.FileName.ToLower();

			//遍历正在有相同名字运行的例程   
			foreach (Process itemProcess in processes)
			{
				//过滤掉当前进程   
				if (itemProcess.Id == curProcess.Id)
					continue;

				string itemModuleFileName = itemProcess.MainModule.FileName.Clone().ToString();
				itemModuleFileName = itemModuleFileName.ToLower();
				if (curModuleFileName.Equals(itemModuleFileName))
					processTarget = itemProcess;
				if (processTarget != null)
					return processTarget;
			}

			return processTarget;
		}

		public static Dictionary<string, Bitmap> GetDictImage(string relativePath)
		{
			return GetDictImage(relativePath, "*.png|*.jpg|*.bmp|*.jpeg|*.gif");
		}

		public static Dictionary<string, Bitmap> GetDictImage(string relativePath, string extensionStr)
		{
			Dictionary<string, Bitmap> dict = new Dictionary<string, Bitmap>();
			string imagesFolder = PublicMethods.GetAbsolutePath(relativePath);
			if (Directory.Exists(imagesFolder) == false)
				return dict;

			DirectoryInfo di = new DirectoryInfo(imagesFolder);
			//string[] suffixAry = new string[] { "*.png", "*.jpg", "*.bmp", "*.jpeg", "*.gif" };
			string[] suffixAry = extensionStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string suffix in suffixAry)
			{
				FileInfo[] fiAry = di.GetFiles(suffix);
				foreach (FileInfo fi in fiAry)
					dict.Add(fi.Name, new Bitmap(fi.FullName, false));
			}

			return dict;
		}

		public static void SetSamePoperty<T, K>(T t, K k)
		{
			Type typeT = typeof(T);
			PropertyInfo[] piAryT = typeT.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			Type typeK = typeof(K);
			PropertyInfo[] piAryK = typeK.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo piT in piAryT)
			{
				foreach (PropertyInfo piK in piAryK)
				{
					if (piT.Name == piK.Name)
					{
						object piValueK = piK.GetValue(k, null);
						piK.SetValue(t, piValueK, null);
						break;
					}
				}
			}
		}

		public static T SetSamePoperty<T, K>(K k) where T : class, new()
		{
			Type type = typeof(T);
			T tObj = Activator.CreateInstance(type) as T;
			if (tObj == null)
				return null;

			SetSamePoperty(tObj, k);

			return tObj;
		}

		public static Dictionary<string, string> GetDictParamsByUrlStr(string paramStr, bool keyIsNormalOrLower)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			string[] strAry = paramStr.Split(new char[] { '=', '&' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < strAry.Length; i += 2)
			{
				if (i >= strAry.Length)
					break;
				string key = strAry[i];
				if (keyIsNormalOrLower == false)
					key = strAry[i].ToLower();
				dict.Add(key, strAry[i + 1]);
			}

			return dict;
		}


	}
}