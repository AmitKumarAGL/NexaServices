using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using NEXA.DataService.DataContract;

namespace NEXA.DataService.ServiceContract
{
    [ServiceContract]
    public interface INEXAService
    {
        #region User Profile
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ValidateUser")]
        BaseListReturnType<UserDetails> ValidateUser(string pn_userid, string pn_pwd, string pn_date);
        //--ValidateUser(UserLogin obj);
        #endregion
        #region BoomBarrier open
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetBoomDetails")]
        BaseListReturnType<BoomBarrierDetails> GetBoomDetails(string pn_dealer_cd, string pn_loc_Cd, string pn_date);
        #endregion


        #region BoomBarrier open without sticker search conditions
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetBoomSearchDetails")]
        BaseListReturnType<BoomBarrierDetails> GetBoomSearchDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_Cd, string pn_date);
        #endregion


        #region BioMetric Details
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetBioMetricDetails")]
        BaseListReturnType<BioMetric> GetBioMetricDetails(string pn_dealer_cd, string pn_loc_Cd, string pn_date);

        #endregion

        #region PartMaster Details
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetPartDetails")]
        BaseListReturnType<PartList> GetPartDetails(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_part_num);

        #endregion

        #region DealerLocationList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DealerLocationList")]
        BaseListReturnType<DealerLocationList> DealerLocationList(string pn_pmc);
        #endregion

        #region ExtendedWarrantyList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ExtendedWarrantyList")]
        BaseListReturnType<ExtendedWarrantyList> ExtendedWarrantyList(string pn_pmc, string pn_vin);

        #endregion
        #region MCPList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MCPList")]
        BaseListReturnType<MCPList> MCPList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_omr);

        #endregion
        #region LabourList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LabourMasterList")]
        BaseListReturnType<LabourMasterList> LabourMasterList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_srv_cat_cd);

        #endregion

        #region Pickup Type List
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PickupTypeList")]
        BaseListReturnType<PickupTypeList> PickupTypeList(string pn_pmc);
        #endregion

        #region UnApprovedFitmentsList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UnApprovedFitmentsList")]
        BaseListReturnType<UnApprovedFitmentsList> UnApprovedFitmentsList(string pn_pmc);
        #endregion

        #region DemandRepairsList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DemandRepairsList")]
        BaseListReturnType<DemandRepairsList> DemandRepairsList(string pn_pmc, string pn_reg_num);
        #endregion

        #region ServiceTypeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ServiceTypeList")]
        BaseListReturnType<ServiceTypeList> ServiceTypeList(string pn_pmc);
        #endregion

        #region BillableTypeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "BillableTypeList")]
        BaseListReturnType<BillableTypeList> BillableTypeList(string pn_pmc);
        #endregion

        #region ProblemCodeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProblemCodeList")]
        BaseListReturnType<ProblemCodeList> ProblemCodeList(string pn_pmc);
        #endregion

        #region FaultCodeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "FaultCodeList")]
        BaseListReturnType<FaultCodeList> FaultCodeList(string pn_pmc);
        #endregion

        #region ActionCodeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActionCodeList")]
        BaseListReturnType<ActionCodeList> ActionCodeList(string pn_pmc);
        #endregion

        #region CSIReasonList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "CSIReasonList")]
        BaseListReturnType<CSIReasonList> CSIReasonList(string pn_pmc);
        #endregion

        #region DelayReasonsClosingList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DelayReasonsClosingList")]
        BaseListReturnType<DelayReasonsClosingList> DelayReasonsClosingList(string pn_pmc);
        #endregion

        #region DelayReasonsBillingList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DelayReasonsBillingList")]
        BaseListReturnType<DelayReasonsBillingList> DelayReasonsBillingList(string pn_pmc);
        #endregion

        #region PaymentModeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PaymentModeList")]
        BaseListReturnType<PaymentModeList> PaymentModeList(string pn_pmc);
        #endregion

        #region ReportedByList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ReportedByList")]
        BaseListReturnType<ReportedByList> ReportedByList(string pn_pmc);
        #endregion

        #region PickUpLocationList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PickUpLocationList")]
        BaseListReturnType<PickUpLocationList> PickUpLocationList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region MobileServiceMMSList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MobileServiceMMSList")]
        BaseListReturnType<MobileServiceMMSList> MobileServiceMMSList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region DriveEmployeeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DriveEmployeeList")]
        BaseListReturnType<DriveEmployeeList> DriveEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region BayCodeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "BayCodeList")]
        BaseListReturnType<BayCodeList> BayCodeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region ServiceAdvisorEmployeeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ServiceAdvisorEmployeeList")]
        BaseListReturnType<ServiceAdvisorEmployeeList> ServiceAdvisorEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region TechnicalAdvisorEmployeeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "TechnicalAdvisorEmployeeList")]
        BaseListReturnType<TechnicalAdvisorEmployeeList> TechnicalAdvisorEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region GroupList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GroupList")]
        BaseListReturnType<GroupList> GroupList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region TechnicianEmployeeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "TechnicianEmployeeList")]
        BaseListReturnType<TechnicianEmployeeList> TechnicianEmployeeList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region InventoryList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "InventoryList")]
        BaseListReturnType<InventoryList> InventoryList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region AuthorizedPersonForDiscountList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AuthorizedPersonForDiscountList")]
        BaseListReturnType<AuthorizedPersonForDiscountList> AuthorizedPersonForDiscountList(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region SplitRatioListOnlyForParts
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SplitRatioListOnlyForParts")]
        BaseListReturnType<SplitRatioListOnlyForParts> SplitRatioListOnlyForParts(string pn_parent, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region ServiceMenuCardList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ServiceMenuCardList")]
        BaseListReturnType<ServiceMenuCardList> ServiceMenuCardList(string pn_parent, string pn_dealer_cd, string pn_loc_cd, string pn_reg_num, string pn_srv_cat_cd, string pn_omr);
        #endregion

        #region AppointmentTypeDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentTypeDTLList")]
        BaseListReturnType<AppointmentTypeList> AppointmentTypeDTLList(string pn_pmc);
        #endregion

        #region AppointmentSlotDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentSlotDTLList")]
        BaseListReturnType<AppointmentSlotList> AppointmentSlotDTLList(string pn_pmc);
        #endregion

        #region AppointmentSlotTimeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentSlotTimeList")]
        BaseListReturnType<AppointmentSlotTimeList> AppointmentSlotTimeList(string pn_pmc);
        #endregion

        #region AppointmentPrePostDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentPrePostDTLList")]
        BaseListReturnType<AppointmentPrePostPoneList> AppointmentPrePostDTLList(string pn_pmc);
        #endregion

        #region AppointmentCancelReasonList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentCancelReasonList")]
        BaseListReturnType<AppointmentCancelReasonList> AppointmentCancelReasonList(string pn_pmc);
        #endregion

        #region AppointmentVehicleDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentVehicleDTLList")]
        BaseListReturnType<AppointmentVehicleDetails> AppointmentVehicleDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_reg_num);
        #endregion

        #region AppointmentInsertDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentInsertDTLList")]
        BaseListReturnType<GenerateAppointment> AppointmentInsertDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_reg_num, string pn_odometer, string pn_srvtype_cd, string pn_appnt_type, string pn_appnt_date, string pn_currentsa_cd, string pn_slot_cd, string pn_slottime_cd, string pn_pickuptype, string pn_pickuploc, string pn_pickuptime, string pn_pickupaddr, string pn_droploc, string pn_droptime, string pn_dropaddr, string pn_driver, string pn_vehicleno, string pn_pickupremarks, string pn_remark_non_prev_sa);
        #endregion

        #region AppointmentUpdateDTLList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentUpdateDTLList")]
        BaseListReturnType<UpdateAppointmentdetailasperAppointmentno> AppointmentUpdateDTLList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_appnt_no, string pn_prepone_type, string pn_prepone_date, string pn_odometer, string pn_srvtype, string pn_current_sa, string pn_appnt_type, string pn_slot, string pn_slot_time, string pn_pickuptype, string pn_pickuploc, string pn_pickuptime, string pn_pickupaddr, string pn_droploc, string pn_droptime, string pn_dropaddr, string pn_driver, string pn_vehicleno, string pn_pickupremarks, string pn_remark_notselect_sa);
        #endregion

        #region AppointmentCancelList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentCancelList")]
        BaseListReturnType<AppointmentCancel> AppointmentCancelList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_appnt_no, string pn_cancel_reason);
        #endregion

        #region AppointmentListAccordingToDateRange
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRange")]
        BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRange(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region AppointmentListAccordingToDateRangeDayWiseList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRangeDayWiseList")]
        BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeDayWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification
        //[OperationContract]
        //[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification")]
        //BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeDayWiseListWithLocalNotification(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region AppointmentListAccordingToDateRangeWeekWiseList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRangeWeekWiseList")]
        BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeWeekWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region AppointmentListAccordingToDateRangeMonthWiseList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRangeMonthWiseList")]
        BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeMonthWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region AppointmentListAccordingToDateRangeSAWiseList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentListAccordingToDateRangeSAWiseList")]
        BaseListReturnType<AppointmentListAccordingToDateRange> AppointmentListAccordingToDateRangeSAWiseList(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_from_date, string pn_to_date);
        #endregion

        #region JobCardOpeningCustomerAndVehicleMaster
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardOpeningCustomerAndVehicleMaster")]
        BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd);
        #endregion

        #region SubServiceTypeDetails. This is now not using
        //[OperationContract]
        //[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubServiceTypeDetails")]
        //BaseListReturnType<SubServiceTypeDetails> SubServiceTypeDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_srvtype_cd, string pn_omr);

        #endregion

        #region AppointmentDetails
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AppointmentDetails")]
        BaseListReturnType<AppointmentDetails> AppointmentDetails(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_appnt_no);
        #endregion

        #region GenerateJobCard
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GenerateJobCard")]
        //BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, string pn_cust_sign, string pn_est_remarks);
        //BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, string pn_est_remarks);
        BaseListReturnType<GenerateJobCard> GenerateJobCard(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_checkin_date, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_rfid_num, string pn_waiting_cust, string pn_demand_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_inv_ins_str, string pn_mcard_ins_str, string pn_unapprv_fit_str, string pn_estm_str, string pn_prob_str, string pn_pickup_type, string pn_pickup_loc_cd, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_driver, string pn_pikcup_remarks, string pn_drop_loc_cd, string pn_drop_date, string pn_mms_num, string pn_rtest_stime, string pn_rtest_skms, string pn_rtest_etime, string pn_rtest_ekms, string pn_part_est_amt, string pn_opr_est_amt, string pn_cust_sign, string pn_est_remarks);
        #endregion


        #region SADashboardOnlyForCurrentDate
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SADashboardOnlyForCurrentDate")]
        BaseListReturnType<SADashboardOnlyForCurrentDate> SADashboardOnlyForCurrentDate(string pn_dealer_cd, string pn_loc_cd, string pn_user_id);
        #endregion

        #region JobCardListOfVehicle
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardListOfVehicle")]
        BaseListReturnType<JobCardListOfVehicle> JobCardListOfVehicle(string pn_pmc, string pn_reg_num);
        #endregion

        #region JobCardDetailsAccordingToJobCard
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardDetailsAccordingToJobCard")]
        BaseListReturnType<JobCardDetailsAccordingToJobCard> JobCardDetailsAccordingToJobCard(string pn_pmc, string pn_reg_num, string pn_ro_num);
        #endregion

        #region JobCardListForSA
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardListForSA")]
        BaseListReturnType<JobCardListForSA> JobCardListForSA(string pn_dealer_cd, string pn_loc_cd, string pn_user_id);
        #endregion

        #region RejectionReasonsList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RejectionReasonsList")]
        BaseListReturnType<RejectionReasonsList> RejectionReasonsList(string pn_pmc);
        #endregion

        #region PartCodeList
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PartCodeList")]
        BaseListReturnType<PartCodeList> PartCodeList(string pn_pmc, string pn_group_cd);
        #endregion

        #region JobCardListForSA_JCClosePull
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardClosePull")]
        BaseListReturnType<JobCardClosePull> JobCardClosePull(string pn_jc_module, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_no);
        #endregion

        #region JobCardClosePush
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardClosePush")]
        //BaseListReturnType<JobCardClosePush> JobCardClosePush(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_payment_mode, string pn_sa_adv, string pn_gst_type, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_demand_ins_str, string pn_repair_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_mcard_ins_str, string pn_tcamp_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_rtest_startime, string pn_rtest_startkm, string pn_rtest_endtime, string pn_rtest_endkm, string pn_delay_reas_cd, string pn_delay_reas_rem, string pn_csi_reas_cd, string pn_csi_reas_rem, string pn_disc_part_perc, string pn_disc_labour_perc, string pn_disc_auth_by);
        BaseListReturnType<JobCardClosePush> JobCardClosePush(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_demand_ins_str, string pn_repair_ins_str, string pn_part_ins_str, string pn_labor_ins_str, string pn_mcard_ins_str, string pn_tcamp_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_rtest_startime, string pn_rtest_startkm, string pn_rtest_endtime, string pn_rtest_endkm, string pn_delay_reas_cd, string pn_delay_reas_rem, string pn_csi_reas_cd, string pn_csi_reas_rem, string pn_disc_part_perc, string pn_disc_labour_perc, string pn_disc_auth_by);
        #endregion

        #region MyCalls_GetResponse
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetResponse")]
        BaseListReturnType<MyCalls_GetResponse> MyCallsGetResponse();
        #endregion

        #region MyCalls_GetRating
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetRating")]
        BaseListReturnType<MyCalls_GetRating> MyCallsGetRating();
        #endregion

        #region MyCalls_GetFollowStatus
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetFollowStatus")]
        BaseListReturnType<MyCalls_GetFollowStatus> MyCallsGetFollowStatus();
        #endregion

        #region MyCalls_GetPSFDissatisfiedReason
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetPSFDissatisfiedReason")]
        BaseListReturnType<MyCalls_GetPSFDissatisfiedReason> MyCallsGetPSFDissatisfiedReason();
        #endregion

        #region MyCalls_GetSrvMod
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetSrvMod")]
        BaseListReturnType<MyCalls_GetSrvMod> MyCallsGetSrvMod();
        #endregion

        #region MyCalls_GetScript
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetScript")]
        BaseListReturnType<MyCalls_GetScript> MyCallsGetScript();
        #endregion

        #region MyCalls_GetPSFCustHDR
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetPSFCustHDR")]
        BaseListReturnType<MyCalls_GetPSFCustHDR> MyCallsGetPSFCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date, string pn_followup_Cd, string pn_psf_days);
        #endregion

        #region MyCalls_GetSMRWelcomeCustHDR
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetSMRWelcomeCustHDR")]
        BaseListReturnType<MyCalls_GetSMRWelcomeCustHDR> MyCallsGetSMRWelcomeCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date);
        #endregion

        #region MyCalls_GetSrvCustomerDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetSrvCustomerDetail")]
        BaseListReturnType<MyCalls_GetSrvCustomerDetail> MyCallsGetSrvCustomerDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_cust_cd, string pn_vin, string pn_followup_type, string pn_psf_num);
        #endregion

        #region MyCalls_UpdateFollowUpDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsUpdateFollowUpDetail")]
        BaseListReturnType<MyCalls_UpdateFollowUpDetail> MyCallsUpdateFollowUpDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_followup_Cd, string pn_status_Cd, string pn_vin, string pn_bkg_type, string pn_bkg_date, string pn_srv_type, string pn_pickup_req, string pn_free_pickup, string pn_pickup_type, string pn_pickup_date, string pn_pickup_loc, string pn_pickup_driver, string pn_pickup_remarks, string pn_mms_reg_num, string pn_followup_str, string pn_voice_cust, string pn_psf_followup_str);
        #endregion

        #region ServiceTypeValidation
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ServiceTypeValidation")]
        BaseListReturnType<ServiceTypeValidation> ServiceTypeValidation(string pn_parent, string pn_dealer, string pn_loc, string pn_comp, string pn_vin, string pn_srvtype, string pn_omr);
        #endregion

        #region JobCardUpdate
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardUpdate")]
        //BaseListReturnType<JobCardUpdate> JobCardUpdate(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id, string pn_gst_type, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_waiting_cust, string pn_demand_ins_str, string pn_mcard_ins_str, string pn_labor_ins_str, string pn_part_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_sch_est_part_amt, string pn_sch_est_lab_amt, string pn_dmd_est_part_amt, string pn_dmd_est_lab_amt, string pn_est_remarks);
        BaseListReturnType<JobCardUpdate> JobCardUpdate(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id, string pn_gst_type, string pn_srv_cat_cd, string pn_sub_srv_type_cd, string pn_omr, string pn_promised_date, string pn_payment_mode, string pn_sa_adv, string pn_tech_adv, string pn_bay_cd, string pn_group_cd, string pn_tech_cd, string pn_waiting_cust, string pn_demand_ins_str, string pn_mcard_ins_str, string pn_labor_ins_str, string pn_part_ins_str, string pn_repair_ins_str, string pn_pickup_type, string pn_pickup_date, string pn_free_pikcup_flag, string pn_pickup_loc_cd, string pn_pickup_driver, string pn_pikcup_remarks, string pn_mms_num, string pn_sch_est_part_amt, string pn_sch_est_lab_amt, string pn_dmd_est_part_amt, string pn_dmd_est_lab_amt, string pn_est_remarks);
        #endregion

        #region JobCardPreInvoicePrint
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardPreInvoicePrint")]
        BaseListReturnType<JobCardPreInvoicePrint> JobCardPreInvoicePrint(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_user_id);
        #endregion

        #region MonitoringScreenBayDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MonitoringScreenBayDetail")]
        BaseListReturnType<MonitoringScreenBayDetail> MonitoringScreenBayDetail(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_bay_start_date);
        #endregion

        #region JCClosingBillableType
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JCClosingBillableType")]
        BaseListReturnType<JCClosingBillableType> JCClosingBillableType(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_labor_Cd, string pn_bill_type_Cd);
        #endregion

        #region QMMonitoringJobCard
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "QMMonitoringJobCard")]
        BaseListReturnType<QMClusterMonitoringJobCardResult> QMMonitoringJobCard(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date);
        #endregion

        #region MonitoringVehicleStuckUpDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MonitoringVehicleStuckUpDetail")]
        BaseListReturnType<MonitoringVehicleStuckUpDetail> MonitoringVehicleStuckUpDetail(string pn_dealer_map_cd, string pn_loc_Cd, string pn_date);
        #endregion

        #region WalkinCustomerVehInfo
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "WalkinCustomerVehInfo")]
        BaseListReturnType<WalkinCustomerVehInfo> WalkinCustomerVehInfo(string pn_rfid_num, string pn_dealer_map_cd, string pn_loc_Cd);
        #endregion

        #region ValidateBillType
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ValidateBillType")]
        BaseListReturnType<ValidateBillType> ValidateBillType(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_jc_num, string pn_part_num, string pn_bill_type_Cd);
        #endregion

        #region QMMonitoringJobCardStageWiseDetails
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "QMMonitoringJobCardStageWiseDetails")]
        BaseListReturnType<QMMonitoringJobCardStageWiseDetails> QMMonitoringJobCardStageWiseDetails(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date);
        #endregion

        #region QMMonitoringJobCard New
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "QMMonitoringJobCards")]
        BaseListReturnType<QMClusterMonitoringJobCardsResult> QMMonitoringJobCards(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date);
        #endregion

        #region QMMonitoringJobCardOnly
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "QMMonitoringJobCardOnly")]
        BaseListReturnType<QMMonitoringJobCardOnly> QMMonitoringJobCardOnly(string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_date);
        #endregion

        #region VehicleStatusDisplay
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "VehicleStatusDisplay")]
        BaseListReturnType<VehicleStatusDisplay> VehicleStatusDisplay(string p_group, string d_mapcd, string l_code);
        #endregion

        //#region NexaAlert
        //[OperationContract]
        //[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "NexaAlert")]
        //BaseListReturnType<Notification_NexaAlert> NexaAlert(string pn_date);
        //#endregion

        #region MyCalls_GetINTCustHDR
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetINTCustHDR")]
        BaseListReturnType<MyCalls_GetINTCustHDR> MyCallsGetINTCustHDR(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_from_date, string pn_to_Date);
        #endregion

        #region MyCalls_GetINTCustDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyCallsGetINTCustDetail")]
        BaseListReturnType<MyCalls_GetSrvCustomerDetail2> MyCallsGetINTCustDetail(string pn_user_id, string pn_parent_group, string pn_dealer_map_cd, string pn_loc_Cd, string pn_comp_fa, string pn_cust_cd, string pn_vin, string pn_followup_type, string pn_psf_num);
        #endregion

        #region VTSStageWiseDetails
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "VTSStageWiseDetails")]
        BaseListReturnType<VTSStageDetails> VTSStageWiseDetails(string pn_dealer_map_cd, string pn_loc_Cd, string pn_date);
        #endregion

        #region ModifyCustomerDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ModifyCustomerDetail")]
        BaseListReturnType<ModifyCustomerDetail> ModifyCustomerDetail(string pn_cust_id, string pn_user_id, string pn_cust_mod_flag, string pn_cust_name, string pn_cust_add1, string pn_cust_add2, string pn_cust_add3, string pn_city_cd, string pn_city_desc, string pn_email, string pn_email1, string pn_phone, string pn_work_phone, string pn_mobile, string pn_dob, string pn_doa);
        #endregion

        #region GetRFTagDetail
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetRFTagDetail")]
        BaseListReturnType<RFTagDetail> GetRFTagDetail(string pn_parent_group, string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_vin, string pn_srv_cat_cd);
        #endregion

        #region GetRFTagScanTime
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetRFTagScanTime")]
        BaseListReturnType<RFTagScanTime> GetRFTagScanTime(string pn_dealer_cd, string pn_loc_cd, string pn_user_id, string pn_rftag_no, string pn_srv_cat_cd);
        #endregion
    }
}