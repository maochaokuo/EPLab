using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EPLab.dbService
{
    public class DapperSelect<T> : IDisposable
    {
        //public string sql { get; set; }
        //public DynamicParameters whereParas { get; set; }
        //public DynamicParameters setParas { get; set; }

        protected string connS = "";
        protected SqlConnection conn = null;
        private bool disposedValue;

        public DapperSelect(string connS)
        {
            //whereParas = new DynamicParameters();
            //setParas = new DynamicParameters();
            this.connS = connS;
        }
        protected IDbConnection GetConn()
        {
            if (conn == null || conn.State != ConnectionState.Open)
            {
                conn = new SqlConnection(connS);
                conn.Open();
            }
            return conn;
        }
        public List<T> Select(string sql
            , DynamicParameters whereParas = null)
        {
            List<T> ret = null;
            using (var con=GetConn())
            {
                var qry = con.Query<T>(sql, whereParas);
                if (qry.Any())
                    ret = qry.ToList();
            }
            return ret;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TO DO: dispose managed state (managed objects)
                }

                // TO DO: free unmanaged resources (unmanaged objects) and override finalizer
                // TO DO: set large fields to null
                disposedValue = true;
            }
        }

        // // TO DO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DapperLib()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
