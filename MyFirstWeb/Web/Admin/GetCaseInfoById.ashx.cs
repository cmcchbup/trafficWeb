using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// GetCaseInfoById 的摘要说明
    /// </summary>
    public class GetCaseInfoById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string caseId = context.Request["caseId"] == null ? string.Empty : context.Request["caseId"];

            BLL.CaseInfoBLL caseInfoBll = new CaseInfoBLL();
            BLL.BaoJingRenBLL baoJingRenBll = new BaoJingRenBLL();
            BLL.JieJingRenBLL jieJingRenBll = new JieJingRenBLL();
            Model.CaseInfo caseInfo = caseInfoBll.GetByCaseId(caseId);
            Model.BaoJingRen baoJingRen = baoJingRenBll.GetByCaseId(caseId);
            Model.JieJingRen jieJingRen = jieJingRenBll.GetByCaseId(caseId);

            var model = new {CaseInfo = caseInfo, BaoJingRen = baoJingRen, JieJingRen = jieJingRen};
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string JsonObj = javaScriptSerializer.Serialize(model);
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