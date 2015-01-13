using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// SearchCaseInfo 的摘要说明
    /// </summary>
    public class SearchCaseInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string caseId = context.Request["CaseId"] == null ? "" : context.Request["CaseId"];
            string caseLevel = context.Request["CaseLevel"];
            //string caseSource = context.Request["CaseLevel"];

            BLL.CaseInfoBLL bll = new CaseInfoBLL();
            if (caseId == "" && caseLevel == "不选")
            {
                List<Model.CaseInfo> list = bll.GetAll() as List<Model.CaseInfo>;
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            if (caseId != "")
            {
                Model.CaseInfo list = bll.GetByCaseId(caseId);
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
            }
            else
            {
                List<Model.CaseInfo> list = bll.GetByLevel(caseLevel) as List<Model.CaseInfo>;
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
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