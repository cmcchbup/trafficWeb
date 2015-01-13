using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// SearchShouHaiZhe 的摘要说明
    /// </summary>
    public class SearchShouHaiZhe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["Name"] == null ? "" : context.Request["Name"];
            string peopleId = context.Request["PeopleId"] == null ? "" : context.Request["PeopleId"];

            BLL.ShouHaiZheBLL bll = new ShouHaiZheBLL();
            if (name == "" && peopleId == "")
            {
                List<Model.ShouHaiZhe> model = bll.GetAll() as List<Model.ShouHaiZhe>;
                var list = new { PersonList = model };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            if (peopleId != "")
            {
                List<Model.ShouHaiZhe> model = bll.GetByPeopleId(peopleId) as List<Model.ShouHaiZhe>;
                var list = new { PersonList = model };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            else if (name != "")
            {
                List<Model.ShouHaiZhe> model = bll.GetByName(name) as List<Model.ShouHaiZhe>;
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