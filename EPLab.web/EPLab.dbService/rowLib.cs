using Dapper;
using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EPLab.dbService
{
    public class rowLib : Repository<Rows>
    {
        public rowLib(string connS) : base(connS)
        {
        }

        public override List<Rows> GetAll()
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows ";
                var qry = con.Query<Rows>(sql).ToList();
                return qry;
            }
        }

        public  List<Rows> RowsByTableId(Guid tableId)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows " +
                    $"where tableId=@TableId";
                var qry = con.Query<Rows>(sql,
                    new { TableId = tableId }).ToList();
                return qry;
            }
        }

        public override Rows GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from rows " +
                    $"where rowId=@rowId";
                var qry = conn.Query<Rows>(sql,
                    new { rowId = gid }).SingleOrDefault();
                return qry;
            }
        }

        public override string Insert(Rows rec)
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
                        RowId = rec.RowId,
                        TableId = rec.TableId
                    });
            }
            return ret;
        }

        public override string Update(Rows rec)
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
                        tableId = rec.TableId,
                        rowId = rec.RowId
                    });
            }
            return ret;
        }
        public override string Delete(Rows rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"delete from rows " +
                    $"where rowId=@rowId";
                con.Execute(sql, new
                {
                    rowId = rec.RowId
                });
            }
            return ret;
        }
    }
}
