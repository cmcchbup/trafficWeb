using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// GetCaseInfoList 的摘要说明
    /// </summary>
    public class GetCaseInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.CaseInfoBLL bll = new CaseInfoBLL();
            List<Model.CaseInfo> list = bll.GetAll() as List<Model.CaseInfo>;
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string JsonObj= javaScriptSerializer.Serialize(list);
            context.Response.Write(JsonObj);
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