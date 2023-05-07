using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Banner.Models;
using ESCommon;

namespace Banner.Controllers
{
    public class ServiceOrdersController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        [HttpGet]
        public IEnumerable<ServiceOrders> GetOrders(string Id, string UserId)
        {

            List<ServiceOrders> objResult = new List<ServiceOrders>();
            try
            {
                if (clsMain.MyString(Id) == "0" || clsMain.MyString(Id) == null || clsMain.MyString(Id) == "" || clsMain.MyString(Id) == "undefined")
                {
                    Id = "0";
                }
                if (clsMain.MyString(UserId) == "0" || clsMain.MyString(UserId) == null || clsMain.MyString(UserId) == "" || clsMain.MyString(UserId) == "undefined")
                {
                    UserId = "0";
                }

                SQLHELPER obj = new SQLHELPER(ConnectionString);
                string str = " exec sa.GetServiceOrderDetails @Id= " + Id + ",@UserId = " + UserId;

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        ServiceOrders row = new ServiceOrders();

                        row.Id = clsMain.MyInt(item["Id"]);
                        row.ServiceName = clsMain.MyString(item["ServiceName"]);
                        row.ServiceOrderId = clsMain.MyString(item["ServiceOrderId"]);
                        row.ServicePrice = clsMain.MyInt(item["ServicePrice"]);
                        row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
                        row.Address = clsMain.MyString(item["Address"]);
                        row.UserId = clsMain.MyInt(item["UserId"]);
                        row.ServiceProvider = clsMain.MyString(item["ServiceProvider"]);
                        objResult.Add(row);
                    }

                }

            }
            catch (Exception)
            {

                //if (ex.Message.ToString().Contains("Conversion failed when converting the varchar value "));
                //return.objResult;
            }

            return objResult;
        }

        [HttpPost]
        public ServiceOrders Order(List<ServiceOrders> myOrders)
        {
            ServiceOrders result = new ServiceOrders();
            try
            {
                foreach (ServiceOrders order in myOrders)
                {
                    SqlParameter[] sqlParam = new SqlParameter[7];
                    sqlParam[0] = new SqlParameter("@ServiceName", order.ServiceName);
                    sqlParam[1] = new SqlParameter("@ServiceOrderId", order.ServiceOrderId);
                    sqlParam[2] = new SqlParameter("@ServicePrice", order.ServicePrice);
                    sqlParam[3] = new SqlParameter("@ImageUrl", order.ImageUrl);
                    sqlParam[4] = new SqlParameter("@Address", order.Address);
                    sqlParam[5] = new SqlParameter("@UserId", order.UserId);
                    sqlParam[6] = new SqlParameter("@ServiceProvider", order.ServiceProvider);
                    DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("dbo.PostServiceOrderDetails", sqlParam);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        result.Message = clsMain.MyString(dt.Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.ToString();
            }
            return result;
        }

    }
}
