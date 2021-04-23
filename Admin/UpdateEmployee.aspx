﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="UpdateEmployee.aspx.cs" Inherits="Admin_UpdateEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xl-12">
            <div id="panel-6" class="panel">
                <div class="panel-hdr">
                    <h2>My Profile
                    </h2>
                    <div class="panel-toolbar">
                        <button class="btn btn-panel" data-action="panel-collapse" data-toggle="tooltip" data-offset="0,10" data-original-title="Collapse"></button>
                        <button class="btn btn-panel" data-action="panel-fullscreen" data-toggle="tooltip" data-offset="0,10" data-original-title="Fullscreen"></button>
                        <button class="btn btn-panel" data-action="panel-close" data-toggle="tooltip" data-offset="0,10" data-original-title="Close"></button>
                    </div>
                </div>
                <div class="panel-container show">
                    <div class="panel-content p-0">
                            <div class="panel-content">
                                <div class="form-row">
                                    <div class="col-md-6 mb-3">
                                        <label class="form-label" for="validationDefault01"> Employee Name</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmployeeName" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtEmployeeName" runat="server" placeholder="Employee Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 mb-3">
                                        <label class="form-label" for="validationDefault02">E-Mail</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmployeeEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtEmployeeEmail" runat="server" placeholder="Employee Email" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmployeeEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ForeColor="Red" Display="Dynamic" ErrorMessage="Invalid email address"></asp:RegularExpressionValidator>
                                    </div>

                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-3">
                                        <label class="form-label" for="validationDefaultUsername">Mobile</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmployeeMobile" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtEmployeeMobile" runat="server" placeholder="Employee Mobile" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Mobile Number. Please Enter Valid Mobile Number" ControlToValidate="txtEmployeeMobile" ForeColor="Red" ValidationExpression="[0-9]{10}" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6 mb-3">
                                        <label>Address</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmployeeAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtEmployeeAddress" runat="server" TextMode ="MultiLine" Rows ="4" placeholder="Address" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                            </div>
                            <div class="panel-content border-faded border-left-0 border-right-0 border-bottom-0 d-flex flex-row">
                                 <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="btn btn-default ml-auto" CausesValidation="true" OnClick="btnSubmit_Click" />
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

