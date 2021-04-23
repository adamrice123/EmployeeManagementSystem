<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ApplyLeave.aspx.cs" Inherits="Employee_ApplyLeave" EnableEventValidation="false" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xl-6">
            <div id="panel-6" class="panel">
                <div class="panel-hdr">
                    <h2>Apply Leave Form
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
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault01">Leave Category</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlLeaveCategory" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlLeaveCategory" runat="server" CssClass="form-control">
                                        <asp:ListItem>Holidays</asp:ListItem>
                                        <asp:ListItem>Casual Leave</asp:ListItem>
                                        <asp:ListItem>Sick Leave</asp:ListItem>
                                        <asp:ListItem>Maternity Leave</asp:ListItem>
                                        <asp:ListItem>Quarantine Leave</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault01">Start Date</label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtStartDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtStartDate" runat="server" placeholder="mm-dd-yyyy" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                 <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault01">End Date</label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEndDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEndDate" runat="server" placeholder="mm-dd-yyyy" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6 mb-3">
                                    <label class="form-label" for="validationDefault01">Reason</label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtReason" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtReason" runat="server" placeholder="Reason" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
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

