using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegisterPage.Models
{
    public class DBManager
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public int Insert(string procedure, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(procedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter dataIDU in parameters)
            {
                if (parameters != null)
                    cmd.Parameters.Add(dataIDU);
            }
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return 0;
        }
        public DataTable Select(string procedure, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(procedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter data in parameters)
            {
                cmd.Parameters.Add(data);
            }
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}