using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NEXA.DataService.DataContract
{
    [DataContract(Name = "ListReturnTypeOf{0}")]
    public class BaseListReturnType<ReturnType>
    {
        [DataMember]
        public string message { get; set; }

        [DataMember]
        public int code { get; set; }

        [DataMember]
        public List<ReturnType> result { get; set; }

        //[DataMember]
        //public long TotalCount { get; set; }

        //[DataMember]
        //public int PageNo { get; set; }

        //[DataMember]
        //public int PageSize { get; set; }
    }
}
