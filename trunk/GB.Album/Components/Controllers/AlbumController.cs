using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Album.Components.Entities;

namespace IB.Album.Components.Controllers
{
    
    public class AlbumController
    {
        #region Create new Instance
        public interface IFactory
        {
            AlbumController GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static AlbumController GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new AlbumController();
        }

        [ThreadStatic]
        static AlbumController _instance;
        #endregion

        #region CRUD Album
        public int AddAlbum(GB.Album.Components.Entities.Album album)
        {
            int rt=-1;
            SqlServerDB.SqlServerDb.GetInstance().Insert(album);

            
   
            return rt;
        }
        #endregion

    }
}