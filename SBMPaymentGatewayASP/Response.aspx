<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="SBMPaymentGatewayASP.Response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_response_details" runat="server" Text="Response Details"></asp:Label><br />
            <asp:Label ID="lbl_action_code_description" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_approval_code" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_reference_no" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_order_id" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_post_date" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_action_code" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_eci" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_cvv_validation_result" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbl_order_status" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
