using Banner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ESCommon;
using System.Data;

namespace Banner.Controllers
{
    public class PostServiceInventoryController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();


        [HttpPost]
        public ServiceInventory Inventories(List<ServiceInventory> inventories)
        {
            ServiceInventory result = new ServiceInventory();
            try
            {
                foreach (ServiceInventory order in inventories)
                {
                    SqlParameter[] sqlParam = new SqlParameter[14];

                    sqlParam[0] = new SqlParameter("@ProductName", order.ProductName);
                    sqlParam[1] = new SqlParameter("@ServiceName", order.ServiceName);
                    sqlParam[2] = new SqlParameter("@ServiceCategory", order.ServiceCategory);
                    sqlParam[3] = new SqlParameter("@ServicePrice", order.ServicePrice);
                    sqlParam[4] = new SqlParameter("@ImageUrl", order.ImageUrl);
                    sqlParam[5] = new SqlParameter("@ServiceDescriptionLong", order.ServiceDescriptionLong);
                    sqlParam[6] = new SqlParameter("@ServiceDescriptionShort", order.ServiceDescriptionShort);
                    sqlParam[7] = new SqlParameter("@ServiceStatus", order.ServiceStatus);
                    sqlParam[8] = new SqlParameter("@DiscountPrice", order.DiscountPrice);
                    sqlParam[9] = new SqlParameter("@BrandName", order.BrandName);
                    sqlParam[10] = new SqlParameter("@CategoryId", order.CategoryId);
                    sqlParam[11] = new SqlParameter("@BrandId", order.BrandId);
                    sqlParam[12] = new SqlParameter("@AddOnId", order.AddOnId);
                    sqlParam[13] = new SqlParameter("ServiceProvider",order.ServiceProvider);


                    //yaha data table mein get table mein "PostOrderDetails" Procedure ka naam atta hai


                    DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("sa.PostServiceInventoryDetails", sqlParam);
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
