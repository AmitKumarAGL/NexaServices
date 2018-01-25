using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NEXA.DataService.DataLayer
{ 
  public class SQLHelper
    {
      public string constr = Convert.ToString(ConfigurationManager.ConnectionStrings["M3MCon"]);

      //To Get all properties
      public DataTable GetAll(string SP_name)
      {
          SqlConnection con = new SqlConnection(constr);
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = con;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = SP_name;
          SqlDataAdapter ad = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          ad.Fill(dt);
          return dt;

      }

      public DataSet ExecuteQuery(string queryname)
      {
          SqlConnection con = new SqlConnection(constr);
          SqlCommand cmd = new SqlCommand(queryname,con);
          cmd.Connection = con;         
          SqlDataAdapter ad = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          ad.Fill(ds);
          return ds;

      }


      //To Get Propertydetails by id
      public DataSet GetData(string SP_name,SqlParameter[] parameters)
      {
          SqlConnection con = new SqlConnection(constr);
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = con;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = SP_name;
          SqlDataAdapter ad = new SqlDataAdapter(cmd);
          AddParameters(ref cmd, parameters);
          DataSet ds = new DataSet();
          ad.Fill(ds);
          return ds;

      }
      public DataSet GetData(string SP_name)
      {
          SqlConnection con = new SqlConnection(constr);
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = con;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = SP_name;
          SqlDataAdapter ad = new SqlDataAdapter(cmd);          
          DataSet ds = new DataSet();
          ad.Fill(ds);
          return ds;

      }

      //To Insert data in table
      public void InsertData(string SP_name, SqlParameter[] parameters)
      {
          try
          {
              SqlConnection con = new SqlConnection(constr);
              SqlCommand cmd = new SqlCommand();
              cmd.Connection = con;
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = SP_name;
              AddParameters(ref cmd, parameters);
              con.Open();
              cmd.ExecuteNonQuery();
          }
          catch (Exception ex)
          {

              throw new Exception();
          }
         

      }

      public void AddParameters(ref SqlCommand cmd, SqlParameter[] parameters)
      {
          foreach (SqlParameter para in parameters)
          {
              if (para.Value == null)
              {
                  para.Value = (object)DBNull.Value;
              }

              cmd.Parameters.Add(para);
          }
      }


    }
}
