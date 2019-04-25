<%@ Page Title="LandView" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="LandView.aspx.vb" Inherits="WebApplication1.LandView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="text-align: center">
    


        <asp:Panel ID="HomePanel" runat="server">
            <asp:Image ID="Image1" runat="server" Height="330px" ImageUrl="http://igtnet-w.ddns.net:100/plotview/mm.png" Width="330px" />
            <br />
            <br />
            <asp:Panel ID="SectorSelectPanel" runat="server" Width="481px">
                <table class="nav-justified">
                    <tr>
                        <td style="width: 259px"><strong>Region:</strong></td>
                        <td><strong>Plot:</strong></td>
                    </tr>
                    <tr>
                        <td style="width: 259px">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="200px">
                                <asp:ListItem Value="mm">-- Select an item --</asp:ListItem>
                                <asp:ListItem Value="IB">INDUSTRIAL SECTOR</asp:ListItem>
                                <asp:ListItem Value="UB">UMS MAIN &amp; UMS-EX </asp:ListItem>
                                <asp:ListItem Value="SB">SUBURBIA</asp:ListItem>
                                <asp:ListItem Value="RB">URBIA</asp:ListItem>
                                <asp:ListItem Value="PB">PARADISUS</asp:ListItem>
                                <asp:ListItem Value="DB">DOMUM</asp:ListItem>
                                <asp:ListItem Value="LB">LAETRES</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False" Height="18px" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowPanel" runat="server" Width="519px">
                <table class="nav-justified" style="font-family: Arial; font-size: x-small">
                    <tr>
                        <td class="text-right" style="width: 57px; height: 13px"><strong>Plot ID:</strong></td>
                        <td class="text-left" style="height: 13px; width: 100px">&nbsp;&nbsp;
                            <asp:Label ID="PlotLBL" runat="server"></asp:Label>
                        </td>
                        <td class="text-right" style="height: 13px; width: 89px"><strong>Aproximate Size:</strong></td>
                        <td class="text-left" style="height: 13px; width: 100px">&nbsp;&nbsp;
                            <asp:Label ID="SizeLBL" runat="server"></asp:Label>
                        </td>
                        <td class="text-right" style="height: 13px; width: 88px"><strong>Price Per Block:</strong></td>
                        <td class="text-left" style="height: 13px">&nbsp;&nbsp;
                            <asp:Label ID="PPBlockLBL" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right" style="width: 57px; height: 14px"><strong>Status:</strong></td>
                        <td class="text-left" style="width: 100px; height: 14px">&nbsp;&nbsp;
                            <asp:Label ID="StatusLBL" runat="server"></asp:Label>
                        </td>
                        <td class="text-right" style="width: 89px; height: 14px"><strong>Aproximate Area:</strong></td>
                        <td class="text-left" style="width: 100px; height: 14px">&nbsp;&nbsp;
                            <asp:Label ID="AreaLBL" runat="server"></asp:Label>
                        </td>
                        <td class="text-right" style="width: 88px; height: 14px"><strong>Total Price:</strong></td>
                        <td class="text-left" style="height: 14px">&nbsp;&nbsp;
                            <asp:Label ID="PriceLBL" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right" style="width: 57px"><strong>Owner:</strong></td>
                        <td class="text-left" style="width: 100px">&nbsp;&nbsp;
                            <asp:Label ID="OwnerLBL" runat="server"></asp:Label>
                        </td>
                        <td class="text-right" style="width: 89px"><strong>Comment:</strong></td>
                        <td class="text-left" colspan="3">&nbsp;&nbsp;
                            <asp:Label ID="CommentLBL" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Button ID="LoadButton" runat="server" Text="Load" Width="124px" />
            <br />
            <br />
            <div style="text-justify" class="text-left">

                <span style="font-family: Arial; font-size: xx-small">It is highly recommended you check the plot you&#39;re buying physically before completing the transaction!
            <br />
            For purchases outside of the listed plots, contact a UMS Government Official for price and availability</span></asp:Panel>
            </div>
            


    </div>


</asp:Content>
