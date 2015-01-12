using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// UpdateCaseInfo 的摘要说明
    /// </summary>
    public class UpdateCaseInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string caseId = context.Request["caseId"];
            string caseLevel = context.Request["caseLevel"];
            string caseSource = context.Request["caseSource"];
            string caseDescribe = context.Request["caseDescribe"];
            string JieJingRenName = context.Request["JieJingRenName"];
            string JieJingRenPoliceId = context.Request["JieJingRenPoliceId"];
            string BaoJingRenName = context.Request["BaoJingRenName"];
            string BaoJingRenSex = context.Request["BaoJingRenSex"];
            string BaojingRenPeopleId = context.Request["BaojingRenPeopleId"];
            string BaoJingRenAddress = context.Request["BaoJingRenAddress"];
            string BaoJingPhone = context.Request["BaoJingPhone"];
            string BaoJingRenContactWay = context.Request["BaoJingRenContactWay"];

            BLL.CaseInfoBLL caseInfoBll = new CaseInfoBLL();
            BLL.BaoJingRenBLL baoJingRenBll = new BaoJingRenBLL();
            BLL.JieJingRenBLL jieJingRenBll = new JieJingRenBLL();


            Model.CaseInfo modelCaseInfo = new CaseInfo();
            modelCaseInfo.CaseId = caseId;
            modelCaseInfo.CaseLevel = caseLevel;
            modelCaseInfo.CaseSource = caseSource;
            modelCaseInfo.CaseDescribe = caseDescribe;

            Model.JieJingRen modelJieJingRen = new JieJingRen();
            modelJieJingRen.CaseId = caseId;
            modelJieJingRen.Name = JieJingRenName;
            modelJieJingRen.PoliceId = JieJingRenPoliceId;

            Model.BaoJingRen modelBaoJingRen = new BaoJingRen();
            modelBaoJingRen.Name = BaoJingRenName;
            modelBaoJingRen.Sex = BaoJingRenSex;
            modelBaoJingRen.CaseId = caseId;
            modelBaoJingRen.PeopleId = BaojingRenPeopleId;
            modelBaoJingRen.BaoJingPhone = BaoJingPhone;
            modelBaoJingRen.ContactWay = BaoJingRenContactWay;
            modelBaoJingRen.Address = BaoJingRenAddress;

            if (caseInfoBll.Update(modelCaseInfo)==1)
            {
                context.Response.Write("CaseOk");
            }
            else
            {
                context.Response.Write("CaseFail");
            }

            if (baoJingRenBll.Update(modelBaoJingRen)==1)
            {
                context.Response.Write("BaoJingRenOk");
            }
            else
            {
                context.Response.Write("BaoJingRenFail");
            }

            if (jieJingRenBll.Update(modelJieJingRen)==1)
            {
                context.Response.Write("JieJingRenOk");
            }
            else
            {
                context.Response.Write("JieJingRenFail");
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