using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// AddCase 的摘要说明
    /// </summary>
    public class AddCase : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //            caseId: caseId,
            //            caseLevel: caseLevel,
            //            caseSource: caseSource,
            //            caseDescribe: caseDescribe,
            //            JieJingRenName: JieJingRenName,
            //            JieJingRenPoliceId: JieJingRenPoliceId,
            //            BaoJingRenName: BaoJingRenName,
            //            BaoJingRenSex: BaoJingRenSex,
            //            BaojingRenPeopleId: BaojingRenPeopleId,
            //            BaoJingRenAddress: BaoJingRenAddress,
            //            BaoJingPhone: BaoJingPhone,
            //            BaoJingRenContactWay: BaoJingRenContactWay
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
            BLL.JieJingRenBLL jieJingRenBll = new JieJingRenBLL();
            BLL.BaoJingRenBLL baoJingRenBll = new BaoJingRenBLL();

            Model.CaseInfo modelExit= caseInfoBll.GetByCaseId(caseId);
            if (modelExit!=null)
            {
                //存在该案件编号，请重新输入
                context.Response.Write("Exit");
                context.Response.End();
            }

            Model.CaseInfo modelCaseInfo = new CaseInfo();
            modelCaseInfo.CaseId = caseId;
            modelCaseInfo.CaseLevel = caseLevel;
            modelCaseInfo.CaseSource = caseSource;
            modelCaseInfo.CaseDescribe = caseDescribe;

            Model.CaseInfo modelCaseInfoAdded= caseInfoBll.Add(modelCaseInfo);
            if (modelCaseInfoAdded!=null)
            {
                //案件详情添加成功 
                context.Response.Write("CaseOk");
            }
            else
            {
                context.Response.Write("CaseFail");
            }


            Model.JieJingRen modelJieJingRen = new JieJingRen();
            modelJieJingRen.CaseId = caseId;
            modelJieJingRen.Name = JieJingRenName;
            modelJieJingRen.PoliceId = JieJingRenPoliceId;
            Model.JieJingRen modelJieJingRenAdded= jieJingRenBll.Add(modelJieJingRen);
            if (modelJieJingRenAdded!=null)
            {
                //接警人信息添加成功 
                context.Response.Write("JieJingRenOk");
            }
            else
            {
                context.Response.Write("JieJingRenFail");
            }

            Model.BaoJingRen modelBaoJingRen = new BaoJingRen();
            modelBaoJingRen.Name = BaoJingRenName;
            modelBaoJingRen.Sex = BaoJingRenSex;
            modelBaoJingRen.CaseId = caseId;
            modelBaoJingRen.PeopleId = BaojingRenPeopleId;
            modelBaoJingRen.BaoJingPhone = BaoJingPhone;
            modelBaoJingRen.ContactWay = BaoJingRenContactWay;
            modelBaoJingRen.Address = BaoJingRenAddress;
            Model.BaoJingRen modelBaoJingRenAdded = baoJingRenBll.Add(modelBaoJingRen);
            if (modelBaoJingRenAdded!=null)
            {
                //报警人添加成功 
                context.Response.Write("BaoJingRenOk");
            }
            else
            {
                context.Response.Write("BaoJingRenFail");
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