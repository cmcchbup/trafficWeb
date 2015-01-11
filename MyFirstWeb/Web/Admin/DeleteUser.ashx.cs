using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string password = context.Request["password"] == null ? string.Empty : context.Request["password"];
            string currentUserName = context.Request["UserName"] == null ? string.Empty : context.Request["UserName"];//从cookie中取出用户名

            BLL.LoginBLL bll = new LoginBLL();
            Model.Login model = bll.GetByUserName(currentUserName);
            password = CLYLibrary.GetMD5.GetMd5Str(password);
            if (password!=model.Password.Trim())
            {//密码错误
                context.Response.Write("passwordError");
                context.Response.End();
            }
            int result = bll.DeleteById(model.Id);
            if (result==1)
            {
                //删除成功
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