using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Banner.Models
{
    public class ServiceBannerDB
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebApi"].ConnectionString);

        public List<ServiceBanner> Get()
        {
            List<ServiceBanner> list = new List<ServiceBanner>();

            SqlCommand cmd = new SqlCommand("Select * FROM sa.ServiceBanner", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ServiceBanner
                {
                    BannerId = Convert.ToInt32(dr[0]),
                    BannerName = Convert.ToString(dr[1]),
                    ImageUrl = Convert.ToString(dr[2]),
                });
            }
            return list;
        }
    }
}