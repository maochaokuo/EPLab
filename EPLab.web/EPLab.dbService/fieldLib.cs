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

        public override Fields GetOne(Guid gid)
        {
            using (var con = GetConn())
            {
                string sql = $"select * from fields " +
                    $"where fieldId=@fieldId";
                var qry = conn.Query<Fields>(sql, 
                    new { fieldId = gid }).FirstOrDefault();
                return qry;
            }
        }

        public override string Insert(Fields rec)
        {
            string ret = "";
            using (var con = GetConn())
            {
                string sql = $"insert into fields " +
                    $"(tableName,tableDesc) " +
                    $"vales (@tableName,@tableDesc)";
                con.Execute(sql,
                    new
                    {
                        TableId = rec.TableId,
                        FieldName = rec.FieldName,
                        FieldDesc = rec.FieldDesc,
                        PrimaryOrder = rec.PrimaryOrder,
                        ForeignFieldId = rec.ForeignFieldId,
                        //ForeignFieldId = rec.def
                    });
            }
            return ret;
        }

        public override string Update(Fields rec)
        {
            return base.Update(rec);
        }
        public override string Delete(Fields rec)
        {
            return base.Delete(rec);
        }

    }
}
