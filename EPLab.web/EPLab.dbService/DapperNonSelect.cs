using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EPLab.dbService
{
    public class DapperNonSelect : IDisposable
    {
        public string sql { get; set; }
        public DynamicParameters whereParas { get; set; }
        public DynamicParameters setParas { get; set; }
        public DynamicParameters allParas { get; set; }

        protected string connS = "";
        protected SqlConnection conn = null;
        protected IDbTransaction trans = null;          //交易用物件，慎用
        private bool disposedValue;

        public DapperNonSelect(string connS)
        {
            whereParas = new DynamicParameters();
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
        protected IDbTransaction BeginTransaction(bool updateInternal)
        {
            IDbTransaction transRet = conn.BeginTransaction();
            if (updateInternal)
                trans = transRet;
            return transRet;
        }
        protected void Commit()
        {
            if (trans != null)
            {
                Commit();
                trans = null;
            }
        }
        protected void Rollback()
        {
            if (trans != null)
            {
                Rollback();
                trans = null;
            }
        }
        public int NonSelectExec(IDbTransaction tran)
        {
            int rows = 0;
            using (var con=GetConn())
            {
                rows = con.Execute(sql, allParas, tran);
            }
            return rows;
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
        // ~DapperNonSelect()
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
