﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePages.Master" AutoEventWireup="true" CodeBehind="MoldMaterialMaster.aspx.cs" Inherits="MoldSystem.View.MoldMaterialMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">
    <style type="text/css">
        .logoinside {
            max-height: 36px;
        }

        .bg_menu {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .link_menu {
            line-height: 24px;
        }

        .text_menu {
            margin-top: 0px;
            font-size: 12px;
        }

        .bg_menu .row {
            max-width: 1170px;
            margin: 0 auto;
        }

        .link_menu {
            display: none !important;
        }

        .input-sm, select.input-sm {
            height: 25px;
        }

        label {
            margin-bottom: 0;
        }

        .headaccout {
            padding-bottom: 0px;
            padding-top: 10px;
        }

        .formaccount {
            padding-bottom: 10px;
            padding-top: 10px;
            margin: 5px 0;
        }

        .gridEditButton {
            background-image: url("../Images/edit-icon.png");
            margin: 0 auto;
            width: 16px;
            height: 16px;
            cursor: pointer;
        }

        .gridDeleteButton {
            background-image: url("../Images/del-icon.png");
            margin: 0 auto;
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        function gridEditButton_Click(e) {
            var src = ASPxClientUtils.GetEventSource(e);
            editPopup(src.id, src);
            callbackHelper.EndCallback(moldmatEditPopup);
        };

        function addPopup() {
            showClearedPopup(moldmatEditPopup);
        }

        function editPopup(id, sender) { // TODO
            showClearedPopup(moldmatEditPopup);
            callbackHelper.DoCallback(moldmatEditPopup, id, sender);
        }

        function saveButton_Click(s, e) {
            var commandName = moldmatEditPopup.cpMoldMatID ? "Edit" : "New";
            saveEditForm(moldmatEditPopup, serializeArgs([commandName, moldmatEditPopup.cpMoldMatID]));
        };

        function cancelButton_Click(s, e) {
            var commandName = moldmatEditPopup.cpMoldMatID ? "Edit" : "New";
            cancelEditForm(moldmatEditPopup, serializeArgs([commandName, moldmatEditPopup.cpMoldMatID]));
        };

        function moldmatEditPopup_EndCallback(s, e) {
            s.SetHeaderText(s.cpHeaderText);
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12 headaccout">Mold Material Master</div>
        </div>
        <div class="row formaccount">
            <div class="col-xs-12 col-sm-6 col-md-offset-1 col-md-4">
                <div class="form-group">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mold Material ID">
                    </dx:ASPxLabel>
                    <dx:ASPxTextBox ID="MoldMatIDTextBox" runat="server" Width="170px">
                        <ClientSideEvents KeyDown="numeric_keypress" />
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-offset-1 col-md-4">
                <div class="form-group">
                    <dx:ASPxLabel runat="server" Text="Mold Material Name"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="MoldMatNameTextBox" runat="server" Width="400px">
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="col-xs-12 col-md-offset-1 col-sm-10 text-left">
                <asp:Button runat="server" ID="ResetButton" Text="Reset"  CssClass="btn_reset" OnClick="ResetButton_Click" />
                <asp:Button runat="server" ID="SearchButton" Text="Search"  CssClass="btn_save" OnClick="SearchButton_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-11 col-sm-11 headaccout">Mold Material Data</div>
            <div class="col-xs-1 col-sm-1 headaccout">
                <dx:ASPxButton runat="server" ID="NewButton" Text="New" RenderMode="Link" Font-Underline="false" Font-Size="Medium" ForeColor="White">
                    <ClientSideEvents Click="addPopup" />
                </dx:ASPxButton>
            </div>
        </div>
        <div class="row formaccount">
            <div class="col-xs-12 col-sm-offset-1 col-sm-10">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-lg-12">
                        <dx:ASPxGridView runat="server" ID="MoldMatGrid" ClientInstanceName="moldmatGrid" Width="100%"  
                                    AutoGenerateColumns="False" KeyFieldName="MoldMatID"  EnableCallBacks="False">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Mold Material ID" Width="30%" FieldName="MoldMatID" VisibleIndex="0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mold Material Name" Width="60%" FieldName="MoldMatName" VisibleIndex="1">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Caption=" " Width="5%" VisibleIndex="2">
                                    <DataItemTemplate>
                                         <div id='<%# Eval("MoldMatID") %>' onclick="gridEditButton_Click(event)" class="gridEditButton" title="Edit"></div>
                                    </DataItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption=" " Width="5%" VisibleIndex="3">
                                    <DataItemTemplate>
                                        <div id='<%# Eval("MoldMatID") %>' onclick="gridDeleteButton_Click(event)" class="gridDeleteButton" title="Delete"></div>
                                    </DataItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                </dx:GridViewDataColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
        <div id="EditFormsContainer">
            <dx:MoldMaterialEditForms ID="MoldMatEditForm" runat="server" />
        </div>
    </div>
</asp:Content>
