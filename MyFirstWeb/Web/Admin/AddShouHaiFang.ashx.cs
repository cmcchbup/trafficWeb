using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET.CLY.BLL;
using NET.CLY.Model;

namespace NET.CLY.Admin
{
    /// <summary>
    /// AddShouHaiFang 的摘要说明
    /// </summary>
    public class AddShouHaiFang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = context.Request["name"] == null ? string.Empty : context.Request["name"];
            string sex = context.Request["sex"] == null ? string.Empty : context.Request["sex"];
            string nation = context.Request["nation"] == null ? string.Empty : context.Request["nation"];
            string jiGuan = context.Request["jiGuan"] == null ? string.Empty : context.Request["jiGuan"];

            DateTime birthDay = DateTime.ParseExact(context.Request["birthDay"].ToString(), "yyyy-MM-dd", null);
            string peopleId = context.Request["peopleId"] == null ? string.Empty : context.Request["peopleId"];
            DateTime chuLingRiQi = DateTime.ParseExact(context.Request["chuLingRiQi"].ToString(), "yyyy-MM-dd", null);
            string zhunJiaCheXing = context.Request["zhunJiaCheXing"] == null ? string.Empty : context.Request["zhunJiaCheXing"];
            string jiaShiZhengHao = context.Request["jiaShiZhengHao"] == null ? string.Empty : context.Request["jiaShiZhengHao"];
            string contactWay = context.Request["contactWay"] == null ? string.Empty : context.Request["contactWay"];
            string address = context.Request["address"] == null ? string.Empty : context.Request["address"];
            string imagePoeple = context.Request["imagePoeple"] == null ? string.Empty : context.Request["imagePoeple"];
            string carType = context.Request["carType"] == null ? string.Empty : context.Request["carType"];
            string carId = context.Request["carId"] == null ? string.Empty : context.Request["carId"];
            string carColor = context.Request["carColor"] == null ? string.Empty : context.Request["carColor"];
            string carOwnerName = context.Request["carOwnerName"] == null ? string.Empty : context.Request["carOwnerName"];
            string carBrand = context.Request["carBrand"] == null ? string.Empty : context.Request["carBrand"];
            string carOwnerPeopleId = context.Request["carOwnerPeopleId"] == null ? string.Empty : context.Request["carOwnerPeopleId"];
            string imageCar = context.Request["imageCar"] == null ? string.Empty : context.Request["imageCar"];

            BLL.ShouHaiZheBLL bllPeople = new ShouHaiZheBLL();
            BLL.ShouHaiCheBLL bllCar = new ShouHaiCheBLL();
            Model.ShouHaiZhe modelPeople = new ShouHaiZhe();
            Model.ShouHaiChe modelCar = new ShouHaiChe();

            modelPeople.Name = name;
            modelPeople.Sex = sex;
            modelPeople.Nation = nation;
            modelPeople.JiGuan = jiGuan;
            modelPeople.BirthDay = birthDay;
            modelPeople.PeopleId = peopleId;
            modelPeople.ChuLingRiQi = chuLingRiQi;
            modelPeople.ZhunJiaCheXing = zhunJiaCheXing;
            modelPeople.JiaShiZhengHao = jiaShiZhengHao;
            modelPeople.ContactWay = contactWay;
            modelPeople.Address = address;
            modelPeople.Photo = imagePoeple;

            modelCar.CarType = carType;
            modelCar.CarId = carId;
            modelCar.CarColor = carColor;
            modelCar.CarOwnerName = carOwnerName;
            modelCar.CarBrand = carBrand;
            modelCar.CarOwnerPeopleId = carOwnerPeopleId;
            modelCar.CarPhoto = imageCar;


            if (bllPeople.Add(modelPeople) != null)
            {
                context.Response.Write("ok");
            }
            if (bllCar.Add(modelCar) != null)
            {
                context.Response.Write("ok");
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