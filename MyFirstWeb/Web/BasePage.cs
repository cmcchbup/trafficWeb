using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET.CLY
{
    public class BasePage:System.Web.UI.Page   //这个类是用来校验当前是否存在登陆的用户的
    {
        public Model.Login CurrentLoginUser { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            CurrentLoginUser = Session["LoginUser"] as Model.Login;
            if (CurrentLoginUser==null)
            {   //如果不存在，就跳转到登陆界面
                Response.Redirect("/Admin/Login.aspx");
            }
        }
    }
}