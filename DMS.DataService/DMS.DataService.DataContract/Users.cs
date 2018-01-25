using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NEXA.DataService.DataContract
{
    public class Users
    {

    }

    [DataContract]
    public class UserLogin
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string Pwd { get; set; }
    }
    [DataContract]
    public class UserDetails
    {
        [DataMember]
        public string pn_userid { get; set; }
        [DataMember]
        public string pn_pwd { get; set; }

        [DataMember]
        public string pn_date { get; set; }
        [DataMember]
        public string po_pmc { get; set; }
        [DataMember]
        public string po_parent { get; set; }
        [DataMember]
        public string po_dealer_cd { get; set; }
        [DataMember]
        public string po_loc_cd { get; set; }
        [DataMember]
        public string po_comp_fa { get; set; }
        [DataMember]
        public string po_user_code { get; set; }
        [DataMember]
        public string po_user_name { get; set; }
        [DataMember]
        public string po_time_slot { get; set; }
        [DataMember]
        public string po_emp_desg { get; set; }
        [DataMember]
        public string po_mspin { get; set; }
        [DataMember]
        public string po_cont_no { get; set; }
        [DataMember]
        public string po_emailid { get; set; }
        [DataMember]
        public string po_leave_dt { get; set; }
        [DataMember]
        public string po_status { get; set; }
        [DataMember]
        public string po_state_cd { get; set; }
        [DataMember]
        public string po_state_desc { get; set; }
    }
}