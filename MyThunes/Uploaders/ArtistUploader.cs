using System;
using System.IO;
using System.Web;

namespace MyThunes.Uploaders
{
    public class ArtistUploader
    {
        public static String SaveImage(HttpPostedFile file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/Images/Artitst"), fileName);
                    file.SaveAs(path);
                    return (path + fileName);
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}