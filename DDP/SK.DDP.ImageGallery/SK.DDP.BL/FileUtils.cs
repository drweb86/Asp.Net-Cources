using System;
using System.IO;
using System.Reflection;

namespace SK.DDP.BL
{
    public static class FileUtils
    {
        private static readonly string _physicalPath;
        private static readonly string _physicalContentPath;
        private static readonly string _physicalImagesPath;

        static FileUtils()
        {
            _physicalPath = System.Web.HttpContext.Current.Server.MapPath("/");
            _physicalContentPath = Path.Combine(_physicalPath, "Content");
            _physicalImagesPath = Path.Combine(_physicalContentPath, "Images");
            
            if (!Directory.Exists(_physicalImagesPath))
                Directory.CreateDirectory(_physicalImagesPath);
        }

        internal static string GetUserAlbumsFolder(Guid userId)
        {
            return Path.Combine(_physicalImagesPath, userId.ToString());
        }

        internal static string GetUserImagesFolder(Guid userId, int albumUid)
        {
            return Path.Combine(GetUserAlbumsFolder(userId), albumUid.ToString());
        }

        internal static string GetImageFolder(Guid userId, int albumUid, int imageUid)
        {
            return Path.Combine(GetUserImagesFolder(userId, albumUid), imageUid.ToString());
        }

        internal static string GetImagePath(Guid userId, int albumUid, int imageUid, string fileName)
        {
            return Path.Combine(GetImageFolder(userId, albumUid, imageUid), fileName);
        }
    }
}