using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;

namespace NET.CLY.Admin
{
    /// <summary>
    /// DeleteShouHaiZhe 的摘要说明
    /// </summary>
    public class DeleteShouHaiZhe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int personId = context.Request["PersonId"] == null ? 0 : int.Parse(context.Request["PersonId"]);
            //string carId = context.Request["CarId"] == null ? string.Empty : context.Request["CarId"];

            BLL.ShouHaiZheBLL personBll = new ShouHaiZheBLL();
            //BLL.ShouHaiCheBLL carBll = new ShouHaiCheBLL();
            int result1 = personBll.DeleteById(personId);
            //int result2 = carBll.DeleteByCarId(carId);

            if (result1 == 1)
            {
                //成功
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