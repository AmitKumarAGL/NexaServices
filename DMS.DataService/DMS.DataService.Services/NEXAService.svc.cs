using System;
using System.Collections.Generic;
using System.Linq;
using NEXA.DataService.ServiceContract;
using System.ServiceModel.Activation;
using NEXA.DataService.DataContract;
using NEXA.DataService.Common.Enum;
using NEXA.DataService.LogHelper;
using NEXA.DataService.DataLayer;
using System.Data;
using System.ServiceModel.Web;
using System.Data.OracleClient;
using System.Configuration;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web.Script.Serialization;

namespace NEXA.DataService.Services
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NEXAService : INEXAService
    {
        string jsonResponce = string.Empty;
        JavaScriptSerializer js = new JavaScriptSerializer();
        String encType = string.Empty;
        string constr = ConfigurationManager.ConnectionStrings["conoracle"].ConnectionString;
        OracleConnection con;
        OracleCommand cmd;
        DataSet ds;
        OracleDataAdapter da;
        DataTable dt;


        //string ConnectAGLServer = ConfigurationManager.ConnectionStrings["ConnectAGLServer"].ConnectionString;
        //System.Data.SqlClient.SqlConnection conAGL;
        //System.Data.SqlClient.SqlCommand cmdAGL;
        //System.Data.SqlClient.SqlDataAdapter daAGL;
        //DataSet dsAGL;


        //string USP_GetDataLocalDealerNotification_AGL = ConfigurationManager.AppSettings["USP_GetDataLocalDealerNotification_AGL"].ToString();

        #region All USP from Web.config
        //string Usp_SaveData = ConfigurationManager.AppSettings["SaveData"].ToString();
        string Usp_BoomBarrier = ConfigurationManager.AppSettings["Usp_BoomBarrier"].ToString();
        string Usp_BoomBarrierSticker = ConfigurationManager.AppSettings["Usp_BoomBarrierSticker"].ToString();
        string Usp_BioMetric = ConfigurationManager.AppSettings["Usp_BioMetric"].ToString();
        string Usp_ValidateLogin = ConfigurationManager.AppSettings["Usp_ValidateLogin"].ToString();
        string Usp_PartMaster = ConfigurationManager.AppSettings["Usp_PartMaster"].ToString();
        string Usp_DealerLocationList = ConfigurationManager.AppSettings["Usp_DealerLocationList"].ToString();
        string Usp_ExtendedWarrantyList = ConfigurationManager.AppSettings["Usp_ExtendedWarrantyList"].ToString();
        string Usp_MRPList = ConfigurationManager.AppSettings["Usp_MRPList"].ToString();
        string Usp_LabourList = ConfigurationManager.AppSettings["Usp_LabourList"].ToString();
        string Usp_PickupTypeList = ConfigurationManager.AppSettings["Usp_PickupTypeList"].ToString();
        string Usp_UnApprovedFitmentsList = ConfigurationManager.AppSettings["Usp_UnApprovedFitmentsList"].ToString();
        string Usp_DemandRepairsList = ConfigurationManager.AppSettings["Usp_DemandRepairsList"].ToString();
        string Usp_ServiceTypeList = ConfigurationManager.AppSettings["Usp_ServiceTypeList"].ToString();
        string Usp_BillableTypeList = ConfigurationManager.AppSettings["Usp_BillableTypeList"].ToString();
        string Usp_ProblemCodeList = ConfigurationManager.AppSettings["Usp_ProblemCodeList"].ToString();
        string Usp_FaultCodeList = ConfigurationManager.AppSettings["Usp_FaultCodeList"].ToString();
        string Usp_ActionCodeList = ConfigurationManager.AppSettings["Usp_ActionCodeList"].ToString();
        string Usp_CSIReasonList = ConfigurationManager.AppSettings["Usp_CSIReasonList"].ToString();
        string Usp_DelayReasonsClosingList = ConfigurationManager.AppSettings["Usp_DelayReasonsClosingList"].ToString();
        string Usp_DelayReasonsBillingList = ConfigurationManager.AppSettings["Usp_DelayReasonsBillingList"].ToString();
        string Usp_PaymentModeList = ConfigurationManager.AppSettings["Usp_PaymentModeList"].ToString();
        string Usp_ReportedByList = ConfigurationManager.AppSettings["Usp_ReportedByList"].ToString();
        string Usp_PickUpLocationList = ConfigurationManager.AppSettings["Usp_PickUpLocationList"].ToString();
        string Usp_MobileServiceMMSList = ConfigurationManager.AppSettings["Usp_MobileServiceMMSList"].ToString();
        string Usp_DriveEmployeeList = ConfigurationManager.AppSettings["Usp_DriveEmployeeList"].ToString();
        string Usp_BayCodeList = ConfigurationManager.AppSettings["Usp_BayCodeList"].ToString();
        string Usp_ServiceAdvisorEmployeeList = ConfigurationManager.AppSettings["Usp_ServiceAdvisorEmployeeList"].ToString();
        string Usp_TechnicalAdvisorEmployeeList = ConfigurationManager.AppSettings["Usp_TechnicalAdvisorEmployeeList"].ToString();
        string Usp_GroupList = ConfigurationManager.AppSettings["Usp_GroupList"].ToString();
        string Usp_TechnicianEmployeeList = ConfigurationManager.AppSettings["Usp_TechnicianEmployeeList"].ToString();
        string Usp_InventoryList = ConfigurationManager.AppSettings["Usp_InventoryList"].ToString();
        string Usp_AuthorizedPersonForDiscountList = ConfigurationManager.AppSettings["Usp_AuthorizedPersonForDiscountList"].ToString();
        string Usp_SplitRatioListOnlyForParts = ConfigurationManager.AppSettings["Usp_SplitRatioListOnlyForParts"].ToString();
        string Usp_ServiceMenuCardList = ConfigurationManager.AppSettings["Usp_ServiceMenuCardList"].ToString();
        string Usp_AppointmentTypeDTLList = ConfigurationManager.AppSettings["Usp_AppointmentTypeDTLList"].ToString();
        string Usp_AppointmentSlotDTLList = ConfigurationManager.AppSettings["Usp_AppointmentSlotDTLList"].ToString();
        string Usp_AppointmentSlotTimeList = ConfigurationManager.AppSettings["Usp_AppointmentSlotTimeList"].ToString();
        string Usp_AppointmentPrePostDTLList = ConfigurationManager.AppSettings["Usp_AppointmentPrePostDTLList"].ToString();
        string Usp_AppointmentCancelReasonList = ConfigurationManager.AppSettings["Usp_AppointmentCancelReasonList"].ToString();
        string Usp_AppointmentVehicleDTLList = ConfigurationManager.AppSettings["Usp_AppointmentVehicleDTLList"].ToString();
        string Usp_AppointmentInsertDTLList = ConfigurationManager.AppSettings["Usp_AppointmentInsertDTLList"].ToString();
        string Usp_AppointmentUpdateDTLList = ConfigurationManager.AppSettings["Usp_AppointmentUpdateDTLList"].ToString();
        string Usp_AppointmentCancelList = ConfigurationManager.AppSettings["Usp_AppointmentCancelList"].ToString();
        string Usp_AppointmentListAccordingToDateRange = ConfigurationManager.AppSettings["Usp_AppointmentListAccordingToDateRange"].ToString();
        string Usp_AppointmentDetails = ConfigurationManager.AppSettings["Usp_AppointmentDetails"].ToString();
        //string Usp_SubServiceTypeDetails = ConfigurationManager.AppSettings["Usp_SubServiceTypeDetails"].ToString();
        string Usp_JobCardOpeningCustomerAndVehicleMaster = ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString();
        string Usp_GenerateJobCard = ConfigurationManager.AppSettings["Usp_GenerateJobCard"].ToString();
        string Usp_SADashboardOnlyForCurrentDate = ConfigurationManager.AppSettings["Usp_SADashboardOnlyForCurrentDate"].ToString();
        string Usp_JobCardListOfVehicle = ConfigurationManager.AppSettings["Usp_JobCardListOfVehicle"].ToString();
        string Usp_JobCardDetailsAccordingToJobCard = ConfigurationManager.AppSettings["Usp_JobCardDetailsAccordingToJobCard"].ToString();
        string Usp_JobCardListForSA = ConfigurationManager.AppSettings["Usp_JobCardListForSA"].ToString();
        string Usp_RejectionReasonsList = ConfigurationManager.AppSettings["Usp_RejectionReasonsList"].ToString();
        string Usp_PartCodeList = ConfigurationManager.AppSettings["Usp_PartCodeList"].ToString();
        string Usp_JobCardListForSA_JCClosePull = ConfigurationManager.AppSettings["Usp_JobCardListForSA_JCClosePull"].ToString();
        string Usp_JobCardClosePush = ConfigurationManager.AppSettings["Usp_JobCardClosePush"].ToString();
        string Usp_MyCalls_GetResponse = ConfigurationManager.AppSettings["Usp_MyCalls_GetResponse"].ToString();
        string Usp_MyCalls_GetRating = ConfigurationManager.AppSettings["Usp_MyCalls_GetRating"].ToString();
        string Usp_MyCalls_GetFollowStatus = ConfigurationManager.AppSettings["Usp_MyCalls_GetFollowStatus"].ToString();
        string Usp_MyCalls_GetPSFDissatisfiedReason = ConfigurationManager.AppSettings["Usp_MyCalls_GetPSFDissatisfiedReason"].ToString();
        string Usp_MyCalls_GetSrvMod = ConfigurationManager.AppSettings["Usp_MyCalls_GetSrvMod"].ToString();
        string Usp_MyCalls_GetScript = ConfigurationManager.AppSettings["Usp_MyCalls_GetScript"].ToString();
        string Usp_MyCalls_GetPSFCustHDR = ConfigurationManager.AppSettings["Usp_MyCalls_GetPSFCustHDR"].ToString();
        string Usp_MyCalls_GetSMRWelcomeCustHDR = ConfigurationManager.AppSettings["Usp_MyCalls_GetSMRWelcomeCustHDR"].ToString();
        string Usp_MyCalls_GetSrvCustomerDetail = ConfigurationManager.AppSettings["Usp_MyCalls_GetSrvCustomerDetail"].ToString();
        string Usp_MyCalls_UpdateFollowUpDetail = ConfigurationManager.AppSettings["Usp_MyCalls_UpdateFollowUpDetail"].ToString();
        string Usp_ServiceTypeValidation = ConfigurationManager.AppSettings["Usp_ServiceTypeValidation"].ToString();
        string Usp_JobCardUpdate = ConfigurationManager.AppSettings["Usp_JobCardUpdate"].ToString();
        string Usp_JobCardPreInvoicePrint = ConfigurationManager.AppSettings["Usp_JobCardPreInvoicePrint"].ToString();
        string Usp_MonitoringScreenBayDetail = ConfigurationManager.AppSettings["Usp_MonitoringScreenBayDetail"].ToString();
        string Usp_JCClosingBillableType = ConfigurationManager.AppSettings["Usp_JCClosingBillableType"].ToString();
        string Usp_QMMonitoringJobCard = ConfigurationManager.AppSettings["Usp_QMMonitoringJobCard"].ToString();
        string Usp_MonitoringVehicleStuckUpDetail = ConfigurationManager.AppSettings["Usp_MonitoringVehicleStuckUpDetail"].ToString();
        string Usp_WalkinCustomerVehInfo = ConfigurationManager.AppSettings["Usp_WalkinCustomerVehInfo"].ToString();
        string Usp_ValidateBillType = ConfigurationManager.AppSettings["Usp_ValidateBillType"].ToString();
        string Usp_QMMonitoringJobCardStageWiseDetails = ConfigurationManager.AppSettings["Usp_QMMonitoringJobCardStageWiseDetails"].ToString();
        string Usp_VehicleStatusDisplay = ConfigurationManager.AppSettings["Usp_VehicleStatusDisplay"].ToString();
        //string Usp_NexaAlert = ConfigurationManager.AppSettings["Usp_NexaAlert"].ToString();
        string Usp_MyCalls_GetINTCustHDR = ConfigurationManager.AppSettings["Usp_MyCalls_GetINTCustHDR"].ToString();
        string Usp_MyCalls_GetINTCustDetail = ConfigurationManager.AppSettings["Usp_MyCalls_GetINTCustDetail"].ToString();
        string Usp_VTSStageDetails = ConfigurationManager.AppSettings["Usp_VTSStageDetails"].ToString();
        string Usp_ModifyCustomerDetail = ConfigurationManager.AppSettings["Usp_ModifyCustomerDetail"].ToString();
        string Usp_GetRFTagDetail = ConfigurationManager.AppSettings["Usp_GetRFTagDetail"].ToString();
        string Usp_GetRFTagScanTime = ConfigurationManager.AppSettings["Usp_GetRFTagScanTime"].ToString();
        #endregion


        // string Usp_ServiceDetails = ConfigurationManager.AppSettings["Usp_ServiceDetails"].ToString();


        //#region For User Login and others
        //public BaseReturnType<UserDetails> ValidateUser(string pn_userid, string pn_pwd, string pn_date)
        //{
        //    BaseReturnType<UserDetails> response = new BaseReturnType<UserDetails>();
        //    UserDetails list;
        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    try
        //    {
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_ValidateLogin;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("pn_userid", OracleType.VarChar).Value = pn_userid;
        //        cmd.Parameters.Add("pn_pwd", OracleType.VarChar).Value = pn_pwd;
        //        cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

        //        cmd.Parameters.Add("po_pmc", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_parent", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_dealer_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_loc_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_user_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_time_slot", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

        //        //Add Cursor or others parameters if any.
        //        //cmd.Parameters.Add("POC_DETAIL", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        da = new OracleDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            return response;
        //        }
        //        //con.Close();
        //        list = new UserDetails();
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            response.code = (int)ServiceMassageCode.SUCCESS;
        //            response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //            list.po_pmc = Convert.ToInt32(ds.Tables[0].Rows[0]["po_pmc"]).ToString();
        //            list.po_parent = ds.Tables[0].Rows[0]["po_parent"].ToString();
        //            list.po_dealer_cd = Convert.ToInt32(ds.Tables[0].Rows[0]["po_dealer_cd"]).ToString();
        //            list.po_loc_cd = ds.Tables[0].Rows[0]["po_loc_cd"].ToString();
        //            list.po_user_name = ds.Tables[0].Rows[0]["po_user_name"].ToString();
        //            list.po_time_slot = ds.Tables[0].Rows[0]["po_time_slot"].ToString();
        //        }
        //        else
        //        {
        //            response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //            response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //            //list.UserName = "";
        //        }

        //        response.result = list;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging.Error(ex, "PropertiesService:Properties_Listing");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        //#endregion

        #region for UserDetails
        public BaseListReturnType<UserDetails> ValidateUser(string pn_userid, string pn_pwd, string pn_date)
        {
            BaseListReturnType<UserDetails> response = new BaseListReturnType<UserDetails>();

            UserDetails Typedetail = null;
            List<UserDetails> Details;
            //Validate Token
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
                cmd.CommandText = Usp_ValidateLogin;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_userid", OracleType.VarChar).Value = pn_userid;
                cmd.Parameters.Add("pn_pwd", OracleType.VarChar).Value = pn_pwd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_pmc", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_parent", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_dealer_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_loc_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_comp_fa", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_user_code", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_user_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_time_slot", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_emp_desg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mspin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cont_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_emailid", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_leave_dt", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_status", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_state_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_state_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                //da = new OracleDataAdapter(cmd);
                //ds = new DataSet();
                //da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<UserDetails>();



                Typedetail = new UserDetails();

                Typedetail.po_pmc = cmd.Parameters["po_pmc"].Value.ToString();
                Typedetail.po_parent = cmd.Parameters["po_parent"].Value.ToString();
                Typedetail.po_dealer_cd = cmd.Parameters["po_dealer_cd"].Value.ToString();
                Typedetail.po_loc_cd = cmd.Parameters["po_loc_cd"].Value.ToString();

                Typedetail.po_comp_fa = cmd.Parameters["po_comp_fa"].Value.ToString();

                Typedetail.po_user_code = cmd.Parameters["po_user_code"].Value.ToString();

                Typedetail.po_user_name = cmd.Parameters["po_user_name"].Value.ToString();
                Typedetail.po_time_slot = cmd.Parameters["po_time_slot"].Value.ToString();

                Typedetail.po_emp_desg = cmd.Parameters["po_emp_desg"].Value.ToString();
                Typedetail.po_mspin = cmd.Parameters["po_mspin"].Value.ToString();
                Typedetail.po_cont_no = cmd.Parameters["po_cont_no"].Value.ToString();
                Typedetail.po_emailid = cmd.Parameters["po_emailid"].Value.ToString();
                Typedetail.po_leave_dt = cmd.Parameters["po_leave_dt"].Value.ToString();
                Typedetail.po_status = cmd.Parameters["po_status"].Value.ToString();

                Typedetail.po_state_cd = cmd.Parameters["po_state_cd"].Value.ToString();
                Typedetail.po_state_desc = cmd.Parameters["po_state_desc"].Value.ToString();


                Details.Add(Typedetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                #region Commented Old Code
                //if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                //{
                //    var detailTable = ds.Tables[0];
                //    if (detailTable.Rows.Count > 0)
                //    {
                //        foreach (DataRow row in detailTable.Rows)
                //        {
                //            response.code = (int)ServiceMassageCode.SUCCESS;
                //            response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                //            Typedetail = new UserDetails();

                //            //Typedetail.po_pmc = Convert.ToInt32(row["po_pmc"]).ToString();
                //            //Typedetail.po_parent = Convert.ToString(row["po_parent"]);
                //            //Typedetail.po_dealer_cd = Convert.ToInt32(row["po_dealer_cd"]).ToString();
                //            //Typedetail.po_loc_cd = Convert.ToString(row["po_loc_cd"]);
                //            //Typedetail.po_user_name = Convert.ToString(row["po_user_name"]);
                //            //Typedetail.po_time_slot = Convert.ToString(row["po_time_slot"]);

                //            Typedetail.po_pmc = Convert.ToString(row["po_pmc"]);
                //            Typedetail.po_parent = Convert.ToString(row["po_parent"]);
                //            Typedetail.po_dealer_cd = Convert.ToString(row["po_dealer_cd"]);
                //            Typedetail.po_loc_cd = Convert.ToString(row["po_loc_cd"]);
                //            Typedetail.po_user_name = Convert.ToString(row["po_user_name"]);
                //            Typedetail.po_time_slot = Convert.ToString(row["po_time_slot"]);

                //            //Typedetail.po_pmc = "A";
                //            //Typedetail.po_parent = "B";
                //            //Typedetail.po_dealer_cd = "C";
                //            //Typedetail.po_loc_cd = "D";
                //            //Typedetail.po_user_name = "E";
                //            //Typedetail.po_time_slot = "F";

                //            Details.Add(Typedetail);
                //        }
                //    }
                //    else
                //    {
                //        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                //        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                //    }
                //}
                //else
                //{
                //    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                //    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                //}


                //response.code = (int)ServiceMassageCode.SUCCESS;
                //response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                #endregion

                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ValidateUser");

                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region For Boom Barrier Open
        public BaseListReturnType<BoomBarrierDetails> GetBoomDetails(string pn_dealer_cd, string pn_loc_Cd, string pn_date)
        {
            BaseListReturnType<BoomBarrierDetails> response = new BaseListReturnType<BoomBarrierDetails>();

            BoomBarrierDetails boombarrierdetail = null;
            List<BoomBarrierDetails> barrierDetails;
            //Validate Token
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
                cmd.CommandText = Usp_BoomBarrier;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;
                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                barrierDetails = new List<BoomBarrierDetails>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            boombarrierdetail = new BoomBarrierDetails();
                            boombarrierdetail.rfid_number = Convert.ToString(row["rfid_number"]);
                            boombarrierdetail.registration_number = Convert.ToString(row["registration_number"]);
                            boombarrierdetail.appoinment_number = Convert.ToString(row["appoinment_number"]);
                            boombarrierdetail.appoinment_status = Convert.ToString(row["appoinment_status"]);
                            //boombarrierdetail.time_slotrfid_number = Convert.ToString(row["time_slotrfid_number"]);
                            boombarrierdetail.time_slot = Convert.ToString(row["time_slot"]);

                            boombarrierdetail.sa_code = Convert.ToString(row["sa_code"]);
                            boombarrierdetail.sa_name = Convert.ToString(row["sa_name"]);

                            barrierDetails.Add(boombarrierdetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = barrierDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_GetBoomDetails");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region For Boom Barrier Open for without STICKER

        public BaseListReturnType<BoomBarrierDetails> GetBoomSearchDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_Cd, string pn_date)
        {

            BaseListReturnType<BoomBarrierDetails> response = new BaseListReturnType<BoomBarrierDetails>();

            BoomBarrierDetails boombarrierdetail = null;
            List<BoomBarrierDetails> barrierDetails;
            //Validate Token
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
                cmd.CommandText = Usp_BoomBarrierSticker;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;

                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;
                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                barrierDetails = new List<BoomBarrierDetails>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            boombarrierdetail = new BoomBarrierDetails();
                            boombarrierdetail.rfid_number = Convert.ToString(row["rfid_number"]);
                            boombarrierdetail.registration_number = Convert.ToString(row["registration_number"]);
                            boombarrierdetail.appoinment_number = Convert.ToString(row["appoinment_number"]);
                            boombarrierdetail.appoinment_status = Convert.ToString(row["appoinment_status"]);
                            //boombarrierdetail.time_slotrfid_number = Convert.ToString(row["time_slotrfid_number"]);
                            boombarrierdetail.time_slot = Convert.ToString(row["time_slot"]);
                            boombarrierdetail.model_cd = Convert.ToString(row["model_cd"]);
                            boombarrierdetail.model_desc = Convert.ToString(row["model_desc"]);

                            barrierDetails.Add(boombarrierdetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = barrierDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_GetBoomSearchDetails");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }


        #endregion

        #region For BioMetric 
        public BaseListReturnType<BioMetric> GetBioMetricDetails(string pn_dealer_cd, string pn_loc_Cd, string pn_date)
        {
            BaseListReturnType<BioMetric> response = new BaseListReturnType<BioMetric>();
            BioMetric biometric = null;
            List<BioMetric> biometriclist = new List<BioMetric>();
            //Validate Token
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
                cmd.CommandText = Usp_BioMetric;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Float).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_attnd_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Float).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
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


                var biometricTable = ds.Tables[0];
                if (biometricTable.Rows.Count > 0)
                {
                    foreach (DataRow row in biometricTable.Rows)
                    {
                        biometric = new BioMetric();
                        biometric.employee_name = Convert.ToString(row["employee_name"]);
                        biometric.employee_code = Convert.ToString(row["employee_code"]);
                        biometric.mspin = Convert.ToString(row["mspin"]);
                        biometric.desg_code = Convert.ToString(row["desg_code"]);
                        biometric.desg_desc = Convert.ToString(row["desg_desc"]);
                        biometric.punch_time = Convert.ToString(row["punch_time"]);
                        biometric.shift_slot = Convert.ToString(row["shift_slot"]);

                        biometric.MOBILE = Convert.ToString(row["MOBILE"]);
                        biometric.EMAIL_ID = Convert.ToString(row["EMAIL_ID"]);

                        biometriclist.Add(biometric);

                    }

                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = biometriclist;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_GetBioMetricDetails");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        //#region ServiceType MASTER
        //public BaseListReturnType<ServiceTypes> ServiceTypeMaster()
        //{
        //    BaseListReturnType<ServiceTypes> response = new BaseListReturnType<ServiceTypes>();
        //    List<ServiceTypes> mainlist = new List<ServiceTypes>();
        //    ServiceTypes list;

        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    try
        //    {
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_PartMaster;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        /*  cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //          cmd.Parameters.Add("p_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //          cmd.Parameters.Add("p_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output; */
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        da = new OracleDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        con.Close();
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                list = new ServiceTypes();
        //                list.po_Code = ds.Tables[0].Rows[i]["po_Code"].ToString();
        //                list.po_ServiceTypeDesc = ds.Tables[0].Rows[i]["po_ServiceTypeDesc"].ToString();
        //                mainlist.Add(list);
        //            }
        //        }
        //        response.code = (int)ServiceMassageCode.SUCCESS;
        //        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //        response.result = mainlist;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging.Error(ex, "PropertiesService:Properties_Listing");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        //#endregion

        #region for part master
        public BaseListReturnType<PartList> GetPartDetails(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_part_num)
        {

            BaseListReturnType<PartList> response = new BaseListReturnType<PartList>();

            PartList PartTypedetail = null;
            List<PartList> PartDetails;
            //Validate Token
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
                cmd.CommandText = Usp_PartMaster;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_part_num", OracleType.VarChar).Value = pn_part_num;
                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                PartDetails = new List<PartList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            PartTypedetail = new PartList();
                            PartTypedetail.part_num = Convert.ToString(row["part_num"]);
                            PartTypedetail.part_desc = Convert.ToString(row["part_desc"]);
                            PartTypedetail.mrp = Convert.ToString(row["mrp"]);
                            PartTypedetail.stock = Convert.ToString(row["stock"]);

                            PartDetails.Add(PartTypedetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = PartDetails;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_GetPartDetails");
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DealerLocationList
        public BaseListReturnType<DealerLocationList> DealerLocationList(string pn_pmc)
        {

            BaseListReturnType<DealerLocationList> response = new BaseListReturnType<DealerLocationList>();

            DealerLocationList DealerLocationTypedetail = null;
            List<DealerLocationList> DealerLocationDetails;
            //Validate Token
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
                cmd.CommandText = Usp_DealerLocationList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_dealer_loc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                DealerLocationDetails = new List<DealerLocationList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            DealerLocationTypedetail = new DealerLocationList();
                            DealerLocationTypedetail.parent_group = Convert.ToString(row["parent_group"]);
                            DealerLocationTypedetail.dealer_map_cd = Convert.ToString(row["dealer_map_cd"]);
                            DealerLocationTypedetail.loc_cd = Convert.ToString(row["loc_cd"]);
                            DealerLocationTypedetail.comp_fa = Convert.ToString(row["comp_fa"]);

                            DealerLocationTypedetail.dealer_name = Convert.ToString(row["dealer_name"]);
                            DealerLocationTypedetail.loc_desc = Convert.ToString(row["loc_desc"]);

                            DealerLocationDetails.Add(DealerLocationTypedetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = DealerLocationDetails;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_DealerLocationList");

                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for Extended Warranty List
        public BaseListReturnType<ExtendedWarrantyList> ExtendedWarrantyList(string pn_pmc, string pn_vin)
        {

            BaseListReturnType<ExtendedWarrantyList> response = new BaseListReturnType<ExtendedWarrantyList>();

            ExtendedWarrantyList ExtendedWarrantyListTypedetail = null;
            List<ExtendedWarrantyList> ExtendedWarrantyListTypedetailDetails;
            //Validate Token
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
                cmd.CommandText = Usp_ExtendedWarrantyList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);
                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;

                cmd.Parameters.Add("po_ewar_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                ExtendedWarrantyListTypedetailDetails = new List<ExtendedWarrantyList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            ExtendedWarrantyListTypedetail = new ExtendedWarrantyList();
                            ExtendedWarrantyListTypedetail.ew_type = Convert.ToString(row["ew_type"]);
                            ExtendedWarrantyListTypedetail.ew_type_desc = Convert.ToString(row["ew_type_desc"]);
                            ExtendedWarrantyListTypedetail.ewr_price = Convert.ToString(row["ewr_price"]);
                            ExtendedWarrantyListTypedetail.ewr_expiry_date = Convert.ToString(row["ewr_expiry_date"]);

                            ExtendedWarrantyListTypedetail.ewr_expiry_mileage = Convert.ToString(row["ewr_expiry_mileage"]);


                            ExtendedWarrantyListTypedetailDetails.Add(ExtendedWarrantyListTypedetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = ExtendedWarrantyListTypedetailDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ExtendedWarrantyList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MCP List 
        public BaseListReturnType<MCPList> MCPList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_omr)
        {

            BaseListReturnType<MCPList> response = new BaseListReturnType<MCPList>();

            MCPList MCPListTypedetail = null;
            List<MCPList> MCPListTypedetailDetails;
            //Validate Token
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
                cmd.CommandText = Usp_MRPList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_omr", OracleType.Number).Value = Convert.ToInt32(pn_omr);


                cmd.Parameters.Add("po_mcp_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                MCPListTypedetailDetails = new List<MCPList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            MCPListTypedetail = new MCPList();
                            MCPListTypedetail.pkg_code = Convert.ToString(row["pkg_code"]);
                            MCPListTypedetail.pkg_desc = Convert.ToString(row["pkg_desc"]);
                            MCPListTypedetail.mcp_start_date = Convert.ToString(row["mcp_start_date"]);
                            MCPListTypedetail.mcp_expiry_date = Convert.ToString(row["mcp_expiry_date"]);
                            MCPListTypedetail.price = Convert.ToString(row["price"]);




                            MCPListTypedetailDetails.Add(MCPListTypedetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = MCPListTypedetailDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MCPList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for Labour Master List 
        public BaseListReturnType<LabourMasterList> LabourMasterList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_srv_cat_cd)
        {

            BaseListReturnType<LabourMasterList> response = new BaseListReturnType<LabourMasterList>();

            LabourMasterList LabourMasterListTypedetail = null;
            List<LabourMasterList> LabourMasterListTypedetailDetails;
            //Validate Token
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
                cmd.CommandText = Usp_LabourList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_srv_cat_cd", OracleType.VarChar).Value = pn_srv_cat_cd;


                cmd.Parameters.Add("po_labor_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                LabourMasterListTypedetailDetails = new List<LabourMasterList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {


                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            LabourMasterListTypedetail = new LabourMasterList();
                            LabourMasterListTypedetail.veh_system = Convert.ToString(row["veh_system"]);
                            LabourMasterListTypedetail.veh_sub_system = Convert.ToString(row["veh_sub_system"]);
                            LabourMasterListTypedetail.veh_sys_desc = Convert.ToString(row["veh_sys_desc"]);
                            LabourMasterListTypedetail.veh_sub_sys_desc = Convert.ToString(row["veh_sub_sys_desc"]);
                            LabourMasterListTypedetail.opr_cd = Convert.ToString(row["opr_cd"]);
                            LabourMasterListTypedetail.opr_desc = Convert.ToString(row["opr_desc"]);
                            LabourMasterListTypedetail.frm_hrs = Convert.ToString(row["frm_hrs"]);
                            LabourMasterListTypedetail.fixed_amt = Convert.ToString(row["fixed_amt"]);





                            LabourMasterListTypedetailDetails.Add(LabourMasterListTypedetail);
                        }

                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = LabourMasterListTypedetailDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_LabourMasterList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for PickupTypeList
        public BaseListReturnType<PickupTypeList> PickupTypeList(string pn_pmc)
        {
            BaseListReturnType<PickupTypeList> response = new BaseListReturnType<PickupTypeList>();

            PickupTypeList PickupTypedetail = null;
            List<PickupTypeList> PickupDetails;
            //Validate Token
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
                cmd.CommandText = Usp_PickupTypeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_pickup_type_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                PickupDetails = new List<PickupTypeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            PickupTypedetail = new PickupTypeList();
                            PickupTypedetail.pickup_code = Convert.ToString(row["pickup_code"]);
                            PickupTypedetail.pickup_desc = Convert.ToString(row["pickup_desc"]);

                            PickupDetails.Add(PickupTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = PickupDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_PickupTypeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for UnApprovedFitmentsList
        public BaseListReturnType<UnApprovedFitmentsList> UnApprovedFitmentsList(string pn_pmc)
        {
            BaseListReturnType<UnApprovedFitmentsList> response = new BaseListReturnType<UnApprovedFitmentsList>();

            UnApprovedFitmentsList UnApprovedFitmentsListTypedetail = null;
            List<UnApprovedFitmentsList> UnApprovedFitmentsListDetails;
            //Validate Token
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
                cmd.CommandText = Usp_UnApprovedFitmentsList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_unapprv_fitment_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                UnApprovedFitmentsListDetails = new List<UnApprovedFitmentsList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            UnApprovedFitmentsListTypedetail = new UnApprovedFitmentsList();
                            UnApprovedFitmentsListTypedetail.apprv_fit_code = Convert.ToString(row["apprv_fit_code"]);
                            UnApprovedFitmentsListTypedetail.apprv_fit_desc = Convert.ToString(row["apprv_fit_desc"]);

                            UnApprovedFitmentsListDetails.Add(UnApprovedFitmentsListTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = UnApprovedFitmentsListDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_UnApprovedFitmentsList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DemandRepairsList
        public BaseListReturnType<DemandRepairsList> DemandRepairsList(string pn_pmc, string pn_reg_num)
        {
            BaseListReturnType<DemandRepairsList> response = new BaseListReturnType<DemandRepairsList>();

            DemandRepairsList DemandRepairsTypedetail = null;
            List<DemandRepairsList> DemandRepairsDetails;
            //Validate Token
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
                cmd.CommandText = Usp_DemandRepairsList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;

                cmd.Parameters.Add("po_demand_cd_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                DemandRepairsDetails = new List<DemandRepairsList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            DemandRepairsTypedetail = new DemandRepairsList();
                            DemandRepairsTypedetail.demand_cd = Convert.ToString(row["demand_cd"]);
                            DemandRepairsTypedetail.demand_desc = Convert.ToString(row["demand_desc"]);
                            DemandRepairsTypedetail.service_type = Convert.ToString(row["service_type"]);
                            DemandRepairsTypedetail.pop_yn = Convert.ToString(row["pop_yn"]);

                            DemandRepairsDetails.Add(DemandRepairsTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = DemandRepairsDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_DemandRepairsList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ServiceTypeList
        public BaseListReturnType<ServiceTypeList> ServiceTypeList(string pn_pmc)
        {
            BaseListReturnType<ServiceTypeList> response = new BaseListReturnType<ServiceTypeList>();

            ServiceTypeList ServiceTypedetail = null;
            List<ServiceTypeList> ServiceDetails;
            //Validate Token
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
                cmd.CommandText = Usp_ServiceTypeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_srv_type_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                ServiceDetails = new List<ServiceTypeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            ServiceTypedetail = new ServiceTypeList();
                            ServiceTypedetail.srv_type = Convert.ToString(row["srv_type"]);
                            ServiceTypedetail.srv_type_desc = Convert.ToString(row["srv_type_desc"]);

                            ServiceDetails.Add(ServiceTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = ServiceDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ServiceTypeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for BillableTypeList
        public BaseListReturnType<BillableTypeList> BillableTypeList(string pn_pmc)
        {
            BaseListReturnType<BillableTypeList> response = new BaseListReturnType<BillableTypeList>();

            BillableTypeList BillableTypedetail = null;
            List<BillableTypeList> BillableDetails;
            //Validate Token
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
                cmd.CommandText = Usp_BillableTypeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_billable_type", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                BillableDetails = new List<BillableTypeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            BillableTypedetail = new BillableTypeList();
                            BillableTypedetail.bill_type = Convert.ToString(row["bill_type"]);
                            BillableTypedetail.bill_type_desc = Convert.ToString(row["bill_type_desc"]);

                            BillableDetails.Add(BillableTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = BillableDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_BillableTypeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ProblemCodeList
        public BaseListReturnType<ProblemCodeList> ProblemCodeList(string pn_pmc)
        {
            BaseListReturnType<ProblemCodeList> response = new BaseListReturnType<ProblemCodeList>();

            ProblemCodeList ProblemCodeTypedetail = null;
            List<ProblemCodeList> ProblemCodeDetails;
            //Validate Token
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
                cmd.CommandText = Usp_ProblemCodeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_problem_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                ProblemCodeDetails = new List<ProblemCodeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            ProblemCodeTypedetail = new ProblemCodeList();
                            ProblemCodeTypedetail.problem_cd = Convert.ToString(row["problem_cd"]);
                            ProblemCodeTypedetail.problem_desc = Convert.ToString(row["problem_desc"]);

                            ProblemCodeDetails.Add(ProblemCodeTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = ProblemCodeDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ProblemCodeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for FaultCodeList
        public BaseListReturnType<FaultCodeList> FaultCodeList(string pn_pmc)
        {
            BaseListReturnType<FaultCodeList> response = new BaseListReturnType<FaultCodeList>();

            FaultCodeList FaultCodeTypedetail = null;
            List<FaultCodeList> FaultCodeDetails;
            //Validate Token
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
                cmd.CommandText = Usp_FaultCodeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_fault_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                FaultCodeDetails = new List<FaultCodeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            FaultCodeTypedetail = new FaultCodeList();
                            FaultCodeTypedetail.problem_cd = Convert.ToString(row["problem_cd"]);
                            FaultCodeTypedetail.fault_cd = Convert.ToString(row["fault_cd"]);
                            FaultCodeTypedetail.fault_desc = Convert.ToString(row["fault_desc"]);

                            FaultCodeDetails.Add(FaultCodeTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = FaultCodeDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_FaultCodeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ActionCodeList
        public BaseListReturnType<ActionCodeList> ActionCodeList(string pn_pmc)
        {
            BaseListReturnType<ActionCodeList> response = new BaseListReturnType<ActionCodeList>();

            ActionCodeList ActionCodeTypedetail = null;
            List<ActionCodeList> ActionCodeDetails;
            //Validate Token
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
                cmd.CommandText = Usp_ActionCodeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_action_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                ActionCodeDetails = new List<ActionCodeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            ActionCodeTypedetail = new ActionCodeList();
                            ActionCodeTypedetail.problem_cd = Convert.ToString(row["problem_cd"]);
                            ActionCodeTypedetail.fault_cd = Convert.ToString(row["fault_cd"]);
                            ActionCodeTypedetail.action_cd = Convert.ToString(row["action_cd"]);
                            ActionCodeTypedetail.action_desc = Convert.ToString(row["action_desc"]);

                            ActionCodeDetails.Add(ActionCodeTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = ActionCodeDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ActionCodeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for CSIReasonList
        public BaseListReturnType<CSIReasonList> CSIReasonList(string pn_pmc)
        {
            BaseListReturnType<CSIReasonList> response = new BaseListReturnType<CSIReasonList>();

            CSIReasonList CSIReasonTypedetail = null;
            List<CSIReasonList> CSIReasonDetails;
            //Validate Token
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
                cmd.CommandText = Usp_CSIReasonList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_csi_reas_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                CSIReasonDetails = new List<CSIReasonList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            CSIReasonTypedetail = new CSIReasonList();
                            CSIReasonTypedetail.csi_cd = Convert.ToString(row["csi_cd"]);
                            CSIReasonTypedetail.csi_desc = Convert.ToString(row["csi_desc"]);

                            CSIReasonDetails.Add(CSIReasonTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = CSIReasonDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_CSIReasonList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DelayReasonsClosingList
        public BaseListReturnType<DelayReasonsClosingList> DelayReasonsClosingList(string pn_pmc)
        {
            BaseListReturnType<DelayReasonsClosingList> response = new BaseListReturnType<DelayReasonsClosingList>();

            DelayReasonsClosingList DelayReasonsClosingTypedetail = null;
            List<DelayReasonsClosingList> DelayReasonsClosingDetails;
            //Validate Token
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
                cmd.CommandText = Usp_DelayReasonsClosingList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_closing_delay_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                DelayReasonsClosingDetails = new List<DelayReasonsClosingList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            DelayReasonsClosingTypedetail = new DelayReasonsClosingList();
                            DelayReasonsClosingTypedetail.delay_cd = Convert.ToString(row["delay_cd"]);
                            DelayReasonsClosingTypedetail.delay_desc = Convert.ToString(row["delay_desc"]);

                            DelayReasonsClosingDetails.Add(DelayReasonsClosingTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = DelayReasonsClosingDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_DelayReasonsClosingList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DelayReasonsBillingList
        public BaseListReturnType<DelayReasonsBillingList> DelayReasonsBillingList(string pn_pmc)
        {
            BaseListReturnType<DelayReasonsBillingList> response = new BaseListReturnType<DelayReasonsBillingList>();

            DelayReasonsBillingList DelayReasonsBillingTypedetail = null;
            List<DelayReasonsBillingList> DelayReasonsBillingDetails;
            //Validate Token
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
                cmd.CommandText = Usp_DelayReasonsBillingList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_billing_delay_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                DelayReasonsBillingDetails = new List<DelayReasonsBillingList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            DelayReasonsBillingTypedetail = new DelayReasonsBillingList();
                            DelayReasonsBillingTypedetail.delay_cd = Convert.ToString(row["delay_cd"]);
                            DelayReasonsBillingTypedetail.delay_desc = Convert.ToString(row["delay_desc"]);

                            DelayReasonsBillingDetails.Add(DelayReasonsBillingTypedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = DelayReasonsBillingDetails;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_DelayReasonsBillingList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for PaymentModeList
        public BaseListReturnType<PaymentModeList> PaymentModeList(string pn_pmc)
        {
            BaseListReturnType<PaymentModeList> response = new BaseListReturnType<PaymentModeList>();

            PaymentModeList Typedetail = null;
            List<PaymentModeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_PaymentModeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_payment_mode_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<PaymentModeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new PaymentModeList();
                            Typedetail.pay_mode_cd = Convert.ToString(row["pay_mode_cd"]);
                            Typedetail.pay_mode_desc = Convert.ToString(row["pay_mode_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_PaymentModeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ReportedByList
        public BaseListReturnType<ReportedByList> ReportedByList(string pn_pmc)
        {
            BaseListReturnType<ReportedByList> response = new BaseListReturnType<ReportedByList>();

            ReportedByList Typedetail = null;
            List<ReportedByList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_ReportedByList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_reported_by_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<ReportedByList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new ReportedByList();
                            Typedetail.rep_by_cd = Convert.ToString(row["rep_by_cd"]);
                            Typedetail.rep_by_desc = Convert.ToString(row["rep_by_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ReportedByList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for PickUpLocationList
        public BaseListReturnType<PickUpLocationList> PickUpLocationList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<PickUpLocationList> response = new BaseListReturnType<PickUpLocationList>();

            PickUpLocationList Typedetail = null;
            List<PickUpLocationList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_PickUpLocationList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_pickup_loc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<PickUpLocationList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new PickUpLocationList();
                            Typedetail.area_cd = Convert.ToString(row["area_cd"]);
                            Typedetail.area_desc = Convert.ToString(row["area_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_PickUpLocationList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MobileServiceMMSList
        public BaseListReturnType<MobileServiceMMSList> MobileServiceMMSList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<MobileServiceMMSList> response = new BaseListReturnType<MobileServiceMMSList>();

            MobileServiceMMSList Typedetail = null;
            List<MobileServiceMMSList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MobileServiceMMSList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_mobile_srv_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MobileServiceMMSList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MobileServiceMMSList();
                            Typedetail.mms_num = Convert.ToString(row["mms_num"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MobileServiceMMSList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DriveEmployeeList
        public BaseListReturnType<DriveEmployeeList> DriveEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<DriveEmployeeList> response = new BaseListReturnType<DriveEmployeeList>();

            DriveEmployeeList Typedetail = null;
            List<DriveEmployeeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_DriveEmployeeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_driver_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<DriveEmployeeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new DriveEmployeeList();
                            Typedetail.emp_cd = Convert.ToString(row["emp_cd"]);
                            Typedetail.emp_name = Convert.ToString(row["emp_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_DriveEmployeeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for BayCodeList
        public BaseListReturnType<BayCodeList> BayCodeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<BayCodeList> response = new BaseListReturnType<BayCodeList>();

            BayCodeList Typedetail = null;
            List<BayCodeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_BayCodeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_bay_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<BayCodeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new BayCodeList();
                            Typedetail.bay_type = Convert.ToString(row["bay_type"]);
                            Typedetail.bay_desc = Convert.ToString(row["bay_desc"]);
                            Typedetail.bay_cd = Convert.ToString(row["bay_cd"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_BayCodeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ServiceAdvisorEmployeeList
        public BaseListReturnType<ServiceAdvisorEmployeeList> ServiceAdvisorEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<ServiceAdvisorEmployeeList> response = new BaseListReturnType<ServiceAdvisorEmployeeList>();

            ServiceAdvisorEmployeeList Typedetail = null;
            List<ServiceAdvisorEmployeeList> Details;
            #region Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_ServiceAdvisorEmployeeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_srv_adv_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<ServiceAdvisorEmployeeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new ServiceAdvisorEmployeeList();
                            Typedetail.emp_cd = Convert.ToString(row["emp_cd"]);
                            Typedetail.emp_name = Convert.ToString(row["emp_name"]);
                            Typedetail.dms_user_id = Convert.ToString(row["dms_user_id"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ServiceAdvisorEmployeeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for TechnicalAdvisorEmployeeList
        public BaseListReturnType<TechnicalAdvisorEmployeeList> TechnicalAdvisorEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<TechnicalAdvisorEmployeeList> response = new BaseListReturnType<TechnicalAdvisorEmployeeList>();

            TechnicalAdvisorEmployeeList Typedetail = null;
            List<TechnicalAdvisorEmployeeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_TechnicalAdvisorEmployeeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_tech_adv_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<TechnicalAdvisorEmployeeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new TechnicalAdvisorEmployeeList();
                            Typedetail.emp_cd = Convert.ToString(row["emp_cd"]);
                            Typedetail.emp_name = Convert.ToString(row["emp_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_TechnicalAdvisorEmployeeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for GroupList
        public BaseListReturnType<GroupList> GroupList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<GroupList> response = new BaseListReturnType<GroupList>();

            GroupList Typedetail = null;
            List<GroupList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_GroupList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_group_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<GroupList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new GroupList();
                            Typedetail.group_cd = Convert.ToString(row["group_cd"]);
                            Typedetail.group_name = Convert.ToString(row["group_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_GroupList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for TechnicianEmployeeList
        public BaseListReturnType<TechnicianEmployeeList> TechnicianEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<TechnicianEmployeeList> response = new BaseListReturnType<TechnicianEmployeeList>();

            TechnicianEmployeeList Typedetail = null;
            List<TechnicianEmployeeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_TechnicianEmployeeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_tech_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<TechnicianEmployeeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new TechnicianEmployeeList();
                            Typedetail.group_cd = Convert.ToString(row["group_cd"]);
                            Typedetail.emp_cd = Convert.ToString(row["emp_cd"]);
                            Typedetail.emp_name = Convert.ToString(row["emp_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_TechnicianEmployeeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for InventoryList
        public BaseListReturnType<InventoryList> InventoryList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<InventoryList> response = new BaseListReturnType<InventoryList>();

            InventoryList Typedetail = null;
            List<InventoryList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_InventoryList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_inv_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<InventoryList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new InventoryList();
                            Typedetail.inventory_cd = Convert.ToString(row["inventory_cd"]);
                            Typedetail.inventory_desc = Convert.ToString(row["inventory_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_InventoryList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AuthorizedPersonForDiscountList
        public BaseListReturnType<AuthorizedPersonForDiscountList> AuthorizedPersonForDiscountList(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<AuthorizedPersonForDiscountList> response = new BaseListReturnType<AuthorizedPersonForDiscountList>();

            AuthorizedPersonForDiscountList Typedetail = null;
            List<AuthorizedPersonForDiscountList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AuthorizedPersonForDiscountList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_dis_auth_by_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AuthorizedPersonForDiscountList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AuthorizedPersonForDiscountList();
                            Typedetail.emp_cd = Convert.ToString(row["emp_cd"]);
                            Typedetail.emp_name = Convert.ToString(row["emp_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AuthorizedPersonForDiscountList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for SplitRatioListOnlyForParts
        public BaseListReturnType<SplitRatioListOnlyForParts> SplitRatioListOnlyForParts(string pn_parent, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<SplitRatioListOnlyForParts> response = new BaseListReturnType<SplitRatioListOnlyForParts>();

            SplitRatioListOnlyForParts Typedetail = null;
            List<SplitRatioListOnlyForParts> Details;
            //Validate Token
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
                cmd.CommandText = Usp_SplitRatioListOnlyForParts;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("po_split_ratio_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<SplitRatioListOnlyForParts>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new SplitRatioListOnlyForParts();
                            Typedetail.split_cd = Convert.ToString(row["split_cd"]);
                            Typedetail.split_desc = Convert.ToString(row["split_desc"]);
                            Typedetail.cust_per = Convert.ToString(row["cust_per"]);
                            Typedetail.ins_per = Convert.ToString(row["ins_per"]);
                            Typedetail.dlr_per = Convert.ToString(row["dlr_per"]);
                            Typedetail.oem_per = Convert.ToString(row["oem_per"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_SplitRatioListOnlyForParts");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ServiceMenuCardList
        public BaseListReturnType<ServiceMenuCardList> ServiceMenuCardList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_srv_cat_cd, string pn_omr)
        {
            BaseListReturnType<ServiceMenuCardList> response = new BaseListReturnType<ServiceMenuCardList>();

            ServiceMenuCardList Typedetail = null;
            List<ServiceMenuCardList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_ServiceMenuCardList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_srv_cat_cd", OracleType.VarChar).Value = pn_srv_cat_cd;
                cmd.Parameters.Add("pn_omr", OracleType.Number).Value = Convert.ToInt32(pn_omr);

                cmd.Parameters.Add("po_sub_srv_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sub_srv_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_smcard_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<ServiceMenuCardList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new ServiceMenuCardList();

                            //Typedetail.po_sub_srv_cd = Convert.ToString(row["po_sub_srv_cd"]);
                            //Typedetail.po_sub_srv_desc = Convert.ToString(row["po_sub_srv_desc"]);


                            Typedetail.po_sub_srv_cd = cmd.Parameters["po_sub_srv_cd"].Value.ToString();
                            Typedetail.po_sub_srv_desc = cmd.Parameters["po_sub_srv_desc"].Value.ToString();


                            //Typedetail.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            //Typedetail.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            //Typedetail.srv_cd = Convert.ToString(row["srv_cd"]);
                            //Typedetail.srv_desc = Convert.ToString(row["srv_desc"]);
                            //Typedetail.srv_qty = Convert.ToString(row["srv_qty"]);
                            //Typedetail.grp_cd = Convert.ToString(row["grp_cd"]);
                            //Typedetail.rate = Convert.ToString(row["rate"]);


                            Typedetail.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            Typedetail.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            Typedetail.srv_cd = Convert.ToString(row["grp_cd"]); //This is actually srv_cd
                            Typedetail.srv_desc = Convert.ToString(row["srv_desc"]);
                            Typedetail.srv_qty = Convert.ToString(row["srv_qty"]);
                            Typedetail.grp_cd = Convert.ToString(row["srv_cd"]); //This is actually grp_cd
                            Typedetail.rate = Convert.ToString(row["rate"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_ServiceMenuCardList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentTypeDTLList
        public BaseListReturnType<AppointmentTypeList> AppointmentTypeDTLList(string pn_pmc)
        {
            BaseListReturnType<AppointmentTypeList> response = new BaseListReturnType<AppointmentTypeList>();

            AppointmentTypeList Typedetail = null;
            List<AppointmentTypeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AppointmentTypeDTLList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_appnt_type_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AppointmentTypeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AppointmentTypeList();


                            Typedetail.type_cd = Convert.ToString(row["type_cd"]);
                            Typedetail.type_desc = Convert.ToString(row["type_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentTypeDTLList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentSlotDTLList
        public BaseListReturnType<AppointmentSlotList> AppointmentSlotDTLList(string pn_pmc)
        {
            BaseListReturnType<AppointmentSlotList> response = new BaseListReturnType<AppointmentSlotList>();

            AppointmentSlotList Typedetail = null;
            List<AppointmentSlotList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AppointmentSlotDTLList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_appnt_slot_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AppointmentSlotList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AppointmentSlotList();


                            Typedetail.slot_cd = Convert.ToString(row["slot_cd"]);
                            Typedetail.slot_desc = Convert.ToString(row["slot_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentSlotDTLList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentSlotTimeList
        public BaseListReturnType<AppointmentSlotTimeList> AppointmentSlotTimeList(string pn_pmc)
        {
            BaseListReturnType<AppointmentSlotTimeList> response = new BaseListReturnType<AppointmentSlotTimeList>();

            AppointmentSlotTimeList Typedetail = null;
            List<AppointmentSlotTimeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AppointmentSlotTimeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_appnt_sime_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AppointmentSlotTimeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AppointmentSlotTimeList();


                            Typedetail.slot_cd = Convert.ToString(row["slot_cd"]);
                            Typedetail.time_desc = Convert.ToString(row["time_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppoinmentSlotTimeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentPrePostDTLList
        public BaseListReturnType<AppointmentPrePostPoneList> AppointmentPrePostDTLList(string pn_pmc)
        {
            BaseListReturnType<AppointmentPrePostPoneList> response = new BaseListReturnType<AppointmentPrePostPoneList>();

            AppointmentPrePostPoneList Typedetail = null;
            List<AppointmentPrePostPoneList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AppointmentPrePostDTLList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_pre_postpone_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AppointmentPrePostPoneList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AppointmentPrePostPoneList();


                            Typedetail.list_code = Convert.ToString(row["list_code"]);
                            Typedetail.list_desc = Convert.ToString(row["list_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentPrePostDTLList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentCancelReasonList
        public BaseListReturnType<AppointmentCancelReasonList> AppointmentCancelReasonList(string pn_pmc)
        {
            BaseListReturnType<AppointmentCancelReasonList> response = new BaseListReturnType<AppointmentCancelReasonList>();

            AppointmentCancelReasonList Typedetail = null;
            List<AppointmentCancelReasonList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_AppointmentCancelReasonList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_reason_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<AppointmentCancelReasonList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new AppointmentCancelReasonList();


                            Typedetail.reason_cd = Convert.ToString(row["reason_cd"]);
                            Typedetail.reason_desc = Convert.ToString(row["reason_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentCancelReasonList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentVehicleDTLList
        public BaseListReturnType<AppointmentVehicleDetails> AppointmentVehicleDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_reg_num)
        {
            BaseListReturnType<AppointmentVehicleDetails> response = new BaseListReturnType<AppointmentVehicleDetails>();
            AppointmentVehicleDetails Typedetail = null;
            List<AppointmentVehicleDetails> AppointmentDetails;
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            DateTime DateOfEval;
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
                cmd.CommandText = Usp_AppointmentVehicleDTLList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                //for output params
                cmd.Parameters.Add("po_reg_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_id", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mobile", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_add", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vehiclemodel", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_city", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_state", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_contact_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_email", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_variant", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_color", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_category", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_sa_attnd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                AppointmentDetails = new List<AppointmentVehicleDetails>();
                Typedetail = new AppointmentVehicleDetails();
                Typedetail.po_reg_num = cmd.Parameters["po_reg_num"].Value.ToString();
                Typedetail.po_cust_id = cmd.Parameters["po_cust_id"].Value.ToString();
                Typedetail.po_mobile = cmd.Parameters["po_mobile"].Value.ToString();
                Typedetail.po_cust_name = cmd.Parameters["po_cust_name"].Value.ToString();
                Typedetail.po_cust_add = cmd.Parameters["po_cust_add"].Value.ToString();
                Typedetail.po_vehiclemodel = cmd.Parameters["po_vehiclemodel"].Value.ToString();
                Typedetail.po_city = cmd.Parameters["po_city"].Value.ToString();
                Typedetail.po_state = cmd.Parameters["po_state"].Value.ToString();
                Typedetail.po_cust_contact_num = cmd.Parameters["po_cust_contact_num"].Value.ToString();
                Typedetail.po_email = cmd.Parameters["po_email"].Value.ToString();
                Typedetail.po_vin = cmd.Parameters["po_vin"].Value.ToString();
                Typedetail.po_variant = cmd.Parameters["po_variant"].Value.ToString();
                Typedetail.po_color = cmd.Parameters["po_color"].Value.ToString();
                Typedetail.po_cust_category = cmd.Parameters["po_cust_category"].Value.ToString();
                Typedetail.po_last_sa_attnd = cmd.Parameters["po_last_sa_attnd"].Value.ToString();
                AppointmentDetails.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = AppointmentDetails;

            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_AppointmentVehicleDTLList");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }

        #endregion

        #region for AppointmentInsertDTLList
        public BaseListReturnType<GenerateAppointment> AppointmentInsertDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_reg_num, string pn_odometer, string pn_srvtype_cd, string pn_appnt_type, string pn_appnt_date, string pn_currentsa_cd, string pn_slot_cd, string pn_slottime_cd, string pn_pickuptype, string pn_pickuploc, string pn_pickuptime, string pn_pickupaddr, string pn_droploc, string pn_droptime, string pn_dropaddr, string pn_driver, string pn_vehicleno, string pn_pickupremarks, string pn_remark_non_prev_sa)
        {
            BaseListReturnType<GenerateAppointment> response = new BaseListReturnType<GenerateAppointment>();
            GenerateAppointment Typedetail = null;
            List<GenerateAppointment> AppointmentDetails;
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            DateTime DateOfEval;
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
                cmd.CommandText = Usp_AppointmentInsertDTLList;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_odometer", OracleType.Number).Value = Convert.ToInt32(pn_odometer);
                cmd.Parameters.Add("pn_srvtype_cd", OracleType.VarChar).Value = pn_srvtype_cd;
                cmd.Parameters.Add("pn_appnt_type", OracleType.VarChar).Value = pn_appnt_type;
                cmd.Parameters.Add("pn_appnt_date", OracleType.VarChar).Value = pn_appnt_date;
                cmd.Parameters.Add("pn_currentsa_cd", OracleType.VarChar).Value = pn_currentsa_cd;
                cmd.Parameters.Add("pn_slot_cd", OracleType.VarChar).Value = pn_slot_cd;
                cmd.Parameters.Add("pn_slottime_cd", OracleType.VarChar).Value = pn_slottime_cd;
                cmd.Parameters.Add("pn_pickuptype", OracleType.VarChar).Value = pn_pickuptype;
                cmd.Parameters.Add("pn_pickuploc", OracleType.VarChar).Value = pn_pickuploc;
                cmd.Parameters.Add("pn_pickuptime", OracleType.VarChar).Value = pn_pickuptime;
                cmd.Parameters.Add("pn_pickupaddr", OracleType.VarChar).Value = pn_pickupaddr;
                cmd.Parameters.Add("pn_droploc", OracleType.VarChar).Value = pn_droploc;
                cmd.Parameters.Add("pn_droptime", OracleType.VarChar).Value = pn_droptime;
                cmd.Parameters.Add("pn_dropaddr", OracleType.VarChar).Value = pn_dropaddr;
                cmd.Parameters.Add("pn_driver", OracleType.VarChar).Value = pn_driver;
                cmd.Parameters.Add("pn_vehicleno", OracleType.VarChar).Value = pn_vehicleno;
                cmd.Parameters.Add("pn_pickupremarks", OracleType.VarChar).Value = pn_pickupremarks;
                cmd.Parameters.Add("pn_remark_non_prev_sa", OracleType.VarChar).Value = pn_remark_non_prev_sa;

                //for output params
                cmd.Parameters.Add("po_appnt_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                AppointmentDetails = new List<GenerateAppointment>();
                Typedetail = new GenerateAppointment();
                Typedetail.po_appnt_no = cmd.Parameters["po_appnt_no"].Value.ToString();
                AppointmentDetails.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = AppointmentDetails;

            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_AppointmentInsertDTLList");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }

        #endregion

        #region for AppointmentUpdateDTLList
        public BaseListReturnType<UpdateAppointmentdetailasperAppointmentno> AppointmentUpdateDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_appnt_no, string pn_prepone_type, string pn_prepone_date, string pn_odometer, string pn_srvtype, string pn_current_sa, string pn_appnt_type, string pn_slot, string pn_slot_time, string pn_pickuptype, string pn_pickuploc, string pn_pickuptime, string pn_pickupaddr, string pn_droploc, string pn_droptime, string pn_dropaddr, string pn_driver, string pn_vehicleno, string pn_pickupremarks, string pn_remark_notselect_sa)
        {
            BaseListReturnType<UpdateAppointmentdetailasperAppointmentno> response = new BaseListReturnType<UpdateAppointmentdetailasperAppointmentno>();
            try
            {
                UpdateAppointmentdetailasperAppointmentno result = new UpdateAppointmentdetailasperAppointmentno();
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
                cmd.CommandText = Usp_AppointmentUpdateDTLList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_appnt_no", OracleType.VarChar).Value = pn_appnt_no;
                cmd.Parameters.Add("pn_prepone_type", OracleType.VarChar).Value = pn_prepone_type;
                cmd.Parameters.Add("pn_prepone_date", OracleType.VarChar).Value = pn_prepone_date;
                cmd.Parameters.Add("pn_odometer", OracleType.Number).Value = Convert.ToInt32(pn_odometer);
                cmd.Parameters.Add("pn_srvtype", OracleType.VarChar).Value = pn_srvtype;
                cmd.Parameters.Add("pn_current_sa", OracleType.VarChar).Value = pn_current_sa;
                cmd.Parameters.Add("pn_appnt_type", OracleType.VarChar).Value = pn_appnt_type;
                cmd.Parameters.Add("pn_slot", OracleType.VarChar).Value = pn_slot;
                cmd.Parameters.Add("pn_slot_time", OracleType.VarChar).Value = pn_slot_time;
                cmd.Parameters.Add("pn_pickuptype", OracleType.VarChar).Value = pn_pickuptype;
                cmd.Parameters.Add("pn_pickuploc", OracleType.VarChar).Value = pn_pickuploc;
                cmd.Parameters.Add("pn_pickuptime", OracleType.VarChar).Value = pn_pickuptime;
                cmd.Parameters.Add("pn_pickupaddr", OracleType.VarChar).Value = pn_pickupaddr;
                cmd.Parameters.Add("pn_droploc", OracleType.VarChar).Value = pn_droploc;
                cmd.Parameters.Add("pn_droptime", OracleType.VarChar).Value = pn_droptime;
                cmd.Parameters.Add("pn_dropaddr", OracleType.VarChar).Value = pn_dropaddr;
                cmd.Parameters.Add("pn_driver", OracleType.VarChar).Value = pn_driver;
                cmd.Parameters.Add("pn_vehicleno", OracleType.VarChar).Value = pn_vehicleno;
                cmd.Parameters.Add("pn_pickupremarks", OracleType.VarChar).Value = pn_pickupremarks;
                cmd.Parameters.Add("pn_remark_notselect_sa", OracleType.VarChar).Value = pn_remark_notselect_sa;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //  response.result = result;
            }

            catch (Exception ex)
            {
                // CreateLogFiles Err = new CreateLogFiles();
                // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

                //Logging.Error(ex, "DMS:PushEvaluaton");
                ErrorLog.LogException(ex, "NEXAService_AppointmentUpdateDTLList");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentCancelList
        public BaseListReturnType<AppointmentCancel> AppointmentCancelList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_appnt_no, string pn_cancel_reason)
        {
            BaseListReturnType<AppointmentCancel> response = new BaseListReturnType<AppointmentCancel>();
            try
            {
                AppointmentCancel result = new AppointmentCancel();
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
                cmd.CommandText = Usp_AppointmentCancelList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_appnt_no", OracleType.VarChar).Value = pn_appnt_no;
                cmd.Parameters.Add("pn_cancel_reason", OracleType.VarChar).Value = pn_cancel_reason;
                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                // response.result = result;
            }

            catch (Exception ex)
            {
                // CreateLogFiles Err = new CreateLogFiles();
                // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

                //Logging.Error(ex, "DMS:PushEvaluaton");
                ErrorLog.LogException(ex, "NEXAService_AppointmentCancelList");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                                               // response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentListAccordingToDateRange
        public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRange(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

            List<AppointmentListAccordingToDateRange> MainALLDetailsList;
            AppointmentListAccordingToDateRange listDetail = null;

            List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
            AppointmentDayWiseList listAppointmentDayWiseList1;

            List<WeekList> listWeekList = new List<WeekList>();
            List<WeekListDayName> listWeekListDayName = new List<WeekListDayName>();
            List<WeekListTimeSlot> listWeekListTimeSlot = new List<WeekListTimeSlot>();
            List<WeekListCounts> listWeekListCounts = new List<WeekListCounts>();

            WeekList listWeekList1;
            WeekListDayName listWeekListDayName1;
            WeekListTimeSlot listWeekListTimeSlot1;
            WeekListCounts listWeekListCounts1;


            List<MonthList> listMonthList = new List<MonthList>();
            List<MonthListDayName> listMonthListDayName = new List<MonthListDayName>();
            List<MonthListCounts> listMonthListCounts = new List<MonthListCounts>();

            MonthList listMonthList1;
            MonthListDayName listMonthListDayName1;
            MonthListCounts listMonthListCounts1;

            List<SAList> listSAList = new List<SAList>();
            List<SAListDayName> listSAListDayName = new List<SAListDayName>();
            List<SADetails> listSADetails = new List<SADetails>();

            SAList listSAList1;
            SAListDayName listSAListDayName1;
            SADetails listSADetails1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange();
                        listDetail.dayWiseLists = listAppointmentDayWiseList;

                        #endregion

                        #region Commented Code
                        #region Assign Date, Time and SA Slots
                        DataTable DT_appnt_for_dt = new DataTable();
                        DataTable DT_time_slot = new DataTable();
                        DataTable DT_SA = new DataTable();
                        DataTable DT_SADetails = new DataTable();
                        DataTable DT_SADetails2 = new DataTable();

                        DataTable DT_appnt_for_dt2 = new DataTable();
                        DataTable DT_appnt_for_dt3 = new DataTable();

                        DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        DT_time_slot = ds.Tables[0].DefaultView.ToTable("time_slot", true, "time_slot");

                        DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

                        DT_SADetails.Clear();
                        DT_SADetails.Columns.Add("sa_code");
                        DT_SADetails.Columns.Add("pn_user_id");
                        DT_SADetails.Columns.Add("sa_name");
                        for (int i = 0; i < DT_SA.Rows.Count; i++)
                        {
                            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                            {
                                if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
                                {
                                    DataRow DT_SADetails_row = DT_SADetails.NewRow();

                                    DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
                                    DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
                                    DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

                                    DT_SADetails.Rows.Add(DT_SADetails_row);
                                    break;
                                }
                            }
                        }
                        //DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");

                        DT_appnt_for_dt2.Clear();
                        DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

                        for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
                        {
                            DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
                            DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
                            DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
                        }
                        DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        #endregion

                        #region Counts for Week Wise Details Day Date and Time Slot Wise
                        listWeekList1 = new WeekList();
                        listWeekList = new List<WeekList>();

                        listWeekListDayName1 = new WeekListDayName();
                        listWeekListDayName = new List<WeekListDayName>();

                        listWeekListTimeSlot1 = new WeekListTimeSlot();
                        listWeekListTimeSlot = new List<WeekListTimeSlot>();

                        listWeekListCounts1 = new WeekListCounts();
                        listWeekListCounts = new List<WeekListCounts>();

                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listWeekList1 = new WeekList();

                            listWeekListDayName = new List<WeekListDayName>();
                            listWeekListTimeSlot = new List<WeekListTimeSlot>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                            for (int k = 0; k < DT_time_slot.Rows.Count; k++)
                            {
                                listWeekListDayName1 = new WeekListDayName();
                                listWeekListTimeSlot1 = new WeekListTimeSlot();
                                listWeekListCounts1 = new WeekListCounts();
                                listWeekListCounts = new List<WeekListCounts>();

                                listWeekListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                                string strTimeSlots = string.Empty;
                                strTimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900
                                listWeekListTimeSlot1.TimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900

                                Int32 iAllRecCount = 0;
                                Int32 iReportedCount = 0;
                                Int32 iAppointedCount = 0;
                                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                                {
                                    if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["time_slot"].ToString() == strTimeSlots))
                                    {
                                        iAllRecCount = iAllRecCount + 1;

                                        iAppointedCount = iAppointedCount + 1;

                                        if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                                        {
                                            iReportedCount = iReportedCount + 1;
                                        }
                                    }
                                }

                                listWeekListCounts1.AllRecCount = iAllRecCount.ToString();
                                listWeekListCounts1.AppointedCount = iAppointedCount.ToString();
                                listWeekListCounts1.ReportedCount = iReportedCount.ToString();

                                listWeekListCounts.Add(listWeekListCounts1);

                                listWeekListTimeSlot1.weekWiselistCounts = listWeekListCounts;
                                listWeekListTimeSlot.Add(listWeekListTimeSlot1);
                            }

                            listWeekListDayName1.weekWiselistTimeSlots = listWeekListTimeSlot;
                            listWeekListDayName.Add(listWeekListDayName1);

                            listWeekList1.weekWiselistDayNames = listWeekListDayName;
                            listWeekList.Add(listWeekList1);

                            listDetail.weekWiselists = listWeekList;

                        }
                        //MainALLDetailsList.Add(listDetail);
                        #endregion

                        #region Counts for Month Wise Details Day Date Wise
                        listMonthList1 = new MonthList();
                        listMonthList = new List<MonthList>();

                        listMonthListDayName1 = new MonthListDayName();
                        listMonthListDayName = new List<MonthListDayName>();

                        listMonthListCounts1 = new MonthListCounts();
                        listMonthListCounts = new List<MonthListCounts>();

                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listMonthList1 = new MonthList();

                            listMonthListDayName = new List<MonthListDayName>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                            listMonthListDayName1 = new MonthListDayName();
                            listMonthListCounts1 = new MonthListCounts();
                            listMonthListCounts = new List<MonthListCounts>();

                            listMonthListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                            Int32 iAllRecCount = 0;
                            Int32 iReportedCount = 0;
                            Int32 iAppointedCount = 0;
                            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                            {
                                if (ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames)
                                {
                                    iAllRecCount = iAllRecCount + 1;

                                    iAppointedCount = iAppointedCount + 1;

                                    if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                                    {
                                        iReportedCount = iReportedCount + 1;
                                    }
                                }
                            }

                            listMonthListCounts1.AllRecCount = iAllRecCount.ToString();
                            listMonthListCounts1.AppointedCount = iAppointedCount.ToString();
                            listMonthListCounts1.ReportedCount = iReportedCount.ToString();

                            listMonthListCounts.Add(listMonthListCounts1);

                            listMonthListDayName1.monthWiselistCounts = listMonthListCounts;
                            listMonthListDayName.Add(listMonthListDayName1);

                            listMonthList1.monthWiselistDayNames = listMonthListDayName;
                            listMonthList.Add(listMonthList1);

                            listDetail.monthWiselists = listMonthList;
                        }
                        #endregion

                        #region Counts for SA Wise Details Day Date Wise
                        listSAList1 = new SAList();
                        listSAList = new List<SAList>();

                        listSAListDayName1 = new SAListDayName();
                        listSAListDayName = new List<SAListDayName>();

                        listSADetails1 = new SADetails();
                        listSADetails = new List<SADetails>();


                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listSAList1 = new SAList();

                            listSAListDayName = new List<SAListDayName>();
                            listSADetails = new List<SADetails>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                            for (int k = 0; k < DT_SA.Rows.Count; k++)
                            {
                                listSAListDayName1 = new SAListDayName();
                                listSADetails1 = new SADetails();


                                listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                                string strSADetails = string.Empty;
                                strSADetails = DT_SA.Rows[k][0].ToString();//0018
                                listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

                                //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
                                //if (drSADetails.Length > 0)
                                //{
                                //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
                                //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
                                //}

                                for (int w = 0; w < DT_SADetails.Rows.Count; w++)
                                {
                                    if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
                                    {
                                        listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
                                        listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

                                        break;
                                    }
                                }

                                Int32 iSAAllAppointRecCounts = 0;
                                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                                {
                                    if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
                                    {
                                        iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
                                    }
                                }
                                listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


                                listSADetails.Add(listSADetails1);
                            }

                            listSAListDayName1.saWiseDetails = listSADetails;
                            listSAListDayName.Add(listSAListDayName1);

                            listSAList1.saWiselistDayNames = listSAListDayName;
                            listSAList.Add(listSAList1);

                            listDetail.saWiselists = listSAList;
                        }
                        #endregion
                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRange");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentListAccordingToDateRangeDayWiseList

        #region Commented Code
        //public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeDayWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        //{
        //    BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

        //    List<AppointmentListAccordingToDateRange> MainALLDetailsList;
        //    AppointmentListAccordingToDateRange listDetail = null;

        //    List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
        //    AppointmentDayWiseList listAppointmentDayWiseList1;

        //    //List<WeekList> listWeekList = new List<WeekList>();
        //    //List<WeekListDayName> listWeekListDayName = new List<WeekListDayName>();
        //    //List<WeekListTimeSlot> listWeekListTimeSlot = new List<WeekListTimeSlot>();
        //    //List<WeekListCounts> listWeekListCounts = new List<WeekListCounts>();

        //    //WeekList listWeekList1;
        //    //WeekListDayName listWeekListDayName1;
        //    //WeekListTimeSlot listWeekListTimeSlot1;
        //    //WeekListCounts listWeekListCounts1;


        //    //List<MonthList> listMonthList = new List<MonthList>();
        //    //List<MonthListDayName> listMonthListDayName = new List<MonthListDayName>();
        //    //List<MonthListCounts> listMonthListCounts = new List<MonthListCounts>();

        //    //MonthList listMonthList1;
        //    //MonthListDayName listMonthListDayName1;
        //    //MonthListCounts listMonthListCounts1;

        //    //List<SAList> listSAList = new List<SAList>();
        //    //List<SAListDayName> listSAListDayName = new List<SAListDayName>();
        //    //List<SADetails> listSADetails = new List<SADetails>();

        //    //SAList listSAList1;
        //    //SAListDayName listSAListDayName1;
        //    //SADetails listSADetails1;

        //    #region Token Validating //Validate Token
        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    #endregion
        //    try
        //    {
        //        #region Connection and Bind Data in Dataset
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
        //        cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
        //        cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
        //        cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
        //        cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

        //        cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        da = new OracleDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        #endregion
        //        #region In case of Error
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            cmd.Dispose();
        //            return response;
        //        }
        //        #endregion
        //        // con.Close();

        //        MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            var detailTable = ds.Tables[0];
        //            if (detailTable.Rows.Count > 0)
        //            {
        //                #region Main Day Wise Details
        //                listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
        //                foreach (DataRow row in detailTable.Rows)
        //                {
        //                    listAppointmentDayWiseList1 = new AppointmentDayWiseList();

        //                    listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
        //                    listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
        //                    listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
        //                    listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
        //                    listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
        //                    listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
        //                    listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
        //                    listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
        //                    listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
        //                    listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
        //                    listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
        //                    listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

        //                    listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
        //                }
        //                listDetail = new AppointmentListAccordingToDateRange();
        //                listDetail.dayWiseLists = listAppointmentDayWiseList;

        //                #endregion

        //                #region Commented Code
        //                //#region Assign Date, Time and SA Slots
        //                //DataTable DT_appnt_for_dt = new DataTable();
        //                //DataTable DT_time_slot = new DataTable();
        //                ////DataTable DT_SA = new DataTable();
        //                ////DataTable DT_SADetails = new DataTable();
        //                ////DataTable DT_SADetails2 = new DataTable();

        //                //DataTable DT_appnt_for_dt2 = new DataTable();
        //                //DataTable DT_appnt_for_dt3 = new DataTable();

        //                //DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
        //                //DT_time_slot = ds.Tables[0].DefaultView.ToTable("time_slot", true, "time_slot");

        //                ////DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

        //                ////DT_SADetails.Clear();
        //                ////DT_SADetails.Columns.Add("sa_code");
        //                ////DT_SADetails.Columns.Add("pn_user_id");
        //                ////DT_SADetails.Columns.Add("sa_name");
        //                ////for (int i = 0; i < DT_SA.Rows.Count; i++)
        //                ////{
        //                ////    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        //                ////    {
        //                ////        if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
        //                ////        {
        //                ////            DataRow DT_SADetails_row = DT_SADetails.NewRow();

        //                ////            DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
        //                ////            DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
        //                ////            DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

        //                ////            DT_SADetails.Rows.Add(DT_SADetails_row);
        //                ////            break;
        //                ////        }
        //                ////    }
        //                ////}
        //                //////DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");

        //                //DT_appnt_for_dt2.Clear();
        //                //DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

        //                //for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
        //                //{
        //                //    DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
        //                //    DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
        //                //    DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
        //                //}
        //                //DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
        //                //#endregion

        //                //#region Counts for Week Wise Details Day Date and Time Slot Wise
        //                //listWeekList1 = new WeekList();
        //                //listWeekList = new List<WeekList>();

        //                //listWeekListDayName1 = new WeekListDayName();
        //                //listWeekListDayName = new List<WeekListDayName>();

        //                //listWeekListTimeSlot1 = new WeekListTimeSlot();
        //                //listWeekListTimeSlot = new List<WeekListTimeSlot>();

        //                //listWeekListCounts1 = new WeekListCounts();
        //                //listWeekListCounts = new List<WeekListCounts>();

        //                //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                //{
        //                //    listWeekList1 = new WeekList();

        //                //    listWeekListDayName = new List<WeekListDayName>();
        //                //    listWeekListTimeSlot = new List<WeekListTimeSlot>();

        //                //    string strDayNames = string.Empty;
        //                //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //    for (int k = 0; k < DT_time_slot.Rows.Count; k++)
        //                //    {
        //                //        listWeekListDayName1 = new WeekListDayName();
        //                //        listWeekListTimeSlot1 = new WeekListTimeSlot();
        //                //        listWeekListCounts1 = new WeekListCounts();
        //                //        listWeekListCounts = new List<WeekListCounts>();

        //                //        listWeekListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //        string strTimeSlots = string.Empty;
        //                //        strTimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900
        //                //        listWeekListTimeSlot1.TimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900

        //                //        Int32 iAllRecCount = 0;
        //                //        Int32 iReportedCount = 0;
        //                //        Int32 iAppointedCount = 0;
        //                //        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                //        {
        //                //            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["time_slot"].ToString() == strTimeSlots))
        //                //            {
        //                //                iAllRecCount = iAllRecCount + 1;

        //                //                iAppointedCount = iAppointedCount + 1;

        //                //                if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
        //                //                {
        //                //                    iReportedCount = iReportedCount + 1;
        //                //                }
        //                //            }
        //                //        }

        //                //        listWeekListCounts1.AllRecCount = iAllRecCount.ToString();
        //                //        listWeekListCounts1.AppointedCount = iAppointedCount.ToString();
        //                //        listWeekListCounts1.ReportedCount = iReportedCount.ToString();

        //                //        listWeekListCounts.Add(listWeekListCounts1);

        //                //        listWeekListTimeSlot1.weekWiselistCounts = listWeekListCounts;
        //                //        listWeekListTimeSlot.Add(listWeekListTimeSlot1);
        //                //    }

        //                //    listWeekListDayName1.weekWiselistTimeSlots = listWeekListTimeSlot;
        //                //    listWeekListDayName.Add(listWeekListDayName1);

        //                //    listWeekList1.weekWiselistDayNames = listWeekListDayName;
        //                //    listWeekList.Add(listWeekList1);

        //                //    listDetail.weekWiselists = listWeekList;

        //                //}
        //                ////MainALLDetailsList.Add(listDetail);
        //                //#endregion

        //                //#region Counts for Month Wise Details Day Date Wise
        //                //listMonthList1 = new MonthList();
        //                //listMonthList = new List<MonthList>();

        //                //listMonthListDayName1 = new MonthListDayName();
        //                //listMonthListDayName = new List<MonthListDayName>();

        //                //listMonthListCounts1 = new MonthListCounts();
        //                //listMonthListCounts = new List<MonthListCounts>();

        //                //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                //{
        //                //    listMonthList1 = new MonthList();

        //                //    listMonthListDayName = new List<MonthListDayName>();

        //                //    string strDayNames = string.Empty;
        //                //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


        //                //    listMonthListDayName1 = new MonthListDayName();
        //                //    listMonthListCounts1 = new MonthListCounts();
        //                //    listMonthListCounts = new List<MonthListCounts>();

        //                //    listMonthListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //    Int32 iAllRecCount = 0;
        //                //    Int32 iReportedCount = 0;
        //                //    Int32 iAppointedCount = 0;
        //                //    for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                //    {
        //                //        if (ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames)
        //                //        {
        //                //            iAllRecCount = iAllRecCount + 1;

        //                //            iAppointedCount = iAppointedCount + 1;

        //                //            if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
        //                //            {
        //                //                iReportedCount = iReportedCount + 1;
        //                //            }
        //                //        }
        //                //    }

        //                //    listMonthListCounts1.AllRecCount = iAllRecCount.ToString();
        //                //    listMonthListCounts1.AppointedCount = iAppointedCount.ToString();
        //                //    listMonthListCounts1.ReportedCount = iReportedCount.ToString();

        //                //    listMonthListCounts.Add(listMonthListCounts1);

        //                //    listMonthListDayName1.monthWiselistCounts = listMonthListCounts;
        //                //    listMonthListDayName.Add(listMonthListDayName1);

        //                //    listMonthList1.monthWiselistDayNames = listMonthListDayName;
        //                //    listMonthList.Add(listMonthList1);

        //                //    listDetail.monthWiselists = listMonthList;
        //                //}
        //                //#endregion

        //                //#region Counts for SA Wise Details Day Date Wise
        //                ////listSAList1 = new SAList();
        //                ////listSAList = new List<SAList>();

        //                ////listSAListDayName1 = new SAListDayName();
        //                ////listSAListDayName = new List<SAListDayName>();

        //                ////listSADetails1 = new SADetails();
        //                ////listSADetails = new List<SADetails>();


        //                ////for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                ////{
        //                ////    listSAList1 = new SAList();

        //                ////    listSAListDayName = new List<SAListDayName>();
        //                ////    listSADetails = new List<SADetails>();

        //                ////    string strDayNames = string.Empty;
        //                ////    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


        //                ////    for (int k = 0; k < DT_SA.Rows.Count; k++)
        //                ////    {
        //                ////        listSAListDayName1 = new SAListDayName();
        //                ////        listSADetails1 = new SADetails();


        //                ////        listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                ////        string strSADetails = string.Empty;
        //                ////        strSADetails = DT_SA.Rows[k][0].ToString();//0018
        //                ////        listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

        //                ////        //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
        //                ////        //if (drSADetails.Length > 0)
        //                ////        //{
        //                ////        //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
        //                ////        //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
        //                ////        //}

        //                ////        for (int w = 0; w < DT_SADetails.Rows.Count; w++)
        //                ////        {
        //                ////            if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
        //                ////            {
        //                ////                listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
        //                ////                listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

        //                ////                break;
        //                ////            }
        //                ////        }

        //                ////        Int32 iSAAllAppointRecCounts = 0;
        //                ////        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                ////        {
        //                ////            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
        //                ////            {
        //                ////                iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
        //                ////            }
        //                ////        }
        //                ////        listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


        //                ////        listSADetails.Add(listSADetails1);
        //                ////    }

        //                ////    listSAListDayName1.saWiseDetails = listSADetails;
        //                ////    listSAListDayName.Add(listSAListDayName1);

        //                ////    listSAList1.saWiselistDayNames = listSAListDayName;
        //                ////    listSAList.Add(listSAList1);

        //                ////    listDetail.saWiselists = listSAList;
        //                ////}
        //                //#endregion
        //                #endregion

        //                MainALLDetailsList.Add(listDetail);

        //                response.code = (int)ServiceMassageCode.SUCCESS;
        //                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //            }
        //            else
        //            {
        //                response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //                response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //            }
        //        }
        //        else
        //        {
        //            response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //            response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //        }

        //        response.result = MainALLDetailsList;
        //    }

        //    catch (Exception ex)
        //    {
        //        // Logging.Error(ex, "PropertiesService:Properties_Listing");
        //        ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeDayWiseList");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message;
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        #endregion
        public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeDayWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

            List<AppointmentListAccordingToDateRange> MainALLDetailsList;
            AppointmentListAccordingToDateRange listDetail = null;

            List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
            AppointmentDayWiseList listAppointmentDayWiseList1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange();
                        listDetail.dayWiseLists = listAppointmentDayWiseList;

                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeDayWiseList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentListAccordingToDateRangeDayWiseList_WithMonitoring
        #region Commented Code
        //public BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring> AppointmentListAccordingToDateRangeDayWiseListWithMonitoring(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        //{
        //    BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring> response = new BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring>();

        //    List<AppointmentListAccordingToDateRange_WithMonitoring> MainALLDetailsList;
        //    AppointmentListAccordingToDateRange_WithMonitoring listDetail = null;

        //    List<AppointmentDayWiseList_WithMonitoring> listAppointmentDayWiseList = new List<AppointmentDayWiseList_WithMonitoring>();
        //    AppointmentDayWiseList_WithMonitoring listAppointmentDayWiseList1;

        //    #region Token Validating //Validate Token
        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    #endregion
        //    try
        //    {
        //        #region Connection and Bind Data in Dataset
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
        //        cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
        //        cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
        //        cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
        //        cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

        //        cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        da = new OracleDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        #endregion
        //        #region In case of Error
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            cmd.Dispose();
        //            return response;
        //        }
        //        #endregion
        //        // con.Close();

        //        MainALLDetailsList = new List<AppointmentListAccordingToDateRange_WithMonitoring>();

        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            var detailTable = ds.Tables[0];
        //            if (detailTable.Rows.Count > 0)
        //            {
        //                #region Main Day Wise Details
        //                listAppointmentDayWiseList = new List<AppointmentDayWiseList_WithMonitoring>();
        //                foreach (DataRow row in detailTable.Rows)
        //                {
        //                    listAppointmentDayWiseList1 = new AppointmentDayWiseList_WithMonitoring();

        //                    listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
        //                    listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
        //                    listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
        //                    listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
        //                    listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
        //                    listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
        //                    listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
        //                    listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
        //                    listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
        //                    listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
        //                    listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
        //                    listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

        //                    listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
        //                }
        //                listDetail = new AppointmentListAccordingToDateRange_WithMonitoring();
        //                listDetail.dayWiseLists = listAppointmentDayWiseList;

        //                #endregion

        //                MainALLDetailsList.Add(listDetail);

        //                response.code = (int)ServiceMassageCode.SUCCESS;
        //                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //            }
        //            else
        //            {
        //                response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //                response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //            }
        //        }
        //        else
        //        {
        //            response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //            response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //        }

        //        response.result = MainALLDetailsList;
        //    }

        //    catch (Exception ex)
        //    {
        //        // Logging.Error(ex, "PropertiesService:Properties_Listing");
        //        ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeDayWiseList_WithMonitoring");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message;
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        #endregion
        #region Private Internal Method
        private BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring> AppointmentListAccordingToDateRangeDayWiseList_Internal(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring> response = new BaseListReturnType<AppointmentListAccordingToDateRange_WithMonitoring>();

            List<AppointmentListAccordingToDateRange_WithMonitoring> MainALLDetailsList;
            AppointmentListAccordingToDateRange_WithMonitoring listDetail = null;

            List<AppointmentDayWiseList_WithMonitoring> listAppointmentDayWiseList = new List<AppointmentDayWiseList_WithMonitoring>();
            AppointmentDayWiseList_WithMonitoring listAppointmentDayWiseList1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange_WithMonitoring>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList_WithMonitoring>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList_WithMonitoring();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange_WithMonitoring();
                        listDetail.dayWiseLists = listAppointmentDayWiseList;

                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeDayWiseList_WithMonitoring");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion
        #endregion


        #region for AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification
        //public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        //{
        //    BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

        //    List<AppointmentListAccordingToDateRange> MainALLDetailsList;
        //    AppointmentListAccordingToDateRange listDetail = null;

        //    List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
        //    AppointmentDayWiseList listAppointmentDayWiseList1;

        //    #region Commented Code
        //    //List<WeekList> listWeekList = new List<WeekList>();
        //    //List<WeekListDayName> listWeekListDayName = new List<WeekListDayName>();
        //    //List<WeekListTimeSlot> listWeekListTimeSlot = new List<WeekListTimeSlot>();
        //    //List<WeekListCounts> listWeekListCounts = new List<WeekListCounts>();

        //    //WeekList listWeekList1;
        //    //WeekListDayName listWeekListDayName1;
        //    //WeekListTimeSlot listWeekListTimeSlot1;
        //    //WeekListCounts listWeekListCounts1;


        //    //List<MonthList> listMonthList = new List<MonthList>();
        //    //List<MonthListDayName> listMonthListDayName = new List<MonthListDayName>();
        //    //List<MonthListCounts> listMonthListCounts = new List<MonthListCounts>();

        //    //MonthList listMonthList1;
        //    //MonthListDayName listMonthListDayName1;
        //    //MonthListCounts listMonthListCounts1;

        //    //List<SAList> listSAList = new List<SAList>();
        //    //List<SAListDayName> listSAListDayName = new List<SAListDayName>();
        //    //List<SADetails> listSADetails = new List<SADetails>();

        //    //SAList listSAList1;
        //    //SAListDayName listSAListDayName1;
        //    //SADetails listSADetails1;
        //    #endregion

        //    #region Token Validating //Validate Token
        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    #endregion
        //    try
        //    {
        //        #region Connection and Bind Data in Dataset
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
        //        cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
        //        cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
        //        cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
        //        cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

        //        cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        da = new OracleDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        #endregion

        //        #region In case of Error
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            cmd.Dispose();
        //            return response;
        //        }
        //        #endregion
        //        // con.Close();

        //        #region For AGL Local Data Connection and Bind Data in Dataset
        //        conAGL = new System.Data.SqlClient.SqlConnection(ConnectAGLServer);
        //        cmdAGL = new System.Data.SqlClient.SqlCommand();
        //        cmdAGL.Connection = conAGL;
        //        cmdAGL.CommandText = USP_GetDataLocalDealerNotification_AGL;
        //        cmdAGL.CommandType = CommandType.StoredProcedure;

        //        if (conAGL.State == ConnectionState.Closed)
        //        {
        //            conAGL.Open();
        //        }
        //        cmdAGL.ExecuteNonQuery();
        //        daAGL = new System.Data.SqlClient.SqlDataAdapter(cmdAGL);
        //        dsAGL = new DataSet();
        //        daAGL.Fill(dsAGL);

        //        if (dsAGL != null && dsAGL.Tables != null && dsAGL.Tables.Count > 0)
        //        {
        //            var detailTableAGL = dsAGL.Tables[0];
        //        }
        //        #endregion

        //        MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            var detailTable = ds.Tables[0];
        //            if (detailTable.Rows.Count > 0)
        //            {
        //                #region Main Day Wise Details
        //                listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
        //                foreach (DataRow row in detailTable.Rows)
        //                {
        //                    listAppointmentDayWiseList1 = new AppointmentDayWiseList();

        //                    listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
        //                    listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
        //                    listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
        //                    listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
        //                    listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
        //                    listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
        //                    listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
        //                    listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
        //                    listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
        //                    listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
        //                    listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
        //                    listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

        //                    listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
        //                }
        //                listDetail = new AppointmentListAccordingToDateRange();
        //                listDetail.dayWiseLists = listAppointmentDayWiseList;

        //                #endregion

        //                #region Commented Code
        //                //#region Assign Date, Time and SA Slots
        //                //DataTable DT_appnt_for_dt = new DataTable();
        //                //DataTable DT_time_slot = new DataTable();
        //                ////DataTable DT_SA = new DataTable();
        //                ////DataTable DT_SADetails = new DataTable();
        //                ////DataTable DT_SADetails2 = new DataTable();

        //                //DataTable DT_appnt_for_dt2 = new DataTable();
        //                //DataTable DT_appnt_for_dt3 = new DataTable();

        //                //DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
        //                //DT_time_slot = ds.Tables[0].DefaultView.ToTable("time_slot", true, "time_slot");

        //                ////DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

        //                ////DT_SADetails.Clear();
        //                ////DT_SADetails.Columns.Add("sa_code");
        //                ////DT_SADetails.Columns.Add("pn_user_id");
        //                ////DT_SADetails.Columns.Add("sa_name");
        //                ////for (int i = 0; i < DT_SA.Rows.Count; i++)
        //                ////{
        //                ////    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        //                ////    {
        //                ////        if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
        //                ////        {
        //                ////            DataRow DT_SADetails_row = DT_SADetails.NewRow();

        //                ////            DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
        //                ////            DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
        //                ////            DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

        //                ////            DT_SADetails.Rows.Add(DT_SADetails_row);
        //                ////            break;
        //                ////        }
        //                ////    }
        //                ////}
        //                //////DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");

        //                //DT_appnt_for_dt2.Clear();
        //                //DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

        //                //for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
        //                //{
        //                //    DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
        //                //    DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
        //                //    DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
        //                //}
        //                //DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
        //                //#endregion

        //                //#region Counts for Week Wise Details Day Date and Time Slot Wise
        //                //listWeekList1 = new WeekList();
        //                //listWeekList = new List<WeekList>();

        //                //listWeekListDayName1 = new WeekListDayName();
        //                //listWeekListDayName = new List<WeekListDayName>();

        //                //listWeekListTimeSlot1 = new WeekListTimeSlot();
        //                //listWeekListTimeSlot = new List<WeekListTimeSlot>();

        //                //listWeekListCounts1 = new WeekListCounts();
        //                //listWeekListCounts = new List<WeekListCounts>();

        //                //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                //{
        //                //    listWeekList1 = new WeekList();

        //                //    listWeekListDayName = new List<WeekListDayName>();
        //                //    listWeekListTimeSlot = new List<WeekListTimeSlot>();

        //                //    string strDayNames = string.Empty;
        //                //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //    for (int k = 0; k < DT_time_slot.Rows.Count; k++)
        //                //    {
        //                //        listWeekListDayName1 = new WeekListDayName();
        //                //        listWeekListTimeSlot1 = new WeekListTimeSlot();
        //                //        listWeekListCounts1 = new WeekListCounts();
        //                //        listWeekListCounts = new List<WeekListCounts>();

        //                //        listWeekListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //        string strTimeSlots = string.Empty;
        //                //        strTimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900
        //                //        listWeekListTimeSlot1.TimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900

        //                //        Int32 iAllRecCount = 0;
        //                //        Int32 iReportedCount = 0;
        //                //        Int32 iAppointedCount = 0;
        //                //        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                //        {
        //                //            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["time_slot"].ToString() == strTimeSlots))
        //                //            {
        //                //                iAllRecCount = iAllRecCount + 1;

        //                //                iAppointedCount = iAppointedCount + 1;

        //                //                if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
        //                //                {
        //                //                    iReportedCount = iReportedCount + 1;
        //                //                }
        //                //            }
        //                //        }

        //                //        listWeekListCounts1.AllRecCount = iAllRecCount.ToString();
        //                //        listWeekListCounts1.AppointedCount = iAppointedCount.ToString();
        //                //        listWeekListCounts1.ReportedCount = iReportedCount.ToString();

        //                //        listWeekListCounts.Add(listWeekListCounts1);

        //                //        listWeekListTimeSlot1.weekWiselistCounts = listWeekListCounts;
        //                //        listWeekListTimeSlot.Add(listWeekListTimeSlot1);
        //                //    }

        //                //    listWeekListDayName1.weekWiselistTimeSlots = listWeekListTimeSlot;
        //                //    listWeekListDayName.Add(listWeekListDayName1);

        //                //    listWeekList1.weekWiselistDayNames = listWeekListDayName;
        //                //    listWeekList.Add(listWeekList1);

        //                //    listDetail.weekWiselists = listWeekList;

        //                //}
        //                ////MainALLDetailsList.Add(listDetail);
        //                //#endregion

        //                //#region Counts for Month Wise Details Day Date Wise
        //                //listMonthList1 = new MonthList();
        //                //listMonthList = new List<MonthList>();

        //                //listMonthListDayName1 = new MonthListDayName();
        //                //listMonthListDayName = new List<MonthListDayName>();

        //                //listMonthListCounts1 = new MonthListCounts();
        //                //listMonthListCounts = new List<MonthListCounts>();

        //                //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                //{
        //                //    listMonthList1 = new MonthList();

        //                //    listMonthListDayName = new List<MonthListDayName>();

        //                //    string strDayNames = string.Empty;
        //                //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


        //                //    listMonthListDayName1 = new MonthListDayName();
        //                //    listMonthListCounts1 = new MonthListCounts();
        //                //    listMonthListCounts = new List<MonthListCounts>();

        //                //    listMonthListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                //    Int32 iAllRecCount = 0;
        //                //    Int32 iReportedCount = 0;
        //                //    Int32 iAppointedCount = 0;
        //                //    for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                //    {
        //                //        if (ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames)
        //                //        {
        //                //            iAllRecCount = iAllRecCount + 1;

        //                //            iAppointedCount = iAppointedCount + 1;

        //                //            if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
        //                //            {
        //                //                iReportedCount = iReportedCount + 1;
        //                //            }
        //                //        }
        //                //    }

        //                //    listMonthListCounts1.AllRecCount = iAllRecCount.ToString();
        //                //    listMonthListCounts1.AppointedCount = iAppointedCount.ToString();
        //                //    listMonthListCounts1.ReportedCount = iReportedCount.ToString();

        //                //    listMonthListCounts.Add(listMonthListCounts1);

        //                //    listMonthListDayName1.monthWiselistCounts = listMonthListCounts;
        //                //    listMonthListDayName.Add(listMonthListDayName1);

        //                //    listMonthList1.monthWiselistDayNames = listMonthListDayName;
        //                //    listMonthList.Add(listMonthList1);

        //                //    listDetail.monthWiselists = listMonthList;
        //                //}
        //                //#endregion

        //                //#region Counts for SA Wise Details Day Date Wise
        //                ////listSAList1 = new SAList();
        //                ////listSAList = new List<SAList>();

        //                ////listSAListDayName1 = new SAListDayName();
        //                ////listSAListDayName = new List<SAListDayName>();

        //                ////listSADetails1 = new SADetails();
        //                ////listSADetails = new List<SADetails>();


        //                ////for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
        //                ////{
        //                ////    listSAList1 = new SAList();

        //                ////    listSAListDayName = new List<SAListDayName>();
        //                ////    listSADetails = new List<SADetails>();

        //                ////    string strDayNames = string.Empty;
        //                ////    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


        //                ////    for (int k = 0; k < DT_SA.Rows.Count; k++)
        //                ////    {
        //                ////        listSAListDayName1 = new SAListDayName();
        //                ////        listSADetails1 = new SADetails();


        //                ////        listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

        //                ////        string strSADetails = string.Empty;
        //                ////        strSADetails = DT_SA.Rows[k][0].ToString();//0018
        //                ////        listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

        //                ////        //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
        //                ////        //if (drSADetails.Length > 0)
        //                ////        //{
        //                ////        //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
        //                ////        //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
        //                ////        //}

        //                ////        for (int w = 0; w < DT_SADetails.Rows.Count; w++)
        //                ////        {
        //                ////            if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
        //                ////            {
        //                ////                listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
        //                ////                listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

        //                ////                break;
        //                ////            }
        //                ////        }

        //                ////        Int32 iSAAllAppointRecCounts = 0;
        //                ////        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        //                ////        {
        //                ////            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
        //                ////            {
        //                ////                iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
        //                ////            }
        //                ////        }
        //                ////        listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


        //                ////        listSADetails.Add(listSADetails1);
        //                ////    }

        //                ////    listSAListDayName1.saWiseDetails = listSADetails;
        //                ////    listSAListDayName.Add(listSAListDayName1);

        //                ////    listSAList1.saWiselistDayNames = listSAListDayName;
        //                ////    listSAList.Add(listSAList1);

        //                ////    listDetail.saWiselists = listSAList;
        //                ////}
        //                //#endregion
        //                #endregion

        //                MainALLDetailsList.Add(listDetail);

        //                response.code = (int)ServiceMassageCode.SUCCESS;
        //                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //            }
        //            else
        //            {
        //                response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //                response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //            }
        //        }
        //        else
        //        {
        //            response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
        //            response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
        //        }

        //        response.result = MainALLDetailsList;
        //    }

        //    catch (Exception ex)
        //    {
        //        // Logging.Error(ex, "PropertiesService:Properties_Listing");
        //        ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message;
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        #endregion

        #region for AppointmentListAccordingToDateRangeWeekWiseList
        public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeWeekWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

            List<AppointmentListAccordingToDateRange> MainALLDetailsList;
            AppointmentListAccordingToDateRange listDetail = null;

            List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
            AppointmentDayWiseList listAppointmentDayWiseList1;

            List<WeekList> listWeekList = new List<WeekList>();
            List<WeekListDayName> listWeekListDayName = new List<WeekListDayName>();
            List<WeekListTimeSlot> listWeekListTimeSlot = new List<WeekListTimeSlot>();
            List<WeekListCounts> listWeekListCounts = new List<WeekListCounts>();

            WeekList listWeekList1;
            WeekListDayName listWeekListDayName1;
            WeekListTimeSlot listWeekListTimeSlot1;
            WeekListCounts listWeekListCounts1;


            //List<MonthList> listMonthList = new List<MonthList>();
            //List<MonthListDayName> listMonthListDayName = new List<MonthListDayName>();
            //List<MonthListCounts> listMonthListCounts = new List<MonthListCounts>();

            //MonthList listMonthList1;
            //MonthListDayName listMonthListDayName1;
            //MonthListCounts listMonthListCounts1;

            //List<SAList> listSAList = new List<SAList>();
            //List<SAListDayName> listSAListDayName = new List<SAListDayName>();
            //List<SADetails> listSADetails = new List<SADetails>();

            //SAList listSAList1;
            //SAListDayName listSAListDayName1;
            //SADetails listSADetails1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Not Commented Code
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange();
                        //listDetail.dayWiseLists = listAppointmentDayWiseList;
                        listDetail.dayWiseLists = null;
                        #endregion
                        #endregion

                        #region Assign Date, Time and SA Slots
                        DataTable DT_appnt_for_dt = new DataTable();
                        DataTable DT_time_slot = new DataTable();
                        //DataTable DT_SA = new DataTable();
                        //DataTable DT_SADetails = new DataTable();
                        //DataTable DT_SADetails2 = new DataTable();

                        DataTable DT_appnt_for_dt2 = new DataTable();
                        DataTable DT_appnt_for_dt3 = new DataTable();

                        DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        //DT_time_slot = ds.Tables[0].DefaultView.ToTable("time_slot", true, "time_slot");
                        #region Add Manual Time Slots as per requirement of iOS Team
                        string strTimeSlot = string.Empty;
                        DT_time_slot.Clear();
                        DT_time_slot.Columns.Add("time_slot");
                        for (int z = 1; z <= 5; z++)
                        {
                            if (z == 1)
                            {
                                strTimeSlot = "0700-0900";
                            }
                            else if (z == 2)
                            {
                                strTimeSlot = "0900-1100";
                            }
                            else if (z == 3)
                            {
                                strTimeSlot = "1100-1300";
                            }
                            else if (z == 4)
                            {
                                strTimeSlot = "1300-1600";
                            }
                            else if (z == 5)
                            {
                                strTimeSlot = "1600-1900";
                            }
                            DataRow DT_time_slot_row = DT_time_slot.NewRow();
                            DT_time_slot_row["time_slot"] = strTimeSlot;
                            DT_time_slot.Rows.Add(DT_time_slot_row);
                        }
                        #endregion

                        #region Commented Code
                        //DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

                        //DT_SADetails.Clear();
                        //DT_SADetails.Columns.Add("sa_code");
                        //DT_SADetails.Columns.Add("pn_user_id");
                        //DT_SADetails.Columns.Add("sa_name");
                        //for (int i = 0; i < DT_SA.Rows.Count; i++)
                        //{
                        //    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                        //    {
                        //        if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
                        //        {
                        //            DataRow DT_SADetails_row = DT_SADetails.NewRow();

                        //            DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
                        //            DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
                        //            DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

                        //            DT_SADetails.Rows.Add(DT_SADetails_row);
                        //            break;
                        //        }
                        //    }
                        //}
                        ////DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");
                        #endregion

                        DT_appnt_for_dt2.Clear();
                        DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

                        for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
                        {
                            DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
                            DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
                            DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
                        }
                        DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        #endregion

                        #region Counts for Week Wise Details Day Date and Time Slot Wise
                        listWeekList1 = new WeekList();
                        listWeekList = new List<WeekList>();

                        listWeekListDayName1 = new WeekListDayName();
                        listWeekListDayName = new List<WeekListDayName>();

                        listWeekListTimeSlot1 = new WeekListTimeSlot();
                        listWeekListTimeSlot = new List<WeekListTimeSlot>();

                        listWeekListCounts1 = new WeekListCounts();
                        listWeekListCounts = new List<WeekListCounts>();

                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listWeekList1 = new WeekList();

                            listWeekListDayName = new List<WeekListDayName>();
                            listWeekListTimeSlot = new List<WeekListTimeSlot>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                            for (int k = 0; k < DT_time_slot.Rows.Count; k++)
                            {
                                listWeekListDayName1 = new WeekListDayName();
                                listWeekListTimeSlot1 = new WeekListTimeSlot();
                                listWeekListCounts1 = new WeekListCounts();
                                listWeekListCounts = new List<WeekListCounts>();

                                listWeekListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                                string strTimeSlots = string.Empty;
                                strTimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900
                                listWeekListTimeSlot1.TimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900

                                Int32 iAllRecCount = 0;
                                Int32 iReportedCount = 0;
                                Int32 iAppointedCount = 0;
                                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                                {
                                    if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["time_slot"].ToString() == strTimeSlots))
                                    {
                                        iAllRecCount = iAllRecCount + 1;

                                        iAppointedCount = iAppointedCount + 1;

                                        if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                                        {
                                            iReportedCount = iReportedCount + 1;
                                        }
                                    }
                                }

                                listWeekListCounts1.AllRecCount = iAllRecCount.ToString();
                                listWeekListCounts1.AppointedCount = iAppointedCount.ToString();
                                listWeekListCounts1.ReportedCount = iReportedCount.ToString();

                                listWeekListCounts.Add(listWeekListCounts1);

                                listWeekListTimeSlot1.weekWiselistCounts = listWeekListCounts;
                                listWeekListTimeSlot.Add(listWeekListTimeSlot1);
                            }

                            listWeekListDayName1.weekWiselistTimeSlots = listWeekListTimeSlot;
                            listWeekListDayName.Add(listWeekListDayName1);

                            listWeekList1.weekWiselistDayNames = listWeekListDayName;
                            listWeekList.Add(listWeekList1);

                            listDetail.weekWiselists = listWeekList;

                        }
                        //MainALLDetailsList.Add(listDetail);
                        #endregion

                        #region Commented Code
                        //#region Counts for Month Wise Details Day Date Wise
                        //listMonthList1 = new MonthList();
                        //listMonthList = new List<MonthList>();

                        //listMonthListDayName1 = new MonthListDayName();
                        //listMonthListDayName = new List<MonthListDayName>();

                        //listMonthListCounts1 = new MonthListCounts();
                        //listMonthListCounts = new List<MonthListCounts>();

                        //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        //{
                        //    listMonthList1 = new MonthList();

                        //    listMonthListDayName = new List<MonthListDayName>();

                        //    string strDayNames = string.Empty;
                        //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                        //    listMonthListDayName1 = new MonthListDayName();
                        //    listMonthListCounts1 = new MonthListCounts();
                        //    listMonthListCounts = new List<MonthListCounts>();

                        //    listMonthListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                        //    Int32 iAllRecCount = 0;
                        //    Int32 iReportedCount = 0;
                        //    Int32 iAppointedCount = 0;
                        //    for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                        //    {
                        //        if (ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames)
                        //        {
                        //            iAllRecCount = iAllRecCount + 1;

                        //            iAppointedCount = iAppointedCount + 1;

                        //            if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                        //            {
                        //                iReportedCount = iReportedCount + 1;
                        //            }
                        //        }
                        //    }

                        //    listMonthListCounts1.AllRecCount = iAllRecCount.ToString();
                        //    listMonthListCounts1.AppointedCount = iAppointedCount.ToString();
                        //    listMonthListCounts1.ReportedCount = iReportedCount.ToString();

                        //    listMonthListCounts.Add(listMonthListCounts1);

                        //    listMonthListDayName1.monthWiselistCounts = listMonthListCounts;
                        //    listMonthListDayName.Add(listMonthListDayName1);

                        //    listMonthList1.monthWiselistDayNames = listMonthListDayName;
                        //    listMonthList.Add(listMonthList1);

                        //listDetail.monthWiselists = listMonthList;
                        //}
                        //#endregion

                        //#region Counts for SA Wise Details Day Date Wise
                        ////listSAList1 = new SAList();
                        ////listSAList = new List<SAList>();

                        ////listSAListDayName1 = new SAListDayName();
                        ////listSAListDayName = new List<SAListDayName>();

                        ////listSADetails1 = new SADetails();
                        ////listSADetails = new List<SADetails>();


                        ////for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        ////{
                        ////    listSAList1 = new SAList();

                        ////    listSAListDayName = new List<SAListDayName>();
                        ////    listSADetails = new List<SADetails>();

                        ////    string strDayNames = string.Empty;
                        ////    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                        ////    for (int k = 0; k < DT_SA.Rows.Count; k++)
                        ////    {
                        ////        listSAListDayName1 = new SAListDayName();
                        ////        listSADetails1 = new SADetails();


                        ////        listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                        ////        string strSADetails = string.Empty;
                        ////        strSADetails = DT_SA.Rows[k][0].ToString();//0018
                        ////        listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

                        ////        //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
                        ////        //if (drSADetails.Length > 0)
                        ////        //{
                        ////        //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
                        ////        //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
                        ////        //}

                        ////        for (int w = 0; w < DT_SADetails.Rows.Count; w++)
                        ////        {
                        ////            if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
                        ////            {
                        ////                listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
                        ////                listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

                        ////                break;
                        ////            }
                        ////        }

                        ////        Int32 iSAAllAppointRecCounts = 0;
                        ////        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                        ////        {
                        ////            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
                        ////            {
                        ////                iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
                        ////            }
                        ////        }
                        ////        listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


                        ////        listSADetails.Add(listSADetails1);
                        ////    }

                        ////    listSAListDayName1.saWiseDetails = listSADetails;
                        ////    listSAListDayName.Add(listSAListDayName1);

                        ////    listSAList1.saWiselistDayNames = listSAListDayName;
                        ////    listSAList.Add(listSAList1);

                        //listDetail.saWiselists = listSAList;
                        ////}
                        //#endregion
                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeWeekWiseList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentListAccordingToDateRangeMonthWiseList
        public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeMonthWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

            List<AppointmentListAccordingToDateRange> MainALLDetailsList;
            AppointmentListAccordingToDateRange listDetail = null;

            List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
            AppointmentDayWiseList listAppointmentDayWiseList1;

            //List<WeekList> listWeekList = new List<WeekList>();
            //List<WeekListDayName> listWeekListDayName = new List<WeekListDayName>();
            //List<WeekListTimeSlot> listWeekListTimeSlot = new List<WeekListTimeSlot>();
            //List<WeekListCounts> listWeekListCounts = new List<WeekListCounts>();

            //WeekList listWeekList1;
            //WeekListDayName listWeekListDayName1;
            //WeekListTimeSlot listWeekListTimeSlot1;
            //WeekListCounts listWeekListCounts1;


            List<MonthList> listMonthList = new List<MonthList>();
            List<MonthListDayName> listMonthListDayName = new List<MonthListDayName>();
            List<MonthListCounts> listMonthListCounts = new List<MonthListCounts>();

            MonthList listMonthList1;
            MonthListDayName listMonthListDayName1;
            MonthListCounts listMonthListCounts1;

            //List<SAList> listSAList = new List<SAList>();
            //List<SAListDayName> listSAListDayName = new List<SAListDayName>();
            //List<SADetails> listSADetails = new List<SADetails>();

            //SAList listSAList1;
            //SAListDayName listSAListDayName1;
            //SADetails listSADetails1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Not Commented Code
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange();
                        //listDetail.dayWiseLists = listAppointmentDayWiseList;
                        listDetail.dayWiseLists = null;
                        #endregion
                        #endregion

                        #region Assign Date, Time and SA Slots
                        DataTable DT_appnt_for_dt = new DataTable();
                        DataTable DT_time_slot = new DataTable();
                        //DataTable DT_SA = new DataTable();
                        //DataTable DT_SADetails = new DataTable();
                        //DataTable DT_SADetails2 = new DataTable();

                        DataTable DT_appnt_for_dt2 = new DataTable();
                        DataTable DT_appnt_for_dt3 = new DataTable();

                        DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        //DT_time_slot = ds.Tables[0].DefaultView.ToTable("time_slot", true, "time_slot");
                        #region Add Manual Time Slots as per requirement of iOS Team
                        string strTimeSlot = string.Empty;
                        DT_time_slot.Clear();
                        DT_time_slot.Columns.Add("time_slot");
                        for (int z = 1; z <= 5; z++)
                        {
                            if (z == 1)
                            {
                                strTimeSlot = "0700-0900";
                            }
                            else if (z == 2)
                            {
                                strTimeSlot = "0900-1100";
                            }
                            else if (z == 3)
                            {
                                strTimeSlot = "1100-1300";
                            }
                            else if (z == 4)
                            {
                                strTimeSlot = "1300-1600";
                            }
                            else if (z == 5)
                            {
                                strTimeSlot = "1600-1900";
                            }
                            DataRow DT_time_slot_row = DT_time_slot.NewRow();
                            DT_time_slot_row["time_slot"] = strTimeSlot;
                            DT_time_slot.Rows.Add(DT_time_slot_row);
                        }
                        #endregion

                        #region Commented Code
                        //DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

                        //DT_SADetails.Clear();
                        //DT_SADetails.Columns.Add("sa_code");
                        //DT_SADetails.Columns.Add("pn_user_id");
                        //DT_SADetails.Columns.Add("sa_name");
                        //for (int i = 0; i < DT_SA.Rows.Count; i++)
                        //{
                        //    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                        //    {
                        //        if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
                        //        {
                        //            DataRow DT_SADetails_row = DT_SADetails.NewRow();

                        //            DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
                        //            DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
                        //            DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

                        //            DT_SADetails.Rows.Add(DT_SADetails_row);
                        //            break;
                        //        }
                        //    }
                        //}
                        ////DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");
                        #endregion

                        DT_appnt_for_dt2.Clear();
                        DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

                        for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
                        {
                            DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
                            DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
                            DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
                        }
                        DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        #endregion

                        #region Commented Code
                        //#region Counts for Week Wise Details Day Date and Time Slot Wise
                        //listWeekList1 = new WeekList();
                        //listWeekList = new List<WeekList>();

                        //listWeekListDayName1 = new WeekListDayName();
                        //listWeekListDayName = new List<WeekListDayName>();

                        //listWeekListTimeSlot1 = new WeekListTimeSlot();
                        //listWeekListTimeSlot = new List<WeekListTimeSlot>();

                        //listWeekListCounts1 = new WeekListCounts();
                        //listWeekListCounts = new List<WeekListCounts>();

                        //for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        //{
                        //    listWeekList1 = new WeekList();

                        //    listWeekListDayName = new List<WeekListDayName>();
                        //    listWeekListTimeSlot = new List<WeekListTimeSlot>();

                        //    string strDayNames = string.Empty;
                        //    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                        //    for (int k = 0; k < DT_time_slot.Rows.Count; k++)
                        //    {
                        //        listWeekListDayName1 = new WeekListDayName();
                        //        listWeekListTimeSlot1 = new WeekListTimeSlot();
                        //        listWeekListCounts1 = new WeekListCounts();
                        //        listWeekListCounts = new List<WeekListCounts>();

                        //        listWeekListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                        //        string strTimeSlots = string.Empty;
                        //        strTimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900
                        //        listWeekListTimeSlot1.TimeSlots = DT_time_slot.Rows[k][0].ToString();//0700-0900

                        //        Int32 iAllRecCount = 0;
                        //        Int32 iReportedCount = 0;
                        //        Int32 iAppointedCount = 0;
                        //        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                        //        {
                        //            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["time_slot"].ToString() == strTimeSlots))
                        //            {
                        //                iAllRecCount = iAllRecCount + 1;

                        //                iAppointedCount = iAppointedCount + 1;

                        //                if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                        //                {
                        //                    iReportedCount = iReportedCount + 1;
                        //                }
                        //            }
                        //        }

                        //        listWeekListCounts1.AllRecCount = iAllRecCount.ToString();
                        //        listWeekListCounts1.AppointedCount = iAppointedCount.ToString();
                        //        listWeekListCounts1.ReportedCount = iReportedCount.ToString();

                        //        listWeekListCounts.Add(listWeekListCounts1);

                        //        listWeekListTimeSlot1.weekWiselistCounts = listWeekListCounts;
                        //        listWeekListTimeSlot.Add(listWeekListTimeSlot1);
                        //    }

                        //    listWeekListDayName1.weekWiselistTimeSlots = listWeekListTimeSlot;
                        //    listWeekListDayName.Add(listWeekListDayName1);

                        //    listWeekList1.weekWiselistDayNames = listWeekListDayName;
                        //    listWeekList.Add(listWeekList1);

                        //    listDetail.weekWiselists = listWeekList;

                        //}
                        ////MainALLDetailsList.Add(listDetail);
                        //#endregion
                        #endregion

                        #region Counts for Month Wise Details Day Date Wise
                        listMonthList1 = new MonthList();
                        listMonthList = new List<MonthList>();

                        listMonthListDayName1 = new MonthListDayName();
                        listMonthListDayName = new List<MonthListDayName>();

                        listMonthListCounts1 = new MonthListCounts();
                        listMonthListCounts = new List<MonthListCounts>();

                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listMonthList1 = new MonthList();

                            listMonthListDayName = new List<MonthListDayName>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                            listMonthListDayName1 = new MonthListDayName();
                            listMonthListCounts1 = new MonthListCounts();
                            listMonthListCounts = new List<MonthListCounts>();

                            listMonthListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                            Int32 iAllRecCount = 0;
                            Int32 iReportedCount = 0;
                            Int32 iAppointedCount = 0;
                            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                            {
                                if (ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames)
                                {
                                    iAllRecCount = iAllRecCount + 1;

                                    iAppointedCount = iAppointedCount + 1;

                                    if (ds.Tables[0].Rows[m]["confirmed_yn"].ToString().ToLower() == "y")//need discuss dilip
                                    {
                                        iReportedCount = iReportedCount + 1;
                                    }
                                }
                            }

                            listMonthListCounts1.AllRecCount = iAllRecCount.ToString();
                            listMonthListCounts1.AppointedCount = iAppointedCount.ToString();
                            listMonthListCounts1.ReportedCount = iReportedCount.ToString();

                            listMonthListCounts.Add(listMonthListCounts1);

                            listMonthListDayName1.monthWiselistCounts = listMonthListCounts;
                            listMonthListDayName.Add(listMonthListDayName1);

                            listMonthList1.monthWiselistDayNames = listMonthListDayName;
                            listMonthList.Add(listMonthList1);

                            listDetail.monthWiselists = listMonthList;
                        }
                        #endregion

                        #region Commented Code
                        //#region Counts for SA Wise Details Day Date Wise
                        ////listSAList1 = new SAList();
                        ////listSAList = new List<SAList>();

                        ////listSAListDayName1 = new SAListDayName();
                        ////listSAListDayName = new List<SAListDayName>();

                        ////listSADetails1 = new SADetails();
                        ////listSADetails = new List<SADetails>();


                        ////for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        ////{
                        ////    listSAList1 = new SAList();

                        ////    listSAListDayName = new List<SAListDayName>();
                        ////    listSADetails = new List<SADetails>();

                        ////    string strDayNames = string.Empty;
                        ////    strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                        ////    for (int k = 0; k < DT_SA.Rows.Count; k++)
                        ////    {
                        ////        listSAListDayName1 = new SAListDayName();
                        ////        listSADetails1 = new SADetails();


                        ////        listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                        ////        string strSADetails = string.Empty;
                        ////        strSADetails = DT_SA.Rows[k][0].ToString();//0018
                        ////        listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

                        ////        //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
                        ////        //if (drSADetails.Length > 0)
                        ////        //{
                        ////        //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
                        ////        //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
                        ////        //}

                        ////        for (int w = 0; w < DT_SADetails.Rows.Count; w++)
                        ////        {
                        ////            if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
                        ////            {
                        ////                listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
                        ////                listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

                        ////                break;
                        ////            }
                        ////        }

                        ////        Int32 iSAAllAppointRecCounts = 0;
                        ////        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                        ////        {
                        ////            if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
                        ////            {
                        ////                iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
                        ////            }
                        ////        }
                        ////        listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


                        ////        listSADetails.Add(listSADetails1);
                        ////    }

                        ////    listSAListDayName1.saWiseDetails = listSADetails;
                        ////    listSAListDayName.Add(listSAListDayName1);

                        ////    listSAList1.saWiselistDayNames = listSAListDayName;
                        ////    listSAList.Add(listSAList1);

                        ////    listDetail.saWiselists = listSAList;
                        ////}
                        //#endregion
                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeMonthWiseList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for AppointmentListAccordingToDateRangeSAWiseList
        public BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeSAWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date)
        {
            BaseListReturnType<AppointmentListAccordingToDateRange> response = new BaseListReturnType<AppointmentListAccordingToDateRange>();

            List<AppointmentListAccordingToDateRange> MainALLDetailsList;
            AppointmentListAccordingToDateRange listDetail = null;

            List<AppointmentDayWiseList> listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
            AppointmentDayWiseList listAppointmentDayWiseList1;

            List<SAList> listSAList = new List<SAList>();
            List<SAListDayName> listSAListDayName = new List<SAListDayName>();
            List<SADetails> listSADetails = new List<SADetails>();

            SAList listSAList1;
            SAListDayName listSAListDayName1;
            SADetails listSADetails1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_AppointmentListAccordingToDateRange;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_date", OracleType.VarChar).Value = pn_to_date;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<AppointmentListAccordingToDateRange>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        #region Not Commented Code
                        #region Main Day Wise Details
                        listAppointmentDayWiseList = new List<AppointmentDayWiseList>();
                        foreach (DataRow row in detailTable.Rows)
                        {
                            listAppointmentDayWiseList1 = new AppointmentDayWiseList();

                            listAppointmentDayWiseList1.reg_num = Convert.ToString(row["reg_num"]);
                            listAppointmentDayWiseList1.time_slot = Convert.ToString(row["time_slot"]);
                            listAppointmentDayWiseList1.srv_type_cd = Convert.ToString(row["srv_type_cd"]);
                            listAppointmentDayWiseList1.srv_type_desc = Convert.ToString(row["srv_type_desc"]);
                            listAppointmentDayWiseList1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                            listAppointmentDayWiseList1.sa_code = Convert.ToString(row["sa_code"]);
                            listAppointmentDayWiseList1.sa_name = Convert.ToString(row["sa_name"]);
                            listAppointmentDayWiseList1.appnt_num = Convert.ToString(row["appnt_num"]);
                            listAppointmentDayWiseList1.appnt_for_dt = Convert.ToString(row["appnt_for_dt"]);
                            listAppointmentDayWiseList1.odometer_reading = Convert.ToString(row["odometer_reading"]);
                            listAppointmentDayWiseList1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                            listAppointmentDayWiseList1.jc_num = Convert.ToString(row["jc_num"]);

                            listAppointmentDayWiseList1.booking_slot_time = Convert.ToString(row["booking_slot_time"]);

                            listAppointmentDayWiseList1.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            listAppointmentDayWiseList1.JC_OPENDATETIME = Convert.ToString(row["JC_OPENDATETIME"]);

                            listAppointmentDayWiseList.Add(listAppointmentDayWiseList1);
                        }
                        listDetail = new AppointmentListAccordingToDateRange();
                        //listDetail.dayWiseLists = listAppointmentDayWiseList;
                        listDetail.dayWiseLists = null;
                        #endregion
                        #endregion

                        #region Assign Date, Time and SA Slots
                        DataTable DT_appnt_for_dt = new DataTable();
                        DataTable DT_SA = new DataTable();
                        DataTable DT_SADetails = new DataTable();
                        DataTable DT_SADetails2 = new DataTable();

                        DataTable DT_appnt_for_dt2 = new DataTable();
                        DataTable DT_appnt_for_dt3 = new DataTable();

                        DT_appnt_for_dt = ds.Tables[0].DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");

                        DT_SA = ds.Tables[0].DefaultView.ToTable("sa_code", true, "sa_code");

                        DT_SADetails.Clear();
                        DT_SADetails.Columns.Add("sa_code");
                        DT_SADetails.Columns.Add("pn_user_id");
                        DT_SADetails.Columns.Add("sa_name");
                        for (int i = 0; i < DT_SA.Rows.Count; i++)
                        {
                            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                            {
                                if (ds.Tables[0].Rows[z]["sa_code"].ToString() == DT_SA.Rows[i]["sa_code"].ToString())
                                {
                                    DataRow DT_SADetails_row = DT_SADetails.NewRow();

                                    DT_SADetails_row["sa_code"] = ds.Tables[0].Rows[z]["sa_code"].ToString();//0018
                                    DT_SADetails_row["pn_user_id"] = pn_user_id;// ds.Tables[0].Rows[z]["pn_user_id"].ToString();//Prem.job5
                                    DT_SADetails_row["sa_name"] = ds.Tables[0].Rows[z]["sa_name"].ToString();//Md. Ansari

                                    DT_SADetails.Rows.Add(DT_SADetails_row);
                                    break;
                                }
                            }
                        }
                        //DT_SADetails2 = DT_SADetails.DefaultView.ToTable("sa_code", true, "sa_code", "pn_user_id", "sa_name");

                        DT_appnt_for_dt2.Clear();
                        DT_appnt_for_dt2.Columns.Add("appnt_for_dt");

                        for (int i = 0; i < DT_appnt_for_dt.Rows.Count; i++)
                        {
                            DataRow DT_appnt_for_dt2_row = DT_appnt_for_dt2.NewRow();
                            DT_appnt_for_dt2_row["appnt_for_dt"] = DT_appnt_for_dt.Rows[i][0].ToString().Substring(0, 11);//07-Apr-2017
                            DT_appnt_for_dt2.Rows.Add(DT_appnt_for_dt2_row);
                        }
                        DT_appnt_for_dt3 = DT_appnt_for_dt2.DefaultView.ToTable("appnt_for_dt", true, "appnt_for_dt");
                        #endregion

                        #region Counts for SA Wise Details Day Date Wise
                        listSAList1 = new SAList();
                        listSAList = new List<SAList>();

                        listSAListDayName1 = new SAListDayName();
                        listSAListDayName = new List<SAListDayName>();

                        listSADetails1 = new SADetails();
                        listSADetails = new List<SADetails>();


                        for (int i = 0; i < DT_appnt_for_dt3.Rows.Count; i++)
                        {
                            listSAList1 = new SAList();

                            listSAListDayName = new List<SAListDayName>();
                            listSADetails = new List<SADetails>();

                            string strDayNames = string.Empty;
                            strDayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017


                            for (int k = 0; k < DT_SA.Rows.Count; k++)
                            {
                                listSAListDayName1 = new SAListDayName();
                                listSADetails1 = new SADetails();


                                listSAListDayName1.DayNames = DT_appnt_for_dt3.Rows[i][0].ToString();//07-Apr-2017

                                string strSADetails = string.Empty;
                                strSADetails = DT_SA.Rows[k][0].ToString();//0018
                                listSADetails1.sa_code = DT_SA.Rows[k][0].ToString();//0018

                                //DataRow[] drSADetails = ds.Tables[0].Select("sa_code = '" + strSADetails + "'"); //SA Code
                                //if (drSADetails.Length > 0)
                                //{
                                //    listSADetails1.SA_pn_user_id = drSADetails[0]["pn_user_id"].ToString();
                                //    listSADetails1.sa_name = drSADetails[0]["sa_name"].ToString();
                                //}

                                for (int w = 0; w < DT_SADetails.Rows.Count; w++)
                                {
                                    if (DT_SADetails.Rows[w]["sa_code"].ToString() == strSADetails)
                                    {
                                        listSADetails1.SA_pn_user_id = DT_SADetails.Rows[w]["pn_user_id"].ToString();
                                        listSADetails1.sa_name = DT_SADetails.Rows[w]["sa_name"].ToString();

                                        break;
                                    }
                                }

                                Int32 iSAAllAppointRecCounts = 0;
                                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                                {
                                    if ((ds.Tables[0].Rows[m]["appnt_for_dt"].ToString().Substring(0, 11) == strDayNames) && (ds.Tables[0].Rows[m]["sa_code"].ToString() == strSADetails))
                                    {
                                        iSAAllAppointRecCounts = iSAAllAppointRecCounts + 1;
                                    }
                                }
                                listSADetails1.SAAllAppointRecCounts = iSAAllAppointRecCounts.ToString();


                                listSADetails.Add(listSADetails1);
                            }

                            listSAListDayName1.saWiseDetails = listSADetails;
                            listSAListDayName.Add(listSAListDayName1);

                            listSAList1.saWiselistDayNames = listSAListDayName;
                            listSAList.Add(listSAList1);

                            listDetail.saWiselists = listSAList;
                        }
                        #endregion

                        MainALLDetailsList.Add(listDetail);

                        response.code = (int)ServiceMassageCode.SUCCESS;
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                    else
                    {
                        response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                        response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                    }
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_AppointmentListAccordingToDateRangeSAWiseList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardOpeningCustomerAndVehicleMaster
        public BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd)
        {
            BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> response = new BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster>();

            JobCardOpeningCustomerAndVehicleMaster Typedetail = null;
            List<JobCardOpeningCustomerAndVehicleMaster> Details;

            try
            {
                JobCardOpeningCustomerAndVehicleMaster result = new JobCardOpeningCustomerAndVehicleMaster();
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
                cmd.CommandText = Usp_JobCardOpeningCustomerAndVehicleMaster;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                //for output params
                cmd.Parameters.Add("po_srvbooking_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_id", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_address", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_city", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_state", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_phone", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mobile", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_email", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vehiclemodel", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rftagno", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_chassisno", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_color", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ownveh_count", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_veh_sale_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tv_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_n2n_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mi_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_category", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tv_sale_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mi_validity_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_variant_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_variant_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_category", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_expiry_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_model_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_model_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_cap_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_mcp_package_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_expiry_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_autocard_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_autocard_point", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_complement_dtl", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_followup_dtl", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_followup_by", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_govt_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_csi", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_theft_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_veh_user_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_engine_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_key_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sold_by", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_enrol_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_repair", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_location", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_psf_status", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_srv_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_next_srv_due", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_next_due_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;


                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                Details = new List<JobCardOpeningCustomerAndVehicleMaster>();
                Typedetail = new JobCardOpeningCustomerAndVehicleMaster();
                Typedetail.po_srvbooking_no = cmd.Parameters["po_srvbooking_no"].Value.ToString();
                Typedetail.po_cust_id = cmd.Parameters["po_cust_id"].Value.ToString();
                Typedetail.po_cust_name = cmd.Parameters["po_cust_name"].Value.ToString();
                Typedetail.po_cust_address = cmd.Parameters["po_cust_address"].Value.ToString();
                Typedetail.po_city = cmd.Parameters["po_city"].Value.ToString();
                Typedetail.po_state = cmd.Parameters["po_state"].Value.ToString();
                Typedetail.po_phone = cmd.Parameters["po_phone"].Value.ToString();
                Typedetail.po_mobile = cmd.Parameters["po_mobile"].Value.ToString();
                Typedetail.po_pin = cmd.Parameters["po_pin"].Value.ToString();
                Typedetail.po_email = cmd.Parameters["po_email"].Value.ToString();
                Typedetail.po_vehiclemodel = cmd.Parameters["po_vehiclemodel"].Value.ToString();
                Typedetail.po_vin = cmd.Parameters["po_vin"].Value.ToString();
                Typedetail.po_rftagno = cmd.Parameters["po_rftagno"].Value.ToString();
                Typedetail.po_chassisno = cmd.Parameters["po_chassisno"].Value.ToString();
                Typedetail.po_color = cmd.Parameters["po_color"].Value.ToString();
                Typedetail.po_ownveh_count = cmd.Parameters["po_ownveh_count"].Value.ToString();
                Typedetail.po_veh_sale_date = cmd.Parameters["po_veh_sale_date"].Value.ToString();
                Typedetail.po_tv_yn = cmd.Parameters["po_tv_yn"].Value.ToString();
                Typedetail.po_n2n_yn = cmd.Parameters["po_n2n_yn"].Value.ToString();
                Typedetail.po_ew_yn = cmd.Parameters["po_ew_yn"].Value.ToString();
                Typedetail.po_mi_yn = cmd.Parameters["po_mi_yn"].Value.ToString();
                Typedetail.po_category = cmd.Parameters["po_category"].Value.ToString();
                Typedetail.po_tv_sale_date = cmd.Parameters["po_tv_sale_date"].Value.ToString();
                Typedetail.po_mi_validity_date = cmd.Parameters["po_mi_validity_date"].Value.ToString();
                Typedetail.po_variant_cd = cmd.Parameters["po_variant_cd"].Value.ToString();
                Typedetail.po_variant_desc = cmd.Parameters["po_variant_desc"].Value.ToString();
                Typedetail.po_cust_category = cmd.Parameters["po_cust_category"].Value.ToString();
                Typedetail.po_ew_type = cmd.Parameters["po_ew_type"].Value.ToString();
                Typedetail.po_ew_expiry_date = cmd.Parameters["po_ew_expiry_date"].Value.ToString();
                Typedetail.po_srv_model_desc = cmd.Parameters["po_srv_model_desc"].Value.ToString();
                Typedetail.po_srv_model_cd = cmd.Parameters["po_srv_model_cd"].Value.ToString();
                Typedetail.po_tech_cap_yn = cmd.Parameters["po_tech_cap_yn"].Value.ToString();
                Typedetail.po_mcp_package_desc = cmd.Parameters["po_mcp_package_desc"].Value.ToString();
                Typedetail.po_mcp_expiry_date = cmd.Parameters["po_mcp_expiry_date"].Value.ToString();
                Typedetail.po_autocard_no = cmd.Parameters["po_autocard_no"].Value.ToString();
                Typedetail.po_autocard_point = cmd.Parameters["po_autocard_point"].Value.ToString();
                Typedetail.po_complement_dtl = cmd.Parameters["po_complement_dtl"].Value.ToString();
                Typedetail.po_last_followup_dtl = cmd.Parameters["po_last_followup_dtl"].Value.ToString();
                Typedetail.po_last_followup_by = cmd.Parameters["po_last_followup_by"].Value.ToString();
                Typedetail.po_govt_yn = cmd.Parameters["po_govt_yn"].Value.ToString();
                Typedetail.po_last_csi = cmd.Parameters["po_last_csi"].Value.ToString();
                Typedetail.po_theft_yn = cmd.Parameters["po_theft_yn"].Value.ToString();

                Typedetail.po_veh_user_name = cmd.Parameters["po_veh_user_name"].Value.ToString();
                Typedetail.po_engine_num = cmd.Parameters["po_engine_num"].Value.ToString();
                Typedetail.po_key_no = cmd.Parameters["po_key_no"].Value.ToString();
                Typedetail.po_sold_by = cmd.Parameters["po_sold_by"].Value.ToString();
                Typedetail.po_mcp_enrol_no = cmd.Parameters["po_mcp_enrol_no"].Value.ToString();
                Typedetail.po_mcp_type = cmd.Parameters["po_mcp_type"].Value.ToString();
                Typedetail.po_repair = cmd.Parameters["po_repair"].Value.ToString();
                Typedetail.po_location = cmd.Parameters["po_location"].Value.ToString();
                Typedetail.po_last_psf_status = cmd.Parameters["po_last_psf_status"].Value.ToString();
                Typedetail.po_last_srv_date = cmd.Parameters["po_last_srv_date"].Value.ToString();
                Typedetail.po_next_srv_due = cmd.Parameters["po_next_srv_due"].Value.ToString();
                Typedetail.po_next_due_date = cmd.Parameters["po_next_due_date"].Value.ToString();

                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // CreateLogFiles Err = new CreateLogFiles();
                // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

                //Logging.Error(ex, "DMS:PushEvaluaton");
                ErrorLog.LogException(ex, "NEXAService_JobCardOpeningCustomerAndVehicleMaster");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                                               // response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for SubServiceTypeDetails. This is now not using
        //public BaseListReturnType<SubServiceTypeDetails> SubServiceTypeDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_srvtype_cd, string pn_omr)
        //{
        //    BaseListReturnType<SubServiceTypeDetails> response = new BaseListReturnType<SubServiceTypeDetails>();
        //    try
        //    {
        //        SubServiceTypeDetails result = new SubServiceTypeDetails();
        //        ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //        DateTime DateOfEval;
        //        if (!headerInfo.IsAuthenticated)
        //        {
        //            response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //            response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //            response.result = null;
        //            return response;
        //        }

        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_SubServiceTypeDetails;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
        //        cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
        //        cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
        //        cmd.Parameters.Add("pn_srvtype_cd", OracleType.VarChar).Value = pn_srvtype_cd;
        //        cmd.Parameters.Add("pn_omr", OracleType.VarChar).Value = pn_omr;
        //        //for output params

        //        cmd.Parameters.Add("po_subsrv_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_subsrv_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        // string outputStr = string.Empty;
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            cmd.Dispose();
        //            return response;
        //        }

        //        con.Close();
        //        response.code = (int)ServiceMassageCode.SUCCESS;
        //        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
        //        // response.result = result;
        //    }

        //    catch (Exception ex)
        //    {
        //        // CreateLogFiles Err = new CreateLogFiles();
        //        // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

        //        //Logging.Error(ex, "DMS:PushEvaluaton");
        //        ErrorLog.LogException(ex, "NEXAService_SubServiceTypeDetails");
        //        response.code = 100; //(int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
        //                                       // response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        #endregion

        #region for Appointmentdetails
        public BaseListReturnType<AppointmentDetails> AppointmentDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_appnt_no)
        {
            BaseListReturnType<AppointmentDetails> response = new BaseListReturnType<AppointmentDetails>();
            try
            {
                AppointmentDetails result = new AppointmentDetails();
                AppointmentDetails Typedetail = null;
                List<AppointmentDetails> AppointmentDetails;
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
                cmd.CommandText = Usp_AppointmentDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_appnt_no", OracleType.VarChar).Value = pn_appnt_no;

                //for output params
                cmd.Parameters.Add("po_srvtype_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_odometer", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickuptype", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickuploc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickupaddress", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickupdate", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_drivername", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickupremarks", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_droploc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_dropaddress", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_dropdate", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                AppointmentDetails = new List<AppointmentDetails>();
                Typedetail = new AppointmentDetails();
                Typedetail.po_srvtype_cd = cmd.Parameters["po_srvtype_cd"].Value.ToString();
                Typedetail.po_odometer = cmd.Parameters["po_odometer"].Value.ToString();
                Typedetail.po_pickuptype = cmd.Parameters["po_pickuptype"].Value.ToString();
                Typedetail.po_pickuploc = cmd.Parameters["po_pickuploc"].Value.ToString();
                Typedetail.po_pickupaddress = cmd.Parameters["po_pickupaddress"].Value.ToString();
                Typedetail.po_pickupdate = cmd.Parameters["po_pickupdate"].Value.ToString();
                Typedetail.po_drivername = cmd.Parameters["po_drivername"].Value.ToString();
                Typedetail.po_pickupremarks = cmd.Parameters["po_pickupremarks"].Value.ToString();
                Typedetail.po_droploc = cmd.Parameters["po_droploc"].Value.ToString();
                Typedetail.po_dropaddress = cmd.Parameters["po_dropaddress"].Value.ToString();
                Typedetail.po_dropdate = cmd.Parameters["po_dropdate"].Value.ToString();

                AppointmentDetails.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = AppointmentDetails;

            }

            catch (Exception ex)
            {
                // CreateLogFiles Err = new CreateLogFiles();
                // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

                //Logging.Error(ex, "DMS:PushEvaluaton");
                ErrorLog.LogException(ex, "NEXAService_AppointmentDetails");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                                               // response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for GenerateJobCard
        //public BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, string pn_cust_sign, string pn_est_remarks)
        //public BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, byte[] pn_cust_sign, string pn_est_remarks)
        //public BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, byte[] pn_cust_sign, string pn_est_remarks)
        public BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, string pn_cust_sign, string pn_est_remarks)
        {
            //string pn_cust_sign

            BaseListReturnType<GenerateJobCard> response = new BaseListReturnType<GenerateJobCard>();

            GenerateJobCard Typedetail = null;
            List<GenerateJobCard> Details;
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
                cmd.CommandText = Usp_GenerateJobCard;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_srv_cat_cd", OracleType.VarChar).Value = pn_srv_cat_cd;
                cmd.Parameters.Add("pn_sub_srv_type_cd", OracleType.VarChar).Value = pn_sub_srv_type_cd;
                cmd.Parameters.Add("pn_omr", OracleType.Number).Value = Convert.ToInt32(pn_omr);
                cmd.Parameters.Add("pn_promised_date", OracleType.VarChar).Value = pn_promised_date;
                cmd.Parameters.Add("pn_checkin_date", OracleType.VarChar).Value = pn_checkin_date;
                cmd.Parameters.Add("pn_sa_adv", OracleType.VarChar).Value = pn_sa_adv;
                cmd.Parameters.Add("pn_tech_adv", OracleType.VarChar).Value = pn_tech_adv;
                cmd.Parameters.Add("pn_bay_cd", OracleType.VarChar).Value = pn_bay_cd;
                cmd.Parameters.Add("pn_group_cd", OracleType.VarChar).Value = pn_group_cd;
                cmd.Parameters.Add("pn_tech_cd", OracleType.VarChar).Value = pn_tech_cd;
                cmd.Parameters.Add("pn_rfid_num", OracleType.VarChar).Value = pn_rfid_num;
                cmd.Parameters.Add("pn_waiting_cust", OracleType.VarChar).Value = pn_waiting_cust;

                cmd.Parameters.Add("pn_demand_ins_str", OracleType.VarChar).Value = pn_demand_ins_str;
                cmd.Parameters.Add("pn_part_ins_str", OracleType.VarChar).Value = pn_part_ins_str;
                cmd.Parameters.Add("pn_labor_ins_str", OracleType.VarChar).Value = pn_labor_ins_str;
                cmd.Parameters.Add("pn_inv_ins_str", OracleType.VarChar).Value = pn_inv_ins_str;
                cmd.Parameters.Add("pn_mcard_ins_str", OracleType.VarChar).Value = pn_mcard_ins_str;
                cmd.Parameters.Add("pn_unapprv_fit_str", OracleType.VarChar).Value = pn_unapprv_fit_str;
                cmd.Parameters.Add("pn_estm_str", OracleType.VarChar).Value = pn_estm_str;

                cmd.Parameters.Add("pn_prob_str", OracleType.VarChar).Value = pn_prob_str;
                cmd.Parameters.Add("pn_pickup_type", OracleType.VarChar).Value = pn_pickup_type;
                cmd.Parameters.Add("pn_pickup_loc_cd", OracleType.VarChar).Value = pn_pickup_loc_cd;
                cmd.Parameters.Add("pn_pickup_date", OracleType.VarChar).Value = pn_pickup_date;
                cmd.Parameters.Add("pn_free_pikcup_flag", OracleType.VarChar).Value = pn_free_pikcup_flag;
                cmd.Parameters.Add("pn_pickup_driver", OracleType.VarChar).Value = pn_pickup_driver;
                cmd.Parameters.Add("pn_pikcup_remarks", OracleType.VarChar).Value = pn_pikcup_remarks;
                cmd.Parameters.Add("pn_drop_loc_cd", OracleType.VarChar).Value = pn_drop_loc_cd;
                cmd.Parameters.Add("pn_drop_date", OracleType.VarChar).Value = pn_drop_date;
                cmd.Parameters.Add("pn_mms_num", OracleType.VarChar).Value = pn_mms_num;

                cmd.Parameters.Add("pn_rtest_stime", OracleType.Number).Value = Convert.ToInt32(pn_rtest_stime);
                cmd.Parameters.Add("pn_rtest_skms", OracleType.Number).Value = Convert.ToInt32(pn_rtest_skms);
                cmd.Parameters.Add("pn_rtest_etime", OracleType.Number).Value = Convert.ToInt32(pn_rtest_etime);
                cmd.Parameters.Add("pn_rtest_ekms", OracleType.Number).Value = Convert.ToInt32(pn_rtest_ekms);
                cmd.Parameters.Add("pn_part_est_amt", OracleType.Number).Value = Convert.ToInt32(pn_part_est_amt);
                cmd.Parameters.Add("pn_opr_est_amt", OracleType.Number).Value = Convert.ToInt32(pn_opr_est_amt);



                ////byte[] data = Convert.FromBase64String(pn_cust_sign);
                ////string decodedString = System.Text.Encoding.UTF8.GetString(data);
                //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pn_cust_sign);

                ////cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = decodedString;
                ////cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = pn_cust_sign;
                //cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = bytes;
                //cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = pn_cust_sign;
                //cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = Convert.ToByte(pn_cust_sign);


                cmd.Parameters.Add("pn_est_remarks", OracleType.VarChar).Value = pn_est_remarks;

                //for output params
                cmd.Parameters.Add("po_part_req_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_job_card_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                Details = new List<GenerateJobCard>();
                Typedetail = new GenerateJobCard();
                Typedetail.po_part_req_num = cmd.Parameters["po_part_req_num"].Value.ToString();
                Typedetail.po_job_card_num = cmd.Parameters["po_job_card_num"].Value.ToString();
                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_GenerateJobCard");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for SADashboardOnlyForCurrentDate
        public BaseListReturnType<SADashboardOnlyForCurrentDate> SADashboardOnlyForCurrentDate(string pn_dealer_cd, string pn_loc_cd, string pn_user_id)
        {
            BaseListReturnType<SADashboardOnlyForCurrentDate> response = new BaseListReturnType<SADashboardOnlyForCurrentDate>();

            List<SADashboardOnlyForCurrentDate> MainALLDetailsList;
            SADashboardOnlyForCurrentDate listDetail = null;

            List<AppointmentDetail> listAppointmentDetail = new List<AppointmentDetail>();
            List<CallDetail> listCallDetail = new List<CallDetail>();
            List<JobCardDetail> listJobCardDetail = new List<JobCardDetail>();
            List<PickDropDetail> listPickDropDetail = new List<PickDropDetail>();

            AppointmentDetail listAppointmentDetail1;
            CallDetail listCallDetail1;
            JobCardDetail listJobCardDetail1;
            PickDropDetail listPickDropDetail1;

            Int32 iintroduction_Generated_Count = 0;
            Int32 iintroduction_Close_Count = 0;
            Int32 iintroduction_Open_Count = 0;

            Int32 iwelcome_Generated_Count = 0;
            Int32 iwelcome_Close_Count = 0;
            Int32 iwelcome_Open_Count = 0;

            Int32 ismr_Generated_Count = 0;
            Int32 ismr_Close_Count = 0;
            Int32 ismr_Open_Count = 0;

            Int32 ipsf_Generated_Count = 0;
            Int32 ipsf_Close_Count = 0;
            Int32 ipsf_Open_Count = 0;

            Int32 imyAppointments_Appointed_Count = 0;
            Int32 imyAppointments_Reported_Count = 0;
            Int32 imyAppointments_Pending_Count = 0;

            Int32 imyJobCards_Opened_Count = 0;
            Int32 imyJobCards_Closed_Count = 0;
            Int32 imyJobCards_SameDayDelivery_Count = 0;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_SADashboardOnlyForCurrentDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;

                cmd.Parameters.Add("po_appnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_call_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_jc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_pickdrop_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrAppointmentDetail;
                OracleDataReader rdrCallDetail;
                OracleDataReader rdrJobCardDetail;
                OracleDataReader rdrPickDropDetail;

                //da = new OracleDataAdapter(cmd);
                //ds = new DataSet();
                //da.Fill(ds);

                rdrAppointmentDetail = (OracleDataReader)cmd.Parameters["po_appnt_refcur"].Value;
                rdrCallDetail = (OracleDataReader)cmd.Parameters["po_call_refcur"].Value;
                rdrJobCardDetail = (OracleDataReader)cmd.Parameters["po_jc_refcur"].Value;
                rdrPickDropDetail = (OracleDataReader)cmd.Parameters["po_pickdrop_refcur"].Value;

                #endregion

                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<SADashboardOnlyForCurrentDate>();

                //if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                //if (rdrAppointmentDetail.HasRows || rdrCallDetail.HasRows || rdrJobCardDetail.HasRows)
                //{
                //var detailTable = ds.Tables[0];
                //if (detailTable.Rows.Count > 0)
                //{
                listAppointmentDetail = new List<AppointmentDetail>();
                listCallDetail = new List<CallDetail>();
                listJobCardDetail = new List<JobCardDetail>();
                listPickDropDetail = new List<PickDropDetail>();

                #region Commented Code
                //foreach (DataRow row in detailTable.Rows)
                //{
                //    listAppointmentDetail1 = new AppointmentDetail();
                //    listCallDetail1 = new CallDetail();
                //    listJobCardDetail1 = new JobCardDetail();


                //    listAppointmentDetail1.reg_num = Convert.ToString(row["reg_num"]);
                //    listAppointmentDetail1.time_slot = Convert.ToString(row["time_slot"]);
                //    listAppointmentDetail1.srv_type = Convert.ToString(row["srv_type"]);
                //    listAppointmentDetail1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                //    listAppointmentDetail1.sa_code = Convert.ToString(row["sa_code"]);
                //    listAppointmentDetail1.sa_name = Convert.ToString(row["sa_name"]);
                //    listAppointmentDetail1.appnt_num = Convert.ToString(row["appnt_num"]);
                //    listAppointmentDetail1.confirmed_yn = Convert.ToString(row["confirmed_yn"]);
                //    listAppointmentDetail1.jc_num = Convert.ToString(row["jc_num"]);

                //    listAppointmentDetail.Add(listAppointmentDetail1);




                //    listCallDetail1.cust_name = Convert.ToString(row["cust_name"]);
                //    listCallDetail1.reg_num = Convert.ToString(row["reg_num"]);
                //    listCallDetail1.sale_date = Convert.ToString(row["sale_date"]);
                //    listCallDetail1.vehiclemodel = Convert.ToString(row["vehiclemodel"]);
                //    listCallDetail1.call_type = Convert.ToString(row["call_type"]);
                //    listCallDetail1.call_status = Convert.ToString(row["call_status"]);
                //    listCallDetail1.contact_no = Convert.ToString(row["contact_no"]);
                //    listCallDetail1.emailid = Convert.ToString(row["emailid"]);
                //    listCallDetail1.vin = Convert.ToString(row["vin"]);
                //    listCallDetail1.follow_status = Convert.ToString(row["follow_status"]);

                //    listCallDetail.Add(listCallDetail1);




                //    listJobCardDetail1.jc_num = Convert.ToString(row["jc_num"]);
                //    listJobCardDetail1.cust_name = Convert.ToString(row["cust_name"]);
                //    listJobCardDetail1.reg_num = Convert.ToString(row["reg_num"]);
                //    listJobCardDetail1.jc_date = Convert.ToString(row["jc_date"]);
                //    listJobCardDetail1.promise_datetime = Convert.ToString(row["promise_datetime"]);
                //    listJobCardDetail1.jc_status = Convert.ToString(row["jc_status"]);
                //    listJobCardDetail1.srv_type = Convert.ToString(row["srv_type"]);
                //    listJobCardDetail1.vechilemodel = Convert.ToString(row["vechilemodel"]);
                //    listJobCardDetail1.contact_no = Convert.ToString(row["contact_no"]);
                //    listJobCardDetail1.emailid = Convert.ToString(row["emailid"]);
                //    listJobCardDetail1.vin = Convert.ToString(row["vin"]);

                //    listJobCardDetail.Add(listJobCardDetail1);
                //}
                //listDetail = new SADashboardOnlyForCurrentDate();
                //listDetail.appointmentDetailLists = listAppointmentDetail;
                //listDetail.callDetailLists = listCallDetail;
                //listDetail.jobCardDetailLists = listJobCardDetail;
                #endregion

                #region rdrAppointmentDetail
                if (rdrAppointmentDetail.HasRows)
                {
                    while (rdrAppointmentDetail.Read())
                    {
                        listAppointmentDetail1 = new AppointmentDetail();
                        listAppointmentDetail1.reg_num = rdrAppointmentDetail["reg_num"].ToString();
                        listAppointmentDetail1.time_slot = rdrAppointmentDetail["time_slot"].ToString();
                        listAppointmentDetail1.srv_type = rdrAppointmentDetail["srv_type"].ToString();
                        listAppointmentDetail1.vechilemodel = rdrAppointmentDetail["vechilemodel"].ToString();
                        listAppointmentDetail1.sa_code = rdrAppointmentDetail["sa_code"].ToString();
                        listAppointmentDetail1.sa_name = rdrAppointmentDetail["sa_name"].ToString();
                        listAppointmentDetail1.appnt_num = rdrAppointmentDetail["appnt_num"].ToString();
                        listAppointmentDetail1.confirmed_yn = rdrAppointmentDetail["confirmed_yn"].ToString();
                        listAppointmentDetail1.jc_num = rdrAppointmentDetail["jc_num"].ToString();

                        listAppointmentDetail1.odometer_reading = rdrAppointmentDetail["odometer_reading"].ToString();

                        if (rdrAppointmentDetail["confirmed_yn"].ToString().Trim().ToLower() == "y")
                        {
                            imyAppointments_Appointed_Count = imyAppointments_Appointed_Count + 1;

                            imyAppointments_Reported_Count = imyAppointments_Reported_Count + 1;
                        }
                        else if (rdrAppointmentDetail["confirmed_yn"].ToString().Trim().ToLower() == "n")
                        {
                            imyAppointments_Appointed_Count = imyAppointments_Appointed_Count + 1;

                            imyAppointments_Pending_Count = imyAppointments_Pending_Count + 1;
                        }

                        listAppointmentDetail.Add(listAppointmentDetail1);
                    }
                }
                #endregion
                #region rdrCallDetail
                if (rdrCallDetail.HasRows)
                {
                    while (rdrCallDetail.Read())
                    {
                        listCallDetail1 = new CallDetail();
                        listCallDetail1.cust_name = rdrCallDetail["cust_name"].ToString();
                        listCallDetail1.reg_num = rdrCallDetail["reg_num"].ToString();
                        listCallDetail1.sale_date = rdrCallDetail["sale_date"].ToString();
                        listCallDetail1.vehiclemodel = rdrCallDetail["vehiclemodel"].ToString();
                        listCallDetail1.call_type = rdrCallDetail["call_type"].ToString();
                        listCallDetail1.call_status = rdrCallDetail["call_status"].ToString();
                        listCallDetail1.contact_no = rdrCallDetail["contact_no"].ToString();
                        listCallDetail1.emailid = rdrCallDetail["emailid"].ToString();
                        listCallDetail1.vin = rdrCallDetail["vin"].ToString();
                        listCallDetail1.follow_status = rdrCallDetail["follow_status"].ToString();

                        if (rdrCallDetail["call_type"].ToString().Trim().ToLower() == "psf")
                        {
                            ipsf_Generated_Count = ipsf_Generated_Count + 1;

                            if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "open")
                            {
                                ipsf_Open_Count = ipsf_Open_Count + 1;
                            }
                            else if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "close")
                            {
                                ipsf_Close_Count = ipsf_Close_Count + 1;
                            }
                        }
                        else if (rdrCallDetail["call_type"].ToString().Trim().ToLower() == "smr")
                        {
                            ismr_Generated_Count = ismr_Generated_Count + 1;

                            if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "open")
                            {
                                ismr_Open_Count = ismr_Open_Count + 1;
                            }
                            else if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "close")
                            {
                                ismr_Close_Count = ismr_Close_Count + 1;
                            }
                        }
                        else if (rdrCallDetail["call_type"].ToString().Trim().ToLower() == "wel")//welcome
                        {
                            iwelcome_Generated_Count = iwelcome_Generated_Count + 1;

                            if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "open")
                            {
                                iwelcome_Open_Count = iwelcome_Open_Count + 1;
                            }
                            else if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "close")
                            {
                                iwelcome_Close_Count = iwelcome_Close_Count + 1;
                            }
                        }
                        else if (rdrCallDetail["call_type"].ToString().Trim().ToLower() == "int")//introduction
                        {
                            iintroduction_Generated_Count = iintroduction_Generated_Count + 1;

                            if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "open")
                            {
                                iintroduction_Open_Count = iintroduction_Open_Count + 1;
                            }
                            else if (rdrCallDetail["follow_status"].ToString().Trim().ToLower() == "close")
                            {
                                iintroduction_Close_Count = iintroduction_Close_Count + 1;
                            }
                        }

                        listCallDetail.Add(listCallDetail1);
                    }
                }
                #endregion
                #region rdrJobCardDetail
                if (rdrJobCardDetail.HasRows)
                {
                    while (rdrJobCardDetail.Read())
                    {
                        listJobCardDetail1 = new JobCardDetail();
                        listJobCardDetail1.jc_num = rdrJobCardDetail["jc_num"].ToString();
                        listJobCardDetail1.cust_name = rdrJobCardDetail["cust_name"].ToString();
                        listJobCardDetail1.reg_num = rdrJobCardDetail["reg_num"].ToString();
                        listJobCardDetail1.jc_date = rdrJobCardDetail["jc_date"].ToString();
                        listJobCardDetail1.promise_datetime = rdrJobCardDetail["promise_datetime"].ToString();
                        listJobCardDetail1.jc_status = rdrJobCardDetail["jc_status"].ToString();
                        listJobCardDetail1.srv_type = rdrJobCardDetail["srv_type"].ToString();
                        listJobCardDetail1.vechilemodel = rdrJobCardDetail["vechilemodel"].ToString();
                        listJobCardDetail1.contact_no = rdrJobCardDetail["contact_no"].ToString();
                        listJobCardDetail1.emailid = rdrJobCardDetail["emailid"].ToString();
                        listJobCardDetail1.vin = rdrJobCardDetail["vin"].ToString();
                        listJobCardDetail1.revised_datetime = rdrJobCardDetail["revised_datetime"].ToString();
                        listJobCardDetail1.sa_code = rdrJobCardDetail["sa_code"].ToString();
                        listJobCardDetail1.sa_name = rdrJobCardDetail["sa_name"].ToString();
                        listJobCardDetail1.jc_close_date = rdrJobCardDetail["jc_close_date"].ToString();

                        listJobCardDetail1.waiting_yn = rdrJobCardDetail["waiting_yn"].ToString();
                        listJobCardDetail1.Pickup_Type = rdrJobCardDetail["Pickup_Type"].ToString();
                        listJobCardDetail1.appointment_type = rdrJobCardDetail["appointment_type"].ToString();

                        if (rdrJobCardDetail["jc_status"].ToString().Trim().ToLower().Contains("open"))
                        {
                            imyJobCards_Opened_Count = imyJobCards_Opened_Count + 1;
                        }
                        else if (rdrJobCardDetail["jc_status"].ToString().Trim().ToLower().Contains("close"))
                        {
                            imyJobCards_Closed_Count = imyJobCards_Closed_Count + 1;
                        }

                        if ((!string.IsNullOrEmpty(rdrJobCardDetail["jc_date"].ToString().Trim())) && (!string.IsNullOrEmpty(rdrJobCardDetail["jc_close_date"].ToString().Trim())))
                        {
                            //DateTime d1_jc_date, d2_jc_close_date;
                            //d1_jc_date = DateTime.Parse(rdrJobCardDetail["jc_date"].ToString("yyyy-MM-dd"));
                            //d2_jc_close_date = DateTime.Parse(rdrJobCardDetail["jc_close_date"].ToString("yyyy-MM-dd"));
                            //if (d1_jc_date == d2_jc_close_date)
                            if (Convert.ToDateTime(rdrJobCardDetail["jc_date"]).ToString("yyyy-MM-dd") == Convert.ToDateTime(rdrJobCardDetail["jc_close_date"]).ToString("yyyy-MM-dd"))
                            {
                                imyJobCards_SameDayDelivery_Count = imyJobCards_SameDayDelivery_Count + 1;
                            }
                        }

                        listJobCardDetail.Add(listJobCardDetail1);
                    }
                }
                #endregion
                #region rdrPickDropDetail
                if (rdrPickDropDetail.HasRows)
                {
                    while (rdrPickDropDetail.Read())
                    {
                        listPickDropDetail1 = new PickDropDetail();
                        listPickDropDetail1.PDA_name = rdrPickDropDetail["PDA_name"].ToString();
                        listPickDropDetail1.Mobile_no_PDA = rdrPickDropDetail["Mobile_no_PDA"].ToString();
                        listPickDropDetail1.Zone_Localities = rdrPickDropDetail["Zone_Localities"].ToString();
                        listPickDropDetail1.CustomerName = rdrPickDropDetail["CustomerName"].ToString();
                        listPickDropDetail1.Mobile_No = rdrPickDropDetail["Mobile_No"].ToString();
                        listPickDropDetail1.Pickup_Time = rdrPickDropDetail["Pickup_Time"].ToString();
                        listPickDropDetail1.Pickup_Type = rdrPickDropDetail["Pickup_Type"].ToString();

                        listPickDropDetail.Add(listPickDropDetail1);
                    }
                }
                #endregion

                listDetail = new SADashboardOnlyForCurrentDate();
                listDetail.appointmentDetailLists = listAppointmentDetail;
                listDetail.callDetailLists = listCallDetail;
                listDetail.jobCardDetailLists = listJobCardDetail;
                listDetail.pickdropDetailLists = listPickDropDetail;


                listDetail.introduction_Generated_Count = iintroduction_Generated_Count.ToString();
                listDetail.introduction_Close_Count = iintroduction_Close_Count.ToString();
                listDetail.introduction_Open_Count = iintroduction_Open_Count.ToString();

                listDetail.welcome_Generated_Count = iwelcome_Generated_Count.ToString();
                listDetail.welcome_Close_Count = iwelcome_Close_Count.ToString();
                listDetail.welcome_Open_Count = iwelcome_Open_Count.ToString();

                listDetail.smr_Generated_Count = ismr_Generated_Count.ToString();
                listDetail.smr_Close_Count = ismr_Close_Count.ToString();
                listDetail.smr_Open_Count = ismr_Open_Count.ToString();

                listDetail.psf_Generated_Count = ipsf_Generated_Count.ToString();
                listDetail.psf_Close_Count = ipsf_Close_Count.ToString();
                listDetail.psf_Open_Count = ipsf_Open_Count.ToString();

                listDetail.myAppointments_Appointed_Count = imyAppointments_Appointed_Count.ToString();
                listDetail.myAppointments_Reported_Count = imyAppointments_Reported_Count.ToString();
                listDetail.myAppointments_Pending_Count = imyAppointments_Pending_Count.ToString();

                listDetail.myJobCards_Opened_Count = imyJobCards_Opened_Count.ToString();
                listDetail.myJobCards_Closed_Count = imyJobCards_Closed_Count.ToString();
                listDetail.myJobCards_SameDayDelivery_Count = imyJobCards_SameDayDelivery_Count.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //}
                //else
                //{
                //    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                //    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                //}
                //}
                //else
                //{
                //    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                //    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                //}

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_SADashboardOnlyForCurrentDate");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardListOfVehicle
        public BaseListReturnType<JobCardListOfVehicle> JobCardListOfVehicle(string pn_pmc, string pn_reg_num)
        {
            BaseListReturnType<JobCardListOfVehicle> response = new BaseListReturnType<JobCardListOfVehicle>();

            JobCardListOfVehicle Typedetail = null;
            List<JobCardListOfVehicle> Details;
            //Validate Token
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
                cmd.CommandText = Usp_JobCardListOfVehicle;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;

                cmd.Parameters.Add("po_hist_hdr_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<JobCardListOfVehicle>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new JobCardListOfVehicle();

                            Typedetail.dealer_code = Convert.ToString(row["dealer_code"]);
                            Typedetail.dealer_name = Convert.ToString(row["dealer_name"]);
                            Typedetail.service_date = Convert.ToString(row["service_date"]);
                            Typedetail.service_type = Convert.ToString(row["service_type"]);
                            Typedetail.model = Convert.ToString(row["model"]);
                            Typedetail.mileage = Convert.ToString(row["mileage"]);
                            Typedetail.job_card_date = Convert.ToString(row["job_card_date"]);
                            Typedetail.job_card_num = Convert.ToString(row["job_card_num"]);
                            Typedetail.bill_date = Convert.ToString(row["bill_date"]);
                            Typedetail.sa_name = Convert.ToString(row["sa_name"]);
                            Typedetail.technician_name = Convert.ToString(row["technician_name"]);
                            Typedetail.psf_status = Convert.ToString(row["psf_status"]);
                            Typedetail.remarks = Convert.ToString(row["remarks"]);
                            Typedetail.unapproved_fitness = Convert.ToString(row["unapproved_fitness"]);
                            Typedetail.labour_amt = Convert.ToString(row["labour_amt"]);
                            Typedetail.part_amt = Convert.ToString(row["part_amt"]);
                            Typedetail.tot_amt = Convert.ToString(row["tot_amt"]);
                            Typedetail.est_labour_amt = Convert.ToString(row["est_labour_amt"]);
                            Typedetail.est_part_amt = Convert.ToString(row["est_part_amt"]);
                            Typedetail.tot_est_amt = Convert.ToString(row["tot_est_amt"]);

                            Typedetail.attend_through = Convert.ToString(row["attend_through"]);
                            Typedetail.csi_per = Convert.ToString(row["csi_per"]);
                            Typedetail.satisfied_yn = Convert.ToString(row["satisfied_yn"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_JobCardListOfVehicle");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardDetailsAccordingToJobCard
        public BaseListReturnType<JobCardDetailsAccordingToJobCard> JobCardDetailsAccordingToJobCard(string pn_pmc, string pn_reg_num, string pn_ro_num)
        {
            BaseListReturnType<JobCardDetailsAccordingToJobCard> response = new BaseListReturnType<JobCardDetailsAccordingToJobCard>();

            List<JobCardDetailsAccordingToJobCard> MainALLDetailsList;
            JobCardDetailsAccordingToJobCard listDetail = null;

            List<VehicleFollowHistory> listVehicleFollowHistory = new List<VehicleFollowHistory>();
            List<VehiclePartHistory> listVehiclePartHistory = new List<VehiclePartHistory>();
            List<VehicleLaborHistory> listVehicleLaborHistory = new List<VehicleLaborHistory>();
            List<VehicleDemandRepairsHistory> listVehicleDemandRepairsHistory = new List<VehicleDemandRepairsHistory>();

            VehicleFollowHistory listVehicleFollowHistory1;
            VehiclePartHistory listVehiclePartHistory1;
            VehicleLaborHistory listVehicleLaborHistory1;
            VehicleDemandRepairsHistory listVehicleDemandRepairsHistory1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_JobCardDetailsAccordingToJobCard;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);
                cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                cmd.Parameters.Add("pn_ro_num", OracleType.VarChar).Value = pn_ro_num;

                cmd.Parameters.Add("po_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_labor_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_demand_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrVehicleFollowHistory;
                OracleDataReader rdrVehiclePartHistory;
                OracleDataReader rdrVehicleLaborHistory;
                OracleDataReader rdrVehicleDemandRepairsHistory;

                rdrVehicleFollowHistory = (OracleDataReader)cmd.Parameters["po_followup_refcur"].Value;
                rdrVehiclePartHistory = (OracleDataReader)cmd.Parameters["po_part_refcur"].Value;
                rdrVehicleLaborHistory = (OracleDataReader)cmd.Parameters["po_labor_refcur"].Value;
                rdrVehicleDemandRepairsHistory = (OracleDataReader)cmd.Parameters["po_demand_refcur"].Value;

                #endregion

                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<JobCardDetailsAccordingToJobCard>();

                if (rdrVehicleFollowHistory.HasRows || rdrVehiclePartHistory.HasRows || rdrVehicleLaborHistory.HasRows || rdrVehicleDemandRepairsHistory.HasRows)
                {
                    listVehicleFollowHistory = new List<VehicleFollowHistory>();
                    listVehiclePartHistory = new List<VehiclePartHistory>();
                    listVehicleLaborHistory = new List<VehicleLaborHistory>();
                    listVehicleDemandRepairsHistory = new List<VehicleDemandRepairsHistory>();

                    if (rdrVehicleFollowHistory.HasRows)
                    {
                        while (rdrVehicleFollowHistory.Read())
                        {
                            listVehicleFollowHistory1 = new VehicleFollowHistory();
                            listVehicleFollowHistory1.psf_num = rdrVehicleFollowHistory["psf_num"].ToString();
                            //listVehicleFollowHistory1.psf_date = rdrVehicleFollowHistory["psf_date"].ToString();
                            listVehicleFollowHistory1.psf_date = rdrVehicleFollowHistory["psf_date"].ToString();
                            listVehicleFollowHistory1.psf_by = rdrVehicleFollowHistory["psf_by"].ToString();
                            listVehicleFollowHistory1.remarks = rdrVehicleFollowHistory["remarks"].ToString();
                            listVehicleFollowHistory1.satisfied_yn = rdrVehicleFollowHistory["satisfied_yn"].ToString();
                            listVehicleFollowHistory1.response = rdrVehicleFollowHistory["response"].ToString();

                            listVehicleFollowHistory.Add(listVehicleFollowHistory1);
                        }
                    }

                    if (rdrVehiclePartHistory.HasRows)
                    {
                        while (rdrVehiclePartHistory.Read())
                        {
                            listVehiclePartHistory1 = new VehiclePartHistory();
                            listVehiclePartHistory1.part_num = rdrVehiclePartHistory["part_num"].ToString();
                            listVehiclePartHistory1.part_desc = rdrVehiclePartHistory["part_desc"].ToString();
                            listVehiclePartHistory1.iss_qty = rdrVehiclePartHistory["iss_qty"].ToString();
                            listVehiclePartHistory1.part_amt = rdrVehiclePartHistory["part_amt"].ToString();
                            listVehiclePartHistory1.billable_type = rdrVehiclePartHistory["billable_type"].ToString();

                            listVehiclePartHistory.Add(listVehiclePartHistory1);
                        }
                    }

                    if (rdrVehicleLaborHistory.HasRows)
                    {
                        while (rdrVehicleLaborHistory.Read())
                        {
                            listVehicleLaborHistory1 = new VehicleLaborHistory();
                            listVehicleLaborHistory1.opr_cd = rdrVehicleLaborHistory["opr_cd"].ToString();
                            listVehicleLaborHistory1.opr_desc = rdrVehicleLaborHistory["opr_desc"].ToString();
                            listVehicleLaborHistory1.opr_amt = rdrVehicleLaborHistory["opr_amt"].ToString();
                            listVehicleLaborHistory1.billable_type = rdrVehicleLaborHistory["billable_type"].ToString();

                            listVehicleLaborHistory.Add(listVehicleLaborHistory1);
                        }
                    }

                    if (rdrVehicleDemandRepairsHistory.HasRows)
                    {
                        while (rdrVehicleDemandRepairsHistory.Read())
                        {
                            listVehicleDemandRepairsHistory1 = new VehicleDemandRepairsHistory();
                            listVehicleDemandRepairsHistory1.demand_cd = rdrVehicleDemandRepairsHistory["demand_cd"].ToString();
                            listVehicleDemandRepairsHistory1.demand_desc = rdrVehicleDemandRepairsHistory["demand_desc"].ToString();
                            listVehicleDemandRepairsHistory1.customer_voice = rdrVehicleDemandRepairsHistory["customer_voice"].ToString();

                            listVehicleDemandRepairsHistory.Add(listVehicleDemandRepairsHistory1);
                        }
                    }

                    listDetail = new JobCardDetailsAccordingToJobCard();
                    listDetail.vehicleFollowHistoryLists = listVehicleFollowHistory;
                    listDetail.vehiclePartHistoryLists = listVehiclePartHistory;
                    listDetail.vehicleLaborHistoryLists = listVehicleLaborHistory;
                    listDetail.vehicleDemandRepairsHistoryLists = listVehicleDemandRepairsHistory;

                    MainALLDetailsList.Add(listDetail);

                    response.code = (int)ServiceMassageCode.SUCCESS;
                    response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                }
                else
                {
                    response.code = (int)ServiceMassageCode.DATA_NOT_EXIST;
                    response.message = Convert.ToString(ServiceMassageCode.DATA_NOT_EXIST);
                }

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_JobCardDetailsAccordingToJobCard");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardListForSA
        public BaseListReturnType<JobCardListForSA> JobCardListForSA(string pn_dealer_cd, string pn_loc_cd, string pn_user_id)
        {
            BaseListReturnType<JobCardListForSA> response = new BaseListReturnType<JobCardListForSA>();

            JobCardListForSA Typedetail = null;
            List<JobCardListForSA> Details;
            //Validate Token
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
                cmd.CommandText = Usp_JobCardListForSA;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;

                cmd.Parameters.Add("po_jc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<JobCardListForSA>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new JobCardListForSA();

                            Typedetail.model = Convert.ToString(row["model"]);
                            Typedetail.cust_name = Convert.ToString(row["cust_name"]);
                            Typedetail.mobile_phone = Convert.ToString(row["mobile_phone"]);
                            Typedetail.job_card_num = Convert.ToString(row["job_card_num"]);
                            Typedetail.srv_type = Convert.ToString(row["srv_type"]);
                            Typedetail.jc_open_date = Convert.ToString(row["jc_open_date"]);
                            Typedetail.prom_date = Convert.ToString(row["prom_date"]);
                            Typedetail.jc_status = Convert.ToString(row["jc_status"]);
                            Typedetail.srv_adv_cd = Convert.ToString(row["srv_adv_cd"]);
                            Typedetail.srv_sdv_name = Convert.ToString(row["srv_sdv_name"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_JobCardListForSA");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for RejectionReasonsList
        public BaseListReturnType<RejectionReasonsList> RejectionReasonsList(string pn_pmc)
        {
            BaseListReturnType<RejectionReasonsList> response = new BaseListReturnType<RejectionReasonsList>();

            RejectionReasonsList Typedetail = null;
            List<RejectionReasonsList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_RejectionReasonsList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);

                cmd.Parameters.Add("po_rejreas_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<RejectionReasonsList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new RejectionReasonsList();

                            Typedetail.reason_cd = Convert.ToString(row["reason_cd"]);
                            Typedetail.reason_desc = Convert.ToString(row["reason_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_RejectionReasonsList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for PartCodeList
        public BaseListReturnType<PartCodeList> PartCodeList(string pn_pmc, string pn_group_cd)
        {
            BaseListReturnType<PartCodeList> response = new BaseListReturnType<PartCodeList>();

            PartCodeList Typedetail = null;
            List<PartCodeList> Details;
            //Validate Token
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
                cmd.CommandText = Usp_PartCodeList;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_pmc", OracleType.Number).Value = Convert.ToInt32(pn_pmc);
                cmd.Parameters.Add("pn_group_cd", OracleType.VarChar).Value = pn_group_cd;

                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<PartCodeList>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new PartCodeList();

                            Typedetail.part_num = Convert.ToString(row["part_num"]);
                            Typedetail.part_desc = Convert.ToString(row["part_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_PartCodeList");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardListForSA_JCClosePull
        public BaseListReturnType<JobCardClosePull> JobCardClosePull(string pn_jc_module, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_no)
        {
            BaseListReturnType<JobCardClosePull> response = new BaseListReturnType<JobCardClosePull>();

            List<JobCardClosePull> MainALLDetailsList;
            JobCardClosePull listDetail = null;

            List<JCClosePull_DemandList> listDemandList = new List<JCClosePull_DemandList>();
            List<JCClosePull_PartList> listPartList = new List<JCClosePull_PartList>();
            List<JCClosePull_LaborList> listLaborList = new List<JCClosePull_LaborList>();
            List<JCClosePull_InvList> listInvList = new List<JCClosePull_InvList>();
            List<JCClosePull_SmcardList> listSmcardList = new List<JCClosePull_SmcardList>();
            List<JCClosePull_UnapprfitList> listUnapprfitList = new List<JCClosePull_UnapprfitList>();
            List<JCClosePull_Tech_campList> listTech_campList = new List<JCClosePull_Tech_campList>();
            List<JCClosePull_Repair_actList> listRepair_actList = new List<JCClosePull_Repair_actList>();
            List<JCClosePull_Comply_dtlList> listComply_dtlList = new List<JCClosePull_Comply_dtlList>();

            JCClosePull_DemandList listDemandList1;
            JCClosePull_PartList listPartList1;
            JCClosePull_LaborList listLaborList1;
            JCClosePull_InvList listInvList1;
            JCClosePull_SmcardList listSmcardList1;
            JCClosePull_UnapprfitList listUnapprfitList1;
            JCClosePull_Tech_campList listTech_campList1;
            JCClosePull_Repair_actList listRepair_actList1;
            JCClosePull_Comply_dtlList listComply_dtlList1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_JobCardListForSA_JCClosePull;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("pn_jc_module", OracleType.VarChar).Value = pn_jc_module;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_no", OracleType.VarChar).Value = pn_jc_no;

                //Output
                cmd.Parameters.Add("po_jc_status", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_jc_status_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_gst_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_reg_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//New Added
                cmd.Parameters.Add("po_pay_mode", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//New Added
                cmd.Parameters.Add("po_pay_mode_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//New Added

                cmd.Parameters.Add("po_omr", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_type_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_type_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sub_srv_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sub_srv_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_bay_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_bay_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_adv_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_adv_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_group_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_group_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_adv_Cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_adv_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ceo_approval", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_lastflwup_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_lastflwup_csi", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_lastflwup_by", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_type_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_loc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_loc_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_driver", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_driver_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_remarks", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_free_pickup_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mms_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_intial_prom_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_revised_prom_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_jc_close_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_jc_open_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_corp_status", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rdtest_st_time", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rdtest_st_km", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rdtest_end_time", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rdtest_end_km", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_est_sch_labor_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_est_sch_part_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_est_labor_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_est_part_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_re_est_labor_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_re_est_part_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_amc_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_amc_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_amc_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_recall_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_delay_reas_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_delay_reas_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_delay_reas_remarks", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_csi_reas_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_csi_reas_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_csi_reas_remarks", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_part_disc_perc", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_labour_disc_perc", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_disc_auth_by_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_disc_auth_by_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_demand_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_labor_Refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_inv_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_smcard_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_unapprfit_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_tech_camp_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_repair_act_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_comply_dtl_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                //cmd.Parameters.Add("po_vts_card_num", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vts_card_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//Changed

                cmd.Parameters.Add("po_checkin_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cus_out_amt", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pref_followup_time", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_prob_str", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrDemandList;
                OracleDataReader rdrPartList;
                OracleDataReader rdrLaborList;
                OracleDataReader rdrInvList;
                OracleDataReader rdrSmcardList;
                OracleDataReader rdrUnapprfitList;
                OracleDataReader rdrTech_campList;
                OracleDataReader rdrRepair_actList;
                OracleDataReader rdrComply_dtlList;

                rdrDemandList = (OracleDataReader)cmd.Parameters["po_demand_refcur"].Value;
                rdrPartList = (OracleDataReader)cmd.Parameters["po_part_refcur"].Value;
                rdrLaborList = (OracleDataReader)cmd.Parameters["po_labor_Refcur"].Value;
                rdrInvList = (OracleDataReader)cmd.Parameters["po_inv_refcur"].Value;
                rdrSmcardList = (OracleDataReader)cmd.Parameters["po_smcard_refcur"].Value;
                rdrUnapprfitList = (OracleDataReader)cmd.Parameters["po_unapprfit_refcur"].Value;
                rdrTech_campList = (OracleDataReader)cmd.Parameters["po_tech_camp_refcur"].Value;
                rdrRepair_actList = (OracleDataReader)cmd.Parameters["po_repair_act_refcur"].Value;
                rdrComply_dtlList = (OracleDataReader)cmd.Parameters["po_comply_dtl_refcur"].Value;
                #endregion

                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<JobCardClosePull>();

                listDemandList = new List<JCClosePull_DemandList>();
                listPartList = new List<JCClosePull_PartList>();
                listLaborList = new List<JCClosePull_LaborList>();
                listInvList = new List<JCClosePull_InvList>();
                listSmcardList = new List<JCClosePull_SmcardList>();
                listUnapprfitList = new List<JCClosePull_UnapprfitList>();
                listTech_campList = new List<JCClosePull_Tech_campList>();
                listRepair_actList = new List<JCClosePull_Repair_actList>();
                listComply_dtlList = new List<JCClosePull_Comply_dtlList>();

                #region rdrDemandList
                if (rdrDemandList.HasRows)
                {
                    while (rdrDemandList.Read())
                    {
                        listDemandList1 = new JCClosePull_DemandList();
                        listDemandList1.Srl_Num = rdrDemandList["Srl_Num"].ToString();
                        listDemandList1.Demand_Cd = rdrDemandList["Demand_Cd"].ToString();
                        listDemandList1.Demand_Desc = rdrDemandList["Demand_Desc"].ToString();
                        listDemandList1.Reported_by = rdrDemandList["Reported_by"].ToString();
                        listDemandList1.Reported_by_desc = rdrDemandList["Reported_by_desc"].ToString();
                        listDemandList1.Attended_YN = rdrDemandList["Attended_YN"].ToString();
                        listDemandList1.Carry_fwd_YN = rdrDemandList["Carry_fwd_YN"].ToString();
                        listDemandList1.Carry_fwd_YN_desc = rdrDemandList["Carry_fwd_YN_desc"].ToString();
                        listDemandList1.War_YN = rdrDemandList["War_YN"].ToString();
                        listDemandList1.problem_narr = rdrDemandList["problem_narr"].ToString();

                        listDemandList.Add(listDemandList1);
                    }
                }
                #endregion
                #region rdrPartList
                if (rdrPartList.HasRows)
                {
                    while (rdrPartList.Read())
                    {
                        listPartList1 = new JCClosePull_PartList();
                        listPartList1.Srl_Num = rdrPartList["Srl_Num"].ToString();
                        listPartList1.Doc_Num = rdrPartList["Doc_Num"].ToString();
                        listPartList1.Part_Num = rdrPartList["Part_Num"].ToString();
                        listPartList1.Part_Desc = rdrPartList["Part_Desc"].ToString();
                        listPartList1.Req_qty = rdrPartList["Req_qty"].ToString();
                        listPartList1.Issued_qty = rdrPartList["Issued_qty"].ToString();
                        listPartList1.Return_qty = rdrPartList["Return_qty"].ToString();
                        listPartList1.Bill_qty = rdrPartList["Bill_qty"].ToString();
                        listPartList1.Rate = rdrPartList["Rate"].ToString();
                        listPartList1.Total_amt = rdrPartList["Total_amt"].ToString();
                        listPartList1.Bill_type = rdrPartList["Bill_type"].ToString();
                        listPartList1.Bill_type_desc = rdrPartList["Bill_type_desc"].ToString();
                        listPartList1.Auto_depreciation = rdrPartList["Auto_depreciation"].ToString();
                        listPartList1.Disc_ind = rdrPartList["Disc_ind"].ToString();
                        listPartList1.Disc_ind_desc = rdrPartList["Disc_ind_desc"].ToString();
                        listPartList1.Disc_value = rdrPartList["Disc_value"].ToString();
                        listPartList1.Split_ratio = rdrPartList["Split_ratio"].ToString();
                        listPartList1.Split_desc = rdrPartList["Split_desc"].ToString();
                        listPartList1.Cust_per = rdrPartList["Cust_per"].ToString();
                        listPartList1.Ins_per = rdrPartList["Ins_per"].ToString();
                        listPartList1.Dlr_per = rdrPartList["Dlr_per"].ToString();
                        listPartList1.Oem_per = rdrPartList["Oem_per"].ToString();
                        listPartList1.Curr_stock = rdrPartList["Curr_stock"].ToString();

                        listPartList.Add(listPartList1);
                    }
                }
                #endregion
                #region rdrLaborList
                if (rdrLaborList.HasRows)
                {
                    while (rdrLaborList.Read())
                    {
                        listLaborList1 = new JCClosePull_LaborList();
                        listLaborList1.Srl_Num = rdrLaborList["Srl_Num"].ToString();
                        listLaborList1.Labour_Cd = rdrLaborList["Labour_Cd"].ToString();
                        listLaborList1.Labour_Desc = rdrLaborList["Labour_Desc"].ToString();
                        listLaborList1.Mod_yn = rdrLaborList["Mod_yn"].ToString();
                        listLaborList1.Flat_amt = rdrLaborList["Flat_amt"].ToString();
                        listLaborList1.labour_amt = rdrLaborList["labour_amt"].ToString();
                        listLaborList1.FRM_hrs = rdrLaborList["FRM_hrs"].ToString();
                        listLaborList1.Bill_type = rdrLaborList["Bill_type"].ToString();
                        listLaborList1.Bill_type_desc = rdrLaborList["Bill_type_desc"].ToString();
                        listLaborList1.Disc_ind = rdrLaborList["Disc_ind"].ToString();
                        listLaborList1.Disc_ind_desc = rdrLaborList["Disc_ind_desc"].ToString();
                        listLaborList1.Disc_value = rdrLaborList["Disc_value"].ToString();
                        listLaborList1.Split_ratio = rdrLaborList["Split_ratio"].ToString();
                        listLaborList1.Split_desc = rdrLaborList["Split_desc"].ToString();
                        listLaborList1.Cust_per = rdrLaborList["Cust_per"].ToString();
                        listLaborList1.Ins_per = rdrLaborList["Ins_per"].ToString();
                        listLaborList1.Dlr_per = rdrLaborList["Dlr_per"].ToString();
                        listLaborList1.Oem_per = rdrLaborList["Oem_per"].ToString();
                        listLaborList1.Technician = rdrLaborList["Technician"].ToString();
                        listLaborList1.Technician_desc = rdrLaborList["Technician_desc"].ToString();
                        listLaborList1.Technician_2 = rdrLaborList["Technician_2"].ToString();
                        listLaborList1.Technician_2_desc = rdrLaborList["Technician_2_desc"].ToString();
                        listLaborList1.sublet_yn = rdrLaborList["sublet_yn"].ToString();
                        listLaborList1.Sublet_amt = rdrLaborList["Sublet_amt"].ToString();
                        listLaborList1.Sub_cont_cd = rdrLaborList["Sub_cont_cd"].ToString();
                        listLaborList1.Sub_cont_desc = rdrLaborList["Sub_cont_desc"].ToString();

                        listLaborList.Add(listLaborList1);
                    }
                }
                #endregion
                #region rdrInvList
                if (rdrInvList.HasRows)
                {
                    while (rdrInvList.Read())
                    {
                        listInvList1 = new JCClosePull_InvList();
                        listInvList1.Inv_Cd = rdrInvList["Inv_Cd"].ToString();
                        listInvList1.Inv_desc = rdrInvList["Inv_desc"].ToString();
                        listInvList1.Inv_count = rdrInvList["Inv_count"].ToString();
                        listInvList1.Inv_yn = rdrInvList["Inv_yn"].ToString();

                        listInvList.Add(listInvList1);
                    }
                }
                #endregion
                #region rdrSmcardList
                if (rdrSmcardList.HasRows)
                {
                    while (rdrSmcardList.Read())
                    {
                        listSmcardList1 = new JCClosePull_SmcardList();
                        listSmcardList1.Srl_Num = rdrSmcardList["Srl_Num"].ToString();
                        listSmcardList1.Srv_type = rdrSmcardList["Srv_type"].ToString();
                        listSmcardList1.Srv_type_desc = rdrSmcardList["Srv_type_desc"].ToString();
                        listSmcardList1.Srv_cd = rdrSmcardList["Srv_cd"].ToString();
                        listSmcardList1.Srv_desc = rdrSmcardList["Srv_desc"].ToString();
                        listSmcardList1.Part_num = rdrSmcardList["Part_num"].ToString();
                        listSmcardList1.Part_desc = rdrSmcardList["Part_desc"].ToString();
                        listSmcardList1.Srv_qty = rdrSmcardList["Srv_qty"].ToString();
                        listSmcardList1.Accept_yn = rdrSmcardList["Accept_yn"].ToString();
                        listSmcardList1.Accept_yn_desc = rdrSmcardList["Accept_yn_desc"].ToString();
                        listSmcardList1.Reject_reason = rdrSmcardList["Reject_reason"].ToString();
                        listSmcardList1.Reject_reason_desc = rdrSmcardList["Reject_reason_desc"].ToString();
                        listSmcardList1.Accept_qty = rdrSmcardList["Accept_qty"].ToString();

                        listSmcardList.Add(listSmcardList1);
                    }
                }
                #endregion
                #region rdrUnapprfitList
                if (rdrUnapprfitList.HasRows)
                {
                    while (rdrUnapprfitList.Read())
                    {
                        listUnapprfitList1 = new JCClosePull_UnapprfitList();
                        listUnapprfitList1.Srl_Num = rdrUnapprfitList["Srl_Num"].ToString();
                        listUnapprfitList1.Fitment_cd = rdrUnapprfitList["Fitment_cd"].ToString();
                        listUnapprfitList1.Fitment_desc = rdrUnapprfitList["Fitment_desc"].ToString();

                        listUnapprfitList.Add(listUnapprfitList1);
                    }
                }
                #endregion
                #region rdrTech_campList
                if (rdrTech_campList.HasRows)
                {
                    while (rdrTech_campList.Read())
                    {
                        listTech_campList1 = new JCClosePull_Tech_campList();
                        listTech_campList1.Srl_Num = rdrTech_campList["Srl_Num"].ToString();
                        listTech_campList1.Srv_circular_num = rdrTech_campList["Srv_circular_num"].ToString();
                        listTech_campList1.Subject = rdrTech_campList["Subject"].ToString();
                        listTech_campList1.Measure = rdrTech_campList["Measure"].ToString();
                        listTech_campList1.From_date = rdrTech_campList["From_date"].ToString();
                        listTech_campList1.To_date = rdrTech_campList["To_date"].ToString();
                        listTech_campList1.Recall_num = rdrTech_campList["Recall_num"].ToString();
                        listTech_campList1.jc_status = rdrTech_campList["jc_status"].ToString();
                        listTech_campList1.JC_status_desc = rdrTech_campList["JC_status_desc"].ToString();

                        listTech_campList.Add(listTech_campList1);
                    }
                }
                #endregion
                #region rdrRepair_actList
                if (rdrRepair_actList.HasRows)
                {
                    while (rdrRepair_actList.Read())
                    {
                        listRepair_actList1 = new JCClosePull_Repair_actList();
                        listRepair_actList1.Srl_Num = rdrRepair_actList["Srl_Num"].ToString();
                        listRepair_actList1.Demand_cd = rdrRepair_actList["Demand_cd"].ToString();
                        listRepair_actList1.Demand_desc = rdrRepair_actList["Demand_desc"].ToString();
                        listRepair_actList1.Problem_cd = rdrRepair_actList["Problem_cd"].ToString();
                        listRepair_actList1.Problem_desc = rdrRepair_actList["Problem_desc"].ToString();
                        listRepair_actList1.Fault_cd = rdrRepair_actList["Fault_cd"].ToString();
                        listRepair_actList1.Fault_desc = rdrRepair_actList["Fault_desc"].ToString();
                        listRepair_actList1.Action_cd = rdrRepair_actList["Action_cd"].ToString();
                        listRepair_actList1.Action_desc = rdrRepair_actList["Action_desc"].ToString();

                        listRepair_actList.Add(listRepair_actList1);
                    }
                }
                #endregion
                #region rdrComply_dtlList
                if (rdrComply_dtlList.HasRows)
                {
                    while (rdrComply_dtlList.Read())
                    {
                        listComply_dtlList1 = new JCClosePull_Comply_dtlList();
                        listComply_dtlList1.Srl_Num = rdrComply_dtlList["Srl_Num"].ToString();
                        listComply_dtlList1.psf_num = rdrComply_dtlList["psf_num"].ToString();
                        listComply_dtlList1.comp_detls = rdrComply_dtlList["comp_detls"].ToString();
                        listComply_dtlList1.attended_yn = rdrComply_dtlList["attended_yn"].ToString();

                        listComply_dtlList.Add(listComply_dtlList1);
                    }
                }
                #endregion

                listDetail = new JobCardClosePull();
                listDetail.DemandList = listDemandList;
                listDetail.PartList = listPartList;
                listDetail.LaborList = listLaborList;
                listDetail.InvList = listInvList;
                listDetail.SmcardList = listSmcardList;
                listDetail.UnapprfitList = listUnapprfitList;
                listDetail.Tech_campList = listTech_campList;
                listDetail.Repair_actList = listRepair_actList;
                listDetail.Comply_dtlList = listComply_dtlList;

                listDetail.po_jc_status = cmd.Parameters["po_jc_status"].Value.ToString();
                listDetail.po_jc_status_desc = cmd.Parameters["po_jc_status_desc"].Value.ToString();

                listDetail.po_gst_type = cmd.Parameters["po_gst_type"].Value.ToString();

                listDetail.po_reg_num = cmd.Parameters["po_reg_num"].Value.ToString();
                listDetail.po_pay_mode = cmd.Parameters["po_pay_mode"].Value.ToString();
                listDetail.po_pay_mode_desc = cmd.Parameters["po_pay_mode_desc"].Value.ToString();
                listDetail.po_omr = cmd.Parameters["po_omr"].Value.ToString(); //Int
                listDetail.po_srv_type_cd = cmd.Parameters["po_srv_type_cd"].Value.ToString();
                listDetail.po_srv_type_desc = cmd.Parameters["po_srv_type_desc"].Value.ToString();
                listDetail.po_sub_srv_cd = cmd.Parameters["po_sub_srv_cd"].Value.ToString();
                listDetail.po_sub_srv_desc = cmd.Parameters["po_sub_srv_desc"].Value.ToString();
                listDetail.po_bay_cd = cmd.Parameters["po_bay_cd"].Value.ToString();
                listDetail.po_bay_desc = cmd.Parameters["po_bay_desc"].Value.ToString();
                listDetail.po_srv_adv_cd = cmd.Parameters["po_srv_adv_cd"].Value.ToString();
                listDetail.po_srv_adv_desc = cmd.Parameters["po_srv_adv_desc"].Value.ToString();
                listDetail.po_group_cd = cmd.Parameters["po_group_cd"].Value.ToString();
                listDetail.po_group_desc = cmd.Parameters["po_group_desc"].Value.ToString();
                listDetail.po_tech_cd = cmd.Parameters["po_tech_cd"].Value.ToString();
                listDetail.po_tech_desc = cmd.Parameters["po_tech_desc"].Value.ToString();
                listDetail.po_tech_adv_Cd = cmd.Parameters["po_tech_adv_Cd"].Value.ToString();
                listDetail.po_tech_adv_desc = cmd.Parameters["po_tech_adv_desc"].Value.ToString();
                listDetail.po_ceo_approval = cmd.Parameters["po_ceo_approval"].Value.ToString();
                listDetail.po_lastflwup_date = cmd.Parameters["po_lastflwup_date"].Value.ToString();
                listDetail.po_lastflwup_csi = cmd.Parameters["po_lastflwup_csi"].Value.ToString(); //Int
                listDetail.po_lastflwup_by = cmd.Parameters["po_lastflwup_by"].Value.ToString();
                listDetail.po_pickup_type = cmd.Parameters["po_pickup_type"].Value.ToString();
                listDetail.po_pickup_type_desc = cmd.Parameters["po_pickup_type_desc"].Value.ToString();
                listDetail.po_pickup_date = cmd.Parameters["po_pickup_date"].Value.ToString();
                listDetail.po_pickup_loc = cmd.Parameters["po_pickup_loc"].Value.ToString();
                listDetail.po_pickup_loc_desc = cmd.Parameters["po_pickup_loc_desc"].Value.ToString();
                listDetail.po_driver = cmd.Parameters["po_driver"].Value.ToString();
                listDetail.po_driver_desc = cmd.Parameters["po_driver_desc"].Value.ToString();
                listDetail.po_pickup_remarks = cmd.Parameters["po_pickup_remarks"].Value.ToString();
                listDetail.po_free_pickup_yn = cmd.Parameters["po_free_pickup_yn"].Value.ToString();
                listDetail.po_mms_num = cmd.Parameters["po_mms_num"].Value.ToString();
                listDetail.po_intial_prom_date = cmd.Parameters["po_intial_prom_date"].Value.ToString();
                listDetail.po_revised_prom_date = cmd.Parameters["po_revised_prom_date"].Value.ToString();
                listDetail.po_jc_close_date = cmd.Parameters["po_jc_close_date"].Value.ToString();
                listDetail.po_jc_open_date = cmd.Parameters["po_jc_open_date"].Value.ToString();
                listDetail.po_cust_corp_status = cmd.Parameters["po_cust_corp_status"].Value.ToString();
                listDetail.po_rdtest_st_time = cmd.Parameters["po_rdtest_st_time"].Value.ToString(); //Int
                listDetail.po_rdtest_st_km = cmd.Parameters["po_rdtest_st_km"].Value.ToString(); //Int
                listDetail.po_rdtest_end_time = cmd.Parameters["po_rdtest_end_time"].Value.ToString(); //Int
                listDetail.po_rdtest_end_km = cmd.Parameters["po_rdtest_end_km"].Value.ToString(); //Int
                listDetail.po_est_sch_labor_amt = cmd.Parameters["po_est_sch_labor_amt"].Value.ToString(); //Int
                listDetail.po_est_sch_part_amt = cmd.Parameters["po_est_sch_part_amt"].Value.ToString(); //Int
                listDetail.po_est_labor_amt = cmd.Parameters["po_est_labor_amt"].Value.ToString(); //Int
                listDetail.po_est_part_amt = cmd.Parameters["po_est_part_amt"].Value.ToString(); //Int
                listDetail.po_re_est_labor_amt = cmd.Parameters["po_re_est_labor_amt"].Value.ToString(); //Int
                listDetail.po_re_est_part_amt = cmd.Parameters["po_re_est_part_amt"].Value.ToString(); //Int
                listDetail.po_amc_yn = cmd.Parameters["po_amc_yn"].Value.ToString();
                listDetail.po_amc_num = cmd.Parameters["po_amc_num"].Value.ToString();
                listDetail.po_amc_date = cmd.Parameters["po_amc_date"].Value.ToString();
                listDetail.po_recall_yn = cmd.Parameters["po_recall_yn"].Value.ToString();
                listDetail.po_delay_reas_cd = cmd.Parameters["po_delay_reas_cd"].Value.ToString();
                listDetail.po_delay_reas_desc = cmd.Parameters["po_delay_reas_desc"].Value.ToString();
                listDetail.po_delay_reas_remarks = cmd.Parameters["po_delay_reas_remarks"].Value.ToString();
                listDetail.po_csi_reas_cd = cmd.Parameters["po_csi_reas_cd"].Value.ToString();
                listDetail.po_csi_reas_desc = cmd.Parameters["po_csi_reas_desc"].Value.ToString();
                listDetail.po_csi_reas_remarks = cmd.Parameters["po_csi_reas_remarks"].Value.ToString();
                listDetail.po_part_disc_perc = cmd.Parameters["po_part_disc_perc"].Value.ToString(); //Int
                listDetail.po_labour_disc_perc = cmd.Parameters["po_labour_disc_perc"].Value.ToString(); //Int
                listDetail.po_disc_auth_by_cd = cmd.Parameters["po_disc_auth_by_cd"].Value.ToString();
                listDetail.po_disc_auth_by_desc = cmd.Parameters["po_disc_auth_by_desc"].Value.ToString();
                listDetail.po_vts_card_num = cmd.Parameters["po_vts_card_num"].Value.ToString(); //Int
                listDetail.po_checkin_date = cmd.Parameters["po_checkin_date"].Value.ToString();
                listDetail.po_cus_out_amt = cmd.Parameters["po_cus_out_amt"].Value.ToString(); //Int
                listDetail.po_pref_followup_time = cmd.Parameters["po_pref_followup_time"].Value.ToString();
                listDetail.po_prob_str = cmd.Parameters["po_prob_str"].Value.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }
            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_JobCardClosePull");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardClosePush
        public BaseListReturnType<JobCardClosePush> JobCardClosePush(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_demand_ins_str, string pn_repair_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_mcard_ins_str, string pn_tcamp_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_rtest_startime, string pn_rtest_startkm, string pn_rtest_endtime, string pn_rtest_endkm, string pn_delay_reas_cd, string pn_delay_reas_rem, string pn_csi_reas_cd, string pn_csi_reas_rem, string pn_disc_part_perc, string pn_disc_labour_perc, string pn_disc_auth_by)
        {
            //string pn_gst_type

            BaseListReturnType<JobCardClosePush> response = new BaseListReturnType<JobCardClosePush>();

            JobCardClosePush result = new JobCardClosePush();

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
                cmd.CommandText = Usp_JobCardClosePush;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_num", OracleType.VarChar).Value = pn_jc_num;
                cmd.Parameters.Add("pn_srv_cat_cd", OracleType.VarChar).Value = pn_srv_cat_cd;
                cmd.Parameters.Add("pn_sub_srv_type_cd", OracleType.VarChar).Value = pn_sub_srv_type_cd;
                cmd.Parameters.Add("pn_payment_mode", OracleType.VarChar).Value = pn_payment_mode;
                cmd.Parameters.Add("pn_sa_adv", OracleType.VarChar).Value = pn_sa_adv;
                //cmd.Parameters.Add("pn_gst_type", OracleType.VarChar).Value = pn_gst_type;
                cmd.Parameters.Add("pn_tech_adv", OracleType.VarChar).Value = pn_tech_adv;
                cmd.Parameters.Add("pn_bay_cd", OracleType.VarChar).Value = pn_bay_cd;
                cmd.Parameters.Add("pn_group_cd", OracleType.VarChar).Value = pn_group_cd;
                cmd.Parameters.Add("pn_tech_cd", OracleType.VarChar).Value = pn_tech_cd;

                cmd.Parameters.Add("pn_demand_ins_str", OracleType.VarChar).Value = pn_demand_ins_str;
                cmd.Parameters.Add("pn_repair_ins_str", OracleType.VarChar).Value = pn_repair_ins_str;
                cmd.Parameters.Add("pn_part_ins_str", OracleType.VarChar).Value = pn_part_ins_str;
                cmd.Parameters.Add("pn_labor_ins_str", OracleType.VarChar).Value = pn_labor_ins_str;
                cmd.Parameters.Add("pn_mcard_ins_str", OracleType.VarChar).Value = pn_mcard_ins_str;
                cmd.Parameters.Add("pn_tcamp_ins_str", OracleType.VarChar).Value = pn_tcamp_ins_str;

                cmd.Parameters.Add("pn_pickup_type", OracleType.VarChar).Value = pn_pickup_type;
                cmd.Parameters.Add("pn_pickup_date", OracleType.VarChar).Value = pn_pickup_date;
                cmd.Parameters.Add("pn_free_pikcup_flag", OracleType.VarChar).Value = pn_free_pikcup_flag;
                cmd.Parameters.Add("pn_pickup_loc_cd", OracleType.VarChar).Value = pn_pickup_loc_cd;
                cmd.Parameters.Add("pn_pickup_driver", OracleType.VarChar).Value = pn_pickup_driver;
                cmd.Parameters.Add("pn_pikcup_remarks", OracleType.VarChar).Value = pn_pikcup_remarks;
                cmd.Parameters.Add("pn_mms_num", OracleType.VarChar).Value = pn_mms_num;

                cmd.Parameters.Add("pn_rtest_startime", OracleType.Number).Value = Convert.ToInt32(pn_rtest_startime);
                cmd.Parameters.Add("pn_rtest_startkm", OracleType.Number).Value = Convert.ToInt32(pn_rtest_startkm);
                cmd.Parameters.Add("pn_rtest_endtime", OracleType.Number).Value = Convert.ToInt32(pn_rtest_endtime);
                cmd.Parameters.Add("pn_rtest_endkm", OracleType.Number).Value = Convert.ToInt32(pn_rtest_endkm);

                cmd.Parameters.Add("pn_delay_reas_cd", OracleType.VarChar).Value = pn_delay_reas_cd;
                cmd.Parameters.Add("pn_delay_reas_rem", OracleType.VarChar).Value = pn_delay_reas_rem;
                cmd.Parameters.Add("pn_csi_reas_cd", OracleType.VarChar).Value = pn_csi_reas_cd;
                cmd.Parameters.Add("pn_csi_reas_rem", OracleType.VarChar).Value = pn_csi_reas_rem;
                cmd.Parameters.Add("pn_disc_part_perc", OracleType.Number).Value = Convert.ToInt32(pn_disc_part_perc);
                cmd.Parameters.Add("pn_disc_labour_perc", OracleType.Number).Value = Convert.ToInt32(pn_disc_labour_perc);
                cmd.Parameters.Add("pn_disc_auth_by", OracleType.VarChar).Value = pn_disc_auth_by;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }


                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //response.result = result;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_JobCardClosePush");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetResponse
        public BaseListReturnType<MyCalls_GetResponse> MyCallsGetResponse()
        {
            BaseListReturnType<MyCalls_GetResponse> response = new BaseListReturnType<MyCalls_GetResponse>();

            MyCalls_GetResponse Typedetail = null;
            List<MyCalls_GetResponse> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetResponse;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_response_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetResponse>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetResponse();

                            Typedetail.response_type = Convert.ToString(row["response_type"]);
                            Typedetail.response_cd = Convert.ToString(row["response_cd"]);
                            Typedetail.response_desc = Convert.ToString(row["response_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetResponse");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetRating
        public BaseListReturnType<MyCalls_GetRating> MyCallsGetRating()
        {
            BaseListReturnType<MyCalls_GetRating> response = new BaseListReturnType<MyCalls_GetRating>();

            MyCalls_GetRating Typedetail = null;
            List<MyCalls_GetRating> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetRating;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_rating_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetRating>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetRating();

                            Typedetail.rating_Cd = Convert.ToString(row["rating_Cd"]);
                            Typedetail.rating_desc = Convert.ToString(row["rating_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetRating");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetFollowStatus
        public BaseListReturnType<MyCalls_GetFollowStatus> MyCallsGetFollowStatus()
        {
            BaseListReturnType<MyCalls_GetFollowStatus> response = new BaseListReturnType<MyCalls_GetFollowStatus>();

            MyCalls_GetFollowStatus Typedetail = null;
            List<MyCalls_GetFollowStatus> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetFollowStatus;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_fstatus_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetFollowStatus>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetFollowStatus();

                            Typedetail.status_Cd = Convert.ToString(row["status_Cd"]);
                            Typedetail.status_desc = Convert.ToString(row["status_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetFollowStatus");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetPSFDissatisfiedReason
        public BaseListReturnType<MyCalls_GetPSFDissatisfiedReason> MyCallsGetPSFDissatisfiedReason()
        {
            BaseListReturnType<MyCalls_GetPSFDissatisfiedReason> response = new BaseListReturnType<MyCalls_GetPSFDissatisfiedReason>();

            MyCalls_GetPSFDissatisfiedReason Typedetail = null;
            List<MyCalls_GetPSFDissatisfiedReason> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetPSFDissatisfiedReason;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_disreason_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetPSFDissatisfiedReason>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetPSFDissatisfiedReason();

                            Typedetail.disreason_cd = Convert.ToString(row["disreason_cd"]);
                            Typedetail.disreason_desc = Convert.ToString(row["disreason_desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetPSFDissatisfiedReason");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetSrvMod
        public BaseListReturnType<MyCalls_GetSrvMod> MyCallsGetSrvMod()
        {
            BaseListReturnType<MyCalls_GetSrvMod> response = new BaseListReturnType<MyCalls_GetSrvMod>();

            MyCalls_GetSrvMod Typedetail = null;
            List<MyCalls_GetSrvMod> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetSrvMod;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_srv_mod_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetSrvMod>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetSrvMod();

                            Typedetail.mode_Cd = Convert.ToString(row["mode_Cd"]);
                            Typedetail.mode_Desc = Convert.ToString(row["mode_Desc"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetSrvMod");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetScript
        public BaseListReturnType<MyCalls_GetScript> MyCallsGetScript()
        {
            BaseListReturnType<MyCalls_GetScript> response = new BaseListReturnType<MyCalls_GetScript>();

            MyCalls_GetScript Typedetail = null;
            List<MyCalls_GetScript> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MyCalls_GetScript;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("po_script_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MyCalls_GetScript>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MyCalls_GetScript();

                            Typedetail.script_type = Convert.ToString(row["script_type"]);
                            Typedetail.script = Convert.ToString(row["script"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetScript");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetPSFCustHDR
        public BaseListReturnType<MyCalls_GetPSFCustHDR> MyCallsGetPSFCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date, string pn_followup_Cd, string pn_psf_days)
        {
            BaseListReturnType<MyCalls_GetPSFCustHDR> response = new BaseListReturnType<MyCalls_GetPSFCustHDR>();

            List<MyCalls_GetPSFCustHDR> MainALLDetailsList;
            MyCalls_GetPSFCustHDR listDetail = null;

            List<MyCalls_PSFDash> listMyCalls_PSFDashList = new List<MyCalls_PSFDash>();
            MyCalls_PSFDash listMyCalls_PSFDashList1;

            List<MyCalls_CustomerResponse> listMyCalls_CustomerResponseList = new List<MyCalls_CustomerResponse>();
            MyCalls_CustomerResponse listMyCalls_CustomerResponseList1;

            Int32 ipsf_Generated_Count = 0;
            Int32 ipsf_Close_Count = 0;
            Int32 ipsf_Open_Count = 0;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MyCalls_GetPSFCustHDR;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_Date", OracleType.VarChar).Value = pn_to_Date;
                cmd.Parameters.Add("pn_followup_Cd", OracleType.VarChar).Value = pn_followup_Cd;
                cmd.Parameters.Add("pn_psf_days", OracleType.VarChar).Value = pn_psf_days;

                cmd.Parameters.Add("po_psf_dash_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_cust_response", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrMyCalls_PSFDash;
                OracleDataReader rdrMyCalls_CustomerResponse;

                rdrMyCalls_PSFDash = (OracleDataReader)cmd.Parameters["po_psf_dash_refcur"].Value;
                rdrMyCalls_CustomerResponse = (OracleDataReader)cmd.Parameters["po_cust_response"].Value;

                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<MyCalls_GetPSFCustHDR>();

                listMyCalls_PSFDashList = new List<MyCalls_PSFDash>();
                listMyCalls_CustomerResponseList = new List<MyCalls_CustomerResponse>();

                #region rdrMyCalls_PSFDash
                if (rdrMyCalls_PSFDash.HasRows)
                {
                    while (rdrMyCalls_PSFDash.Read())
                    {
                        listMyCalls_PSFDashList1 = new MyCalls_PSFDash();
                        listMyCalls_PSFDashList1.sr_no = rdrMyCalls_PSFDash["sr_no"].ToString();
                        listMyCalls_PSFDashList1.cust_name = rdrMyCalls_PSFDash["cust_name"].ToString();
                        listMyCalls_PSFDashList1.Cust_cd = rdrMyCalls_PSFDash["Cust_cd"].ToString();
                        listMyCalls_PSFDashList1.reg_num = rdrMyCalls_PSFDash["reg_num"].ToString();
                        listMyCalls_PSFDashList1.vin = rdrMyCalls_PSFDash["vin"].ToString();
                        listMyCalls_PSFDashList1.model_desc = rdrMyCalls_PSFDash["model_desc"].ToString();
                        listMyCalls_PSFDashList1.Sale_Date = rdrMyCalls_PSFDash["Sale_Date"].ToString();
                        listMyCalls_PSFDashList1.contact_no = rdrMyCalls_PSFDash["contact_no"].ToString();
                        listMyCalls_PSFDashList1.email_id = rdrMyCalls_PSFDash["email_id"].ToString();
                        listMyCalls_PSFDashList1.followup_date = rdrMyCalls_PSFDash["followup_date"].ToString();
                        listMyCalls_PSFDashList1.followup_day = rdrMyCalls_PSFDash["followup_day"].ToString();
                        listMyCalls_PSFDashList1.followup_type = rdrMyCalls_PSFDash["followup_type"].ToString();
                        listMyCalls_PSFDashList1.psf_num = rdrMyCalls_PSFDash["psf_num"].ToString();
                        listMyCalls_PSFDashList1.list_cd = rdrMyCalls_PSFDash["list_cd"].ToString();
                        listMyCalls_PSFDashList1.list_desc = rdrMyCalls_PSFDash["list_desc"].ToString();
                        listMyCalls_PSFDashList1.status_cd = rdrMyCalls_PSFDash["status_cd"].ToString();

                        if (rdrMyCalls_PSFDash["status_cd"].ToString().Trim().ToLower() == "c")
                        {
                            ipsf_Generated_Count = ipsf_Generated_Count + 1;

                            ipsf_Close_Count = ipsf_Close_Count + 1;
                        }
                        else if (rdrMyCalls_PSFDash["status_cd"].ToString().Trim().ToLower() == "nc")
                        {
                            ipsf_Generated_Count = ipsf_Generated_Count + 1;

                            ipsf_Open_Count = ipsf_Open_Count + 1;
                        }

                        listMyCalls_PSFDashList1.status_Desc = rdrMyCalls_PSFDash["status_Desc"].ToString();
                        listMyCalls_PSFDashList1.satisfied_flag = rdrMyCalls_PSFDash["satisfied_flag"].ToString();
                        listMyCalls_PSFDashList1.emp_Cd = rdrMyCalls_PSFDash["emp_Cd"].ToString();
                        listMyCalls_PSFDashList1.sub_srv_rcateg = rdrMyCalls_PSFDash["sub_srv_rcateg"].ToString();

                        listMyCalls_PSFDashList.Add(listMyCalls_PSFDashList1);
                    }
                }
                #endregion

                #region rdrMyCalls_CustomerResponse
                if (rdrMyCalls_CustomerResponse.HasRows)
                {
                    while (rdrMyCalls_CustomerResponse.Read())
                    {
                        listMyCalls_CustomerResponseList1 = new MyCalls_CustomerResponse();
                        listMyCalls_CustomerResponseList1.ROWNUM = rdrMyCalls_CustomerResponse["ROWNUM"].ToString();
                        listMyCalls_CustomerResponseList1.list_code = rdrMyCalls_CustomerResponse["list_code"].ToString();
                        listMyCalls_CustomerResponseList1.list_desc = rdrMyCalls_CustomerResponse["list_desc"].ToString();

                        listMyCalls_CustomerResponseList.Add(listMyCalls_CustomerResponseList1);
                    }
                }
                #endregion

                listDetail = new MyCalls_GetPSFCustHDR();
                listDetail.MyCalls_PSFDash = listMyCalls_PSFDashList;
                listDetail.MyCalls_CustomerResponse = listMyCalls_CustomerResponseList;

                listDetail.psf_Generated_Count = ipsf_Generated_Count.ToString();
                listDetail.psf_Close_Count = ipsf_Close_Count.ToString();
                listDetail.psf_Open_Count = ipsf_Open_Count.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetPSFCustHDR");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetSMRWelcomeCustHDR
        public BaseListReturnType<MyCalls_GetSMRWelcomeCustHDR> MyCallsGetSMRWelcomeCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date)
        {
            BaseListReturnType<MyCalls_GetSMRWelcomeCustHDR> response = new BaseListReturnType<MyCalls_GetSMRWelcomeCustHDR>();

            List<MyCalls_GetSMRWelcomeCustHDR> MainALLDetailsList;
            MyCalls_GetSMRWelcomeCustHDR listDetail = null;

            List<MyCalls_SMRDash> listMyCalls_SMRDashList = new List<MyCalls_SMRDash>();
            MyCalls_SMRDash listMyCalls_SMRDashList1;

            List<MyCalls_WelcomeDash> listMyCalls_WelcomeDashList = new List<MyCalls_WelcomeDash>();
            MyCalls_WelcomeDash listMyCalls_WelcomeDashList1;

            Int32 ismr_Generated_Count = 0;
            Int32 ismr_Close_Count = 0;
            Int32 ismr_Open_Count = 0;

            Int32 iwelcome_Generated_Count = 0;
            Int32 iwelcome_Close_Count = 0;
            Int32 iwelcome_Open_Count = 0;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MyCalls_GetSMRWelcomeCustHDR;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_Date", OracleType.VarChar).Value = pn_to_Date;

                cmd.Parameters.Add("po_srv_dash_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_srv_call_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrMyCalls_SMRDash;
                OracleDataReader rdrMyCalls_WelcomeDash;

                rdrMyCalls_SMRDash = (OracleDataReader)cmd.Parameters["po_srv_dash_refcur"].Value;
                rdrMyCalls_WelcomeDash = (OracleDataReader)cmd.Parameters["po_srv_call_refcur"].Value;

                #endregion
                #region In case of Error
                //if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                //{
                //    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                //    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                //    response.result = null;
                //    con.Close();
                //    cmd.Dispose();
                //    return response;
                //}
                #endregion
                // con.Close();

                MainALLDetailsList = new List<MyCalls_GetSMRWelcomeCustHDR>();

                listMyCalls_SMRDashList = new List<MyCalls_SMRDash>();
                listMyCalls_WelcomeDashList = new List<MyCalls_WelcomeDash>();

                #region rdrMyCalls_SMRDash
                if (rdrMyCalls_SMRDash.HasRows)
                {
                    while (rdrMyCalls_SMRDash.Read())
                    {
                        listMyCalls_SMRDashList1 = new MyCalls_SMRDash();
                        listMyCalls_SMRDashList1.sr_no = rdrMyCalls_SMRDash["sr_no"].ToString();
                        listMyCalls_SMRDashList1.cust_name = rdrMyCalls_SMRDash["cust_name"].ToString();
                        listMyCalls_SMRDashList1.Cust_cd = rdrMyCalls_SMRDash["Cust_cd"].ToString();
                        listMyCalls_SMRDashList1.reg_num = rdrMyCalls_SMRDash["reg_num"].ToString();
                        listMyCalls_SMRDashList1.vin = rdrMyCalls_SMRDash["vin"].ToString();
                        listMyCalls_SMRDashList1.model_desc = rdrMyCalls_SMRDash["model_desc"].ToString();
                        listMyCalls_SMRDashList1.Sale_Date = rdrMyCalls_SMRDash["Sale_Date"].ToString();
                        listMyCalls_SMRDashList1.contact_no = rdrMyCalls_SMRDash["contact_no"].ToString();
                        listMyCalls_SMRDashList1.email_id = rdrMyCalls_SMRDash["email_id"].ToString();
                        listMyCalls_SMRDashList1.followup_date = rdrMyCalls_SMRDash["followup_date"].ToString();
                        listMyCalls_SMRDashList1.srv_type_cd = rdrMyCalls_SMRDash["srv_type_cd"].ToString();
                        listMyCalls_SMRDashList1.sub_Srv_type_desc = rdrMyCalls_SMRDash["sub_Srv_type_desc"].ToString();
                        listMyCalls_SMRDashList1.list_cd = rdrMyCalls_SMRDash["list_cd"].ToString();
                        listMyCalls_SMRDashList1.list_desc = rdrMyCalls_SMRDash["list_desc"].ToString();
                        listMyCalls_SMRDashList1.list_updateable = rdrMyCalls_SMRDash["list_updateable"].ToString();

                        if (rdrMyCalls_SMRDash["list_updateable"].ToString().Trim().ToLower() == "y")
                        {
                            ismr_Generated_Count = ismr_Generated_Count + 1;

                            ismr_Close_Count = ismr_Close_Count + 1;
                        }
                        else if (rdrMyCalls_SMRDash["list_updateable"].ToString().Trim().ToLower() == "n")
                        {
                            ismr_Generated_Count = ismr_Generated_Count + 1;

                            ismr_Open_Count = ismr_Open_Count + 1;
                        }

                        listMyCalls_SMRDashList1.Psf_Num = rdrMyCalls_SMRDash["Psf_Num"].ToString();
                        listMyCalls_SMRDashList1.followup_type = rdrMyCalls_SMRDash["followup_type"].ToString();
                        listMyCalls_SMRDashList1.emp_Cd = rdrMyCalls_SMRDash["emp_Cd"].ToString();

                        listMyCalls_SMRDashList1.NEXA_VEH = rdrMyCalls_SMRDash["NEXA_VEH"].ToString();

                        listMyCalls_SMRDashList.Add(listMyCalls_SMRDashList1);
                    }
                }
                #endregion

                #region rdrMyCalls_WelcomeDash
                if (rdrMyCalls_WelcomeDash.HasRows)
                {
                    while (rdrMyCalls_WelcomeDash.Read())
                    {
                        listMyCalls_WelcomeDashList1 = new MyCalls_WelcomeDash();
                        listMyCalls_WelcomeDashList1.sr_no = rdrMyCalls_WelcomeDash["sr_no"].ToString();
                        listMyCalls_WelcomeDashList1.cust_name = rdrMyCalls_WelcomeDash["cust_name"].ToString();
                        listMyCalls_WelcomeDashList1.Cust_cd = rdrMyCalls_WelcomeDash["Cust_cd"].ToString();
                        listMyCalls_WelcomeDashList1.reg_num = rdrMyCalls_WelcomeDash["reg_num"].ToString();
                        listMyCalls_WelcomeDashList1.vin = rdrMyCalls_WelcomeDash["vin"].ToString();
                        listMyCalls_WelcomeDashList1.model_desc = rdrMyCalls_WelcomeDash["model_desc"].ToString();
                        listMyCalls_WelcomeDashList1.Sale_Date = rdrMyCalls_WelcomeDash["Sale_Date"].ToString();
                        listMyCalls_WelcomeDashList1.contact_no = rdrMyCalls_WelcomeDash["contact_no"].ToString();
                        listMyCalls_WelcomeDashList1.email_id = rdrMyCalls_WelcomeDash["email_id"].ToString();
                        listMyCalls_WelcomeDashList1.followup_date = rdrMyCalls_WelcomeDash["followup_date"].ToString();
                        listMyCalls_WelcomeDashList1.list_cd = rdrMyCalls_WelcomeDash["list_cd"].ToString();
                        listMyCalls_WelcomeDashList1.list_desc = rdrMyCalls_WelcomeDash["list_desc"].ToString();
                        listMyCalls_WelcomeDashList1.followup_type = rdrMyCalls_WelcomeDash["followup_type"].ToString();
                        listMyCalls_WelcomeDashList1.psf_num = rdrMyCalls_WelcomeDash["psf_num"].ToString();
                        listMyCalls_WelcomeDashList1.status_cd = rdrMyCalls_WelcomeDash["status_cd"].ToString();

                        if (rdrMyCalls_WelcomeDash["status_cd"].ToString().Trim().ToLower() == "d")
                        {
                            iwelcome_Generated_Count = iwelcome_Generated_Count + 1;

                            iwelcome_Close_Count = iwelcome_Close_Count + 1;
                        }
                        else if (rdrMyCalls_WelcomeDash["status_cd"].ToString().Trim().ToLower() == "p")
                        {
                            iwelcome_Generated_Count = iwelcome_Generated_Count + 1;

                            iwelcome_Open_Count = iwelcome_Open_Count + 1;
                        }

                        listMyCalls_WelcomeDashList1.status_Desc = rdrMyCalls_WelcomeDash["status_Desc"].ToString();
                        listMyCalls_WelcomeDashList1.updateable = rdrMyCalls_WelcomeDash["updateable"].ToString();
                        listMyCalls_WelcomeDashList1.emp_Cd = rdrMyCalls_WelcomeDash["emp_Cd"].ToString();

                        listMyCalls_WelcomeDashList1.NEXA_VEH = rdrMyCalls_WelcomeDash["NEXA_VEH"].ToString();


                        listMyCalls_WelcomeDashList.Add(listMyCalls_WelcomeDashList1);
                    }
                }
                #endregion

                listDetail = new MyCalls_GetSMRWelcomeCustHDR();
                listDetail.MyCalls_SMRDash = listMyCalls_SMRDashList;
                listDetail.MyCalls_WelcomeDash = listMyCalls_WelcomeDashList;

                listDetail.smr_Generated_Count = ismr_Generated_Count.ToString();
                listDetail.smr_Close_Count = ismr_Close_Count.ToString();
                listDetail.smr_Open_Count = ismr_Open_Count.ToString();

                listDetail.welcome_Generated_Count = iwelcome_Generated_Count.ToString();
                listDetail.welcome_Close_Count = iwelcome_Close_Count.ToString();
                listDetail.welcome_Open_Count = iwelcome_Open_Count.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetSMRWelcomeCustHDR");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetSrvCustomerDetail
        public BaseListReturnType<MyCalls_GetSrvCustomerDetail> MyCallsGetSrvCustomerDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_cust_cd, string pn_vin, string pn_followup_type, string pn_psf_num)
        {
            //string err1 = string.Empty;
            //string err2 = string.Empty;
            //string err3 = string.Empty;
            //string err4 = string.Empty;
            //string err5 = string.Empty;
            //string err6 = string.Empty;
            //string err7 = string.Empty;
            //string err8 = string.Empty;
            //string err9 = string.Empty;
            //string err10 = string.Empty;
            //string err11 = string.Empty;
            //string err12 = string.Empty;
            //string err13 = string.Empty;
            //string err14 = string.Empty;
            //string err15 = string.Empty;
            //string err16 = string.Empty;
            //string err17 = string.Empty;
            //string err18 = string.Empty;
            //string err19 = string.Empty;
            //string err20 = string.Empty;
            //string err21 = string.Empty;
            //string err22 = string.Empty;
            //string err23 = string.Empty;
            //string err24 = string.Empty;
            //string err25 = string.Empty;
            //string err26 = string.Empty;
            //string err27 = string.Empty;
            //string err28 = string.Empty;
            //string err29 = string.Empty;
            //string err30 = string.Empty;
            //string err31 = string.Empty;
            //string err32 = string.Empty;
            //string err33 = string.Empty;
            //string err34 = string.Empty;
            //string err35 = string.Empty;
            //string err36 = string.Empty;
            //string err37 = string.Empty;
            //string err38 = string.Empty;
            //string err39 = string.Empty;
            //string err40 = string.Empty;
            //string err41 = string.Empty;
            //string err42 = string.Empty;
            //string err43 = string.Empty;
            //string err44 = string.Empty;
            //string err45 = string.Empty;
            //string err46 = string.Empty;
            //string err47 = string.Empty;
            //string err48 = string.Empty;
            //string err49 = string.Empty;
            //string err50 = string.Empty;
            //string err51 = string.Empty;
            //string err52 = string.Empty;

            //err15 = " Method Objects Start ";

            BaseListReturnType<MyCalls_GetSrvCustomerDetail> response = new BaseListReturnType<MyCalls_GetSrvCustomerDetail>();

            List<MyCalls_GetSrvCustomerDetail> MainALLDetailsList;
            MyCalls_GetSrvCustomerDetail listDetail = null;

            List<MyCalls_CustomerVehicleDet> listMyCalls_CustomerVehicleDetList = new List<MyCalls_CustomerVehicleDet>();
            List<MyCalls_LastFollowUp> listMyCalls_LastFollowUpList = new List<MyCalls_LastFollowUp>();
            List<MyCalls_JCDetails> listMyCalls_JCDetailsList = new List<MyCalls_JCDetails>();
            List<MyCalls_PendingComplaints> listMyCalls_PendingComplaintsList = new List<MyCalls_PendingComplaints>();
            List<MyCalls_FollowUp> listMyCalls_FollowUpList = new List<MyCalls_FollowUp>();
            List<MyCalls_PSFFollowUp> listMyCalls_PSFFollowUpList = new List<MyCalls_PSFFollowUp>();

            MyCalls_CustomerVehicleDet listMyCalls_CustomerVehicleDetList1;
            MyCalls_LastFollowUp listMyCalls_LastFollowUpList1;
            MyCalls_JCDetails listMyCalls_JCDetailsList1;
            MyCalls_PendingComplaints listMyCalls_PendingComplaintsList1;
            MyCalls_FollowUp listMyCalls_FollowUpList1;
            MyCalls_PSFFollowUp listMyCalls_PSFFollowUpList1;

            //err16 = " Method Objects End ";

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                //err17 = " Token Error ";

                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            //err18 = " Token Success ";

            try
            {
                #region Connection and Bind Data in Dataset
                //err19 = " Connection Start ";

                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MyCalls_GetSrvCustomerDetail;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_cust_cd", OracleType.VarChar).Value = pn_cust_cd;
                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;
                cmd.Parameters.Add("pn_followup_type", OracleType.VarChar).Value = pn_followup_type;
                cmd.Parameters.Add("pn_psf_num", OracleType.VarChar).Value = pn_psf_num;

                //output cursor
                cmd.Parameters.Add("po_custveh_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_last_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_jc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_pending_complaints", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                //Output
                cmd.Parameters.Add("po_bkg_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_bkg_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_req", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_free_pickup", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_loc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_driver", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pickup_remarks", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //output cursor
                cmd.Parameters.Add("po_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                //Output
                cmd.Parameters.Add("po_satisified_flag", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_voice_cust", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //output cursor
                cmd.Parameters.Add("po_psf_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 8000).Direction = ParameterDirection.Output;

                //err20 = " Parameters Defined End ";

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //err22 = " Connection Now Open ";
                //err23 = " Connection ExecuteNonQuery Start ";

                cmd.ExecuteNonQuery();

                //err24 = " Connection ExecuteNonQuery End ";

                OracleDataReader rdrMyCalls_CustomerVehicleDet;
                OracleDataReader rdrMyCalls_LastFollowUp;
                OracleDataReader rdrMyCalls_JCDetails;
                OracleDataReader rdrMyCalls_PendingComplaints;
                OracleDataReader rdrMyCalls_FollowUp;
                OracleDataReader rdrMyCalls_PSFFollowUp;

                rdrMyCalls_CustomerVehicleDet = (OracleDataReader)cmd.Parameters["po_custveh_refcur"].Value;
                rdrMyCalls_LastFollowUp = (OracleDataReader)cmd.Parameters["po_last_followup_refcur"].Value;
                rdrMyCalls_JCDetails = (OracleDataReader)cmd.Parameters["po_jc_refcur"].Value;
                rdrMyCalls_PendingComplaints = (OracleDataReader)cmd.Parameters["po_pending_complaints"].Value;
                rdrMyCalls_FollowUp = (OracleDataReader)cmd.Parameters["po_followup_refcur"].Value;
                rdrMyCalls_PSFFollowUp = (OracleDataReader)cmd.Parameters["po_psf_followup_refcur"].Value;

                //err25 = " Assigned Values to Cursor ";
                #endregion

                #region In case of Error
                //if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                //{
                //    //err1 = " In case of Error";

                //    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                //    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                //    //response.message = cmd.Parameters["po_err_msg"].Value.ToString() + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14;
                //    response.result = null;
                //    con.Close();
                //    cmd.Dispose();
                //    return response;
                //}
                #endregion
                // con.Close();

                MainALLDetailsList = new List<MyCalls_GetSrvCustomerDetail>();

                listMyCalls_CustomerVehicleDetList = new List<MyCalls_CustomerVehicleDet>();
                listMyCalls_LastFollowUpList = new List<MyCalls_LastFollowUp>();
                listMyCalls_JCDetailsList = new List<MyCalls_JCDetails>();
                listMyCalls_PendingComplaintsList = new List<MyCalls_PendingComplaints>();
                listMyCalls_FollowUpList = new List<MyCalls_FollowUp>();
                listMyCalls_PSFFollowUpList = new List<MyCalls_PSFFollowUp>();

                #region rdrMyCalls_CustomerVehicleDet
                //err2 = " Before Reader rdrMyCalls_CustomerVehicleDet";
                if (rdrMyCalls_CustomerVehicleDet.HasRows)
                {
                    //err3 = " Reader rdrMyCalls_CustomerVehicleDet Has Rows";
                    while (rdrMyCalls_CustomerVehicleDet.Read())
                    {
                        //err4 = " Start While of Reader rdrMyCalls_CustomerVehicleDet";

                        listMyCalls_CustomerVehicleDetList1 = new MyCalls_CustomerVehicleDet();
                        listMyCalls_CustomerVehicleDetList1.cust_name = rdrMyCalls_CustomerVehicleDet["cust_name"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone = rdrMyCalls_CustomerVehicleDet["phone"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone_m = rdrMyCalls_CustomerVehicleDet["phone_m"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone_o = rdrMyCalls_CustomerVehicleDet["phone_o"].ToString();
                        listMyCalls_CustomerVehicleDetList1.email = rdrMyCalls_CustomerVehicleDet["email"].ToString();
                        listMyCalls_CustomerVehicleDetList1.category = rdrMyCalls_CustomerVehicleDet["category"].ToString();
                        listMyCalls_CustomerVehicleDetList1.contact_person = rdrMyCalls_CustomerVehicleDet["contact_person"].ToString();
                        listMyCalls_CustomerVehicleDetList1.preferred_time = rdrMyCalls_CustomerVehicleDet["preferred_time"].ToString();
                        listMyCalls_CustomerVehicleDetList1.reg_num = rdrMyCalls_CustomerVehicleDet["reg_num"].ToString();
                        listMyCalls_CustomerVehicleDetList1.vehicle_model = rdrMyCalls_CustomerVehicleDet["vehicle_model"].ToString();
                        listMyCalls_CustomerVehicleDetList1.vehicle_variant = rdrMyCalls_CustomerVehicleDet["vehicle_variant"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Sale_Date = rdrMyCalls_CustomerVehicleDet["Sale_Date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.color_desc = rdrMyCalls_CustomerVehicleDet["color_desc"].ToString();
                        listMyCalls_CustomerVehicleDetList1.VIN = rdrMyCalls_CustomerVehicleDet["VIN"].ToString();
                        listMyCalls_CustomerVehicleDetList1.RM = rdrMyCalls_CustomerVehicleDet["RM"].ToString();
                        listMyCalls_CustomerVehicleDetList1.EW = rdrMyCalls_CustomerVehicleDet["EW"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Service_Type = rdrMyCalls_CustomerVehicleDet["Service_Type"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Due_Date = rdrMyCalls_CustomerVehicleDet["Due_Date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_date = rdrMyCalls_CustomerVehicleDet["last_srv_date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_type = rdrMyCalls_CustomerVehicleDet["last_srv_type"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_mileage = rdrMyCalls_CustomerVehicleDet["last_srv_mileage"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_psf_status = rdrMyCalls_CustomerVehicleDet["last_psf_status"].ToString();

                        listMyCalls_CustomerVehicleDetList.Add(listMyCalls_CustomerVehicleDetList1);

                        //err5 = " End While of Reader rdrMyCalls_CustomerVehicleDet";
                    }
                }
                #endregion
                #region rdrMyCalls_LastFollowUp
                //err31 = " Before Reader rdrMyCalls_LastFollowUp";
                if (rdrMyCalls_LastFollowUp.HasRows)
                {
                    //err32 = " Reader rdrMyCalls_LastFollowUp Has Rows";
                    while (rdrMyCalls_LastFollowUp.Read())
                    {
                        //err33 = " Start While of Reader rdrMyCalls_LastFollowUp";

                        listMyCalls_LastFollowUpList1 = new MyCalls_LastFollowUp();
                        //listMyCalls_LastFollowUpList1.followup_no = rdrMyCalls_LastFollowUp["followup_no"].ToString();
                        //listMyCalls_LastFollowUpList1.type = rdrMyCalls_LastFollowUp["type"].ToString();
                        //listMyCalls_LastFollowUpList1.followup_Date = rdrMyCalls_LastFollowUp["followup_Date"].ToString();
                        //listMyCalls_LastFollowUpList1.response = rdrMyCalls_LastFollowUp["response"].ToString();
                        listMyCalls_LastFollowUpList1.psf_num = rdrMyCalls_LastFollowUp["psf_num"].ToString();
                        listMyCalls_LastFollowUpList1.psf_type = rdrMyCalls_LastFollowUp["psf_type"].ToString();
                        listMyCalls_LastFollowUpList1.psf_date = rdrMyCalls_LastFollowUp["psf_date"].ToString();
                        listMyCalls_LastFollowUpList1.response = rdrMyCalls_LastFollowUp["response"].ToString();

                        listMyCalls_LastFollowUpList.Add(listMyCalls_LastFollowUpList1);

                        //err34 = " End While of Reader rdrMyCalls_LastFollowUp";
                    }
                }
                #endregion
                #region rdrMyCalls_JCDetails
                //err35 = " Before Reader rdrMyCalls_JCDetails";
                if (rdrMyCalls_JCDetails.HasRows)
                {
                    //err36 = " Reader rdrMyCalls_JCDetails Has Rows";
                    while (rdrMyCalls_JCDetails.Read())
                    {
                        //err37 = " Start While of Reader rdrMyCalls_JCDetails";

                        listMyCalls_JCDetailsList1 = new MyCalls_JCDetails();
                        //listMyCalls_JCDetailsList1.jc_no = rdrMyCalls_JCDetails["jc_no"].ToString();
                        //listMyCalls_JCDetailsList1.jc_Date = rdrMyCalls_JCDetails["jc_Date"].ToString();
                        //listMyCalls_JCDetailsList1.jc_omr = rdrMyCalls_JCDetails["jc_omr"].ToString();
                        //listMyCalls_JCDetailsList1.srv_type = rdrMyCalls_JCDetails["srv_type"].ToString();
                        //listMyCalls_JCDetailsList1.bill_amt = rdrMyCalls_JCDetails["bill_amt"].ToString();
                        //listMyCalls_JCDetailsList1.csi = rdrMyCalls_JCDetails["csi"].ToString();
                        listMyCalls_JCDetailsList1.ro_num = rdrMyCalls_JCDetails["ro_num"].ToString();
                        listMyCalls_JCDetailsList1.ro_date = rdrMyCalls_JCDetails["ro_date"].ToString();
                        listMyCalls_JCDetailsList1.odometer_reading = rdrMyCalls_JCDetails["odometer_reading"].ToString();
                        listMyCalls_JCDetailsList1.rcateg_cd = rdrMyCalls_JCDetails["rcateg_cd"].ToString();
                        listMyCalls_JCDetailsList1.bill_amt = rdrMyCalls_JCDetails["bill_amt"].ToString();
                        listMyCalls_JCDetailsList1.csi_per = rdrMyCalls_JCDetails["csi_per"].ToString();

                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["jc_no"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.jc_no = rdrMyCalls_JCDetails["jc_no"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.jc_no = "";
                        //}
                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["jc_Date"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.jc_Date = rdrMyCalls_JCDetails["jc_Date"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.jc_Date = "";
                        //}
                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["jc_omr"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.jc_omr = rdrMyCalls_JCDetails["jc_omr"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.jc_omr = "";
                        //}
                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["srv_type"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.srv_type = rdrMyCalls_JCDetails["srv_type"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.srv_type = "";
                        //}
                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["bill_amt"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.bill_amt = rdrMyCalls_JCDetails["bill_amt"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.bill_amt = "";
                        //}
                        //if (!string.IsNullOrEmpty(rdrMyCalls_JCDetails["csi"].ToString()))
                        //{
                        //    listMyCalls_JCDetailsList1.csi = rdrMyCalls_JCDetails["csi"].ToString();
                        //}
                        //else
                        //{
                        //    listMyCalls_JCDetailsList1.csi = "";
                        //}




                        listMyCalls_JCDetailsList.Add(listMyCalls_JCDetailsList1);

                        //err38 = " End While of Reader rdrMyCalls_JCDetails";
                    }
                }
                #endregion
                #region rdrMyCalls_PendingComplaints
                //err39 = " Before Reader rdrMyCalls_PendingComplaints";
                if (rdrMyCalls_PendingComplaints.HasRows)
                {
                    //err40 = " Reader rdrMyCalls_PendingComplaints Has Rows";
                    while (rdrMyCalls_PendingComplaints.Read())
                    {
                        //err41 = " Start While of Reader rdrMyCalls_PendingComplaints";

                        listMyCalls_PendingComplaintsList1 = new MyCalls_PendingComplaints();
                        //listMyCalls_PendingComplaintsList1.complaint_no = rdrMyCalls_PendingComplaints["complaint_no"].ToString();
                        //listMyCalls_PendingComplaintsList1.complaint_date = rdrMyCalls_PendingComplaints["complaint_date"].ToString();
                        //listMyCalls_PendingComplaintsList1.satisfied_yn = rdrMyCalls_PendingComplaints["satisfied_yn"].ToString();
                        //listMyCalls_PendingComplaintsList1.cust_voice = rdrMyCalls_PendingComplaints["cust_voice"].ToString();
                        listMyCalls_PendingComplaintsList1.compl_num = rdrMyCalls_PendingComplaints["compl_num"].ToString();
                        listMyCalls_PendingComplaintsList1.compl_date = rdrMyCalls_PendingComplaints["compl_date"].ToString();
                        listMyCalls_PendingComplaintsList1.comp_status = rdrMyCalls_PendingComplaints["comp_status"].ToString();
                        listMyCalls_PendingComplaintsList1.complaint_desc = rdrMyCalls_PendingComplaints["complaint_desc"].ToString();

                        listMyCalls_PendingComplaintsList.Add(listMyCalls_PendingComplaintsList1);

                        //err42 = " End While of Reader rdrMyCalls_PendingComplaints";
                    }
                }
                #endregion
                #region rdrMyCalls_FollowUp
                //err43 = " Before Reader rdrMyCalls_FollowUp";
                if (rdrMyCalls_FollowUp.HasRows)
                {
                    //err44 = " Reader rdrMyCalls_FollowUp Has Rows";
                    while (rdrMyCalls_FollowUp.Read())
                    {
                        //err45 = " Start While of Reader rdrMyCalls_FollowUp";

                        listMyCalls_FollowUpList1 = new MyCalls_FollowUp();
                        //listMyCalls_FollowUpList1.followup_no = rdrMyCalls_FollowUp["followup_no"].ToString();
                        //listMyCalls_FollowUpList1.followup_type = rdrMyCalls_FollowUp["followup_type"].ToString();
                        //listMyCalls_FollowUpList1.followup_Date = rdrMyCalls_FollowUp["followup_Date"].ToString();
                        //listMyCalls_FollowUpList1.response_Cd = rdrMyCalls_FollowUp["response_Cd"].ToString();
                        //listMyCalls_FollowUpList1.response_Desc = rdrMyCalls_FollowUp["response_Desc"].ToString();
                        //listMyCalls_FollowUpList1.rating_Cd = rdrMyCalls_FollowUp["rating_Cd"].ToString();
                        //listMyCalls_FollowUpList1.rating_desc = rdrMyCalls_FollowUp["rating_desc"].ToString();
                        //listMyCalls_FollowUpList1.followup_status_cd = rdrMyCalls_FollowUp["followup_status_cd"].ToString();
                        //listMyCalls_FollowUpList1.followup_status_desc = rdrMyCalls_FollowUp["followup_status_desc"].ToString();
                        //listMyCalls_FollowUpList1.next_followup_Date = rdrMyCalls_FollowUp["next_followup_Date"].ToString();
                        //listMyCalls_FollowUpList1.contact_person = rdrMyCalls_FollowUp["contact_person"].ToString();
                        //listMyCalls_FollowUpList1.complaint = rdrMyCalls_FollowUp["complaint"].ToString();
                        listMyCalls_FollowUpList1.psf_num = rdrMyCalls_FollowUp["psf_num"].ToString();
                        listMyCalls_FollowUpList1.psf_type = rdrMyCalls_FollowUp["psf_type"].ToString();
                        listMyCalls_FollowUpList1.psf_date = rdrMyCalls_FollowUp["psf_date"].ToString();
                        listMyCalls_FollowUpList1.response = rdrMyCalls_FollowUp["response"].ToString();
                        listMyCalls_FollowUpList1.response_Desc = rdrMyCalls_FollowUp["response_Desc"].ToString();
                        listMyCalls_FollowUpList1.rating_Cd = rdrMyCalls_FollowUp["rating_Cd"].ToString();
                        listMyCalls_FollowUpList1.rating_desc = rdrMyCalls_FollowUp["rating_desc"].ToString();
                        listMyCalls_FollowUpList1.followup_status_cd = rdrMyCalls_FollowUp["followup_status_cd"].ToString();
                        listMyCalls_FollowUpList1.followup_status_desc = rdrMyCalls_FollowUp["followup_status_desc"].ToString();
                        listMyCalls_FollowUpList1.next_followup_Date = rdrMyCalls_FollowUp["next_followup_Date"].ToString();
                        listMyCalls_FollowUpList1.contact_person = rdrMyCalls_FollowUp["contact_person"].ToString();
                        listMyCalls_FollowUpList1.complaint = rdrMyCalls_FollowUp["complaint"].ToString();

                        listMyCalls_FollowUpList.Add(listMyCalls_FollowUpList1);

                        //err46 = " End While of Reader rdrMyCalls_FollowUp";
                    }
                }
                #endregion
                #region rdrMyCalls_PSFFollowUp
                //err47 = " Before Reader rdrMyCalls_PSFFollowUp";
                if (rdrMyCalls_PSFFollowUp.HasRows)
                {
                    //err48 = " Reader rdrMyCalls_PSFFollowUp Has Rows";
                    while (rdrMyCalls_PSFFollowUp.Read())
                    {
                        //err49 = " Start While of Reader rdrMyCalls_PSFFollowUp";

                        listMyCalls_PSFFollowUpList1 = new MyCalls_PSFFollowUp();
                        //listMyCalls_PSFFollowUpList1.sr_no = rdrMyCalls_PSFFollowUp["sr_no"].ToString();
                        //listMyCalls_PSFFollowUpList1.script_Cd = rdrMyCalls_PSFFollowUp["script_Cd"].ToString();
                        //listMyCalls_PSFFollowUpList1.script_Desc = rdrMyCalls_PSFFollowUp["script_Desc"].ToString();
                        //listMyCalls_PSFFollowUpList1.feedback = rdrMyCalls_PSFFollowUp["feedback"].ToString();
                        //listMyCalls_PSFFollowUpList1.voice_of_cust = rdrMyCalls_PSFFollowUp["voice_of_cust"].ToString();
                        listMyCalls_PSFFollowUpList1.psf_srl = rdrMyCalls_PSFFollowUp["psf_srl"].ToString();
                        listMyCalls_PSFFollowUpList1.psf_questions = rdrMyCalls_PSFFollowUp["psf_questions"].ToString();
                        listMyCalls_PSFFollowUpList1.script_desc = rdrMyCalls_PSFFollowUp["script_desc"].ToString();
                        listMyCalls_PSFFollowUpList1.psf_feedback = rdrMyCalls_PSFFollowUp["psf_feedback"].ToString();
                        listMyCalls_PSFFollowUpList1.feedback_desc = rdrMyCalls_PSFFollowUp["feedback_desc"].ToString();
                        listMyCalls_PSFFollowUpList1.voice_of_cust = rdrMyCalls_PSFFollowUp["voice_of_cust"].ToString();

                        listMyCalls_PSFFollowUpList.Add(listMyCalls_PSFFollowUpList1);

                        //err50 = " End While of Reader rdrMyCalls_PSFFollowUp";
                    }
                }
                #endregion

                listDetail = new MyCalls_GetSrvCustomerDetail();
                listDetail.MyCalls_CustomerVehicleDet = listMyCalls_CustomerVehicleDetList;
                listDetail.MyCalls_LastFollowUp = listMyCalls_LastFollowUpList;
                listDetail.MyCalls_JCDetails = listMyCalls_JCDetailsList;
                listDetail.MyCalls_PendingComplaints = listMyCalls_PendingComplaintsList;
                listDetail.MyCalls_FollowUp = listMyCalls_FollowUpList;
                listDetail.MyCalls_PSFFollowUp = listMyCalls_PSFFollowUpList;

                //err51 = " After add all cursor value to list";

                listDetail.po_bkg_type = cmd.Parameters["po_bkg_type"].Value.ToString();
                listDetail.po_bkg_date = cmd.Parameters["po_bkg_date"].Value.ToString();
                listDetail.po_srv_type = cmd.Parameters["po_srv_type"].Value.ToString();
                listDetail.po_pickup_req = cmd.Parameters["po_pickup_req"].Value.ToString();
                listDetail.po_free_pickup = cmd.Parameters["po_free_pickup"].Value.ToString();
                listDetail.po_pickup_type = cmd.Parameters["po_pickup_type"].Value.ToString();
                listDetail.po_pickup_date = cmd.Parameters["po_pickup_date"].Value.ToString();
                listDetail.po_pickup_loc = cmd.Parameters["po_pickup_loc"].Value.ToString();
                listDetail.po_pickup_driver = cmd.Parameters["po_pickup_driver"].Value.ToString();
                listDetail.po_pickup_remarks = cmd.Parameters["po_pickup_remarks"].Value.ToString();
                listDetail.po_satisified_flag = cmd.Parameters["po_satisified_flag"].Value.ToString();
                listDetail.po_voice_cust = cmd.Parameters["po_voice_cust"].Value.ToString();

                //err52 = " After add all cursor + normal output value to list";

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //response.message = Convert.ToString(ServiceMassageCode.SUCCESS) + "  result" + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err31 + err32 + err33 + err34 + err35 + err36 + err37 + err38 + err39 + err40 + err41 + err42 + err43 + err44 + err45 + err46 + err47 + err48 + err49 + err50 + err51 + err52;

                response.result = MainALLDetailsList;
            }
            catch (Exception ex)
            {
                //err14 = " In case of Exception";

                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetSrvCustomerDetail");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                //response.message = ex.Message + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err31 + err32 + err33 + err34 + err35 + err36 + err37 + err38 + err39 + err40 + err41 + err42 + err43 + err44 + err45 + err46 + err47 + err48 + err49 + err50 + err51 + err52;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_UpdateFollowUpDetail
        public BaseListReturnType<MyCalls_UpdateFollowUpDetail> MyCallsUpdateFollowUpDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_followup_Cd, string pn_status_Cd, string pn_vin, string pn_bkg_type, string pn_bkg_date, string pn_srv_type, string pn_pickup_req, string pn_free_pickup, string pn_pickup_type, string pn_pickup_date, string pn_pickup_loc, string pn_pickup_driver, string pn_pickup_remarks, string pn_mms_reg_num, string pn_followup_str, string pn_voice_cust, string pn_psf_followup_str)
        {
            BaseListReturnType<MyCalls_UpdateFollowUpDetail> response = new BaseListReturnType<MyCalls_UpdateFollowUpDetail>();

            MyCalls_UpdateFollowUpDetail result = new MyCalls_UpdateFollowUpDetail();

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
                cmd.CommandText = Usp_MyCalls_UpdateFollowUpDetail;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_followup_Cd", OracleType.VarChar).Value = pn_followup_Cd;
                cmd.Parameters.Add("pn_status_Cd", OracleType.VarChar).Value = pn_status_Cd;
                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;
                cmd.Parameters.Add("pn_bkg_type", OracleType.VarChar).Value = pn_bkg_type;
                cmd.Parameters.Add("pn_bkg_date", OracleType.VarChar).Value = pn_bkg_date;
                cmd.Parameters.Add("pn_srv_type", OracleType.VarChar).Value = pn_srv_type;
                cmd.Parameters.Add("pn_pickup_req", OracleType.VarChar).Value = pn_pickup_req;
                cmd.Parameters.Add("pn_free_pickup", OracleType.VarChar).Value = pn_free_pickup;
                cmd.Parameters.Add("pn_pickup_type", OracleType.VarChar).Value = pn_pickup_type;
                cmd.Parameters.Add("pn_pickup_date", OracleType.VarChar).Value = pn_pickup_date;
                cmd.Parameters.Add("pn_pickup_loc", OracleType.VarChar).Value = pn_pickup_loc;
                cmd.Parameters.Add("pn_pickup_driver", OracleType.VarChar).Value = pn_pickup_driver;
                cmd.Parameters.Add("pn_pickup_remarks", OracleType.VarChar).Value = pn_pickup_remarks;
                cmd.Parameters.Add("pn_mms_reg_num", OracleType.VarChar).Value = pn_mms_reg_num;

                cmd.Parameters.Add("pn_followup_str", OracleType.VarChar).Value = pn_followup_str;

                cmd.Parameters.Add("pn_voice_cust", OracleType.VarChar).Value = pn_voice_cust;

                cmd.Parameters.Add("pn_psf_followup_str", OracleType.VarChar).Value = pn_psf_followup_str;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }


                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //response.result = result;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_MyCallsUpdateFollowUpDetail");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ServiceTypeValidation
        public BaseListReturnType<ServiceTypeValidation> ServiceTypeValidation(string pn_parent, string pn_dealer, string pn_loc, string pn_comp, string pn_vin, string pn_srvtype, string pn_omr)
        {
            BaseListReturnType<ServiceTypeValidation> response = new BaseListReturnType<ServiceTypeValidation>();
            ServiceTypeValidation Typedetail = null;
            List<ServiceTypeValidation> Details;
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
                cmd.CommandText = Usp_ServiceTypeValidation;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent", OracleType.VarChar).Value = pn_parent;
                cmd.Parameters.Add("pn_dealer", OracleType.Number).Value = Convert.ToInt32(pn_dealer);
                cmd.Parameters.Add("pn_loc", OracleType.VarChar).Value = pn_loc;
                cmd.Parameters.Add("pn_comp", OracleType.VarChar).Value = pn_comp;
                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;
                cmd.Parameters.Add("pn_srvtype", OracleType.VarChar).Value = pn_srvtype;
                cmd.Parameters.Add("pn_omr", OracleType.Number).Value = Convert.ToInt32(pn_omr);

                //for output params
                cmd.Parameters.Add("po_omr_change", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                Details = new List<ServiceTypeValidation>();
                Typedetail = new ServiceTypeValidation();
                Typedetail.po_omr_change = cmd.Parameters["po_omr_change"].Value.ToString();

                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_ServiceTypeValidation");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }

        #endregion

        #region for JobCardUpdate
        public BaseListReturnType<JobCardUpdate> JobCardUpdate(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id, string pn_gst_type, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_waiting_cust, string pn_demand_ins_str, string pn_mcard_ins_str, string pn_labor_ins_str, string pn_part_ins_str, string pn_repair_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_sch_est_part_amt, string pn_sch_est_lab_amt, string pn_dmd_est_part_amt, string pn_dmd_est_lab_amt, string pn_est_remarks)
        //public BaseListReturnType<JobCardUpdate> JobCardUpdate(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id, string pn_gst_type, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_waiting_cust, string pn_demand_ins_str, string pn_mcard_ins_str, string pn_labor_ins_str, string pn_part_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_sch_est_part_amt, string pn_sch_est_lab_amt, string pn_dmd_est_part_amt, string pn_dmd_est_lab_amt, string pn_est_remarks)
        {
            //string pn_cust_sign

            BaseListReturnType<JobCardUpdate> response = new BaseListReturnType<JobCardUpdate>();

            JobCardUpdate Typedetail = null;
            List<JobCardUpdate> Details;
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
                cmd.CommandText = Usp_JobCardUpdate;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_num", OracleType.VarChar).Value = pn_jc_num;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_gst_type", OracleType.VarChar).Value = pn_gst_type;//New
                cmd.Parameters.Add("pn_srv_cat_cd", OracleType.VarChar).Value = pn_srv_cat_cd;
                cmd.Parameters.Add("pn_sub_srv_type_cd", OracleType.VarChar).Value = pn_sub_srv_type_cd;

                cmd.Parameters.Add("pn_omr", OracleType.Number).Value = Convert.ToInt32(pn_omr);

                cmd.Parameters.Add("pn_promised_date", OracleType.VarChar).Value = pn_promised_date;
                cmd.Parameters.Add("pn_payment_mode", OracleType.VarChar).Value = pn_payment_mode;
                cmd.Parameters.Add("pn_sa_adv", OracleType.VarChar).Value = pn_sa_adv;
                cmd.Parameters.Add("pn_tech_adv", OracleType.VarChar).Value = pn_tech_adv;
                cmd.Parameters.Add("pn_bay_cd", OracleType.VarChar).Value = pn_bay_cd;
                cmd.Parameters.Add("pn_group_cd", OracleType.VarChar).Value = pn_group_cd;
                cmd.Parameters.Add("pn_tech_cd", OracleType.VarChar).Value = pn_tech_cd;
                cmd.Parameters.Add("pn_waiting_cust", OracleType.VarChar).Value = pn_waiting_cust;

                cmd.Parameters.Add("pn_demand_ins_str", OracleType.VarChar).Value = pn_demand_ins_str;
                cmd.Parameters.Add("pn_mcard_ins_str", OracleType.VarChar).Value = pn_mcard_ins_str;

                cmd.Parameters.Add("pn_labor_ins_str", OracleType.VarChar).Value = pn_labor_ins_str;
                cmd.Parameters.Add("pn_part_ins_str", OracleType.VarChar).Value = pn_part_ins_str;

                cmd.Parameters.Add("pn_repair_ins_str", OracleType.VarChar).Value = pn_repair_ins_str;

                cmd.Parameters.Add("pn_pickup_type", OracleType.VarChar).Value = pn_pickup_type;
                cmd.Parameters.Add("pn_pickup_date", OracleType.VarChar).Value = pn_pickup_date;
                cmd.Parameters.Add("pn_free_pikcup_flag", OracleType.VarChar).Value = pn_free_pikcup_flag;
                cmd.Parameters.Add("pn_pickup_loc_cd", OracleType.VarChar).Value = pn_pickup_loc_cd;
                cmd.Parameters.Add("pn_pickup_driver", OracleType.VarChar).Value = pn_pickup_driver;
                cmd.Parameters.Add("pn_pikcup_remarks", OracleType.VarChar).Value = pn_pikcup_remarks;
                cmd.Parameters.Add("pn_mms_num", OracleType.VarChar).Value = pn_mms_num;

                cmd.Parameters.Add("pn_sch_est_part_amt", OracleType.Number).Value = Convert.ToInt32(pn_sch_est_part_amt);
                cmd.Parameters.Add("pn_sch_est_lab_amt", OracleType.Number).Value = Convert.ToInt32(pn_sch_est_lab_amt);
                cmd.Parameters.Add("pn_dmd_est_part_amt", OracleType.Number).Value = Convert.ToInt32(pn_dmd_est_part_amt);
                cmd.Parameters.Add("pn_dmd_est_lab_amt", OracleType.Number).Value = Convert.ToInt32(pn_dmd_est_lab_amt);

                //cmd.Parameters.Add("pn_cust_sign", OracleType.VarChar).Value = pn_cust_sign;
                //cmd.Parameters.Add("pn_cust_sign", OracleType.Blob).Value = Convert.ToByte(pn_cust_sign);

                cmd.Parameters.Add("pn_est_remarks", OracleType.VarChar).Value = pn_est_remarks;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = null;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_JobCardUpdate");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JobCardPreInvoicePrint
        public BaseListReturnType<JobCardPreInvoicePrint> JobCardPreInvoicePrint(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id)
        {
            #region Variables
            //string err1 = string.Empty;
            //string err2 = string.Empty;
            //string err3 = string.Empty;
            //string err4 = string.Empty;
            //string err5 = string.Empty;
            //string err6 = string.Empty;
            //string err7 = string.Empty;
            //string err8 = string.Empty;
            //string err9 = string.Empty;
            //string err10 = string.Empty;
            //string err11 = string.Empty;
            //string err12 = string.Empty;
            //string err13 = string.Empty;
            //string err14 = string.Empty;
            //string err15 = string.Empty;
            //string err16 = string.Empty;
            //string err17 = string.Empty;
            //string err18 = string.Empty;
            //string err19 = string.Empty;
            //string err20 = string.Empty;
            //string err21 = string.Empty;
            //string err22 = string.Empty;
            //string err23 = string.Empty;
            //string err24 = string.Empty;
            //string err25 = string.Empty;
            //string err26 = string.Empty;
            //string err27 = string.Empty;
            //string err28 = string.Empty;
            //string err29 = string.Empty;
            //string err30 = string.Empty;
            #endregion

            //err15 = " Method Objects Start ";

            BaseListReturnType<JobCardPreInvoicePrint> response = new BaseListReturnType<JobCardPreInvoicePrint>();

            List<JobCardPreInvoicePrint> MainALLDetailsList;
            JobCardPreInvoicePrint listDetail = null;

            List<JobCardPreInvoicePrint_DemandList> listJobCardPreInvoicePrint_DemandListList = new List<JobCardPreInvoicePrint_DemandList>();
            List<JobCardPreInvoicePrint_PartList> listJobCardPreInvoicePrint_PartListList = new List<JobCardPreInvoicePrint_PartList>();
            List<JobCardPreInvoicePrint_LabourList> listJobCardPreInvoicePrint_LabourListList = new List<JobCardPreInvoicePrint_LabourList>();
            List<JobCardPreInvoicePrint_BillList> listJobCardPreInvoicePrint_BillListList = new List<JobCardPreInvoicePrint_BillList>();

            JobCardPreInvoicePrint_DemandList listJobCardPreInvoicePrint_DemandListList1;
            JobCardPreInvoicePrint_PartList listJobCardPreInvoicePrint_PartListList1;
            JobCardPreInvoicePrint_LabourList listJobCardPreInvoicePrint_LabourListList1;
            JobCardPreInvoicePrint_BillList listJobCardPreInvoicePrint_BillListList1;

            //err16 = " Method Objects End ";

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                //err17 = " Token Error ";

                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            //err18 = " Token Success ";

            try
            {
                #region Connection and Bind Data in Dataset
                //err19 = " Connection Start ";
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_JobCardPreInvoicePrint;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_num", OracleType.VarChar).Value = pn_jc_num;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;

                //Output
                cmd.Parameters.Add("po_jc_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mileage", OracleType.Number).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_cust_gstn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_dlr_gstn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pos", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_last_mileage", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_service_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_next_srv_due", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sa_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_loyaltycard", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_srv", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //output cursor
                cmd.Parameters.Add("po_demand_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_part_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_labor_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_bill_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //err20 = " Parameters Defined End ";

                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //err21 = " Connection Now Close ";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //err22 = " Connection Now Open ";
                //err23 = " Connection ExecuteNonQuery Start ";
                cmd.ExecuteNonQuery();

                //err24 = " Connection ExecuteNonQuery End ";

                OracleDataReader rdrJobCardPreInvoicePrint_DemandList;
                OracleDataReader rdrJobCardPreInvoicePrint_PartList;
                OracleDataReader rdrJobCardPreInvoicePrint_LabourList;
                OracleDataReader rdrJobCardPreInvoicePrint_BillList;

                rdrJobCardPreInvoicePrint_DemandList = (OracleDataReader)cmd.Parameters["po_demand_refcur"].Value;
                rdrJobCardPreInvoicePrint_PartList = (OracleDataReader)cmd.Parameters["po_part_refcur"].Value;
                rdrJobCardPreInvoicePrint_LabourList = (OracleDataReader)cmd.Parameters["po_labor_refcur"].Value;
                rdrJobCardPreInvoicePrint_BillList = (OracleDataReader)cmd.Parameters["po_bill_refcur"].Value;

                //err25 = " Assigned Values to Cursor ";
                #endregion

                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    //err1 = " In case of Error";

                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    //response.message = cmd.Parameters["po_err_msg"].Value.ToString() + err1;
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<JobCardPreInvoicePrint>();

                listJobCardPreInvoicePrint_DemandListList = new List<JobCardPreInvoicePrint_DemandList>();
                listJobCardPreInvoicePrint_PartListList = new List<JobCardPreInvoicePrint_PartList>();
                listJobCardPreInvoicePrint_LabourListList = new List<JobCardPreInvoicePrint_LabourList>();
                listJobCardPreInvoicePrint_BillListList = new List<JobCardPreInvoicePrint_BillList>();

                #region rdrJobCardPreInvoicePrint_DemandList
                //err2 = " Before Reader rdrJobCardPreInvoicePrint_DemandList";
                if (rdrJobCardPreInvoicePrint_DemandList.HasRows)
                {
                    //err3 = " Reader rdrJobCardPreInvoicePrint_DemandList Has Rows";

                    while (rdrJobCardPreInvoicePrint_DemandList.Read())
                    {
                        //err4 = " Start While of Reader rdrJobCardPreInvoicePrint_DemandList";

                        listJobCardPreInvoicePrint_DemandListList1 = new JobCardPreInvoicePrint_DemandList();
                        listJobCardPreInvoicePrint_DemandListList1.demand_cd = rdrJobCardPreInvoicePrint_DemandList["demand_cd"].ToString();
                        listJobCardPreInvoicePrint_DemandListList1.demand_desc = rdrJobCardPreInvoicePrint_DemandList["demand_desc"].ToString();
                        listJobCardPreInvoicePrint_DemandListList1.demand_type = rdrJobCardPreInvoicePrint_DemandList["demand_type"].ToString();
                        listJobCardPreInvoicePrint_DemandListList1.problem_narr = rdrJobCardPreInvoicePrint_DemandList["problem_narr"].ToString();
                        listJobCardPreInvoicePrint_DemandListList1.action_desc = rdrJobCardPreInvoicePrint_DemandList["action_desc"].ToString();

                        listJobCardPreInvoicePrint_DemandListList.Add(listJobCardPreInvoicePrint_DemandListList1);

                        //err5 = " Start While of Reader rdrJobCardPreInvoicePrint_DemandList";
                    }
                }
                #endregion
                #region rdrJobCardPreInvoicePrint_PartList
                //err6 = " Before Reader rdrJobCardPreInvoicePrint_PartList";
                if (rdrJobCardPreInvoicePrint_PartList.HasRows)
                {
                    //err7 = " Reader rdrJobCardPreInvoicePrint_PartList Has Rows";

                    while (rdrJobCardPreInvoicePrint_PartList.Read())
                    {
                        // err8 = " Start While of Reader rdrJobCardPreInvoicePrint_PartList";

                        listJobCardPreInvoicePrint_PartListList1 = new JobCardPreInvoicePrint_PartList();
                        listJobCardPreInvoicePrint_PartListList1.part_num = rdrJobCardPreInvoicePrint_PartList["part_num"].ToString();
                        listJobCardPreInvoicePrint_PartListList1.part_desc = rdrJobCardPreInvoicePrint_PartList["part_desc"].ToString();
                        listJobCardPreInvoicePrint_PartListList1.iss_qty = rdrJobCardPreInvoicePrint_PartList["iss_qty"].ToString();
                        listJobCardPreInvoicePrint_PartListList1.rate = rdrJobCardPreInvoicePrint_PartList["rate"].ToString();
                        listJobCardPreInvoicePrint_PartListList1.taxable_amt = rdrJobCardPreInvoicePrint_PartList["taxable_amt"].ToString();
                        //listJobCardPreInvoicePrint_PartListList1.taxpaid_amt = rdrJobCardPreInvoicePrint_PartList["taxpaid_amt"].ToString();
                        listJobCardPreInvoicePrint_PartListList1.HSN_CODE = rdrJobCardPreInvoicePrint_PartList["HSN_CODE"].ToString();

                        listJobCardPreInvoicePrint_PartListList.Add(listJobCardPreInvoicePrint_PartListList1);

                        //err9 = " Start While of Reader rdrJobCardPreInvoicePrint_PartList";
                    }
                }
                #endregion
                #region listJobCardPreInvoicePrint_LabourListList
                //err10 = " Before Reader rdrJobCardPreInvoicePrint_LabourList";
                if (rdrJobCardPreInvoicePrint_LabourList.HasRows)
                {
                    //err11 = " Reader rdrJobCardPreInvoicePrint_LabourList Has Rows";

                    while (rdrJobCardPreInvoicePrint_LabourList.Read())
                    {
                        //err12 = " Start While of Reader rdrJobCardPreInvoicePrint_LabourList";

                        listJobCardPreInvoicePrint_LabourListList1 = new JobCardPreInvoicePrint_LabourList();
                        listJobCardPreInvoicePrint_LabourListList1.labor_cd = rdrJobCardPreInvoicePrint_LabourList["labor_cd"].ToString();
                        listJobCardPreInvoicePrint_LabourListList1.labor_desc = rdrJobCardPreInvoicePrint_LabourList["labor_desc"].ToString();
                        listJobCardPreInvoicePrint_LabourListList1.labor_charges = rdrJobCardPreInvoicePrint_LabourList["labor_charges"].ToString();

                        listJobCardPreInvoicePrint_LabourListList1.SAC_CODE = rdrJobCardPreInvoicePrint_LabourList["SAC_CODE"].ToString();

                        listJobCardPreInvoicePrint_LabourListList.Add(listJobCardPreInvoicePrint_LabourListList1);

                        //err13 = " Start While of Reader rdrJobCardPreInvoicePrint_LabourList";
                    }
                }
                #endregion
                #region listJobCardPreInvoicePrint_BillListList
                //err10 = " Before Reader rdrJobCardPreInvoicePrint_LabourList";
                if (rdrJobCardPreInvoicePrint_BillList.HasRows)
                {
                    //err11 = " Reader rdrJobCardPreInvoicePrint_LabourList Has Rows";

                    while (rdrJobCardPreInvoicePrint_BillList.Read())
                    {
                        //err12 = " Start While of Reader rdrJobCardPreInvoicePrint_LabourList";

                        listJobCardPreInvoicePrint_BillListList1 = new JobCardPreInvoicePrint_BillList();
                        listJobCardPreInvoicePrint_BillListList1.header = rdrJobCardPreInvoicePrint_BillList["header"].ToString();
                        listJobCardPreInvoicePrint_BillListList1.part_charges = rdrJobCardPreInvoicePrint_BillList["part_charges"].ToString();
                        listJobCardPreInvoicePrint_BillListList1.labour_charges = rdrJobCardPreInvoicePrint_BillList["labour_charges"].ToString();

                        listJobCardPreInvoicePrint_BillListList.Add(listJobCardPreInvoicePrint_BillListList1);

                        //err13 = " Start While of Reader rdrJobCardPreInvoicePrint_LabourList";
                    }
                }
                #endregion


                listDetail = new JobCardPreInvoicePrint();
                listDetail.JobCardPreInvoicePrint_DemandList = listJobCardPreInvoicePrint_DemandListList;
                listDetail.JobCardPreInvoicePrint_PartList = listJobCardPreInvoicePrint_PartListList;
                listDetail.JobCardPreInvoicePrint_LabourList = listJobCardPreInvoicePrint_LabourListList;
                listDetail.JobCardPreInvoicePrint_BillList = listJobCardPreInvoicePrint_BillListList;

                listDetail.po_jc_date = cmd.Parameters["po_jc_date"].Value.ToString();
                listDetail.po_mileage = cmd.Parameters["po_mileage"].Value.ToString();//Int

                listDetail.po_cust_gstn = cmd.Parameters["po_cust_gstn"].Value.ToString();
                listDetail.po_dlr_gstn = cmd.Parameters["po_dlr_gstn"].Value.ToString();
                listDetail.po_pos = cmd.Parameters["po_pos"].Value.ToString();

                listDetail.po_last_mileage = cmd.Parameters["po_last_mileage"].Value.ToString();//Int
                listDetail.po_service_type = cmd.Parameters["po_service_type"].Value.ToString();
                listDetail.po_next_srv_due = cmd.Parameters["po_next_srv_due"].Value.ToString();
                listDetail.po_sa_name = cmd.Parameters["po_sa_name"].Value.ToString();
                listDetail.po_loyaltycard = cmd.Parameters["po_loyaltycard"].Value.ToString();
                listDetail.po_last_srv = cmd.Parameters["po_last_srv"].Value.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }
            catch (Exception ex)
            {
                //err14 = " In case of Exception";

                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_JobCardPreInvoicePrint");
                response.code = (int)ServiceMassageCode.ERROR;
                //response.message = ex.Message + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MonitoringScreenBayDetail
        public BaseListReturnType<MonitoringScreenBayDetail> MonitoringScreenBayDetail(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_bay_start_date)
        {
            BaseListReturnType<MonitoringScreenBayDetail> response = new BaseListReturnType<MonitoringScreenBayDetail>();

            MonitoringScreenBayDetail Typedetail = null;
            List<MonitoringScreenBayDetail> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MonitoringScreenBayDetail;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_bay_start_date", OracleType.VarChar).Value = pn_bay_start_date;

                cmd.Parameters.Add("po_baydtl_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MonitoringScreenBayDetail>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MonitoringScreenBayDetail();

                            Typedetail.bay_desc = Convert.ToString(row["bay_desc"]);
                            Typedetail.worked_before_time_cnt = Convert.ToString(row["worked_before_time_cnt"]);
                            Typedetail.worked_after_time_cnt = Convert.ToString(row["worked_after_time_cnt"]);
                            Typedetail.total_labor_revenue = Convert.ToString(row["total_labor_revenue"]);
                            Typedetail.max_potional_labor_revenue = Convert.ToString(row["max_potional_labor_revenue"]);
                            Typedetail.per_potional_utilized = Convert.ToString(row["per_potional_utilized"]);
                            Typedetail.reg_num = Convert.ToString(row["reg_num"]);
                            Typedetail.est_time_for_completion = Convert.ToString(row["est_time_for_completion"]);
                            Typedetail.time_left_delay_completion = Convert.ToString(row["time_left_delay_completion"]);
                            Typedetail.Workshop_working_time = Convert.ToString(row["Workshop_working_time"]);
                            Typedetail.BaySuspended_status = Convert.ToString(row["BaySuspended_status"]);
                            Typedetail.BayOntimeStatus = Convert.ToString(row["BayOntimeStatus"]);
                            Typedetail.WorkDelayed_Status = Convert.ToString(row["WorkDelayed_Status"]);

                            Typedetail.BAY_ALLOCATION_DATETIME = Convert.ToString(row["BAY_ALLOCATION_DATETIME"]);

                            Typedetail.bay_in_time = Convert.ToString(row["bay_in_time"]);
                            Typedetail.bay_status_cd = Convert.ToString(row["bay_status_cd"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MonitoringScreenBayDetail");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for JCClosingBillableType
        public BaseListReturnType<JCClosingBillableType> JCClosingBillableType(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_labor_Cd, string pn_bill_type_Cd)
        {
            BaseListReturnType<JCClosingBillableType> response = new BaseListReturnType<JCClosingBillableType>();
            try
            {
                JCClosingBillableType result = new JCClosingBillableType();
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
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
                cmd.CommandText = Usp_JCClosingBillableType;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_num", OracleType.VarChar).Value = pn_jc_num;
                cmd.Parameters.Add("pn_labor_Cd", OracleType.VarChar).Value = pn_labor_Cd;
                cmd.Parameters.Add("pn_bill_type_Cd", OracleType.VarChar).Value = pn_bill_type_Cd;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //  response.result = result;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_JCClosingBillableType");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for QMMonitoringJobCard
        public BaseListReturnType<QMClusterMonitoringJobCardResult> QMMonitoringJobCard(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            BaseListReturnType<QMClusterMonitoringJobCardResult> response = new BaseListReturnType<QMClusterMonitoringJobCardResult>();

            QMMonitoringJobCard Typedetail = null;
            List<QMMonitoringJobCard> Details;
            //Validate Token
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
                cmd.CommandText = Usp_QMMonitoringJobCard;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_mointorjc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCard>();

                int iVehBilledWithin4HoursCounts = 0;
                int iVehBilledWithin4HoursPerc = 0;
                int iVehLess1HourRemainAsPromiseCounts = 0;
                int icustomerWaitInLoungeCounts = 0;
                int ionlinePaymentsCounts = 0;

                int iTotalVehBilledTillNowCounts = 0;

                int iTarget_service_load_for_today = 0;
                int iJobcards_opened_today = 0;
                int iCarryover_jobcards = 0;
                int iJobcards_billed_today = 0;

                int iGate_In_Counts = 0;
                int iGate_Out_Counts = 0;
                int iShopFloor_In_Counts = 0;
                int iShopFloor_Out_Counts = 0;
                int iBayAllocated_In_Counts = 0;
                int iBayAllocated_Out_Counts = 0;
                int iFinalWashing_In_Counts = 0;
                int iFinalWashing_Out_Counts = 0;
                int iFinalInspection_In_Counts = 0;
                int iFinalInspection_Out_Counts = 0;
                int iTesterLine_In_Counts = 0;
                int iTesterLine_Out_Counts = 0;

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        //int iSNo = 0;

                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCard();

                            //iSNo = iSNo + 1;

                            //Typedetail.SNo = iSNo.ToString();

                            Typedetail.APPOINTMENT_TYPE = Convert.ToString(row["APPOINTMENT_TYPE"]);
                            Typedetail.REG_NUM = Convert.ToString(row["REG_NUM"]);
                            Typedetail.JOB_CARD_NUM = Convert.ToString(row["JOB_CARD_NUM"]);
                            Typedetail.SRV_TYPE = Convert.ToString(row["SRV_TYPE"]);
                            Typedetail.MODEL = Convert.ToString(row["MODEL"]);
                            Typedetail.SRV_ADV_CD = Convert.ToString(row["SRV_ADV_CD"]);
                            Typedetail.SRV_SDV_NAME = Convert.ToString(row["SRV_SDV_NAME"]);
                            Typedetail.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            Typedetail.JC_OPEN_DATE = Convert.ToString(row["JC_OPEN_DATE"]);
                            Typedetail.PROM_DATE = Convert.ToString(row["PROM_DATE"]);
                            Typedetail.JC_CLOSE_DATE = Convert.ToString(row["JC_CLOSE_DATE"]);
                            Typedetail.JC_BILL_DATE = Convert.ToString(row["JC_BILL_DATE"]);
                            Typedetail.GATE_OUT_TIME = Convert.ToString(row["GATE_OUT_TIME"]);
                            Typedetail.STAGE = Convert.ToString(row["STAGE"]);
                            Typedetail.TIME_IN_STAGE = Convert.ToString(row["TIME_IN_STAGE"]);
                            Typedetail.DELAY_REASON = Convert.ToString(row["DELAY_REASON"]);
                            Typedetail.WAITING_YN = Convert.ToString(row["WAITING_YN"]);
                            Typedetail.ONLINE_PAYMENT_FLAG = Convert.ToString(row["ONLINE_PAYMENT_FLAG"]);


                            #region Cluster Name Set
                            //Typedetail.Cluster = "";
                            Typedetail.Cluster = "WORK IN PROGRESS";

                            //if (string.IsNullOrEmpty(Typedetail.STAGE.Trim()))
                            //{
                            //    Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                            //}
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.STAGE.Trim())))
                            {
                                Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                                Typedetail.STAGE = "Pending for Shopfloor";
                            }

                            //if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor") && (string.IsNullOrEmpty(Typedetail.TIME_IN_STAGE.Trim())))
                            if ((Typedetail.STAGE.Trim().ToLower() == "si") && (string.IsNullOrEmpty(Typedetail.TIME_IN_STAGE.Trim())))// add logic here current time minus si in time
                            {
                                //Typedetail.Cluster = "BAY LOCATION PENDING";
                                Typedetail.Cluster = "VEHICLE ON SHOPFLOOR";
                            }

                            ////if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor") && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            ////if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor out") && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            //if (Typedetail.STAGE.Trim().ToLower() == "shopfloor out")
                            //{
                            //    Typedetail.Cluster = "WORK IN PROGRESS";
                            //}

                            //if (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim()))// add logic here where bay allocated in and out time calculation
                            //{
                            //    Typedetail.Cluster = "WORK IN PROGRESS";
                            //}

                            if (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim()))// add logic here si out time is available
                            {
                                Typedetail.Cluster = "SHOPFLOOR OUT, JC NOT CLOSED";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                Typedetail.Cluster = "JC CLOSED, BUT NOT BILLED";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED, BUT NOT GATE OUT";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED AND GATE OUT";
                            }
                            #endregion

                            #region Set Parameters and No of Vehicle
                            #region Total Vehicle Billed till now Counts
                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                iTotalVehBilledTillNowCounts = iTotalVehBilledTillNowCounts + 1;
                            }
                            #endregion

                            #region Vehicle Billed Within 4 Hours
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    DateTime d_JC_OPEN_DATE, d_JC_BILL_DATE;
                                    d_JC_OPEN_DATE = Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim());
                                    d_JC_BILL_DATE = Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim());

                                    TimeSpan span = d_JC_BILL_DATE.Subtract(d_JC_OPEN_DATE);
                                    if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 240))//within 4 hours
                                    {
                                        iVehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts + 1;
                                    }
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursCounts = "";// iVehBilledWithin4HoursCounts.ToString();
                            Typedetail.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                            #endregion
                            #region % Vehicle Billed Within 4 Hours
                            if (!string.IsNullOrEmpty(Typedetail.VehBilledWithin4HoursCounts.Trim()))
                            {
                                if (Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) > 0)
                                {
                                    //iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / detailTable.Rows.Count;
                                    iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / iTotalVehBilledTillNowCounts;
                                }
                                else
                                {
                                    iVehBilledWithin4HoursPerc = 0;
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursPerc = "";// iVehBilledWithin4HoursPerc.ToString() + "%";
                            Typedetail.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                            #endregion
                            #region Vehicle in which Less than 1 Hour Remaining As per Promised time
                            if ((!string.IsNullOrEmpty(Typedetail.PROM_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            {
                                DateTime d_PROM_DATE;
                                DateTime d_DateTimeNow;
                                d_PROM_DATE = Convert.ToDateTime(Typedetail.PROM_DATE.Trim());
                                d_DateTimeNow = Convert.ToDateTime(DateTime.Now);

                                TimeSpan span = d_PROM_DATE.Subtract(d_DateTimeNow);
                                if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 60))//within 1 hour
                                {
                                    iVehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts + 1;
                                }
                            }
                            //Typedetail.VehLess1HourRemainAsPromiseCounts = "";// iVehLess1HourRemainAsPromiseCounts.ToString();
                            Typedetail.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                            #endregion
                            #region customer Waiting In customer Lounge
                            if (!string.IsNullOrEmpty(Typedetail.WAITING_YN.Trim()))
                            {
                                if (Typedetail.WAITING_YN.Trim().ToLower() == "y")
                                {
                                    icustomerWaitInLoungeCounts = icustomerWaitInLoungeCounts + 1;
                                }
                            }
                            //Typedetail.customerWaitInLoungeCounts = "";// icustomerWaitInLoungeCounts.ToString();
                            Typedetail.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                            #endregion
                            #region No of online Payments done
                            if (!string.IsNullOrEmpty(Typedetail.ONLINE_PAYMENT_FLAG.Trim()))
                            {
                                if (Typedetail.ONLINE_PAYMENT_FLAG.Trim().ToLower() == "y")
                                {
                                    ionlinePaymentsCounts = ionlinePaymentsCounts + 1;
                                }
                            }
                            //Typedetail.onlinePaymentsCounts = "";// ionlinePaymentsCounts.ToString();
                            Typedetail.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();
                            #endregion
                            #endregion

                            #region Set Vehicle Status Summary Total Capacity
                            #region Target service load for today
                            //iTarget_service_load_for_today = 0;
                            iTarget_service_load_for_today = 35;

                            //Typedetail.Target_service_load_for_today = "";// iTarget_service_load_for_today.ToString();
                            #endregion
                            #region Jobcards opened today
                            if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_opened_today = iJobcards_opened_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_opened_today = "";// iJobcards_opened_today.ToString();
                            #endregion
                            #region carryover Jobcards
                            //if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") != Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iCarryover_jobcards = iCarryover_jobcards + 1;
                                }
                            }
                            //Typedetail.Carryover_jobcards = "";// iCarryover_jobcards.ToString();
                            #endregion
                            #region Jobcards billed today
                            if (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_billed_today = iJobcards_billed_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_billed_today = "";// iJobcards_billed_today.ToString();
                            #endregion
                            #endregion


                            #region Stage Details
                            #region Commented Code
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim()))
                            //{
                            //    iGate_In_Counts = iGate_In_Counts + 1;
                            //}
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            //{
                            //    iGate_Out_Counts = iGate_Out_Counts + 1;
                            //    iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                            //}

                            //if (Typedetail.STAGE.Trim().ToLower() == "shopfloor")
                            //{
                            //    iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "bay allocated")
                            //{
                            //    iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;

                            //    iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final washing")
                            //{
                            //    iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;

                            //    iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final inspection")
                            //{
                            //    iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;

                            //    iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "tester line")
                            //{
                            //    iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;

                            //    iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                            //}
                            #endregion
                            if (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim()))
                            {
                                iGate_In_Counts = iGate_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "si")//shopfloor in
                            {
                                iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "shopfloor out")
                            {
                                iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "bay allocated")
                            {
                                iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "bay allocated out")
                            {
                                iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final washing")
                            {
                                iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final washing out")
                            {
                                iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "fi")//final inspection in
                            {
                                iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final inspection out")//final inspection
                            {
                                iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "tester line in")
                            {
                                iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "tester line out")
                            {
                                iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                            }
                            if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            {
                                iGate_Out_Counts = iGate_Out_Counts + 1;
                            }
                            #endregion

                            Details.Add(Typedetail);
                        }
                    }
                }

                QMClusterMonitoringJobCardResult QMResult = new QMClusterMonitoringJobCardResult();
                List<QMClusterMonitoringJobCardResult> clusterDetailsResult = new List<QMClusterMonitoringJobCardResult>();

                List<string> clusters = Details.Select(c => c.Cluster).Distinct().ToList();
                List<QMClusterMonitoringJobCard> clusterDetails = new List<QMClusterMonitoringJobCard>();
                foreach (string cluster in clusters)
                {
                    var clusterData = Details.Where(c => c.Cluster == cluster).ToList();
                    QMClusterMonitoringJobCard dd = new QMClusterMonitoringJobCard();
                    dd.Cluster = cluster;
                    var ddaaa = new List<QMMonitoringJobCard>();
                    ddaaa.AddRange(clusterData);
                    dd.ItemCount = clusterData.Count.ToString();
                    dd.ClusterDetails = ddaaa;
                    clusterDetails.Add(dd);
                }
                QMResult.ClusterData = clusterDetails;

                QMResult.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                QMResult.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                QMResult.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                QMResult.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                QMResult.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();

                QMResult.Target_service_load_for_today = iTarget_service_load_for_today.ToString();
                QMResult.Jobcards_opened_today = iJobcards_opened_today.ToString();
                QMResult.Carryover_jobcards = iCarryover_jobcards.ToString();
                QMResult.Jobcards_billed_today = iJobcards_billed_today.ToString();

                QMResult.Gate_In_Counts = iGate_In_Counts.ToString();
                QMResult.Gate_Out_Counts = iGate_Out_Counts.ToString();
                QMResult.ShopFloor_In_Counts = iShopFloor_In_Counts.ToString();
                QMResult.ShopFloor_Out_Counts = iShopFloor_Out_Counts.ToString();
                QMResult.BayAllocated_In_Counts = iBayAllocated_In_Counts.ToString();
                QMResult.BayAllocated_Out_Counts = iBayAllocated_Out_Counts.ToString();
                QMResult.FinalWashing_In_Counts = iFinalWashing_In_Counts.ToString();
                QMResult.FinalWashing_Out_Counts = iFinalWashing_Out_Counts.ToString();
                QMResult.FinalInspection_In_Counts = iFinalInspection_In_Counts.ToString();
                QMResult.FinalInspection_Out_Counts = iFinalInspection_Out_Counts.ToString();
                QMResult.TesterLine_In_Counts = iTesterLine_In_Counts.ToString();
                QMResult.TesterLine_Out_Counts = iTesterLine_Out_Counts.ToString();


                clusterDetailsResult.Add(QMResult);


                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                //response.result = clusterDetails;
                response.result = clusterDetailsResult;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCard");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #region Private Internal Method
        private BaseListReturnType<QMClusterMonitoringJobCardResult> QMMonitoringJobCard_Internal(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            BaseListReturnType<QMClusterMonitoringJobCardResult> response = new BaseListReturnType<QMClusterMonitoringJobCardResult>();

            QMMonitoringJobCard Typedetail = null;
            List<QMMonitoringJobCard> Details;
            //Validate Token
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
                cmd.CommandText = Usp_QMMonitoringJobCard;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_mointorjc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCard>();

                int iVehBilledWithin4HoursCounts = 0;
                int iVehBilledWithin4HoursPerc = 0;
                int iVehLess1HourRemainAsPromiseCounts = 0;
                int icustomerWaitInLoungeCounts = 0;
                int ionlinePaymentsCounts = 0;

                int iTotalVehBilledTillNowCounts = 0;

                int iTarget_service_load_for_today = 0;
                int iJobcards_opened_today = 0;
                int iCarryover_jobcards = 0;
                int iJobcards_billed_today = 0;

                int iGate_In_Counts = 0;
                int iGate_Out_Counts = 0;
                int iShopFloor_In_Counts = 0;
                int iShopFloor_Out_Counts = 0;
                int iBayAllocated_In_Counts = 0;
                int iBayAllocated_Out_Counts = 0;
                int iFinalWashing_In_Counts = 0;
                int iFinalWashing_Out_Counts = 0;
                int iFinalInspection_In_Counts = 0;
                int iFinalInspection_Out_Counts = 0;
                int iTesterLine_In_Counts = 0;
                int iTesterLine_Out_Counts = 0;

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        //int iSNo = 0;

                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCard();

                            //iSNo = iSNo + 1;

                            //Typedetail.SNo = iSNo.ToString();

                            Typedetail.APPOINTMENT_TYPE = Convert.ToString(row["APPOINTMENT_TYPE"]);
                            Typedetail.REG_NUM = Convert.ToString(row["REG_NUM"]);
                            Typedetail.JOB_CARD_NUM = Convert.ToString(row["JOB_CARD_NUM"]);
                            Typedetail.SRV_TYPE = Convert.ToString(row["SRV_TYPE"]);
                            Typedetail.MODEL = Convert.ToString(row["MODEL"]);
                            Typedetail.SRV_ADV_CD = Convert.ToString(row["SRV_ADV_CD"]);
                            Typedetail.SRV_SDV_NAME = Convert.ToString(row["SRV_SDV_NAME"]);
                            Typedetail.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            Typedetail.JC_OPEN_DATE = Convert.ToString(row["JC_OPEN_DATE"]);
                            Typedetail.PROM_DATE = Convert.ToString(row["PROM_DATE"]);
                            Typedetail.JC_CLOSE_DATE = Convert.ToString(row["JC_CLOSE_DATE"]);
                            Typedetail.JC_BILL_DATE = Convert.ToString(row["JC_BILL_DATE"]);
                            Typedetail.GATE_OUT_TIME = Convert.ToString(row["GATE_OUT_TIME"]);
                            Typedetail.STAGE = Convert.ToString(row["STAGE"]);
                            Typedetail.TIME_IN_STAGE = Convert.ToString(row["TIME_IN_STAGE"]);
                            Typedetail.DELAY_REASON = Convert.ToString(row["DELAY_REASON"]);
                            Typedetail.WAITING_YN = Convert.ToString(row["WAITING_YN"]);
                            Typedetail.ONLINE_PAYMENT_FLAG = Convert.ToString(row["ONLINE_PAYMENT_FLAG"]);


                            #region Cluster Name Set
                            //Typedetail.Cluster = "";
                            Typedetail.Cluster = "WORK IN PROGRESS";

                            //if (string.IsNullOrEmpty(Typedetail.STAGE.Trim()))
                            //{
                            //    Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                            //}
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.STAGE.Trim())))
                            {
                                Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                                Typedetail.STAGE = "Pending for Shopfloor";
                            }

                            //if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor") && (string.IsNullOrEmpty(Typedetail.TIME_IN_STAGE.Trim())))
                            if ((Typedetail.STAGE.Trim().ToLower() == "si") && (string.IsNullOrEmpty(Typedetail.TIME_IN_STAGE.Trim())))// add logic here current time minus si in time
                            {
                                //Typedetail.Cluster = "BAY LOCATION PENDING";
                                Typedetail.Cluster = "VEHICLE ON SHOPFLOOR";
                            }

                            ////if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor") && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            ////if ((Typedetail.STAGE.Trim().ToLower() == "shopfloor out") && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            //if (Typedetail.STAGE.Trim().ToLower() == "shopfloor out")
                            //{
                            //    Typedetail.Cluster = "WORK IN PROGRESS";
                            //}

                            //if (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim()))// add logic here where bay allocated in and out time calculation
                            //{
                            //    Typedetail.Cluster = "WORK IN PROGRESS";
                            //}

                            if (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim()))// add logic here si out time is available
                            {
                                Typedetail.Cluster = "SHOPFLOOR OUT, JC NOT CLOSED";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                Typedetail.Cluster = "JC CLOSED, BUT NOT BILLED";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED, BUT NOT GATE OUT";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED AND GATE OUT";
                            }
                            #endregion

                            #region Set Parameters and No of Vehicle
                            #region Total Vehicle Billed till now Counts
                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                iTotalVehBilledTillNowCounts = iTotalVehBilledTillNowCounts + 1;
                            }
                            #endregion

                            #region Vehicle Billed Within 4 Hours
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    DateTime d_JC_OPEN_DATE, d_JC_BILL_DATE;
                                    d_JC_OPEN_DATE = Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim());
                                    d_JC_BILL_DATE = Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim());

                                    TimeSpan span = d_JC_BILL_DATE.Subtract(d_JC_OPEN_DATE);
                                    if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 240))//within 4 hours
                                    {
                                        iVehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts + 1;
                                    }
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursCounts = "";// iVehBilledWithin4HoursCounts.ToString();
                            Typedetail.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                            #endregion
                            #region % Vehicle Billed Within 4 Hours
                            if (!string.IsNullOrEmpty(Typedetail.VehBilledWithin4HoursCounts.Trim()))
                            {
                                if (Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) > 0)
                                {
                                    //iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / detailTable.Rows.Count;
                                    iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / iTotalVehBilledTillNowCounts;
                                }
                                else
                                {
                                    iVehBilledWithin4HoursPerc = 0;
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursPerc = "";// iVehBilledWithin4HoursPerc.ToString() + "%";
                            Typedetail.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                            #endregion
                            #region Vehicle in which Less than 1 Hour Remaining As per Promised time
                            if ((!string.IsNullOrEmpty(Typedetail.PROM_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            {
                                DateTime d_PROM_DATE;
                                DateTime d_DateTimeNow;
                                d_PROM_DATE = Convert.ToDateTime(Typedetail.PROM_DATE.Trim());
                                d_DateTimeNow = Convert.ToDateTime(DateTime.Now);

                                TimeSpan span = d_PROM_DATE.Subtract(d_DateTimeNow);
                                if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 60))//within 1 hour
                                {
                                    iVehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts + 1;
                                }
                            }
                            //Typedetail.VehLess1HourRemainAsPromiseCounts = "";// iVehLess1HourRemainAsPromiseCounts.ToString();
                            Typedetail.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                            #endregion
                            #region customer Waiting In customer Lounge
                            if (!string.IsNullOrEmpty(Typedetail.WAITING_YN.Trim()))
                            {
                                if (Typedetail.WAITING_YN.Trim().ToLower() == "y")
                                {
                                    icustomerWaitInLoungeCounts = icustomerWaitInLoungeCounts + 1;
                                }
                            }
                            //Typedetail.customerWaitInLoungeCounts = "";// icustomerWaitInLoungeCounts.ToString();
                            Typedetail.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                            #endregion
                            #region No of online Payments done
                            if (!string.IsNullOrEmpty(Typedetail.ONLINE_PAYMENT_FLAG.Trim()))
                            {
                                if (Typedetail.ONLINE_PAYMENT_FLAG.Trim().ToLower() == "y")
                                {
                                    ionlinePaymentsCounts = ionlinePaymentsCounts + 1;
                                }
                            }
                            //Typedetail.onlinePaymentsCounts = "";// ionlinePaymentsCounts.ToString();
                            Typedetail.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();
                            #endregion
                            #endregion

                            #region Set Vehicle Status Summary Total Capacity
                            #region Target service load for today
                            //iTarget_service_load_for_today = 0;
                            iTarget_service_load_for_today = 35;

                            //Typedetail.Target_service_load_for_today = "";// iTarget_service_load_for_today.ToString();
                            #endregion
                            #region Jobcards opened today
                            if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_opened_today = iJobcards_opened_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_opened_today = "";// iJobcards_opened_today.ToString();
                            #endregion
                            #region carryover Jobcards
                            //if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") != Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iCarryover_jobcards = iCarryover_jobcards + 1;
                                }
                            }
                            //Typedetail.Carryover_jobcards = "";// iCarryover_jobcards.ToString();
                            #endregion
                            #region Jobcards billed today
                            if (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_billed_today = iJobcards_billed_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_billed_today = "";// iJobcards_billed_today.ToString();
                            #endregion
                            #endregion


                            #region Stage Details
                            #region Commented Code
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim()))
                            //{
                            //    iGate_In_Counts = iGate_In_Counts + 1;
                            //}
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            //{
                            //    iGate_Out_Counts = iGate_Out_Counts + 1;
                            //    iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                            //}

                            //if (Typedetail.STAGE.Trim().ToLower() == "shopfloor")
                            //{
                            //    iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "bay allocated")
                            //{
                            //    iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;

                            //    iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final washing")
                            //{
                            //    iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;

                            //    iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final inspection")
                            //{
                            //    iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;

                            //    iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "tester line")
                            //{
                            //    iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;

                            //    iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                            //}
                            #endregion
                            if (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim()))
                            {
                                iGate_In_Counts = iGate_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "si")//shopfloor in
                            {
                                iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "shopfloor out")
                            {
                                iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "bay allocated")
                            {
                                iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "bay allocated out")
                            {
                                iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final washing")
                            {
                                iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final washing out")
                            {
                                iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "fi")//final inspection in
                            {
                                iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "final inspection out")//final inspection
                            {
                                iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "tester line in")
                            {
                                iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                            }
                            if (Typedetail.STAGE.Trim().ToLower() == "tester line out")
                            {
                                iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                            }
                            if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            {
                                iGate_Out_Counts = iGate_Out_Counts + 1;
                            }
                            #endregion

                            Details.Add(Typedetail);
                        }
                    }
                }

                QMClusterMonitoringJobCardResult QMResult = new QMClusterMonitoringJobCardResult();
                List<QMClusterMonitoringJobCardResult> clusterDetailsResult = new List<QMClusterMonitoringJobCardResult>();

                List<string> clusters = Details.Select(c => c.Cluster).Distinct().ToList();
                List<QMClusterMonitoringJobCard> clusterDetails = new List<QMClusterMonitoringJobCard>();
                foreach (string cluster in clusters)
                {
                    var clusterData = Details.Where(c => c.Cluster == cluster).ToList();
                    QMClusterMonitoringJobCard dd = new QMClusterMonitoringJobCard();
                    dd.Cluster = cluster;
                    var ddaaa = new List<QMMonitoringJobCard>();
                    ddaaa.AddRange(clusterData);
                    dd.ItemCount = clusterData.Count.ToString();
                    dd.ClusterDetails = ddaaa;
                    clusterDetails.Add(dd);
                }
                QMResult.ClusterData = clusterDetails;

                QMResult.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                QMResult.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                QMResult.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                QMResult.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                QMResult.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();

                QMResult.Target_service_load_for_today = iTarget_service_load_for_today.ToString();
                QMResult.Jobcards_opened_today = iJobcards_opened_today.ToString();
                QMResult.Carryover_jobcards = iCarryover_jobcards.ToString();
                QMResult.Jobcards_billed_today = iJobcards_billed_today.ToString();

                QMResult.Gate_In_Counts = iGate_In_Counts.ToString();
                QMResult.Gate_Out_Counts = iGate_Out_Counts.ToString();
                QMResult.ShopFloor_In_Counts = iShopFloor_In_Counts.ToString();
                QMResult.ShopFloor_Out_Counts = iShopFloor_Out_Counts.ToString();
                QMResult.BayAllocated_In_Counts = iBayAllocated_In_Counts.ToString();
                QMResult.BayAllocated_Out_Counts = iBayAllocated_Out_Counts.ToString();
                QMResult.FinalWashing_In_Counts = iFinalWashing_In_Counts.ToString();
                QMResult.FinalWashing_Out_Counts = iFinalWashing_Out_Counts.ToString();
                QMResult.FinalInspection_In_Counts = iFinalInspection_In_Counts.ToString();
                QMResult.FinalInspection_Out_Counts = iFinalInspection_Out_Counts.ToString();
                QMResult.TesterLine_In_Counts = iTesterLine_In_Counts.ToString();
                QMResult.TesterLine_Out_Counts = iTesterLine_Out_Counts.ToString();


                clusterDetailsResult.Add(QMResult);


                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                //response.result = clusterDetails;
                response.result = clusterDetailsResult;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCard");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion
        #endregion

        #region for QMMonitoringJobCardStageWiseDetails
        public BaseListReturnType<QMMonitoringJobCardStageWiseDetails> QMMonitoringJobCardStageWiseDetails(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            BaseListReturnType<QMMonitoringJobCardStageWiseDetails> response = new BaseListReturnType<QMMonitoringJobCardStageWiseDetails>();

            QMMonitoringJobCardStageWiseDetails Typedetail = null;
            List<QMMonitoringJobCardStageWiseDetails> Details;
            //Validate Token
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
                cmd.CommandText = Usp_QMMonitoringJobCardStageWiseDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("pn_vts_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCardStageWiseDetails>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCardStageWiseDetails();

                            Typedetail.RO_NUM = Convert.ToString(row["RO_NUM"]);
                            Typedetail.STAGE_ID = Convert.ToString(row["STAGE_ID"]);
                            Typedetail.STAGE_DESC = Convert.ToString(row["STAGE_DESC"]);
                            Typedetail.BAY_FLAG = Convert.ToString(row["BAY_FLAG"]);
                            Typedetail.STAGE_IN_TIME = Convert.ToString(row["STAGE_IN_TIME"]);
                            Typedetail.STAGE_OUT_TIME = Convert.ToString(row["STAGE_OUT_TIME"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCardStageWiseDetails");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for VTSStageWiseDetails
        public BaseListReturnType<VTSStageDetails> VTSStageWiseDetails(string pn_dealer_map_cd, string pn_loc_Cd, string pn_date)
        {
            BaseListReturnType<VTSStageDetails> response = new BaseListReturnType<VTSStageDetails>();

            VTSStageDetails Typedetail = null;
            List<VTSStageDetails> Details;
            //Validate Token
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
                cmd.CommandText = Usp_VTSStageDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("pn_vts_stage_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<VTSStageDetails>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new VTSStageDetails();

                            Typedetail.STAGE_ID = Convert.ToString(row["STAGE_ID"]);
                            Typedetail.STAGE_DESC = Convert.ToString(row["STAGE_DESC"]);
                            Typedetail.IN_CNT = Convert.ToString(row["IN_CNT"]);
                            Typedetail.OUT_CNT = Convert.ToString(row["OUT_CNT"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_VTSStageDetails");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region Clusterdata related
        private List<QMMonitoringJobCardStageWiseDetails> MonitoringJobCardStageWiseDetails(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            QMMonitoringJobCardStageWiseDetails Typedetail = null;
            List<QMMonitoringJobCardStageWiseDetails> Details;

            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_QMMonitoringJobCardStageWiseDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;
                cmd.Parameters.Add("pn_vts_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    con.Close();
                    return null;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCardStageWiseDetails>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCardStageWiseDetails();
                            Typedetail.RO_NUM = Convert.ToString(row["RO_NUM"]);
                            Typedetail.STAGE_ID = Convert.ToString(row["STAGE_ID"]);
                            Typedetail.STAGE_DESC = Convert.ToString(row["STAGE_DESC"]);
                            Typedetail.BAY_FLAG = Convert.ToString(row["BAY_FLAG"]);
                            Typedetail.STAGE_IN_TIME = Convert.ToString(row["STAGE_IN_TIME"]);
                            Typedetail.STAGE_OUT_TIME = Convert.ToString(row["STAGE_OUT_TIME"]);
                            Details.Add(Typedetail);
                        }
                    }
                }
                return Details;
            }
            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCardStageWiseDetails");
                con.Close();
                cmd.Dispose();
                return null;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
        }
        public BaseListReturnType<QMClusterMonitoringJobCardsResult> QMMonitoringJobCards(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            BaseListReturnType<QMClusterMonitoringJobCardsResult> response = new BaseListReturnType<QMClusterMonitoringJobCardsResult>();
            QMMonitoringJobCards Typedetail = null;
            List<QMMonitoringJobCards> Details;

            #region Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                List<string> clusters = new List<string>();
                clusters.Add("JC OPENED, NOT ENTERED SHOPFLOOR");
                clusters.Add("VEHICLE ON SHOPFLOOR");//BAY LOCATION PENDING
                clusters.Add("SHOPFLOOR OUT, JC NOT CLOSED");
                clusters.Add("JC CLOSED, BUT NOT BILLED");
                clusters.Add("JC BILLED, BUT NOT GATE OUT");
                clusters.Add("JC BILLED AND GATE OUT");
                clusters.Add("WORK IN PROGRESS");

                List<QMMonitoringJobCardStageWiseDetails> jobCardStageWiseDetails = MonitoringJobCardStageWiseDetails(pn_parent_group, pn_dealer_map_cd, pn_loc_Cd, pn_comp_fa, pn_date);
                if (jobCardStageWiseDetails == null)
                {
                    jobCardStageWiseDetails = new List<DataContract.QMMonitoringJobCardStageWiseDetails>();
                    //jobCardStageWiseDetails.Add(new DataContract.QMMonitoringJobCardStageWiseDetails { STAGE_OUT_TIME = "" });
                }
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_QMMonitoringJobCard;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_mointorjc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCards>();

                #region Variables
                int iVehBilledWithin4HoursCounts = 0;
                int iVehBilledWithin4HoursPerc = 0;
                int iVehLess1HourRemainAsPromiseCounts = 0;
                int icustomerWaitInLoungeCounts = 0;
                int ionlinePaymentsCounts = 0;

                int iTotalVehBilledTillNowCounts = 0;

                int iTarget_service_load_for_today = 0;
                int iJobcards_opened_today = 0;
                int iCarryover_jobcards = 0;
                int iJobcards_billed_today = 0;

                int iGate_In_Counts = 0;
                int iGate_Out_Counts = 0;
                int iUnderBodyWashing_In_Counts = 0;
                int iUnderBodyWashing_Out_Counts = 0;
                int iShopFloor_In_Counts = 0;
                int iShopFloor_Out_Counts = 0;
                int iBayAllocated_In_Counts = 0;
                int iBayAllocated_Out_Counts = 0;
                int iFinalWashing_In_Counts = 0;
                int iFinalWashing_Out_Counts = 0;
                int iFinalInspection_In_Counts = 0;
                int iFinalInspection_Out_Counts = 0;
                int iTesterLine_In_Counts = 0;
                int iTesterLine_Out_Counts = 0;
                #endregion
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        //int iSNo = 0;
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCards();
                            //iSNo = iSNo + 1;
                            //Typedetail.SNo = iSNo.ToString();
                            Typedetail.APPOINTMENT_TYPE = Convert.ToString(row["APPOINTMENT_TYPE"]);
                            Typedetail.REG_NUM = Convert.ToString(row["REG_NUM"]);
                            Typedetail.JOB_CARD_NUM = Convert.ToString(row["JOB_CARD_NUM"]);
                            Typedetail.SRV_TYPE = Convert.ToString(row["SRV_TYPE"]);
                            Typedetail.MODEL = Convert.ToString(row["MODEL"]);
                            Typedetail.SRV_ADV_CD = Convert.ToString(row["SRV_ADV_CD"]);
                            Typedetail.SRV_SDV_NAME = Convert.ToString(row["SRV_SDV_NAME"]);
                            Typedetail.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            Typedetail.JC_OPEN_DATE = Convert.ToString(row["JC_OPEN_DATE"]);
                            Typedetail.PROM_DATE = Convert.ToString(row["PROM_DATE"]);
                            Typedetail.JC_CLOSE_DATE = Convert.ToString(row["JC_CLOSE_DATE"]);
                            Typedetail.JC_BILL_DATE = Convert.ToString(row["JC_BILL_DATE"]);
                            Typedetail.GATE_OUT_TIME = Convert.ToString(row["GATE_OUT_TIME"]);
                            Typedetail.STAGE = Convert.ToString(row["STAGE"]);
                            Typedetail.TIME_IN_STAGE = Convert.ToString(row["TIME_IN_STAGE"]);
                            Typedetail.DELAY_REASON = Convert.ToString(row["DELAY_REASON"]);
                            Typedetail.WAITING_YN = Convert.ToString(row["WAITING_YN"]);
                            Typedetail.ONLINE_PAYMENT_FLAG = Convert.ToString(row["ONLINE_PAYMENT_FLAG"]);

                            #region Cluster Name Set

                            //Typedetail.Cluster = "";

                            #region not in stagewise list
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") != Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    //iCarryover_jobcards = iCarryover_jobcards + 1;
                                    string jobcardNo = Typedetail.JOB_CARD_NUM;
                                    var checKData = jobCardStageWiseDetails.FirstOrDefault(j => j.RO_NUM == jobcardNo);
                                    if (checKData == null)
                                    {
                                        Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                                        Typedetail.STAGE = "PENDING FOR SHOPFLOOR ENTRY";
                                        Typedetail.STAGE_DESC = "PENDING FOR SHOPFLOOR ENTRY";
                                        Typedetail.STAGE_ID = string.Empty;
                                        Typedetail.STAGE_IN_TIME = string.Empty;
                                        Typedetail.STAGE_OUT_TIME = string.Empty;
                                    }
                                }
                                else if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    string jobcardNo = Typedetail.JOB_CARD_NUM;
                                    var checKData = jobCardStageWiseDetails.FirstOrDefault(j => j.RO_NUM == jobcardNo);
                                    if (checKData == null)
                                    {
                                        Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                                        Typedetail.STAGE = "PENDING FOR SHOPFLOOR ENTRY";
                                        Typedetail.STAGE_DESC = "PENDING FOR SHOPFLOOR ENTRY";
                                        Typedetail.STAGE_ID = string.Empty;
                                        Typedetail.STAGE_IN_TIME = string.Empty;
                                        Typedetail.STAGE_OUT_TIME = string.Empty;
                                    }
                                }
                            }
                            #endregion


                            List<QMMonitoringJobCardStageWiseDetails> stageWiseDetails = jobCardStageWiseDetails.Where(j => j.RO_NUM == Typedetail.JOB_CARD_NUM).ToList();
                            if (stageWiseDetails != null && stageWiseDetails.Count > 0)
                            {
                                var OpenedButNoonShopFloor = stageWiseDetails.FirstOrDefault(s => s.STAGE_ID.ToLower() != "si" && s.STAGE_IN_TIME.Trim() == "");
                                var onShopFloor = stageWiseDetails.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() == "");   //&& s.BAY_FLAG.ToLower() == "n"
                                try
                                {
                                    onShopFloor = stageWiseDetails.Where(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() == "").OrderByDescending(s => Convert.ToDateTime(s.STAGE_IN_TIME.Trim())).FirstOrDefault(); ;//&& s.BAY_FLAG.ToLower() == "n"
                                }
                                catch
                                {
                                }
                                //var ShopFloorOutJCNotClosed = stageWiseDetails.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "y");
                                var ShopFloorOutJCNotClosed = stageWiseDetails.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() != "" && (s.BAY_FLAG.ToLower() == "y" || s.BAY_FLAG.ToLower() == "n"));
                                //var WorkinProgress = stageWiseDetails.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() == "" && s.BAY_FLAG.ToLower() == "y");

                                if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && OpenedButNoonShopFloor != null)
                                {
                                    Typedetail.Cluster = "JC OPENED, NOT ENTERED SHOPFLOOR";
                                    Typedetail.STAGE = "PENDING FOR SHOPFLOOR ENTRY";

                                    Typedetail.STAGE_DESC = "PENDING FOR SHOPFLOOR ENTRY";
                                    Typedetail.STAGE_ID = OpenedButNoonShopFloor.STAGE_ID;
                                    Typedetail.STAGE_IN_TIME = OpenedButNoonShopFloor.STAGE_IN_TIME;
                                    Typedetail.STAGE_OUT_TIME = OpenedButNoonShopFloor.STAGE_OUT_TIME;
                                }
                                else if (onShopFloor != null)
                                {
                                    //Typedetail.Cluster = "BAY LOCATION PENDING";
                                    Typedetail.Cluster = "VEHICLE ON SHOPFLOOR";

                                    Typedetail.STAGE_DESC = "SHOP FLOOR";
                                    Typedetail.BayStatusFlag = onShopFloor.BAY_FLAG;
                                    Typedetail.STAGE_ID = onShopFloor.STAGE_ID;
                                    Typedetail.STAGE_IN_TIME = onShopFloor.STAGE_IN_TIME;
                                    Typedetail.STAGE_OUT_TIME = onShopFloor.STAGE_OUT_TIME;
                                }
                                else if ((string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())) && ShopFloorOutJCNotClosed != null)
                                {
                                    Typedetail.Cluster = "SHOPFLOOR OUT, JC NOT CLOSED";

                                    Typedetail.STAGE_DESC = "PENDING FOR JOB CARD CLOSING";
                                    Typedetail.STAGE_ID = ShopFloorOutJCNotClosed.STAGE_ID;
                                    Typedetail.STAGE_IN_TIME = ShopFloorOutJCNotClosed.STAGE_IN_TIME;
                                    Typedetail.STAGE_OUT_TIME = ShopFloorOutJCNotClosed.STAGE_OUT_TIME;
                                }
                                //else if (WorkinProgress != null)
                                //{
                                //    Typedetail.Cluster = "WORK IN PROGRESS";

                                //    Typedetail.STAGE_DESC = WorkinProgress.STAGE_DESC;
                                //    Typedetail.STAGE_ID = WorkinProgress.STAGE_ID;
                                //    Typedetail.STAGE_IN_TIME = WorkinProgress.STAGE_IN_TIME;
                                //    Typedetail.STAGE_OUT_TIME = WorkinProgress.STAGE_OUT_TIME;
                                //}
                            }
                            if ((!string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                Typedetail.Cluster = "JC CLOSED, BUT NOT BILLED";

                                Typedetail.STAGE_DESC = "CLOSED";
                                Typedetail.STAGE_ID = "CL";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED, BUT NOT GATE OUT";

                                Typedetail.STAGE_DESC = "BILLED";
                                Typedetail.STAGE_ID = "BL";
                            }

                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim())))
                            {
                                Typedetail.Cluster = "JC BILLED AND GATE OUT";

                                Typedetail.STAGE_DESC = "GATE OUT";
                                Typedetail.STAGE_ID = "GO";
                            }
                            #endregion

                            #region Set Parameters and No of Vehicle
                            #region Total Vehicle Billed till now Counts
                            if ((!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iTotalVehBilledTillNowCounts = iTotalVehBilledTillNowCounts + 1;
                                }
                            }
                            #endregion

                            #region Vehicle Billed Within 4 Hours
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if ((Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")) && (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")))
                                {
                                    DateTime d_JC_OPEN_DATE, d_JC_BILL_DATE;
                                    d_JC_OPEN_DATE = Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim());
                                    d_JC_BILL_DATE = Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim());

                                    TimeSpan span = d_JC_BILL_DATE.Subtract(d_JC_OPEN_DATE);
                                    if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 240))//within 4 hours
                                    {
                                        iVehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts + 1;
                                    }
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursCounts = "";// iVehBilledWithin4HoursCounts.ToString();
                            Typedetail.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                            #endregion
                            #region % Vehicle Billed Within 4 Hours
                            if (!string.IsNullOrEmpty(Typedetail.VehBilledWithin4HoursCounts.Trim()))
                            {
                                if (Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) > 0 && iTotalVehBilledTillNowCounts > 0)
                                {
                                    //iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / detailTable.Rows.Count;
                                    iVehBilledWithin4HoursPerc = Convert.ToInt32(Convert.ToInt32(Typedetail.VehBilledWithin4HoursCounts.Trim()) * 100) / iTotalVehBilledTillNowCounts;
                                }
                                else
                                {
                                    iVehBilledWithin4HoursPerc = 0;
                                }
                            }
                            //Typedetail.VehBilledWithin4HoursPerc = "";// iVehBilledWithin4HoursPerc.ToString() + "%";
                            Typedetail.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                            #endregion
                            #region Vehicle in which Less than 1 Hour Remaining As per Promised time
                            if ((!string.IsNullOrEmpty(Typedetail.PROM_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_CLOSE_DATE.Trim())))
                            {
                                DateTime d_PROM_DATE;
                                DateTime d_DateTimeNow;
                                d_PROM_DATE = Convert.ToDateTime(Typedetail.PROM_DATE.Trim());
                                d_DateTimeNow = Convert.ToDateTime(DateTime.Now);

                                TimeSpan span = d_PROM_DATE.Subtract(d_DateTimeNow);
                                if ((span.TotalMinutes > 0) && (span.TotalMinutes <= 60))//within 1 hour
                                {
                                    iVehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts + 1;
                                }
                            }
                            //Typedetail.VehLess1HourRemainAsPromiseCounts = "";// iVehLess1HourRemainAsPromiseCounts.ToString();
                            Typedetail.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                            #endregion
                            #region customer Waiting In customer Lounge
                            if ((!string.IsNullOrEmpty(Typedetail.WAITING_YN.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Typedetail.WAITING_YN.Trim().ToLower() == "y")
                                {
                                    icustomerWaitInLoungeCounts = icustomerWaitInLoungeCounts + 1;
                                }
                            }
                            //Typedetail.customerWaitInLoungeCounts = "";// icustomerWaitInLoungeCounts.ToString();
                            Typedetail.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                            #endregion
                            #region No of online Payments done
                            if (!string.IsNullOrEmpty(Typedetail.ONLINE_PAYMENT_FLAG.Trim()))
                            {
                                if (Typedetail.ONLINE_PAYMENT_FLAG.Trim().ToLower() == "y")
                                {
                                    ionlinePaymentsCounts = ionlinePaymentsCounts + 1;
                                }
                            }
                            //Typedetail.onlinePaymentsCounts = "";// ionlinePaymentsCounts.ToString();
                            Typedetail.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();
                            #endregion
                            #endregion

                            #region Set Vehicle Status Summary Total Capacity
                            #region Target service load for today
                            //iTarget_service_load_for_today = 0;
                            iTarget_service_load_for_today = 35;

                            //Typedetail.Target_service_load_for_today = "";// iTarget_service_load_for_today.ToString();
                            #endregion
                            #region Jobcards opened today
                            if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_opened_today = iJobcards_opened_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_opened_today = "";// iJobcards_opened_today.ToString();
                            #endregion
                            #region carryover Jobcards
                            //if (!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim()))
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim())))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_OPEN_DATE.Trim()).ToString("yyyy-MM-dd") != Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iCarryover_jobcards = iCarryover_jobcards + 1;
                                }
                            }
                            //Typedetail.Carryover_jobcards = "";// iCarryover_jobcards.ToString();
                            #endregion
                            #region Jobcards billed today
                            if (!string.IsNullOrEmpty(Typedetail.JC_BILL_DATE.Trim()))
                            {
                                if (Convert.ToDateTime(Typedetail.JC_BILL_DATE.Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                                {
                                    iJobcards_billed_today = iJobcards_billed_today + 1;
                                }
                            }
                            //Typedetail.Jobcards_billed_today = "";// iJobcards_billed_today.ToString();
                            #endregion
                            #endregion


                            #region Stage Details
                            #region Commented Code
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim()))
                            //{
                            //    iGate_In_Counts = iGate_In_Counts + 1;
                            //}
                            //if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            //{
                            //    iGate_Out_Counts = iGate_Out_Counts + 1;
                            //    iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                            //}

                            //if (Typedetail.STAGE.Trim().ToLower() == "shopfloor")
                            //{
                            //    iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "bay allocated")
                            //{
                            //    iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;

                            //    iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final washing")
                            //{
                            //    iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;

                            //    iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "final inspection")
                            //{
                            //    iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;

                            //    iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                            //}
                            //if (Typedetail.STAGE.Trim().ToLower() == "tester line")
                            //{
                            //    iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;

                            //    iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                            //}
                            #endregion
                            if ((!string.IsNullOrEmpty(Typedetail.JC_OPEN_DATE.Trim())) && (!string.IsNullOrEmpty(Typedetail.GATE_IN_TIME.Trim())))
                            {
                                iGate_In_Counts = iGate_In_Counts + 1;
                            }
                            if (!string.IsNullOrEmpty(Typedetail.GATE_OUT_TIME.Trim()))
                            {
                                iGate_Out_Counts = iGate_Out_Counts + 1;
                            }

                            List<QMMonitoringJobCardStageWiseDetails> stageWiseDetails2 = jobCardStageWiseDetails.Where(j => j.RO_NUM == Typedetail.JOB_CARD_NUM).ToList();
                            if (stageWiseDetails2 != null && stageWiseDetails2.Count > 0)
                            {
                                var UnderBodyWashingInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "ui" && s.STAGE_DESC.ToLower() == "under washing" && s.STAGE_IN_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");
                                var UnderBodyWashingOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "ui" && s.STAGE_DESC.ToLower() == "under washing" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");
                                var UnderBodyWashingInAndOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "ui" && s.STAGE_DESC.ToLower() == "under washing" && s.STAGE_IN_TIME.Trim() != "" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");

                                var ShopFloorInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");
                                var ShopFloorOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");

                                var BayAllocatedInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_IN_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "y");
                                var BayAllocatedOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "si" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "y");

                                var FinalWashingInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "wi" && s.STAGE_DESC.ToLower() == "washing" && s.STAGE_IN_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");
                                var FinalWashingOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "wi" && s.STAGE_DESC.ToLower() == "washing" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");

                                var FinalInspectionInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "fi" && s.STAGE_IN_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");
                                var FinalInspectionOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "fi" && s.STAGE_OUT_TIME.Trim() != "" && s.BAY_FLAG.ToLower() == "n");

                                var TesterLineInTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "ti" && s.STAGE_IN_TIME.Trim() != "");
                                var TesterLineOutTimeOnly = stageWiseDetails2.FirstOrDefault(s => s.STAGE_ID.ToLower() == "ti" && s.STAGE_OUT_TIME.Trim() != "");

                                if (UnderBodyWashingInTimeOnly != null)
                                {
                                    iUnderBodyWashing_In_Counts = iUnderBodyWashing_In_Counts + 1;
                                }
                                if (UnderBodyWashingOutTimeOnly != null)
                                {
                                    iUnderBodyWashing_Out_Counts = iUnderBodyWashing_Out_Counts + 1;
                                }

                                if (ShopFloorInTimeOnly != null)
                                {
                                    iShopFloor_In_Counts = iShopFloor_In_Counts + 1;
                                }
                                if (ShopFloorOutTimeOnly != null)
                                {
                                    iShopFloor_Out_Counts = iShopFloor_Out_Counts + 1;
                                }

                                if (BayAllocatedInTimeOnly != null)
                                {
                                    iBayAllocated_In_Counts = iBayAllocated_In_Counts + 1;
                                }
                                if (BayAllocatedOutTimeOnly != null)
                                {
                                    iBayAllocated_Out_Counts = iBayAllocated_Out_Counts + 1;
                                }

                                if (FinalWashingInTimeOnly != null)
                                {
                                    iFinalWashing_In_Counts = iFinalWashing_In_Counts + 1;
                                }
                                if (FinalWashingOutTimeOnly != null)
                                {
                                    iFinalWashing_Out_Counts = iFinalWashing_Out_Counts + 1;
                                }

                                if (FinalInspectionInTimeOnly != null)
                                {
                                    iFinalInspection_In_Counts = iFinalInspection_In_Counts + 1;
                                }
                                if (FinalInspectionOutTimeOnly != null)
                                {
                                    iFinalInspection_Out_Counts = iFinalInspection_Out_Counts + 1;
                                }

                                if (TesterLineInTimeOnly != null)
                                {
                                    iTesterLine_In_Counts = iTesterLine_In_Counts + 1;
                                }
                                if (TesterLineOutTimeOnly != null)
                                {
                                    iTesterLine_Out_Counts = iTesterLine_Out_Counts + 1;
                                }
                            }
                            #endregion

                            Details.Add(Typedetail);
                        }


                        //endof for each loop
                    }
                }

                QMClusterMonitoringJobCardsResult QMResult = new QMClusterMonitoringJobCardsResult();
                List<QMClusterMonitoringJobCardsResult> clusterDetailsResult = new List<QMClusterMonitoringJobCardsResult>();

                List<QMClusterMonitoringJobCards> clusterDetails = new List<QMClusterMonitoringJobCards>();
                foreach (string cluster in clusters)
                {
                    var clusterData = Details.Where(c => c.Cluster == cluster).ToList();
                    QMClusterMonitoringJobCards dd = new QMClusterMonitoringJobCards();
                    if (clusterData != null && clusterData.Count > 0)
                    {
                        dd.Cluster = cluster;
                        var ddaaa = new List<QMMonitoringJobCards>();
                        ddaaa.AddRange(clusterData);
                        dd.ItemCount = clusterData.Count.ToString();
                        dd.ClusterDetails = ddaaa;
                    }
                    else
                    {
                        dd.Cluster = cluster;
                        dd.ItemCount = "0";
                        dd.ClusterDetails = null;
                    }
                    clusterDetails.Add(dd);
                }
                QMResult.ClusterData = clusterDetails;
                QMResult.VehBilledWithin4HoursCounts = iVehBilledWithin4HoursCounts.ToString();
                if (iTotalVehBilledTillNowCounts > 0)
                {
                    iVehBilledWithin4HoursPerc = Convert.ToInt32((iVehBilledWithin4HoursCounts * 100) / iTotalVehBilledTillNowCounts);
                }
                else
                {
                    iVehBilledWithin4HoursPerc = 0;
                }
                QMResult.VehBilledWithin4HoursPerc = iVehBilledWithin4HoursPerc.ToString() + "%";
                QMResult.VehLess1HourRemainAsPromiseCounts = iVehLess1HourRemainAsPromiseCounts.ToString();
                QMResult.customerWaitInLoungeCounts = icustomerWaitInLoungeCounts.ToString();
                QMResult.onlinePaymentsCounts = ionlinePaymentsCounts.ToString();
                QMResult.Target_service_load_for_today = iTarget_service_load_for_today.ToString();
                QMResult.Jobcards_opened_today = iJobcards_opened_today.ToString();
                QMResult.Carryover_jobcards = iCarryover_jobcards.ToString();
                QMResult.Jobcards_billed_today = iJobcards_billed_today.ToString();
                QMResult.Gate_In_Counts = iGate_In_Counts.ToString();
                QMResult.Gate_Out_Counts = iGate_Out_Counts.ToString();
                QMResult.UnderBodyWashing_In_Counts = iUnderBodyWashing_In_Counts.ToString();
                QMResult.UnderBodyWashing_Out_Counts = iUnderBodyWashing_Out_Counts.ToString();
                QMResult.ShopFloor_In_Counts = iShopFloor_In_Counts.ToString();
                QMResult.ShopFloor_Out_Counts = iShopFloor_Out_Counts.ToString();
                QMResult.BayAllocated_In_Counts = iBayAllocated_In_Counts.ToString();
                QMResult.BayAllocated_Out_Counts = iBayAllocated_Out_Counts.ToString();
                QMResult.FinalWashing_In_Counts = iFinalWashing_In_Counts.ToString();
                QMResult.FinalWashing_Out_Counts = iFinalWashing_Out_Counts.ToString();
                QMResult.FinalInspection_In_Counts = iFinalInspection_In_Counts.ToString();
                QMResult.FinalInspection_Out_Counts = iFinalInspection_Out_Counts.ToString();
                QMResult.TesterLine_In_Counts = iTesterLine_In_Counts.ToString();
                QMResult.TesterLine_Out_Counts = iTesterLine_Out_Counts.ToString();


                clusterDetailsResult.Add(QMResult);


                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                //response.result = clusterDetails;
                response.result = clusterDetailsResult;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCard");
                response.code = (int)ServiceMassageCode.ERROR;
                //response.message = ex.Message + " " + ex.ToString();
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }

        public BaseListReturnType<QMMonitoringJobCardOnly> QMMonitoringJobCardOnly(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date)
        {
            BaseListReturnType<QMMonitoringJobCardOnly> response = new BaseListReturnType<QMMonitoringJobCardOnly>();

            QMMonitoringJobCardOnly Typedetail = null;
            List<QMMonitoringJobCardOnly> Details;

            #region Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_QMMonitoringJobCard;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("po_mointorjc_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<QMMonitoringJobCardOnly>();

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new QMMonitoringJobCardOnly();

                            Typedetail.APPOINTMENT_TYPE = Convert.ToString(row["APPOINTMENT_TYPE"]);
                            Typedetail.REG_NUM = Convert.ToString(row["REG_NUM"]);
                            Typedetail.JOB_CARD_NUM = Convert.ToString(row["JOB_CARD_NUM"]);
                            Typedetail.SRV_TYPE = Convert.ToString(row["SRV_TYPE"]);
                            Typedetail.MODEL = Convert.ToString(row["MODEL"]);
                            Typedetail.SRV_ADV_CD = Convert.ToString(row["SRV_ADV_CD"]);
                            Typedetail.SRV_SDV_NAME = Convert.ToString(row["SRV_SDV_NAME"]);
                            Typedetail.GATE_IN_TIME = Convert.ToString(row["GATE_IN_TIME"]);
                            Typedetail.JC_OPEN_DATE = Convert.ToString(row["JC_OPEN_DATE"]);
                            Typedetail.PROM_DATE = Convert.ToString(row["PROM_DATE"]);
                            Typedetail.JC_CLOSE_DATE = Convert.ToString(row["JC_CLOSE_DATE"]);
                            Typedetail.JC_BILL_DATE = Convert.ToString(row["JC_BILL_DATE"]);
                            Typedetail.GATE_OUT_TIME = Convert.ToString(row["GATE_OUT_TIME"]);
                            Typedetail.STAGE = Convert.ToString(row["STAGE"]);
                            Typedetail.TIME_IN_STAGE = Convert.ToString(row["TIME_IN_STAGE"]);
                            Typedetail.DELAY_REASON = Convert.ToString(row["DELAY_REASON"]);
                            Typedetail.WAITING_YN = Convert.ToString(row["WAITING_YN"]);
                            Typedetail.ONLINE_PAYMENT_FLAG = Convert.ToString(row["ONLINE_PAYMENT_FLAG"]);

                            Details.Add(Typedetail);
                        }
                    }
                }

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_QMMonitoringJobCardOnly");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }

        #endregion

        #region for MonitoringVehicleStuckUpDetail
        public BaseListReturnType<MonitoringVehicleStuckUpDetail> MonitoringVehicleStuckUpDetail(string pn_dealer_map_cd, string pn_loc_Cd, string pn_date)
        {
            BaseListReturnType<MonitoringVehicleStuckUpDetail> response = new BaseListReturnType<MonitoringVehicleStuckUpDetail>();

            MonitoringVehicleStuckUpDetail Typedetail = null;
            List<MonitoringVehicleStuckUpDetail> Details;
            //Validate Token
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
                cmd.CommandText = Usp_MonitoringVehicleStuckUpDetail;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

                cmd.Parameters.Add("pn_vehstuck_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<MonitoringVehicleStuckUpDetail>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new MonitoringVehicleStuckUpDetail();

                            Typedetail.model_desc = Convert.ToString(row["model_desc"]);
                            Typedetail.Reg_num = Convert.ToString(row["Reg_num"]);
                            Typedetail.JC_No = Convert.ToString(row["JC_No"]);
                            Typedetail.rcateg_desc = Convert.ToString(row["rcateg_desc"]);
                            Typedetail.JC_open_datetime = Convert.ToString(row["JC_open_datetime"]);
                            Typedetail.Revised_promise_dateTime = Convert.ToString(row["Revised_promise_dateTime"]);
                            Typedetail.Stuck_Up_datetime = Convert.ToString(row["Stuck_Up_datetime"]);
                            Typedetail.Stuck_Time = Convert.ToString(row["Stuck_Time"]);
                            Typedetail.Reason_for_StuckUp = Convert.ToString(row["Reason_for_StuckUp"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MonitoringVehicleStuckUpDetail");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for WalkinCustomerVehInfo
        public BaseListReturnType<WalkinCustomerVehInfo> WalkinCustomerVehInfo(string pn_rfid_num, string pn_dealer_map_cd, string pn_loc_Cd)
        {
            BaseListReturnType<WalkinCustomerVehInfo> response = new BaseListReturnType<WalkinCustomerVehInfo>();
            WalkinCustomerVehInfo Typedetail = null;
            List<WalkinCustomerVehInfo> Details;
            //Validate Token
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
                cmd.CommandText = Usp_WalkinCustomerVehInfo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_rfid_num", OracleType.VarChar).Value = pn_rfid_num;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;

                //for output params
                cmd.Parameters.Add("po_reg_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_mobile", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                Details = new List<WalkinCustomerVehInfo>();
                Typedetail = new WalkinCustomerVehInfo();
                Typedetail.po_reg_num = cmd.Parameters["po_reg_num"].Value.ToString();
                Typedetail.po_cust_name = cmd.Parameters["po_cust_name"].Value.ToString();
                Typedetail.po_cust_mobile = cmd.Parameters["po_cust_mobile"].Value.ToString();

                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_WalkinCustomerVehInfo");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ValidateBillType
        public BaseListReturnType<ValidateBillType> ValidateBillType(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_part_num, string pn_bill_type_Cd)
        {
            BaseListReturnType<ValidateBillType> response = new BaseListReturnType<ValidateBillType>();
            try
            {
                ValidateBillType result = new ValidateBillType();
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
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
                cmd.CommandText = Usp_ValidateBillType;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_jc_num", OracleType.VarChar).Value = pn_jc_num;
                cmd.Parameters.Add("pn_part_num", OracleType.VarChar).Value = pn_part_num;
                cmd.Parameters.Add("pn_bill_type_Cd", OracleType.VarChar).Value = pn_bill_type_Cd;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                // string outputStr = string.Empty;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //  response.result = result;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_ValidateBillType");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for VehicleStatusDisplay
        public BaseListReturnType<VehicleStatusDisplay> VehicleStatusDisplay(string p_group, string d_mapcd, string l_code)
        {
            BaseListReturnType<VehicleStatusDisplay> response = new BaseListReturnType<VehicleStatusDisplay>();

            List<VehicleStatusDisplay> MainALLDetailsList;
            VehicleStatusDisplay listDetail = null;

            List<VehicleStatusDisplay_List> VehicleStatusDisplay_List = new List<VehicleStatusDisplay_List>();

            VehicleStatusDisplay_List VehicleStatusDisplay_List1;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_VehicleStatusDisplay;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("p_group", OracleType.VarChar).Value = p_group;
                cmd.Parameters.Add("d_mapcd", OracleType.Number).Value = Convert.ToInt32(d_mapcd);
                cmd.Parameters.Add("l_code", OracleType.VarChar).Value = l_code;

                //Output
                cmd.Parameters.Add("vsd_flag", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //output cursor
                cmd.Parameters.Add("list_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("err_reas", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrVehicleStatusDisplay_List;

                rdrVehicleStatusDisplay_List = (OracleDataReader)cmd.Parameters["list_cursor"].Value;
                #endregion

                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["err_reas"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["err_cd"].Value.ToString());
                    response.message = cmd.Parameters["err_reas"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion

                MainALLDetailsList = new List<VehicleStatusDisplay>();

                VehicleStatusDisplay_List = new List<VehicleStatusDisplay_List>();

                #region rdrVehicleStatusDisplay_List
                if (rdrVehicleStatusDisplay_List.HasRows)
                {
                    while (rdrVehicleStatusDisplay_List.Read())
                    {
                        VehicleStatusDisplay_List1 = new VehicleStatusDisplay_List();
                        VehicleStatusDisplay_List1.REG_NO = rdrVehicleStatusDisplay_List["REG_NO"].ToString();
                        VehicleStatusDisplay_List1.CUST_NAME = rdrVehicleStatusDisplay_List["CUST_NAME"].ToString();
                        VehicleStatusDisplay_List1.PROMISED_TIME = rdrVehicleStatusDisplay_List["PROMISED_TIME"].ToString();
                        VehicleStatusDisplay_List1.REV_PROMISED_TIME = rdrVehicleStatusDisplay_List["REV_PROMISED_TIME"].ToString();
                        VehicleStatusDisplay_List1.WIP = rdrVehicleStatusDisplay_List["WIP"].ToString();
                        VehicleStatusDisplay_List1.FI = rdrVehicleStatusDisplay_List["FI"].ToString();
                        VehicleStatusDisplay_List1.WASHING = rdrVehicleStatusDisplay_List["WASHING"].ToString();
                        VehicleStatusDisplay_List1.READY_FOR_DELV = rdrVehicleStatusDisplay_List["READY_FOR_DELV"].ToString();
                        VehicleStatusDisplay_List1.STATUS = rdrVehicleStatusDisplay_List["STATUS"].ToString();
                        VehicleStatusDisplay_List1.SRV_ADV = rdrVehicleStatusDisplay_List["SRV_ADV"].ToString();
                        VehicleStatusDisplay_List1.JC_NO = rdrVehicleStatusDisplay_List["JC_NO"].ToString();

                        VehicleStatusDisplay_List.Add(VehicleStatusDisplay_List1);
                    }
                }
                #endregion

                listDetail = new VehicleStatusDisplay();
                listDetail.VehicleStatusDisplay_List = VehicleStatusDisplay_List;

                listDetail.vsd_flag = cmd.Parameters["vsd_flag"].Value.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }
            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_VehicleStatusDisplay");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        //#region for NexaAlert
        //public BaseListReturnType<Notification_NexaAlert> NexaAlert(string pn_date)
        //{
        //    BaseListReturnType<Notification_NexaAlert> response = new BaseListReturnType<Notification_NexaAlert>();

        //    List<Notification_NexaAlert> MainALLDetailsList;
        //    Notification_NexaAlert listDetail = null;

        //    List<Notification_NexaAlert_CallDetails> listNotification_NexaAlert_CallDetailsList = new List<Notification_NexaAlert_CallDetails>();
        //    Notification_NexaAlert_CallDetails listNotification_NexaAlert_CallDetailsList1;

        //    List<Notification_NexaAlert_AppointmentDetails> listNotification_NexaAlert_AppointmentDetailsList = new List<Notification_NexaAlert_AppointmentDetails>();
        //    Notification_NexaAlert_AppointmentDetails listNotification_NexaAlert_AppointmentDetailsList1;

        //    List<Notification_NexaAlert_JCDetails> listNotification_NexaAlert_JCDetailsList = new List<Notification_NexaAlert_JCDetails>();
        //    Notification_NexaAlert_JCDetails listNotification_NexaAlert_JCDetailsList1;

        //    #region Token Validating //Validate Token
        //    ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
        //    if (!headerInfo.IsAuthenticated)
        //    {
        //        response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
        //        response.message = Convert.ToString(ServiceMassageCode.ERROR);
        //        response.result = null;
        //        return response;
        //    }
        //    #endregion
        //    try
        //    {
        //        #region Connection and Bind Data in Dataset
        //        con = new OracleConnection(constr);
        //        cmd = new OracleCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Usp_NexaAlert;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("pn_date", OracleType.VarChar).Value = pn_date;

        //        cmd.Parameters.Add("po_call_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        cmd.Parameters.Add("po_nappnt_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
        //        cmd.Parameters.Add("po_jobcard_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

        //        cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        cmd.ExecuteNonQuery();

        //        OracleDataReader rdrNotification_NexaAlert_CallDetails;
        //        OracleDataReader rdrNotification_NexaAlert_AppointmentDetails;
        //        OracleDataReader rdrNotification_NexaAlert_JCDetails;

        //        rdrNotification_NexaAlert_CallDetails = (OracleDataReader)cmd.Parameters["po_call_refcur"].Value;
        //        rdrNotification_NexaAlert_AppointmentDetails = (OracleDataReader)cmd.Parameters["po_nappnt_refcur"].Value;
        //        rdrNotification_NexaAlert_JCDetails = (OracleDataReader)cmd.Parameters["po_jobcard_refcur"].Value;

        //        #endregion
        //        #region In case of Error
        //        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
        //        {
        //            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
        //            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
        //            response.result = null;
        //            con.Close();
        //            cmd.Dispose();
        //            return response;
        //        }
        //        #endregion
        //        // con.Close();

        //        MainALLDetailsList = new List<Notification_NexaAlert>();

        //        listMyCalls_PSFDashList = new List<MyCalls_PSFDash>();
        //        listMyCalls_CustomerResponseList = new List<MyCalls_CustomerResponse>();

        //        #region rdrMyCalls_PSFDash
        //        if (rdrMyCalls_PSFDash.HasRows)
        //        {
        //            while (rdrMyCalls_PSFDash.Read())
        //            {
        //                listMyCalls_PSFDashList1 = new MyCalls_PSFDash();
        //                listMyCalls_PSFDashList1.sr_no = rdrMyCalls_PSFDash["sr_no"].ToString();
        //                listMyCalls_PSFDashList1.cust_name = rdrMyCalls_PSFDash["cust_name"].ToString();
        //                listMyCalls_PSFDashList1.Cust_cd = rdrMyCalls_PSFDash["Cust_cd"].ToString();

        //                listMyCalls_PSFDashList.Add(listMyCalls_PSFDashList1);
        //            }
        //        }
        //        #endregion

        //        #region rdrMyCalls_CustomerResponse
        //        if (rdrMyCalls_CustomerResponse.HasRows)
        //        {
        //            while (rdrMyCalls_CustomerResponse.Read())
        //            {
        //                listMyCalls_CustomerResponseList1 = new MyCalls_CustomerResponse();
        //                listMyCalls_CustomerResponseList1.ROWNUM = rdrMyCalls_CustomerResponse["ROWNUM"].ToString();
        //                listMyCalls_CustomerResponseList1.list_code = rdrMyCalls_CustomerResponse["list_code"].ToString();

        //                listMyCalls_CustomerResponseList.Add(listMyCalls_CustomerResponseList1);
        //            }
        //        }
        //        #endregion

        //        listDetail = new Notification_NexaAlert();
        //        listDetail.MyCalls_PSFDash = listMyCalls_PSFDashList;
        //        listDetail.MyCalls_CustomerResponse = listMyCalls_CustomerResponseList;

        //        MainALLDetailsList.Add(listDetail);

        //        response.code = (int)ServiceMassageCode.SUCCESS;
        //        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

        //        response.result = MainALLDetailsList;
        //    }

        //    catch (Exception ex)
        //    {
        //        ErrorLog.LogException(ex, "NEXAService_Notification_NexaAlert");
        //        response.code = (int)ServiceMassageCode.ERROR;
        //        response.message = ex.Message;
        //        response.result = null;
        //        con.Close();
        //        cmd.Dispose();
        //    }
        //    finally
        //    {
        //        con.Close();
        //        cmd.Dispose();
        //        OracleConnection.ClearPool(con);
        //    }
        //    return response;
        //}
        //#endregion

        #region for MyCalls_GetINTCustHDR
        public BaseListReturnType<MyCalls_GetINTCustHDR> MyCallsGetINTCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date)
        {
            BaseListReturnType<MyCalls_GetINTCustHDR> response = new BaseListReturnType<MyCalls_GetINTCustHDR>();

            List<MyCalls_GetINTCustHDR> MainALLDetailsList;
            MyCalls_GetINTCustHDR listDetail = null;

            List<MyCalls_INTCallDet> listMyCalls_INTCallDetList = new List<MyCalls_INTCallDet>();
            MyCalls_INTCallDet listMyCalls_INTCallDetList1;

            Int32 iint_Generated_Count = 0;
            Int32 iint_Close_Count = 0;
            Int32 iint_Open_Count = 0;

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                #region Connection and Bind Data in Dataset
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MyCalls_GetINTCustHDR;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_from_date", OracleType.VarChar).Value = pn_from_date;
                cmd.Parameters.Add("pn_to_Date", OracleType.VarChar).Value = pn_to_Date;

                cmd.Parameters.Add("po_int_call_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                OracleDataReader rdrMyCalls_INTCallDet;

                rdrMyCalls_INTCallDet = (OracleDataReader)cmd.Parameters["po_int_call_refcur"].Value;

                #endregion
                #region In case of Error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }
                #endregion
                // con.Close();

                MainALLDetailsList = new List<MyCalls_GetINTCustHDR>();

                listMyCalls_INTCallDetList = new List<MyCalls_INTCallDet>();

                #region rdrMyCalls_INTCallDet
                if (rdrMyCalls_INTCallDet.HasRows)
                {
                    while (rdrMyCalls_INTCallDet.Read())
                    {
                        listMyCalls_INTCallDetList1 = new MyCalls_INTCallDet();
                        listMyCalls_INTCallDetList1.sr_no = rdrMyCalls_INTCallDet["SR_NO"].ToString();
                        listMyCalls_INTCallDetList1.cust_name = rdrMyCalls_INTCallDet["CUST_NAME"].ToString();
                        listMyCalls_INTCallDetList1.Cust_cd = rdrMyCalls_INTCallDet["CUST_CD"].ToString();
                        listMyCalls_INTCallDetList1.reg_num = rdrMyCalls_INTCallDet["REG_NUM"].ToString();
                        listMyCalls_INTCallDetList1.vin = rdrMyCalls_INTCallDet["VIN"].ToString();
                        listMyCalls_INTCallDetList1.model_desc = rdrMyCalls_INTCallDet["MODEL_DESC"].ToString();
                        listMyCalls_INTCallDetList1.Sale_Date = rdrMyCalls_INTCallDet["SALE_DATE"].ToString();
                        listMyCalls_INTCallDetList1.contact_no = rdrMyCalls_INTCallDet["CONTACT_NO"].ToString();
                        listMyCalls_INTCallDetList1.email_id = rdrMyCalls_INTCallDet["EMAIL"].ToString();
                        listMyCalls_INTCallDetList1.followup_date = rdrMyCalls_INTCallDet["FOLLOWUP_DATE"].ToString();
                        listMyCalls_INTCallDetList1.list_cd = rdrMyCalls_INTCallDet["LIST_CD"].ToString();
                        listMyCalls_INTCallDetList1.list_desc = rdrMyCalls_INTCallDet["LIST_DESC"].ToString();
                        listMyCalls_INTCallDetList1.followup_type = rdrMyCalls_INTCallDet["FOLLOWUP_TYPE"].ToString();
                        listMyCalls_INTCallDetList1.psf_num = rdrMyCalls_INTCallDet["PSF_NUM"].ToString();
                        listMyCalls_INTCallDetList1.status_cd = rdrMyCalls_INTCallDet["STATUS_CD"].ToString();
                        listMyCalls_INTCallDetList1.status_Desc = rdrMyCalls_INTCallDet["STATUS_DESC"].ToString();
                        listMyCalls_INTCallDetList1.UPDATEABLE = rdrMyCalls_INTCallDet["UPDATEABLE"].ToString();
                        listMyCalls_INTCallDetList1.emp_Cd = rdrMyCalls_INTCallDet["EMP_CD"].ToString();
                        listMyCalls_INTCallDetList1.NEXA_VEH = rdrMyCalls_INTCallDet["NEXA_VEH"].ToString();

                        if (rdrMyCalls_INTCallDet["STATUS_CD"].ToString().Trim().ToLower() == "p")
                        {
                            iint_Generated_Count = iint_Generated_Count + 1;

                            iint_Open_Count = iint_Open_Count + 1;
                        }
                        else
                        {
                            iint_Generated_Count = iint_Generated_Count + 1;

                            iint_Close_Count = iint_Close_Count + 1;
                        }

                        listMyCalls_INTCallDetList.Add(listMyCalls_INTCallDetList1);
                    }
                }
                #endregion

                listDetail = new MyCalls_GetINTCustHDR();
                listDetail.MyCalls_INTCallDet = listMyCalls_INTCallDetList;

                listDetail.int_Generated_Count = iint_Generated_Count.ToString();
                listDetail.int_Close_Count = iint_Close_Count.ToString();
                listDetail.int_Open_Count = iint_Open_Count.ToString();

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.result = MainALLDetailsList;
            }

            catch (Exception ex)
            {
                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetINTCustHDR");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for MyCalls_GetINTCustDetail
        public BaseListReturnType<MyCalls_GetSrvCustomerDetail2> MyCallsGetINTCustDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_cust_cd, string pn_vin, string pn_followup_type, string pn_psf_num)
        {
            #region Commented Code
            //string err1 = string.Empty;
            //string err2 = string.Empty;
            //string err3 = string.Empty;
            //string err4 = string.Empty;
            //string err5 = string.Empty;
            //string err6 = string.Empty;
            //string err7 = string.Empty;
            //string err8 = string.Empty;
            //string err9 = string.Empty;
            //string err10 = string.Empty;
            //string err11 = string.Empty;
            //string err12 = string.Empty;
            //string err13 = string.Empty;
            //string err14 = string.Empty;
            //string err15 = string.Empty;
            //string err16 = string.Empty;
            //string err17 = string.Empty;
            //string err18 = string.Empty;
            //string err19 = string.Empty;
            //string err20 = string.Empty;
            //string err21 = string.Empty;
            //string err22 = string.Empty;
            //string err23 = string.Empty;
            //string err24 = string.Empty;
            //string err25 = string.Empty;
            //string err26 = string.Empty;
            //string err27 = string.Empty;
            //string err28 = string.Empty;
            //string err29 = string.Empty;
            //string err30 = string.Empty;
            //string err31 = string.Empty;
            //string err32 = string.Empty;
            //string err33 = string.Empty;
            //string err34 = string.Empty;
            //string err35 = string.Empty;
            //string err36 = string.Empty;
            //string err37 = string.Empty;
            //string err38 = string.Empty;
            //string err39 = string.Empty;
            //string err40 = string.Empty;
            //string err41 = string.Empty;
            //string err42 = string.Empty;
            //string err43 = string.Empty;
            //string err44 = string.Empty;
            //string err45 = string.Empty;
            //string err46 = string.Empty;
            //string err47 = string.Empty;
            //string err48 = string.Empty;
            //string err49 = string.Empty;
            //string err50 = string.Empty;
            //string err51 = string.Empty;
            //string err52 = string.Empty;
            #endregion
            //err15 = " Method Objects Start ";

            BaseListReturnType<MyCalls_GetSrvCustomerDetail2> response = new BaseListReturnType<MyCalls_GetSrvCustomerDetail2>();

            List<MyCalls_GetSrvCustomerDetail2> MainALLDetailsList;
            MyCalls_GetSrvCustomerDetail2 listDetail = null;

            List<MyCalls_CustomerVehicleDet2> listMyCalls_CustomerVehicleDetList = new List<MyCalls_CustomerVehicleDet2>();
            List<MyCalls_LastFollowUp2> listMyCalls_LastFollowUpList = new List<MyCalls_LastFollowUp2>();
            List<MyCalls_FollowUp2> listMyCalls_FollowUpList = new List<MyCalls_FollowUp2>();
            List<MyCalls_PSFFollowUp2> listMyCalls_PSFFollowUpList = new List<MyCalls_PSFFollowUp2>();

            MyCalls_CustomerVehicleDet2 listMyCalls_CustomerVehicleDetList1;
            MyCalls_LastFollowUp2 listMyCalls_LastFollowUpList1;
            MyCalls_FollowUp2 listMyCalls_FollowUpList1;
            MyCalls_PSFFollowUp2 listMyCalls_PSFFollowUpList1;

            //err16 = " Method Objects End ";

            #region Token Validating //Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                //err17 = " Token Error ";

                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            //err18 = " Token Success ";

            try
            {
                #region Connection and Bind Data in Dataset
                //err19 = " Connection Start ";

                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_MyCalls_GetINTCustDetail;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_parent_group", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("pn_dealer_map_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_map_cd);
                cmd.Parameters.Add("pn_loc_Cd", OracleType.VarChar).Value = pn_loc_Cd;
                cmd.Parameters.Add("pn_comp_fa", OracleType.VarChar).Value = pn_comp_fa;
                cmd.Parameters.Add("pn_cust_cd", OracleType.VarChar).Value = pn_cust_cd;
                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;
                cmd.Parameters.Add("pn_followup_type", OracleType.VarChar).Value = pn_followup_type;
                cmd.Parameters.Add("pn_psf_num", OracleType.VarChar).Value = pn_psf_num;

                //output cursor
                cmd.Parameters.Add("po_custveh_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_last_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor
                cmd.Parameters.Add("po_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                //Output
                cmd.Parameters.Add("po_satisified_flag", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_voice_cust", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //output cursor
                cmd.Parameters.Add("po_psf_followup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 8000).Direction = ParameterDirection.Output;

                //err20 = " Parameters Defined End ";

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //err22 = " Connection Now Open ";
                //err23 = " Connection ExecuteNonQuery Start ";

                cmd.ExecuteNonQuery();

                //err24 = " Connection ExecuteNonQuery End ";

                OracleDataReader rdrMyCalls_CustomerVehicleDet;
                OracleDataReader rdrMyCalls_LastFollowUp;
                OracleDataReader rdrMyCalls_FollowUp;
                OracleDataReader rdrMyCalls_PSFFollowUp;

                rdrMyCalls_CustomerVehicleDet = (OracleDataReader)cmd.Parameters["po_custveh_refcur"].Value;
                rdrMyCalls_LastFollowUp = (OracleDataReader)cmd.Parameters["po_last_followup_refcur"].Value;
                rdrMyCalls_FollowUp = (OracleDataReader)cmd.Parameters["po_followup_refcur"].Value;
                rdrMyCalls_PSFFollowUp = (OracleDataReader)cmd.Parameters["po_psf_followup_refcur"].Value;

                //err25 = " Assigned Values to Cursor ";
                #endregion

                #region In case of Error
                //if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                //{
                //    //err1 = " In case of Error";

                //    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                //    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                //    //response.message = cmd.Parameters["po_err_msg"].Value.ToString() + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14;
                //    response.result = null;
                //    con.Close();
                //    cmd.Dispose();
                //    return response;
                //}
                #endregion
                // con.Close();

                MainALLDetailsList = new List<MyCalls_GetSrvCustomerDetail2>();

                listMyCalls_CustomerVehicleDetList = new List<MyCalls_CustomerVehicleDet2>();
                listMyCalls_LastFollowUpList = new List<MyCalls_LastFollowUp2>();
                listMyCalls_FollowUpList = new List<MyCalls_FollowUp2>();
                listMyCalls_PSFFollowUpList = new List<MyCalls_PSFFollowUp2>();

                #region rdrMyCalls_CustomerVehicleDet
                //err2 = " Before Reader rdrMyCalls_CustomerVehicleDet";
                if (rdrMyCalls_CustomerVehicleDet.HasRows)
                {
                    //err3 = " Reader rdrMyCalls_CustomerVehicleDet Has Rows";
                    while (rdrMyCalls_CustomerVehicleDet.Read())
                    {
                        //err4 = " Start While of Reader rdrMyCalls_CustomerVehicleDet";

                        listMyCalls_CustomerVehicleDetList1 = new MyCalls_CustomerVehicleDet2();
                        listMyCalls_CustomerVehicleDetList1.cust_name = rdrMyCalls_CustomerVehicleDet["cust_name"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone = rdrMyCalls_CustomerVehicleDet["phone"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone_m = rdrMyCalls_CustomerVehicleDet["phone_m"].ToString();
                        listMyCalls_CustomerVehicleDetList1.phone_o = rdrMyCalls_CustomerVehicleDet["phone_o"].ToString();
                        listMyCalls_CustomerVehicleDetList1.email = rdrMyCalls_CustomerVehicleDet["email"].ToString();
                        listMyCalls_CustomerVehicleDetList1.category = rdrMyCalls_CustomerVehicleDet["category"].ToString();
                        listMyCalls_CustomerVehicleDetList1.contact_person = rdrMyCalls_CustomerVehicleDet["contact_person"].ToString();
                        listMyCalls_CustomerVehicleDetList1.preferred_time = rdrMyCalls_CustomerVehicleDet["preferred_time"].ToString();
                        listMyCalls_CustomerVehicleDetList1.reg_num = rdrMyCalls_CustomerVehicleDet["reg_num"].ToString();
                        listMyCalls_CustomerVehicleDetList1.vehicle_model = rdrMyCalls_CustomerVehicleDet["vehicle_model"].ToString();
                        listMyCalls_CustomerVehicleDetList1.vehicle_variant = rdrMyCalls_CustomerVehicleDet["vehicle_variant"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Sale_Date = rdrMyCalls_CustomerVehicleDet["Sale_Date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.color_desc = rdrMyCalls_CustomerVehicleDet["color_desc"].ToString();
                        listMyCalls_CustomerVehicleDetList1.VIN = rdrMyCalls_CustomerVehicleDet["VIN"].ToString();
                        listMyCalls_CustomerVehicleDetList1.RM = rdrMyCalls_CustomerVehicleDet["RM"].ToString();
                        listMyCalls_CustomerVehicleDetList1.EW = rdrMyCalls_CustomerVehicleDet["EW"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Service_Type = rdrMyCalls_CustomerVehicleDet["Service_Type"].ToString();
                        listMyCalls_CustomerVehicleDetList1.Due_Date = rdrMyCalls_CustomerVehicleDet["Due_Date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_date = rdrMyCalls_CustomerVehicleDet["last_srv_date"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_type = rdrMyCalls_CustomerVehicleDet["last_srv_type"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_srv_mileage = rdrMyCalls_CustomerVehicleDet["last_srv_mileage"].ToString();
                        listMyCalls_CustomerVehicleDetList1.last_psf_status = rdrMyCalls_CustomerVehicleDet["last_psf_status"].ToString();

                        listMyCalls_CustomerVehicleDetList.Add(listMyCalls_CustomerVehicleDetList1);

                        //err5 = " End While of Reader rdrMyCalls_CustomerVehicleDet";
                    }
                }
                #endregion
                #region rdrMyCalls_LastFollowUp
                //err31 = " Before Reader rdrMyCalls_LastFollowUp";
                if (rdrMyCalls_LastFollowUp.HasRows)
                {
                    //err32 = " Reader rdrMyCalls_LastFollowUp Has Rows";
                    while (rdrMyCalls_LastFollowUp.Read())
                    {
                        //err33 = " Start While of Reader rdrMyCalls_LastFollowUp";

                        listMyCalls_LastFollowUpList1 = new MyCalls_LastFollowUp2();
                        listMyCalls_LastFollowUpList1.psf_num = rdrMyCalls_LastFollowUp["psf_num"].ToString();
                        listMyCalls_LastFollowUpList1.psf_type = rdrMyCalls_LastFollowUp["psf_type"].ToString();
                        listMyCalls_LastFollowUpList1.psf_date = rdrMyCalls_LastFollowUp["psf_date"].ToString();
                        listMyCalls_LastFollowUpList1.response = rdrMyCalls_LastFollowUp["response"].ToString();

                        listMyCalls_LastFollowUpList.Add(listMyCalls_LastFollowUpList1);

                        //err34 = " End While of Reader rdrMyCalls_LastFollowUp";
                    }
                }
                #endregion
                #region rdrMyCalls_FollowUp
                //err43 = " Before Reader rdrMyCalls_FollowUp";
                if (rdrMyCalls_FollowUp.HasRows)
                {
                    //err44 = " Reader rdrMyCalls_FollowUp Has Rows";
                    while (rdrMyCalls_FollowUp.Read())
                    {
                        //err45 = " Start While of Reader rdrMyCalls_FollowUp";

                        listMyCalls_FollowUpList1 = new MyCalls_FollowUp2();
                        listMyCalls_FollowUpList1.psf_num = rdrMyCalls_FollowUp["psf_num"].ToString();
                        listMyCalls_FollowUpList1.psf_type = rdrMyCalls_FollowUp["psf_type"].ToString();
                        listMyCalls_FollowUpList1.psf_date = rdrMyCalls_FollowUp["psf_date"].ToString();
                        listMyCalls_FollowUpList1.response = rdrMyCalls_FollowUp["response"].ToString();
                        listMyCalls_FollowUpList1.response_Desc = rdrMyCalls_FollowUp["response_Desc"].ToString();
                        listMyCalls_FollowUpList1.rating_Cd = rdrMyCalls_FollowUp["rating_Cd"].ToString();
                        listMyCalls_FollowUpList1.rating_desc = rdrMyCalls_FollowUp["rating_desc"].ToString();
                        listMyCalls_FollowUpList1.followup_status_cd = rdrMyCalls_FollowUp["followup_status_cd"].ToString();
                        listMyCalls_FollowUpList1.followup_status_desc = rdrMyCalls_FollowUp["followup_status_desc"].ToString();
                        listMyCalls_FollowUpList1.next_followup_Date = rdrMyCalls_FollowUp["next_followup_Date"].ToString();
                        listMyCalls_FollowUpList1.contact_person = rdrMyCalls_FollowUp["contact_person"].ToString();
                        listMyCalls_FollowUpList1.complaint = rdrMyCalls_FollowUp["complaint"].ToString();

                        listMyCalls_FollowUpList.Add(listMyCalls_FollowUpList1);

                        //err46 = " End While of Reader rdrMyCalls_FollowUp";
                    }
                }
                #endregion
                #region rdrMyCalls_PSFFollowUp
                //err47 = " Before Reader rdrMyCalls_PSFFollowUp";
                if (rdrMyCalls_PSFFollowUp.HasRows)
                {
                    //err48 = " Reader rdrMyCalls_PSFFollowUp Has Rows";
                    while (rdrMyCalls_PSFFollowUp.Read())
                    {
                        //err49 = " Start While of Reader rdrMyCalls_PSFFollowUp";

                        listMyCalls_PSFFollowUpList1 = new MyCalls_PSFFollowUp2();
                        listMyCalls_PSFFollowUpList1.psf_srl = rdrMyCalls_PSFFollowUp["psf_srl"].ToString();
                        listMyCalls_PSFFollowUpList1.psf_questions = rdrMyCalls_PSFFollowUp["psf_questions"].ToString();
                        listMyCalls_PSFFollowUpList1.script_desc = rdrMyCalls_PSFFollowUp["script_desc"].ToString();
                        listMyCalls_PSFFollowUpList1.psf_feedback = rdrMyCalls_PSFFollowUp["psf_feedback"].ToString();
                        listMyCalls_PSFFollowUpList1.feedback_desc = rdrMyCalls_PSFFollowUp["feedback_desc"].ToString();
                        listMyCalls_PSFFollowUpList1.voice_of_cust = rdrMyCalls_PSFFollowUp["voice_of_cust"].ToString();

                        listMyCalls_PSFFollowUpList.Add(listMyCalls_PSFFollowUpList1);

                        //err50 = " End While of Reader rdrMyCalls_PSFFollowUp";
                    }
                }
                #endregion

                listDetail = new MyCalls_GetSrvCustomerDetail2();
                listDetail.MyCalls_CustomerVehicleDet = listMyCalls_CustomerVehicleDetList;
                listDetail.MyCalls_LastFollowUp = listMyCalls_LastFollowUpList;
                listDetail.MyCalls_FollowUp = listMyCalls_FollowUpList;
                listDetail.MyCalls_PSFFollowUp = listMyCalls_PSFFollowUpList;

                //err51 = " After add all cursor value to list";

                listDetail.po_satisified_flag = cmd.Parameters["po_satisified_flag"].Value.ToString();
                listDetail.po_voice_cust = cmd.Parameters["po_voice_cust"].Value.ToString();

                //err52 = " After add all cursor + normal output value to list";

                MainALLDetailsList.Add(listDetail);

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                //response.message = Convert.ToString(ServiceMassageCode.SUCCESS) + "  result" + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err31 + err32 + err33 + err34 + err35 + err36 + err37 + err38 + err39 + err40 + err41 + err42 + err43 + err44 + err45 + err46 + err47 + err48 + err49 + err50 + err51 + err52;

                response.result = MainALLDetailsList;
            }
            catch (Exception ex)
            {
                //err14 = " In case of Exception";

                // Logging.Error(ex, "PropertiesService:Properties_Listing");
                ErrorLog.LogException(ex, "NEXAService_MyCallsGetINTCustDetail");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                //response.message = ex.Message + err1 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24 + err25 + err26 + err27 + err28 + err29 + err30 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err31 + err32 + err33 + err34 + err35 + err36 + err37 + err38 + err39 + err40 + err41 + err42 + err43 + err44 + err45 + err46 + err47 + err48 + err49 + err50 + err51 + err52;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for ModifyCustomerDetail
        public BaseListReturnType<ModifyCustomerDetail> ModifyCustomerDetail(string pn_cust_id, string pn_user_id, string pn_cust_mod_flag, string pn_cust_name, string pn_cust_add1, string pn_cust_add2, string pn_cust_add3, string pn_city_cd, string pn_city_desc, string pn_email, string pn_email1, string pn_phone, string pn_work_phone, string pn_mobile, string pn_dob, string pn_doa)
        {
            BaseListReturnType<ModifyCustomerDetail> response = new BaseListReturnType<ModifyCustomerDetail>();

            ModifyCustomerDetail Typedetail = null;
            List<ModifyCustomerDetail> Details;

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
                cmd.CommandText = Usp_ModifyCustomerDetail;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pn_cust_id", OracleType.VarChar).Value = pn_cust_id;
                cmd.Parameters.Add("pn_user_id", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("pn_cust_mod_flag", OracleType.VarChar).Value = pn_cust_mod_flag;
                cmd.Parameters.Add("pn_cust_name", OracleType.VarChar).Value = pn_cust_name;
                cmd.Parameters.Add("pn_cust_add1", OracleType.VarChar).Value = pn_cust_add1;
                cmd.Parameters.Add("pn_cust_add2", OracleType.VarChar).Value = pn_cust_add2;
                cmd.Parameters.Add("pn_cust_add3", OracleType.VarChar).Value = pn_cust_add3;
                cmd.Parameters.Add("pn_city_cd", OracleType.VarChar).Value = pn_city_cd;
                cmd.Parameters.Add("pn_city_desc", OracleType.VarChar).Value = pn_city_desc;
                cmd.Parameters.Add("pn_email", OracleType.VarChar).Value = pn_email;
                cmd.Parameters.Add("pn_email1", OracleType.VarChar).Value = pn_email1;
                cmd.Parameters.Add("pn_phone", OracleType.VarChar).Value = pn_phone;
                cmd.Parameters.Add("pn_work_phone", OracleType.VarChar).Value = pn_work_phone;
                cmd.Parameters.Add("pn_mobile", OracleType.VarChar).Value = pn_mobile;
                cmd.Parameters.Add("pn_dob", OracleType.VarChar).Value = pn_dob;
                cmd.Parameters.Add("pn_doa", OracleType.VarChar).Value = pn_doa;

                //for output params
                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = null;
            }

            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_ModifyCustomerDetail");
                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for GetRFTagDetail
        public BaseListReturnType<RFTagDetail> GetRFTagDetail(string pn_parent_group, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_vin, string pn_srv_cat_cd)
        {
            BaseListReturnType<RFTagDetail> response = new BaseListReturnType<RFTagDetail>();
            RFTagDetail Typedetail = null;
            List<RFTagDetail> Details;
            #region Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_GetRFTagDetail;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PN_PARENT_GROUP", OracleType.VarChar).Value = pn_parent_group;
                cmd.Parameters.Add("PN_DEALER_CD", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("PN_LOC_CD", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("PN_USER_ID", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("PN_VIN", OracleType.VarChar).Value = pn_vin;
                cmd.Parameters.Add("PN_SRV_CAT_CD", OracleType.VarChar).Value = pn_srv_cat_cd;

                //for output params
                cmd.Parameters.Add("PO_AVTS_YN", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_RFTAG_NO", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_CHECKIN_DATETIME", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                #region if error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                #endregion

                Details = new List<RFTagDetail>();
                Typedetail = new RFTagDetail();
                Typedetail.po_avts_yn = cmd.Parameters["PO_AVTS_YN"].Value.ToString();
                Typedetail.pn_rftag_no = cmd.Parameters["PO_RFTAG_NO"].Value.ToString();
                Typedetail.po_checkin_datetime = cmd.Parameters["PO_CHECKIN_DATETIME"].Value.ToString();

                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }
            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_GetRFTagDetail");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for GetRFTagScanTime
        public BaseListReturnType<RFTagScanTime> GetRFTagScanTime(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_rftag_no, string pn_srv_cat_cd)
        {
            BaseListReturnType<RFTagScanTime> response = new BaseListReturnType<RFTagScanTime>();
            RFTagScanTime Typedetail = null;
            List<RFTagScanTime> Details;
            #region Validate Token
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_GetRFTagScanTime;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PN_DEALER_CD", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("PN_LOC_CD", OracleType.VarChar).Value = pn_loc_cd;
                cmd.Parameters.Add("PN_USER_ID", OracleType.VarChar).Value = pn_user_id;
                cmd.Parameters.Add("PN_RFTAG_NO", OracleType.VarChar).Value = pn_rftag_no;
                cmd.Parameters.Add("PN_SRV_CAT_CD", OracleType.VarChar).Value = pn_srv_cat_cd;

                //for output params
                cmd.Parameters.Add("PO_CHECKIN_DATETIME", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                #region if error
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                    response.result = null;
                    con.Close();
                    return response;
                }
                #endregion

                Details = new List<RFTagScanTime>();
                Typedetail = new RFTagScanTime();
                Typedetail.po_checkin_datetime = cmd.Parameters["PO_CHECKIN_DATETIME"].Value.ToString();

                Details.Add(Typedetail);
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
            }
            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "NEXAService_GetRFTagScanTime");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion
    }
}