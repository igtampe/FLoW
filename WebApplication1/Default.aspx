<%@ Page Title="FLoW: Fast Lowlevel Webaccess for ViBE" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="text-align: center">
		
        <asp:Panel ID="LogonPanel" runat="server">
			<asp:Image ID="VibeLogo" runat="server" Height="150px" ImageUrl="~/Resources/FlowBadge.png" />
            &nbsp;<br /> Welcome to FLoW!<br />
            <br />
            &nbsp; ID&nbsp;
            <asp:TextBox ID="LogonID" runat="server" Height="16px" MaxLength="5" Width="223px"></asp:TextBox>
            <br />
            PIN&nbsp;
            <asp:TextBox ID="LogonPIN" runat="server" Height="16px" MaxLength="4" TextMode="Password" Width="225px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login" Width="131px" />
            <br />
            <br />
            <br />
		</asp:Panel>
        <asp:Panel ID="MainPanel" runat="server" Visible="False">
			<div style="text-align: center">
				<table align="center" aria-orientation="horizontal" class="auto-style2" spellcheck="false" style="width: 35% margin:0 auto">
                    <tr>
                        <td class="text-left" colspan="3" style="height: 20px"><span style="font-family: Arial; font-size: large"><strong>
                            <asp:Label ID="MainScreenUsernamelabel" runat="server" style="font-size: xx-large" Text="User"></asp:Label>
                            </strong></span></td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="3" style="height: 20px"><span style="font-family: Arial"><span style="font-size: small">
                            <asp:CheckBox ID="UMSNBCheck" runat="server" Enabled="False" Font-Size="Small" style="background-color: #EEEEEE" Text=" " />
                            <asp:LinkButton ID="UMSNBHyperlink" runat="server">UMSNB</asp:LinkButton>
                            <span style="background-color: #EEEEEE">&nbsp; </span>
                            <asp:CheckBox ID="GBANKCheck" runat="server" Enabled="False" Font-Size="Small" style="background-color: #EEEEEE" Text=" " />
                            <span style="background-color: #EEEEEE">
                            <asp:LinkButton ID="GBANKHyperlink" runat="server">GBANK</asp:LinkButton>
                            &nbsp; </span>
                            <asp:CheckBox ID="RIVERCheck" runat="server" Enabled="False" Font-Bold="False" Font-Size="Small" style="background-color: #EEEEEE" Text=" " />
                            <asp:LinkButton ID="RIVERHyperlink" runat="server">RIVER</asp:LinkButton>
                            </span></span>&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text-center" colspan="3" style="height: 20px">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="2" style="height: 20px">UMS National Bank</td>
                        <td class="text-right" style="height: 20px; width: 99px;">
                            <asp:Label ID="UMSBLabel" runat="server" Text="Label"></asp:Label>
                            p</td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="2" style="height: 20px">GBank</td>
                        <td class="text-right" style="height: 20px; width: 99px;">
                            <asp:Label ID="GBANKBLabel" runat="server" Text="Label"></asp:Label>
                            p</td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="2">Riverside Bank</td>
                        <td class="text-right" style="width: 99px">
                            <asp:Label ID="RIVERBLabel" runat="server" Text="Label"></asp:Label>
                            p</td>
                    </tr>
                    <tr>
                        <td class="text-left" style="width: 99px">&nbsp;</td>
                        <td class="text-left" style="width: 99px">&nbsp;</td>
                        <td class="text-right" style="width: 99px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="2" style="height: 20px;"><strong>Total</strong></td>
                        <td class="text-right" style="height: 20px; width: 99px">
                            <asp:Label ID="TotalBLabel" runat="server" Text="Label"></asp:Label>
                            p</td>
                    </tr>
                    <tr>
                        <td class="text-center" colspan="3" style="height: 20px;">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 99px">
                            <asp:Button ID="LogoutButton" runat="server" style="margin-bottom: 6" Text="Logout" Width="99px" />
                        </td>
                        <td class="text-center" style="width: 99px">
                            <asp:Button ID="TransferButton" runat="server" style="margin-bottom: 6" Text="Transfer" Width="99px" />
                        </td>
                        <td class="text-center" style="width: 99px">
                            <asp:Button ID="SendButton" runat="server" style="margin-bottom: 6" Text="Send" Width="99px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 99px">&nbsp;</td>
                        <td class="text-center" style="width: 99px">&nbsp;</td>
                        <td class="text-center" style="width: 99px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 99px">&nbsp;</td>
                        <td class="text-center" style="width: 99px">
                            <asp:Button ID="RefreshButton" runat="server" Height="26px" style="margin-bottom: 6" Text="Refresh" Width="99px" />
                        </td>
                        <td class="text-center" style="width: 99px">&nbsp;</td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="BankQuestionPanel" runat="server" Visible="False">
                    <strong>Looks like you don&#39;t have a
                    <asp:Label ID="BQBankLBL" runat="server" Text="Label"></asp:Label>
                    &nbsp;Account.</strong><br /> Would you like to create one?<br />
                    <br />
                    <asp:Button ID="BQYes" runat="server" Text="Yes" Width="128px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BQNo" runat="server" Text="No" Width="128px" />
                </asp:Panel>
                <asp:Panel ID="DirectoryPanel" runat="server" Visible="False">
                    <strong>Send Money to Who?</strong><br />
                    <asp:ListBox ID="ListBox1" runat="server" Height="139px" Width="197px"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="DirectoryOK" runat="server" style="margin-bottom: 6" Text="OK" Width="99px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="DirectoryCancel" runat="server" Text="Cancel" Width="92px" />
                </asp:Panel>
                <asp:Panel ID="SendMoneyPanel" runat="server" Visible="False">
                    <table style="border-style: none; height: 80px; width: 316px; margin-right: 0px; margin-left: 0px; margin:0 auto">
                        <tr>
                            <td class="text-center" colspan="3" style="height: 21px"><strong>Send Money:</strong></td>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 50px; height: 21px">From:</td>
                            <strong>
                            <td style="height: 21px; width: 50px;">
                                <asp:Label ID="SendFromLBL" runat="server" Text="57174\"></asp:Label>
                            </td>
                            <td style="height: 21px; width: 250px;">
                                <asp:RadioButton ID="UMSNBRButtonSend" runat="server" GroupName="Send" Text="UMSNB" />
                                &nbsp;
                                <asp:RadioButton ID="GBANKRButtonSend" runat="server" GroupName="Send" Text="GBANK" />
                                &nbsp;
                                <asp:RadioButton ID="RIVERRButtonSend" runat="server" GroupName="Send" Text="RIVER" />
                            </td>
                            </strong>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 50px; height: 20px">To:</td>
                            <td style="height: 20px; width: 50px;">
                                <asp:Label ID="SendToLBL" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="height: 20px; width: 250px;"><strong>
                                <asp:RadioButton ID="UMSNBRButtonSendTo" runat="server" GroupName="SendTo" Text="UMSNB" />
                                &nbsp;
                                <asp:RadioButton ID="GBANKRButtonSendTo" runat="server" GroupName="SendTo" Text="GBANK" />
                                &nbsp;
                                <asp:RadioButton ID="RIVERRButtonSendTo" runat="server" GroupName="SendTo" Text="RIVER" />
                                </strong></td>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 50px; height: 20px">Amount</td>
                            <td style="height: 20px; width: 50px;"></td>
                            <td style="height: 20px; width: 250px;"><strong>
                                <asp:TextBox ID="SendAmountTXB" runat="server" TextMode="Number" Width="200px"></asp:TextBox>
                                </strong></td>
                        </tr>
                    </table>
                    <br />
                    </strong>
                    <asp:Button ID="SendMoneyOK" runat="server" Text="OK" Width="92px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="SendMoneyCancel" runat="server" Text="Cancel" Width="92px" />
                    <br />
                </asp:Panel>
                <asp:Panel ID="TransferPanel" runat="server" Visible="False">
                    <table align="center" style="margin:0 auto">
                        <tr>
                            <td class="text-center" colspan="2"><strong>Transfer Money:</strong></td>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 82px">From:</td>
                            <strong>
                            <td>
                                <asp:RadioButton ID="UMSNBRButtonTFrom" runat="server" GroupName="A" Text="UMSNB" />
                                &nbsp;
                                <asp:RadioButton ID="GBANKRButtonTFrom" runat="server" GroupName="A" Text="GBANK" />
                                &nbsp;
                                <asp:RadioButton ID="RIVERRButtonTFrom" runat="server" GroupName="A" Text="RIVER" />
                            </td>
                            </strong>
                        </tr>
                        <tr>
                            <td class="text-left" style="width: 82px; height: 20px">To:</td>
                            <td style="height: 20px"><strong>
                                <asp:RadioButton ID="UMSNBRButtonTTo" runat="server" GroupName="B" Text="UMSNB" />
                                &nbsp;
                                <asp:RadioButton ID="GBANKRButtonTTo" runat="server" GroupName="B" Text="GBANK" />
                                &nbsp;
                                <asp:RadioButton ID="RIVERRButtonTTo" runat="server" GroupName="B" Text="RIVER" />
                                </strong></td>
                        </tr>
                        <tr>
                            <td class="text-left" style="height: 22px; width: 82px">Amount:</td>
                            <td class="text-center" style="height: 22px">
                                <asp:TextBox ID="TransferAmountTXB" runat="server" TextMode="Number" ViewStateMode="Disabled" Width="199px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </strong></strong>
                    <br />
                    <asp:Button ID="TransferMoneyOK" runat="server" Text="OK" Width="92px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="TransferMoneyCancel" runat="server" Text="Cancel" Width="92px" />
                    <br />
                </asp:Panel>
			</div>
		</asp:Panel>
                <asp:Panel ID="BankWindow" runat="server" Visible="False">
                    <asp:Image ID="BankLogo" runat="server" Height="100px" ImageUrl="~/Resources/LemonInvest.png" Width="400px" />
                    <br />
                    <br />
                    <asp:TextBox ID="BankLogTextbox" runat="server" Font-Size="X-Small" Height="329px" ReadOnly="True" TextMode="MultiLine" Width="559px" Wrap="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="CloseBABTN" runat="server" Text="Close Account" Width="125px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="LogOKButton" runat="server" Text="OK" Width="125px" />
                    <br />
                    <br />
                </asp:Panel>

    	<asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="49px" style="margin-bottom: 0px" Visible="False">
			<div class="text-center">
				<strong>NOTE<br /> </strong>
				<asp:Label ID="NotifLabel" runat="server" Text="The notification sub seems to have been sent an incorrect value!"></asp:Label>
				<strong>
				<br />
				</strong>
			</div>
		</asp:Panel>
		</div>

    </asp:Content>
