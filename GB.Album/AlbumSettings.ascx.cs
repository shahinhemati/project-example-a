using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DotNetNuke.UI.Modules;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Common;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using GB.Common.Entities;
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
            if (this.GetSettings == null)
                return;

            // defer to presenter to set the model with any needed information
            GetSettings(this, null);

            // update the view based on our model
            //this.DescriptionTextBox.Text = this.Model.Description;
            //this.NameTextBox.Text = this.Model.Title;

            this.txtbxFromEmail.Text = Model.EmailAddress;
            this.txtbxQuestionEmailTemplate.Text = Model.EmailQuestionTemplate;
            this.txtAnswerEmailTemplate.Text = Model.EmailAnswerTemplate;
            this.txtbxCommentEmailTemplate.Text = Model.EmailCommentTemplate;
            this.txtbxSummaryEmailTemplate.Text = Model.EmailSummaryTemplate;

            this.dntxtbxMinTitleChars.Value = Convert.ToInt32(Model.CharacterTitleMin);
            

        }

        public void UpdateSettings()
        {
            // validate the page
            if (!Page.IsValid)
                return;

            // pull the values out of the form
            //this.Model.Description = this.DescriptionTextBox.Text;
            //this.Model.Title = this.NameTextBox.Text;
            


            // ensure the event is wired up before proceeding
            if (this.SaveSettings == null)
                return;

            // defer to the presenter to update the database based on our model
            SaveSettings(this, null);
        }
    }
}