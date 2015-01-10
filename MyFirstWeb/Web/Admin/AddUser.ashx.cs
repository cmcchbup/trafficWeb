using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string UserName = context.Request["u"] == null ? string.Empty : context.Request["u"];
            string Password = context.Request["p"] == null ? string.Empty : context.Request["p"];
            string UserType = context.Request["t"] == null ? "police" : context.Request["t"];

            Password = CLYLibrary.GetMD5.GetMd5Str(Password);
            BLL.LoginBLL bll = new LoginBLL();

            int result = bll.Exit(UserName);
            if (result>0)
            {
                //用户已存在
                context.Response.Write("exit");
                context.Response.End();//直接结束，后面的代码不执行了
                
            }
            Model.Login model = new Model.Login();
            model.UserName = UserName;
            model.UserType = UserType;
            model.Password = Password;
            Model.Login addModel = bll.Add(model);
            if (addModel!=null)
            {//添加成功
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