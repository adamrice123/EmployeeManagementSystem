<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ViewSalary.aspx.cs" Inherits="Employee_ViewSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-lg-12">
            <div id="panel-4" class="panel">
                <div class="panel-hdr">
                    <h2>Salary <span class="fw-300"><i>Records</i></span>
                    </h2>
                </div>
                <div class="panel-container show">
                    <div class="panel-content">
                        <asp:Repeater ID="RepeaterSalary" runat="server">
                            <HeaderTemplate>
                                <table id="dt-basic-example" class="table table-bordered table-hover table-striped w-100">
                                    <thead class="bg-warning-200">
                                        <tr>
                                           
                                            <th>Division</th>
                                            <th>EmployeeId</th>
                                            <th>EmployeeName</th>
                                            <th>EmployementType</th>
                                            <th>BasicSalary</th>
                                            <th>HouserentAllowance</th>
                                            <th>MedicalAllowance</th>
                                            <th>SpeicalAllowance</th>
                                            <th>FuelAllowance</th>
                                            <th>PhoneBillAllowance</th>
                                            <th>OtherAllowance</th>
                                            <th>ProvidentFund</th>
                                            <th>TaxDeduction</th>
                                            <th>OtherDeduction</th>
                                            <th>GrossSalary</th>
                                            <th>TotalDeduction</th>
                                            <th>NetSalary</th>
                                            <th>CreatedBy</th>
                                            <th>CreatedOn</th>
                                            <th>CreatedOn</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    
                                    <td><%# Eval("Division")%></td>
                                    <td><%# Eval("EmployeeId")%></td>
                                    <td><%# Eval("EmployeeName")%></td>
                                    <td><%# Eval("EmployementType")%></td>
                                    <td><%# Eval("BasicSalary")%></td>
                                    <td><%# Eval("HouserentAllowance")%></td>
                                    <td><%# Eval("MedicalAllowance")%></td>
                                    <td><%# Eval("SpeicalAllowance")%></td>
                                    <td><%# Eval("FuelAllowance")%></td>
                                    <td><%# Eval("PhoneBillAllowance")%></td>
                                    <td><%# Eval("OtherAllowance")%></td>
                                    <td><%# Eval("ProvidentFund")%></td>
                                    <td><%# Eval("TaxDeduction")%></td>
                                    <td><%# Eval("OtherDeduction")%></td>
                                    <td><%# Eval("GrossSalary")%></td>
                                    <td><%# Eval("TotalDeduction")%></td>
                                    <td><%# Eval("NetSalary")%></td>
                                    <td><%# Eval("CreatedBy")%></td>
                                    <td><%# Eval("CreatedOn")%></td>
                                     <td><%# Eval("CreatedOn")%></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                     </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <!-- datatable end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

