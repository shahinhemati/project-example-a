using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;
using AlbumCommon = GB.Album.CommonBase.Constants;

namespace GB.Album.Components.Controller
{
    public class FileAlbumController
    {

        #region Properties

        #endregion

        /// <summary>
        /// Store Images in album
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="portalID"></param>
        public void StoreImagesInAlbum(Stream stream, string filename, int portalID, int width)
        {
            //ensure all folders exist in this portal
            EnsureFolderExist(portalID);

            // Store File to Album
            IFolderInfo folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImage);
            FileManager.Instance.AddFile(folder, filename, stream);

            //Store File to AlbumThum
            Stream streamThum = ConvertToThumImage(stream, width);
            folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImageThum);
            FileManager.Instance.AddFile(folder, filename, streamThum);
            
        }

        /// <summary>
        /// store image presentation of album
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="portalID"></param>
        public void StoreImageOfAlbum(Stream stream, string filename, int portalID, int width)
        {

            //ensure all folders exist in this portal
            EnsureFolderExist(portalID);

            // Store File to Album
            IFolderInfo folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImage);
            FileManager.Instance.AddFile(folder, filename, stream);

            //Store File to AlbumThum
            Stream streamThum = ConvertToThumImage(stream, width);
            folder = FolderManager.Instance.GetFolder(portalID, AlbumCommon.FolderImageThum);
            FileManager.Instance.AddFile(folder, filename, streamThum);


        }

        #region Process Image to ThumbnailImage

        private Stream ConvertToThumImage(Stream stream, int width)
        {
            Image image = Image.FromStream(stream);
            int height = image.Size.IsEmpty ? 0 : width * (image.Height / image.Width);
            image = image.GetThumbnailImage(width, height, ThumbnailCallback, IntPtr.Zero);
            image.Save(stream, ImageFormat.Png);

            return stream;
        }

        private static bool ThumbnailCallback() { return false; }

        #endregion


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