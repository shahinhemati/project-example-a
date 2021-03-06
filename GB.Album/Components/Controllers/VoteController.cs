﻿using System;
using System.Collections.Generic;
using GB.Album.Entities;

namespace GB.Album.Controller
{
    public class VoteController
    {
        #region Variables
        public static string PrefixCache { set; get; }
        #endregion

        #region Create new Instance
        public interface IFactory
        {
            VoteController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static VoteController GetInstance(string prefixCache)
        {

            PrefixCache = prefixCache;
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new VoteController();
        }

        [ThreadStatic]
        static VoteController _instance;
        #endregion

        public List<SettingInfo> GetQaPortalSettings(int portalId)
        {
            throw new NotImplementedException();
        }

        public UserScoreInfo GetUserScore(int userId, int portalId)
        {
            throw new NotImplementedException();
        }

        public List<TermSynonymInfo> GetTermSynonyms(int p)
        {
            throw new NotImplementedException();
        }

        public void GetPost(int currentPostId, int portalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoteInfo> GetPostVotes(int CurrentPostID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoteInfo> GetTermSynonymVotes(int relatedTermId, int portalId)
        {
            throw new NotImplementedException();
        }

        public int AddVote(VoteInfo objVote, int p)
        {
            throw new NotImplementedException();
        }
    }
}