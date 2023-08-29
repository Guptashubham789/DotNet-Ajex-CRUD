using Newtonsoft.Json;
using RegisterPage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterPage.Controllers
{
    public class HomeController : Controller
    {
        DBManager db = new DBManager();
        [HttpGet]
        public ActionResult Index()
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@action",1)
                };
            DataTable dt = db.Select("sp_mstatus", parameters);
            ViewBag.data1 = dt;

            SqlParameter[] parameters1 = new SqlParameter[]
                {
                    new SqlParameter("@action",2)
                };
            DataTable dt1 = db.Select("sp_mstatus", parameters1);
            ViewBag.data2 = dt1;

            SqlParameter[] parameters2 = new SqlParameter[]
                {
                    new SqlParameter("@action",2)
                };
            DataTable dt3= db.Select("sp_register", parameters2);
            return View(dt3);
        }
        [HttpPost]
        public ActionResult Index(RegisterModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@action",1),
                new SqlParameter("@first_name",data.fname),
                new SqlParameter("@middile_name",data.mname),
                new SqlParameter("@last_name",data.lname),
                new SqlParameter("@material_status",data.mstatus),
                new SqlParameter("@date_of_birth",data.dob),
                new SqlParameter("@email",data.email),
                new SqlParameter("@mobile_number",data.mnumber),
                new SqlParameter("@address",data.address),
                new SqlParameter("@country",data.country),
                new SqlParameter("@state",data.state),
                new SqlParameter("@city",data.city),
                new SqlParameter("@zip_code",data.zipcode)
            };
            int res = db.Insert("sp_register", parameters);
            return RedirectToAction("index");
        }

        public JsonResult deleterecord(int id)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id",id),
                new SqlParameter("@action",3)
                };
                int res = db.Insert("sp_register", parameters);
                return Json("Record deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error occured", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ViewRecord()
        {
            return View();
        }
        public ActionResult EditRecord(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@action",1)
               };
            DataTable dt = db.Select("sp_mstatus", parameters);
            ViewBag.data1 = dt;
            SqlParameter[] parameters1 = new SqlParameter[]
                {
                    new SqlParameter("@action",2)
                };
            DataTable dt1 = db.Select("sp_mstatus", parameters1);
            ViewBag.data2 = dt1;
            SqlParameter[] para1 = new SqlParameter[]
                {
                new SqlParameter("@id",id),
                new SqlParameter("@action",4)
                };
            DataTable dt3 = db.Select("sp_register", para1);
            return View(dt3);

        }

        [HttpPost]
        public ActionResult EditRecord(RegisterModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@action",5),
                new SqlParameter("@id",data.id),
                new SqlParameter("@first_name",data.fname),
                new SqlParameter("@middile_name",data.mname),
                new SqlParameter("@last_name",data.lname),
                new SqlParameter("@material_status",data.mstatus),
                new SqlParameter("@date_of_birth",data.dob),
                new SqlParameter("@email",data.email),
                new SqlParameter("@mobile_number",data.mnumber),
                new SqlParameter("@address",data.address),
                new SqlParameter("@country",data.country),
                new SqlParameter("@state",data.state),
                new SqlParameter("@city",data.city),
                new SqlParameter("@zip_code",data.zipcode)
           };
            int res = db.Insert("sp_register", parameters);
            return RedirectToAction("index");
        }
        public ActionResult StateBind(int ? id)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@action",3),
                    new SqlParameter("@country_id",id)
                };
            DataTable dt = db.Select("sp_mstatus", parameters);
            ViewBag.data1 = dt;
            var data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CityBind(int? id)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@action",4),
                    new SqlParameter("@state_id",id)
                };
            DataTable dt = db.Select("sp_mstatus", parameters);
            ViewBag.data1 = dt;
            var data = JsonConvert.SerializeObject(dt);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}