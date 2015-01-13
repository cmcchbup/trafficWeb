using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// SearchShouHaiChe 的摘要说明
    /// </summary>
    public class SearchShouHaiChe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string carId = context.Request["CarId"] == null ? "" : context.Request["CarId"];
            BLL.ShouHaiCheBLL bll = new ShouHaiCheBLL();

            if (carId == "")
            {
                List<Model.ShouHaiChe> models = bll.GetAll() as List<Model.ShouHaiChe>;
                var list = new { CarList = models };
                System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string JsonObj = javaScriptSerializer.Serialize(list);
                context.Response.Write(JsonObj);
                context.Response.End();
            }
            else
            {
                Model.ShouHaiChe model = bll.GetByCarId(carId);
                List<Model.ShouHaiChe> models = new List<ShouHaiChe>();
                models.Add(model);
                var list = new { CarList = models };
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