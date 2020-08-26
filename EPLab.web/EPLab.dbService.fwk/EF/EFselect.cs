using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLab.dbService
{
    public class EFselect : IDisposable
    {
        protected EPlabContext dbContext = null;//DbContext
        private bool disposedValue;

        public EFselect()
        {
            dbContext = new EPlabContext();
        }
        public EFselect(string connectionString)
        {
            dbContext = new EPlabContext();
            dbContext.Database.Connection.ConnectionString 
                = connectionString;
        }
        public EFselect(EPlabContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public EPlabContext getDbContext()
        {
            return dbContext;
        }
        public List<queryWhereRec> select<queryWhereRec>(string sql
            , params object[] param)//new SqlParameter("param1", param1),
        {
            List<queryWhereRec> ret = null;
            //DbContext dbc = dbContext;
            var qry = dbContext.Database.SqlQuery<queryWhereRec>(sql, param);
                //, new SqlParameter("param1", "para1value"));
            if (qry.Any())
                ret = qry.ToList();
            return ret;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EFselect()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
