using System;
using System.Web.UI.WebControls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using IB.Album.Components.Controllers;
using WebFormsMvp;


namespace GB.Album
{
    [PresenterBinding(typeof(ManagerAlbumPresenter))]
    public partial class ManagerAlbum : ModuleView<ManagerAlbumModel>,IManagerAlbumView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                dgDNNGrid.AutoGenerateColumns = true;
                dgDNNGrid.CellSpacing = 0;
                dgDNNGrid.GridLines = GridLines.Both;
                dgDNNGrid.FooterStyle.CssClass = "DataGrid_Footer";
                dgDNNGrid.HeaderStyle.CssClass = "DataGrid_Header";
                dgDNNGrid.ItemStyle.CssClass = "DataGrid_Item";
                dgDNNGrid.AlternatingItemStyle.CssClass = "DataGrid_AlternatingItem";

                dgDNNGrid.DataSource = (new AlbumController()).GetAlbums();
                dgDNNGrid.DataBind();
            }       
        }

        public void Refresh()
        {
            
        }

        public event EventHandler Delete;
    }
}