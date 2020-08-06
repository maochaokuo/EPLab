using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class fieldLib : Repository<Fields>
    {
        public fieldLib(string connS) : base(connS)
        {
        }

        public override List<Fields> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields ";
                var qry = con.Query<Fields>(sql).ToList();
                return qry;
            }
        }
        public List<Fields> FieldsByTableId(Guid tableId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields " +
                    $"where tableId=@TableId";
                var qry = con.Query<Fields>(sql,
                    new { TableId = tableId }).ToList();
                return qry;
            }
        }
        public override Fields GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields " +
                    $"where fieldId=@fieldId";
                var qry = conn.Query<Fields>(sql, 
                    new { fieldId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(Fields rec)
        {
            //undone (1) !!... defaultOrder
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
                        FieldId = rec.FieldId,
                        TableId = rec.TableId,
                        FieldName = rec.FieldName,
                        FieldDesc = rec.FieldDesc,
                        PrimaryOrder = rec.PrimaryOrder,
                        ForeignFieldId = rec.ForeignFieldId,
                        DefaultValue = rec.DefaultValue,
                        DefaultOrder = rec.DefaultOrder
                    });
            }
            return ret;
        }

        public override string Update(Fields rec)
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
                        FieldId = rec.FieldId,
                        TableId = rec.TableId,
                        FieldName = rec.FieldName,
                        FieldDesc = rec.FieldDesc,
                        PrimaryOrder = rec.PrimaryOrder,
                        ForeignFieldId = rec.ForeignFieldId,
                        DefaultValue = rec.DefaultValue
                    });
            }
            return ret;
        }
        public override string Delete(Fields rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from fields " +
                    $"where FieldId=@FieldId";
                con.Execute(sql, new
                {
                    FieldId = rec.FieldId
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
