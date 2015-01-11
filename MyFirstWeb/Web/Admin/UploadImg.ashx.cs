using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NET.CLY.Admin
{
    /// <summary>
    /// UploadImg 的摘要说明
    /// </summary>
    public class UploadImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile imgFile = context.Request.Files["img"];
            string ext = Path.GetExtension(imgFile.FileName);
            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                string clientPath = "/UploadFiles/" + Guid.NewGuid().ToString() + ext;
                string path = context.Request.MapPath(clientPath);
                imgFile.SaveAs(path);
                context.Response.Write(clientPath);
            }
            else
            {
                context.Response.Write("extError");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}