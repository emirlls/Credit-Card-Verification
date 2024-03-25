<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebDersi1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Credit Card Verify System</title>
    <link rel="stylesheet" href="styles.css">
    <script src = "webform.js" ></script>
    
    <%--oninput="formatCardNumber(this)"
    oninput="validateCardHolderName()"
    oninput="formatExpirationDate(this)"
    oninput="validateCVV(this)"--%>


</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div class="container">
        <h2>Credit Card Verify</h2>

            <div class="card-number-container">
                <label for="cardnumber">Card Number</label>
                <asp:TextBox ID="cardnumber" runat="server" placeholder="Enter Card Number (XXXX XXXX XXXX XXXX)" ClientIDMode="Static" maxlength="19" oninput="formatCardNumber(this)"  ></asp:TextBox>
                <div class="card-logo-container">
                    <%--<asp:Image ID="mastercardImage" runat="server" ImageUrl="~/mastercard.png" class="card-logo" Visible="false" />
                    <asp:Image ID="visaImage" runat="server" ImageUrl="~/visa.png" class="card-logo" Visible="false" />--%>
                    <img id="visaImage" src="visa.png" alt="Visa" class="card-logo" style="display:none;">
                    <img id="mastercardImage" src="mastercard.png" alt="MasterCard" class="card-logo" style="display:none;">
                </div>
            </div>
           
            <div class="cardname-container">
                <label for="cardname">Owner</label>
                <asp:TextBox ID="cardname" runat="server" placeholder="Enter Full Name" ClientIDMode="Static" oninput="validateCardHolderName()" ></asp:TextBox>
            </div>
          
            <div class="expiration-date-container">
                <label for="exdate">Expiration Date</label>
                <asp:TextBox ID="exdate" runat="server" placeholder="MM/YY" ClientIDMode="Static" maxlength="5" oninput="formatExpirationDate(this)"></asp:TextBox>
                
            </div>

            <div class="cvv-container">
                <label for="cvv">CVV</label>
                <asp:TextBox ID="cvv" runat="server" placeholder="CVV (XXX)" ClientIDMode="Static" maxlength="3" oninput="validateCVV(this)" ></asp:TextBox>
                
            </div>
            <div style="text-align: center;">
                <asp:Button ID="confirmbutton" runat="server" Text="Confirm" Style="background-color: #007bff; color: #fff; border: none; padding: 10px 20px; border-radius: 5px; cursor: pointer;" OnClick="ConfirmButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
