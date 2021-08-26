using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{

    public class CabInvoiceException :Exception
    {
        public enum ExceptionType
        {
            INVALID_TIME,INVALID_DISTANCE,NULL_RIDES,INVALID_USER_ID
        }
        ExceptionType type;
        public string message;
        public CabInvoiceException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
