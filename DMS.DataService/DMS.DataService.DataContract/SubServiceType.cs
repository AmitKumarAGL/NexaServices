using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class SubServiceType
    {
    }

    [DataContract]
    public class SubServiceTypeDetails
    {
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_srvtype_cd { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string po_subsrv_cd { get; set; }
        [DataMember]
        public string po_subsrv_type { get; set; }

    }

}