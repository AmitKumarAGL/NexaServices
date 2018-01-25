using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NEXA.DataService.DataContract
{
    [DataContract(Name = "ReturnTypeOf{0}")]
    public class BaseReturnType<ReturnType>
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public ReturnType result { get; set; }

    }
}
