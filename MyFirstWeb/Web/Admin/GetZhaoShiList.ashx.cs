using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// GetZhaoShiList 的摘要说明
    /// </summary>
    public class GetZhaoShiList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.ZhaoShiZheBLL personBll = new ZhaoShiZheBLL();
            BLL.ZhaoShiCheBLL carBll = new ZhaoShiCheBLL();
            List<Model.ZhaoShiZhe> personList = personBll.GetAll() as List<Model.ZhaoShiZhe>;
            List<Model.ZhaoShiChe> carList = carBll.GetAll() as List<Model.ZhaoShiChe>;
            var list = new { PersonList = personList, CarList = carList };
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string JsonObj = javaScriptSerializer.Serialize(list);
            context.Response.Write(JsonObj);
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