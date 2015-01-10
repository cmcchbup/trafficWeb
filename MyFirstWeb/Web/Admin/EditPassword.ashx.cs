using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// EditPassword 的摘要说明
    /// </summary>
    public class EditPassword : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string password1 = context.Request["p1"] == null ? string.Empty : context.Request["p1"];
            string password2 = context.Request["p2"] == null ? string.Empty : context.Request["p2"];
            Model.Login CurrentUser = context.Session["LoginUser"] as Model.Login;
            BLL.LoginBLL bll = new LoginBLL();
            Model.Login model = bll.GetById(CurrentUser.Id);
            password1 = CLYLibrary.GetMD5.GetMd5Str(password1);

            if (password1.Length <= 0 || password2.Length <= 0)
            {//迷之情况
                context.Response.Write("fail");
                context.Response.End();
            }

            if (password1 != model.Password)
            {
                //原密码输入错误
                context.Response.Write("PasswordError");
                context.Response.End();
            }

            //验证完毕，开始更新密码
            model.Password = CLYLibrary.GetMD5.GetMd5Str(password2);
            int result = bll.Update(model);
            if (result == 1)
            {
                //修改成功
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