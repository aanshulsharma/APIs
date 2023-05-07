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
using System.Web;
using System.IO;

namespace Banner.Controllers
{
    public class InventoryController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        // GET: api/Inventory

        [HttpGet]
        public IEnumerable<InvenModel>GetDetails(string Id,string CategoryId, string BrandId)
        {

            List<InvenModel> objResult = new List<InvenModel>();

            try
            {
                if (clsMain.MyString(Id) == "0" || clsMain.MyString(Id) == null || clsMain.MyString(Id) == "" || clsMain.MyString(Id) == "undefined")
                {
                    Id = "0";
                }
                if (clsMain.MyString(CategoryId) == "0" || clsMain.MyString(CategoryId) == null || clsMain.MyString(CategoryId)=="" || clsMain.MyString(CategoryId) == "undefined")
                {
                    CategoryId = "0";
                }
                if (clsMain.MyString(BrandId) == "0" || clsMain.MyString(BrandId) == null || clsMain.MyString(BrandId) == "" || clsMain.MyString(BrandId) == "undefined")
                {
                    BrandId = "0";
                }

                SQLHELPER obj = new SQLHELPER(ConnectionString);
                string str = " exec sa.GetInventoryDetails @Id= " + Id + ",@CategoryId = " + CategoryId + ", @BrandId = " + BrandId;

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        InvenModel row = new InvenModel();

                        row.Id = clsMain.MyInt(item["Id"]);
                        row.ProductName = clsMain.MyString(item["ProductName"]);
                        row.ProductCategory = clsMain.MyString(item["ProductCategory"]);
                        row.ProductPrice = clsMain.MyInt(item["ProductPrice"]);
                        row.ImageUrl = clsMain.MyString(item["ImageUrl"]);
                        row.ProductDescription_Long = clsMain.MyString(item["ProductDescription_Long"]);
                        row.ProductDescription_Short = clsMain.MyString(item["ProductDescription_Short"]);
                        row.StockQuantity = clsMain.MyInt(item["StockQuantity"]);
                        row.StockStatus = clsMain.MyString(item["StockStatus"]);
                        row.ProductWeight = clsMain.MyInt(item["ProductWeight"]);
                        row.ProductDimension = clsMain.MyString(item["ProductDimension"]);
                        row.DisPrice = clsMain.MyInt(item["DisPrice"]);
                        row.QTY = clsMain.MyInt(item["QTY"]);
                        row.Brand = clsMain.MyString(item["Brand"]);
                        row.CategoryId = clsMain.MyInt(item["CategoryId"]);
                        row.BrandId = clsMain.MyInt(item["BrandId"]);
                        row.Seller = clsMain.MyString(item["Seller"]);
                        objResult.Add(row);
                    }

                }

            }
            catch (Exception ex)
            {
                return (IEnumerable<InvenModel>)InternalServerError(ex);
                //if (ex.Message.ToString().Contains("Conversion failed when converting the varchar value "));
                //return objResult;
            }

            return objResult;
        }

        [HttpPost]
        public InvenModel Inventories(List<InvenModel> inventories)
        {
            InvenModel result = new InvenModel();
            try
            {
                foreach (InvenModel order in inventories)
                {
                    SqlParameter[] sqlParam = new SqlParameter[16];

                    sqlParam[0] = new SqlParameter("@ProductName", order.ProductName);
                    sqlParam[1] = new SqlParameter("@ProductCategory", order.ProductCategory);
                    sqlParam[2] = new SqlParameter("@ProductPrice", order.ProductPrice);
                    sqlParam[3] = new SqlParameter("@ImageUrl", order.ImageUrl);
                    sqlParam[4] = new SqlParameter("@ProductDescription_Long", order.ProductDescription_Long);
                    sqlParam[5] = new SqlParameter("@ProductDescription_Short", order.ProductDescription_Short);
                    sqlParam[6] = new SqlParameter("@StockQuantity", order.StockQuantity);
                    sqlParam[7] = new SqlParameter("@StockStatus", order.StockStatus);
                    sqlParam[8] = new SqlParameter("@ProductWeight", order.ProductWeight);
                    sqlParam[9] = new SqlParameter("@ProductDimension", order.ProductDimension);
                    sqlParam[10] = new SqlParameter("@DisPrice", order.DisPrice);
                    sqlParam[11] = new SqlParameter("@QTY", order.QTY);
                    sqlParam[12] = new SqlParameter("@Brand", order.Brand);
                    sqlParam[13] = new SqlParameter("@CategoryId", order.CategoryId);
                    sqlParam[14] = new SqlParameter("@BrandId", order.BrandId);
                    sqlParam[15] = new SqlParameter("@Seller", order.Seller);


                    //yaha data table mein get table mein "PostOrderDetails" Procedure ka naam atta hai
                    

                    DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("sa.PostInventoryDetails", sqlParam);
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

