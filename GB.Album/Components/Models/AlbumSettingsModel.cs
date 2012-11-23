using DotNetNuke.Web.Mvp;

namespace GB.Album.Components.Models
{
    public class AlbumSettingsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        #region Email 
        public string EmailAddress { get; set; }
        public string EmailQuestionTemplate { get; set; }
        public string EmailAnswerTemplate { get; set; }
        public string EmailCommentTemplate { set; get; }
        public string EmailSummaryTemplate { set; get; }
        #endregion

        #region AskQuestionSetting

        public int CharacterTitleMin { set; get; }
        public int TagQuestionMin { set; get; }

        #endregion

        #region User InterFace

        public int HomeQuestionCount { set; get; }
        public int HomeTermCount { set; get; }
        public int HomeRecentTagsTimeFrame { set; get; }
        public int BrowseQuestionCount { set; get; }
        public int QuestionAnswerCount { set; get; }
        public int TagsCount { set; get; }
        public string FacebookAppId { set; get; }
        public bool EnableGoogleSharing { set; get; }
        public bool EnableTwitterSharing { set; get; }
        public bool EnableLinkedInSharing { set; get; }

        #endregion

        #region Operation Thresholds

        public int CloseQuestionVotes { set; get; }
        public int CloseQuestionWindow { set; get; }
        public int FlagQuestionRemoval { set; get; }
        public int PostVoteChangeWindow { set; get; }
        public int PostFlagLimit { set; get; }
        public int CloseTermWindow { set; get; }
        public int TermFlagWindow { set; get; }
        public int TermFlagLimit { set; get; }
        public int SynonymApproveCount { set; get; }
        public int SynonymRejectCount { set; get; }
        public int SynonymMax { set; get; }
        public int DialyCloseVotesCount { set; get; }
        public int DialyPostFlagCount { set; get; }
        public int DialySpamVotes { set; get; }
        public int DialyAnswerUpVote { set; get; }
        public int DialyQuestionUpVote { set; get; }
        public int HomeQuestionScoreMinimum { set; get; }

        #endregion
    }
}