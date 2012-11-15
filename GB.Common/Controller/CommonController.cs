using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Controllers;

namespace GB.Common.Controller
{
    
    public class CommonController
    {

        public IGBEntityController GbEntityCtr;

        public BadgeController BadgeCtr
        {
            get { return new BadgeController(); }
        }
        public ContentItemController ContentItemCtr
        {
            get { return new ContentItemController(); }
        }

        public ScheduleItemSettingController ScheduleItemSettingCtr
        {
            get { return new ScheduleItemSettingController(); }
        }

        public SettingController SettingCtr
        {
            get { return new SettingController(); }
        }

        public TermController TermCtr
        {
            get { return new TermController(); }
        }

        public TermHistoryController TermHistoryCtr
        {
            get { return new TermHistoryController(); }
        }

        public TermSynonymController TermSynonymCtr
        {
            get { return new TermSynonymController(); }
        }

        public UserScoreController UserScoreCtr
        {
            get { return new UserScoreController(); }
        }

        public UserScoreLogController UserScoreLogCtr
        {
            get { return new UserScoreLogController(); }
        }

        public VoteController VoteCtr
        {
            get { return new VoteController(); }
        }
    }
}