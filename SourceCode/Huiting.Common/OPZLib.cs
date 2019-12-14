using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BDSoft.Common
{
	/// <summary>
	/// ZLib压缩操作类
	/// </summary>
	public class OPZLib
	{
		public static void CopyStream(Stream input, Stream output)
		{
			int bufferSize = 2048;
			try
			{
				CopyStream(input, output, bufferSize);
				return;
			}
			catch
			{

			}

			int[] BuffSizeList = { 1000, 1024, 1068, 1356, 1698, 1675, 2000 };
			foreach (int curBufferSize in BuffSizeList)
			{
				try
				{
					CopyStream(input, output, curBufferSize);
					return;
				}
				catch
				{
				}
			}
			throw (new Exception("解压文件失败！"));
		}

		public static void CopyStream(Stream input, Stream output, int bufferSize)
		{
			byte[] buffer = new byte[bufferSize];
			while (true)
			{
				int read = input.Read(buffer, 0, buffer.Length);
				if (read <= 0)
				{
					return;
				}
				output.Write(buffer, 0, read);
			}
		}

		/// <summary>
		/// 压缩文件
		/// </summary>
		/// <param name="FileName">被压缩文件名（必须输入绝对路径）</param>
		/// <param name="CompressedFileName">压缩后保存的文件名（必须输入绝对路径）</param>
		/// <returns></returns>
		public static bool CompressFile(string FileName, string CompressedFileName)
		{
			bool bResult = false;

			FileStream outFileStream = new FileStream(CompressedFileName, FileMode.Create);
			ZOutputStream outZStream = new ZOutputStream(outFileStream, zlibConst.Z_DEFAULT_COMPRESSION);
			FileStream inFileStream = new FileStream(FileName, FileMode.Open);
			try
			{
				CopyStream(inFileStream, outZStream);
				bResult = true;
			}
			catch
			{
				bResult = false;
			}
			finally
			{
				outZStream.Close();
				outFileStream.Close();
				inFileStream.Close();
			}
			return bResult;
		}

		/// <summary>
		/// 解压文件
		/// </summary>
		/// <param name="CompressedFileName">被解压文件名（必须输入绝对路径）</param>
		/// <param name="DecompressFileName">解压后保存的文件名（必须输入绝对路径）</param>
		/// <returns></returns>
		public static bool DecompressFile(string CompressedFileName, string DecompressFileName)
		{
			bool bResult = false;
			FileStream outFileStream = new FileStream(DecompressFileName, FileMode.Create);
			ZOutputStream outZStream = new ZOutputStream(outFileStream);
			FileStream inFileStream = new FileStream(CompressedFileName, FileMode.Open);
			try
			{
				CopyStream(inFileStream, outZStream);
				bResult = true;

			}
			catch
			{
				bResult = false;


			}
			finally
			{
				outZStream.Close();
				outFileStream.Close();
				inFileStream.Close();
			}
			return bResult;
		}

		/// <summary>
		/// 压缩byte数组数据
		/// </summary>
		/// <param name="SourceByte">需要被压缩的Byte数组数据</param>
		/// <returns></returns>
		public static byte[] CompressBytes(byte[] SourceByte)
		{
			try
			{
				MemoryStream stmInput = new MemoryStream(SourceByte);
				Stream stmOutPut = CompressStream(stmInput);
				byte[] bytOutPut = new byte[stmOutPut.Length];
				stmOutPut.Position = 0;
				stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);
				return bytOutPut;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 压缩文件至二进制流
		/// </summary>
		/// <param name="FilePath">要压缩的文件地址</param>
		/// <returns>返回压缩的二进制数组</returns>
		public static Byte[] CompressFileBytes(string FilePath)
		{
			FileStream fs = new FileStream(FilePath, FileMode.Open);
			long count = fs.Length;
			byte[] SourceByte = new byte[count];
			fs.Read(SourceByte, 0, (int)count);
			fs.Close();
			fs.Dispose();

			//byte[] SourceByte;
			try
			{
				MemoryStream stmInput = new MemoryStream(SourceByte);
				Stream stmOutPut = CompressStream(stmInput);
				byte[] bytOutPut = new byte[stmOutPut.Length];
				stmOutPut.Position = 0;
				stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);
				return bytOutPut;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 解压byte数据数据
		/// </summary>
		/// <param name="SourceByte">需要被解压的byte数组数据</param>
		/// <returns></returns>
		public static byte[] DecompressBytes(byte[] SourceByte)
		{
			try
			{
				MemoryStream stmInput = new MemoryStream(SourceByte);
				Stream stmOutPut = DecompressStream(stmInput);
				byte[] bytOutPut = new byte[stmOutPut.Length];
				stmOutPut.Position = 0;
				stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);
				return bytOutPut;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		/// <summary>
		/// 解压缩二进制到相应的文件
		/// </summary>
		/// <param name="SourceByte">被压缩的二进制流</param>
		/// <param name="FilePath">要保存的文件地址</param>
		/// <returns></returns>
		public static bool DecompressFileBytes(byte[] SourceByte, string FilePath)
		{
			try
			{
				MemoryStream stmInput = new MemoryStream(SourceByte);
				Stream stmOutPut = DecompressStream(stmInput);
				byte[] bytOutPut = new byte[stmOutPut.Length];
				stmOutPut.Position = 0;
				stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);

				if (File.Exists(FilePath))
				{
					File.Delete(FilePath);
				}
				FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);

				fs.Write(bytOutPut, 0, bytOutPut.Length);
				fs.Flush();
				fs.Close();
				fs.Dispose();

				return true;// bytOutPut;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 压缩流
		/// </summary>
		/// <param name="SourceStream">需要被压缩的流数据</param>
		/// <returns></returns>
		public static Stream CompressStream(Stream SourceStream)
		{
			try
			{
				MemoryStream stmOutTemp = new MemoryStream();
				ZOutputStream outZStream = new ZOutputStream(stmOutTemp, zlibConst.Z_DEFAULT_COMPRESSION);
				CopyStream(SourceStream, outZStream);
				outZStream.finish();
				return stmOutTemp;
			}
			catch
			{
				return null;
			}
		}

		public static Stream DecompressStream(Stream SourceStream)
		{
			try
			{
				MemoryStream stmOutput = new MemoryStream();
				ZOutputStream outZStream = new ZOutputStream(stmOutput);
				CopyStream(SourceStream, outZStream);
				outZStream.finish();
				return stmOutput;
			}
			catch
			{

				return null;
			}
		}

		/// <summary>
		/// 压缩字符串
		/// </summary>
		/// <param name="SourceString">需要被压缩的字符串</param>
		/// <returns></returns>
		public static string CompressToBase64String(string SourceString)
		{
			byte[] byteSource = System.Text.Encoding.UTF8.GetBytes(SourceString);
			byte[] byteCompress = CompressBytes(byteSource);
			if (byteCompress != null)
				return Convert.ToBase64String(byteCompress);
			return null;
		}

		/// <summary>
		/// 解压字符串
		/// </summary>
		/// <param name="SourceString">需要被解压的字符串</param>
		/// <returns></returns>
		public static string DecompressStringFromBase64String(string SourceString)
		{
			byte[] byteSource = Convert.FromBase64String(SourceString);
			byte[] byteDecompress = DecompressBytes(byteSource);
			if (byteDecompress != null)
			{
				return System.Text.Encoding.UTF8.GetString(byteDecompress);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 压缩字符串成
		/// </summary>
		/// <param name="SourceString">需要被压缩的字符串</param>
		/// <returns></returns>
		public static byte[] CompressToByteAry(string SourceString)
		{
			byte[] byteSource = System.Text.Encoding.UTF8.GetBytes(SourceString);
			byte[] byteCompress = CompressBytes(byteSource);
			return byteCompress;
		}

		/// <summary>
		/// 解压字符串
		/// </summary>
		/// <param name="SourceString">需要被解压的字符串</param>
		/// <returns></returns>
		public static string DecompressString(byte[] byteSource)
		{
			byte[] byteDecompress = DecompressBytes(byteSource);
			if (byteDecompress != null)
			{
				return System.Text.Encoding.UTF8.GetString(byteDecompress);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 压缩数据集为二进制
		/// </summary>
		/// <param name="curSet">在压缩的数据集</param>
		/// <returns>压缩成的二进制</returns>
		public static byte[] CompressDataSet(DataSet curSet)
		{
			byte[] e2 = null;
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(ms, curSet);
				e2 = OPZLib.CompressBytes(ms.GetBuffer());
			}
			return e2;
		}

		/// <summary>
		/// 将二进制解压缩为数据集
		/// </summary>
		/// <param name="byteSource">预解压缩的二进制</param>
		/// <returns>解压缩后的数据集</returns>
		public static DataSet DecompressDataSet(byte[] byteSource)
		{
			DataSet curSet = new DataSet();
			BinaryFormatter bf = new BinaryFormatter();
			byte[] DeData = OPZLib.DecompressBytes(byteSource);
			using (MemoryStream ms = new MemoryStream(DeData))
				curSet = bf.Deserialize(ms) as DataSet;

			return curSet;
		}
	}
}