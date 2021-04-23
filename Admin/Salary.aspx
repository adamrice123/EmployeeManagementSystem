<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Salary.aspx.cs" Inherits="Admin_Salary" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xl-12">
            <div id="panel-6" class="panel">
                <div class="panel-hdr">
                    <h2>Salary Form
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
                                    <label class="form-label" for="validationDefault01">Select Division</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDivision" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label class="form-label" for="validationDefault02">Employee</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEmployee" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="form-row">
                                <div class="col-md-6 mb-3">
                                    <label class="form-label" for="validationDefaultUsername">Employement Type</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEmployementType" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlEmployementType" runat="server" CssClass="form-control">
                                        <asp:ListItem>-- Select ---</asp:ListItem>
                                        <asp:ListItem>Provision</asp:ListItem>
                                        <asp:ListItem>Permanent</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label>Basic Salary</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtBasicSalary" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtBasicSalary" runat="server" placeholder="Basic Salary" CssClass="form-control calculate"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row mb-2">
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault03">Houserent Allowance</label>
                                    <asp:TextBox ID="txtHouserentAllowance" runat="server" CssClass="form-control calculate" placeholder="Houserent Allowance"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault04">Medical Allowance</label>
                                    <asp:TextBox ID="txtMedicalAllowance" runat="server" CssClass="form-control calculate" placeholder="Medical Allowance"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault05">Speical Allowance</label>
                                    <asp:TextBox ID="txtSpeicalAllowance" runat="server" CssClass="form-control calculate" placeholder="Speical Allowance"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row mb-2">
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault03">Fuel Allowance</label>
                                    <asp:TextBox ID="txtFuelAllowance" runat="server" CssClass="form-control calculate" placeholder="Houserent Allowance"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault04">Phone Bill Allowance</label>
                                    <asp:TextBox ID="txtPhoneBillAllowance" runat="server" CssClass="form-control calculate" placeholder="Medical Allowance"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault05">Other Allowance</label>
                                    <asp:TextBox ID="txtOtherAllowance" runat="server" CssClass="form-control calculate" placeholder="Other Allowance"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row mb-2">
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault03">Provident Fund</label>
                                    <asp:TextBox ID="txtProvidentFund" runat="server" CssClass="form-control calculate calculateDeduction" placeholder="Provident Fund"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault04">Tax Deduction</label>
                                    <asp:TextBox ID="txtTaxDeduction" runat="server" CssClass="form-control calculate calculateDeduction" placeholder="Tax Deduction"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault05">Other Deduction</label>
                                    <asp:TextBox ID="txtOtherDeduction" runat="server" CssClass="form-control calculate calculateDeduction" onkeypress="SUM();" placeholder="Other Deduction"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row mb-2">
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault03">Gross Salary</label>
                                    <asp:TextBox ID="txtGrossSalary" runat="server" CssClass="form-control" ClientIDMode="Inherit" placeholder="Gross Salary"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault04">Total Deduction</label>
                                    <asp:TextBox ID="txtTotalDeduction" runat="server" CssClass="form-control"  ClientIDMode="Static" placeholder="Total Deduction"></asp:TextBox>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label class="form-label" for="validationDefault05">Net Salary</label>
                                    <asp:TextBox ID="txtNetSalary" runat="server" CssClass="form-control"  ClientIDMode="Inherit" placeholder="Net Salary"></asp:TextBox>
                                </div>
                                <asp:Label ID="lblGross" runat="server" Text="" Visible="false"></asp:Label>
                                  <asp:Label ID="lblTotal" runat="server" Text="" Visible="false"></asp:Label>
                                  <asp:Label ID="lblNet" runat="server" Text="" Visible="false"></asp:Label>
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
    <script src="js/jquery-1.2.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".calculate").each(function () {
                $(this).keyup(function () {
                    var total = 0;
                    $(".calculate").each(function () {
                        if (!isNaN(this.value) && this.value.length != 0) {
                            total += parseFloat(this.value);
                        }
                    });
                    $('#<%=txtGrossSalary.ClientID %>').val(total);
                 });
             });
         });
    </script>
    <script type="text/javascript">
        function SUM() {
            var num1 = $('input[id=<%=txtTotalDeduction.ClientID%>]').val();
            var num2 = $('input[id=<%=txtGrossSalary.ClientID%>]').val();
            var result = parseFloat(num2) - parseFloat(num1);
            if (!isNaN(result)) {
                document.getElementById('<%=txtNetSalary.ClientID %>').value = result;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".calculateDeduction").each(function () {
                $(this).keyup(function () {
                    var total = 0;
                    $(".calculateDeduction").each(function () {
                        if (!isNaN(this.value) && this.value.length != 0) {
                            total += parseFloat(this.value);
                        }
                    });
                    $('#<%=txtTotalDeduction.ClientID %>').val(total);
                });
            });
        });
    </script>
</asp:Content>

