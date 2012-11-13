﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Content.Taxonomy;
namespace GB.Common.Controllers
{
    public class TermController
    {
        #region Variables
        public static string PrefixCache { set; get; }
        #endregion

        #region Create new Instance
        public interface IFactory
        {
            TermController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static TermController GetInstance(string prefixCache)
        {

            PrefixCache = prefixCache;
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new TermController();
        }

        [ThreadStatic]
        static TermController _instance;
        #endregion


        #region Methods 
        
        

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="contentTypeId"></param>
        /// <param name="moduleId"></param>
        /// <param name="vocabularyId"></param>
        /// <returns></returns>
        public List<Term> GetTermsByContentType(int portalId, int contentTypeId, int moduleId, int vocabularyId)
        {
            //get Terms  
            
            throw new NotImplementedException();
        }

        internal List<Term> GetTermsByAlbumID(int albumId)
        {
            throw new NotImplementedException();
        }
    }
}