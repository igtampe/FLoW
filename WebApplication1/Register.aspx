<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.vb" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="text-align: center" __designer:mapid="212">
		
        <asp:Panel ID="LogonPanel" runat="server" Width="570px">
			<span style="font-family: Arial; font-size: xx-large"><strong>UMSWEB REGISTRATION<br /> </strong></span><span style="font-family: Arial; font-weight: normal; font-size: small">Welcome!</span><br />
		</asp:Panel>
        <asp:Panel ID="MainRegisterPanel" runat="server">
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="179px" ReadOnly="True" style="margin-right: 0" TextMode="MultiLine" Width="400px">UMSWEB TERMS AND CONDITIONS:

The UMSWEB is designed to be used by citizens of the UMS (Ultra Modern Sector). Any other activity will be illegal under UMS Law. Under this system you can:

 [1.] Pay taxes                                                                
 [2.] Manage your monets                                                       
 [5.] More amazing stuff                                                       

The UMSWEB is a program presented as is. The UMS Is not responsible for any problems that occur here-on out. Legal mumbo jumbo goes here and very big words like taxes and regulatory bodies and federal prosecution along with penal code 1422 and law 14. All transactions will be logged and notified to theUMS Government. The UMS Reserves the right to use any and all information provided. Usage of this system implies acceptance. The UMS is (C)2018 Nexus LLC
</asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="179px" ReadOnly="True" TextMode="MultiLine" Width="400px">ViBE TERMS OF SERVICE

By using this product you agree to all terms set in this doucment. Please read them. Its super short so please. If you don&#39;t agree to them then just don&#39;t use ViBE. Simple.

A. By using this product you agree to have Igtampe not be responsible for anything it does. It&#39;s provided AS IS. I will help recover what I can but I make NO GUARANTEES.

B. Do not send money to the Lemon. Your assets will be frozen if you do.

C. This program is not for resale, it&#39;s a free utility.

e s o   e s   t o d o
-IGT
</asp:TextBox>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="False" Text="I have read and agree to both of the Terms and Conditions." />
            <br />
            Name:
            <asp:TextBox ID="NameTXB" runat="server" Width="128px"></asp:TextBox>
            &nbsp;PIN:
            <asp:TextBox ID="PinTXB" runat="server" MaxLength="4" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" Width="127px" />
            &nbsp;<br />
            <br />
        </asp:Panel>
        <strong __designer:mapid="1de">
    <asp:Panel ID="ConfirmationPanel" runat="server" Visible="False">
        <div class="text-center">
            <br />
            <span style="font-family: Arial; font-size: x-large"><strong>Congratulations!<br /> </strong></span>You&#39;re now registered on the UMSWEB!<br />
            <br />
            <asp:Label ID="NewIDLBL" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="57174"></asp:Label>
            <br />
            <br />
            This is your ID<br /> Remember it as you will need it to sign in!<br />
            <br />
            Welcome to the UMSWEB,
            <asp:Label ID="NAMELBL" runat="server" Text="NAME"></asp:Label>
            <br />
            <br />
            <a href="Default.aspx">Click here to sign in</a><br />
        </div>
    </asp:Panel>
    </strong>
        <br />
    <asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="49px" style="margin-bottom: 0px" Visible="False" Width="552px">
        <div class="text-center">
            <strong>NOTE<br /> </strong>
            <asp:Label ID="NotifLabel0" runat="server" Text="The notification sub seems to have been sent an incorrect value!"></asp:Label>
            <strong>
            <br />
            </strong>
        </div>
    </asp:Panel>
		</div>

    </asp:Content>
