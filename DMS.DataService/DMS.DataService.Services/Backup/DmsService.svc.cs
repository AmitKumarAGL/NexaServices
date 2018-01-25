using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMS.DataService.ServiceContract;
using System.ServiceModel.Activation;
using DMS.DataService.DataContract;
using DMS.DataService.Common.Enum;
using DMS.DataService.LogHelper;
using DMS.DataService.DataLayer;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel.Web;
using System.Data.OracleClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace DMS.DataService.Services
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DmsService : IDmsService
    {
        string constr = ConfigurationManager.ConnectionStrings["conoracle"].ConnectionString;
        OracleConnection con;
        OracleCommand cmd;
        DataSet ds;
        OracleDataAdapter da;
        DataTable dt;

        string Usp_Manpower = ConfigurationManager.AppSettings["Usp_Manpower"].ToString();
        string Usp_VehicleDetais = ConfigurationManager.AppSettings["Usp_VehicleDetais"].ToString();
        string Usp_CarEnquiry = ConfigurationManager.AppSettings["Usp_CarEnquiry"].ToString();
        string Usp_PushEvaluation = ConfigurationManager.AppSettings["Usp_PushEvaluation"].ToString();
        string Usp_VehicleStatusSearch = ConfigurationManager.AppSettings["Usp_VehicleStatusSearch"].ToString();
        string Usp_VehicleHistory = ConfigurationManager.AppSettings["Usp_VehicleHistory"].ToString();
        string Usp_VehicleHistory2 = ConfigurationManager.AppSettings["Usp_VehicleHistory2"].ToString();
        string Usp_MakeList = ConfigurationManager.AppSettings["Usp_MakeList"].ToString();
        string Usp_ModelList = ConfigurationManager.AppSettings["Usp_ModelList"].ToString();
        string Usp_SubModelList = ConfigurationManager.AppSettings["Usp_SubModelList"].ToString();
        string Usp_VariantColorList = ConfigurationManager.AppSettings["Usp_VariantColorList"].ToString();
        string Usp_EmissionList = ConfigurationManager.AppSettings["Usp_EmissionList"].ToString();
        string Usp_NtvReasonList = ConfigurationManager.AppSettings["Usp_NtvReasonList"].ToString();

        public static string siteurl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();


        #region Manpower mapped with Dealers

        public BaseListReturnType<Manpower> ManpowerList(string ppmc)
        {
            BaseListReturnType<Manpower> response = new BaseListReturnType<Manpower>();
            List<Manpower> mainlist = new List<Manpower>();
            Manpower list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }

            try
            {

                DmsDL dmsdl = new DmsDL();
                string[] arr1 = new string[] { "one", "two", "three" };

                if (string.IsNullOrEmpty(ppmc))
                {
                    ppmc = "1";
                }

                if (!CheckSpecialChar(ppmc))
                {
                    response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                    response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                    response.result = null;
                    return response;
                }
                else
                {
                    OracleDataReader rdrManpower;
                    con = new OracleConnection(constr);
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Usp_Manpower;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(ppmc);// Input variable                  
                    cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                    cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    rdrManpower = (OracleDataReader)cmd.Parameters["list_cursor"].Value;
                    //catch error from db
                    if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                    {
                        response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                        response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                        response.result = null;
                        return response;
                    }

                    if (rdrManpower.HasRows)
                    {
                        while (rdrManpower.Read())
                        {
                            try
                            {
                                list = new Manpower();
                                list.REGION_CD = rdrManpower["REGION_CD"].ToString();
                                list.MUL_DEALER_CD = rdrManpower["MUL_DEALER_CD"].ToString();
                                list.FOR_CD = rdrManpower["FOR_CD"].ToString();
                                list.PARENT_GROUP = rdrManpower["PARENT_GROUP"].ToString();
                                list.DEALER_MAP_CD = rdrManpower["DEALER_MAP_CD"].ToString();
                                list.LOC_CD = rdrManpower["LOC_CD"].ToString();
                                list.EMP_CD = rdrManpower["EMP_CD"].ToString();
                                list.EMP_NAME = rdrManpower["EMP_NAME"].ToString();
                                list.MSPIN = rdrManpower["MSPIN"].ToString();
                                list.EMP_EMAIL_ID = rdrManpower["EMP_EMAIL_ID"].ToString();
                                list.DESG_DESC = rdrManpower["DESG_DESC"].ToString();
                                list.MOBILE = rdrManpower["MOBILE"].ToString();
                                list.EMP_JOINING_DATE = rdrManpower["EMP_JOINING_DATE"].ToString();
                                list.EMP_LEAVING_DATE = rdrManpower["EMP_LEAVING_DATE"].ToString();
                                list.LEAVING_REASON = rdrManpower["LEAVING_REASON"].ToString();
                                list.M_MUL_DEALER_CD = rdrManpower["M_MUL_DEALER_CD"].ToString();
                                list.M_FOR_CD = rdrManpower["M_FOR_CD"].ToString();
                                list.M_PARENT_GROUP = rdrManpower["M_PARENT_GROUP"].ToString();
                                list.M_DEALER_MAP_CD = rdrManpower["M_DEALER_MAP_CD"].ToString();
                                list.M_LOC_CD = rdrManpower["M_LOC_CD"].ToString();
                               
                                mainlist.Add(list);
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }

                    con.Close();
                    response.code = (int)ServiceMassageCode.SUCCESS;
                    response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    response.result = mainlist;
                    return response;
                }
            }

            catch (Exception ex)
            {
                //Logging.Error(ex, "DmsService:ManpowerList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }


        }

        #endregion

        #region To Get vehicle details on the basis of VIN/Reg num/Model+chassis

        public BaseReturnType<VinSearch> VehicleDetails(String vinNo, String regNo, bool msil, string p_pmc, string p_model, string p_chassis)
        {
            BaseReturnType<VinSearch> response = new BaseReturnType<VinSearch>();
            try
            {
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
                if (!headerInfo.IsAuthenticated)
                {
                    response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                    response.message = Convert.ToString(ServiceMassageCode.ERROR);
                    response.result = null;
                    return response;
                }


                VinSearch vinSearch = new VinSearch();

                if (!CheckSpecialChar(vinNo))
                {
                    response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                    response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                    response.result = null;
                    return response;
                }
                if (!CheckSpecialChar(regNo))
                {
                    response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                    response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                    response.result = null;
                    return response;
                }
                OracleDataReader rdrDetail;
                OracleDataReader rdrDetail1;
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_VehicleDetais;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_PMC", OracleType.VarChar).Value = p_pmc; // Input
                cmd.Parameters.Add("P_VIN", OracleType.VarChar).Value = vinNo; // Input
                cmd.Parameters.Add("P_REG_NO", OracleType.VarChar).Value = regNo; // Input
                cmd.Parameters.Add("P_MODEL", OracleType.VarChar).Value = p_model; // Input
                cmd.Parameters.Add("P_CHASSIS", OracleType.VarChar).Value = p_chassis; // Input
                cmd.Parameters.Add("ERR_CD", OracleType.Number).Direction = ParameterDirection.Output;//out put
                cmd.Parameters.Add("ERR_REASON", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//out put
                cmd.Parameters.Add("VEH_DETAIL", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("VEH_DETAIL1", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                con.Open();
                cmd.ExecuteNonQuery();
                //catch error from db
                if (!string.IsNullOrEmpty(cmd.Parameters["ERR_REASON"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["ERR_REASON"].Value.ToString();
                    response.result = null;
                    return response;
                }
              
                    rdrDetail = (OracleDataReader)cmd.Parameters["VEH_DETAIL"].Value;
                    rdrDetail1 = (OracleDataReader)cmd.Parameters["VEH_DETAIL1"].Value;
                    

                    if (rdrDetail.HasRows)
                    {
                        while (rdrDetail.Read())
                        {
                            vinSearch.MODEL_CD = rdrDetail["MODEL_CD"].ToString();
                            vinSearch.MODEL_DESC = rdrDetail["MODEL_DESC"].ToString();
                            vinSearch.VARIANT_CD = rdrDetail["VARIANT_CD"].ToString();
                            vinSearch.VARIANT_DESC = rdrDetail["VARIANT_DESC"].ToString();
                            vinSearch.CHASSIS = rdrDetail["CHASSIS"].ToString();
                            vinSearch.ENGINE_NUMBER = rdrDetail["ENGINE_NUMBER"].ToString();
                            vinSearch.VIN_NUMBER = rdrDetail["VIN_NUMBER"].ToString();
                            vinSearch.SRL_NUM = rdrDetail["SRL_NUM"].ToString();
                            vinSearch.M =  rdrDetail["M"].ToString();
                            vinSearch.MARUTI = rdrDetail["MARUTI"].ToString();
                            vinSearch.REG_NUM = rdrDetail["REG_NUM"].ToString();
                        }
                    }
                  else if (rdrDetail1.HasRows)
                    {
                        while (rdrDetail1.Read())
                        {
                            vinSearch.MODEL_CD = rdrDetail1["MODEL_CD"].ToString();
                            vinSearch.MODEL_DESC = rdrDetail1["MODEL_DESC"].ToString();
                            vinSearch.VARIANT_CD = rdrDetail1["VARIANT_CD"].ToString();
                            vinSearch.VARIANT_DESC = rdrDetail1["VARIANT_DESC"].ToString();
                            vinSearch.CHASSIS = rdrDetail1["INVD_CHASSIS_NUM"].ToString();
                            vinSearch.ENGINE_NUMBER = rdrDetail1["INVD_ENG_NUM"].ToString();
                            vinSearch.VIN_NUMBER = rdrDetail1["INVD_VIN"].ToString();
                            vinSearch.SRL_NUM = rdrDetail1["SRL_NUM"].ToString();
                            vinSearch.M = rdrDetail1["M"].ToString();
                            vinSearch.MARUTI = rdrDetail1["MARUTI"].ToString();
                            vinSearch.REG_NUM = rdrDetail1["REG_NUM"].ToString();
                        }
                    }

                
                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = vinSearch;


            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "DMS:VehicleDetais");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;//Convert.ToString(ServiceMassageCode.ERROR);               
                response.result = null;
            }

            return response;
        }

        #endregion

        #region Car Enquiry
        public BaseListReturnType<CarEnquiry> CarEnquiry(string MSPIN, string p_pmc, string p_parent_group, string p_dealer_map_cd, string p_loc_cd, string p_enq_num, string fromDate, string toDate)
        {
            BaseListReturnType<CarEnquiry> response = new BaseListReturnType<CarEnquiry>();
            List<CarEnquiry> mainlist = new List<CarEnquiry>();
            CarEnquiry list;
            if (!string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }
            if (string.IsNullOrEmpty(fromDate))
            {
                fromDate = DateTime.Now.AddDays(-7).ToShortDateString();
            }

            if (string.IsNullOrEmpty(toDate))
            {
                toDate = DateTime.Now.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(MSPIN))
            {
                if (!CheckSpecialChar(MSPIN))
                {
                    response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                    response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                    response.result = null;
                    return response;
                }
            }
            if (!ValidateDate(fromDate))
            {
                response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                response.result = null;
                return response;
            }
            if (!ValidateDate(toDate))
            {
                response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                response.result = null;
                return response;
            }

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }

            try
            {
                OracleDataReader rdrP_enq_detail;
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_CarEnquiry;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.VarChar).Value = p_pmc;
                cmd.Parameters.Add("p_parent_group", OracleType.VarChar).Value = p_parent_group; // Input
                cmd.Parameters.Add("p_dealer_map_cd", OracleType.VarChar).Value = p_dealer_map_cd; // Input
                cmd.Parameters.Add("p_loc_cd", OracleType.VarChar).Value = p_loc_cd; // Input
                cmd.Parameters.Add("p_enq_num", OracleType.VarChar).Value = p_enq_num; // Input
                cmd.Parameters.Add("p_mspin", OracleType.VarChar).Value = MSPIN; // Input
                cmd.Parameters.Add("p_fromdate", OracleType.DateTime).Value = Convert.ToDateTime(fromDate); // Input
                cmd.Parameters.Add("p_todate", OracleType.DateTime).Value = Convert.ToDateTime(toDate); ; // Input    
                cmd.Parameters.Add("p_enq_detail", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                //catch error from db
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
               
                    rdrP_enq_detail = (OracleDataReader)cmd.Parameters["p_enq_detail"].Value;
                    if (rdrP_enq_detail.HasRows)
                    {
                        while (rdrP_enq_detail.Read())
                        {
                            list = new CarEnquiry();
                            list.REGION_CD = rdrP_enq_detail["REGION_CD"].ToString();
                            list.MUL_DEALER_CD = rdrP_enq_detail["MUL_DEALER_CD"].ToString();
                            list.FOR_CD = rdrP_enq_detail["FOR_CD"].ToString();
                            list.PARENT_GROUP = rdrP_enq_detail["PARENT_GROUP"].ToString();
                            list.DEALER_MAP_CD = rdrP_enq_detail["DEALER_MAP_CD"].ToString();
                            list.LOC_CD = rdrP_enq_detail["LOC_CD"].ToString();
                            list.ENQ_NUM = rdrP_enq_detail["ENQ_NUM"].ToString();
                            list.ENQ_DATE = rdrP_enq_detail["ENQ_DATE"].ToString();
                            list.MODEL_CD = rdrP_enq_detail["MODEL_CD"].ToString();
                            list.ENQ_VARIANTCD = rdrP_enq_detail["ENQ_VARIANTCD"].ToString();
                            list.CUST_NAME = rdrP_enq_detail["CUST_NAME"].ToString();
                            list.MOBILE = rdrP_enq_detail["MOBILE"].ToString();
                            list.DSE_NAME = rdrP_enq_detail["DSE_NAME"].ToString();
                            list.ENQ_SOURCE = rdrP_enq_detail["ENQ_SOURCE"].ToString();
                            list.TYPE_OF_BUYER = rdrP_enq_detail["TYPE_OF_BUYER"].ToString();
                            list.COMP_FA = rdrP_enq_detail["COMP_FA"].ToString();                                               
                            mainlist.Add(list);
                        }
                    }
                
                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;

            }

            catch (Exception ex)
            {
                //Logging.Error(ex, "DMS:CarEnquiry");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region push Evaluation

        public BaseReturnType<string> PushEvaluaton(PushEvaluation Input)
        {
            BaseReturnType<string> response = new BaseReturnType<string>();
            try
            {
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
                DateTime DateOfEval;
                if (!headerInfo.IsAuthenticated)
                {
                    response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                    response.message = Convert.ToString(ServiceMassageCode.ERROR);
                    response.result = null;
                    return response;
                }
             
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_PushEvaluation;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_trans_id", OracleType.VarChar).Value = Input.evaluationId;// Input variable
                cmd.Parameters.Add("p_parent_group", OracleType.VarChar).Value = Input.parentGroup;
                cmd.Parameters.Add("p_dealer_map_cd", OracleType.Number).Value = Convert.ToInt64(Input.dealerCode);
                cmd.Parameters.Add("p_loc_cd", OracleType.VarChar).Value = Input.locCd;
                cmd.Parameters.Add("p_comp_fa", OracleType.VarChar).Value = Input.compFa;
                cmd.Parameters.Add("p_enq_num", OracleType.VarChar).Value = Input.enquiryNo;
                cmd.Parameters.Add("p_oc_cust_name", OracleType.VarChar).Value = Input.customerDetails.customerName;
                cmd.Parameters.Add("p_oc_cust_mobile", OracleType.VarChar).Value = Input.customerDetails.customerMobile;
                cmd.Parameters.Add("p_manufacturer", OracleType.VarChar).Value = Input.vehicleDetails.manufacturer;
                cmd.Parameters.Add("p_model", OracleType.VarChar).Value = Input.vehicleDetails.model;
                cmd.Parameters.Add("p_submodel", OracleType.VarChar).Value = Input.vehicleDetails.submodel;
                cmd.Parameters.Add("p_chassis", OracleType.VarChar).Value = Input.vehicleDetails.chassisNo;
                cmd.Parameters.Add("p_engine", OracleType.VarChar).Value = Input.vehicleDetails.engineNo;
                cmd.Parameters.Add("p_vin", OracleType.VarChar).Value = Input.vehicleDetails.vinNo;
                cmd.Parameters.Add("p_yom", OracleType.Number).Value = Convert.ToInt64(Input.vehicleDetails.yom);
                cmd.Parameters.Add("p_emission", OracleType.VarChar).Value = Input.vehicleDetails.emission;
                cmd.Parameters.Add("p_dor", OracleType.DateTime).Value = Input.DOR;
                cmd.Parameters.Add("p_eng_cc", OracleType.Number).Value = Convert.ToInt64(Input.engionCC);
                cmd.Parameters.Add("p_color", OracleType.VarChar).Value = Input.vehicleDetails.color;
                cmd.Parameters.Add("p_reg_num", OracleType.VarChar).Value = Input.vehicleDetails.vehicleRegNo;
                cmd.Parameters.Add("p_mileage", OracleType.Number).Value = Convert.ToInt64(Input.evaluationDetails.mileage);
                cmd.Parameters.Add("p_previous_owner", OracleType.Number).Value = Convert.ToInt64(Input.evaluationDetails.previousOwner);
                cmd.Parameters.Add("p_rf_cost", OracleType.Number).Value = Convert.ToInt64(Input.evaluationDetails.evaluatedRFCost);
                cmd.Parameters.Add("p_category", OracleType.VarChar).Value = Input.evaluationDetails.category;
                cmd.Parameters.Add("p_reason_for_ntv", OracleType.VarChar).Value = Input.evaluationDetails.reasonForNTV;
                cmd.Parameters.Add("p_eval_remarks", OracleType.VarChar).Value = Input.evaluationDetails.evaluationRemarks;
                cmd.Parameters.Add("p_expected_price", OracleType.Number).Value = Convert.ToInt64(Input.priceDetails.expectedPrice);
                cmd.Parameters.Add("p_offered_price", OracleType.Number).Value = Convert.ToInt64(Input.priceDetails.offeredPrice);
                cmd.Parameters.Add("p_mspin", OracleType.VarChar).Value = Input.MSPIN;
                cmd.Parameters.Add("p_enquiry_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_buying_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                string outputStr = string.Empty; 
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
               
                    try
                    {
                        outputStr = "buyingNumer = " + cmd.Parameters["p_buying_num"].Value.ToString() + " : enquiryNumber = " + cmd.Parameters["p_buying_num"].Value.ToString(); //"165489sdf";
                    }
                    catch (Exception ex)
                    {
                        response.code = 100; //(int)ServiceMassageCode.SUCCESS;
                        response.message = ex.Message;
                        response.result = null;
                    }
                
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = outputStr;


            }

            catch (Exception ex)
            {
                //Logging.Error(ex, "DMS:PushEvaluaton");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = "";
            }

            return response;
        }
        #endregion

        #region  Vehicle Status Search

        public BaseListReturnType<VehicleStatusSearch> VehicleStatusSearch(string P_BUYING_NUM, string P_REG_NO, string P_MODEL, string P_CHASSIS)
        {
            BaseListReturnType<VehicleStatusSearch> response = new BaseListReturnType<VehicleStatusSearch>();
            List<VehicleStatusSearch> mainlist = new List<VehicleStatusSearch>();
            VehicleStatusSearch list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            try
            {
                OracleDataReader rdrPOC_DETAIL;
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_VehicleStatusSearch;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_BUYING_NUM", OracleType.VarChar).Value = P_BUYING_NUM;
                cmd.Parameters.Add("P_REG_NO", OracleType.VarChar).Value = P_REG_NO;
                cmd.Parameters.Add("P_MODEL", OracleType.VarChar).Value = P_MODEL;
                cmd.Parameters.Add("P_CHASSIS", OracleType.VarChar).Value = P_CHASSIS;
                cmd.Parameters.Add("POC_DETAIL", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("ERR_CD", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("ERR_REASON", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();

                rdrPOC_DETAIL = (OracleDataReader)cmd.Parameters["POC_DETAIL"].Value;
                if (!string.IsNullOrEmpty(cmd.Parameters["ERR_REASON"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["ERR_REASON"].Value.ToString();
                    response.result = null;
                    return response;
                }
              
                    if (rdrPOC_DETAIL.HasRows)
                    {
                        while (rdrPOC_DETAIL.Read())
                        {
                            list = new VehicleStatusSearch();
                            list.buyCancelDate = rdrPOC_DETAIL["BUY_CANCEL_DATE"].ToString();
                            list.buyCancelReason = rdrPOC_DETAIL["BUY_CANCEL_REASON"].ToString();
                            list.buyDate = rdrPOC_DETAIL["BUY_DATE"].ToString();
                            list.buyingNum = rdrPOC_DETAIL["BUYING_NUM"].ToString();
                            list.dealerName = rdrPOC_DETAIL["DEALER_NAME"].ToString();
                            list.dlrCiry = rdrPOC_DETAIL["DLR_CITY"].ToString();
                            list.dlrForCd = rdrPOC_DETAIL["DLR_FOR_CD"].ToString();
                            list.regNo = rdrPOC_DETAIL["REG_NO"].ToString();
                            list.vehCategory = rdrPOC_DETAIL["VEH_CATEGORY"].ToString();
                            list.evalDate = rdrPOC_DETAIL["EVAL_DATE"].ToString();
                            list.exchangeDate = rdrPOC_DETAIL["EXCHANGE_DATE"].ToString();
                            list.exchCancelDate = rdrPOC_DETAIL["EXCH_CANCEL_DATE"].ToString();
                            list.sellDate = rdrPOC_DETAIL["SELL_DATE"].ToString();
                            list.expiryDate = rdrPOC_DETAIL["EXPIRY_DATE"].ToString();
                            list.buyTransferTvCode = rdrPOC_DETAIL["BUY_TRANSFER_TV_CODE"].ToString();
                            list.rfDate = rdrPOC_DETAIL["RF_DATE"].ToString();
                            list.rfCertificationDate = rdrPOC_DETAIL["RF_CERTIFICATION_DATE"].ToString();
                            list.invPocExchangeFlag = rdrPOC_DETAIL["INV_POC_EXCHANGE_FLAG"].ToString();
                            list.catgAtBuy = rdrPOC_DETAIL["CATG_AT_BUY"].ToString();
                            list.stkCatgCurrSaleTime = rdrPOC_DETAIL["STK_CATG_CURR_SALE_TIME"].ToString();
                            list.StkTvNtvCounter = rdrPOC_DETAIL["STK_TV_NTV_COUNTER"].ToString();
                            list.srlNum = rdrPOC_DETAIL["SRL_NUM"].ToString();
                            mainlist.Add(list);

                        }
                    }
                
                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;


            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }

        #endregion

        #region Vehicle History
        public BaseListReturnType<VehicleHistory> VehicleHistory(string pn_reg_num, string pn_user_id)
        {
            BaseListReturnType<VehicleHistory> response = new BaseListReturnType<VehicleHistory>();
            List<VehicleHistory> mainlist;
            VehicleHistory list;
            List<Followup> listFollowup = new List<Followup>();
            List<Part> listPart = new List<Part>();
            List<Labour> listLabour = new List<Labour>();
            List<Demand> listDemand = new List<Demand>();
            Followup listFollowup1;
            Part listPart1;
            Labour listLabour1;
            Demand listDemand1;


            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_VehicleHistory;//"PKG_JCO_1.SP_JCO_GET_HISTROY_HDR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("po_hist_hdr_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                OracleDataReader rdrFollowup;
                OracleDataReader rdrPart;
                OracleDataReader rdrLabour;
                OracleDataReader rdrDemand;

                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
                else
                {

                    con.Close();
                    mainlist = new List<VehicleHistory>();
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            try
                            {
                                con = new OracleConnection(constr);
                                cmd = new OracleCommand();
                                cmd.Connection = con;
                                cmd.CommandText = Usp_VehicleHistory2;//PKG_JCO_1.SP_JCO_GET_HISTROY_DTL
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("pn_ro_num", OracleType.VarChar).Value = ds.Tables[0].Rows[i]["JOB_CARD_NUM"].ToString();
                                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                                cmd.Parameters.Add("po_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("po_labor_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("po_demand_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                                if (con.State != ConnectionState.Open)
                                {
                                    con.Open();
                                }
                                cmd.ExecuteNonQuery();
                                rdrFollowup = (OracleDataReader)cmd.Parameters["po_followup_refcur"].Value;
                                rdrPart = (OracleDataReader)cmd.Parameters["po_part_refcur"].Value;
                                rdrLabour = (OracleDataReader)cmd.Parameters["po_labor_refcur"].Value;
                                rdrDemand = (OracleDataReader)cmd.Parameters["po_demand_refcur"].Value;
                                if (rdrFollowup.HasRows)
                                {
                                    while (rdrFollowup.Read())
                                    {
                                        listFollowup1 = new Followup();
                                        listFollowup1.PSF_NUM = rdrFollowup["PSF_NUM"].ToString();
                                        listFollowup1.PSF_DATE = rdrFollowup["PSF_DATE"].ToString();
                                        listFollowup1.PSF_BY = rdrFollowup["PSF_BY"].ToString();
                                        listFollowup1.GEN_REMARKS = rdrFollowup["GEN_REMARKS"].ToString();
                                        listFollowup1.SATISFIED_FLAG = rdrFollowup["SATISFIED_FLAG"].ToString();
                                        listFollowup1.SATISFIED_DESC = rdrFollowup["SATISFIED_DESC"].ToString();
                                        listFollowup.Add(listFollowup1);

                                    }
                                }
                                if (rdrPart.HasRows)
                                {
                                    while (rdrPart.Read())
                                    {
                                        listPart1 = new Part();
                                        listPart1.PART_NUM = rdrPart["PART_NUM"].ToString();
                                        listPart1.PART_DESC = rdrPart["PART_DESC"].ToString();
                                        listPart1.ISS_QTY = rdrPart["ISS_QTY"].ToString();
                                        listPart1.PART_AMT = rdrPart["PART_AMT"].ToString();
                                        listPart1.BILLABLE_TYPE = rdrPart["BILLABLE_TYPE"].ToString();
                                        listPart.Add(listPart1);
                                    }
                                }

                                if (rdrLabour.HasRows)
                                {
                                    while (rdrLabour.Read())
                                    {
                                        listLabour1 = new Labour();
                                        listLabour1.OPR_CD = rdrLabour["OPR_CD"].ToString();
                                        listLabour1.OPR_DESC = rdrLabour["OPR_DESC"].ToString();
                                        listLabour1.OPR_AMT = rdrLabour["OPR_AMT"].ToString();
                                        listLabour1.BILLTYPE = rdrLabour["BILLTYPE"].ToString();
                                        listLabour.Add(listLabour1);
                                    }
                                }
                                if (rdrDemand.HasRows)
                                {
                                    while (rdrDemand.Read())
                                    {
                                        listDemand1 = new Demand();
                                        listDemand1.DEMAND_CD = rdrDemand["DEMAND_CD"].ToString();
                                        listDemand1.DEMAND_DESC = rdrDemand["DEMAND_DESC"].ToString();
                                        listDemand1.CUSTOMER_VOICE = rdrDemand["CUSTOMER_VOICE"].ToString();
                                        listDemand.Add(listDemand1);
                                    }
                                }

                                //con.Close();
                            }
                            catch (Exception ex)
                            {
                                con.Close();
                            }

                            list = new VehicleHistory();
                            list.followups = listFollowup;
                            list.parts = listPart;
                            list.labours = listLabour;
                            list.demands = listDemand;
                            mainlist.Add(list);

                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = 100;//(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }

        #endregion

        #region MAKE MASTER
        public BaseListReturnType<MakeMaster> MakeList(string p_pmc)
        {
            BaseListReturnType<MakeMaster> response = new BaseListReturnType<MakeMaster>();
            List<MakeMaster> mainlist = new List<MakeMaster>();
            MakeMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                response.code = (int)ServiceMassageCode.INVALID_PARAMETER;
                response.message = Convert.ToString(ServiceMassageCode.INVALID_PARAMETER);
                response.result = null;
                return response;
            }

            try
            {

                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MakeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1                
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }


                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new MakeMaster();
                        list.makeCode = ds.Tables[0].Rows[i]["MAKE_CD"].ToString();
                        list.makeDesc = ds.Tables[0].Rows[i]["MAKE_DESCRIPTION"].ToString();
                        mainlist.Add(list);
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region Model Master
        public BaseListReturnType<ModelMaster> ModelList(string p_pmc)
        {
            BaseListReturnType<ModelMaster> response = new BaseListReturnType<ModelMaster>();
            List<ModelMaster> mainlist = new List<ModelMaster>();
            ModelMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }
            try
            {


                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_ModelList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1                
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }

                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new ModelMaster();
                        list.makeCode = ds.Tables[0].Rows[i]["MAKE_CD"].ToString();
                        list.modelCode = ds.Tables[0].Rows[i]["Model_cd"].ToString();
                        list.modelDesc = ds.Tables[0].Rows[i]["Model_desc"].ToString();
                        mainlist.Add(list);
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                //  Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region Sub Model Master
        public BaseListReturnType<SubModelMaster> SubModelList(string p_pmc)
        {
            BaseListReturnType<SubModelMaster> response = new BaseListReturnType<SubModelMaster>();
            List<SubModelMaster> mainlist = new List<SubModelMaster>();
            SubModelMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }


            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_SubModelList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1                
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new SubModelMaster();
                        list.makeCd = ds.Tables[0].Rows[i]["Make_Cd"].ToString();
                        list.modelCd = ds.Tables[0].Rows[i]["Model_cd"].ToString();
                        list.subModelName = ds.Tables[0].Rows[i]["SUBMODELNAME"].ToString();
                        list.subModelNo = ds.Tables[0].Rows[i]["SUBMODELNO"].ToString();
                        list.fuelType = ds.Tables[0].Rows[i]["FUELTYPE_CD"].ToString();
                        mainlist.Add(list);
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                //  Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region Variant Color
        public BaseListReturnType<VariantColorMaster> VariantColorList(string p_pmc, string p_make, string p_model, string p_var)
        {
            BaseListReturnType<VariantColorMaster> response = new BaseListReturnType<VariantColorMaster>();
            List<VariantColorMaster> mainlist = new List<VariantColorMaster>();
            VariantColorMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }

            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_VariantColorList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1 
                cmd.Parameters.Add("P_MAKE", OracleType.VarChar).Value = p_make;
                cmd.Parameters.Add("P_MODEL", OracleType.VarChar).Value = p_model;
                cmd.Parameters.Add("P_VAR", OracleType.VarChar).Value = p_var;
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new VariantColorMaster();
                        list.make = ds.Tables[0].Rows[i]["MAKE"].ToString();
                        list.modelCd = ds.Tables[0].Rows[i]["MODEL_CD"].ToString();
                        list.variantCd = ds.Tables[0].Rows[i]["VARIANT_CD"].ToString();
                        list.eColorCd = ds.Tables[0].Rows[i]["ECOLOR_CD"].ToString();
                        list.eColorDesc = ds.Tables[0].Rows[i]["ECOLOR_DESC"].ToString();
                        mainlist.Add(list);
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }
            return response;
        }
        #endregion

        #region Emission Master
        public BaseListReturnType<EmissionMaster> EmissionList(string p_pmc)
        {
            BaseListReturnType<EmissionMaster> response = new BaseListReturnType<EmissionMaster>();
            List<EmissionMaster> mainlist = new List<EmissionMaster>();
            EmissionMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }


            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_EmissionList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1               
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new EmissionMaster();
                        list.listCode = ds.Tables[0].Rows[i]["List_code"].ToString();
                        list.listDesc = ds.Tables[0].Rows[i]["List_Desc"].ToString();
                        mainlist.Add(list);
                    }
                }

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                //  Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region NTV Reason Master
        public BaseListReturnType<NtvReasonMaster> NtvReasonList(string p_pmc)
        {
            BaseListReturnType<NtvReasonMaster> response = new BaseListReturnType<NtvReasonMaster>();
            List<NtvReasonMaster> mainlist = new List<NtvReasonMaster>();
            NtvReasonMaster list;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            if (string.IsNullOrEmpty(p_pmc))
            {
                p_pmc = "1";
            }

            try
            {
                //list = new NtvReasonMaster();
                //list.listCode = "R101";
                //list.listDesc = "Reason Demo";
                //mainlist.Add(list);
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_NtvReasonList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_pmc", OracleType.Number).Value = Convert.ToInt64(p_pmc); // Default 1               
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["p_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["p_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["p_err_msg"].Value.ToString();
                    response.result = null;
                    return response;
                }
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list = new NtvReasonMaster();
                        list.listCode = ds.Tables[0].Rows[i]["List_code"].ToString();
                        list.listDesc = ds.Tables[0].Rows[i]["List_Desc"].ToString();
                        mainlist.Add(list);
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = mainlist;
            }

            catch (Exception ex)
            {
                //  Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
            }

            return response;
        }
        #endregion

        #region Data Validation
       

        private bool ValidatePushEvalData(PushEvaluation data)
        {

            if (!CheckSpecialChar(data.evaluationId))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.dealerCode))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.MSPIN))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.customerName))
            {
                return false;
            }
            else if (!ValidateEmail(data.customerDetails.customerEmail))//email
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.customerMobile))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.address))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.city))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.pin))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.customerDetails.state))
            {
                return false;
            }

            else if (!CheckSpecialChar(data.vehicleDetails.manufacturer))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.model))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.submodel))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.chassisNo))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.engineNo))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.vinNo))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.yom))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.emission))
            {
                return false;
            }
            else if (!ValidateDate(data.vehicleDetails.dateOfReg))//date
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.color))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.vehicleDetails.vehicleRegNo))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.mileage))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.previousOwner))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.evaluatedRFCost))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.category))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.reasonForNTV))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.evaluationDetails.evaluationRemarks))
            {
                return false;
            }

            else if (!CheckSpecialChar(data.priceDetails.expectedPrice))
            {
                return false;
            }
            else if (!CheckSpecialChar(data.priceDetails.offeredPrice))
            {
                return false;
            }



            return true;
        }

        private bool CheckSpecialChar(string str)
        {
            bool flag = false;
            // var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            try
            {

                if (!string.IsNullOrEmpty(str))
                {
                    str = str.Replace(" ", "");
                    if (str.Any(ch => !Char.IsLetterOrDigit(ch)))
                    {
                        flag = false;
                        return flag;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public bool ValidateEmail(string emailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Match matches = Regex.Match(emailAddress, regexPattern);
            return matches.Success;
        }

        public bool ValidateDate(string dt)
        {
            DateTime DT;
            try
            {
                if (DateTime.TryParse(dt, out DT))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Test service

        public BaseReturnType<string> Test(string name)
        {
            BaseReturnType<string> response = new BaseReturnType<string>();
            //con = new OracleConnection(constr);
            //cmd = new OracleCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "getDBUSERCursor";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("p_username", OracleType.VarChar).Value = name; // Default 1

            //cmd.Parameters.Add("c_dbuser", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

            //con.Open();
            //cmd.ExecuteNonQuery();
            //da = new OracleDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //con.Close();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    response.message = "Success";
            //    response.result = ds.Tables[0].Rows[0]["name"].ToString();

            //}
            response.result = "HI output from new service2";
            return response;
        }

        #endregion

    }


}
