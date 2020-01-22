using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [Serializable]
    public class NodeEnity
    {
        public OrganizationType OrgType;
        public string OrgValue;

        public string GetFieldName()
        {
            string result = null;
            switch (OrgType)
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
                    result = "";
                    break;
            }
            return result;
        }

        public string GetSqlPart()
        {
            string result = null;
            switch (OrgType)
            {
                case OrganizationType.Fgsmc:
                    result = "fgsmc='" + OrgValue + "'";
                    break;
                case OrganizationType.Cycmc:
                    result = "cycmc='" + OrgValue + "'";
                    break;
                case OrganizationType.Ytmc:
                    result = "ytmc='" + OrgValue + "'";
                    break;
                case OrganizationType.Dydm:
                    result = "dydm='" + OrgValue + "'";
                    break;
                case OrganizationType.Root:
                default:
                    break;
            }

            return result;
        }
    }
}
