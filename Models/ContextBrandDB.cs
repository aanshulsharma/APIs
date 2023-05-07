using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class ContextBrandDB
    {
        //For Connectivity
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebApi"].ConnectionString);

        public List<BrandModel> Get()
        {
            List<BrandModel> list = new List<BrandModel>();
            //Ek string type ka Sql Command le liya hai

            SqlCommand cmd = new SqlCommand("Select * FROM sa.Brand", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //data ko get karne ke liye ek container chaiye toh yaha pr data table ka use kr rahe hai
            //datatable ko islie liya tha kyuki jis se adapter ki through iskoi fill karana hai

            DataTable dt = new DataTable();
            da.Fill(dt);

            //data table mein is time pr value aa chuki hai or jab bhi hum adapter use karte hai toh we don't need to open or close the connection
            //Adapter 3 kam karte hai fill or update hi krta hai hai or connectivity bhi karta hai

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BrandModel
                {
                    BrandId = Convert.ToInt32(dr[0]),
                    BrandName = Convert.ToString(dr[1]),
                    Alias = Convert.ToString(dr[2]),
                    ImageUrl = Convert.ToString(dr[3]),
                });
            }
            return list;
        }
    }
}