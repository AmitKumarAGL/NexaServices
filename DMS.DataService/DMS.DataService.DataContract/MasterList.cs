using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MasterList
    {
    }

    #region for service Type

    [DataContract]

    public class ServiceTypes
    {
        [DataMember]
        public string po_ServiceTypeDesc { get; set; }
        [DataMember]
        public string po_Code { get; set; }

    }

    #endregion
    #region for Part Master Details
    [DataContract]

    public class PartList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_part_num { get; set; }

        [DataMember]
        public string part_num { get; set; }
        [DataMember]
        public string part_desc { get; set; }
        [DataMember]
        public string mrp { get; set; }
        [DataMember]
        public string stock { get; set; }

    }
    #endregion

    #region for Dealer&LocationList

    public class DealerLocationList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string parent_group { get; set; }

        [DataMember]
        public string dealer_map_cd { get; set; }
        [DataMember]
        public string loc_cd { get; set; }

        [DataMember]
        public string comp_fa { get; set; }

        [DataMember]
        public string dealer_name { get; set; }

        [DataMember]
        public string loc_desc { get; set; }
    }

    #endregion


    #region for Extended Warranty List

    public class ExtendedWarrantyList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_vin { get; set; }

        [DataMember]
        public string ew_type { get; set; }
        [DataMember]
        public string ew_type_desc { get; set; }

        [DataMember]
        public string ewr_price { get; set; }

        [DataMember]
        public string ewr_expiry_date { get; set; }

        [DataMember]
        public string ewr_expiry_mileage { get; set; }
    }

    #endregion
    #region for MCP List

    public class MCPList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]

        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_omr { get; set; }

        [DataMember]
        public string pkg_code { get; set; }

        [DataMember]
        public string pkg_desc { get; set; }

        [DataMember]
        public string mcp_start_date { get; set; }

        [DataMember]
        public string mcp_expiry_date { get; set; }

        [DataMember]
        public string price { get; set; }
    }

    #endregion
    #region for Labour Master List

    public class LabourMasterList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]

        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }

        [DataMember]
        public string veh_system { get; set; }

        [DataMember]
        public string veh_sub_system { get; set; }

        [DataMember]
        public string veh_sys_desc { get; set; }

        [DataMember]
        public string veh_sub_sys_desc { get; set; }

        [DataMember]
        public string opr_cd { get; set; }

        [DataMember]
        public string opr_desc { get; set; }
        [DataMember]
        public string frm_hrs { get; set; }
        [DataMember]
        public string fixed_amt { get; set; }

    }

    #endregion

    #region for Pickup Type List
    public class PickupTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pickup_code { get; set; }
        [DataMember]
        public string pickup_desc { get; set; }
    }
    #endregion

    #region for UnApprovedFitmentsList
    public class UnApprovedFitmentsList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string apprv_fit_code { get; set; }
        [DataMember]
        public string apprv_fit_desc { get; set; }
    }
    #endregion

    #region for DemandRepairsList
    public class DemandRepairsList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string demand_cd { get; set; }
        [DataMember]
        public string demand_desc { get; set; }
        [DataMember]
        public string service_type { get; set; }
        [DataMember]
        public string pop_yn { get; set; }
    }
    #endregion

    #region for ServiceTypeList
    public class ServiceTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
    }
    #endregion

    #region for BillableTypeList
    public class BillableTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string bill_type { get; set; }
        [DataMember]
        public string bill_type_desc { get; set; }
    }
    #endregion

    #region for ProblemCodeList
    public class ProblemCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string problem_desc { get; set; }
    }
    #endregion

    #region for FaultCodeList
    public class FaultCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string fault_cd { get; set; }
        [DataMember]
        public string fault_desc { get; set; }
    }
    #endregion

    #region for ActionCodeList
    public class ActionCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string fault_cd { get; set; }
        [DataMember]
        public string action_cd { get; set; }
        [DataMember]
        public string action_desc { get; set; }
    }
    #endregion

    #region for CSIReasonList
    public class CSIReasonList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string csi_cd { get; set; }
        [DataMember]
        public string csi_desc { get; set; }
    }
    #endregion

    #region for DelayReasonsClosingList
    public class DelayReasonsClosingList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string delay_cd { get; set; }
        [DataMember]
        public string delay_desc { get; set; }
    }
    #endregion

    #region for DelayReasonsBillingList
    public class DelayReasonsBillingList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string delay_cd { get; set; }
        [DataMember]
        public string delay_desc { get; set; }
    }
    #endregion

    #region for PaymentModeList
    public class PaymentModeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pay_mode_cd { get; set; }
        [DataMember]
        public string pay_mode_desc { get; set; }
    }
    #endregion

    #region for ReportedByList
    public class ReportedByList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string rep_by_cd { get; set; }
        [DataMember]
        public string rep_by_desc { get; set; }
    }
    #endregion

    #region for PickUpLocationList
    public class PickUpLocationList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string area_cd { get; set; }
        [DataMember]
        public string area_desc { get; set; }
    }
    #endregion

    #region for MobileServiceMMSList
    public class MobileServiceMMSList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string mms_num { get; set; }
    }
    #endregion

    #region for DriveEmployeeList
    public class DriveEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for BayCodeList
    public class BayCodeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string bay_type { get; set; }
        [DataMember]
        public string bay_desc { get; set; }
        [DataMember]
        public string bay_cd { get; set; }
    }
    #endregion

    #region for ServiceAdvisorEmployeeList
    public class ServiceAdvisorEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }

        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
        [DataMember]
        public string dms_user_id { get; set; }
    }
    #endregion

    #region for TechnicalAdvisorEmployeeList
    public class TechnicalAdvisorEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for GroupList
    public class GroupList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string group_cd { get; set; }
        [DataMember]
        public string group_name { get; set; }
    }
    #endregion

    #region for TechnicianEmployeeList
    public class TechnicianEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string group_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for InventoryList
    public class InventoryList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string inventory_cd { get; set; }
        [DataMember]
        public string inventory_desc { get; set; }
    }
    #endregion

    #region for AuthorizedPersonForDiscountList
    public class AuthorizedPersonForDiscountList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for SplitRatioListOnlyForParts
    public class SplitRatioListOnlyForParts
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string split_cd { get; set; }
        [DataMember]
        public string split_desc { get; set; }
        [DataMember]
        public string cust_per { get; set; }
        [DataMember]
        public string ins_per { get; set; }
        [DataMember]
        public string dlr_per { get; set; }
        [DataMember]
        public string oem_per { get; set; }
    }
    #endregion

    #region for ServiceMenuCardList
    public class ServiceMenuCardList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string po_sub_srv_cd { get; set; }
        [DataMember]
        public string po_sub_srv_desc { get; set; }
        [DataMember]
        public string srv_type_cd { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
        [DataMember]
        public string srv_cd { get; set; }
        [DataMember]
        public string srv_desc { get; set; }
        [DataMember]
        public string srv_qty { get; set; }
        [DataMember]
        public string grp_cd { get; set; }
        [DataMember]
        public string rate { get; set; }
    }
    #endregion
}