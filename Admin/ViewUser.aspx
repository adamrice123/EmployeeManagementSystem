<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="Admin_ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                            <th>Name</th>
                                            <th>Mail</th>
                                            <th>Paaword</th>
                                            <th>DateOfBirth</th>
                                            <th>Gender</th>
                                            <th>UserType</th>
                                            <th>UserImage</th>
                                            <th>CreatedBy</th>
                                            <th>CreatedOn</th>
                                            <th>CreatedOn</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a class="btn btn-danger btn-sm" href="DeleteUser.aspx?Id=<%# Eval("Id")%>">
                                        <i class="fal fa-trash"></i>Delete</a></td>
                                    <td><%# Eval("Name")%></td>
                                    <td><%# Eval("Mail")%></td>
                                    <td><%# Eval("Paaword")%></td>
                                    <td><%# Eval("DateOfBirth")%></td>
                                    <td><%# Eval("Gender")%></td>
                                    <td><%# Eval("UserType")%></td>
                                    <td>
                                        <ul class="list-inline">
                                            <li class="list-inline-item">
                                                <img src='data:<%#Eval("ContentType")%>;base64,<%# Eval("UserImage") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("UserImage")) : string.Empty %>' alt="" height="50px" width="50px" cssclass="table-avatar" />
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

