using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huiting.Common;

namespace ReserveAnalysis
{
    public partial class FrmAbout : Form
    {
        static readonly string fileName = PublicMethods.GetAbsolutePath("about.ini");
        public FrmAbout()
        {
            InitializeComponent();

            this.Load += FrmAbout_Load;
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileName) == false)
                return;
            string fileContent = ReadFile(fileName);
            lblQQ.Text = fileContent;
        }

        public static string ReadFile()
        {
            return ReadFile(fileName);
        }
        public static string ReadFile(string fileName)
        {
            if (File.Exists(fileName) == false)
                return string.Empty;
            StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("gb2312"));
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
