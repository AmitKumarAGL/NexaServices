using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NEXA.DataService.DataContract
{
    public class BoomBarrier
    {

    }

    #region for boom barrier
    [DataContract]
    public class BoomBarrierDetails
    {
        [DataMember]
        public string rfid_number { get; set; }
        [DataMember]
        public string registration_number { get; set; }
        [DataMember]
        public string appoinment_number { get; set; }
        [DataMember]
        public string appoinment_status { get; set; }
        //[DataMember]
        //public string time_slotrfid_number { get; set; }
        [DataMember]
        public string time_slot { get; set; }


        [DataMember]
        public string sa_code { get; set; }
        [DataMember]
        public string sa_name { get; set; }




        [DataMember]
        public string model_cd { get; set; }
        [DataMember]
        public string model_desc { get; set; }

    }
    #endregion


    [DataContract]
    public class BoomBarrierOpen
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_Cd { get; set; }

        [DataMember]
        public string pn_date { get; set; }
    }

    #region for BioMetric 
    [DataContract]
    public class BioMetric
    {
        [DataMember]
        public string employee_name { get; set; }
        [DataMember]
        public string employee_code { get; set; }
        [DataMember]
        public string mspin { get; set; }
        [DataMember]
        public string desg_code { get; set; }
        [DataMember]
        public string desg_desc { get; set; }
        [DataMember]
        public string punch_time { get; set; }
        [DataMember]
        public string shift_slot { get; set; }

        [DataMember]
        public string MOBILE { get; set; }
        [DataMember]
        public string EMAIL_ID { get; set; }


    }
    #endregion
}
