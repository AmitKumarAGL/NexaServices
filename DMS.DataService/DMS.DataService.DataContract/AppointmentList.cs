using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class AppointmentList
    {

    }

    [DataContract]
    public class AppointmentTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string type_cd { get; set; }
        [DataMember]
        public string type_desc { get; set; }
    }

    [DataContract]
    public class AppointmentSlotList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string slot_cd { get; set; }
        [DataMember]
        public string slot_desc { get; set; }
    }

    [DataContract]
    public class AppointmentSlotTimeList
    {
        [DataMember]
        public string pn_pmc { get; set; }

        [DataMember]
        public string slot_cd { get; set; }
        [DataMember]
        public string time_desc { get; set; }

    }

    [DataContract]
    public class AppointmentPrePostPoneList
    {
        [DataMember]
        public string pn_pmc { get; set; }

        [DataMember]
        public string list_code { get; set; }
        [DataMember]
        public string list_desc { get; set; }
    }

    [DataContract]
    public class AppointmentCancelReasonList
    {
        [DataMember]
        public string pn_pmc { get; set; }

        [DataMember]
        public string reason_cd { get; set; }
        [DataMember]
        public string reason_desc { get; set; }
    }

    [DataContract]
    public class AppointmentVehicleDetails
    {
        [DataMember]
        public string pn_reg_num { get; set; }

        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string po_reg_num { get; set; }

        [DataMember]
        public string po_cust_id { get; set; }
        [DataMember]
        public string po_mobile { get; set; }
        [DataMember]
        public string po_cust_name { get; set; }
        [DataMember]
        public string po_cust_add { get; set; }
        [DataMember]
        public string po_vehiclemodel { get; set; }
        [DataMember]
        public string po_city { get; set; }
        [DataMember]
        public string po_state { get; set; }
        [DataMember]
        public string po_cust_contact_num { get; set; }
        [DataMember]
        public string po_email { get; set; }
        [DataMember]
        public string po_vin { get; set; }
        [DataMember]
        public string po_variant { get; set; }
        [DataMember]
        public string po_color { get; set; }
        [DataMember]
        public string po_cust_category { get; set; }
        [DataMember]
        public string po_last_sa_attnd { get; set; }

    }

    [DataContract]
    public class GenerateAppointment
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }

        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_odometer { get; set; }
        [DataMember]
        public string pn_srvtype_cd { get; set; }
        [DataMember]
        public string pn_appnt_type { get; set; }
        [DataMember]
        public string pn_appnt_date { get; set; }
        [DataMember]
        public string pn_currentsa_cd { get; set; }

        [DataMember]
        public string pn_slot_cd { get; set; }

        [DataMember]
        public string pn_slottime_cd { get; set; }

        [DataMember]
        public string pn_pickuptype { get; set; }

        [DataMember]
        public string pn_pickuploc { get; set; }

        [DataMember]
        public string pn_pickuptime { get; set; }

        [DataMember]
        public string pn_pickupaddr { get; set; }
        [DataMember]
        public string pn_droploc { get; set; }

        [DataMember]
        public string pn_droptime { get; set; }
        [DataMember]
        public string pn_dropaddr { get; set; }
        [DataMember]
        public string pn_driver { get; set; }

        [DataMember]
        public string pn_vehicleno { get; set; }

        [DataMember]
        public string pn_pickupremarks { get; set; }
        [DataMember]
        public string pn_remark_non_prev_sa { get; set; }

        [DataMember]
        public string po_appnt_no { get; set; }

    }

    [DataContract]
    public class UpdateAppointmentdetailasperAppointmentno
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_appnt_no { get; set; }
        [DataMember]
        public string pn_prepone_type { get; set; }
        [DataMember]
        public string pn_prepone_date { get; set; }

        [DataMember]
        public string pn_odometer { get; set; }
        [DataMember]
        public string pn_srvtype { get; set; }
        [DataMember]
        public string pn_current_sa { get; set; }

        [DataMember]
        public string pn_appnt_type { get; set; }
        [DataMember]
        public string pn_slot { get; set; }
        [DataMember]
        public string pn_slot_time { get; set; }
        [DataMember]
        public string pn_pickuptype { get; set; }

        [DataMember]
        public string pn_pickuploc { get; set; }
        [DataMember]
        public string pn_pickuptime { get; set; }

        [DataMember]
        public string pn_pickupaddr { get; set; }

        [DataMember]
        public string pn_droploc { get; set; }

        [DataMember]
        public string pn_droptime { get; set; }


        [DataMember]
        public string pn_dropaddr { get; set; }


        [DataMember]
        public string pn_driver { get; set; }

        [DataMember]
        public string pn_vehicleno { get; set; }

        [DataMember]
        public string pn_pickupremarks { get; set; }

        [DataMember]
        public string pn_remark_notselect_sa { get; set; }
    }

    [DataContract]
    public class AppointmentCancel
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_appnt_no { get; set; }

        [DataMember]
        public string pn_cancel_reason { get; set; }

    }


    [DataContract]
    public class AppointmentListAccordingToDateRange
    {
        [DataMember]
        public List<AppointmentDayWiseList> dayWiseLists { get; set; }
        [DataMember]
        public List<WeekList> weekWiselists { get; set; }
        [DataMember]
        public List<MonthList> monthWiselists { get; set; }
        [DataMember]
        public List<SAList> saWiselists { get; set; }
    }

    [DataContract]
    public class AppointmentDayWiseList
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_from_date { get; set; }
        [DataMember]
        public string pn_to_date { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string time_slot { get; set; }
        [DataMember]
        public string srv_type_cd { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
        [DataMember]
        public string vechilemodel { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string appnt_num { get; set; }
        [DataMember]
        public string appnt_for_dt { get; set; }
        [DataMember]
        public string odometer_reading { get; set; }
        [DataMember]
        public string confirmed_yn { get; set; }
        [DataMember]
        public string jc_num { get; set; }

        [DataMember]
        public string booking_slot_time { get; set; }

        [DataMember]
        public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPENDATETIME { get; set; }


        //[DataMember]
        //public string appoinment_number { get; set; }
        //[DataMember]
        //public string appoinment_status { get; set; }
        //[DataMember]
        //public string registration_number { get; set; }
        //[DataMember]
        //public string rfid_number { get; set; }
        //[DataMember]
        //public bool Status { get; set; }
        //[DataMember]
        //public string BoomOpenDateTime { get; set; }
        //[DataMember]
        //public string TimeOfArrival { get; set; }
        //[DataMember]
        //public string JobCardStatus { get; set; }
        //[DataMember]
        //public string CarCurrentStatus { get; set; }
        //[DataMember]
        //public string JobCardOpenDateTime { get; set; }
        //[DataMember]
        //public string JobCardCloseDateTime { get; set; }
    }

    [DataContract]
    public class WeekList
    {
        [DataMember]
        public List<WeekListDayName> weekWiselistDayNames { get; set; }
    }
    [DataContract]
    public class WeekListDayName
    {
        [DataMember]
        public List<WeekListTimeSlot> weekWiselistTimeSlots { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class WeekListTimeSlot
    {
        [DataMember]
        public List<WeekListCounts> weekWiselistCounts { get; set; }

        [DataMember]
        public string TimeSlots { get; set; }
    }
    [DataContract]
    public class WeekListCounts
    {
        [DataMember]
        public string AllRecCount { get; set; }
        [DataMember]
        public string ReportedCount { get; set; }
        [DataMember]
        public string AppointedCount { get; set; }
    }

    [DataContract]
    public class MonthList
    {
        [DataMember]
        public List<MonthListDayName> monthWiselistDayNames { get; set; }
    }
    [DataContract]
    public class MonthListDayName
    {
        [DataMember]
        public List<MonthListCounts> monthWiselistCounts { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class MonthListCounts
    {
        [DataMember]
        public string AllRecCount { get; set; }
        [DataMember]
        public string ReportedCount { get; set; }
        [DataMember]
        public string AppointedCount { get; set; }
    }


    [DataContract]
    public class SAList
    {
        [DataMember]
        public List<SAListDayName> saWiselistDayNames { get; set; }
    }
    [DataContract]
    public class SAListDayName
    {
        [DataMember]
        public List<SADetails> saWiseDetails { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class SADetails
    {
        [DataMember]
        public string SA_pn_user_id { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string SAAllAppointRecCounts { get; set; }
    }

    [DataContract]
    public class AppointmentDetails
    {
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_appnt_no { get; set; }
        [DataMember]
        public string po_srvtype_cd { get; set; }
        [DataMember]
        public string po_odometer { get; set; }
        [DataMember]
        public string po_pickuptype { get; set; }
        [DataMember]
        public string po_pickuploc { get; set; }
        [DataMember]
        public string po_pickupaddress { get; set; }
        [DataMember]
        public string po_pickupdate { get; set; }
        [DataMember]
        public string po_drivername { get; set; }
        [DataMember]
        public string po_pickupremarks { get; set; }
        [DataMember]
        public string po_droploc { get; set; }
        [DataMember]
        public string po_dropaddress { get; set; }
        [DataMember]
        public string po_dropdate { get; set; }
    }

    [DataContract]
    public class AppointmentListAccordingToDateRange_WithMonitoring
    {
        [DataMember]
        public List<AppointmentDayWiseList_WithMonitoring> dayWiseLists { get; set; }
        [DataMember]
        public List<WeekList_WithMonitoring> weekWiselists { get; set; }
        [DataMember]
        public List<MonthList_WithMonitoring> monthWiselists { get; set; }
        [DataMember]
        public List<SAList_WithMonitoring> saWiselists { get; set; }
    }
    [DataContract]
    public class AppointmentDayWiseList_WithMonitoring
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string pn_from_date { get; set; }
        [DataMember]
        public string pn_to_date { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string time_slot { get; set; }
        [DataMember]
        public string srv_type_cd { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
        [DataMember]
        public string vechilemodel { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string appnt_num { get; set; }
        [DataMember]
        public string appnt_for_dt { get; set; }
        [DataMember]
        public string odometer_reading { get; set; }
        [DataMember]
        public string confirmed_yn { get; set; }
        [DataMember]
        public string jc_num { get; set; }

        [DataMember]
        public string booking_slot_time { get; set; }

        [DataMember]
        public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPENDATETIME { get; set; }


        //[DataMember]
        //public string appoinment_number { get; set; }
        //[DataMember]
        //public string appoinment_status { get; set; }
        //[DataMember]
        //public string registration_number { get; set; }
        //[DataMember]
        //public string rfid_number { get; set; }
        //[DataMember]
        //public bool Status { get; set; }
        //[DataMember]
        //public string BoomOpenDateTime { get; set; }
        //[DataMember]
        //public string TimeOfArrival { get; set; }
        //[DataMember]
        //public string JobCardStatus { get; set; }
        //[DataMember]
        //public string CarCurrentStatus { get; set; }
        //[DataMember]
        //public string JobCardOpenDateTime { get; set; }
        //[DataMember]
        //public string JobCardCloseDateTime { get; set; }


        //[DataMember]
        //public string GATE_IN_TIME { get; set; }
        [DataMember]
        public string JC_OPEN_DATE { get; set; }
        [DataMember]
        public string JC_CLOSE_DATE { get; set; }
    }
    [DataContract]
    public class WeekList_WithMonitoring
    {
        [DataMember]
        public List<WeekListDayName_WithMonitoring> weekWiselistDayNames { get; set; }
    }
    [DataContract]
    public class WeekListDayName_WithMonitoring
    {
        [DataMember]
        public List<WeekListTimeSlot_WithMonitoring> weekWiselistTimeSlots { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class WeekListTimeSlot_WithMonitoring
    {
        [DataMember]
        public List<WeekListCounts_WithMonitoring> weekWiselistCounts { get; set; }

        [DataMember]
        public string TimeSlots { get; set; }
    }
    [DataContract]
    public class WeekListCounts_WithMonitoring
    {
        [DataMember]
        public string AllRecCount { get; set; }
        [DataMember]
        public string ReportedCount { get; set; }
        [DataMember]
        public string AppointedCount { get; set; }
    }
    [DataContract]
    public class MonthList_WithMonitoring
    {
        [DataMember]
        public List<MonthListDayName_WithMonitoring> monthWiselistDayNames { get; set; }
    }
    [DataContract]
    public class MonthListDayName_WithMonitoring
    {
        [DataMember]
        public List<MonthListCounts_WithMonitoring> monthWiselistCounts { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class MonthListCounts_WithMonitoring
    {
        [DataMember]
        public string AllRecCount { get; set; }
        [DataMember]
        public string ReportedCount { get; set; }
        [DataMember]
        public string AppointedCount { get; set; }
    }
    [DataContract]
    public class SAList_WithMonitoring
    {
        [DataMember]
        public List<SAListDayName_WithMonitoring> saWiselistDayNames { get; set; }
    }
    [DataContract]
    public class SAListDayName_WithMonitoring
    {
        [DataMember]
        public List<SADetails_WithMonitoring> saWiseDetails { get; set; }

        [DataMember]
        public string DayNames { get; set; }
    }
    [DataContract]
    public class SADetails_WithMonitoring
    {
        [DataMember]
        public string SA_pn_user_id { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string SAAllAppointRecCounts { get; set; }
    }
}