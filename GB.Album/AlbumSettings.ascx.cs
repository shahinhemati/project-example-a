using System;
using DotNetNuke.UI.Modules;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(AlbumSettingsPresenter))]
    public partial class AlbumSettings : ModuleView<AlbumSettingsModel>, IAlbumSettingsView, ISettingsControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler GetSettings;
        public event EventHandler SaveSettings;
        public void LoadSettings()
        {
            // ensure the event is wired up before proceeding
            if (GetSettings == null)
                return;

            // defer to presenter to set the model with any needed information
            GetSettings(this, null);

            // update the view based on our model
            //this.DescriptionTextBox.Text = this.Model.Description;
            //this.NameTextBox.Text = this.Model.Title;

            //txtbxFromEmail.Text = Model.EmailAddress;
            //txtbxQuestionEmailTemplate.Text = Model.EmailQuestionTemplate;
            //txtAnswerEmailTemplate.Text = Model.EmailAnswerTemplate;
            //txtbxCommentEmailTemplate.Text = Model.EmailCommentTemplate;
            //txtbxSummaryEmailTemplate.Text = Model.EmailSummaryTemplate;

            //dntxtbxMinTitleChars.Value =Model.CharacterTitleMin;
            //dntxtbxMinBodyChars.Value = Model.BodyCharsMin;
            //dntxtbxMaxTags.Value = Model.MaxTags;

            //Create combobox Vocabroot
            //ddlVocabRoot.

            //this.chkAutoApprove.Checked=Model.
        }

        public void UpdateSettings()
        {
            // validate the page
            if (!Page.IsValid)
                return;

            // pull the values out of the form
            //this.Model.Description = this.DescriptionTextBox.Text;
            //this.Model.Title = this.NameTextBox.Text;
            //Model.EmailAddress=txtbxFromEmail.Text ;

            // ensure the event is wired up before proceeding
            if (SaveSettings == null)
                return;

            // defer to the presenter to update the database based on our model
            SaveSettings(this, null);
        }
    }
}