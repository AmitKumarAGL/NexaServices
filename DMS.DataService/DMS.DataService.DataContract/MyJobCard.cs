using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MyJobCard
    {
    }
    [DataContract]
    public class JobCardListForSA
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string model { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string mobile_phone { get; set; }
        [DataMember]
        public string job_card_num { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string jc_open_date { get; set; }
        [DataMember]
        public string prom_date { get; set; }
        [DataMember]
        public string jc_status { get; set; }
        [DataMember]
        public string srv_adv_cd { get; set; }
        [DataMember]
        public string srv_sdv_name { get; set; }
    }
}