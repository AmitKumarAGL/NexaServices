using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class VehicleHistory
    {
    }
    [DataContract]
    public class JobCardListOfVehicle
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string dealer_code { get; set; }
        [DataMember]
        public string dealer_name { get; set; }
        [DataMember]
        public string service_date { get; set; }
        [DataMember]
        public string service_type { get; set; }
        [DataMember]
        public string model { get; set; }
        [DataMember]
        public string mileage { get; set; }
        [DataMember]
        public string job_card_date { get; set; }
        [DataMember]
        public string job_card_num { get; set; }
        [DataMember]
        public string bill_date { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string technician_name { get; set; }
        [DataMember]
        public string psf_status { get; set; }
        [DataMember]
        public string remarks { get; set; }
        [DataMember]
        public string unapproved_fitness { get; set; }
        [DataMember]
        public string labour_amt { get; set; }
        [DataMember]
        public string part_amt { get; set; }
        [DataMember]
        public string tot_amt { get; set; }
        [DataMember]
        public string est_labour_amt { get; set; }
        [DataMember]
        public string est_part_amt { get; set; }
        [DataMember]
        public string tot_est_amt { get; set; }
        [DataMember]
        public string attend_through { get; set; }
        [DataMember]
        public string csi_per { get; set; }
        [DataMember]
        public string satisfied_yn { get; set; }
    }
    [DataContract]
    public class JobCardDetailsAccordingToJobCardInputs
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_ro_num { get; set; }
    }
    [DataContract]
    public class JobCardDetailsAccordingToJobCard
    {
        [DataMember]
        public List<VehicleFollowHistory> vehicleFollowHistoryLists { get; set; }
        [DataMember]
        public List<VehiclePartHistory> vehiclePartHistoryLists { get; set; }
        [DataMember]
        public List<VehicleLaborHistory> vehicleLaborHistoryLists { get; set; }
        [DataMember]
        public List<VehicleDemandRepairsHistory> vehicleDemandRepairsHistoryLists { get; set; }
    }
    [DataContract]
    public class VehicleFollowHistory
    {
        [DataMember]
        public string psf_num { get; set; }
        [DataMember]
        public string psf_date { get; set; }
        [DataMember]
        public string psf_by { get; set; }
        [DataMember]
        public string remarks { get; set; }
        [DataMember]
        public string satisfied_yn { get; set; }
        [DataMember]
        public string response { get; set; }
    }
    [DataContract]
    public class VehiclePartHistory
    {
        [DataMember]
        public string part_num { get; set; }
        [DataMember]
        public string part_desc { get; set; }
        [DataMember]
        public string iss_qty { get; set; }
        [DataMember]
        public string part_amt { get; set; }
        [DataMember]
        public string billable_type { get; set; }
    }
    [DataContract]
    public class VehicleLaborHistory
    {
        [DataMember]
        public string opr_cd { get; set; }
        [DataMember]
        public string opr_desc { get; set; }
        [DataMember]
        public string opr_amt { get; set; }
        [DataMember]
        public string billable_type { get; set; }
    }
    [DataContract]
    public class VehicleDemandRepairsHistory
    {
        [DataMember]
        public string demand_cd { get; set; }
        [DataMember]
        public string demand_desc { get; set; }
        [DataMember]
        public string customer_voice { get; set; }
    }


    [DataContract]
    public class VehicleStatusDisplay
    {
        [DataMember]
        public string p_group { get; set; }
        [DataMember]
        public string d_mapcd { get; set; }
        [DataMember]
        public string l_code { get; set; }
        [DataMember]
        public string vsd_flag { get; set; }

        [DataMember]
        public List<VehicleStatusDisplay_List> VehicleStatusDisplay_List { get; set; }
    }
    [DataContract]
    public class VehicleStatusDisplay_List
    {
        [DataMember]
        public string REG_NO { get; set; }
        [DataMember]
        public string CUST_NAME { get; set; }
        [DataMember]
        public string PROMISED_TIME { get; set; }
        [DataMember]
        public string REV_PROMISED_TIME { get; set; }
        [DataMember]
        public string WIP { get; set; }
        [DataMember]
        public string FI { get; set; }
        [DataMember]
        public string WASHING { get; set; }
        [DataMember]
        public string READY_FOR_DELV { get; set; }
        [DataMember]
        public string STATUS { get; set; }
        [DataMember]
        public string SRV_ADV { get; set; }
        [DataMember]
        public string JC_NO { get; set; }
    }
}
