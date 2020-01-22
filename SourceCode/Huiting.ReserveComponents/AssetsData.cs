using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;
using ReserveCommon;

namespace ReserveComponents
{
    public class AssetsData : UnitBasicDataDto, IAssetsData, IEntityData
    {
        public string ID
        {
            get
            {
                return DYDM;
            }
            set
            {
                DYDM = value;
            }
        }

        public string Text
        {
            get
            {
                return DYMC;
            }
            set
            {

            }
        }

        public string PID { get; set; }

        public AssetsData()
        {

        }

        public AssetsData(UnitBasicDataDto unitBasicDataDto)
        {
            ObjectChildItemSetter.SetProperties(unitBasicDataDto, this);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IconItemData Convert()
        {
            IconItemData data = new IconItemData();
            data.Text = this.Text;
            data.Image = Properties.Resources.unit_72;
            return data;
        }

        public void Dispose()
        {

        }

        public string GetText(SortInfoQueue sortList)
        {
            string values = null;

            if (sortList == null || sortList.Count <= 0)
            {
                values = Text;
            }
            else
            {
                foreach (SortInfo item in sortList)
                {
                    object objValue = PublicMethods.GetPropertyValue(this, item.Type.ToString());
                    if (objValue == null)
                        continue;
                    string strValue = objValue.ToString().Trim();
                    if (string.IsNullOrEmpty(strValue))
                        continue;
                    if (!string.IsNullOrEmpty(values))
                        values += " " + sortList.Separator + " ";
                    values += strValue;
                }
            }

            return values;
        }

        public List<NodeEnity> GetLstNodeEntity()
        {
            List<NodeEnity> lstNE;
            NodeEnity neDydm = new NodeEnity() { OrgType = OrganizationType.Dydm, OrgValue = this.DYDM };
            NodeEnity neOil = new NodeEnity() { OrgType = OrganizationType.Ytmc, OrgValue = "0_" + this.FGSMC + "_" + this.CYCMC + "_" + this.YTMC };
            NodeEnity neCycmc = new NodeEnity() { OrgType = OrganizationType.Cycmc, OrgValue = "0_" + this.FGSMC + "_" + this.CYCMC };
            NodeEnity neFgsmc = new NodeEnity() { OrgType = OrganizationType.Fgsmc, OrgValue = "0_" + this.FGSMC };
            NodeEnity neRoot = new NodeEnity() { OrgType = OrganizationType.Root, OrgValue = "null" };

            lstNE = new List<NodeEnity>() { neDydm, neOil, neCycmc, neFgsmc, neRoot };
            return lstNE;
        }

        public string GetOrgValue(OrganizationType orgType)
        {
            string orgValue;
            switch (orgType)
            {
                case OrganizationType.Root:
                    orgValue = "null";
                    break;
                case OrganizationType.Fgsmc:
                    orgValue = "0_" + this.FGSMC;
                    break;
                case OrganizationType.Cycmc:
                    orgValue = "0_" + this.FGSMC + "_" + this.CYCMC;
                    break;
                case OrganizationType.Ytmc:
                    orgValue = "0_" + this.FGSMC + "_" + this.CYCMC + "_" + this.YTMC;
                    break;
                case OrganizationType.Dydm:
                default:
                    orgValue = this.DYDM;
                    break;
            }

            return orgValue;
        }
    }
}
