<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewEmployee.aspx.cs" Inherits="Admin_ViewEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <div id="panel-4" class="panel">
                <div class="panel-hdr">
                    <h2>Employee <span class="fw-300"><i>Records</i></span>
                    </h2>
                </div>
                <div class="panel-container show">
                    <div class="panel-content">
                        <asp:Repeater ID="RepeaterEmployee" runat="server">
                            <HeaderTemplate>
                                <table id="dt-basic-example" class="table table-bordered table-hover table-striped w-100">
                                    <thead class="bg-warning-200">
                                        <tr>
                                            <th>Action</th>
                                            <th>EmployeeId</th>
                                            <th>EmployeeName</th>
                                            <th>Mail</th>
                                            <th>MobileNo</th>
                                            <th>Address</th>
                                            <th>DateOfJoin</th>
                                            <th>Department</th>
                                            <th>Division</th>
                                            <th>DateOfBirth</th>
                                            <th>Gender</th>
                                            <th>EmployeeImage</th>
                                            <th>CreatedBy</th>
                                            <th>CreatedOn</th>
                                            <th>CreatedOn</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a class="btn btn-danger btn-sm" href="DeleteEmployee.aspx?Id=<%# Eval("Id")%>">
                                        <i class="fal fa-trash"></i>Delete</a>
                                        <a class="btn btn-dark btn-sm" href="UpdateEmployee.aspx?Id=<%# Eval("Id")%>">
                                        <i class="fal fa-edit "></i>Update</a>
                                    </td>
                                    <td><%# Eval("EmployeeId")%></td>
                                    <td><%# Eval("EmployeeName")%></td>
                                    <td><%# Eval("Mail")%></td>
                                    <td><%# Eval("MobileNo")%></td>
                                    <td><%# Eval("Address")%></td>
                                    <td><%# Eval("DateOfJoin")%></td>
                                    <td><%# Eval("Department")%></td>
                                    <td><%# Eval("Division")%></td>
                                    <td><%# Eval("DateOfBirth")%></td>
                                    <td><%# Eval("Gender")%></td>
                                    <td>
                                        <ul class="list-inline">
                                            <li class="list-inline-item">
                                                <img src='data:<%#Eval("ContentType")%>;base64,<%# Eval("EmployeeImage") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("EmployeeImage")) : string.Empty %>' alt="" height="50px" width="50px" cssclass="table-avatar" />
                                            </li>
                                        </ul>
                                    </td>
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

