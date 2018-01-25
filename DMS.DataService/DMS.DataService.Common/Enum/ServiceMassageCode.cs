using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEXA.DataService.Common.Enum
{
    public enum ServiceMassageCode
    {
        SUCCESS = 200,
        INVALID_PARAMETER = 201,
        ERROR = 202,
        DATA_NOT_EXIST = 203,
        SQL_ERROR = 204,
        UNAUTHORIZED_REQUEST = 205,
        ITEM_NOT_EXIST = 206,
        DATA_ALREADY_EXIST = 207,
      
       // Record_Added_Successfully=200
    }
}
