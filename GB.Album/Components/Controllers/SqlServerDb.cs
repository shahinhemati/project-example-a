using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Content;
using GB.Album.Entities;
using PetaPoco;

namespace GB.Album.Controllers
{

    public partial class SqlServerDb : Database
    {
        public SqlServerDb()
            : base("sqlserver")
        {
            CommonConstruct();
        }

        public SqlServerDb(string connectionStringName)
            : base(connectionStringName)
        {
            CommonConstruct();
        }

        partial void CommonConstruct();

        public interface IFactory
        {
            SqlServerDb GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static SqlServerDb GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new SqlServerDb();
        }

        [ThreadStatic]
        static SqlServerDb _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }
    }
}