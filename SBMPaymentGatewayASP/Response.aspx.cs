using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBMPaymentGatewayASP
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_action_code_description.Text = "Action Code Description: " + Request.QueryString["ActionCodeDescription"];
            lbl_approval_code.Text = "Approval Code: " + Request.QueryString["approvalCode"];
            lbl_reference_no.Text = "Reference Number: " + Request.QueryString["referenceNumber"];
            lbl_order_id.Text = "Order Id: " + Request.QueryString["orderId"];
            lbl_post_date.Text = "Post Date: " + Request.QueryString["postDate"];
            lbl_order_no.Text = "Order Number: " + Request.QueryString["OrderNumber"];
            lbl_action_code.Text = "Action Code: " + Request.QueryString["ActionCode"];
            lbl_eci.Text = "ECI: " + Request.QueryString["eci"];
            lbl_cvv_validation_result.Text = "CVV Validation Result: " + Request.QueryString["cvvValidationResult"];
            lbl_order_status.Text = "Order Status: " + Request.QueryString["OrderStatus"];
            lbl_amount.Text = "Amount: " + Request.QueryString["Amount"];
        }
    }
}