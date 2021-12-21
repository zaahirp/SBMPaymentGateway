using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBMPaymentGatewayASP
{
    public class BOM_Constants
    {
        //BOM Ids & Values
        public const string payloadFormatIndication = "000201"; //Id 00, length 02, value 01
        public const string pointofInitiationMethod = "010212";

        public const string merchantAccInfoId = "26";
        public const string addtionalDataFieldTempId = "62";
        public const string refLabelId = "05";

        public const string purposeOfTransactionId = "08";

        //CRC
        public const string crcIdAndLength = "6304";

        //NLTA
        public const string globalUniqueIdentifier = "0009mu.maucas";
        public const string payeeParticipantCode = "0112BOMMNTA0XXXX";
        public const string merchantAccNo = "0212NLTA20210002";
        public const string merchantId = "0309NTLA00002";
        public const string merchantCategoryCode = "52049222";
        public const string countryCode = "5802MU";
        public const string merchantName = "5904NLTA";
        public const string merchantCity = "6009Portlouis";

        //Transaction
        public const string transacAmtId = "54";
        public const string transacCurrency = "5303480";
    }
}