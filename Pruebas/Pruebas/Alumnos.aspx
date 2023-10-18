<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alumnos.aspx.cs" Inherits="Alumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
        <asp:AccessDataSource ID="Alumnos_Acces" runat="server" SelectCommand="select NomAlumno from Alumnos" DataSourceMode="DataReader" DataFile="./App_Data/Alumnos.mdb" />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="Alumnos_Acces" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="NomAlumno" HeaderText="Alumnos" />
            </Columns>
        </asp:GridView>
   </div> </form>
</body>
</html>
