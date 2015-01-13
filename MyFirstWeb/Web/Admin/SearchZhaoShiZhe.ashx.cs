using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// SearchZhaoShiZhe 的摘要说明
    /// </summary>
    public class SearchZhaoShiZhe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["Name"] == null ? "" : context.Request["Name"];
            string peopleId = context.Request["PeopleId"] == null ? "" : context.Request["PeopleId"];

            BLL.ZhaoShiZheBLL bll = new ZhaoShiZheBLL();
            if (name == "" && peopleId == "")
            {
                List<Model.ZhaoShiZhe> model = bll.GetAll() as List<Model.ZhaoShiZhe>;
                var list = new { PersonList = model };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            if (peopleId != "")
            {
                List<Model.ZhaoShiZhe> model = bll.GetByPeopleId(peopleId) as List<Model.ZhaoShiZhe>;
                var list = new { PersonList = model };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            else if (name != "")
            {
                List<Model.ZhaoShiZhe> model = bll.GetByName(name) as List<Model.ZhaoShiZhe>;
                var list = new { PersonList = model };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
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