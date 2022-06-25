<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DAAProject._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <br />
    <asp:Label ID="Label1" runat="server" Text="Enter Input size : "></asp:Label>
    <asp:TextBox ID="Inputsize" runat="server"></asp:TextBox>
            <div>  
            <h2>Select Algorithms</h2>  
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Linear Search" />  
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Binary Search" />  
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Binary Search Tree" />
            <asp:CheckBox ID="CheckBox4" runat="server" Text="Red Black Tree" />  

        </div>  
        <p>  
            <asp:Button ID="Button1" runat="server" Text="Compare" OnClick="Button1_Click" />  
        </p>
        <asp:Label runat="server" ID="Resultmessage"></asp:Label>  
    </form>  
    </div>
    <asp:Chart ID="Chart1" runat="server" >
        <Titles>
        <asp:Title ShadowOffset="3" Name="Items" />
    </Titles>
    <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
    <Series>
        <asp:Series Name="Time in microseconds" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
    </ChartAreas>
    </asp:Chart>
  
</asp:Content>
