using ru.bpc.PPLib;
using ru.bpc.PPLib.message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBMPaymentGatewayASP
{
    public partial class Payment : System.Web.UI.Page
    {
        public Plugin p;

        public Payment()
        {
            //p = Plugin.newInstance(@"C:/Users/zaahirp/Documents/Work/Projects/NTA/SBM Payment Gateway/Repository/SBMPaymentGateway/SBMPaymentGatewayASP/NLTA-API.properties");
            string path = HttpContext.Current.Server.MapPath("NLTA-API.properties");
            p = Plugin.newInstance(path);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrderStatusRequest osr = new OrderStatusRequest();
                osr.SetOrderId("98a8bfe7-fd3d-443e-b218-112c4749645c");
                osr.SetLanguage(@"en");
                OrderStatusResponse osResp = p.GetOrderStatus(osr); //Thow exception when card is declined

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
        }

        protected void btn_payment_Click(object sender, EventArgs e)
        {           
            RegisterRequest rr = new RegisterRequest();
            rr.SetCurrency(@"480"); //ISO-4217 Currency (MUR - 480)

            //var orderNo = new Guid().ToString();
            rr.SetMerchantOrderNumber(@"7"); //Order number cannot be the same //we should generate same

            rr.SetAmount(@"1"); //in cent
            rr.SetLanguage(@"en");
            rr.SetReturnUrl(@"https://localhost:44350/Response.aspx");
            rr.SetDescription(@"This is my first Order");
            RegisterResponse regResp = p.RegisterRequest(rr);

            var url = regResp.GetFormUrl();

            //lbl_order_id.Text = "Order Id: " + regResp.GetOrderId().ToString(); //Save this order id in the database

            Response.Redirect(url);
        }
    }
}