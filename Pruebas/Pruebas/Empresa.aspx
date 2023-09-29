<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empresa.aspx.cs" Inherits="Alumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:AccessDataSource ID="empleados" runat="server" SelectCommand="select * from Empleados" DataSourceMode="DataReader" DataFile="./App_Data/Empresa.mdb" />
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="empleados" DataTextField="NomEmpleado" DataValueField="IdEmpleado" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Text="Empleados" Value="0"></asp:ListItem>
            </asp:DropDownList>


            <asp:AccessDataSource ID="AccessDataSource1" runat="server" SelectCommand="select * from Fichajes where IdEmpleado = @IdEmpleado" DataSourceMode="DataReader" DataFile="./App_Data/Empresa.mdb">
                <SelectParameters>
                    <asp:Parameter Name="IdEmpleado" Type="Int32" />
                </SelectParameters>
            </asp:AccessDataSource>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="AccessDataSource1" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Tipo entrada" HeaderText="Tipo entrada" />
                    <asp:BoundField DataField="Fecha y Hora" HeaderText="Fecha y Hora" />
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
