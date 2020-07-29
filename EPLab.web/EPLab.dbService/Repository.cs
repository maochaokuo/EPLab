using System;
using System.Collections.Generic;
using System.Text;

namespace EPLab.dbService
{
    public class Repository<T>
    {
        protected string connS = "";

        public Repository(string connS)
        {
            this.connS = connS;
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
    }
}
