using BDSoft.DBAccess;
using LocalDataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BDControl;

namespace ReserveAnalysis
{
    //注册检查
    public class RegCheck
    {
        string TelPhoneInfo = $"\r\n{FrmAbout.ReadFile()}";
        RegInfoStruct curRegInfoStruct = new RegInfoStruct();
        DataTable dt_AcessReg = new DataTable();
        DbAccess opDB = localService.DBAccess;

        public string HitInfo = "";
        public string VerInfo = "";
        public string WarringMsg = "";

        public event EventHandler RegCheckOver;

        //是否需要锁定主程序界面
        public bool NeedLockSystem = false;
        Form parentForm = null;
        ProgressForm curProgress = null;
        public RegCheck(Form parentForm)
        {
            this.parentForm = parentForm;
        }
        public void BeginCheck()
        {
            string AppRegFilePath = Application.StartupPath + "\\AppRun.dll";

            #region  //测试版先不连接地址院的校验服务器


            //if(!MyMethod.CheckFileExists(AppRegFilePath))
            //{
            //    //第一次运行，由于没有注册文件，所以先到服务器上拉取一下，比较慢，出进度条
            //    curProgress = new ProgressForm("正在为第一次运行做准备……");
            //    curProgress.Show(parentForm);
            //    //parentForm.Enabled = false;
            //}


            ////先连接服务器，调用更新文件
            //DownLoadRegFile opUpdateRegFile = new DownLoadRegFile();
            //opUpdateRegFile.BeginOp();

            //if (curProgress != null)
            //{
            //    curProgress.Close();
            //    //parentForm.Enabled = true;
            //}

            #endregion

            //如果没有注册文件，要检测是否是第一次安装
            if (!MyMethod.CheckFileExists(AppRegFilePath))
            {   //获取数据库中的标识
                if (GetAccessRegInfo(opDB))
                {
                    //如果第一次安装，密码存储应为null
                    if (dt_AcessReg.Rows.Count > 0)
                    {
                        string TempValue = dt_AcessReg.Rows[0]["psw"].ToString();
                        if (string.IsNullOrEmpty(TempValue))
                        {
                            //确认为第一次安装，启动相关模块
                            RegForm form = new RegForm(opDB);
                            ////默认一个月
                            ////form.text_RegDW.Text = "培训专用";
                            ////form.date_UseDataLimite.Value = "2015-11-10".ConvertDate("yyyy-MM-dd");
                            ////form.btn_Reg_Click(null, null);
                            ////手工注册使用
                            form.TopMost = true;
                            form.ShowDialog(parentForm);
                            form.Dispose();
                            string tempValue = DateTime.Now.ToString("yyyy-MM-dd");
                            dt_AcessReg.Rows[0]["psw"] = MyMethod.GetEecryptStr(tempValue);
                            SaveAccessRegInfo();
                        }
                    }
                }
            }

            BackgroundWorker back_CheckReg = new BackgroundWorker();
            back_CheckReg.WorkerSupportsCancellation = true;
            back_CheckReg.DoWork += back_CheckReg_DoWork;
            back_CheckReg.RunWorkerCompleted += back_CheckReg_RunWorkerCompleted;
            back_CheckReg.RunWorkerAsync();
        }

        void back_CheckReg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //获取当前系统版本
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            string version = myFileVersion.FileVersion;

            switch (curRegInfoStruct.curRegCheckResult)
            {
                case RegCheckResult.UnlimitedVer:
                    //正式版本无任何限制
                    if (!string.IsNullOrEmpty(curRegInfoStruct.RegUnit))
                    {
                        //this.Text = this.Text + "(正式版" + version + "-" + curRegInfoStruct.RegUnit + ")";
                        //barStaticItem_AppInfo.Caption = "当前版本：" + version;
                        HitInfo = "授权类型：正式版。\n注册单位：" + curRegInfoStruct.RegUnit;
                    }
                    VerInfo = "当前版本：" + version;
                    break;
                case RegCheckResult.TrialVer:
                    if (!string.IsNullOrEmpty(curRegInfoStruct.RegUnit))
                    {
                        //this.Text = this.Text + "(试用版" + version + "-" + curRegInfoStruct.RegUnit + ")";
                        //barStaticItem_AppInfo.Caption = "当前版本：T " + version;
                        HitInfo = "授权类型：试用版。\n注册单位：" + curRegInfoStruct.RegUnit;
                    }
                    VerInfo = "当前版本：T " + version;
                    if (curRegInfoStruct.TrialRemainingDays <= 3)
                    {
                        MyMethod.ShowMessage(parentForm, "您的软件还可使用" + curRegInfoStruct.TrialRemainingDays.ToString() + "天，为保障您正常使用，请联系软件供应商。" + TelPhoneInfo);
                    }
                    break;
                case RegCheckResult.Overdue:
                    MyMethod.ShowMessage(parentForm, "很抱歉，您的软件已超过试用期限，如您想继续使用，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
                case RegCheckResult.Mismatch:
                    MyMethod.ShowMessage(parentForm, "很抱歉，您的电脑不具备运行系统的权限，如您想试用系统，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
                case RegCheckResult.PareseFileErr:
                    MyMethod.ShowMessage(parentForm, "很抱歉，软件检测到严重异常，系统文件被破坏，软件将关闭，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
                case RegCheckResult.RegFileLose:
                    //MyMethod.ShowMessage(parentForm, "您所使用的软件尚未授权，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
                case RegCheckResult.RegFileBeCracked:
                    MyMethod.ShowMessage(parentForm, "系统文件被意外修改，软件出现不应有的异常，无法继续使用，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
                case RegCheckResult.Error:
                    MyMethod.ShowMessage(parentForm, "软件出现不应有的异常，无法继续使用，请联系软件供应商。\n" + curRegInfoStruct.str_Err + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;

                case RegCheckResult.Lock:
                    MyMethod.ShowMessage(parentForm, "软件应用出现严重异常，请确认授权合法，请联系软件供应商。\n" + curRegInfoStruct.str_Err + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;

                default:
                    MyMethod.ShowMessage(parentForm, "出现不可预知的异常，软件将关闭，请联系软件供应商。" + TelPhoneInfo);
                    NeedLockSystem = true;
                    break;
            }
            if (RegCheckOver != null)
            {
                RegCheckOverEventArgs newArges = new RegCheckOverEventArgs();
                newArges.NeedLockSystem = NeedLockSystem;
                newArges.curRegInfoStruct = curRegInfoStruct;
                newArges.HitInfo = HitInfo;
                newArges.VerInfo = VerInfo;
                RegCheckOver(this, newArges);
            }
        }
        void back_CheckReg_DoWork(object sender, DoWorkEventArgs e)
        {
            //OpAppRegClass opReg = new OpAppRegClass();
            //curRegInfoStruct = opReg.CurRegInfoStruct;

            curRegInfoStruct = OpAppRegClass.Instance.CurRegInfoStruct;
        }

        private bool GetAccessRegInfo(DbAccess opDB)
        {
            string StrSql = "select * from BDUser where UserName='administrator'";
            //opDB = new DbAccess(CommonObject.CurPTInfo.curDBKind, CommonObject.CurPTInfo.ConnStr);
            this.opDB = opDB;
            opDB.NeedThrowException = false;
            if (!opDB.GetDataTable(StrSql, ref dt_AcessReg))
            {
                curRegInfoStruct.str_Err = opDB.ErrMsg;
                return false;
            }
            return true;
        }

        private bool SaveAccessRegInfo()
        {
            return opDB.UpdateDateTable(dt_AcessReg, "select * from BDUser where UserName='administrator'");
        }
    }

    public class RegCheckOverEventArgs : EventArgs
    {
        public bool NeedLockSystem = false;
        public RegInfoStruct curRegInfoStruct = new RegInfoStruct();
        public string HitInfo = "";
        public string VerInfo = "";
    }

    public class OpAppRegClass
    {
        private RegInfoStruct curRegInfoStruct = new RegInfoStruct();

        //注册服务器操作对象
        //private RegInfoRemoteOp opRemoteSevice = null;
        public RegInfoStruct CurRegInfoStruct
        {
            get
            {
                return curRegInfoStruct;
            }
        }

        //注册信息字符串
        private string RegInfo;

        private string RegFilePath = "";

        static OpAppRegClass instance = new OpAppRegClass();

        public static OpAppRegClass Instance
        {
            get { return OpAppRegClass.instance; }
        }

        public OpAppRegClass()
        {
            Init();

            ////创建远程服务访问对象
            //opRemoteSevice = new RegInfoRemoteOp(curRegInfoStruct);

            ////将软件启动信息写入日志
            //opRemoteSevice.CommitLogInfo("0", "");
        }

        private void Init()
        {
            RegFilePath = Application.StartupPath + "\\AppRun.dll";
            if (!MyMethod.CheckFileExists(RegFilePath))
            {
                curRegInfoStruct.str_Err = "配置文件丢失！";
                curRegInfoStruct.curRegCheckResult = RegCheckResult.RegFileLose;
                //curResult = RegCheckResult.RegFileLose;
                return;
            }

            RegFilePath = @"C:\Users\cmp\Desktop\AppRun.dll";
            string FileStr = MyMethod.FileToStr(RegFilePath);
            if (string.IsNullOrEmpty(FileStr))
            {
                curRegInfoStruct.str_Err = "配置意外被修改！";
                curRegInfoStruct.curRegCheckResult = RegCheckResult.PareseFileErr;
                //curResult = RegCheckResult.PareseFileErr;
                return;
            }
            RegInfo = MyMethod.GetDecryptStr(FileStr.Trim());
            if (string.IsNullOrEmpty(RegInfo))
            {
                curRegInfoStruct.str_Err = "配置意外被修改！";
                curRegInfoStruct.curRegCheckResult = RegCheckResult.PareseFileErr;
                //curResult = RegCheckResult.PareseFileErr;
                return;
            }

            string Spec = "#";
            string[] RegList = RegInfo.Split(Spec.ToCharArray());
            if (RegList.Length < 8)
            {
                curRegInfoStruct.str_Err = "配置被非法修改！";
                curRegInfoStruct.curRegCheckResult = RegCheckResult.RegFileBeCracked;
               // curResult = RegCheckResult.RegFileBeCracked;
                return;
            }
            string VerInfo = RegList[0];
            switch(VerInfo.ToLower().Trim())
            {
                case "v1.0":
                    PareseRegStrV1(RegInfo);
                    break;
                default:
                    PareseRegStrV0(RegInfo);
                    break;
            }
            //if(curRegInfoStruct.curRegCheckResult == RegCheckResult.Lock)
            //{
            //    //如果是锁定状态，直接返回
            //    return;
            //}

            if (curRegInfoStruct.curRegCheckResult != RegCheckResult.TrialVer)
            {
                //检测硬件信息是否匹配
                if (!JugeHardWareInfo())
                    return;
            }

            if (curRegInfoStruct.curRegCheckResult == RegCheckResult.UnlimitedVer)
            {
                //硬件已经匹配，如果是正式版，就可以直接返回了
                return;
            }

            if (curRegInfoStruct.curRegCheckResult == RegCheckResult.Lock)
            {
                //如果是锁定状态，也可以直接返回了
                return;
            }

            //判断软件日期是否已超期
            if (!JugeDateLimite())
            {
                return;
            }

            //判断使用次数是否超限
            if (!JugeUserCountLimite())
            {
                return;
            }
            //自增访问次数
            AddSoftRunCount();
        }

        //最开始版本的解析
        private void PareseRegStrV0(string RegInfoStr)
        {
            curRegInfoStruct = new RegInfoStruct();
            string Spec = "#";
            string[] RegList = RegInfoStr.Split(Spec.ToCharArray());
            if (RegList.Length < 8)
            {
                curRegInfoStruct.str_Err = "配置被非法修改！";
                curRegInfoStruct.curRegCheckResult = RegCheckResult.RegFileBeCracked;
                //curResult = RegCheckResult.RegFileBeCracked;
                return;
            }
            /*
            第一位：授权单位
            第二位：授权用户
            第三位：1正式片，0，试用版
            第四位：试用截止时间
            第五位：试用次数
            第六位：硬件绑定类型
            第七位：硬件ID
            第八位：存储软件运行次数
            */
            string tempValue = "";
            try
            {
                curRegInfoStruct.RegInfoVer = "0";
                curRegInfoStruct.RegUnit = RegList[0];
                curRegInfoStruct.RegUser = RegList[1];
                tempValue = RegList[2];
                if (tempValue == "1")
                {
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.UnlimitedVer;
                    //curResult = RegCheckResult.UnlimitedVer;
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.UnlimitedVer;
                }
                else
                {
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.TrialVer;
                    //curResult = RegCheckResult.TrialVer;
                    curRegInfoStruct.TrialLimiteTime = DateTime.Parse(RegList[3]);
                    curRegInfoStruct.TrialLimiteCount = int.Parse(RegList[4]);
                }
                tempValue = RegList[5];
                if (tempValue == "0")
                {
                    curRegInfoStruct.curBindType = RegBindHDType.CPU;
                }
                else
                {
                    curRegInfoStruct.curBindType = RegBindHDType.HDD;
                }
                curRegInfoStruct.HDMarkCode = RegList[6];

                curRegInfoStruct.LimiteDataUpdateFromServer = false;
              
                curRegInfoStruct.AlreadyUseCount = int.Parse(RegList[7]);
            }
            catch (Exception E)
            {
                curRegInfoStruct.str_Err = E.Message;
                curRegInfoStruct.curRegCheckResult = RegCheckResult.Error;
                //curResult = RegCheckResult.Error;
                return;
            }
        }

        //1.0版加密串解析
        private void PareseRegStrV1(string RegInfoStr)
        {
            curRegInfoStruct = new RegInfoStruct();
            string Spec = "#";
            string[] RegList = RegInfoStr.Split(Spec.ToCharArray());
            if (RegList.Length < 10)
            {
                curRegInfoStruct.str_Err = "配置被非法修改！";
                //curResult = RegCheckResult.RegFileBeCracked;
                curRegInfoStruct.curRegCheckResult = RegCheckResult.RegFileBeCracked;
                return;
            }
            /*
            第一位：加密串版本号
            第二位：授权单位
            第三位：授权用户
            第四位：1正式片，0，试用版
            第五位：试用截止时间
            第六位：试用次数
            第七位：硬件绑定类型
            第八位：硬件ID
            第九位：存储是否限制用户从服务器只能拉取本厂数据
            第十位：存储软件运行次数
            */
            string tempValue = "";
            try
            {
                curRegInfoStruct.RegInfoVer = RegList[0];
                curRegInfoStruct.RegUnit = RegList[1];
                curRegInfoStruct.RegUser = RegList[2];
                tempValue = RegList[3];
                if (tempValue == "1")
                {
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.UnlimitedVer;
                    //curResult = RegCheckResult.UnlimitedVer;
                }
                else if(tempValue == "2")
                {
                    //锁定用户软件
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.Lock;
                    //return;
                }
                else
                {
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.TrialVer;
                    //curResult = RegCheckResult.TrialVer;
                    curRegInfoStruct.TrialLimiteTime = DateTime.Parse(RegList[4]);
                    curRegInfoStruct.TrialLimiteCount = int.Parse(RegList[5]);
                }
                tempValue = RegList[6];
                if(tempValue == "0")
                {
                    curRegInfoStruct.curBindType = RegBindHDType.CPU;
                }
                else
                {
                    curRegInfoStruct.curBindType = RegBindHDType.HDD;
                }
                curRegInfoStruct.HDMarkCode = RegList[7];

                tempValue = RegList[8];
                if(string.IsNullOrEmpty(tempValue))
                {
                    curRegInfoStruct.LimiteDataUpdateFromServer = false;
                }
                else
                {
                    curRegInfoStruct.LimiteDataUpdateFromServer = true;
                    curRegInfoStruct.CYCID = tempValue;
                }
                curRegInfoStruct.AlreadyUseCount = int.Parse(RegList[9]);
            }
            catch (Exception E)
            {
                curRegInfoStruct.str_Err = E.Message;
                curRegInfoStruct.curRegCheckResult = RegCheckResult.Error;
                //curResult = RegCheckResult.Error;
                return;
            }
        }

        private bool JugeHardWareInfo()
        {

            switch (curRegInfoStruct.curBindType)
            {
                case RegBindHDType.HDD:
                    //绑定的硬盘
                    string curHDDCode = MyMethod.GetHddID();
                    curRegInfoStruct.HDDID = curHDDCode;
                    curRegInfoStruct.CPUID = MyMethod.GetCPUID();
                    if (curHDDCode != curRegInfoStruct.HDMarkCode)
                    {
                        //curResult = RegCheckResult.Mismatch;
                        curRegInfoStruct.curRegCheckResult = RegCheckResult.Mismatch;
                        curRegInfoStruct.str_Err = "硬件信息不匹配！";
                        return false;
                    }
                    break;
                case RegBindHDType.CPU:
                    //绑定的CPU
                    string curCPUCode = MyMethod.GetCPUID();
                    curRegInfoStruct.CPUID = curCPUCode;
                    curRegInfoStruct.HDDID = MyMethod.GetHddID();
                    if (curCPUCode != curRegInfoStruct.HDMarkCode)
                    {
                        //curResult = RegCheckResult.Mismatch;
                        curRegInfoStruct.curRegCheckResult = RegCheckResult.Mismatch;
                        curRegInfoStruct.str_Err = "硬件信息不匹配！";
                        return false;
                    }
                    break;
                default:
                    break;

            }

            //获取IP
            curRegInfoStruct.CurIP = MyMethod.GetLocalIPEx();

            //获取当前系统版本
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            curRegInfoStruct.CurAppVer = myFileVersion.FileVersion;

            return true;
        }

        public bool JugeDateLimite()
        {
            if (curRegInfoStruct .TrialLimiteTime< DateTime.Now)
            {
                //curResult = RegCheckResult.Overdue;
                curRegInfoStruct.curRegCheckResult = RegCheckResult.Overdue;
                curRegInfoStruct.str_Err = "软件使用已超期。";
                return false;
            }

            TimeSpan curSpan = curRegInfoStruct.TrialLimiteTime - DateTime.Now  ;

            int enUserDayCount = (int)curSpan.TotalDays;
            if(enUserDayCount<curSpan.TotalDays)
            {
                enUserDayCount++;
            }

            curRegInfoStruct.TrialRemainingDays = enUserDayCount; 

            //判断用户是否修改时间了
            if (GetAccessRegInfo())
            {
                //如果判断用户修改过时间，直接显示软件超期
                if(JugeAccessDataModify())
                {
                    curRegInfoStruct.curRegCheckResult = RegCheckResult.Overdue;
                    curRegInfoStruct.str_Err = "软件使用已超期。";
                    return false;
                }
            }

            return true;
        }

        private bool JugeUserCountLimite()
        {
            if (curRegInfoStruct.TrialLimiteCount == -1)
            {
                //说明不限制使用次数
                curRegInfoStruct.TrialRemainingCounts = -1;
                return true;
            }
            if (curRegInfoStruct.AlreadyUseCount > curRegInfoStruct.TrialLimiteCount)
            {
                //curResult = RegCheckResult.Overdue;
                curRegInfoStruct.curRegCheckResult = RegCheckResult.Overdue;
                curRegInfoStruct.str_Err = "软件使用已超期。";
                return false;
            }
            //enUseCount = LimiteCount - AllRunCount;
            curRegInfoStruct.TrialRemainingCounts = curRegInfoStruct.TrialLimiteCount - curRegInfoStruct.AlreadyUseCount;

            return true;
        }

        public bool AddSoftRunCount()
        {

            curRegInfoStruct.AlreadyUseCount++;
            int index = RegInfo.LastIndexOf("#");
            try
            {
                string  TempRegInfo = RegInfo.Substring(0, index+1);
                TempRegInfo += curRegInfoStruct.AlreadyUseCount.ToString();
                TempRegInfo = MyMethod.GetEecryptStr(TempRegInfo);
                MyMethod.DelFile(RegFilePath);
                MyMethod.StrToFile(RegFilePath, TempRegInfo);
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        ////提交系统运行信息
        //public void CommitSystemRunInfo(string RunInfo)
        //{
        //    opRemoteSevice.CommitLogInfo("1", RunInfo);
        //}

        ////提交系统关闭信息
        //public void CommitSystemCloseInfo()
        //{
        //    opRemoteSevice.CommitLogInfo("-1", "");
        //}
        #region Access库同步操作,暂时未用
        DataTable dt_AcessReg = new DataTable();
        DbAccess opDB = null;
        private bool GetAccessRegInfo()
        {
            string StrSql = "select * from BDUser where UserName='administrator'";
            opDB = new DbAccess(localService.DBAccess. curDBKind, localService.DBAccess.ConnStr);
            opDB.NeedThrowException = false;
            if(!opDB.GetDataTable(StrSql,ref dt_AcessReg))
            {
                curRegInfoStruct.str_Err = opDB.ErrMsg;
                return false;
            }
            return true;
        }

        private bool JugeAccessDataModify()
        {
            if(dt_AcessReg.Rows.Count==0)
            {
                //按说不该出现这种情况，就当用户清空数据空了，自动插入一条
                DataRow newRow = dt_AcessReg.NewRow();
                newRow["UserName"] = "administrator";
                newRow["Psw"] = MyMethod.GetEecryptStr(DateTime.Now.ToString("yyyy-MM-dd"));
                newRow["RealName"] = "管理员";
                //newRow[""] = "";
                //newRow[""] = "";
                dt_AcessReg.Rows.Add(newRow);
                UpdateAccessRegInfo();
                return false;
            }
            string TempValue = dt_AcessReg.Rows[0]["psw"].ToString();
            TempValue = MyMethod.GetDecryptStr(TempValue);
            if(string.IsNullOrEmpty(TempValue))
            {
                dt_AcessReg.Rows[0]["psw"] = MyMethod.GetEecryptStr(DateTime.Now.ToString("yyyy-MM-dd"));
                UpdateAccessRegInfo();
                return false;
            }
            DateTime LastTime = DateTime.Parse(TempValue);
            if(LastTime>DateTime.Now)
            {
                //说明用户手工修改时间了
                return true;
            }

            UpdateAccessRegInfo();
            return false;
        }
        private bool UpdateAccessRegInfo()
        {
            string TempValue = DateTime.Now.ToString("yyyy-MM-dd");
            dt_AcessReg.Rows[0]["psw"] = MyMethod.GetEecryptStr(TempValue);
            return opDB.UpdateDateTable(dt_AcessReg, "select * from BDUser where UserName='administrator'");
        }

        #endregion

    }

    

    //下载更新注册文件
    public class DownLoadRegFile
    {
        //远程注册服务操作对象
        private RemoteImport.OPWebServer opWeb = null;
        string ErrMsg = "";
        public bool RegFileAlreadyUpdate = false;

        RegInfoStruct curRegInfoStruct = null;

        public DownLoadRegFile()
        {
            opWeb = new RemoteImport.OPWebServer();
        }

        public void BeginOp()
        {
            BackgroundWorker opBack = new BackgroundWorker();
            opBack.WorkerSupportsCancellation = true;
            opBack.DoWork += opBack_DoWork;
            opBack.RunWorkerAsync();

            while(opBack.IsBusy)
            {
                try
                {
                    Application.DoEvents();

                }
                catch(Exception E)
                {

                }
            }
        }

        void opBack_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateRegFile();

            }
            catch (Exception E)
            {
                ErrMsg = E.Message;
            }
        }
             

        public void UpdateRegFile()
        {
            //获取服务端的注册字符串
            string SeverRegStr = GetNewRegStrInfo().Trim();
            if (string.IsNullOrEmpty(SeverRegStr))
            {
                return;
            }
            string RegFilePath = Application.StartupPath + "\\AppRun.dll";

            if(!MyMethod.CheckFileExists(RegFilePath))
            {
                RegFileAlreadyUpdate = true;
                //之前没有注册文件，则直接生成
                MyMethod.StrToFile(RegFilePath,SeverRegStr);
                return;
            }

            string curRegStr = MyMethod.FileToStr(RegFilePath).Trim();

            SeverRegStr = SeverRegStr.Replace("\r", "");
            SeverRegStr = SeverRegStr.Replace("\n", "");

            string RealSeverRegStr = MyMethod.GetDecryptStr(SeverRegStr);
            int index = RealSeverRegStr.LastIndexOf("#");
            RealSeverRegStr = RealSeverRegStr.Substring(0, index);

            string RealcurRegStr = "";

            if (!string.IsNullOrEmpty(curRegStr.Trim()))
            {
                curRegStr = curRegStr.Replace("\r", "");
                curRegStr = curRegStr.Replace("\n", "");

                RealcurRegStr = MyMethod.GetDecryptStr(curRegStr);
                index = RealcurRegStr.LastIndexOf("#");
                RealcurRegStr = RealcurRegStr.Substring(0, index);
            }
            //判断服务端与本地的注册码是否相同,因为注册码的最后一位记录的是当前的运行次数，所以前面要去掉最后一项
            if (RealcurRegStr == RealSeverRegStr)
            {
                return;
            }
            //如不相同，应用新的注册文件
            MyMethod.DelFile(RegFilePath);
            MyMethod.StrToFile(RegFilePath, SeverRegStr);
            RegFileAlreadyUpdate = true;
        }

        //获取用户最新的注册信息
        private string GetNewRegStrInfo()
        {
            string RegInfo = "";

            string CPUID = MyMethod.GetCPUID();

            string HddID = MyMethod.GetHddID();

            string strSql = "select * from 注册码管理 where CPU编号='" + CPUID + "' and 硬盘编号='" + HddID + "'";

            DataSet curSet = new DataSet();
            try
            {
                curSet = opWeb.GetDataSet(strSql);
                if (!string.IsNullOrEmpty(opWeb.ErrMsg))
                {
                    return "";
                }
                if (curSet.Tables[0].Rows.Count == 0)
                {
                    //用户信息没有提交注册，自动注册上
                    return "";
                }
                else
                {
                    RegInfo = curSet.Tables[0].Rows[0]["注册码"].ToString();
                }
            }
            catch (Exception E)
            {
                ErrMsg = E.Message;
                RegInfo = "";
            }
            return RegInfo;
        }

        public void BeginWriteLog(RegInfoStruct curRegInfoStruct)
        {
            this.curRegInfoStruct = curRegInfoStruct;
            BackgroundWorker bg_Log = new BackgroundWorker();
            bg_Log.WorkerSupportsCancellation = true;
            bg_Log.DoWork += bg_Log_DoWork;
            bg_Log.RunWorkerAsync();
        }

        void bg_Log_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            WriteLog(curRegInfoStruct);
            UpdateRegInfoToServer(curRegInfoStruct);
        }

        private void WriteLog(RegInfoStruct curRegInfoStruct)
        {
            try
            {
                if (string.IsNullOrEmpty(curRegInfoStruct.CPUID))
                {
                    curRegInfoStruct.CPUID = MyMethod.GetCPUID();
                }

                if (string.IsNullOrEmpty(curRegInfoStruct.HDDID))
                {
                    curRegInfoStruct.HDDID = MyMethod.GetHddID();
                }

                //登录日志
                string strSql = "insert into 系统使用日志(编号,所属单位,注册人姓名,采油厂标识,版本,日志时间,日志状态,授权类型,CPU编号,硬盘编号,用户IP,使用截止时间,软件可运行次数,软件已运行次数,备注) values('";
                strSql += MyMethod.GetGUID() + "','";
                strSql += curRegInfoStruct.RegUnit + "','";
                strSql += curRegInfoStruct.RegUser + "','";
                strSql += curRegInfoStruct.CYCID + "','";
                strSql += curRegInfoStruct.RegInfoVer + "',#";
                strSql += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#,";
                strSql += "0,'";

                strSql += GetCheckResultStr(curRegInfoStruct.curRegCheckResult) + "','";
                strSql += curRegInfoStruct.CPUID + "','";
                strSql += curRegInfoStruct.HDDID + "','";
                strSql += curRegInfoStruct.CurIP + "',#";
                strSql += curRegInfoStruct.TrialLimiteTime.ToString("yyyy-MM-dd") + "#,";
                strSql += curRegInfoStruct.TrialLimiteCount + ",";
                strSql += curRegInfoStruct.AlreadyUseCount + ",'";
                strSql += "登录" + "')";

                if (!opWeb.ExecSql(strSql, ref ErrMsg))
                {
                    int a = 1;
                }
            }
            catch (Exception E)
            {
                ErrMsg = E.Message;
            }
        }

        private void UpdateRegInfoToServer(RegInfoStruct curRegInfoStruct)
        {
            string strSql = "select * from 注册码管理 where CPU编号='" + curRegInfoStruct.CPUID + "' and 硬盘编号='" + curRegInfoStruct.HDDID + "'";

            DataSet curSet = new DataSet();
            try
            {
                curSet = opWeb.GetDataSet(strSql);
                if (!string.IsNullOrEmpty(opWeb.ErrMsg))
                {
                    return;
                }
                if (curSet.Tables[0].Rows.Count > 0)
                {
                    return;
                }

                DataRow newRow = curSet.Tables[0].NewRow();
                newRow["编号"] = MyMethod.GetGUID();
                newRow["所属单位"] = curRegInfoStruct.RegUnit;
                newRow["注册人姓名"] = curRegInfoStruct.RegUser;
                newRow["注册时间"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (curRegInfoStruct.curRegCheckResult == RegCheckResult.UnlimitedVer)
                {
                    newRow["授权类型"] = 1;
                }
                else
                {
                    newRow["授权类型"] = 0;
                }
                newRow["使用截止时间"] = curRegInfoStruct.TrialLimiteTime;
                newRow["软件可运行次数"] = curRegInfoStruct.TrialLimiteCount;
                if (curRegInfoStruct.LimiteDataUpdateFromServer)
                {
                    newRow["数据获取限制"] = 1;
                }
                else
                {
                    newRow["数据获取限制"] = 0;
                }

                if (!string.IsNullOrEmpty(curRegInfoStruct.CYCID))
                {
                    newRow["采油厂标识"] = curRegInfoStruct.CYCID;

                }
                newRow["注册码"] = MyMethod.FileToStr(Application.StartupPath + "\\AppRun.dll");
                if (curRegInfoStruct.curBindType == RegBindHDType.CPU)
                {
                    newRow["绑定硬件"] = 0;
                }
                else
                {
                    newRow["绑定硬件"] = 1;
                }
                newRow["版本"] = curRegInfoStruct.CurAppVer;
                newRow["CPU编号"] = curRegInfoStruct.CPUID;
                newRow["硬盘编号"] = curRegInfoStruct.HDDID;
                newRow["用户IP"] = curRegInfoStruct.CurIP;
                newRow["记录来源"] = "自动补充";

                curSet.Tables[0].Rows.Add(newRow);
                if (!opWeb.UpdateDataSet(curSet, strSql))
                {
                    string ErrMsg = opWeb.ErrMsg;
                }
            }
            catch(Exception E)
            {
                ErrMsg =  E.Message;
            }
        }

        private string GetCheckResultStr(RegCheckResult curResult)
        {
            string ResultStr = "";
            switch (curResult)
            {
                case RegCheckResult.Error:
                    ResultStr = "未知错误";
                    break;
                case RegCheckResult.Lock:
                    ResultStr = "锁定";
                    break;
                case RegCheckResult.Mismatch:
                    ResultStr = "硬件不匹配";
                    break;
                case RegCheckResult.Overdue:
                    ResultStr = "过期";
                    break;
                case RegCheckResult.PareseFileErr:
                    ResultStr = "解析错误";
                    break;
                case RegCheckResult.RegFileBeCracked:
                    ResultStr = "文件被破解";
                    break;
                case RegCheckResult.RegFileLose:
                    ResultStr = "注册文件丢失";
                    break;
                case RegCheckResult.TrialVer:
                    ResultStr = "试用版";
                    break;
                case RegCheckResult.UnlimitedVer:
                    ResultStr = "正式版";
                    break;
                default:
                    ResultStr = "状态异常";
                    break;
            }

            return ResultStr;
        }
    }

    //正式版 ，试用版，过期，硬件不匹配，解决授权文件错误，授权文件被破解，其它错误
    public enum RegCheckResult { UnlimitedVer, TrialVer, Overdue, Mismatch, RegFileLose,PareseFileErr,RegFileBeCracked,Error,Lock };

    public enum RegBindHDType{CPU,HDD};

    public class RegInfoStruct
    {
        //加密串版本号
        public string RegInfoVer = "";
        //授权单位
        public string RegUnit = "";
        //授权用户
        public string RegUser = "";
        //试用截止时间
        public DateTime TrialLimiteTime = DateTime.Now;

        //还可剩余使用天数
        public int TrialRemainingDays = 10;

        //试用次数
        public int TrialLimiteCount = 100;

        //试用剩余次数
        public int TrialRemainingCounts = 100;

        //硬件绑定类型
        public RegBindHDType curBindType = RegBindHDType.CPU;

        //用户硬件标识ID
        public string HDMarkCode = "";

        //存储是否限制用户从服务器只能拉取本厂数据
        public bool LimiteDataUpdateFromServer = true;

        //用户采油厂ID
        public string CYCID = "";

        //用户已经使用软件次数
        public int AlreadyUseCount = 0;

        //校验结果
        public RegCheckResult curRegCheckResult = RegCheckResult.TrialVer;

        //记录错误信息
        public string str_Err = "";

        //用户CPU
        public string CPUID = "";

        //用户硬盘
        public string HDDID = "";

        //用户IP
        public string CurIP = "";

        //当前软件运行版本
        public string CurAppVer = "";
    }
}
