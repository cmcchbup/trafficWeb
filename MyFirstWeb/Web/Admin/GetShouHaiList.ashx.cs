using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// GetShouHaiList 的摘要说明
    /// </summary>
    public class GetShouHaiList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.ShouHaiZheBLL personBll = new ShouHaiZheBLL();
            BLL.ShouHaiCheBLL carBll = new ShouHaiCheBLL();
            List<Model.ShouHaiZhe> personList = personBll.GetAll() as List<Model.ShouHaiZhe>;
            List<Model.ShouHaiChe> carList = carBll.GetAll() as List<Model.ShouHaiChe>;
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