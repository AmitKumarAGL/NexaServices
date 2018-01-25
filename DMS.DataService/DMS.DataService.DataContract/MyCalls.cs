using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MyCalls
    {
    }
    [DataContract]
    public class MyCalls_GetResponse
    {
        [DataMember]
        public string response_type { get; set; }
        [DataMember]
        public string response_cd { get; set; }
        [DataMember]
        public string response_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetRating
    {
        [DataMember]
        public string rating_Cd { get; set; }
        [DataMember]
        public string rating_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetFollowStatus
    {
        [DataMember]
        public string status_Cd { get; set; }
        [DataMember]
        public string status_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetPSFDissatisfiedReason
    {
        [DataMember]
        public string disreason_cd { get; set; }
        [DataMember]
        public string disreason_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetSrvMod
    {
        [DataMember]
        public string mode_Cd { get; set; }
        [DataMember]
        public string mode_Desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetScript
    {
        [DataMember]
        public string script_type { get; set; }
        [DataMember]
        public string script { get; set; }
    }
    [DataContract]
    public class MyCalls_GetPSFCustHDR
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_from_date { get; set; }
        [DataMember]
        public string pn_to_Date { get; set; }
        [DataMember]
        public string pn_followup_Cd { get; set; }
        [DataMember]
        public string pn_psf_days { get; set; }
        [DataMember]
        public List<MyCalls_PSFDash> MyCalls_PSFDash { get; set; }
        [DataMember]
        public List<MyCalls_CustomerResponse> MyCalls_CustomerResponse { get; set; }

        [DataMember]
        public string psf_Generated_Count { get; set; }
        [DataMember]
        public string psf_Close_Count { get; set; }
        [DataMember]
        public string psf_Open_Count { get; set; }
    }
    [DataContract]
    public class MyCalls_PSFDash
    {
        [DataMember]
        public string sr_no { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string Cust_cd { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string model_desc { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string email_id { get; set; }
        [DataMember]
        public string followup_date { get; set; }
        [DataMember]
        public string followup_day { get; set; }
        [DataMember]
        public string followup_type { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string list_cd { get; set; }
        [DataMember]
        public string list_desc { get; set; }
        [DataMember]
        public string status_cd { get; set; }
        [DataMember]
        public string status_Desc { get; set; }
        [DataMember]
        public string satisfied_flag { get; set; }
        [DataMember]
        public string emp_Cd { get; set; }
        [DataMember]
        public string sub_srv_rcateg { get; set; }
    }
    [DataContract]
    public class MyCalls_CustomerResponse
    {
        [DataMember]
        public string ROWNUM { get; set; }
        [DataMember]
        public string list_code { get; set; }
        [DataMember]
        public string list_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_GetSMRWelcomeCustHDR
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_from_date { get; set; }
        [DataMember]
        public string pn_to_Date { get; set; }

        [DataMember]
        public List<MyCalls_SMRDash> MyCalls_SMRDash { get; set; }
        [DataMember]
        public List<MyCalls_WelcomeDash> MyCalls_WelcomeDash { get; set; }

        [DataMember]
        public string smr_Generated_Count { get; set; }
        [DataMember]
        public string smr_Close_Count { get; set; }
        [DataMember]
        public string smr_Open_Count { get; set; }

        [DataMember]
        public string welcome_Generated_Count { get; set; }
        [DataMember]
        public string welcome_Close_Count { get; set; }
        [DataMember]
        public string welcome_Open_Count { get; set; }
    }
    [DataContract]
    public class MyCalls_SMRDash
    {
        [DataMember]
        public string sr_no { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string Cust_cd { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string model_desc { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string email_id { get; set; }
        [DataMember]
        public string followup_date { get; set; }
        [DataMember]
        public string srv_type_cd { get; set; }
        [DataMember]
        public string sub_Srv_type_desc { get; set; }
        [DataMember]
        public string list_cd { get; set; }
        [DataMember]
        public string list_desc { get; set; }
        [DataMember]
        public string list_updateable { get; set; }
        [DataMember]
        public string Psf_Num { get; set; }
        [DataMember]
        public string followup_type { get; set; }
        [DataMember]
        public string emp_Cd { get; set; }

        [DataMember]
        public string NEXA_VEH { get; set; }
    }
    [DataContract]
    public class MyCalls_WelcomeDash
    {
        [DataMember]
        public string sr_no { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string Cust_cd { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string model_desc { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string email_id { get; set; }
        [DataMember]
        public string followup_date { get; set; }
        [DataMember]
        public string list_cd { get; set; }
        [DataMember]
        public string list_desc { get; set; }
        [DataMember]
        public string followup_type { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string status_cd { get; set; }
        [DataMember]
        public string status_Desc { get; set; }
        [DataMember]
        public string updateable { get; set; }
        [DataMember]
        public string emp_Cd { get; set; }

        [DataMember]
        public string NEXA_VEH { get; set; }
    }
    [DataContract]
    public class MyCalls_GetSrvCustomerDetail
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_cust_cd { get; set; }
        [DataMember]
        public string pn_vin { get; set; }
        [DataMember]
        public string pn_followup_type { get; set; }
        [DataMember]
        public string pn_psf_num { get; set; }

        [DataMember]
        public List<MyCalls_CustomerVehicleDet> MyCalls_CustomerVehicleDet { get; set; }
        [DataMember]
        public List<MyCalls_LastFollowUp> MyCalls_LastFollowUp { get; set; }
        [DataMember]
        public List<MyCalls_JCDetails> MyCalls_JCDetails { get; set; }
        [DataMember]
        public List<MyCalls_PendingComplaints> MyCalls_PendingComplaints { get; set; }

        [DataMember]
        public string po_bkg_type { get; set; }
        [DataMember]
        public string po_bkg_date { get; set; }
        [DataMember]
        public string po_srv_type { get; set; }
        [DataMember]
        public string po_pickup_req { get; set; }
        [DataMember]
        public string po_free_pickup { get; set; }
        [DataMember]
        public string po_pickup_type { get; set; }
        [DataMember]
        public string po_pickup_date { get; set; }
        [DataMember]
        public string po_pickup_loc { get; set; }
        [DataMember]
        public string po_pickup_driver { get; set; }
        [DataMember]
        public string po_pickup_remarks { get; set; }

        [DataMember]
        public List<MyCalls_FollowUp> MyCalls_FollowUp { get; set; }

        [DataMember]
        public string po_satisified_flag { get; set; }
        [DataMember]
        public string po_voice_cust { get; set; }

        [DataMember]
        public List<MyCalls_PSFFollowUp> MyCalls_PSFFollowUp { get; set; }
    }
    [DataContract]
    public class MyCalls_CustomerVehicleDet
    {
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string phone_m { get; set; }
        [DataMember]
        public string phone_o { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string contact_person { get; set; }
        [DataMember]
        public string preferred_time { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vehicle_model { get; set; }
        [DataMember]
        public string vehicle_variant { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string color_desc { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string RM { get; set; }
        [DataMember]
        public string EW { get; set; }
        [DataMember]
        public string Service_Type { get; set; }
        [DataMember]
        public string Due_Date { get; set; }
        [DataMember]
        public string last_srv_date { get; set; }
        [DataMember]
        public string last_srv_type { get; set; }
        [DataMember]
        public string last_srv_mileage { get; set; }
        [DataMember]
        public string last_psf_status { get; set; }
    }
    [DataContract]
    public class MyCalls_LastFollowUp
    {
        //[DataMember]
        //public string followup_no { get; set; }
        //[DataMember]
        //public string type { get; set; }
        //[DataMember]
        //public string followup_Date { get; set; }
        //[DataMember]
        //public string response { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string psf_type { get; set; }
        [DataMember]
        public string psf_date { get; set; }
        [DataMember]
        public string response { get; set; }
    }
    [DataContract]
    public class MyCalls_JCDetails
    {
        //[DataMember]
        //public string jc_no { get; set; }
        //[DataMember]
        //public string jc_Date { get; set; }
        //[DataMember]
        //public string jc_omr { get; set; }
        //[DataMember]
        //public string srv_type { get; set; }
        //[DataMember]
        //public string bill_amt { get; set; }
        //[DataMember]
        //public string csi { get; set; }
        [DataMember]
        public string ro_num { get; set; }
        [DataMember]
        public string ro_date { get; set; }
        [DataMember]
        public string odometer_reading { get; set; }
        [DataMember]
        public string rcateg_cd { get; set; }
        [DataMember]
        public string bill_amt { get; set; }
        [DataMember]
        public string csi_per { get; set; }
    }
    [DataContract]
    public class MyCalls_PendingComplaints
    {
        //[DataMember]
        //public string complaint_no { get; set; }
        //[DataMember]
        //public string complaint_date { get; set; }
        //[DataMember]
        //public string satisfied_yn { get; set; }
        //[DataMember]
        //public string cust_voice { get; set; }
        [DataMember]
        public string compl_num { get; set; }
        [DataMember]
        public string compl_date { get; set; }
        [DataMember]
        public string comp_status { get; set; }
        [DataMember]
        public string complaint_desc { get; set; }
    }
    [DataContract]
    public class MyCalls_FollowUp
    {
        //[DataMember]
        //public string followup_no { get; set; }
        //[DataMember]
        //public string followup_type { get; set; }
        //[DataMember]
        //public string followup_Date { get; set; }
        //[DataMember]
        //public string response_Cd { get; set; }
        //[DataMember]
        //public string response_Desc { get; set; }
        //[DataMember]
        //public string rating_Cd { get; set; }
        //[DataMember]
        //public string rating_desc { get; set; }
        //[DataMember]
        //public string followup_status_cd { get; set; }
        //[DataMember]
        //public string followup_status_desc { get; set; }
        //[DataMember]
        //public string next_followup_Date { get; set; }
        //[DataMember]
        //public string contact_person { get; set; }
        //[DataMember]
        //public string complaint { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string psf_type { get; set; }
        [DataMember]
        public string psf_date { get; set; }
        [DataMember]
        public string response { get; set; }
        [DataMember]
        public string response_Desc { get; set; }
        [DataMember]
        public string rating_Cd { get; set; }
        [DataMember]
        public string rating_desc { get; set; }
        [DataMember]
        public string followup_status_cd { get; set; }
        [DataMember]
        public string followup_status_desc { get; set; }
        [DataMember]
        public string next_followup_Date { get; set; }
        [DataMember]
        public string contact_person { get; set; }
        [DataMember]
        public string complaint { get; set; }
    }
    [DataContract]
    public class MyCalls_PSFFollowUp
    {
        //[DataMember]
        //public string sr_no { get; set; }
        //[DataMember]
        //public string script_Cd { get; set; }
        //[DataMember]
        //public string script_Desc { get; set; }
        //[DataMember]
        //public string feedback { get; set; }
        //[DataMember]
        //public string voice_of_cust { get; set; }
        [DataMember]
        public string psf_srl { get; set; }
        [DataMember]
        public string psf_questions { get; set; }
        [DataMember]
        public string script_desc { get; set; }
        [DataMember]
        public string psf_feedback { get; set; }
        [DataMember]
        public string feedback_desc { get; set; }
        [DataMember]
        public string voice_of_cust { get; set; }
    }

    [DataContract]
    public class MyCalls_UpdateFollowUpDetail
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_followup_Cd { get; set; }
        [DataMember]
        public string pn_status_Cd { get; set; }
        [DataMember]
        public string pn_vin { get; set; }
        [DataMember]
        public string pn_bkg_type { get; set; }
        [DataMember]
        public string pn_bkg_date { get; set; }
        [DataMember]
        public string pn_srv_type { get; set; }
        [DataMember]
        public string pn_pickup_req { get; set; }
        [DataMember]
        public string pn_free_pickup { get; set; }
        [DataMember]
        public string pn_pickup_type { get; set; }
        [DataMember]
        public string pn_pickup_date { get; set; }
        [DataMember]
        public string pn_pickup_loc { get; set; }
        [DataMember]
        public string pn_pickup_driver { get; set; }
        [DataMember]
        public string pn_pickup_remarks { get; set; }
        [DataMember]
        public string pn_mms_reg_num { get; set; }
        [DataMember]
        public string pn_followup_str { get; set; }
        //[DataMember]
        //public string followup_no { get; set; }
        //[DataMember]
        //public string followup_type { get; set; }
        //[DataMember]
        //public string followup_Date { get; set; }
        //[DataMember]
        //public string response_Cd { get; set; }
        //[DataMember]
        //public string rating_Cd { get; set; }
        //[DataMember]
        //public string followup_status_cd { get; set; }
        //[DataMember]
        //public string next_followup_Date { get; set; }
        //[DataMember]
        //public string contact_person { get; set; }
        //[DataMember]
        //public string complaint { get; set; }
        [DataMember]
        public string pn_voice_cust { get; set; }
        [DataMember]
        public string pn_psf_followup_str { get; set; }
        //[DataMember]
        //public string sr_no { get; set; }
        //[DataMember]
        //public string script_Cd { get; set; }
        //[DataMember]
        //public string feedback { get; set; }
        //[DataMember]
        //public string voice_of_cust { get; set; }
    }




    [DataContract]
    public class MyCalls_GetINTCustHDR
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_from_date { get; set; }
        [DataMember]
        public string pn_to_Date { get; set; }

        [DataMember]
        public List<MyCalls_INTCallDet> MyCalls_INTCallDet { get; set; }

        [DataMember]
        public string int_Generated_Count { get; set; }
        [DataMember]
        public string int_Close_Count { get; set; }
        [DataMember]
        public string int_Open_Count { get; set; }
    }
    [DataContract]
    public class MyCalls_INTCallDet
    {
        [DataMember]
        public string sr_no { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string Cust_cd { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string model_desc { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string email_id { get; set; }
        [DataMember]
        public string followup_date { get; set; }

        [DataMember]
        public string list_cd { get; set; }
        [DataMember]
        public string list_desc { get; set; }
        [DataMember]
        public string followup_type { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string status_cd { get; set; }
        [DataMember]
        public string status_Desc { get; set; }
        [DataMember]
        public string UPDATEABLE { get; set; }
        [DataMember]
        public string emp_Cd { get; set; }
        [DataMember]
        public string NEXA_VEH { get; set; }
    }










    [DataContract]
    public class MyCalls_GetSrvCustomerDetail2
    {
        #region Property
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_cust_cd { get; set; }
        [DataMember]
        public string pn_vin { get; set; }
        [DataMember]
        public string pn_followup_type { get; set; }
        [DataMember]
        public string pn_psf_num { get; set; }

        [DataMember]
        public List<MyCalls_CustomerVehicleDet2> MyCalls_CustomerVehicleDet { get; set; }
        #endregion
        [DataMember]
        public List<MyCalls_LastFollowUp2> MyCalls_LastFollowUp { get; set; }
        [DataMember]
        public List<MyCalls_FollowUp2> MyCalls_FollowUp { get; set; }

        [DataMember]
        public string po_satisified_flag { get; set; }
        [DataMember]
        public string po_voice_cust { get; set; }

        [DataMember]
        public List<MyCalls_PSFFollowUp2> MyCalls_PSFFollowUp { get; set; }
    }
    [DataContract]
    public class MyCalls_CustomerVehicleDet2
    {
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string phone_m { get; set; }
        [DataMember]
        public string phone_o { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string contact_person { get; set; }
        [DataMember]
        public string preferred_time { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string vehicle_model { get; set; }
        [DataMember]
        public string vehicle_variant { get; set; }
        [DataMember]
        public string Sale_Date { get; set; }
        [DataMember]
        public string color_desc { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string RM { get; set; }
        [DataMember]
        public string EW { get; set; }
        [DataMember]
        public string Service_Type { get; set; }
        [DataMember]
        public string Due_Date { get; set; }
        [DataMember]
        public string last_srv_date { get; set; }
        [DataMember]
        public string last_srv_type { get; set; }
        [DataMember]
        public string last_srv_mileage { get; set; }
        [DataMember]
        public string last_psf_status { get; set; }
    }
    [DataContract]
    public class MyCalls_LastFollowUp2
    {
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string psf_type { get; set; }
        [DataMember]
        public string psf_date { get; set; }
        [DataMember]
        public string response { get; set; }
    }
    [DataContract]
    public class MyCalls_FollowUp2
    {
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string psf_type { get; set; }
        [DataMember]
        public string psf_date { get; set; }
        [DataMember]
        public string response { get; set; }
        [DataMember]
        public string response_Desc { get; set; }
        [DataMember]
        public string rating_Cd { get; set; }
        [DataMember]
        public string rating_desc { get; set; }
        [DataMember]
        public string followup_status_cd { get; set; }
        [DataMember]
        public string followup_status_desc { get; set; }
        [DataMember]
        public string next_followup_Date { get; set; }
        [DataMember]
        public string contact_person { get; set; }
        [DataMember]
        public string complaint { get; set; }
    }
    [DataContract]
    public class MyCalls_PSFFollowUp2
    {
        [DataMember]
        public string psf_srl { get; set; }
        [DataMember]
        public string psf_questions { get; set; }
        [DataMember]
        public string script_desc { get; set; }
        [DataMember]
        public string psf_feedback { get; set; }
        [DataMember]
        public string feedback_desc { get; set; }
        [DataMember]
        public string voice_of_cust { get; set; }
    }
}