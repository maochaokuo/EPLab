using Dapper;
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPLab.dbService
{
    public class rowLib : Repository<rows>
    {
        public rowLib(string connS) : base(connS)
        {
        }

        public override List<rows> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows ";
                var qry = con.Query<rows>(sql).ToList();
                return qry;
            }
        }

        public  List<rows> RowsByTableId(Guid tableId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows " +
                    $"where tableId=@TableId";
                var qry = con.Query<rows>(sql,
                    new { TableId = tableId }).ToList();
                return qry;
            }
        }

        public override rows GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows " +
                    $"where rowId=@rowId";
                var qry = conn.Query<rows>(sql,
                    new { rowId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(rows rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into rows " +
                    $"(RowId,TableId) " +
                    $"values (@RowId,@TableId)";
                con.Execute(sql,
                    new
                    {
                        RowId = rec.rowId,
                        TableId = rec.tableId
                    });
            }
            return ret;
        }

        public override string Update(rows rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"update rows " +
                    $"set TableId=@TableId " +
                    $"where RowId=@RowId";
                con.Execute(sql,
                    new
                    {
                        tableId = rec.tableId,
                        rowId = rec.rowId
                    });
            }
            return ret;
        }
        public override string Delete(rows rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from rows " +
                    $"where rowId=@rowId";
                con.Execute(sql, new
                {
                    rowId = rec.rowId
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
from rows a
join allIdHistory b on a.tableId = uid or a.rowId = uid
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
