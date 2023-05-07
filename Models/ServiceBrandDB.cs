using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class ServiceBrandDB
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebApi"].ConnectionString);

        public List<ServiceBrand> Get()
        {
            List<ServiceBrand> list = new List<ServiceBrand>();

            SqlCommand cmd = new SqlCommand("Select * FROM sa.ServiceBrand", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ServiceBrand
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