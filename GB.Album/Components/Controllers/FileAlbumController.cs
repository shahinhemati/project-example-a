using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;
using GB.Album.Components.Common;

namespace GB.Album.Components.Controller
{
    public class FileAlbumController
    {
        /// <summary>
        /// Store Images in album
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="portalID"></param>
        public void StoreImagesInAlbum(Stream stream, string filename, int portalID)
        {
            //ensure all folders exist in this portal
            EnsureFolderExist(portalID);

            // Store File to Album
            IFolderInfo folder = FolderManager.Instance.GetFolder(portalID,AlbumCommon.FolderImage);
            FileManager.Instance.AddFile(folder, filename, stream);

            //Store File to AlbumThum
            Stream streamThum =ConvertToThumImage(stream);
            folder = FolderManager.Instance.GetFolder(portalID,AlbumCommon.FolderImageThum);
            FileManager.Instance.AddFile(folder, filename, streamThum);

        }

        /// <summary>
        /// store image presentation of album
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="portalID"></param>
        public void StoreImageOfAlbum(Stream stream, string filename, int portalID)
        {

            //ensure all folders exist in this portal
            EnsureFolderExist(portalID);

            // Store File to Album
            IFolderInfo folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImage);
            FileManager.Instance.AddFile(folder, filename, stream);

            //Store File to AlbumThum
            Stream streamThum = ConvertToThumImage(stream);
            folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImageThum);
            FileManager.Instance.AddFile(folder, filename, streamThum);
        }

        private Stream ConvertToThumImage(Stream stream)
        {
            //get size thumb
            int widht;
            //ImageUtils.GetSize()
            
            Image image = Image.FromStream(stream);
            image=image.GetThumbnailImage(0,0,ThumbnailCallback,IntPtr.Zero);
            return image.;
        }

        private static bool ThumbnailCallback() { return false; }

        private void EnsureFolderExist(int portalid)
        {
            if (DataCache.GetCache(AlbumCommon.ModuleCacheKey + portalid.ToString()) == null)
            {

                //Create Folder Thumb and folder album
                if (!FolderManager.Instance.FolderExists(portalid, AlbumCommon.FolderAlbum))
                {
                    FolderManager.Instance.AddFolder(portalid, AlbumCommon.FolderAlbum);
                }
                if (!FolderManager.Instance.FolderExists(portalid, AlbumCommon.FolderAlbumThum))
                {
                    FolderManager.Instance.AddFolder(portalid, AlbumCommon.FolderAlbumThum);
                }

                if (!FolderManager.Instance.FolderExists(portalid, AlbumCommon.FolderImage))
                {
                    FolderManager.Instance.AddFolder(portalid, AlbumCommon.FolderImage);
                }
                if (!FolderManager.Instance.FolderExists(portalid, AlbumCommon.FolderImageThum))
                {
                    FolderManager.Instance.AddFolder(portalid, AlbumCommon.FolderImageThum);
                }

                DataCache.SetCache(AlbumCommon.ModuleCacheKey + portalid.ToString(), "Exist");
            }
        }

    }
}