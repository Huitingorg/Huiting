using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;
using BDSoft.Components;
using LocalDataService;
using ReserveChartExpand;
using ReserveChart;

namespace ReserveAnalysis
{
    public partial class FrmBatchSavePictures : FrmChild
    {
        Size size;
        List<AssetsData> lstAssetsData;
        
        public FrmBatchSavePictures()
        {
            InitializeComponent();
        }

        public FrmBatchSavePictures(List<AssetsData> lstAssetsData, Size size):this()
        {
            this.size = size;
            this.lstAssetsData = lstAssetsData;
        }

        public void BatchSavePictures(string pjnd, List<AssetsData> lstAssetsData, Size size)
        {
            DecParams decParams = new DecParams();
            PictureCreator pictureCreator = new PictureCreator();
            foreach (AssetsData item in lstAssetsData)
            {
                decParams.ProID = item.ProID;
                //decParams.Pjnd = item.Pjnd;
                decParams.Dydm = item.DYDM;
                decParams.Dymc = item.DYMC;
                //decParams.Ycqsrq = item.

                EvaluationOptionsService evalOptionService = new EvaluationOptionsService();
                DataTable dtEvalOption = evalOptionService.GetDataTable(item.ProID, item.Pjnd, item.DYDM);
                if (dtEvalOption == null || dtEvalOption.Rows.Count <= 0)
                    continue;
                string ycqsrq = dtEvalOption.Rows[0]["startNy"].ToString();
                decParams.PreStartDate = ycqsrq.ToDateTime();

                Bitmap bmp = pictureCreator.CreateBitmap(decParams, size);
                bmp.Save(@"e:\\" + decParams.Dymc + ".png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BatchSavePictures(lstAssetsData, size);
        }
    }
}