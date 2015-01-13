using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// GetShouHaiCheById 的摘要说明
    /// </summary>
    public class GetShouHaiCheById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //int personId = context.Request["PersonId"] == null ? 0 : int.Parse(context.Request["PersonId"]);
            string carId = context.Request["CarId"] == null ? string.Empty : context.Request["CarId"];

            // BLL.ShouHaiZheBLL personBll = new ShouHaiZheBLL();
            BLL.ShouHaiCheBLL carBll = new ShouHaiCheBLL();
            // Model.ShouHaiZhe personModel = personBll.GetById(personId);
            Model.ShouHaiChe carModel = carBll.GetByCarId(carId);
            var list = new { Car = carModel };
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
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