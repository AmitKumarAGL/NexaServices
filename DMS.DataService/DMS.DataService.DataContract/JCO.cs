using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    public class JCO
    {

    }

    [DataContract]
    public class VehicleDetails
    {
        [DataMember]
        public string po_RegNum { get; set; }
        [DataMember]
        public string po_OdometerReading { get; set; }
        [DataMember]
        public string po_ServiceType { get; set; }
        [DataMember]
        public string po_SubServiceType { get; set; }
        [DataMember]
        public string po_BayCode { get; set; }
        [DataMember]
        public string po_SA { get; set; }
        [DataMember]
        public string po_Group { get; set; }
        [DataMember]
        public string po_Technician { get; set; }
        [DataMember]
        public string po_TA { get; set; }
        [DataMember]
        public string po_VehicleID { get; set; }
        [DataMember]
        public string po_Model { get; set; }
        [DataMember]
        public string po_Chassis { get; set; }
        [DataMember]
        public string po_VariantCode { get; set; }
        [DataMember]
        public string po_Color { get; set; }
        [DataMember]
        public string po_No_Of_Vehicle_Owned { get; set; }
        [DataMember]
        public string po_RevisitStatus { get; set; }
        [DataMember]
        public string po_VIP { get; set; }
        [DataMember]
        public string po_Category { get; set; }
        [DataMember]
        public string po_TrueValue { get; set; }
        [DataMember]
        public string po_Contract { get; set; }
        [DataMember]
        public string po_ExtendedWarrentty { get; set; }
        [DataMember]
        public string po_MCP { get; set; }
        [DataMember]
        public string po_MI { get; set; }
        [DataMember]
        public string po_TechnicalCampaign { get; set; }
        [DataMember]
        public string po_SaleDate { get; set; }
        [DataMember]
        public string po_GovtVehicle { get; set; }


    }

    [DataContract]
    public class CustomerDetails
    {
        [DataMember]
        public string po_Name { get; set; }
        [DataMember]
        public string po_Address { get; set; }
        [DataMember]
        public string po_City { get; set; }
        [DataMember]
        public string po_Email { get; set; }
        [DataMember]
        public string po_Phone { get; set; }
        [DataMember]
        public string po_WorkPhone { get; set; }
        [DataMember]
        public string po_Mobile { get; set; }
        [DataMember]
        public string po_OutstandingAmt { get; set; }


    }

    [DataContract]
    public class PickupType
    {
        [DataMember]
        public string po_PickupType { get; set; }
        [DataMember]
        public string po_PickupCode { get; set; }

    }
    [DataContract]
    public class PickupLoc
    {
        [DataMember]
        public string po_Location { get; set; }
        [DataMember]
        public string po_LocCode { get; set; }

    }
    [DataContract]
    public class Drivers
    {
        [DataMember]
        public string po_DriverName { get; set; }
        [DataMember]
        public string po_Code { get; set; }

    }
    [DataContract]
    public class InventoryDetails
    {
        [DataMember]
        public string po_Inventrycd { get; set; }
        [DataMember]
        public string po_Inventrydesc { get; set; }

    }
    [DataContract]
    public class UnapproveDetails
    {
        [DataMember]
        public string po_desc { get; set; }
        [DataMember]
        public string po_cd { get; set; }

    }
    [DataContract]
    public class DemandDetails
    {
        [DataMember]
        public string po_demand_Cd { get; set; }
        [DataMember]
        public string po_demand_Desc { get; set; }

    }
    [DataContract]
    public class Labours
    {
        [DataMember]
        public string po_LabourCode { get; set; }
        [DataMember]
        public string po_pabor_desc { get; set; }
        [DataMember]
        public string po_amount { get; set; }

    }
    [DataContract]
    public class Parts
    {
        [DataMember]
        public string po_part_no { get; set; }
        [DataMember]
        public string po_currentstock { get; set; }
        [DataMember]
        public string po_price { get; set; }

    }

    [DataContract]
    public class SA
    {
        [DataMember]
        public string po_emp_Cd { get; set; }
        [DataMember]
        public string po_emp_Desc { get; set; }

    }

    [DataContract]
    public class SaveData
    {
        [DataMember]
        public string evaluationId { get; set; }
        [DataMember]
        public string dealerCode { get; set; }
        [DataMember]
        public string MSPIN { get; set; }
        [DataMember]
        public string parentGroup { get; set; }
        [DataMember]
        public string delerMapCode { get; set; }
        [DataMember]
        public string locCd { get; set; }
        [DataMember]
        public string compFa { get; set; }
        [DataMember]
        public string enquiryNo { get; set; }
        [DataMember]
        public string engionCC { get; set; }

        [DataMember]
        public DateTime DOR { get; set; }//Not send input para

        [DataMember]
        public VehicleDetails2 vehicleDetails { get; set; }

        //New Added on 09 Nov 2016
        [DataMember]
        public string p_enq_src { get; set; }
        [DataMember]
        public string p_profession { get; set; }

        // added on 15 feb 2017
        [DataMember]
        public string p_scrap_flag { get; set; }



    }

    [DataContract]
    public class VehicleDetails2
    {
        [DataMember]
        public string manufacturer { get; set; }
        [DataMember]
        public string model { get; set; }
        [DataMember]
        public string submodel { get; set; }
        [DataMember]
        public string chassisNo { get; set; }
        [DataMember]
        public string engineNo { get; set; }
        [DataMember]
        public string vinNo { get; set; }
        [DataMember]
        public string yom { get; set; }
        [DataMember]
        public string emission { get; set; }
        [DataMember]
        public string dateOfReg { get; set; }
        [DataMember]
        public string color { get; set; }
        [DataMember]
        public string vehicleRegNo { get; set; }

    }

    [DataContract]
    public class Save_Output
    {
        [DataMember]
        public string BuyingNo { get; set; }
        [DataMember]
        public string EnquiryNo { get; set; }
    }
    [DataContract]
    public class ValidateBillType
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
        public string pn_part_num { get; set; }
        [DataMember]
        public string pn_bill_type_Cd { get; set; }
    }
}
