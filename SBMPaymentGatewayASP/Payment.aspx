<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="SBMPaymentGatewayASP.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" />  
    <title></title>

    <style>
        .qr-code {
          margin: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="div_sbm" style="display: none">
                <asp:Label ID="lbl_order_status" runat="server" Text="Order Status: "></asp:Label><br />
                <asp:Label ID="lbl_action_code" runat="server" Text="Action Code: "></asp:Label><br />
                <asp:Label ID="lbl_description" runat="server" Text="Description: "></asp:Label>
                <br />
                <br />
                <asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="btn_payment" Text="Make Payment" OnClick="btn_payment_Click" runat="server" />
                <br />
                <br />
                
                <br />
            </div> 
            <div id="div_qrcode" class="text-center">
                <asp:Label ID="lbl_code" runat="server" Text=""></asp:Label>
                <div class="qr-code">
                    <asp:PlaceHolder ID="plBarCode" runat="server" />
                </div>
                <br />
                <asp:Label ID="lbl_reflabel" runat="server" Text="" style="font-size: x-large;font-weight: 700;"></asp:Label>
                <br />
                <asp:Label ID="lbl_accountno" runat="server" Text="" style="font-size: x-large;font-weight: 700;"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
