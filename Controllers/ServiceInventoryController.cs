
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
    public class ServiceInventoryController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        // GET: api/Inventory

        [HttpGet]
        public IEnumerable<ServiceInven> GetDetails(string Id, string CategoryId, string BrandId, string AddOnId)
        {

            List<ServiceInven> objResult = new List<ServiceInven>();

            try
            {
                if (clsMain.MyString(Id) == "0" || clsMain.MyString(Id) == null || clsMain.MyString(Id) == "" || clsMain.MyString(Id) == "undefined")
                {
                    Id = "0";
                }
                if (clsMain.MyString(CategoryId) == "0" || clsMain.MyString(CategoryId) == null || clsMain.MyString(CategoryId) == "" || clsMain.MyString(CategoryId) == "undefined")
                {
                    CategoryId = "0";
                }
                if (clsMain.MyString(BrandId) == "0" || clsMain.MyString(BrandId) == null || clsMain.MyString(BrandId) == "" || clsMain.MyString(BrandId) == "undefined")
                {
                    BrandId = "0";
                }
                if (clsMain.MyString(AddOnId) == "0" || clsMain.MyString(AddOnId) == null || clsMain.MyString(AddOnId) == "" || clsMain.MyString(AddOnId) == "undefined")
                {
                    AddOnId = "0";
                }

                SQLHELPER obj = new SQLHELPER(ConnectionString);
                string str = "exec sa.GetServiceInventory @Id= '" + Id + "',@CategoryId = '" + CategoryId + "', @BrandId = '" + BrandId + "', @AddOnId = '" + AddOnId + "'";

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        ServiceInven row = new ServiceInven();

                        row.Id = clsMain.MyInt(item["Id"]);
                        row.ProductName = clsMain.MyString(item["ProductName"]);
                        row.ServiceName = clsMain.MyString(item["ServiceName"]);
                        row.ServiceCategory = clsMain.MyString(item["ServiceCategory"]);
                        row.ServicePrice = clsMain.MyInt(item["ServicePrice"]);
                        row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
                        row.ServiceDescriptionLong = clsMain.MyString(item["ServiceDescriptionLong"]);
                        row.ServiceDescriptionShort = clsMain.MyString(item["ServiceDescriptionShort"]);
                        row.ServiceStatus = clsMain.MyString(item["ServiceStatus"]);
                        row.DiscountPrice = clsMain.MyInt(item["DiscountPrice"]);
                        row.BrandName = clsMain.MyString(item["BrandName"]);
                        row.CategoryId = clsMain.MyInt(item["CategoryId"]);
                        row.BrandId = clsMain.MyInt(item["BrandId"]);
                        row.ServiceProvider = clsMain.MyString(item["ServiceProvider"]);
                     


                        // Fetch the add-on services data for this service
                        string str2 = "exec GetAddOnServiceByAddOnId @CategoryId = " + row.Id + "";
                        obj = new SQLHELPER(ConnectionString);
                        DataTable Dt = obj.getTable(str2);

                        row.AddOnServices = new List<AddOnServices>();

                        if (Dt != null && Dt.Rows.Count > 0)
                        {
                            foreach (DataRow addOnRow in Dt.Rows)
                            {
                                AddOnServices addOn = new AddOnServices();
                                addOn.AddOnId = clsMain.MyInt(addOnRow["AddOnId"]);
                                addOn.ProductName = clsMain.MyString(addOnRow["ProductName"]);
                                addOn.ServiceName = clsMain.MyString(addOnRow["ServiceName"]);
                                addOn.ServiceCategory = clsMain.MyString(addOnRow["ServiceCategory"]);
                                addOn.ServicePrice = clsMain.MyInt(addOnRow["ServicePrice"]);
                                addOn.ImageUrl = clsMain.MyString(addOnRow["ImageUrl"]);
                                addOn.ServiceDescriptionLong = clsMain.MyString(addOnRow["ServiceDescriptionLong"]);
                                addOn.ServiceDescriptionShort = clsMain.MyString(addOnRow["ServiceDescriptionShort"]);
                                addOn.ServiceStatus = clsMain.MyString(addOnRow["ServiceStatus"]);
                                addOn.DiscountPrice = clsMain.MyInt(addOnRow["DiscountPrice"]);
                                addOn.BrandName = clsMain.MyString(addOnRow["BrandName"]);
                                addOn.CategoryId = clsMain.MyInt(addOnRow["CategoryId"]);
                                addOn.BrandId = clsMain.MyInt(addOnRow["BrandId"]);
                                row.AddOnServices.Add(addOn);
                            }
                        }
                        objResult.Add(row);
                    }
                }
            }


            catch (Exception)
            {
                // Error handling code
            }

            return objResult;
        }
    }
}





//using Banner.Models;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using ESCommon;

//namespace Banner.Controllers
//{
//    public class ServiceInventoryController : ApiController
//    {
//        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
//        // GET: api/Inventory

//        [HttpGet]
//        public ServiceInven GetDetails(string Id, string CategoryId, string BrandId, string AddOnId)
//        {

//            ServiceInven result = new ServiceInven();

//            try
//            {
//                if (clsMain.MyString(Id) == "0" || clsMain.MyString(Id) == null || clsMain.MyString(Id) == "" || clsMain.MyString(Id) == "undefined")
//                {
//                    Id = "0";
//                }
//                if (clsMain.MyString(CategoryId) == "0" || clsMain.MyString(CategoryId) == null || clsMain.MyString(CategoryId) == "" || clsMain.MyString(CategoryId) == "undefined")
//                {
//                    CategoryId = "0";
//                }
//                if (clsMain.MyString(BrandId) == "0" || clsMain.MyString(BrandId) == null || clsMain.MyString(BrandId) == "" || clsMain.MyString(BrandId) == "undefined")
//                {
//                    BrandId = "0";
//                }
//                if (clsMain.MyString(AddOnId) == "0" || clsMain.MyString(AddOnId) == null || clsMain.MyString(AddOnId) == "" || clsMain.MyString(AddOnId) == "undefined")
//                {
//                    AddOnId = "0";
//                }



//                SQLHELPER obj = new SQLHELPER(ConnectionString);
//                DataSet ds = new ESCommon.SQLHELPER(ConnectionString).getDataSet("exec GetServiceInventory @Id= '" + Id + "',@CategoryId = '" + CategoryId + "', @BrandId = '" + BrandId + "',@AddOnId = '" + AddOnId + "'");

//                if (ds != null && ds.Tables.Count > 0)
//                {

//                   // result.Resuldata = new ResultData();

//                    DataTable dt = ds.Tables[0];
//                   // List< ServiceInven> ServiceInven = new List<ServiceInven>();
//                    if (dt.Rows.Count > 0)
//                    {
//                        foreach (DataRow item in dt.Rows)
//                        {
//                            ServiceInven row = new ServiceInven();

//                            row.Id = clsMain.MyInt(item["Id"]);
//                            row.ProductName = clsMain.MyString(item["ProductName"]);
//                            row.ServiceName = clsMain.MyString(item["ServiceName"]);
//                            row.ServiceCategory = clsMain.MyString(item["ServiceCategory"]);
//                            row.ServicePrice = clsMain.MyInt(item["ServicePrice"]);
//                            row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
//                            row.ServiceDescriptionLong = clsMain.MyString(item["ServiceDescriptionLong"]);
//                            row.ServiceDescriptionShort = clsMain.MyString(item["ServiceDescriptionShort"]);
//                            row.ServiceStatus = clsMain.MyString(item["ServiceStatus"]);
//                            row.DiscountPrice = clsMain.MyInt(item["DiscountPrice"]);
//                            row.BrandName = clsMain.MyString(item["BrandName"]);
//                            row.CategoryId = clsMain.MyInt(item["CategoryId"]);
//                            row.BrandId = clsMain.MyInt(item["BrandId"]);
//                            result.Add(row);

//                        }
//                    }

//                    DataTable dt1 = ds.Tables[1];

//                    result.Addonservicelist = new List<AddOnServices>();


//                    if (dt1.Rows.Count > 0)
//                    {
//                        foreach (DataRow item in dt1.Rows)
//                        {
//                            AddOnServices row = new AddOnServices();

//                            row.AddOnId = clsMain.MyInt(item["AddOnId"]);
//                            row.ProductName = clsMain.MyString(item["ProductName"]);
//                            row.ServiceName = clsMain.MyString(item["ServiceName"]);
//                            row.ServiceCategory = clsMain.MyString(item["ServiceCategory"]);
//                            row.ServicePrice = clsMain.MyInt(item["ServicePrice"]);
//                            row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
//                            row.ServiceDescriptionLong = clsMain.MyString(item["ServiceDescriptionLong"]);
//                            row.ServiceDescriptionShort = clsMain.MyString(item["ServiceDescriptionShort"]);
//                            row.ServiceStatus = clsMain.MyString(item["ServiceStatus"]);
//                            row.DiscountPrice = clsMain.MyInt(item["DiscountPrice"]);
//                            row.BrandName = clsMain.MyString(item["BrandName"]);
//                            row.CategoryId = clsMain.MyInt(item["CategoryId"]);
//                            row.BrandId = clsMain.MyInt(item["BrandId"]);

//                            result.Addonservicelist.Add(row);

//                        }
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return result;
//        }

//        [HttpPost]
//        public ServiceInven Inventories(List<ServiceInven> inventories)
//        {
//            ServiceInven result = new ServiceInven();
//            try
//            {
//                foreach (ServiceInven order in inventories)
//                {
//                    SqlParameter[] sqlParam = new SqlParameter[13];

//                    sqlParam[0] = new SqlParameter("@ProductName", order.ProductName);
//                    sqlParam[1] = new SqlParameter("@ServiceName", order.ServiceName);
//                    sqlParam[2] = new SqlParameter("@ServiceCategory", order.ServiceCategory);
//                    sqlParam[3] = new SqlParameter("@ServicePrice", order.ServicePrice);
//                    sqlParam[4] = new SqlParameter("@ImageUrl", order.ImageUrl);
//                    sqlParam[5] = new SqlParameter("@ServiceDescriptionLong", order.ServiceDescriptionLong);
//                    sqlParam[6] = new SqlParameter("@ServiceDescriptionShort", order.ServiceDescriptionShort);
//                    sqlParam[7] = new SqlParameter("@ServiceStatus", order.ServiceStatus);
//                    sqlParam[8] = new SqlParameter("@DiscountPrice", order.DiscountPrice);
//                    sqlParam[9] = new SqlParameter("@BrandName", order.BrandName);
//                    sqlParam[10] = new SqlParameter("@CategoryId", order.CategoryId);
//                    sqlParam[11] = new SqlParameter("@BrandId", order.BrandId);
//                    sqlParam[12] = new SqlParameter("@AddOnId", order.AddOnId);


//                    //yaha data table mein get table mein "PostOrderDetails" Procedure ka naam atta hai


//                    DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("PostServiceInventoryDetails", sqlParam);
//                    if (dt != null && dt.Rows.Count > 0)
//                    {
//                        result.Message = clsMain.MyString(dt.Rows[0][0]);
//                    }

//                }
//            }

//            catch (Exception ex)
//            {
//                result.Message = ex.Message.ToString();
//            }

//            return result;

//        }

//    }
//}
