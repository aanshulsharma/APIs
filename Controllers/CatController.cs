using Banner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ESCommon;

namespace Banner.Controllers
{
    public class CatController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        // GET: api/Inventory

        [HttpGet]
        public IEnumerable<CatModel>GetDetails(string CategoryId, string PId)
        {

            List<CatModel> objResult = new List<CatModel>();

            try
            {
                if (clsMain.MyString(CategoryId) == "0" || clsMain.MyString(CategoryId) == null || clsMain.MyString(CategoryId) == "" || clsMain.MyString(CategoryId) == "undefined")
                {
                    CategoryId = "0";
                }
                if (clsMain.MyString(PId) == "0" || clsMain.MyString(PId) == null || clsMain.MyString(PId) == "" || clsMain.MyString(PId) == "undefined")
                {
                    PId = "0";
                }

                SQLHELPER obj = new SQLHELPER(ConnectionString);
                string str = " exec sa.GetCategoryDetails @CategoryId= " + CategoryId + ", @PId = " + PId;

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        CatModel row = new CatModel();

                        row.CategoryId = clsMain.MyInt(item["CategoryId"]);
                        row.CategoryName = clsMain.MyString(item["CategoryName"]);
                        row.Alias = clsMain.MyString(item["Alias"]);
                        row.Image_Url = clsMain.MyString(item["Image_Url"]);
                        row.PId = clsMain.MyInt(item["PId"]);
                        objResult.Add(row);
                    }

                }

            }
            catch (Exception)
            {
                //if (ex.Message.ToString().Contains("Conversion failed when converting the varchar value "));
                //return objResult;
            }

            return objResult;
        }
    }
}
