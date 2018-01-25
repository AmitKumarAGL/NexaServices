using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Net.Mail;
using NEXA.DataService.DataLayer;



namespace NEXA.DataService.DataLayer
{
  public class DmsDL
    {

        SQLHelper sqlhelper = new SQLHelper();
        SqlParameter[] sqlParam;
        DataSet ds;
        public static string SiteUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();

        public DataSet VehicleDetais(String P_PMC, String P_VIN, String P_REG_NO, String P_MODEL, String P_CHASSIS)
        {
            try 
            {
                
                sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@P_PMC", P_PMC);
                sqlParam[1] = new SqlParameter("@Region", P_VIN);
                sqlParam[2] = new SqlParameter("@Dealer_cd", P_REG_NO);
                sqlParam[3] = new SqlParameter("@For_cd", P_MODEL);
                sqlParam[1].Direction = ParameterDirection.Output;
                sqlParam[2].Direction = ParameterDirection.Output;
                sqlParam[3].Direction = ParameterDirection.Output;
             
             ds= sqlhelper.GetData("Manpowernew", sqlParam);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return ds;

        }
    }
}
