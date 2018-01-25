using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class RejectionAndPartCode
    {
    }
    [DataContract]
    public class RejectionReasonsList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string reason_cd { get; set; }
        [DataMember]
        public string reason_desc { get; set; }
    }

    [DataContract]
    public class PartCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_group_cd { get; set; }
        [DataMember]
        public string part_num { get; set; }
        [DataMember]
        public string part_desc { get; set; }
    }
}