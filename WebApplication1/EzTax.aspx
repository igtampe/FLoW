<%@ Page Language="vb" CodeBehind="EzTax.aspx.vb" AutoEventWireup="false"Inherits="WebApplication1.EzTax" Theme="" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub LogonID_TextChanged(sender As Object, e As EventArgs)

    End Sub
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EzTax ONLINE</title>
    <style type="text/css">
        .auto-style1 {
            width: 514px;
            height: 1307px;
        }
                
        .auto-style3 {
            height: 77px;
            top: 19px;
            left: 92px;
            z-index: 1;
            text-align: center;
            width: 550px;
        }
        
        .auto-style5 {
            margin-bottom: 1px;
        }
        
        .auto-style6 {
            height: 21px;
            text-align: left;
            width: 508px;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style8 {
            height: 1006px;
        }
        
    b,
strong {
  font-weight: bold;
}
* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}
  *,
  *:before,
  *:after {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
            box-shadow: none !important;
  }
  .text-center {
  text-align: center;
}
        
        .auto-style9 {
            width: 100%;
        }
        .auto-style11 {
            width: 101%;
        }
        .auto-style15 {
            height: 23px;
            text-align: left;
        }
        .auto-style16 {
            text-align: left;
        }
        .auto-style21 {
            width: 250px;
        }
        .auto-style23 {
            text-align: justify;
        }
        
        .auto-style24 {
            font-size: large;
            font-weight: bold;
        }
        .auto-style25 {
            width: 125px;
            text-align: left;
        }
        .auto-style26 {
            width: 200px;
            text-align: left;
        }
        .auto-style27 {
            width: 125px;
            height: 23px;
            text-align: left;
        }
        
        .auto-style28 {
            width: 86%;
        }
        .auto-style29 {
            width: 200px;
        }
        
    </style>
</head>
<body style="background-color:#C0C7CF; width: 1324px; position:center; height: 75px;">
    <form id="form1" runat="server">
        <div style="background-color:#C0C7CF" class="auto-style3">
            <div class="auto-style7">
            <br />
            </div>
            <table class="auto-style1" align="center" border="0">
                <tr>
                    <td class="auto-style6">
                        |
                        <a runat="server" href="~/">FLoW</a> | <a runat="server" href="~/Register">Register</a> | <a runat="server" href="~/EzTax">EzTax</a> | <a runat="server" href="~/LandView">LandView</a> | <a runat="server" href="~/About">About</a> | <a runat="server" href="http://igtnet-w.ddns.net:100">Return to the IGTNET</a> |</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <br />
                        <asp:Panel ID="LogonPanel" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="Solid" Width="350px">
                            <br />
                            <asp:Image ID="Image2" runat="server" CssClass="auto-style5" Height="113px" ImageUrl="~/Resources/EzTax Online.png" Width="269px" />
                            <br />
                            <br />
                            &nbsp;ID&nbsp;
                            <asp:TextBox ID="LogonID" runat="server" Height="16px" MaxLength="5" Width="223px" OnTextChanged="LogonID_TextChanged"></asp:TextBox>
                            <br />
                            PIN&nbsp;
                            <asp:TextBox ID="LogonPIN" runat="server" Height="16px" MaxLength="4" TextMode="Password" Width="225px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Login" Width="131px" />
                            <br />
                            <br />
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="MainPanel" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="Solid" Visible="False" Width="500px">
                            <br />
                            <br />
                            <table class="auto-style9">
                                <tr>
                                    <td colspan="2">
                                        <asp:Image ID="Image3" runat="server" CssClass="auto-style5" Height="113px" ImageUrl="~/Resources/EzTax Online.png" Width="269px" />
                                        <br />
                                        <br />
                                        <span class="auto-style24">Welcome back </span>
                                        <asp:Label ID="UsernameLabel" runat="server" Text="Username" CssClass="auto-style24"></asp:Label>
                                        <br />
                                        Your current information:<br /> </td>
                                </tr>
                                <tr>
                                    <td class="auto-style29">Income:</td>
                                    <td class="auto-style29">Tax</td>
                                </tr>
                                <tr>
                                    <td class="auto-style26">
                                        <table class="auto-style9">
                                            <tr>
                                                <td class="auto-style27">Monthly Income:</td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="IncomeLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">Extra Income:</td>
                                                <td class="auto-style16">
                                                    <asp:Label ID="EILabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">&nbsp;</td>
                                                <td class="auto-style16">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">Total:</td>
                                                <td class="auto-style16">
                                                    <asp:Label ID="TotalLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style26">
                                        <table class="auto-style9">
                                            <tr>
                                                <td class="auto-style25">Tax Bracket:</td>
                                                <td class="auto-style16">
                                                    <asp:Label ID="TaxBracketLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">&nbsp;</td>
                                                <td class="auto-style16">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">&nbsp;</td>
                                                <td class="auto-style16">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">Total Tax Due:</td>
                                                <td class="auto-style16">
                                                    <asp:Label ID="TaxDueLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="UpdateIncomeButton" runat="server" Text="Update Income" Width="125px" />
                            &nbsp;
                            <asp:Button ID="SignOutButton" runat="server" Text="Sign Out" Width="125px" />
                            <br />
                            <br />
                            <asp:Panel ID="UploadPanel" runat="server" Visible="False">
                                <div class="auto-style23">
                                    <table align="center" class="auto-style28">
                                        <tr>
                                            <td>To update your income, you&#39;ll need to download and fill out <a href="http://igtnet-w.ddns.net:100/IRTemplate.csv">the CSV file template</a> with any relevant items&nbsp;
                                                <br />
                                                <br />
                                                You can edit it using MS Excel. Just make sure all item descriptions are on colum A and all item incomes are on colum B. Do not leave any empty rows. Colum width isn&#39;t saved so you can have fun with that.</td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div class="text-center">
                                        Once your done select it and hit upload:<br />
                                        <br />
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="278px" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" Text="Upload" Width="161px" />
                                        &nbsp;
                                        <asp:Button ID="CancelUpload" runat="server" Text="Cancel" Width="161px" />
                                        <br />
                                        <br />
                                    </div>
                                    <br />
                                </div>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="ConfirmationPanel" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="None" Visible="False" Width="500px">
                                <table class="auto-style9">
                                    <tr>
                                        <td colspan="2">Is this information correct?</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">Income:</td>
                                        <td>Tax</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">
                                            <table class="auto-style11">
                                                <tr>
                                                    <td class="auto-style27">Monthly Income:</td>
                                                    <td class="auto-style15">
                                                        <asp:Label ID="UpdatedIncomeLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">Extra Income:</td>
                                                    <td class="auto-style16">
                                                        <asp:Label ID="EILabel0" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">&nbsp;</td>
                                                    <td class="auto-style16">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">Total:</td>
                                                    <td class="auto-style16">
                                                        <asp:Label ID="UpdatedTotalLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table class="auto-style11">
                                                <tr>
                                                    <td class="auto-style25">Tax Bracket:</td>
                                                    <td class="auto-style16">
                                                        <asp:Label ID="UpdatedTaxBracketLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">&nbsp;</td>
                                                    <td class="auto-style16">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">&nbsp;</td>
                                                    <td class="auto-style16">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style25">Total Tax Due:</td>
                                                    <td class="auto-style16">
                                                        <asp:Label ID="UpdatedTaxDueLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Button ID="YesConfirmBTN" runat="server" Text="Yes" Width="125px" />
                                &nbsp;
                                <asp:Button ID="NoConfirmBTN" runat="server" Text="No" Width="125px" />
                                <br />
                                <br />
                            </asp:Panel>
                            <br />
                        </asp:Panel>
                        <br />
    	<asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="49px" style="margin-bottom: 0px" Visible="False" Width="350px">
			<div class="text-center">
				<strong>NOTE<br /> </strong>
				<asp:Label ID="NotifLabel" runat="server" Text="The notification sub seems to have been sent an incorrect value!"></asp:Label>
				<strong>
				<br />
				</strong>
			</div>
		</asp:Panel>
		                <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>

</body>
</html>
