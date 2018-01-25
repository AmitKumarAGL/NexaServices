using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NEXA.DataService.DataContract
{
    class JCOCustVehicleMaster
    {
    }

    [DataContract]
    public class JobCardOpeningCustomerAndVehicleMaster
    {
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string po_srvbooking_no { get; set; }
        [DataMember]
        public string po_cust_id { get; set; }
        [DataMember]
        public string po_cust_name { get; set; }
        [DataMember]
        public string po_cust_address { get; set; }
        [DataMember]
        public string po_city { get; set; }
        [DataMember]
        public string po_state { get; set; }
        [DataMember]
        public string po_phone { get; set; }
        [DataMember]
        public string po_mobile { get; set; }
        [DataMember]
        public string po_pin { get; set; }
        [DataMember]
        public string po_email { get; set; }
        [DataMember]
        public string po_vehiclemodel { get; set; }
        [DataMember]
        public string po_vin { get; set; }
        [DataMember]
        public string po_rftagno { get; set; }
        [DataMember]
        public string po_chassisno { get; set; }
        [DataMember]
        public string po_color { get; set; }
        [DataMember]
        public string po_ownveh_count { get; set; }
        [DataMember]
        public string po_veh_sale_date { get; set; }
        [DataMember]
        public string po_tv_yn { get; set; }
        [DataMember]
        public string po_n2n_yn { get; set; }
        [DataMember]
        public string po_ew_yn { get; set; }
        [DataMember]
        public string po_mi_yn { get; set; }
        [DataMember]
        public string po_category { get; set; }
        [DataMember]
        public string po_tv_sale_date { get; set; }
        [DataMember]
        public string po_mi_validity_date { get; set; }
        [DataMember]
        public string po_variant_cd { get; set; }
        [DataMember]
        public string po_variant_desc { get; set; }
        [DataMember]
        public string po_cust_category { get; set; }
        [DataMember]
        public string po_ew_type { get; set; }
        [DataMember]
        public string po_ew_expiry_date { get; set; }
        [DataMember]
        public string po_srv_model_desc { get; set; }
        [DataMember]
        public string po_srv_model_cd { get; set; }
        [DataMember]
        public string po_tech_cap_yn { get; set; }
        [DataMember]
        public string po_mcp_package_desc { get; set; }
        [DataMember]
        public string po_mcp_expiry_date { get; set; }
        [DataMember]
        public string po_autocard_no { get; set; }
        [DataMember]
        public string po_autocard_point { get; set; }
        [DataMember]
        public string po_complement_dtl { get; set; }
        [DataMember]
        public string po_last_followup_dtl { get; set; }

        [DataMember]
        public string po_last_followup_by { get; set; }
        [DataMember]
        public string po_govt_yn { get; set; }
        [DataMember]
        public string po_last_csi { get; set; }
        [DataMember]
        public string po_theft_yn { get; set; }

        [DataMember]
        public string po_veh_user_name { get; set; }
        [DataMember]
        public string po_engine_num { get; set; }
        [DataMember]
        public string po_key_no { get; set; }
        [DataMember]
        public string po_sold_by { get; set; }
        [DataMember]
        public string po_mcp_enrol_no { get; set; }
        [DataMember]
        public string po_mcp_type { get; set; }
        [DataMember]
        public string po_repair { get; set; }
        [DataMember]
        public string po_location { get; set; }
        [DataMember]
        public string po_last_psf_status { get; set; }
        [DataMember]
        public string po_last_srv_date { get; set; }
        [DataMember]
        public string po_next_srv_due { get; set; }
        [DataMember]
        public string po_next_due_date { get; set; }

    }

    [DataContract]
    public class GenerateJobCard
    {
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }
        [DataMember]
        public string pn_sub_srv_type_cd { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string pn_promised_date { get; set; }
        [DataMember]
        public string pn_checkin_date { get; set; }
        [DataMember]
        public string pn_sa_adv { get; set; }
        [DataMember]
        public string pn_tech_adv { get; set; }
        [DataMember]
        public string pn_bay_cd { get; set; }
        [DataMember]
        public string pn_group_cd { get; set; }
        [DataMember]
        public string pn_tech_cd { get; set; }
        [DataMember]
        public string pn_rfid_num { get; set; }
        [DataMember]
        public string pn_waiting_cust { get; set; }
        [DataMember]
        public string pn_demand_ins_str { get; set; }
        //[DataMember]
        //public string demand_cd { get; set; }
        //[DataMember]
        //public string demand_desc { get; set; }
        //[DataMember]
        //public string demand_type { get; set; }
        //[DataMember]
        //public string problem_narr { get; set; }
        [DataMember]
        public string pn_part_ins_str { get; set; }
        //[DataMember]
        //public string part_no { get; set; }
        //[DataMember]
        //public string part_desc { get; set; }
        //[DataMember]
        //public string issued_qty { get; set; }
        //[DataMember]
        //public string issued_bill_type { get; set; }
        //[DataMember]
        //public string part_amt { get; set; }
        [DataMember]
        public string pn_labor_ins_str { get; set; }
        //[DataMember]
        //public string labor_cd { get; set; }
        //[DataMember]
        //public string labor_desc { get; set; }
        //[DataMember]
        //public string labor_amt { get; set; }
        [DataMember]
        public string pn_inv_ins_str { get; set; }
        //[DataMember]
        //public string inv_cd { get; set; }
        //[DataMember]
        //public string inv_desc { get; set; }
        //[DataMember]
        //public string inv_yn { get; set; }
        //[DataMember]
        //public string inv_remarks { get; set; }
        [DataMember]
        public string pn_mcard_ins_str { get; set; }
        //[DataMember]
        //public string srv_type_Cd { get; set; }
        //[DataMember]
        //public string srv_cd { get; set; }
        //[DataMember]
        //public string accept_yn { get; set; }
        //[DataMember]
        //public string accept_qty { get; set; }
        //[DataMember]
        //public string reject_Reason_cd { get; set; }
        //[DataMember]
        //public string Part_num { get; set; }
        //[DataMember]
        //public string allow_qty { get; set; }
        [DataMember]
        public string pn_unapprv_fit_str { get; set; }
        //[DataMember]
        //public string fitment_cd { get; set; }
        //[DataMember]
        //public string fitment_desc { get; set; }
        [DataMember]
        public string pn_estm_str { get; set; }
        //[DataMember]
        //public string esti_num { get; set; }
        //[DataMember]
        //public string esti_suplement { get; set; }
        [DataMember]
        public string pn_prob_str { get; set; }
        [DataMember]
        public string pn_pickup_type { get; set; }
        [DataMember]
        public string pn_pickup_loc_cd { get; set; }
        [DataMember]
        public string pn_pickup_date { get; set; }
        [DataMember]
        public string pn_free_pikcup_flag { get; set; }
        [DataMember]
        public string pn_pickup_driver { get; set; }
        [DataMember]
        public string pn_pikcup_remarks { get; set; }
        [DataMember]
        public string pn_drop_loc_cd { get; set; }
        [DataMember]
        public string pn_drop_date { get; set; }
        [DataMember]
        public string pn_mms_num { get; set; }
        [DataMember]
        public string pn_rtest_stime { get; set; }
        [DataMember]
        public string pn_rtest_skms { get; set; }
        [DataMember]
        public string pn_rtest_etime { get; set; }
        [DataMember]
        public string pn_rtest_ekms { get; set; }
        [DataMember]
        public string pn_part_est_amt { get; set; }
        [DataMember]
        public string pn_opr_est_amt { get; set; }
        [DataMember]
        public string pn_cust_sign { get; set; }
        //[DataMember]
        //public byte[] pn_cust_sign { get; set; }
        [DataMember]
        public string pn_est_remarks { get; set; }
        [DataMember]
        public string po_part_req_num { get; set; }
        [DataMember]
        public string po_job_card_num { get; set; }
    }

    [DataContract]
    public class JobCardClosePull
    {
        [DataMember]
        public string pn_jc_module { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_jc_no { get; set; }
        [DataMember]
        public string po_jc_status { get; set; }

        [DataMember]
        public string po_jc_status_desc { get; set; }

        [DataMember]
        public string po_gst_type { get; set; }

        [DataMember]
        public string po_reg_num { get; set; }
        [DataMember]
        public string po_pay_mode { get; set; }
        [DataMember]
        public string po_pay_mode_desc { get; set; }
        [DataMember]
        public string po_omr { get; set; }
        [DataMember]
        public string po_srv_type_cd { get; set; }
        [DataMember]
        public string po_srv_type_desc { get; set; }
        [DataMember]
        public string po_sub_srv_cd { get; set; }
        [DataMember]
        public string po_sub_srv_desc { get; set; }
        [DataMember]
        public string po_bay_cd { get; set; }
        [DataMember]
        public string po_bay_desc { get; set; }
        [DataMember]
        public string po_srv_adv_cd { get; set; }
        [DataMember]
        public string po_srv_adv_desc { get; set; }
        [DataMember]
        public string po_group_cd { get; set; }
        [DataMember]
        public string po_group_desc { get; set; }
        [DataMember]
        public string po_tech_cd { get; set; }
        [DataMember]
        public string po_tech_desc { get; set; }
        [DataMember]
        public string po_tech_adv_Cd { get; set; }
        [DataMember]
        public string po_tech_adv_desc { get; set; }
        [DataMember]
        public string po_ceo_approval { get; set; }
        [DataMember]
        public string po_lastflwup_date { get; set; }
        [DataMember]
        public string po_lastflwup_csi { get; set; }
        [DataMember]
        public string po_lastflwup_by { get; set; }
        [DataMember]
        public string po_pickup_type { get; set; }
        [DataMember]
        public string po_pickup_type_desc { get; set; }
        [DataMember]
        public string po_pickup_date { get; set; }
        [DataMember]
        public string po_pickup_loc { get; set; }
        [DataMember]
        public string po_pickup_loc_desc { get; set; }
        [DataMember]
        public string po_driver { get; set; }
        [DataMember]
        public string po_driver_desc { get; set; }
        [DataMember]
        public string po_pickup_remarks { get; set; }
        [DataMember]
        public string po_free_pickup_yn { get; set; }
        [DataMember]
        public string po_mms_num { get; set; }
        [DataMember]
        public string po_intial_prom_date { get; set; }
        [DataMember]
        public string po_revised_prom_date { get; set; }
        [DataMember]
        public string po_jc_close_date { get; set; }
        [DataMember]
        public string po_jc_open_date { get; set; }
        [DataMember]
        public string po_cust_corp_status { get; set; }
        [DataMember]
        public string po_rdtest_st_time { get; set; }
        [DataMember]
        public string po_rdtest_st_km { get; set; }
        [DataMember]
        public string po_rdtest_end_time { get; set; }
        [DataMember]
        public string po_rdtest_end_km { get; set; }
        [DataMember]
        public string po_est_sch_labor_amt { get; set; }
        [DataMember]
        public string po_est_sch_part_amt { get; set; }
        [DataMember]
        public string po_est_labor_amt { get; set; }
        [DataMember]
        public string po_est_part_amt { get; set; }
        [DataMember]
        public string po_re_est_labor_amt { get; set; }
        [DataMember]
        public string po_re_est_part_amt { get; set; }
        [DataMember]
        public string po_amc_yn { get; set; }
        [DataMember]
        public string po_amc_num { get; set; }
        [DataMember]
        public string po_amc_date { get; set; }
        [DataMember]
        public string po_recall_yn { get; set; }
        [DataMember]
        public string po_delay_reas_cd { get; set; }
        [DataMember]
        public string po_delay_reas_desc { get; set; }
        [DataMember]
        public string po_delay_reas_remarks { get; set; }
        [DataMember]
        public string po_csi_reas_cd { get; set; }
        [DataMember]
        public string po_csi_reas_desc { get; set; }
        [DataMember]
        public string po_csi_reas_remarks { get; set; }
        [DataMember]
        public string po_part_disc_perc { get; set; }
        [DataMember]
        public string po_labour_disc_perc { get; set; }
        [DataMember]
        public string po_disc_auth_by_cd { get; set; }
        [DataMember]
        public string po_disc_auth_by_desc { get; set; }
        [DataMember]
        public List<JCClosePull_DemandList> DemandList { get; set; }
        [DataMember]
        public List<JCClosePull_PartList> PartList { get; set; }
        [DataMember]
        public List<JCClosePull_LaborList> LaborList { get; set; }
        [DataMember]
        public List<JCClosePull_InvList> InvList { get; set; }
        [DataMember]
        public List<JCClosePull_SmcardList> SmcardList { get; set; }
        [DataMember]
        public List<JCClosePull_UnapprfitList> UnapprfitList { get; set; }
        [DataMember]
        public List<JCClosePull_Tech_campList> Tech_campList { get; set; }
        [DataMember]
        public List<JCClosePull_Repair_actList> Repair_actList { get; set; }
        [DataMember]
        public List<JCClosePull_Comply_dtlList> Comply_dtlList { get; set; }

        [DataMember]
        public string po_vts_card_num { get; set; }
        [DataMember]
        public string po_checkin_date { get; set; }
        [DataMember]
        public string po_cus_out_amt { get; set; }
        [DataMember]
        public string po_pref_followup_time { get; set; }
        [DataMember]
        public string po_prob_str { get; set; }
    }
    [DataContract]
    public class JCClosePull_DemandList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Demand_Cd { get; set; }
        [DataMember]
        public string Demand_Desc { get; set; }
        [DataMember]
        public string Reported_by { get; set; }
        [DataMember]
        public string Reported_by_desc { get; set; }
        [DataMember]
        public string Attended_YN { get; set; }
        [DataMember]
        public string Carry_fwd_YN { get; set; }
        [DataMember]
        public string Carry_fwd_YN_desc { get; set; }
        [DataMember]
        public string War_YN { get; set; }
        [DataMember]
        public string problem_narr { get; set; }
    }
    [DataContract]
    public class JCClosePull_PartList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Doc_Num { get; set; }
        [DataMember]
        public string Part_Num { get; set; }
        [DataMember]
        public string Part_Desc { get; set; }
        [DataMember]
        public string Req_qty { get; set; }
        [DataMember]
        public string Issued_qty { get; set; }
        [DataMember]
        public string Return_qty { get; set; }
        [DataMember]
        public string Bill_qty { get; set; }
        [DataMember]
        public string Rate { get; set; }
        [DataMember]
        public string Total_amt { get; set; }
        [DataMember]
        public string Bill_type { get; set; }
        [DataMember]
        public string Bill_type_desc { get; set; }
        [DataMember]
        public string Auto_depreciation { get; set; }
        [DataMember]
        public string Disc_ind { get; set; }
        [DataMember]
        public string Disc_ind_desc { get; set; }
        [DataMember]
        public string Disc_value { get; set; }
        [DataMember]
        public string Split_ratio { get; set; }
        [DataMember]
        public string Split_desc { get; set; }
        [DataMember]
        public string Cust_per { get; set; }
        [DataMember]
        public string Ins_per { get; set; }
        [DataMember]
        public string Dlr_per { get; set; }
        [DataMember]
        public string Oem_per { get; set; }
        [DataMember]
        public string Curr_stock { get; set; }
    }
    [DataContract]
    public class JCClosePull_LaborList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Labour_Cd { get; set; }
        [DataMember]
        public string Labour_Desc { get; set; }
        [DataMember]
        public string Mod_yn { get; set; }
        [DataMember]
        public string Flat_amt { get; set; }
        [DataMember]
        public string labour_amt { get; set; }
        [DataMember]
        public string FRM_hrs { get; set; }
        [DataMember]
        public string Bill_type { get; set; }
        [DataMember]
        public string Bill_type_desc { get; set; }
        [DataMember]
        public string Disc_ind { get; set; }
        [DataMember]
        public string Disc_ind_desc { get; set; }
        [DataMember]
        public string Disc_value { get; set; }
        [DataMember]
        public string Split_ratio { get; set; }
        [DataMember]
        public string Split_desc { get; set; }
        [DataMember]
        public string Cust_per { get; set; }
        [DataMember]
        public string Ins_per { get; set; }
        [DataMember]
        public string Dlr_per { get; set; }
        [DataMember]
        public string Oem_per { get; set; }
        [DataMember]
        public string Technician { get; set; }
        [DataMember]
        public string Technician_desc { get; set; }
        [DataMember]
        public string Technician_2 { get; set; }
        [DataMember]
        public string Technician_2_desc { get; set; }
        [DataMember]
        public string sublet_yn { get; set; }
        [DataMember]
        public string Sublet_amt { get; set; }
        [DataMember]
        public string Sub_cont_cd { get; set; }
        [DataMember]
        public string Sub_cont_desc { get; set; }
    }
    [DataContract]
    public class JCClosePull_InvList
    {
        [DataMember]
        public string Inv_Cd { get; set; }
        [DataMember]
        public string Inv_desc { get; set; }
        [DataMember]
        public string Inv_count { get; set; }
        [DataMember]
        public string Inv_yn { get; set; }
    }
    [DataContract]
    public class JCClosePull_SmcardList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Srv_type { get; set; }
        [DataMember]
        public string Srv_type_desc { get; set; }
        [DataMember]
        public string Srv_cd { get; set; }
        [DataMember]
        public string Srv_desc { get; set; }
        [DataMember]
        public string Part_num { get; set; }
        [DataMember]
        public string Part_desc { get; set; }
        [DataMember]
        public string Srv_qty { get; set; }
        [DataMember]
        public string Accept_yn { get; set; }
        [DataMember]
        public string Accept_yn_desc { get; set; }
        [DataMember]
        public string Reject_reason { get; set; }
        [DataMember]
        public string Reject_reason_desc { get; set; }
        [DataMember]
        public string Accept_qty { get; set; }
    }
    [DataContract]
    public class JCClosePull_UnapprfitList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Fitment_cd { get; set; }
        [DataMember]
        public string Fitment_desc { get; set; }
    }
    [DataContract]
    public class JCClosePull_Tech_campList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Srv_circular_num { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Measure { get; set; }
        [DataMember]
        public string From_date { get; set; }
        [DataMember]
        public string To_date { get; set; }
        [DataMember]
        public string Recall_num { get; set; }
        [DataMember]
        public string jc_status { get; set; }
        [DataMember]
        public string JC_status_desc { get; set; }
    }
    [DataContract]
    public class JCClosePull_Repair_actList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string Demand_cd { get; set; }
        [DataMember]
        public string Demand_desc { get; set; }
        [DataMember]
        public string Problem_cd { get; set; }
        [DataMember]
        public string Problem_desc { get; set; }
        [DataMember]
        public string Fault_cd { get; set; }
        [DataMember]
        public string Fault_desc { get; set; }
        [DataMember]
        public string Action_cd { get; set; }
        [DataMember]
        public string Action_desc { get; set; }
    }
    [DataContract]
    public class JCClosePull_Comply_dtlList
    {
        [DataMember]
        public string Srl_Num { get; set; }
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string comp_detls { get; set; }
        [DataMember]
        public string attended_yn { get; set; }
    }

    [DataContract]
    public class JobCardClosePush
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
        public string pn_jc_num { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }
        [DataMember]
        public string pn_sub_srv_type_cd { get; set; }
        [DataMember]
        public string pn_payment_mode { get; set; }
        [DataMember]
        public string pn_sa_adv { get; set; }
        //[DataMember]
        //public string pn_gst_type { get; set; }
        [DataMember]
        public string pn_tech_adv { get; set; }
        [DataMember]
        public string pn_bay_cd { get; set; }
        [DataMember]
        public string pn_group_cd { get; set; }
        [DataMember]
        public string pn_tech_cd { get; set; }
        [DataMember]
        public string pn_demand_ins_str { get; set; }
        //    [DataMember]
        //public string Demand_Cd { get; set; }
        //    [DataMember]
        //public string Cust_voice { get; set; }
        //[DataMember]
        //public string Reported_by { get; set; }
        //    [DataMember]
        //public string Attended_YN { get; set; }
        //    [DataMember]
        //public string Carry_fwd_YN { get; set; }
        //    [DataMember]
        //public string War_YN { get; set; }
        //    [DataMember]
        //public string Rework_dtl { get; set; }
        [DataMember]
        public string pn_repair_ins_str { get; set; }
        //    [DataMember]
        //public string Demand_Cd { get; set; }
        //    [DataMember]
        //public string Problem_Cd { get; set; }
        //    [DataMember]
        //public string Fault_cd { get; set; }
        //    [DataMember]
        //public string Action_cd { get; set; }
        [DataMember]
        public string pn_part_ins_str { get; set; }
        //    [DataMember]
        //public string Part_no { get; set; }
        //    [DataMember]
        //public string Bill_type { get; set; }
        //    [DataMember]
        //public string Disc_Ind { get; set; }
        //    [DataMember]
        //public string Disc_value { get; set; }
        //[DataMember]
        //public string Bill_qty { get; set; }
        //    [DataMember]
        //public string split_ratio { get; set; }
        //    [DataMember]
        //public string Auto_depreciation { get; set; }
        //    [DataMember]
        //public string Cust_paid_per { get; set; }
        //    [DataMember]
        //public string Ins_paid_per { get; set; }
        //    [DataMember]
        //public string Dlr_paid_per { get; set; }
        //    [DataMember]
        //public string Oem_paid_per { get; set; }
        //    [DataMember]
        //public string Issue_reason { get; set; }
        [DataMember]
        public string pn_labor_ins_str { get; set; }
        //    [DataMember]
        //public string Labor_cd { get; set; }
        //    [DataMember]
        //public string Labour_desc { get; set; }
        //    [DataMember]
        //public string Labour_amt { get; set; }
        //    [DataMember]
        //public string Bill_type { get; set; }
        //    [DataMember]
        //public string Disc_ind { get; set; }
        //    [DataMember]
        //public string Disc_value { get; set; }
        //[DataMember]
        //public string Split_ratio { get; set; }
        //    [DataMember]
        //public string Technician { get; set; }
        //    [DataMember]
        //public string Technician_2 { get; set; }
        //    [DataMember]
        //public string Sublet_yn { get; set; }
        //    [DataMember]
        //public string Sublet_amt { get; set; }
        //    [DataMember]
        //public string Sub_cont_cd { get; set; }
        //    [DataMember]
        //public string Cust_paid_per { get; set; }
        //    [DataMember]
        //public string Ins_paid_per { get; set; }
        //    [DataMember]
        //public string Dlr_paid_per { get; set; }
        //    [DataMember]
        //public string Oem_paid_per { get; set; }
        [DataMember]
        public string pn_mcard_ins_str { get; set; }
        //    [DataMember]
        //public string srv_type_cd { get; set; }
        //    [DataMember]
        //public string srv_cd { get; set; }
        //    [DataMember]
        //public string accept_yn { get; set; }
        //    [DataMember]
        //public string accept_qty { get; set; }
        //[DataMember]
        //public string reject_Reason_cd { get; set; }
        //    [DataMember]
        //public string Part_num { get; set; }
        //    [DataMember]
        //public string allow_qty { get; set; }
        [DataMember]
        public string pn_tcamp_ins_str { get; set; }
        //    [DataMember]
        //public string Mul_ref_num { get; set; }
        //    [DataMember]
        //public string Status_cd { get; set; }
        //    [DataMember]
        //public string Status_desc { get; set; }
        [DataMember]
        public string pn_pickup_type { get; set; }
        [DataMember]
        public string pn_pickup_date { get; set; }
        [DataMember]
        public string pn_free_pikcup_flag { get; set; }
        [DataMember]
        public string pn_pickup_loc_cd { get; set; }
        [DataMember]
        public string pn_pickup_driver { get; set; }
        [DataMember]
        public string pn_pikcup_remarks { get; set; }
        [DataMember]
        public string pn_mms_num { get; set; }
        [DataMember]
        public string pn_rtest_startime { get; set; }
        [DataMember]
        public string pn_rtest_startkm { get; set; }
        [DataMember]
        public string pn_rtest_endtime { get; set; }
        [DataMember]
        public string pn_rtest_endkm { get; set; }
        [DataMember]
        public string pn_delay_reas_cd { get; set; }
        [DataMember]
        public string pn_delay_reas_rem { get; set; }
        [DataMember]
        public string pn_csi_reas_cd { get; set; }
        [DataMember]
        public string pn_csi_reas_rem { get; set; }
        [DataMember]
        public string pn_disc_part_perc { get; set; }
        [DataMember]
        public string pn_disc_labour_perc { get; set; }
        [DataMember]
        public string pn_disc_auth_by { get; set; }
    }

    [DataContract]
    public class ServiceTypeValidation
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer { get; set; }
        [DataMember]
        public string pn_loc { get; set; }
        [DataMember]
        public string pn_comp { get; set; }
        [DataMember]
        public string pn_vin { get; set; }
        [DataMember]
        public string pn_srvtype { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string po_omr_change { get; set; }
    }

    [DataContract]
    public class JobCardUpdate
    {
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_jc_num { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_gst_type { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }
        [DataMember]
        public string pn_sub_srv_type_cd { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string pn_promised_date { get; set; }
        [DataMember]
        public string pn_payment_mode { get; set; }
        [DataMember]
        public string pn_sa_adv { get; set; }
        [DataMember]
        public string pn_tech_adv { get; set; }
        [DataMember]
        public string pn_bay_cd { get; set; }
        [DataMember]
        public string pn_group_cd { get; set; }
        [DataMember]
        public string pn_tech_cd { get; set; }
        [DataMember]
        public string pn_waiting_cust { get; set; }
        [DataMember]
        public string pn_demand_ins_str { get; set; }
        //[DataMember]
        //public string demand_cd { get; set; }
        //[DataMember]
        //public string demand_desc { get; set; }
        //[DataMember]
        //public string demand_type { get; set; }
        //[DataMember]
        //public string problem_narr { get; set; }
        [DataMember]
        public string pn_mcard_ins_str { get; set; }
        //[DataMember]
        //public string srv_type_Cd { get; set; }
        //[DataMember]
        //public string srv_cd { get; set; }
        //[DataMember]
        //public string accept_yn { get; set; }
        //[DataMember]
        //public string accept_qty { get; set; }
        //[DataMember]
        //public string reject_Reason_cd { get; set; }
        //[DataMember]
        //public string Part_num { get; set; }
        //[DataMember]
        //public string allow_qty { get; set; }
        [DataMember]
        public string pn_labor_ins_str { get; set; }
        ////Old Property Keys
        //[DataMember]
        //public string labor_cd { get; set; }
        //[DataMember]
        //public string labor_desc { get; set; }
        //[DataMember]
        //public string labor_amt { get; set; }


        ////New Property Keys
        //    [DataMember]
        //public string Labor_cd { get; set; }
        //    [DataMember]
        //public string Labour_desc { get; set; }
        //    [DataMember]
        //public string Labour_amt { get; set; }
        //    [DataMember]
        //public string Bill_type { get; set; }
        //    [DataMember]
        //public string Disc_ind { get; set; }
        //    [DataMember]
        //public string Disc_value { get; set; }
        //[DataMember]
        //public string Split_ratio { get; set; }
        //    [DataMember]
        //public string Technician { get; set; }
        //    [DataMember]
        //public string Technician_2 { get; set; }
        //    [DataMember]
        //public string Sublet_yn { get; set; }
        //    [DataMember]
        //public string Sublet_amt { get; set; }
        //    [DataMember]
        //public string Sub_cont_cd { get; set; }
        //    [DataMember]
        //public string Cust_paid_per { get; set; }
        //    [DataMember]
        //public string Ins_paid_per { get; set; }
        //    [DataMember]
        //public string Dlr_paid_per { get; set; }
        //    [DataMember]
        //public string Oem_paid_per { get; set; }
        [DataMember]
        public string pn_part_ins_str { get; set; }
        ////Old Property Keys
        //[DataMember]
        //public string part_no { get; set; }
        //[DataMember]
        //public string part_desc { get; set; }
        //[DataMember]
        //public string issued_qty { get; set; }
        //[DataMember]
        //public string issued_bill_type { get; set; }
        //[DataMember]
        //public string part_amt { get; set; }


        ////New Property Keys
        //    [DataMember]
        //public string Part_no { get; set; }
        //    [DataMember]
        //public string Bill_type { get; set; }
        //    [DataMember]
        //public string Disc_Ind { get; set; }
        //    [DataMember]
        //public string Disc_value { get; set; }
        //[DataMember]
        //public string Bill_qty { get; set; }
        //    [DataMember]
        //public string split_ratio { get; set; }
        //    [DataMember]
        //public string Auto_depreciation { get; set; }
        //    [DataMember]
        //public string Cust_paid_per { get; set; }
        //    [DataMember]
        //public string Ins_paid_per { get; set; }
        //    [DataMember]
        //public string Dlr_paid_per { get; set; }
        //    [DataMember]
        //public string Oem_paid_per { get; set; }
        //    [DataMember]
        //public string Issue_reason { get; set; }

        [DataMember]
        public string pn_repair_ins_str { get; set; }
        //[DataMember]
        //public string Demand_Cd { get; set; }
        //[DataMember]
        //public string Problem_Cd { get; set; }
        //[DataMember]
        //public string Fault_cd { get; set; }
        //[DataMember]
        //public string Action_cd { get; set; }

        [DataMember]
        public string pn_pickup_type { get; set; }
        [DataMember]
        public string pn_pickup_date { get; set; }
        [DataMember]
        public string pn_free_pikcup_flag { get; set; }
        [DataMember]
        public string pn_pickup_loc_cd { get; set; }
        [DataMember]
        public string pn_pickup_driver { get; set; }
        [DataMember]
        public string pn_pikcup_remarks { get; set; }
        [DataMember]
        public string pn_mms_num { get; set; }
        [DataMember]
        public string pn_sch_est_part_amt { get; set; }
        [DataMember]
        public string pn_sch_est_lab_amt { get; set; }
        [DataMember]
        public string pn_dmd_est_part_amt { get; set; }
        [DataMember]
        public string pn_dmd_est_lab_amt { get; set; }
        [DataMember]
        public string pn_cust_sign { get; set; }
        [DataMember]
        public string pn_est_remarks { get; set; }
    }

    [DataContract]
    public class JobCardPreInvoicePrint
    {
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_jc_num { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string po_jc_date { get; set; }
        [DataMember]
        public string po_mileage { get; set; }
        [DataMember]
        public string po_cust_gstn { get; set; }
        [DataMember]
        public string po_dlr_gstn { get; set; }
        [DataMember]
        public string po_pos { get; set; }
        [DataMember]
        public string po_last_mileage { get; set; }
        [DataMember]
        public string po_service_type { get; set; }
        [DataMember]
        public string po_next_srv_due { get; set; }
        [DataMember]
        public string po_sa_name { get; set; }
        [DataMember]
        public string po_loyaltycard { get; set; }
        [DataMember]
        public string po_last_srv { get; set; }

        [DataMember]
        public List<JobCardPreInvoicePrint_DemandList> JobCardPreInvoicePrint_DemandList { get; set; }
        [DataMember]
        public List<JobCardPreInvoicePrint_PartList> JobCardPreInvoicePrint_PartList { get; set; }
        [DataMember]
        public List<JobCardPreInvoicePrint_LabourList> JobCardPreInvoicePrint_LabourList { get; set; }
        [DataMember]
        public List<JobCardPreInvoicePrint_BillList> JobCardPreInvoicePrint_BillList { get; set; }
    }
    [DataContract]
    public class JobCardPreInvoicePrint_DemandList
    {
        [DataMember]
        public string demand_cd { get; set; }
        [DataMember]
        public string demand_desc { get; set; }
        [DataMember]
        public string demand_type { get; set; }
        [DataMember]
        public string problem_narr { get; set; }
        [DataMember]
        public string action_desc { get; set; }
    }
    [DataContract]
    public class JobCardPreInvoicePrint_PartList
    {
        [DataMember]
        public string part_num { get; set; }
        [DataMember]
        public string part_desc { get; set; }
        [DataMember]
        public string iss_qty { get; set; }
        [DataMember]
        public string rate { get; set; }
        [DataMember]
        public string taxable_amt { get; set; }
        //[DataMember]
        //public string taxpaid_amt { get; set; }
        [DataMember]
        public string HSN_CODE { get; set; }
    }
    [DataContract]
    public class JobCardPreInvoicePrint_LabourList
    {
        [DataMember]
        public string labor_cd { get; set; }
        [DataMember]
        public string labor_desc { get; set; }
        [DataMember]
        public string labor_charges { get; set; }
        [DataMember]
        public string SAC_CODE { get; set; }
    }
    [DataContract]
    public class JobCardPreInvoicePrint_BillList
    {
        [DataMember]
        public string header { get; set; }
        [DataMember]
        public string part_charges { get; set; }
        [DataMember]
        public string labour_charges { get; set; }
    }

    [DataContract]
    public class JCClosingBillableType
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
        public string pn_jc_num { get; set; }
        [DataMember]
        public string pn_labor_Cd { get; set; }
        [DataMember]
        public string pn_bill_type_Cd { get; set; }
    }

    [DataContract]
    public class ModifyCustomerDetail
    {
        [DataMember]
        public string pn_cust_id { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_cust_mod_flag { get; set; }
        [DataMember]
        public string pn_cust_name { get; set; }
        [DataMember]
        public string pn_cust_add1 { get; set; }
        [DataMember]
        public string pn_cust_add2 { get; set; }
        [DataMember]
        public string pn_cust_add3 { get; set; }
        [DataMember]
        public string pn_city_cd { get; set; }
        [DataMember]
        public string pn_city_desc { get; set; }
        [DataMember]
        public string pn_email { get; set; }
        [DataMember]
        public string pn_email1 { get; set; }
        [DataMember]
        public string pn_phone { get; set; }
        [DataMember]
        public string pn_work_phone { get; set; }
        [DataMember]
        public string pn_mobile { get; set; }
        [DataMember]
        public string pn_dob { get; set; }
        [DataMember]
        public string pn_doa { get; set; }
    }

    [DataContract]
    public class RFTagDetail
    {
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_vin { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }

        [DataMember]
        public string po_avts_yn { get; set; }
        [DataMember]
        public string pn_rftag_no { get; set; }
        [DataMember]
        public string po_checkin_datetime { get; set; }

        //[DataMember]
        //public string PN_PARENT_GROUP { get; set; }
        //[DataMember]
        //public string PN_DEALER_CD { get; set; }
        //[DataMember]
        //public string PN_LOC_CD { get; set; }
        //[DataMember]
        //public string PN_USER_ID { get; set; }
        //[DataMember]
        //public string PN_VIN { get; set; }

        //[DataMember]
        //public string PO_AVTS_YN { get; set; }
        //[DataMember]
        //public string PO_RFTAG_NO { get; set; }
        //[DataMember]
        //public string PO_CHECKIN_DATETIME { get; set; }
    }

    [DataContract]
    public class RFTagScanTime
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_rftag_no { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }

        [DataMember]
        public string po_checkin_datetime { get; set; }

        //[DataMember]
        //public string PN_DEALER_CD { get; set; }
        //[DataMember]
        //public string PN_LOC_CD { get; set; }
        //[DataMember]
        //public string PN_USER_ID { get; set; }
        //[DataMember]
        //public string PN_RFTAG_NO { get; set; }

        //[DataMember]
        //public string PO_CHECKIN_DATETIME { get; set; }
    }
}