<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ViewTasks.aspx.cs" Inherits="Employee_ViewSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-lg-12">
            <div id="panel-4" class="panel">
                <div class="panel-hdr">
                    <h2>Task <span class="fw-300"><i>Records</i></span>
                    </h2>
                </div>
                <div class="panel-container show">
                    <div class="panel-content">
                        <asp:Repeater ID="RepeaterSalary" runat="server">
                            <HeaderTemplate>
                                <table id="dt-basic-example" class="table table-bordered table-hover table-striped w-100">
                                    <thead class="bg-warning-200">
                                        <tr>
                                           
                                            <th>Project</th>
                                            <th>Employee Id</th>
                                            <th>Employee Name</th>
                                            <th>Task Description</th>
                                            <th>Created By</th>
                                            <th>Created On</th>
                                            <th>Created On</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    
                                    <td><%# Eval("Project")%></td>
                                    <td><%# Eval("EmployeeId")%></td>
                                    <td><%# Eval("EmployeeName")%></td>
                                    <td><%# Eval("TaskDescription")%></td>
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

