<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteMessageBox.ascx.cs" Inherits="MoldSystem.UserControls.MessageBox.DeleteMessageBox" %>

            <table>
                <tr>
                    <td rowspan="2">
                        
                    </td>

                    <td>
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Are you sure you want to delete this row?">
                        </dx:ASPxLabel>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    
                    <td style="width:100%">
                    </td>
                
                    <td>
                        <dx:ASPxButton ID="btnYes" runat="server" Text="Yes" Width="50px" AutoPostBack="False" ClientInstanceName="btnYes">
                            <ClientSideEvents Click="btnYes_Click" />
                        </dx:ASPxButton>
                    </td>
                    
                    <td>
                        <dx:ASPxButton ID="btnNo" runat="server" Text="No" Width="50px" AutoPostBack="False">
                            <ClientSideEvents Click="btnNo_Click" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>