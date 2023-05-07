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
    public class OrdersController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        [HttpGet]
        public IEnumerable<Orders> GetOrders(string Id, string UserId)
        {

            List<Orders> objResult = new List<Orders>();
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
                string str = " exec sa.GetOrderDetails @Id= " + Id + ",@UserId = " + UserId;

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Orders row = new Orders();

                        row.Id = clsMain.MyInt(item["Id"]);
                        row.ProductName = clsMain.MyString(item["ProductName"]);
                        row.OrderId = clsMain.MyString(item["OrderId"]);
                        row.Price = clsMain.MyInt(item["Price"]);
                        row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
                        row.Address = clsMain.MyString(item["Address"]);
                        row.UserId = clsMain.MyInt(item["UserId"]);
                        row.Seller = clsMain.MyString(item["Seller"]);
                        objResult.Add(row);
                    }

                }

            }
            catch (Exception )
            {

                //if (ex.Message.ToString().Contains("Conversion failed when converting the varchar value "));
                //return.objResult;
            }

            return objResult;
        }

        [HttpPost]
        public Orders Order(List<Orders> myOrders)
        {
            Orders result = new Orders();
            try
            {
                foreach (Orders order in myOrders)
                {
                    SqlParameter[] sqlParam = new SqlParameter[7];
                    sqlParam[0] = new SqlParameter("@ProductName", order.ProductName);
                    sqlParam[1] = new SqlParameter("@OrderId", order.OrderId);
                    sqlParam[2] = new SqlParameter("@Price", order.Price);
                    sqlParam[3] = new SqlParameter("@ImageUrl", order.ImageUrl);
                    sqlParam[4] = new SqlParameter("@Address", order.Address);
                    sqlParam[5] = new SqlParameter("@UserId", order.UserId);
                    sqlParam[6] = new SqlParameter("@Seller", order.Seller);
        
                    
                    //yaha data table mein get table mein "PostOrderDetails" Procedure ka naam atta hai
                    DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("dbo.PostOrderDetails", sqlParam);
                    
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


