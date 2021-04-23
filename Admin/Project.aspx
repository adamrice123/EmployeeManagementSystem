<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="Admin_Project" EnableEventValidation="false" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xl-12">
            <div id="panel-6" class="panel">
                <div class="panel-hdr">
                    <h2>Add New Project
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
                                        <label class="form-label" for="validationDefault01">Project Name</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProjectName" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtProjectName" runat="server" placeholder="Project Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-12 mb-3">
                                        <label class="form-label" for="validationDefaultUsername">Project Description</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDescription" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode ="MultiLine" Rows ="4" placeholder="Project Description" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-4 mb-3">
                                        <label class="form-label" for="validationDefault03">Start Date</label>
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" placeholder="mm-dd-yyyy" TextMode="Date"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 mb-3">
                                        <label class="form-label" for="validationDefault03">End Date</label>
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" placeholder="mm-dd-yyyy" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-content border-faded border-left-0 border-right-0 border-bottom-0 d-flex flex-row">
                                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default ml-auto" CausesValidation="true" OnClick="btnSubmit_Click" />
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

