using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EPLab.dbService
{
    public class Repository<T> : IDisposable
    {
        protected string connS = "";
        protected SqlConnection conn = null;
        private bool disposedValue;

        public Repository(string connS)
        {
            this.connS = connS;
        }
        protected IDbConnection GetConn()
        {
            if (conn==null || conn.State!=ConnectionState.Open)
            {
                conn = new SqlConnection(connS);
                conn.Open();
            }
            return conn;
        }
        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual T GetOne(Guid gid)
        {
            throw new NotImplementedException();
        }
        public virtual string Insert(T obj)
        {
            throw new NotImplementedException();
        }
        public virtual string Update(T obj)
        {
            throw new NotImplementedException();
        }
        public virtual string Delete(T obj)
        {
            throw new NotImplementedException();
        }
        public virtual string DeleteByTag(string tag)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TO DO: dispose managed state (managed objects)
                    conn.Close();
                    conn = null;
                }

                // TO DO: free unmanaged resources (unmanaged objects) and override finalizer
                // TO DO: set large fields to null
                disposedValue = true;
            }
        }

        // // TO DO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Repository()
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
