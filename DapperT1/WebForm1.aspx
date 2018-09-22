<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DapperT1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
            width: 271px;
        }
        .auto-style2 {
            width: 143px;
        }
        .auto-style3 {
            height: 20px;
            width: 143px;
        }
        .auto-style4 {
            width: 143px;
            height: 2px;
        }
        .auto-style5 {
            height: 2px;
            width: 271px;
        }
        .auto-style6 {
            width: 271px;
        }
        .auto-style7 {
            width: 143px;
            height: 19px;
        }
        .auto-style8 {
            height: 19px;
            width: 271px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <a href="https://line.me/R/ti/p/%40tlf2414x"><img height="36" border="0" alt="加入好友" src="https://scdn.line-apps.com/n/line_add_friends/btn/zh-Hant.png"></a>
                    <td class="auto-style6">
                        <asp:Button ID="resetStatus" runat="server" OnClick="resetStatus_Click" Text="resetStatus" Width="254px" />
                    </td>
                    <td rowspan="10">
                        <asp:TextBox ID="TXT_Result" runat="server" Height="181px" TextMode="MultiLine" Width="447px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="244px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="getEnum" runat="server" EnableTheming="False" OnClick="getEnum_Click" Text="getEnum" Width="254px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server" style="margin-bottom: 7px" Width="243px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="SendLogToNotify" runat="server" OnClick="SendLogToNotify_Click" Text="SendLogToNotify" Width="254px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server" Width="239px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="DynamicObjForCrud" runat="server" OnClick="Button1_Click" Text="DynamicObjForCrud" Width="253px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox4" runat="server" Width="239px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="flexMessage" runat="server" OnClick="flexMessage_Click" Text="Flex Message" Width="256px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox5" runat="server" Width="241px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="imagemap" runat="server" OnClick="imagemap_Click" Text="Imagemap" Width="255px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox6" runat="server" Width="239px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="QueryAsync" runat="server" OnClick="QueryAsync_Click" Text="QueryAsync" Width="256px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="FlexTest" Width="242px" />
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="InsertTrans" runat="server" OnClick="InsertTrans_Click" Text="InsertTrans" Width="250px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="GetStatus" Width="244px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
