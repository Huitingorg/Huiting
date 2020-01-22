using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Reflection;

namespace ReserveAnalysis
{
    public class FrmTranslucent : Form
    {
        Font font;
        string version;
        Size realSize;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                if (!DesignMode)
                    param.ExStyle |= NativeMethodss.WS_EX_LAYERED;
                return param;
            }
        }

        public void Show(Bitmap face)
        {
            ClientSize = realSize;
            base.Show();
            UpdateLayered(face);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84://WM_NCHITTEST = 0x84;
                    m.Result = (IntPtr)2;//标题栏
                    return;
            }
            base.WndProc(ref m);
        }

        public void UpdateLayered(Bitmap face)
        {
            if (face == null)
                throw new ArgumentNullException("face");

            Graphics gClient = Graphics.FromHwnd(this.Handle);
            IntPtr dcClient = gClient.GetHdc();
            IntPtr hface = NativeMethodss.CreateCompatibleBitmap(dcClient, realSize.Width, realSize.Height);
            IntPtr dcMem = NativeMethodss.CreateCompatibleDC(dcClient);

            NativeMethodss.SelectObject(dcMem, hface);
            Graphics gMem = Graphics.FromHdc(dcMem);
            gMem.DrawImage(face, 0, 0, realSize.Width, realSize.Height);
            OnPaint(new PaintEventArgs(gMem, new Rectangle(Point.Empty, realSize)));
            gMem.Flush();
            dcMem = gMem.GetHdc();

            NativeMethodss.POINT ptLoc = new NativeMethodss.POINT(Left, Top);
            NativeMethodss.POINT pt = new NativeMethodss.POINT(0, 0);
            NativeMethodss.SIZE sz = new NativeMethodss.SIZE(realSize.Width, realSize.Height);
            NativeMethodss.BLENDFUNCTION blend = new NativeMethodss.BLENDFUNCTION(NativeMethodss.AC_SRC_OVER, 0, 255, NativeMethodss.AC_SRC_ALPHA);
            //NativeMethodss.BOOL ret = NativeMethodss.UpdateLayeredWindow(this.Handle, dcClient, ref ptLoc, ref sz, dcMem, ref pt, 0, ref blend, NativeMethodss.ULW_ALPHA);
            NativeMethodss.BOOL ret = NativeMethodss.UpdateLayeredWindow(this.Handle, dcClient, ref ptLoc, ref sz, dcMem, ref pt, 0, ref blend, NativeMethodss.ULW_COLORKEY);
            gMem.ReleaseHdc();
            gClient.ReleaseHdc();
        }

        private FrmTranslucent()
        {
            realSize = GetRealSize(Properties.Resources.Cover);
            this.ShowInTaskbar = false;

            font = new Font("宋体", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            version = "版本号：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        //按最值等比约束图片
        private Size GetRealSize(Bitmap face)
        {
            int maxValue = 600;
            double zoom = GetZoomValue(maxValue, face.Width);
            if(zoom==1)
            {
                zoom = GetZoomValue(maxValue, face.Height);
                if (zoom == 1)
                {
                    return face.Size;
                }
                else
                {
                    return new Size((int)(zoom * face.Width), maxValue);
                }
            }
            else
            {
                int valueH = (int)(zoom * face.Height);
                zoom = GetZoomValue(maxValue, valueH);
                if (zoom == 1)
                {
                    return new Size(maxValue,valueH);
                }
                else
                {
                    int valueW = (int)(zoom * maxValue);
                    return new Size(valueW, maxValue);
                }
            }
        }

        private double GetZoomValue(int maxValue, int value1)
        {
            if (value1 <= maxValue)
                return 1;
            return maxValue * 1.0 / value1;
        }

        static FrmTranslucent splashScreen;
        public static FrmTranslucent SplashScreen
        {
            get
            {
                return splashScreen;
            }
            set
            {
                splashScreen = value;
            }
        }

        public static void ShowSplashScreen()
        {
            if (splashScreen == null)
                splashScreen = new FrmTranslucent();
            //splashScreen.Text = "可采储量分析系统" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //splashScreen.Icon = Properties.Resources.logo;
            splashScreen.StartPosition = FormStartPosition.CenterScreen;
            splashScreen.Show(Properties.Resources.index);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics g = e.Graphics;
            //g.DrawString(version, font, Brushes.White, new PointF(400, 277));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmTranslucent
            // 
            this.ClientSize = new System.Drawing.Size(1122, 703);
            this.Name = "FrmTranslucent";
            this.ResumeLayout(false);

        }
    }


    static class NativeMethodss
    {
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int width, int height);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

        public enum BOOL
        {
            False = 0,
            True
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public Int32 x;
            public Int32 y;

            public POINT(Int32 x, Int32 y) { this.x = x; this.y = y; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public Int32 cx;
            public Int32 cy;

            public SIZE(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct ARGB
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
            public BLENDFUNCTION(byte blendOp, byte blendFlags, byte sourceConstantAlpha, byte alphaFormat)
            {
                BlendOp = blendOp;
                BlendFlags = blendFlags;
                SourceConstantAlpha = sourceConstantAlpha;
                AlphaFormat = alphaFormat;
            }
        }

        public const Int32 ULW_COLORKEY = 0x00000001;
        public const Int32 ULW_ALPHA = 0x00000002;
        public const Int32 ULW_OPAQUE = 0x00000004;

        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;

        public const int WS_POPUP = -2147483648;
        public const int SW_SHOW = 5;

        public const int WS_EX_APPWINDOW = 0x40000;
        public const int WS_EX_CLIENTEDGE = 0x200;
        public const int WS_EX_CONTEXTHELP = 0x400;
        public const int WS_EX_CONTROLPARENT = 0x10000;
        public const int WS_EX_DLGMODALFRAME = 1;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_LAYOUTRTL = 0x400000;
        public const int WS_EX_LEFT = 0;
        public const int WS_EX_LEFTSCROLLBAR = 0x4000;
        public const int WS_EX_MDICHILD = 0x40;
        public const int WS_EX_NOINHERITLAYOUT = 0x100000;
        public const int WS_EX_RIGHT = 0x1000;
        public const int WS_EX_RTLREADING = 0x2000;
        public const int WS_EX_STATICEDGE = 0x20000;
        public const int WS_EX_TOOLWINDOW = 0x80;
        public const int WS_EX_TOPMOST = 8;
    }
}
