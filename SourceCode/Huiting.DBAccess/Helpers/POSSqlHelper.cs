using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYY.Windows.SAAS.Contract.Attributes;
using XYY.Windows.SAAS.Contract.Configs;

namespace XYY.Windows.SAAS.DB.Helpers
{
    internal class POSQuerySqlHelper
    {
        private SqlCommonQuery sqlQuery = new SqlCommonQuery();

        public POSQuerySqlHelper(SqlCommonQuery query)
        {
            sqlQuery = query;
        }

        /// <summary>
        /// 所有商品
        /// </summary>
        /// <returns></returns>
        public string Sql_Product() => $"SELECT * FROM saas_product_baseinfo WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// <summary>
        /// 所有可用商品
        /// </summary>
        /// <returns></returns>
        public string Sql_Product1() => $"SELECT * FROM saas_product_baseinfo WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn} AND Used=1";

        /// <summary>
        /// 所有积分商品
        /// </summary>
        /// <returns></returns>
        public string Sql_IntegralProduct() => $" select ipro.Integral ExchangeIntegral , bpro.*  from (select * from  saas_member_exchange_product WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}) ipro left join saas_product_baseinfo  bpro on ipro.OrganSign=bpro.OrganSign and ipro.Yn=bpro.Yn and ipro.ProductPref=bpro.Pref ";

        /// <summary>
        /// 所有批号库存
        /// </summary>
        /// <returns></returns>
        public string Sql_Lotnum() => $"SELECT * FROM saas_inventory_lot_number WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn} AND Status = 1";

        /// <summary>
        /// 所在未过期且合格的批号库存
        /// </summary>
        /// <returns></returns>
        public string Sql_Lotnum1() => $"SELECT * FROM saas_inventory_lot_number WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn} AND date( ExpirationDate ) >= date( '{CacheInfo.Global.ServerTime.ToString("yyyy-MM-dd")}' ) AND Status = 1";

        /// <summary>
        /// 所有库存
        /// </summary>
        /// <returns></returns>
        public string Sql_Inventory() => $"SELECT * FROM saas_inventory WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// <summary>
        /// 所有架位
        /// </summary>
        /// <returns></returns>
        public string Sql_Position() => $"SELECT * FROM saas_position WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// 所有员工
        /// </summary>
        /// <returns></returns>
        public string Sql_Employee_Enable() => $"SELECT * FROM saas_employee WHERE OrganSign='{sqlQuery.OrganSign}' AND WorkingState=1 AND IsDisabled=0";
        /// 所有员工
        /// </summary>
        /// <returns></returns>
        public string Sql_Employee() => $"SELECT * FROM saas_employee WHERE OrganSign='{sqlQuery.OrganSign}'";

        /// 所有员工角色关系
        /// </summary>
        /// <returns></returns>
        public string Sql_EmployeeRole() => $"SELECT * FROM saas_employee_role WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// 所有角色
        /// </summary>
        /// <returns></returns>
        public string Sql_Role() => $"SELECT * FROM saas_role WHERE ((SystemRole=0 AND OrganSign='{sqlQuery.OrganSign}') or SystemRole=1) AND Yn={sqlQuery.Yn}";

        /// 所有订单
        /// </summary>
        /// <returns></returns>
        public string Sql_Order() => $"SELECT * FROM saas_order_info WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// 所有指定状态的订单
        /// </summary>
        /// <param name="status">0正常销售 1挂单 2退货 3宜块钱</param>
        /// <returns></returns>
        public string Sql_Order(int[] status) => $"SELECT * FROM saas_order_info WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn} AND status in ({string.Join(",", status)}) and payStatus<10";

        /// 所有订单明细
        /// </summary>
        /// <returns></returns>
        public string Sql_OrderDetail() => $"SELECT * FROM saas_order_detail WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// 所有会员
        /// </summary>
        /// <returns></returns>
        public string Sql_MemberBase() => $"SELECT * FROM saas_member_base WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";

        /// <summary>
        /// 查询当前机构下载所有处方登记输入的历史记录。
        /// </summary>
        public string Sql_PrescriptionInputHistory() => $"SELECT * FROM saas_prescription_input_history WHERE OrganSign = '{ sqlQuery.OrganSign }'";

        /// 当前机构下可用的全量表数据sql
        /// </summary>
        /// <returns></returns>
        //public string Sql_Table(Type tableType) => $"SELECT * FROM {((DataTableAttribute[])tableType.GetCustomAttributes(typeof(DataTableAttribute), false))[0].TableName} WHERE OrganSign='{sqlQuery.OrganSign}' AND Yn={sqlQuery.Yn}";
    }

    public class SqlCommonQuery
    {
        /// <summary>
        /// 机构号
        /// </summary>
        public string OrganSign { get; set; }

        /// <summary>
        /// 是否有效：1 有效， 0 无效
        /// </summary>
        public int Yn { get; set; }
    }
}