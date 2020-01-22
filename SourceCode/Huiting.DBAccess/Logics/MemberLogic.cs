using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using XYY.Windows.SAAS.Contract.Configs;
using XYY.Windows.SAAS.Contract.Dto;
using XYY.Windows.SAAS.Contract.Models;
using XYY.Windows.SAAS.DB.Helpers;

namespace XYY.Windows.SAAS.DB.Logics
{
    public class MemberLogic
    {
        private readonly string tableName_MemberExchangeProductDto = CacheService.GetInstance().GetTableName<MemberExchangeProductDto>();

        /// <summary>
        /// 获取可用的会员兑换商品
        /// </summary>
        /// <param name="getKey"></param>
        /// <returns></returns>
        public Dictionary<string, MemberExchangeProductDto> QueryEnable_MemberExchangeProduct(Func<MemberExchangeProductDto, string> getKey)
        {
            var sql = $"SELECT * FROM {tableName_MemberExchangeProductDto} WHERE OrganSign='{CacheInfo.Drugstore.OrganSign}' AND Yn=1";
            var list = DapperHelper.SqlWithParams<MemberExchangeProductDto>(sql);
            return list.ToDictionary(getKey);
        }

        /// <summary>
        /// 会员等级
        /// </summary>
        /// <returns></returns>
        public List<MemberLevelModel> GetMemberLevelModels()
        {
            List<MemberLevelModel> list = new List<MemberLevelModel>();
            try
            {
                var sql = $"select *  from saas_member_level where yn=1 and  Organsign='{CacheInfo.Drugstore.OrganSign}' and Name is not null and Name<>''";
                list = DapperHelper.SqlWithParams<MemberLevelModel>(sql, null)?.ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }

            return list;
        }

        /// <summary>
        /// 积分兑换商品上传成功后，本地数据处理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool MembersPointExchangeProduct(IntergralExchangeOrderModel models)
        {
            try
            {
                return DapperHelper.SQLLiteSession((conn, trans) =>
                {
                    string sql = $" update saas_member_base set point='{models.MemberBase.Point - models.TotalIntegral}'  where guid='{models.MemberBase.Guid}' and  Organsign='{models.MemberBase.OrganSign}'";
                    conn.Execute(sql, null, trans);
                    return true;
                });
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 获取会员积分变更历史分页数据
        /// </summary>
        /// <param name="query">通用查询条件</param>
        /// <returns></returns>
        public Page<MemberPointHistoryModel> GetMemberPointHistoryModels(CommonQuery query)
        {
            Page<MemberPointHistoryModel> page = new Page<MemberPointHistoryModel>();
            try
            {
                if (string.IsNullOrWhiteSpace(query.Name)) return page;
                StringBuilder sql = new StringBuilder();
                sql.Append($"SELECT a.*,b.Name as CreateUserName FROM saas_member_point_history  as a LEFT JOIN saas_employee as b on a.CreateUser=b.Id where a.Yn = '1'");
                sql.Append($" and a.organSign='{CacheInfo.Drugstore.OrganSign}' and a.Guid not null and a.Guid='{query.Name}'");
                int totalCount = DBService.GetInstance().GetTotalCount(string.Format("select count(*) from ({0})", sql));
                sql.AppendFormat(" order by datetime(a.CreateTime) desc limit {0} offset {1};", query.PageSize, (query.PageIndex - 1) * query.PageSize);
                var items = DapperHelper.SqlWithParams<MemberPointHistoryModel>(sql.ToString(), null);
                if (items != null)
                {
                    page = new Page<MemberPointHistoryModel> { PageIndex = query.PageIndex, PageSize = query.PageSize };
                    page.TotalCount = totalCount;
                    page.Items = new ObservableCollection<MemberPointHistoryModel>(items);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return page;
        }

        /// <summary>
        /// 通过会员id获取会员基础信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public MemberBase GetMemberBase(string memberId, bool isAll = false)
        {
            //string sql = $"SELECT mem.*,lev.value as priceStrategy,lev.name as vipLevelName,pot.consumePrice,pot.point as addPerPoint,lev.discount FROM saas_Member_Base as mem LEFT JOIN (select level.*,dict.value from saas_Member_Level as level left join saas_system_dict as dict on level.priceStrategy=dict.id) as lev on mem.vipLevelId=lev.id left join (select * from saas_member_point_exchange as exch left join saas_system_dict as dict on exch.exchangeType=dict.id where dict.value='1' and exch.organSign='{CacheInfo.Drugstore.OrganSign}' and exch.Yn=1) as pot on mem.vipLevelId=pot.memberLevelId where mem.yn='1' and mem.organSign='{CacheInfo.Drugstore.OrganSign}' and lev.organSign='{CacheInfo.Drugstore.OrganSign}' and mem.guid='{memberId}'";
            string sql = null;
            if (!isAll)
                sql = $"SELECT mem.*,lev.value as priceStrategy,lev.name as vipLevelName,lev.isSpecial,pot.consumePrice,pot.point as addPerPoint,lev.discount,card.amount as memberCardAmount,card.bonus as memberCardBonus,card.totalAmount as memberCardTotalAmount FROM saas_Member_Base as mem left join saas_member_prepay_card as card on mem.guid=card.memberGuid LEFT JOIN (select level.*,dict.value from saas_Member_Level as level left join saas_system_dict as dict on level.priceStrategy=dict.id) as lev on mem.vipLevelId=lev.id left join (select * from saas_member_level_pointexchange_relation where organSign='{CacheInfo.Drugstore.OrganSign}' and Yn=1) as rel on mem.vipLevelId=rel.memberLevelId left join (select * from saas_member_point_exchange as exch left join saas_system_dict as dict on exch.exchangeType=dict.id where dict.value='1' and exch.organSign='{CacheInfo.Drugstore.OrganSign}' and exch.Yn=1) as pot on rel.pointExchangeId=pot.id where mem.Yn=1 and mem.state=1 and mem.guid is not null and (date(mem.expriedTime)>=date('{DBService.GetInstance().GetSqlDateString(CacheInfo.Global.ServerTime)}') or mem.expriedTime isnull) and mem.guid='{memberId}'";
            else
                sql = $"SELECT mem.*,lev.value as priceStrategy,lev.name as vipLevelName,lev.isSpecial,pot.consumePrice,pot.point as addPerPoint,lev.discount,card.amount as memberCardAmount,card.bonus as memberCardBonus,card.totalAmount as memberCardTotalAmount FROM saas_Member_Base as mem left join saas_member_prepay_card as card on mem.guid=card.memberGuid LEFT JOIN (select level.*,dict.value from saas_Member_Level as level left join saas_system_dict as dict on level.priceStrategy=dict.id) as lev on mem.vipLevelId=lev.id left join (select * from saas_member_level_pointexchange_relation where organSign='{CacheInfo.Drugstore.OrganSign}' and Yn=1) as rel on mem.vipLevelId=rel.memberLevelId left join (select * from saas_member_point_exchange as exch left join saas_system_dict as dict on exch.exchangeType=dict.id where dict.value='1' and exch.organSign='{CacheInfo.Drugstore.OrganSign}' and exch.Yn=1) as pot on rel.pointExchangeId=pot.id where mem.guid='{memberId}'";
            return DapperHelper.SqlWithParamsSingle<MemberBase>(sql, null);
        }
        /// <summary>
        /// 获取储值赠送阶梯金额
        /// </summary>
        /// <returns></returns>
        public List<MemberPrepayCardConfigDto> GetMemberPrepayCardConfig()
        {
            string sql = "select * from saas_member_prepay_card_config " +
                "where Yn=1 and OrganSign='"+ CacheInfo.Drugstore.OrganSign+"'";
            var items = DapperHelper.SqlWithParams<MemberPrepayCardConfigDto>(sql, null);
            return items ==null ?new List<MemberPrepayCardConfigDto>(): new List<MemberPrepayCardConfigDto>(items);
        }
        /// <summary>
        /// 获取会员分页数据
        /// </summary>
        /// <param name="query">通用查询条件</param>
        /// <returns></returns>
        public Page<MemberBase> GetMembers(CommonQuery query)
        {
            Page<MemberBase> page = new Page<MemberBase>();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append($"SELECT mem.*,lev.value as priceStrategy,lev.name as vipLevelName,lev.isSpecial,pot.consumePrice,pot.point as addPerPoint,lev.discount,card.amount as memberCardAmount,card.bonus as memberCardBonus,card.totalAmount as memberCardTotalAmount FROM saas_Member_Base as mem left join saas_member_prepay_card as card on mem.guid=card.memberGuid LEFT JOIN (select level.*,dict.value from saas_Member_Level as level left join saas_system_dict as dict on level.priceStrategy=dict.id) as lev on mem.vipLevelId=lev.id left join (select * from saas_member_level_pointexchange_relation where organSign='{CacheInfo.Drugstore.OrganSign}' and Yn=1) as rel on mem.vipLevelId=rel.memberLevelId left join (select * from saas_member_point_exchange as exch left join saas_system_dict as dict on exch.exchangeType=dict.id where dict.value='1' and exch.organSign='{CacheInfo.Drugstore.OrganSign}' and exch.Yn=1) as pot on rel.pointExchangeId=pot.id where mem.state=1 and mem.guid is not null and (date(mem.expriedTime)>=date('{DBService.GetInstance().GetSqlDateString(CacheInfo.Global.ServerTime)}') or mem.expriedTime isnull)");
                if (!string.IsNullOrWhiteSpace(query.Name))
                    sql.AppendFormat(" and (mem.name like '%{0}%' or mem.cartNo like '%{0}%'or mem.telephone like '%{0}%' or mem.mixedQuery like '%{0}%') ", query.Name);
                sql.Append($" and mem.yn='1' and mem.organSign='{CacheInfo.Drugstore.OrganSign}' and lev.organSign='{CacheInfo.Drugstore.OrganSign}' ");
                int totalCount = DBService.GetInstance().GetTotalCount(string.Format("select count(*) from ({0})", sql));
                sql.AppendFormat("order by datetime(mem.CreateTime) desc limit {0} offset {1};", query.PageSize, (query.PageIndex - 1) * query.PageSize);
                var items = DapperHelper.SqlWithParams<MemberBase>(sql.ToString(), null);
                if (totalCount > 0 && items != null)
                {
                    page = new Page<MemberBase> { PageIndex = query.PageIndex, PageSize = query.PageSize };
                    page.TotalCount = totalCount;
                    page.Items = new ObservableCollection<MemberBase>(items);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return page;
        }

        /// <summary>
        /// 获取会员
        /// </summary>
        /// <param name="query">通用查询条件-guid</param>
        /// <returns></returns>
        public Page<MemberBase> GetMembersByGuid(CommonQuery query)
        {
            Page<MemberBase> page = new Page<MemberBase>();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append($"SELECT mem.*,lev.value as priceStrategy,lev.name as vipLevelName,lev.isSpecial,pot.consumePrice,pot.point as addPerPoint,lev.discount FROM saas_Member_Base as mem LEFT JOIN (select level.*,dict.value from saas_Member_Level as level left join saas_system_dict as dict on level.priceStrategy=dict.id) as lev on mem.vipLevelId=lev.id left join (select * from saas_member_point_exchange as exch left join saas_system_dict as dict on exch.exchangeType=dict.id where dict.value='1' and exch.organSign='{CacheInfo.Drugstore.OrganSign}' and exch.Yn=1) as pot on mem.vipLevelId=pot.memberLevelId where mem.state=1 and mem.guid is not null and (date(mem.expriedTime)>=date('{DBService.GetInstance().GetSqlDateString(CacheInfo.Global.ServerTime)}') or mem.expriedTime isnull)");
                if (!string.IsNullOrWhiteSpace(query.Name))
                    sql.AppendFormat(" and mem.guid ='{0}' ", query.Name);
                sql.Append($" and mem.yn='1' and mem.organSign='{CacheInfo.Drugstore.OrganSign}' and lev.organSign='{CacheInfo.Drugstore.OrganSign}' ");
                int totalCount = DBService.GetInstance().GetTotalCount(string.Format("select count(*) from ({0})", sql));
                sql.AppendFormat("order by datetime(mem.CreateTime) desc limit {0} offset {1};", query.PageSize, (query.PageIndex - 1) * query.PageSize);
                var items = DapperHelper.SqlWithParams<MemberBase>(sql.ToString(), null);
                if (totalCount > 0 && items != null)
                {
                    page = new Page<MemberBase> { PageIndex = query.PageIndex, PageSize = query.PageSize };
                    page.TotalCount = totalCount;
                    page.Items = new ObservableCollection<MemberBase>(items);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return page;
        }
    }
}