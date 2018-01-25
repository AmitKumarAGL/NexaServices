using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MonitoringScreens
    {
    }
    [DataContract]
    public class MonitoringScreenBayDetail
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
        public string pn_bay_start_date { get; set; }
        [DataMember]
        public string bay_desc { get; set; }
        [DataMember]
        public string worked_before_time_cnt { get; set; }
        [DataMember]
        public string worked_after_time_cnt { get; set; }
        [DataMember]
        public string total_labor_revenue { get; set; }
        [DataMember]
        public string max_potional_labor_revenue { get; set; }
        [DataMember]
        public string per_potional_utilized { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string est_time_for_completion { get; set; }
        [DataMember]
        public string time_left_delay_completion { get; set; }
        [DataMember]
        public string Workshop_working_time { get; set; }
        [DataMember]
        public string BaySuspended_status { get; set; }
        [DataMember]
        public string BayOntimeStatus { get; set; }
        [DataMember]
        public string WorkDelayed_Status { get; set; }

        [DataMember]
        public string BAY_ALLOCATION_DATETIME { get; set; }

        [DataMember]
        public string bay_in_time { get; set; }
        [DataMember]
        public string bay_status_cd { get; set; }
    }

    [DataContract]
    public class QMMonitoringJobCard
    {
        //[DataMember]
        //public string SNo { get; set; }
        [DataMember]
        public string Cluster { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_date { get; set; }
        [DataMember]
        public string APPOINTMENT_TYPE { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string JOB_CARD_NUM { get; set; }
        [DataMember]
        public string SRV_TYPE { get; set; }
        [DataMember]
        public string MODEL { get; set; }
        [DataMember]
        public string SRV_ADV_CD { get; set; }
        [DataMember]
        public string SRV_SDV_NAME { get; set; }
        [DataMember]
        public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPEN_DATE { get; set; }
        [DataMember]
        public string PROM_DATE { get; set; }
        [DataMember]
        public string JC_CLOSE_DATE { get; set; }
        [DataMember]
        public string JC_BILL_DATE { get; set; }
        [DataMember]
        public string GATE_OUT_TIME { get; set; }
        [DataMember]
        public string STAGE { get; set; }
        [DataMember]
        public string TIME_IN_STAGE { get; set; }
        [DataMember]
        public string DELAY_REASON { get; set; }
        [DataMember]
        public string WAITING_YN { get; set; }
        [DataMember]
        public string ONLINE_PAYMENT_FLAG { get; set; }


        [DataMember]
        public string VehBilledWithin4HoursCounts { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursPerc { get; set; }
        [DataMember]
        public string VehLess1HourRemainAsPromiseCounts { get; set; }
        [DataMember]
        public string customerWaitInLoungeCounts { get; set; }
        [DataMember]
        public string onlinePaymentsCounts { get; set; }

        //[DataMember]
        //public string Target_service_load_for_today { get; set; }
        //[DataMember]
        //public string Jobcards_opened_today { get; set; }
        //[DataMember]
        //public string Carryover_jobcards { get; set; }
        //[DataMember]
        //public string Jobcards_billed_today { get; set; }
    }
    public class QMClusterMonitoringJobCardResult
    {
        [DataMember]
        public List<QMClusterMonitoringJobCard> ClusterData { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursCounts { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursPerc { get; set; }
        [DataMember]
        public string VehLess1HourRemainAsPromiseCounts { get; set; }
        [DataMember]
        public string customerWaitInLoungeCounts { get; set; }
        [DataMember]
        public string onlinePaymentsCounts { get; set; }

        [DataMember]
        public string Target_service_load_for_today { get; set; }
        [DataMember]
        public string Jobcards_opened_today { get; set; }
        [DataMember]
        public string Carryover_jobcards { get; set; }
        [DataMember]
        public string Jobcards_billed_today { get; set; }

        //Stage Details
        [DataMember]
        public string Gate_In_Counts { get; set; }
        [DataMember]
        public string Gate_Out_Counts { get; set; }
        [DataMember]
        public string ShopFloor_In_Counts { get; set; }
        [DataMember]
        public string ShopFloor_Out_Counts { get; set; }
        [DataMember]
        public string BayAllocated_In_Counts { get; set; }
        [DataMember]
        public string BayAllocated_Out_Counts { get; set; }
        [DataMember]
        public string FinalWashing_In_Counts { get; set; }
        [DataMember]
        public string FinalWashing_Out_Counts { get; set; }
        [DataMember]
        public string FinalInspection_In_Counts { get; set; }
        [DataMember]
        public string FinalInspection_Out_Counts { get; set; }
        [DataMember]
        public string TesterLine_In_Counts { get; set; }
        [DataMember]
        public string TesterLine_Out_Counts { get; set; }
    }

    public class QMClusterMonitoringJobCard
    {
        [DataMember]
        public string Cluster { get; set; }
        [DataMember]
        public string ItemCount { get; set; }
        [DataMember]
        public List<QMMonitoringJobCard> ClusterDetails { get; set; }
    }
    [DataContract]
    public class MonitoringVehicleStuckUpDetail
    {
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_date { get; set; }

        [DataMember]
        public string model_desc { get; set; }
        [DataMember]
        public string Reg_num { get; set; }
        [DataMember]
        public string JC_No { get; set; }
        [DataMember]
        public string rcateg_desc { get; set; }
        [DataMember]
        public string JC_open_datetime { get; set; }
        [DataMember]
        public string Revised_promise_dateTime { get; set; }
        [DataMember]
        public string Stuck_Up_datetime { get; set; }
        [DataMember]
        public string Stuck_Time { get; set; }
        [DataMember]
        public string Reason_for_StuckUp { get; set; }
    }
    [DataContract]
    public class WalkinCustomerVehInfo
    {
        [DataMember]
        public string pn_rfid_num { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }

        [DataMember]
        public string po_reg_num { get; set; }
        [DataMember]
        public string po_cust_name { get; set; }
        [DataMember]
        public string po_cust_mobile { get; set; }
    }

    [DataContract]
    public class QMMonitoringJobCardStageWiseDetails
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
        public string pn_date { get; set; }
        [DataMember]
        public string RO_NUM { get; set; }
        [DataMember]
        public string STAGE_ID { get; set; }
        [DataMember]
        public string STAGE_DESC { get; set; }
        [DataMember]
        public string BAY_FLAG { get; set; }
        [DataMember]
        public string STAGE_IN_TIME { get; set; }
        [DataMember]
        public string STAGE_OUT_TIME { get; set; }
    }

    [DataContract]
    public class VTSStageDetails
    {
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_date { get; set; }


        [DataMember]
        public string STAGE_ID { get; set; }
        [DataMember]
        public string STAGE_DESC { get; set; }
        [DataMember]
        public string IN_CNT { get; set; }
        [DataMember]
        public string OUT_CNT { get; set; }
    }

    #region cluster related
    public class QMClusterMonitoringJobCardsResult
    {
        [DataMember]
        public List<QMClusterMonitoringJobCards> ClusterData { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursCounts { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursPerc { get; set; }
        [DataMember]
        public string VehLess1HourRemainAsPromiseCounts { get; set; }
        [DataMember]
        public string customerWaitInLoungeCounts { get; set; }
        [DataMember]
        public string onlinePaymentsCounts { get; set; }

        [DataMember]
        public string Target_service_load_for_today { get; set; }
        [DataMember]
        public string Jobcards_opened_today { get; set; }
        [DataMember]
        public string Carryover_jobcards { get; set; }
        [DataMember]
        public string Jobcards_billed_today { get; set; }

        //Stage Details
        [DataMember]
        public string Gate_In_Counts { get; set; }
        [DataMember]
        public string Gate_Out_Counts { get; set; }
        [DataMember]
        public string UnderBodyWashing_In_Counts { get; set; }
        [DataMember]
        public string UnderBodyWashing_Out_Counts { get; set; }
        [DataMember]
        public string ShopFloor_In_Counts { get; set; }
        [DataMember]
        public string ShopFloor_Out_Counts { get; set; }
        [DataMember]
        public string BayAllocated_In_Counts { get; set; }
        [DataMember]
        public string BayAllocated_Out_Counts { get; set; }
        [DataMember]
        public string FinalWashing_In_Counts { get; set; }
        [DataMember]
        public string FinalWashing_Out_Counts { get; set; }
        [DataMember]
        public string FinalInspection_In_Counts { get; set; }
        [DataMember]
        public string FinalInspection_Out_Counts { get; set; }
        [DataMember]
        public string TesterLine_In_Counts { get; set; }
        [DataMember]
        public string TesterLine_Out_Counts { get; set; }
    }
    public class QMClusterMonitoringJobCards
    {
        [DataMember]
        public string Cluster { get; set; }
        [DataMember]
        public string ItemCount { get; set; }
        [DataMember]
        public List<QMMonitoringJobCards> ClusterDetails { get; set; }
    }
    [DataContract]
    public class QMMonitoringJobCards
    {
        //[DataMember]
        //public string SNo { get; set; }
        [DataMember]
        public string Cluster { get; set; }
        [DataMember]
        public string BayStatusFlag { get; set; }
        [DataMember]
        public string pn_parent_group { get; set; }
        [DataMember]
        public string pn_dealer_map_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }
        [DataMember]
        public string pn_comp_fa { get; set; }
        [DataMember]
        public string pn_date { get; set; }
        [DataMember]
        public string APPOINTMENT_TYPE { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string JOB_CARD_NUM { get; set; }
        [DataMember]
        public string SRV_TYPE { get; set; }
        [DataMember]
        public string MODEL { get; set; }
        [DataMember]
        public string SRV_ADV_CD { get; set; }
        [DataMember]
        public string SRV_SDV_NAME { get; set; }
        [DataMember]
        public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPEN_DATE { get; set; }
        [DataMember]
        public string PROM_DATE { get; set; }
        [DataMember]
        public string JC_CLOSE_DATE { get; set; }
        [DataMember]
        public string JC_BILL_DATE { get; set; }
        [DataMember]
        public string GATE_OUT_TIME { get; set; }
        [DataMember]
        public string STAGE { get; set; }
        [DataMember]
        public string TIME_IN_STAGE { get; set; }
        [DataMember]
        public string DELAY_REASON { get; set; }
        [DataMember]
        public string WAITING_YN { get; set; }
        [DataMember]
        public string ONLINE_PAYMENT_FLAG { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursCounts { get; set; }
        [DataMember]
        public string VehBilledWithin4HoursPerc { get; set; }
        [DataMember]
        public string VehLess1HourRemainAsPromiseCounts { get; set; }
        [DataMember]
        public string customerWaitInLoungeCounts { get; set; }
        [DataMember]
        public string onlinePaymentsCounts { get; set; }

        //QMMonitoringJobCardStageWiseDetails
        [DataMember]
        public string RO_NUM { get; set; }
        [DataMember]
        public string STAGE_ID { get; set; }
        [DataMember]
        public string STAGE_DESC { get; set; }
        [DataMember]
        public string BAY_FLAG { get; set; }
        [DataMember]
        public string STAGE_IN_TIME { get; set; }
        [DataMember]
        public string STAGE_OUT_TIME { get; set; }
        [DataMember]
        public string STAGE_TIME_REVISED { get; set; }
    }

    [DataContract]
    public class QMMonitoringJobCardOnly
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
        public string pn_date { get; set; }


        [DataMember]
        public string APPOINTMENT_TYPE { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string JOB_CARD_NUM { get; set; }
        [DataMember]
        public string SRV_TYPE { get; set; }
        [DataMember]
        public string MODEL { get; set; }
        [DataMember]
        public string SRV_ADV_CD { get; set; }
        [DataMember]
        public string SRV_SDV_NAME { get; set; }
        [DataMember]
        public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPEN_DATE { get; set; }
        [DataMember]
        public string PROM_DATE { get; set; }
        [DataMember]
        public string JC_CLOSE_DATE { get; set; }
        [DataMember]
        public string JC_BILL_DATE { get; set; }
        [DataMember]
        public string GATE_OUT_TIME { get; set; }
        [DataMember]
        public string STAGE { get; set; }
        [DataMember]
        public string TIME_IN_STAGE { get; set; }
        [DataMember]
        public string DELAY_REASON { get; set; }
        [DataMember]
        public string WAITING_YN { get; set; }
        [DataMember]
        public string ONLINE_PAYMENT_FLAG { get; set; }
    }
    #endregion
}