using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET.CLY
{
    public class BasePageMini:System.Web.UI.Page
    {
        public Model.Login CurrentLoginUser { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            CurrentLoginUser = Session["LoginUser"] as Model.Login;
            if (CurrentLoginUser == null)
            {   //如果不存在，就跳转到登陆界面
                Response.Redirect("/Admin/Login.aspx");
            }
            
        }
    }
}