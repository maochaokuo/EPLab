﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        public List<T> GetAll()
        {
            List<T> ret = null; 
            return ret;
        }
        public T GetOne()
        {
            T ret = default(T);
            return ret;
        }
        public string Insert(T obj)
        {
            string ret = "";
            return ret;
        }
        public string Update(T obj)
        {
            string ret = "";
            return ret;
        }
        public string Delete(T obj)
        {
            string ret = "";

            return ret;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    conn.Close();
                    conn = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
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
