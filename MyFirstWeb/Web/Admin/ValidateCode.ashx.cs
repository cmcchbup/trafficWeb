using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CLYLibrary;

namespace NET.CLY.Admin
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            CLYLibrary.ValidateHelper validateHelper = new ValidateHelper();
            string ValidateCode=validateHelper.CreateValidateCode(4);
            context.Session["ValidateCode"] = ValidateCode;//将生成的验证码让到Session中
            validateHelper.CreateValidateGraphic(ValidateCode,context);
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