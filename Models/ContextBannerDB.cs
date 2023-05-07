using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Banner.Models
{
    public class ContextBannerDB
    {
        //For Connectivity
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebApi"].ConnectionString);

        public List<BannerModel> Get()
        {
            List<BannerModel> list = new List<BannerModel>();
            //Ek string type ka Sql Command le liya hai

            SqlCommand cmd = new SqlCommand("Select * FROM sa.banner", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //data ko get karne ke liye ek container chaiye toh yaha pr data table ka use kr rahe hai
            //datatable ko islie liya tha kyuki jis se adapter ki through iskoi fill karana hai

            DataTable dt = new DataTable();
            da.Fill(dt);

            //data table mein is time pr value aa chuki hai or jab bhi hum adapter use karte hai toh we don't need to open or close the connection
            //Adapter 3 kam karte hai fill or update hi krta hai hai or connectivity bhi karta hai

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BannerModel
                {
                    banner_id = Convert.ToInt32(dr[0]),
                    banner_name = Convert.ToString(dr[1]),
                    banner_images = Convert.ToString(dr[2]),
                });
            }
            return list;
        }
    }
}