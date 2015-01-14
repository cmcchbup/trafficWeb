using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        public string UserNameInCookie { get; set; }
        public string ShowMsg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {    //如果是第一次请求，那么就把存储在cookie中的用户名放到用户名文本框中
                UserNameInCookie = Request.Cookies["UserName"] == null
                    ? string.Empty
                    : Request.Cookies["UserName"].Value;
            }
            else
            {  //回调，意味着这次是用户点击登陆按钮,


                string UserName = Request["UserName"] == null ? string.Empty : Request["UserName"];
                string Password = Request["Password"] == null ? string.Empty : Request["Password"];
                Response.Cookies["UserName"].Value = UserName;//将用户名写入到cookie中


                string ValidateCode = Request["ValidateCode"] == null ? string.Empty : Request["ValidateCode"];

                string ValidateCodeInSession = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"].ToString();
                Session["ValidateCode"] = null;//用一次就将Session中的验证码消除，防止被人暴力破解

                if (ValidateCodeInSession != ValidateCode || ValidateCodeInSession == string.Empty)
                {//意味着验证码校验失败
                    ShowMsg = "<script>alert('验证码错误');</script>";
                }
                else
                {//验证码校验zhengq，接下来校验用户名与密码
                    BLL.LoginBLL bll = new LoginBLL();
                    Password = CLYLibrary.GetMD5.GetMd5Str(Password);
                    Model.Login model = bll.login(UserName, Password);
                    if (model != null)
                    {//存在用户
                        //跳转到后台页面，并将用户存储在Session中
                        Session["LoginUser"] = model;
                        Response.Redirect("/admin/Main.aspx");

                    }
                    else
                    {//不存在用户
                        ShowMsg = "<script>alert('用户名或密码输入错误!');</script>";
                    }
                }

            }



        }
    }
}