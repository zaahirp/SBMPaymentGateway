<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="SBMPaymentGatewayASP.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_order_status" runat="server" Text="Order Status: "></asp:Label><br />
            <asp:Label ID="lbl_action_code" runat="server" Text="Action Code: "></asp:Label><br />
            <asp:Label ID="lbl_description" runat="server" Text="Description: "></asp:Label>
            <br />
            <asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btn_payment" Text="Make Payment" OnClick="btn_payment_Click" runat="server" />
        </div>
    </form>
</body>
</html>
