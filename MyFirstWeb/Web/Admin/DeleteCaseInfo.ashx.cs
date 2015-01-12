using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// DeleteCaseInfo 的摘要说明
    /// </summary>
    public class DeleteCaseInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string caseId = context.Request["CaseId"] == null ? string.Empty : context.Request["CaseId"];
            BLL.CaseInfoBLL bll = new CaseInfoBLL();
            int result = bll.DeleteByCaseId(caseId);
            if (result==1)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("fail");
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