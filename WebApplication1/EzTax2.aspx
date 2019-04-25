<%@ Page Title="EzTax Online"  Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EzTax2.aspx.vb" Inherits="WebApplication1.EzTax2" %>
 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="text-align: center">
		
                        <asp:Panel ID="LogonPanel"  HorizontalAlign="center" align="center" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="Solid" Width="500px">
                            <br />
                            <asp:Image ID="Image2" align="center" runat="server" CssClass="auto-style5" Height="113px" ImageUrl="~/Resources/EzTax Online.png" Width="269px" />
                            <br />
                            <br />
                            &nbsp;ID&nbsp;
                            <asp:TextBox ID="LogonID" runat="server" Height="16px" MaxLength="5" Width="223px"></asp:TextBox>
                            <br />
                            PIN&nbsp;
                            <asp:TextBox ID="LogonPIN" runat="server" Height="16px" MaxLength="4" TextMode="Password" Width="225px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Login" Width="131px" />
                            <br />
                            <br />
                        </asp:Panel>


                        <div class="text-center">


                        <asp:Panel ID="MainPanel" align="center" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="Solid" Visible="False" Width="500px">
                            <br />
                            <br />
                            <table align="center" class="text-centered">
                                <tr>
                                    <td colspan="2" class="text-center">
                                        <asp:Image ID="Image3" runat="server" CssClass="auto-style5" Height="113px" ImageUrl="~/Resources/EzTax Online.png" Width="269px" />
                                        <br />
                                        <br />
                                        <span style="font-family: Arial; font-size: large"><span class="auto-style24"><strong>Welcome back </strong></span> </span>
                                        <strong>
                                        <span style="font-family: Arial; font-size: large">
                                        <asp:Label ID="UsernameLabel" runat="server" CssClass="auto-style24" Text="Username"></asp:Label>
                                        </span>
                                        <br />
                                        </strong>Your current information:<br /> <br />
                                        </td>
                                </tr>
                                <tr>
                                    <td class="text-center" style="width: 200px"><strong>Income:</strong></td>
                                    <td class="text-center" style="width: 200px"><strong>Tax</strong></td>
                                </tr>
                                <tr align="center">
                                    <td class="auto-style26" style="width: 200px">
                                        <table class="auto-style9" style="width: 185px">
                                            <tr>
                                                <td style="width: 110px">Monthly Income:</td>
                                                <td class="auto-style15" style="width: 35px">
                                                    <asp:Label ID="IncomeLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 110px; height: 20px">Extra Income:</td>
                                                <td class="auto-style16" style="width: 35px; height: 20px">
                                                    <asp:Label ID="EILabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 110px">&nbsp;</td>
                                                <td class="auto-style16" style="width: 35px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 110px">Total:</td>
                                                <td class="auto-style16" style="width: 35px">
                                                    <asp:Label ID="TotalLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style26" style="width: 200px">
                                        <table class="auto-style9" style="width: 185px">
                                            <tr>
                                                <td class="auto-style25" style="height: 20px; width: 110px">Tax Bracket:</td>
                                                <td class="auto-style16" style="height: 20px">
                                                    <asp:Label ID="TaxBracketLabel" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25" style="width: 110px">&nbsp;</td>
                                                <td class="auto-style16">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25" style="width: 110px">&nbsp;</td>
                                                <td class="auto-style16">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25" style="width: 110px">Total Tax Due:</td>
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
                            <asp:Panel align="center" ID="UploadPanel" runat="server" Visible="False" Width="475px">
                                <div class="auto-style23">
                                    <table align="center" class="auto-style28">
                                        <tr>
                                            <td class="text-justify" style="width: 400px">To update your income, you&#39;ll need to download and fill out <a href="http://igtnet-w.ddns.net:100/IRTemplate.csv">the CSV file template</a> with any relevant items&nbsp;
                                                <br />
                                                <br />
                                                You can edit it using MS Excel. Just make sure all item descriptions are on colum A and all item incomes are on column B. Do not leave any empty rows. Column width isn&#39;t saved so you can have fun with that. You can also use a standard text editor, making sure the commas are appropriately placed.<br />
                                                <br />
                                                Note that we will keep a copy of your income registry file as evidence of your income&#39;s breakdown. We won&#39;t review this data unless the treasury deems it necessary.</td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div class="text-center">
                                        Once your done select it and hit upload:<br />
                                        <br />
                                        <div class="text-center">
                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="486px" />
                                        </div>
                                        <br />
                                        <asp:Button ID="Button6" runat="server" Text="Upload" Width="161px" />
                                        &nbsp;
                                        <asp:Button ID="CancelUpload" runat="server" Text="Cancel" Width="161px" />
                                        <br />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel align="center" ID="ConfirmationPanel" runat="server" BackColor="#C0C7CF" BorderColor="Black" BorderStyle="None" Height="169px" Visible="False" Width="475px">
                                <table class="auto-style9" align="center" style="width: 400px">
                                    <tr>
                                        <td colspan="2" class="text-center" style="height: 20px"><strong>Is this information correct?</strong><br /> </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><strong>Income:</strong></td>
                                        <td class="text-center"><strong>Tax</strong></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">
                                            <table class="auto-style11" style="width: 185px">
                                                <tr>
                                                    <td style="width: 110px">Monthly Income:</td>
                                                    <td style="width: 35px">
                                                        <asp:Label ID="UpdatedIncomeLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px; height: 20px">Extra Income:</td>
                                                    <td style="width: 35px; height: 20px">
                                                        <asp:Label ID="EILabel0" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px">&nbsp;</td>
                                                    <td style="width: 35px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px">Total:</td>
                                                    <td style="width: 35px">
                                                        <asp:Label ID="UpdatedTotalLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table class="auto-style11" style="width: 185px">
                                                <tr>
                                                    <td style="width: 110px">Tax Bracket:</td>
                                                    <td style="width: 35px">
                                                        <asp:Label ID="UpdatedTaxBracketLabel" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px">&nbsp;</td>
                                                    <td style="width: 35px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px">&nbsp;</td>
                                                    <td style="width: 35px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px">Total Tax Due:</td>
                                                    <td style="width: 35px">
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
                            </asp:Panel>
                            <br />
                        </asp:Panel>
    	                </div>
        <br />
        <asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="49px" style="margin-bottom: 0px" Visible="False" Width="500px">
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