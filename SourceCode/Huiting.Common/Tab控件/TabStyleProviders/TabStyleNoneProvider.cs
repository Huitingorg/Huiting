﻿/*
 * This code is provided under the Code Project Open Licence (CPOL)
 * See http://www.codeproject.com/info/cpol10.aspx for details
 */

namespace BDSoft.Common
{
	using System;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Windows.Forms;
	
	[System.ComponentModel.ToolboxItem(false)]
	public class TabStyleNoneProvider : TabStyleProvider
	{
		public TabStyleNoneProvider(TabControlEx2 tabControl) : base(tabControl){
		}
		
		public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds){
		}
	}
}
