
<%@ Page Language="C#" AutoEventWireup="true" Inherits="StartScreen" Codebehind="StartScreen.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
 "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="javascript" type="text/javascript" src="jquery.min.js"></script>
<script language="javascript" type="text/javascript" src="jquery-ui-1.8.23.custom.min.js"></script>

<script language="javascript" type="text/javascript">

    $(function () {
        var colors = new Array();
        colors[0] = "AA00FF";
        colors[1] = "60A917";
        colors[2] = "008A00";
        colors[3] = "00ABA9";
        colors[4] = "1BA1E2";
        colors[5] = "6A00FF";
        colors[6] = "AA00FF";
        colors[7] = "F472D0";
        colors[8] = "D80073";
        colors[9] = "A20025";
        colors[10] = "E51400";
        colors[11] = "FA6800";
        colors[12] = "F0A30A";
        colors[13] = "E3C800";
        colors[14] = "825A2C";
        colors[15] = "6D8764";
        colors[16] = "647687";
        colors[17] = "76608A";
        colors[18] = "87794E";
        colors[19] = "0050EF";
        colors[20] = "D80073";

        var curColor = $(".apps").css("background-color");
        var colorIndex = 0;
        $("#changeColor").click(function () {
            if (curColor == colors[colorIndex]) {
                colorIndex = (++colorIndex) % (colors.length);
                //alert("same color");
                //$(".apps").css("background-color", colors[(++colorIndex) % 9]);
            }
            $(".apps").css("background-color", colors[colorIndex]);
            ++colorIndex;
            colorIndex %= (colors.length);
           // inputData("color", colors[colorIndex]);
          //  document.forms["forsubmit"].submit();
        })

    })


</script>

<head>
    <title>Product Test</title>
</head>
<body>
    <button type="button" id="changeColor" onclick="return changeColor_onclick()">Change color</button>
    <form id="form1" runat="server">

    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Change Template" 
        onclick="Button1_Click1" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Change Apps" 
        onclick="Button2_Click1" />
    <br />
    <br />
    </form>
    </body>
</html>
