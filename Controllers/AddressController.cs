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
    public class AddressController : ApiController
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["WebApi"].ToString();

        //GetApi

        [HttpGet]
        public IEnumerable<AddressModel> GetAddress(string AddressId, string UserId)
        {

            List<AddressModel> objResult = new List<AddressModel>();
            try
            {
                if (clsMain.MyString(AddressId) == "0" || clsMain.MyString(AddressId) == null || clsMain.MyString(AddressId) == "" || clsMain.MyString(AddressId) == "undefined")
                {
                    AddressId = "0";
                }
                if (clsMain.MyString(UserId) == "0" || clsMain.MyString(UserId) == null || clsMain.MyString(UserId) == "" || clsMain.MyString(UserId) == "undefined")
                {
                    UserId = "0";
                }

                SQLHELPER obj = new SQLHELPER(ConnectionString);
                string str = " exec sa.GetAddressDetails @AddressId= " + AddressId + ",@UserId = " + UserId;

                DataTable dt = obj.getTable(str);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        AddressModel row = new AddressModel();

                        row.AddressId = clsMain.MyInt(item["AddressId"]);
                        row.Name = clsMain.MyString(item["Name"]);
                        row.PhoneNumber = clsMain.MyString(item["PhoneNumber"]);
                        row.Address1 = clsMain.MyString(item["Address1"]);
                        row.LandMark = clsMain.MyString(item["LandMark"]);
                        row.ZipCode = clsMain.MyString(item["ZipCode"]);
                        row.City = clsMain.MyString(item["City"]);
                        row.StateName = clsMain.MyString(item["StateName"]);
                        row.UserId = clsMain.MyInt(item["UserId"]);
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
        public AddressModel Addresses(AddressModel address)
        {
            AddressModel result = new AddressModel();
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[8];
                sqlParam[0] = new SqlParameter("@Name", address.Name);
                sqlParam[1] = new SqlParameter("@PhoneNumber", address.PhoneNumber);
                sqlParam[2] = new SqlParameter("@LandMark", address.LandMark);
                sqlParam[3] = new SqlParameter("@ZipCode", address.ZipCode);
                sqlParam[4] = new SqlParameter("@City", address.City);
                sqlParam[5] = new SqlParameter("@StateName", address.StateName);
                sqlParam[6] = new SqlParameter("@UserId", address.UserId);
                sqlParam[7] = new SqlParameter("@Address1", address.Address1);
                //yaha data table mein get table mein "PostOrderDetails" Procedure ka naam atta hai
                DataTable dt = new ESCommon.SQLHELPER(ConnectionString).getTable("dbo.PostAddressDetails", sqlParam);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.Message = clsMain.MyString(dt.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.ToString();
            }
            return result;
        }


        // DELETE api/items/5
        [HttpDelete]
        public AddressModel DeleteAddress(int AddressId)
        {
            AddressModel result = new AddressModel();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql = "DELETE FROM sa.Address WHERE AddressId = @AddressId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AddressId", AddressId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }


        //PUT api/items/5
        [HttpPut]
        public IHttpActionResult UpdateAddress(int AddressId, AddressModel address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql = "UPDATE sa.Address SET Name = @Name , PhoneNumber = @PhoneNumber,LandMark = @LandMark,ZipCode = @ZipCode,City = @City, StateName = @StateName ,UserId= @UserId WHERE AddressId = @AddressId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AddressId", AddressId);
                    command.Parameters.AddWithValue("@Name", address.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    command.Parameters.AddWithValue("@LandMark", address.LandMark);
                    command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@StateName", address.StateName);
                    command.Parameters.AddWithValue("@UserId", address.UserId);
                    command.ExecuteNonQuery();
                }
            }
            return Ok("Updated Successfully");
        }
    }
}