using Banner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Http;
using ESCommon;
using System.Data.SqlClient;

namespace Banner.Controllers
{
    public class UserController : ApiController
    {
        string ConStr = ConfigurationManager.ConnectionStrings["WebApi"].ToString();
        [HttpGet]
        public IEnumerable<User> GetLogin(string Email, string Pwd)
        {
            List<User> Result = new List<User>();
            try
            {
                
                string strQry = "Exec sp_login @Email = '" + Email + "' , @Password = '" + Pwd + "'";

                ESCommon.SQLHELPER obj = new ESCommon.SQLHELPER(ConStr);
                DataTable dt = obj.getTable(strQry);


                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        User ur = new User();
                        ur.username = clsMain.MyString(dt.Rows[i]["USERNAME"]);
                        ur.UserCode = clsMain.MyInt(dt.Rows[i]["UserID"]);
                        ur.UserType = clsMain.MyString(dt.Rows[i]["UserType"]);
                        ur.Password = clsMain.MyString(dt.Rows[i]["UserPassword"]);
                        ur.PhoneNumber = clsMain.MyString(dt.Rows[i]["Phonenumber"]);
                        ur.Email = clsMain.MyString(dt.Rows[i]["Email"]);
                        ur.Message = clsMain.MyString(dt.Rows[i]["Message"]);


                        Result.Add(ur);

                    }
                }
            }
            catch (Exception ex)
            {
                User uc = new User();
                uc.Message = ex.Message.ToString();
                Result.Add(uc);
            }
            return Result;

        }

        [HttpPost]
        public User UserRegistration(User uc)
        {
            User result = new User();
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@username", uc.username);
                sqlParam[1] = new SqlParameter("@password", uc.Password);
                sqlParam[2] = new SqlParameter("@confirmpassword", uc.ConfirmPassword);
                sqlParam[3] = new SqlParameter("@PhoneNumaber", uc.PhoneNumber);
                sqlParam[4] = new SqlParameter("@email", uc.Email);
                sqlParam[5] = new SqlParameter("@usertype", uc.UserType);
                DataTable dt = new ESCommon.SQLHELPER(ConStr).getTable("UserRegistration", sqlParam);
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
    }
}
