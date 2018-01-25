using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class DashboardSA
    {
    }

    [DataContract]
    public class SADashboardOnlyForCurrentDate
    {
        [DataMember]
        public List<AppointmentDetail> appointmentDetailLists { get; set; }
        [DataMember]
        public List<CallDetail> callDetailLists { get; set; }
        [DataMember]
        public List<JobCardDetail> jobCardDetailLists { get; set; }
        [DataMember]
        public List<PickDropDetail> pickdropDetailLists { get; set; }

        [DataMember]
        public string introduction_Generated_Count { get; set; }
        [DataMember]
        public string introduction_Close_Count { get; set; }
        [DataMember]
        public string introduction_Open_Count { get; set; }

        [DataMember]
        public string welcome_Generated_Count { get; set; }
        [DataMember]
        public string welcome_Close_Count { get; set; }
        [DataMember]
        public string welcome_Open_Count { get; set; }

        [DataMember]
        public string smr_Generated_Count { get; set; }
        [DataMember]
        public string smr_Close_Count { get; set; }
        [DataMember]
        public string smr_Open_Count { get; set; }

        [DataMember]
        public string psf_Generated_Count { get; set; }
        [DataMember]
        public string psf_Close_Count { get; set; }
        [DataMember]
        public string psf_Open_Count { get; set; }

        [DataMember]
        public string myAppointments_Appointed_Count { get; set; }
        [DataMember]
        public string myAppointments_Reported_Count { get; set; }
        [DataMember]
        public string myAppointments_Pending_Count { get; set; }

        [DataMember]
        public string myJobCards_Opened_Count { get; set; }
        [DataMember]
        public string myJobCards_Closed_Count { get; set; }
        [DataMember]
        public string myJobCards_SameDayDelivery_Count { get; set; }
    }

    [DataContract]
    public class SADashboardOnlyForCurrentDateInputs
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
    }

    [DataContract]
    public class AppointmentDetail
    {
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string time_slot { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string vechilemodel { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }
        [DataMember]
        public string appnt_num { get; set; }
        [DataMember]
        public string confirmed_yn { get; set; }
        [DataMember]
        public string jc_num { get; set; }

        [DataMember]
        public string odometer_reading { get; set; }
    }
    [DataContract]
    public class CallDetail
    {
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string sale_date { get; set; }
        [DataMember]
        public string vehiclemodel { get; set; }
        [DataMember]
        public string call_type { get; set; }
        [DataMember]
        public string call_status { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string emailid { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string follow_status { get; set; }
    }
    [DataContract]
    public class JobCardDetail
    {
        [DataMember]
        public string jc_num { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string reg_num { get; set; }
        [DataMember]
        public string jc_date { get; set; }
        [DataMember]
        public string promise_datetime { get; set; }
        [DataMember]
        public string jc_status { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string vechilemodel { get; set; }
        [DataMember]
        public string contact_no { get; set; }
        [DataMember]
        public string emailid { get; set; }
        [DataMember]
        public string vin { get; set; }
        [DataMember]
        public string revised_datetime { get; set; }
        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }

        [DataMember]
        public string jc_close_date { get; set; }

        [DataMember]
        public string waiting_yn { get; set; }
        [DataMember]
        public string Pickup_Type { get; set; }
        [DataMember]
        public string appointment_type { get; set; }
    }
    [DataContract]
    public class PickDropDetail
    {
        [DataMember]
        public string PDA_name { get; set; }
        [DataMember]
        public string Mobile_no_PDA { get; set; }
        [DataMember]
        public string Zone_Localities { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string Mobile_No { get; set; }
        [DataMember]
        public string Pickup_Time { get; set; }
        [DataMember]
        public string Pickup_Type { get; set; }
    }
}