using BDSoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDControl;

namespace ReserveCommon
{
    public static class InternalMethods
    {
        public static double ToDoubleValue(this DateTime dateTime)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            double intResult = (dateTime - startTime).TotalSeconds;
            return intResult;
        }

        public static DateTime ToDateTimeValue(this double timeValue)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            startTime = startTime.AddSeconds(timeValue);
            //startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )
            return startTime;
        }

        public static UnitFunctionGroupType GetUnitFunctionGroupType(UnitFunctionType UnitFunctionType)
        {
            UnitFunctionGroupType UnitFunctionGroupType = UnitFunctionGroupType.Other;
            switch (UnitFunctionType)
            {
                case UnitFunctionType.JiBenXinXI:
                case UnitFunctionType.DanJingShuJu:
                case UnitFunctionType.DanYuanShuJu:
                case UnitFunctionType.JingJiPingJiaCanShu:
                    UnitFunctionGroupType = UnitFunctionGroupType.JiChuShuJu;
                    break;
                case UnitFunctionType.SQTZJia:
                case UnitFunctionType.SQTZYi:
                case UnitFunctionType.SQTZBing:
                case UnitFunctionType.SQTZDing:
                    UnitFunctionGroupType = UnitFunctionGroupType.ShuQuTeZheQuXianFenXi;
                    break;
                case UnitFunctionType.LaQiFenXi:
                case UnitFunctionType.TongXianZhangTuBanFa:
                case UnitFunctionType.JingYanGongShi:
                    UnitFunctionGroupType = UnitFunctionGroupType.FuZhuGongJu;
                    break;
                case UnitFunctionType.DJQXChanLiangDuiShiJian:
                case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                case UnitFunctionType.DJQXYueChanDuiLeiChan:
                    UnitFunctionGroupType = UnitFunctionGroupType.HeXinFenXi;
                    break;
                case UnitFunctionType.YuCeChaLiangShuJu:
                case UnitFunctionType.JingJiPingJia:
                //case UnitFunctionType.KeCaiChuLiangFenXiJieGuo:
                case UnitFunctionType.MinGanXingFenXi:
                case UnitFunctionType.BaoGaoShuChu:
                case UnitFunctionType.KPMGBaoBiao:
                case UnitFunctionType.KaiChuBiao:
                    UnitFunctionGroupType = UnitFunctionGroupType.FenXiChengGuo;
                    break;
                default:
                    UnitFunctionGroupType = UnitFunctionGroupType.Other;
                    break;
            }

            return UnitFunctionGroupType;
        }

        public static Bitmap GetImageByUnitFunctionType(UnitFunctionType UnitFunctionType)
        {
            Bitmap bmp = null;
            switch (UnitFunctionType)
            {
                case UnitFunctionType.JiBenXinXI:
                    bmp = Properties.Resources.BasicInfo_72;
                    break;
                case UnitFunctionType.SQTZJia:
                case UnitFunctionType.SQTZYi:
                case UnitFunctionType.SQTZBing:
                case UnitFunctionType.SQTZDing:
                    bmp = Properties.Resources.water;
                    break;
                case UnitFunctionType.LaQiFenXi:
                    bmp = Properties.Resources.laQiFenXI;
                    break;
                case UnitFunctionType.DJQXChanLiangDuiShiJian:
                case UnitFunctionType.DJQXYueChanDuiLeiChan:
                case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                    bmp = Properties.Resources.Arps;
                    break;
                case UnitFunctionType.YuCeChaLiangShuJu:
                    bmp = Properties.Resources.output;
                    break;
                case UnitFunctionType.JingJiPingJia:
                    bmp = Properties.Resources.dollar;
                    break;
                case UnitFunctionType.MinGanXingFenXi:
                    bmp = Properties.Resources.minGanXingFenXi;
                    break;
                case UnitFunctionType.DanYuanShuJu:
                    bmp = Properties.Resources.unit_72;
                    break;
                case UnitFunctionType.DanJingShuJu:
                    bmp = Properties.Resources.danJing;
                    break;
                case UnitFunctionType.BaoGaoShuChu:
                case UnitFunctionType.KPMGBaoBiao:
                case UnitFunctionType.KaiChuBiao:
                    bmp = Properties.Resources.print2;
                    break;
                case UnitFunctionType.TongXianZhangTuBanFa:
                    bmp = Properties.Resources.tongXiangZhang;
                    break;
                case UnitFunctionType.JingJiPingJiaCanShu:
                    bmp = Properties.Resources.EconomicParams;
                    break;
                case UnitFunctionType.JingYanGongShi:
                    bmp = Properties.Resources.fx;
                    break;
                default:
                    bmp = Properties.Resources.fenXi_72;
                    break;
            }

            return bmp;
        }

        public static BDDescriptionAttribute GetBDDescriptionAttribute(UnitFunctionType uct1)
        {
            System.Reflection.FieldInfo[] fieldAry = typeof(UnitFunctionType).GetFields();
            foreach (System.Reflection.FieldInfo item in fieldAry)
            {
                //获取类型
                UnitFunctionType uct;
                if (Enum.TryParse<UnitFunctionType>(item.Name, out uct) == false)
                    continue;

                if (uct != uct1)
                    continue;

                object[] objAry = item.GetCustomAttributes(typeof(BDDescriptionAttribute), false);
                if (objAry.Length > 0)
                    return objAry[0] as BDDescriptionAttribute;
                return null;
            }

            return null;
        }

        public static List<IEntityData> GetLstEntityData()
        {
            List<IEntityData> lstEntityData = new List<IEntityData>();
            foreach (UnitFunctionType item in Enum.GetValues(typeof(UnitFunctionType)))
            {
                if (item == UnitFunctionType.TongXianZhangTuBanFa ||
                    item == UnitFunctionType.KaiChuBiao ||
                    item == UnitFunctionType.KPMGBaoBiao ||
                    item == UnitFunctionType.JingYanGongShi)
                    continue;

                //if (item == UnitFunctionType.DJQXHanShuiLvDuiLeiChan ||
                //    item == UnitFunctionType.DJQXHanYouLvDuiLeiChan ||
                //    item == UnitFunctionType.DJQXShuiYouBiDuiLeiChan ||
                //    item == UnitFunctionType.DJQXYueChanDuiLeiChan ||
                //    item == UnitFunctionType.TongXianZhangTuBanFa ||
                //    item == UnitFunctionType.KaiChuBiao ||
                //    item == UnitFunctionType.KPMGBaoBiao ||
                //    item == UnitFunctionType.MinGanXingFenXi)
                //    continue;
                FunctionData functionData = new FunctionData();
                functionData.FunctionType = item;
                lstEntityData.Add(functionData);
            }

            return lstEntityData;
        }

        public static bool DataRowEquals(this DataRow dr1, DataRow dr2, string excludeColumnName)
        {
            if (dr1 == dr2)
                return true;
            if (dr1 == null)
                return false;
            if (dr2 == null)
                return false;
            if (dr1.Table.Columns.Count != dr2.Table.Columns.Count)
                return false;

            excludeColumnName = excludeColumnName.ToLower().Trim();
            foreach (DataColumn item in dr1.Table.Columns)
            {
                if (item.ColumnName.ToLower().Trim() == excludeColumnName)
                    continue;

                if (dr1[item.ColumnName].ToString() != dr2[item.ColumnName].ToString())
                    return false;
            }

            return true;
        }

        public static List<string> ToLower(this string[] strAry)
        {
            List<string> lstStr = new List<string>();
            for (int i = 0; i < strAry.Length; i++)
            {
                lstStr.Add(strAry[i].ToLower());
            }

            return lstStr;
        }

        public static string GetSqlPart(string prefix, List<NodeEnity> lstNE)
        {
            string sqlPart = null;

            if (lstNE[0].OrgType == OrganizationType.Dydm)
            {
                if (string.IsNullOrEmpty(prefix) == false)
                    sqlPart += prefix + ".";
                sqlPart += lstNE[0].GetSqlPart();
            }
            else
            {
                foreach (NodeEnity item in lstNE)
                {
                    string sqlPartTmp = item.GetSqlPart();
                    if (string.IsNullOrEmpty(sqlPartTmp))
                        continue;
                    if (string.IsNullOrEmpty(sqlPart) == false)
                        sqlPart += " and ";
                    if (string.IsNullOrEmpty(prefix) == false)
                        sqlPart += prefix + ".";
                    sqlPart += sqlPartTmp;
                }
            }

            return sqlPart;
        }

        public static string GetSqlPartWithGroupName(string prefix, GroupInfoQueue groupInfoQueue, List<string> lstHaveExist)
        {
            string result = null;
            foreach (GroupInfo item in groupInfoQueue)
            {
                GroupInfo gdata = item as GroupInfo;
                if (gdata == null)
                    continue;
                string columnName = gdata.Type.ToString();
                if (lstHaveExist.Contains(columnName))
                    continue;

                if (string.IsNullOrEmpty(result) == false)
                    result += ",";
                result += prefix + gdata.Type.ToString();
            }

            if (string.IsNullOrEmpty(result) == false)
                result = "," + result;

            return result;
        }

        public static string GetSqlPart(List<IEntityData> lstParent)
        {
            string sql = null;
            foreach (IEntityData item in lstParent)
            {
                if (item is ProjectData)
                    continue;
                if (string.IsNullOrEmpty(sql) == false)
                    sql += " and ";
                if (item is GroupData)
                {
                    GroupData gdata = item as GroupData;
                    if (string.IsNullOrEmpty(item.Text))
                        sql += "(" + gdata.SortType.ToString() + " is null or " + gdata.SortType.ToString() + "='" + item.Text + "')";
                    else
                        sql += gdata.SortType.ToString() + "='" + item.Text + "'";
                }
                else
                {
                    sql = "dydm='" + item.ID + "'";
                    break;
                }
            }

            return sql;
        }

        public static string GetFieldName(OrganizationType orgType)
        {
            string result = null;
            switch (orgType)
            {
                case OrganizationType.Fgsmc:
                    result = "fgsmc";
                    break;
                case OrganizationType.Cycmc:
                    result = "cycmc";
                    break;
                case OrganizationType.Ytmc:
                    result = "ytmc";
                    break;
                case OrganizationType.Dydm:
                    result = "dydm";
                    break;
                case OrganizationType.Root:
                default:
                    result = null;
                    break;
            }

            return result;
        }

        public static List<NodeEnity> GetLstNodeEntity(DataRow dr, OrganizationType orgType)
        {
            List<NodeEnity> lstNE;
            NodeEnity neDydm = new NodeEnity() { OrgType = OrganizationType.Dydm, OrgValue = dr["dydm"].ToString() };
            NodeEnity neOil = new NodeEnity() { OrgType = OrganizationType.Ytmc, OrgValue = "0_" + dr["FGSMC"].ToString() + "_" + dr["CYCMC"].ToString() + "_" + dr["ytmc"].ToString() };
            NodeEnity neCycmc = new NodeEnity() { OrgType = OrganizationType.Cycmc, OrgValue = "0_" + dr["FGSMC"].ToString() + "_" + dr["CYCMC"].ToString() };
            NodeEnity neFgsmc = new NodeEnity() { OrgType = OrganizationType.Fgsmc, OrgValue = "0_" + dr["FGSMC"].ToString() };
            NodeEnity neRoot = new NodeEnity() { OrgType = OrganizationType.Root, OrgValue = "null" };

            if (orgType == OrganizationType.Dydm)
                lstNE = new List<NodeEnity>() { neDydm, neOil, neCycmc, neFgsmc, neRoot };
            else if (orgType == OrganizationType.Ytmc)
                lstNE = new List<NodeEnity>() { neOil, neCycmc, neFgsmc, neRoot };
            else if (orgType == OrganizationType.Cycmc)
                lstNE = new List<NodeEnity>() { neCycmc, neFgsmc, neRoot };
            else //if (orgType == OrganizationType.Fgsmc)
                lstNE = new List<NodeEnity>() { neFgsmc, neRoot };

            return lstNE;
        }

        public static string GetSqlPartWithDistinct(OrganizationType orgType)
        {
            string result = null;
            switch (orgType)
            {
                case OrganizationType.Fgsmc:
                    result = "distinct(fgsmc),proid";
                    break;
                case OrganizationType.Cycmc:
                    result = "distinct(cycmc),fgsmc,proid";
                    break;
                case OrganizationType.Ytmc:
                    result = "distinct(ytmc),cycmc,fgsmc,proid";
                    break;
                case OrganizationType.Dydm:
                    result = "distinct(dydm),dymc,ytmc,cycmc,fgsmc,proid";
                    break;
                case OrganizationType.Root:
                default:
                    result = null;
                    break;
            }

            return result;
        }

        public static List<OrganizationType> GetLstParentOrgType(OrganizationType orgType)
        {
            List<OrganizationType> lstOrgType = new List<OrganizationType>();
            int intOrgType = (int)orgType;
            foreach (int item in Enum.GetValues(typeof(OrganizationType)))
            {
                if (item <= intOrgType)
                    lstOrgType.Add((OrganizationType)item);
            }

            return lstOrgType;
        }

        //获取子级队列
        public static List<OrganizationType> GetLstChildOrgType(OrganizationType orgType)
        {
            List<OrganizationType> lstOrgType = new List<OrganizationType>();
            int intOrgType = (int)orgType;
            foreach (int item in Enum.GetValues(typeof(OrganizationType)))
            {
                if (item > intOrgType)
                    lstOrgType.Add((OrganizationType)item);
            }

            return lstOrgType;
        }

        public static string GetSqlPartWithList(OrganizationType orgType)
        {
            string result = null;
            switch (orgType)
            {
                case OrganizationType.Fgsmc:
                    result = "fgsmc";
                    break;
                case OrganizationType.Cycmc:
                    result = "fgsmc,cycmc";
                    break;
                case OrganizationType.Ytmc:
                    result = "fgsmc,cycmc,ytmc";
                    break;
                case OrganizationType.Dydm:
                    result = "fgsmc,cycmc,ytmc,dydm";
                    break;
                case OrganizationType.Root:
                default:
                    result = null;
                    break;
            }

            return result;
        }

        #region DataGridView

        public static void DataGridViewCut(DataGridView dgv, DataGridViewCellEventHandler dgv_CellValueChanged)
        {
            if (dgv_CellValueChanged != null)
                dgv.CellValueChanged -= dgv_CellValueChanged;
            MyMethod.CopyFromDataGridView(dgv);
            foreach (DataGridViewCell item in dgv.SelectedCells)
            {
                if (dgv.Columns[item.ColumnIndex].ReadOnly)
                    continue;

                item.Value = DBNull.Value;
            }
            //再绑定单元格值改变事件
            if (dgv_CellValueChanged != null)
                dgv.CellValueChanged += dgv_CellValueChanged;
        }

        public static bool DataGridViewPaste(DataGridView dgv, DataGridViewCellEventHandler dgv_CellValueChanged, out int rowsCount, out int columnsCount)
        {
            rowsCount = columnsCount = 0;
            //粘贴赋值
            dgv.CellValueChanged -= dgv_CellValueChanged;
            //string errMessage = MyMethod.PasterToDataGridView(dgv, dgv.AllowUserToAddRows, ref rowsCount, ref columnsCount);
            //string errMessage = MyMethod.PasterToDataGridView(dgv, false, ref rowsCount, ref columnsCount);
             MyMethod.PasterToDataGridView(dgv, true);
            //再绑定单元格值改变事件
            dgv.CellValueChanged += dgv_CellValueChanged;
            if (string.IsNullOrEmpty(errMessage) == false)
            {
                WinPublicMethods.WarnMessageBox(errMessage);
                return false;
            }
            return true;
        }

        #endregion

        public static double GetBBLByTon(double ton, double yymd)
        {
            return ton / yymd * GlobalInfo.BarrelVolume;
        }

        public static double GetTonByBBL(double bbl, double yymd)
        {
            return bbl / GlobalInfo.BarrelVolume * yymd;
        }

        public static double GetWTonByMBBL(double bbl, double yymd)
        {
            return GetTonByBBL(bbl * 1000, yymd) / 10000;
        }

        public static double GetMCFByM3(double m3)
        {
            return m3 * GlobalInfo.M3ToMCF;
        }

        public static double GetM3ByMCF(double mcf)
        {
            return mcf / GlobalInfo.M3ToMCF;
        }

        public static double GetEnUnit(double qyb, double yymd)
        {
            double mcf = GetMCFByM3(qyb);
            double bbl = GetBBLByTon(1, yymd);
            return mcf / bbl;
        }

        public static double GetCnUnit(double qyb, double yymd)
        {
            double m3 = GetM3ByMCF(qyb);
            double ton = GetTonByBBL(1, yymd);
            return m3 / ton;
        }
    }
}