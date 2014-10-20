
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
        var color;
        var curColor = $(".apps").css("background-color");
        var colorIndex = 0;
        var targetApp;
        $("#changeColor").click(function () {
            /*if (curColor == colors[colorIndex]) {
            colorIndex = (++colorIndex) % (colors.length);
            //alert("same color");
            //$(".apps").css("background-color", colors[(++colorIndex) % 9]);
            }
            $(".apps").css("background-color", colors[colorIndex]);
            ++colorIndex;
            colorIndex %= (colors.length);
            // inputData("color", colors[colorIndex]);
            //  document.forms["forsubmit"].submit();*/
            // $("#colors").attr("style", "display:block;");
            alert("holla");

        })

        $("#changeTemplates").click(function () {
            /*if (curColor == colors[colorIndex]) {
            colorIndex = (++colorIndex) % (colors.length);
            //alert("same color");
            //$(".apps").css("background-color", colors[(++colorIndex) % 9]);
            }
            $(".apps").css("background-color", colors[colorIndex]);
            ++colorIndex;
            colorIndex %= (colors.length);*/
            // inputData("color", colors[colorIndex]);
            //  document.forms["forsubmit"].submit();
            $("#templates").attr("style", "display:block;");
        })

        /* Change the background color of the startscreen */
        $(".colorinput").click(function () {
            color = $(this).attr("id");
            $(".apps").css("background-color", color);
        })

        /* Show the apps lists after click on one app on the startscreen */
        $(".apps").click(function () {
            targetApp = $(this);
            if (targetApp.attr("name") != "large") {
                $("#appspool").attr("style", "display:block; position:fixed; left: 900px; top: 100px; ");
            }
        })

        /* Hide the apps lists after choosing and swap */
        $(".appsinput").click(function () {
            if (null != targetApp) {
                if (targetApp.attr("name") != "large") {
                    targetApp.attr("src", $(this).attr("src"));
                }
                $("#appspool").attr("style", "display:none;");
            }
        })

        /* Choose the template */
        $(".templateinput").click(function () {
            var templateId = $(this).attr("id");
            inputData("template", templateId);
            var colorId = color;
            inputData("color", colorId);
            document.forms["form_change"].submit();
        })

        function inputData(formname, formvalue) {
            var element = document.createElement("input");
            element.setAttribute("name", formname);
            element.setAttribute("value", formvalue);
            element.setAttribute("type", "hidden");
            var foo = document.getElementById("form_change");
            //alert("NAME:" + element.getAttribute("name"));
            //alert("VALUE:" + element.getAttribute("value"));
            //alert(foo.attributes);
            foo.appendChild(element);
        }
    })

</script>

<head>
    <title>Product Test</title>
</head>
<body>
    <!--<button type="button" id="changeColor">Change color</button>-->
    
    <form id="form1" runat="server">
    <div id = "colors" style="display:block;">

        <br />
        <br />
    <asp:Button ID="Button2" runat="server" Text="Change Apps" onclick="Button2_Click1" />
    </form>
        <br />
        <br />
        <img class="colorinput" id="#f0a30a" src="images/colors/amber.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#825a2c" src="images/colors/brown.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#0050ef" src="images/colors/cobalt.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#a20025" src="images/colors/crimson.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#1ba1e2" src="images/colors/cyan.png" style="width: 3%; height: 4%;"/>
        <br />
        <img class="colorinput" id="#008a00" src="images/colors/emerald.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#60a917" src="images/colors/green.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#6a00ff" src="images/colors/indigo.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#a4c400" src="images/colors/lime.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#d80073" src="images/colors/magenta.png" style="width: 3%; height: 4%;"/>
        <br />
        <img class="colorinput" id="#76608a" src="images/colors/mauve.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#6d8764" src="images/colors/olive.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#FA6800" src="images/colors/orange.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#F472D0" src="images/colors/pink.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#E51400" src="images/colors/red.png" style="width: 3%; height: 4%;"/>
        <br />
        <img class="colorinput" id="#7a3b3f" src="images/colors/sienna.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#647687" src="images/colors/steel.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#00ABA9" src="images/colors/teal.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#AA00FF" src="images/colors/violet.png" style="width: 3%; height: 4%;"/>
        <img class="colorinput" id="#d8c100" src="images/colors/yellow.png" style="width: 3%; height: 4%;"/>
        <br />
    </div>
    <br />



    <!--<button type="button" id="changeTemplates" >Change templates</button> -->
    <div id = "templates" style="display:block;">
        <img class="templateinput"  id="0" src="images/templates/template1.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="1" src="images/templates/template2.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="2" src="images/templates/template3.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="3" src="images/templates/template4.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="4" src="images/templates/template5.png" style="width: 3%; height: 9%;"/>
        <br />
        <img class="templateinput"  id="5" src="images/templates/template6.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="6" src="images/templates/template7.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="7" src="images/templates/template8.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="8" src="images/templates/template9.png" style="width: 3%; height: 9%;"/>
        <img class="templateinput"  id="9" src="images/templates/template10.png" style="width: 3%; height: 9%;"/>
        <br />
    </div>

    <br />
    <br />
    <div id = "appspool" style="display:none;">
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/0.png" style="width: 7%; height: 8%;"/>
        <br />
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/1.png" style="width: 7%; height: 8%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/1.png" style="width: 7%; height: 7%;"/>
        <br />
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/0.png" style="width: 7%; height: 7%;"/>
        <br />
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/1.png" style="width: 7%; height: 7%;"/>
        <br />
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/1.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/0.png" style="width: 7%; height: 7%;"/>
        <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/1.png" style="width: 7%; height: 7%;"/>
        <br />
    </div>
    <form id="form_change" method="get" action="StartScreen.aspx" name="thisForm"></form>		
    <br />
    <br />
    <br />
    <br />

    <br />
    <br />
    <br />
    <br />
    </body>
</html>
