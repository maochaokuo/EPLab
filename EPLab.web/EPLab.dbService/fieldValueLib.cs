using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class fieldValueLib : Repository<FieldValues>
    {
        public fieldValueLib(string connS) : base(connS)
        {
        }

        public override List<FieldValues> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fieldValues ";
                var qry = con.Query<FieldValues>(sql).ToList();
                return qry;
            }
        }

        public List<FieldValues> FieldValueByRowId(Guid rowId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fieldValues " +
                    $"where rowId=@RowId";
                var qry = con.Query<FieldValues>(sql,
                    new { RowId = rowId }).ToList();
                return qry;
            }
        }

        public List<FieldValues> FieldValueByFieldId(Guid fieldId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fieldValues " +
                    $"where fieldId=@FieldId";
                var qry = con.Query<FieldValues>(sql,
                    new { FieldId = fieldId }).ToList();
                return qry;
            }
        }

        public override FieldValues GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fieldValues " +
                    $"where fieldValueId=@fieldValueId";
                var qry = conn.Query<FieldValues>(sql,
                    new { fieldValueId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(FieldValues rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into fieldValues " +
                    $"(RowId,FieldId,FieldValue) " +
                    $"values (@RowId,@FieldId,@FieldValue)";
                con.Execute(sql,
                    new
                    {
                        //FieldValueId = rec.FieldValueId,
                        RowId = rec.RowId,
                        FieldId = rec.FieldId,
                        FieldValue = rec.FieldValue
                    });
            }
            return ret;
        }

        public override string Update(FieldValues rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update fieldValues " +
                    $"set FieldValue=@FieldValue " +
                    $"where FieldValueId=@FieldValueId";
                con.Execute(sql,
                    new
                    {
                        FieldValueId = rec.FieldValueId,
                        //RowId = rec.RowId,
                        //FieldId = rec.FieldId,
                        FieldValue = rec.FieldValue
                    });
            }
            return ret;
        }
        public override string Delete(FieldValues rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from fieldValues " +
                    $"where FieldValueId=@FieldValueId";
                con.Execute(sql, new
                {
                    FieldValueId = rec.FieldValueId,
                    //RowId = rec.RowId,
                    //FieldId = rec.FieldId,
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
from fieldValues a
join allIdHistory b on a.fieldId = uid 
where b.tag = @tag";
                con.Execute(sql, new
                {
                    tag = tag
                });
                string sql2 = @"
delete a
from fieldValues a
join allIdHistory b on a.rowId = uid
where b.tag = @tag";
                con.Execute(sql2, new
                {
                    tag = tag
                });
            }
            return ret;
        }
    }
}
