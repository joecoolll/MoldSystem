﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoldMaterialEditForms.ascx.cs" Inherits="MoldSystem.UserControls.EditForms.MoldMaterialEditForms" %>

<dx:ASPxPopupControl ID="MoldMatEditPopup" ClientInstanceName="moldmatEditPopup" runat="server" 
    PopupHorizontalAlign="WindowCenter" ShowCloseButton="true" CloseOnEscape="false"
    PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" Modal="true" PopupAnimationType="Fade" CssClass="editFormPopup" 
    OnWindowCallback="MoldMatEditPopup_WindowCallback">
    <ClientSideEvents EndCallback="moldmatEditPopup_EndCallback" />
    <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <dx:ASPxFormLayout ID="MoldMatEditFormLayout" runat="server" AlignItemCaptionsInAllGroups="True">
                <Styles>
                    <LayoutGroup CssClass="group"></LayoutGroup>
                </Styles>
                <Items>
                    <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None">
                        <Items>
                            <dx:LayoutItem Caption="Mold Material ID">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxTextBox ID="EditFormMoldMatIDTextBox" runat="server" Width="100px" MaxLength="30">
                                            <ClientSideEvents KeyDown="numeric_keypress" />
                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="true">
                                                <RequiredField IsRequired="True" ErrorText="Mold Material ID is required" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="Mold Material Name">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxTextBox ID="EditFormMoldMatNameTextBox" runat="server" Width="250px" MaxLength="30">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <div class="buttonsContainer">
                <dx:ASPxButton ID="SaveButton" runat="server" AutoPostBack="false" Text="Save" Width="100px" CssClass="btn_save">
                    <ClientSideEvents Click="saveButton_Click" />
                </dx:ASPxButton>
                <dx:ASPxButton ID="CancelButton" runat="server" AutoPostBack="False" Text="Cancel" Width="100px" CssClass="btn_reset">
                    <ClientSideEvents Click="cancelButton_Click" />
                </dx:ASPxButton>
            </div>
            <div style="clear: both">
            </div>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>