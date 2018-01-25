using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class Notification
    {
    }

    [DataContract]
    public class Notification_NexaAlert
    {
        [DataMember]
        public string pn_date { get; set; }

        [DataMember]
        public List<Notification_NexaAlert_CallDetails> Notification_NexaAlert_CallDetails { get; set; }
        [DataMember]
        public List<Notification_NexaAlert_AppointmentDetails> Notification_NexaAlert_AppointmentDetails { get; set; }
        [DataMember]
        public List<Notification_NexaAlert_JCDetails> Notification_NexaAlert_JCDetails { get; set; }
    }
    [DataContract]
    public class Notification_NexaAlert_CallDetails
    {
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string DEALER_MAP_CD { get; set; }
        [DataMember]
        public string LOC_CD { get; set; }
        [DataMember]
        public string DEALER_NAME { get; set; }
        [DataMember]
        public string DUE_DATE { get; set; }
    }
    [DataContract]
    public class Notification_NexaAlert_AppointmentDetails
    {
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string BOOKING_DATE { get; set; }
        [DataMember]
        public string SRV_TYPE_DESC { get; set; }
        [DataMember]
        public string DEALER_MAP_CD { get; set; }
        [DataMember]
        public string LOC_CD { get; set; }
        [DataMember]
        public string DEALER_NAME { get; set; }
        [DataMember]
        public string DEALER_ADDRESS { get; set; }
        [DataMember]
        public string SA_NAME { get; set; }
        [DataMember]
        public string SA_MOBILE { get; set; }
        [DataMember]
        public string PICKUP_TYPE { get; set; }
        [DataMember]
        public string PDA_NAME { get; set; }
        [DataMember]
        public string MOBILE_NO_PDA { get; set; }
        [DataMember]
        public string ZONE_LOCALITIES { get; set; }
        [DataMember]
        public string CUSTOMERNAME { get; set; }
        [DataMember]
        public string MOBILE_NO { get; set; }
        [DataMember]
        public string PICKUP_TIME { get; set; }
        [DataMember]
        public string APPOINMENT_STATUS { get; set; }
        [DataMember]
        public string INSTRUCTIONS { get; set; }
    }
    [DataContract]
    public class Notification_NexaAlert_JCDetails
    {
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string DEALER_MAP_CD { get; set; }
        [DataMember]
        public string LOC_CD { get; set; }
        [DataMember]
        public string DEALER_NAME { get; set; }
        [DataMember]
        public string DEALER_ADDRESS { get; set; }
        [DataMember]
        public string JOB_NO { get; set; }
        [DataMember]
        public string JOB_DATE_TIME { get; set; }
        [DataMember]
        public string SRV_TYPE_DESC { get; set; }
        [DataMember]
        public string SERVICE_ADVISOR { get; set; }
        [DataMember]
        public string SERVICE_ADVISOR_MOBILE_NO { get; set; }
        [DataMember]
        public string PROMISED_DATE_TIME { get; set; }
        [DataMember]
        public string JOB_STATUS { get; set; }
        [DataMember]
        public string JOB_STATUSDATETIME { get; set; }
        [DataMember]
        public string REV_PROMISED_DATE { get; set; }
        [DataMember]
        public string PART_AMT { get; set; }
        [DataMember]
        public string LAB_AMT { get; set; }
        [DataMember]
        public string PICKUP_TYPE { get; set; }
        [DataMember]
        public string REMARKS { get; set; }
    }
}