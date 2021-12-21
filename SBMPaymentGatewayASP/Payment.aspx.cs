using ru.bpc.PPLib;
using ru.bpc.PPLib.message;
using SBMPaymentGatewayASP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBMPaymentGatewayASP
{
    public partial class Payment : System.Web.UI.Page
    {
        public Plugin p;
        private string orderNo;

        public Payment()
        {
            //p = Plugin.newInstance(@"C:/Users/zaahirp/Documents/Work/Projects/NTA/SBM Payment Gateway/Repository/SBMPaymentGateway/SBMPaymentGatewayASP/NLTA-API.properties");
            string path = HttpContext.Current.Server.MapPath("NLTA-API.properties");
            p = Plugin.newInstance(path);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //orderNo = "NLTA_" + DateTime.Now.ToString("yyyy-MM-ddThh.mm.ss.ffffff");
            orderNo = "NLTA_" + DateTime.Now.ToString("yyyy-MM-ddThh.mm.ss");
            lbl_order_no.Text = "Order No: " + orderNo;

            try
            {
                OrderStatusRequest osr = new OrderStatusRequest();
                osr.SetOrderId("bdfc964d-e56b-4ef1-99f0-8aca9f9bd196");
                osr.SetLanguage(@"en");
                OrderStatusResponse osResp = p.GetOrderStatus(osr); //Thow exception when transaction is declined

                lbl_order_status.Text = "Order Status: " + osResp.GetOrderStatus().ToString();
                lbl_action_code.Text = "Action Code: " + osResp.GetActionCode().ToString();
                lbl_description.Text = "Description: " + osResp.GetActionCodeDescription();
            }
            catch (Exception)
            {
                lbl_order_status.Text = "Order Status: Declined";
                lbl_action_code.Text = "Action Code: -1";
                lbl_description.Text = "Description: N/A";
            }

            BuildBomQrCode(plBarCode);
        }

        private string SetLength(int length)
        {
            return length.ToString().PadLeft(2, '0');
        }

        private void BuildBomQrCode(PlaceHolder plBarCode)
        {
            //1st part
            StringBuilder root = new StringBuilder();
            string payloadFormatIndication = BOM_Constants.payloadFormatIndication;
            string pointofInitiationMethod = BOM_Constants.pointofInitiationMethod;

            root.Append(payloadFormatIndication);
            root.Append(pointofInitiationMethod);

            //2nd part
            StringBuilder merchantAccInfo = new StringBuilder();
            string merchantAccInfoId = BOM_Constants.merchantAccInfoId;

            merchantAccInfo.Append(merchantAccInfoId);

            string globalUniqueIdentifier = BOM_Constants.globalUniqueIdentifier;
            string payeeParticipantCode = BOM_Constants.payeeParticipantCode;
            string merchantAccNo = BOM_Constants.merchantAccNo;
            string merchantId = BOM_Constants.merchantId;
            string merchantAccInfoGlobal = string.Concat(globalUniqueIdentifier, payeeParticipantCode, merchantAccNo, merchantId);

            merchantAccInfo.Append(SetLength(merchantAccInfoGlobal.Length));
            merchantAccInfo.Append(merchantAccInfoGlobal);

            root.Append(merchantAccInfo);

            //3rd Part
            StringBuilder additionalInfo = new StringBuilder();
            string merchantCategoryCode = BOM_Constants.merchantCategoryCode;
            string transacCurrency = BOM_Constants.transacCurrency;

            string amount = "2000";
            string transacAmt = string.Concat(BOM_Constants.transacAmtId, SetLength(amount.Length), amount);

            string countryCode = BOM_Constants.countryCode;
            string merchantName = BOM_Constants.merchantName;
            string merchantCity = BOM_Constants.merchantCity;

            additionalInfo.Append(merchantCategoryCode);
            additionalInfo.Append(transacCurrency);
            additionalInfo.Append(transacAmt);
            additionalInfo.Append(countryCode);
            additionalInfo.Append(merchantName);
            additionalInfo.Append(merchantCity);

            root.Append(additionalInfo);

            //4th Part
            StringBuilder additionalDataFieldTemplate = new StringBuilder();
            string addtionalDataFieldTempId = BOM_Constants.addtionalDataFieldTempId;

            string refLabelId = BOM_Constants.refLabelId;
            string refLabel = "RGM-TA100-1612210853";
            string refLabelOverall = string.Concat(refLabelId, SetLength(refLabel.Length), refLabel);

            string purposeOfTransactionId = BOM_Constants.purposeOfTransactionId;
            string purposeOfTransaction = "Reservation for RegMark";
            string purposeOfTransacOverall = string.Concat(purposeOfTransactionId, SetLength(purposeOfTransaction.Length), purposeOfTransaction);

            string refLabelPurpose = string.Concat(refLabelOverall, purposeOfTransacOverall);

            string addtionalDataFieldOverall = string.Concat(addtionalDataFieldTempId, SetLength(refLabelPurpose.Length), refLabelPurpose);

            root.Append(addtionalDataFieldOverall);

            //CRC
            string crcIdAndLength = BOM_Constants.crcIdAndLength;
            root.Append(crcIdAndLength);

            string crc = CRCUtils.Crc16Ccitt(root.ToString());

            root.Append(crc);

            lbl_code.Text = root.ToString();
            lbl_reflabel.Text = "Reference Label: " + refLabel;
            lbl_accountno.Text = "Account Number: XXXX XXXX 1061";
            QRCodeUtils.GenerateQrCode(root.ToString(), plBarCode, 270, 270);
        }

        protected void btn_payment_Click(object sender, EventArgs e)
        {
            RegisterRequest rr = new RegisterRequest();
            rr.SetCurrency(@"480"); //ISO-4217 Currency (MUR - 480)

            //var orderNo = new Guid().ToString();
            rr.SetMerchantOrderNumber(orderNo); //Order number cannot be the same //we should generate same

            var amount = "1";
            rr.SetAmount(amount);
            rr.SetLanguage(@"en");
            rr.SetReturnUrl(@"https://localhost:44350/Response.aspx?Amount=" + amount);
            rr.SetDescription(@"This is my first Order");
            RegisterResponse regResp = p.RegisterRequest(rr);

            var url = regResp.GetFormUrl();

            Response.Redirect(url);
        }
    }
}