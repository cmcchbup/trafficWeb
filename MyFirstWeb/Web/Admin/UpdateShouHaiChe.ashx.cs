using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// UpdateShouHaiChe 的摘要说明
    /// </summary>
    public class UpdateShouHaiChe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string carType = context.Request["carType"] == null ? string.Empty : context.Request["carType"];
            string carId = context.Request["carId"] == null ? string.Empty : context.Request["carId"];
            string carColor = context.Request["carColor"] == null ? string.Empty : context.Request["carColor"];
            string carOwnerName = context.Request["carOwnerName"] == null ? string.Empty : context.Request["carOwnerName"];
            string carBrand = context.Request["carBrand"] == null ? string.Empty : context.Request["carBrand"];
            string carOwnerPeopleId = context.Request["carOwnerPeopleId"] == null ? string.Empty : context.Request["carOwnerPeopleId"];
            string imageCar = context.Request["imageCar"] == null ? string.Empty : context.Request["imageCar"];


            //BLL.ShouHaiZheBLL bllPeople = new ShouHaiZheBLL();
            BLL.ShouHaiCheBLL bllCar = new ShouHaiCheBLL();

            //Model.ShouHaiZhe modelPeople = new ShouHaiZhe();
            Model.ShouHaiChe modelCar = new ShouHaiChe();
            modelCar.CarId = carId;
            modelCar.CarType = carType;
            modelCar.CarColor = carColor;
            modelCar.CarOwnerName = carOwnerName;
            modelCar.CarBrand = carBrand;
            modelCar.CarOwnerPeopleId = carOwnerPeopleId;
            modelCar.CarPhoto = imageCar;

            int result = bllCar.Update(modelCar);
            if (result == 1)
            {
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