using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;
using System;


namespace ReserveCommon
{
    //实体数据
    public interface IEntityData : ITreeNodeData
    {
        IconItemData Convert();
    }

    [Serializable]
    public abstract class AEntityData : ATreeNodeData, IEntityData
    {
        
        //public EntityType Type { get; set; }
        public virtual IconItemData Convert()
        {
            IconItemData data = new IconItemData();
            data.ID = this.ID;
            data.PID = this.PID;
            data.Text = this.Text;
            return data;
        }
    }

    //资产数据
    public interface IAssetsData : IEntityData
    {
        //之前的所属的项目ID
        long ProID { get; set; }
        //string Pjnd { get; set; }
        string GetText(SortInfoQueue sortList);
    }

    //描述分组实体
    [Serializable]
    public class GroupData : AEntityData
    {
        public SortType SortType { get; set; }
        public override IconItemData Convert()
        {
            IconItemData data = base.Convert();
            data.Image = Properties.Resources.purpleFloder;
            return data;
        }
    }

    //描述项目实体,即实体类，有别于ProjectInfo,后者为数据类、起中转于实体与数据库间的作用
    [Serializable]
    public class ProjectData : AEntityData
    {
        //树形分组，
        public GroupInfoQueue GroupList { get; set; }
        //列的显示顺序，及显示上下顺序
        public SortInfoQueue SortList { get; set; }

        public string Desciption { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public ProjectData()
        {
            GroupList = new GroupInfoQueue();
            SortList = new SortInfoQueue();
        }

        public ProjectData(ProjectInfoDto c) 
        {
            ID = c.Id.ToString();
            Text = c.MC;
            Desciption = c.Remark;
            CreateTime = c.CreateTime;
            UpdateTime = c.UpdateTime;

            GroupList = new GroupInfoQueue();
            SortList = new SortInfoQueue();

            GroupList.ConvertFrom(c.GroupList);
            SortList.ConvertFrom(c.SortList);
        }

        public void InitDefault()
        {
            if (GroupList == null || GroupList.Count <= 0)
                GroupList = GetDefaultGroup();
            if (SortList == null || SortList.Count <= 0)
                SortList = GetDefaultSort();
        }

        //获取默认的分组类型
        private static GroupInfoQueue GetDefaultGroup()
        {
            GroupInfoQueue lstSortInfo = new GroupInfoQueue();

            //lstSortInfo.Add(new GroupInfo() { Type = SortType.CYCMC });
            //lstSortInfo.Add(new GroupInfo() { Type = SortType.YTMC });

            return lstSortInfo;
        }

        //获取默认的排序类型
        private static SortInfoQueue GetDefaultSort()
        {
            SortInfoQueue lstSortInfo = new SortInfoQueue();

            lstSortInfo.Add(new SortInfo() { Type = SortType.DYMC });
            lstSortInfo.Add(new SortInfo() { Type = SortType.DYDM });

            return lstSortInfo;
        }

        public override IconItemData Convert()
        {
            IconItemData data = base.Convert();
            if (string.IsNullOrEmpty(ID))
                data.Image = Properties.Resources.greenAdd;
            else
                data.Image = Properties.Resources.blueFloder;

            string descStr = "", updateTimeStr = "";
            if (!string.IsNullOrEmpty(this.Desciption))
                descStr = "备注：" + this.Desciption;
            if (UpdateTime != null)
                updateTimeStr = "更新日期：" + UpdateTime.ToString("yyyy-MM-dd hh:mm");

            if (string.IsNullOrEmpty(descStr) && string.IsNullOrEmpty(updateTimeStr))
                data.Tip = null;
            else if (!string.IsNullOrEmpty(descStr) && !string.IsNullOrEmpty(updateTimeStr))
                data.Tip = updateTimeStr + "\r\n" + descStr;
            else
                data.Tip = updateTimeStr + descStr;
            return data;
        }

        public static ProjectData GetNewProjectData(int id)
        {
            ProjectData data = new ProjectData();
            data.ID = id.ToString();
            data.SortList = GetDefaultSort();
            data.GroupList = GetDefaultGroup();
            data.UpdateTime = DateTime.Now;
            data.CreateTime = DateTime.Now;
            data.Desciption = "";
            data.Text = $"工程{id}"; ;

            return data;
        }

        public ProjectInfoDto GetProjectInfoDto()
        {
            ProjectInfoDto projectInfoDto = new ProjectInfoDto();
            projectInfoDto.MC = this.Text;
            projectInfoDto.Remark = this.Desciption;
            projectInfoDto.SortList = this.SortList.ConvertTo();
            projectInfoDto.GroupList=this.GroupList.ConvertTo();
            projectInfoDto.CreateTime = this.CreateTime;
            projectInfoDto.UpdateTime = DateTime.Now;

            return projectInfoDto;
        }
    }

    [Serializable]
    public class FunctionData : AEntityData
    {
        UnitFunctionType functionType;

        public UnitFunctionType FunctionType
        {
            get { return functionType; }
            set
            {
                if (functionType == value)
                    return;
                functionType = value;
                functionGroupType = InternalMethods.GetUnitFunctionGroupType(functionType);
                Text = EnumDictionary<UnitFunctionType>.Instance.GetDescription(functionType);
            }
        }

        UnitFunctionGroupType functionGroupType = new UnitFunctionGroupType();

        public UnitFunctionGroupType FunctionGroupType
        {
            get { return functionGroupType; }
        }

        public FunctionData()
        {
            functionGroupType = InternalMethods.GetUnitFunctionGroupType(functionType);
            Text = EnumDictionary<UnitFunctionType>.Instance.GetDescription(functionType);
        }

        public override IconItemData Convert()
        {
            IconItemData data = base.Convert();
            data.Image = InternalMethods.GetImageByUnitFunctionType(functionType);
            BDDescriptionAttribute bdDescAttr = EnumAttrDict<UnitFunctionType, BDDescriptionAttribute>.Instance.GetAttribute(functionType);
            data.Tip = bdDescAttr.Tip;

            return data;
        }
    }

}