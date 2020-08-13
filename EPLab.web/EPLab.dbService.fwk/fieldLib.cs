using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPLab.dbService
{
    public class fieldLib : Repository<fields>
    {
        public fieldLib(string connS) : base(connS)
        {
        }

        public override List<fields> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields ";
                var qry = con.Query<fields>(sql).ToList();
                return qry;
            }
        }
        public List<T> Query<T>(string sql
            , DynamicParameters paras)
        {
            using (var con = GetConn())
            {
                var qry = con.Query<T>(sql, paras).ToList();
                return qry;
            }
        }
        public List<fields> FieldsByTableId(Guid tableId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields " +
                    $"where tableId=@TableId " +
                    $"order by tableId, defaultOrder";
                var qry = con.Query<fields>(sql,
                    new { TableId = tableId }).ToList();
                return qry;
            }
        }
        public override fields GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields " +
                    $"where fieldId=@fieldId";
                var qry = conn.Query<fields>(sql, 
                    new { fieldId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(fields rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into fields " +
                    $"(FieldId,TableId,FieldName,FieldDesc," +
                    $"PrimaryOrder,ForeignFieldId,DefaultValue,DefaultOrder) " +
                    $"values (@FieldId,@TableId,@FieldName,@FieldDesc," +
                    $"@PrimaryOrder,@ForeignFieldId,@DefaultValue,@DefaultOrder)";
                con.Execute(sql,
                    new
                    {
                        FieldId = rec.fieldId,
                        TableId = rec.tableId,
                        FieldName = rec.fieldName,
                        FieldDesc = rec.fieldDesc,
                        PrimaryOrder = rec.primaryOrder,
                        ForeignFieldId = rec.foreignFieldId,
                        DefaultValue = rec.defaultValue,
                        DefaultOrder = rec.defaultOrder
                    });
            }
            return ret;
        }

        public override string Update(fields rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update fields " +
                    $"set TableId=@TableId, FieldName=@FieldName, " +
                    $"FieldDesc=@FieldDesc, PrimaryOrder=@PrimaryOrder," +
                    $"ForeignFieldId=@ForeignFieldId, " +
                    $"DefaultValue=@DefaultValue" +
                    $"where FieldId=@FieldId";
                con.Execute(sql,
                    new
                    {
                        FieldId = rec.fieldId,
                        TableId = rec.tableId,
                        FieldName = rec.fieldName,
                        FieldDesc = rec.fieldDesc,
                        PrimaryOrder = rec.primaryOrder,
                        ForeignFieldId = rec.foreignFieldId,
                        DefaultValue = rec.defaultValue
                    });
            }
            return ret;
        }
        public override string Delete(fields rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from fields " +
                    $"where FieldId=@FieldId";
                con.Execute(sql, new
                {
                    FieldId = rec.fieldId
                });
            }
            return ret;
        }

        public override string DeleteByTag(string tag)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = @"
delete a
from fields a
join allIdHistory b on a.fieldId = uid 
where b.tag = @tag";
                con.Execute(sql, new
                {
                    tag = tag
                });
            }
            return ret;
        }
    }
}
