using System;
using System.Collections.Generic;
using System.IO;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;

namespace FileUpload.Controllers  
{  


public class UploadController : Controller
{
    // GET: Upload  
    public ActionResult Index()
    {
        return View();
    }
    [HttpGet]

    public ActionResult UploadFile()
    {
        return View();
    }
    [HttpPost]

    public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> file, FormCollection data)
    {
        foreach (var f in file)
        {
            try
            {
                if (f.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(f.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    f.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";  
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
        }
        return View();
    }
}  
}  