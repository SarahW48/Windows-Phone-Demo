
<%@ Page Language="C#" AutoEventWireup="true" Inherits="StartScreen" Codebehind="StartScreen.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
 "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="javascript" type="text/javascript" src="jquery.min.js"></script>
<script language="javascript" type="text/javascript" src="jquery-ui-1.8.23.custom.min.js"></script>

<script language="javascript" type="text/javascript">

    var picid_num = 13;

    $(document).ready(function () {
        generateid();
        setInterval("generateid()", 6000);

    });

    function generateid() {
        var id1 = Math.floor(Math.random() * picid_num + 1);
        var id2 = Math.floor(Math.random() * picid_num + 1);
        while (id2 == id1) {
            id2 = Math.floor(Math.random() * picid_num + 1);
        }
        //console.log(id1, id2);
        livetile(id1, id2);
    }

    function livetile(id1, id2) {
        tileanimateup(id1);
        setTimeout(function () { tileanimateup(id2) }, 1000);
        setTimeout(function () { tileanimatedown(id1) }, 3000);
        setTimeout(function () { tileanimatedown(id2) }, 4000);
    }

    function tileanimateup(id) {
        $("#pic" + id).animate({ "top": "-=35px" }, "slow");
    }

    function tileanimatedown(id) {
        $("#pic" + id).animate({ "top": "+=35px" }, "slow");
    }

    $(function () {
        var myMappings = {
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/1.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/0.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/1.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/0.png"    :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/1.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/1.png"  :"hahaha",          
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/1.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/0.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/1.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/1.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/1.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/0.png" :"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/1.png":"hahaha",   
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/1.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/0.png":"hahaha",
                "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/1.png":"hahaha"
        };
       /* var colors = new Array();
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
        colors[20] = "D80073";*/
        var color;
        var curColor = $(".apps").css("background-color");
        var colorIndex = 0;
        var targetApp;

        /* Change the background color of the startscreen */
        $(".colorinput").click(function () {
            color = $(this).attr("id");
            $(".apps").css("background-color", color);
        })

        /* Show the apps lists after click on one app on the startscreen */
        $(".apps").click(function () {
            targetApp = $(this);
            if (targetApp.attr("name") != "large") {
                $("#appspool").attr("style", "visibility:visible; position:absolute; left:0px; top:0px; ");
                $("#bg1").attr("style", "visibility:hidden;");
                $("#bg2").attr("style", "visibility:block;");
                //$(".bg").attr("src", "http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_2.png")
                //$(".bg").attr("style", "position:absolute; width:455; height:454; left: 104px; top: 235px;");
                $("#apptext").attr("style", "visibility:hidden;");
                $("#apptitle").attr("style", "position:absolute; top:-123px; left:0px;");
            }
        })

        /* Hide the apps lists after choosing and swap */
        $(".appsinput").click(function () {
            if (null != targetApp) {
                if (targetApp.attr("name") != "large") {
                    targetApp.attr("src", $(this).attr("src"));
                    document.getElementById(targetApp.attr("id") + "font").innerHTML = $(this).attr("value"); // change the app text
                }
                if (targetApp.attr("id") == "pic0") {
                    picid_num++;
                    targetApp.attr("id", "pic" + picid_num);
                }
                $("#appspool").attr("style", "position:absolute; visibility:hidden;");
                $("#bg2").attr("style", "visibility:hidden;");
                $("#bg1").attr("style", "visibility:block;");
                //$(".bg").attr("src", "http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_1.png")
                //$(".bg").attr("style", "width:455; height:329; left: 200px; top: 600px;left: 104px;top: 362px;position: absolute;");
                $("#apptext").attr("style", "visibility:block;position:absolute; top:40px; left:0px;");
                $("#apptitle").attr("style", "position:absolute; top:8px; left:0px;");
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

        $(".apps").mouseover(function () {
            var dp = $(this).attr("src");
            $("#discriptionbox").attr("style", "visibility:block; background-color:#3FA9F5;height:180px;width:280px;position:absolute; left:880px; top:274px;");
            $("#discription").append(myMappings[dp]);
        })

        $(".apps").mouseout(function () {
            $("#discription").empty();
            $("#discriptionbox").attr("style", "visibility:hidden;");
        })
    })
</script>

<head>
    <title>Product Test</title>
</head>
<body>
    <!--<button type="button" id="changeColor">Change color</button>-->
    
    <form id="form1" runat="server"></form>

    <div style = "position:absolute;  color:Blue; font-family:Arial Baltic; font-size:300%; top: 80px; left: 110px;">
        <p id="phonetitle" runat="server"></p>
    </div>
    <div id="startscreentitle" style="background-color:#3FA9F5;height:90px;width:1150px;position:absolute; left:60px; top:10px;" ></div>
    <div id="discriptionbox" style="visibility:hidden; background-color:#3FA9F5;height:180px;width:280px;position:absolute; left:880px; top:274px;"><p id="discription"></p> </div>
    <div>
        <div id="bg1" style="visibility:block;">
        &nbsp;<img class="bg" 
                src="http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_1.png" 
                style="width:455; height:329;left: 104px;top: 360px;position: absolute;"/>      
        </div>
        <div id="bg2" style="visibility:hidden;">
        &nbsp;<img class="bg" 
                src="http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_2.png" 
                style="position:absolute; width:455; height:454; left: 104px; top: 235px;"/>      
        </div>
        <div style = "margin-left: 100px; margin-top: 30px; position:absolute;  color:Blue; font-family:Arial Baltic; font-size:100%; top: 345px; left: 22px; width: 482px; height: 50px;">
        <div id="apptitle" style = "position:absolute; top:8px; left:0px;">Change Apps</div>
            <br /><div id="apptext" style="visibility:block;position:absolute; top:40px; left:0px;">Click on the app you want to change</div>
        </div>
        <div id = "appspool" style="visibility:hidden;">
            <div style = "margin-left: 100px; margin-top: 0px; position:absolute;color:Blue; font-family:Arial Baltic; font-size:100%; top: 285px; left: 14px; width: 428px;">
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png" value = "Camera&Photo/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/1.png" value = "Video&Movie/1.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/0.png" value = "Books&Refernce/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/1.png" value = "Books&Refernce/1.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/0.png" value = "Fitness/0.png" style="width:48px; height:48px;"/>           
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/0.png" value = "Video&Movie/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/0.png" value = "Food&Restaurants/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/1.png" value = "Food&Restaurants/1.png" style="width:48px; height:48px;"/>
                <br />
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png" value = "Games/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/1.png" value = "Games/1.png" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png" value = "Music/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/1.png" value = "Music/1.png" style="width:48px; height:48px;"/> 
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/0.png" value = "News/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/1.png" value = "News/1.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/0.png" value = "Organization/0.png" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/1.png" value = "Organization/1.png" style="width:48px; height:48px;"/>
                <br />
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/0.png" value = "Shopping&Finance/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/1.png" value = "Shopping&Finance/1.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/0.png" value = "Social/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/1.png" value = "Social/1.png" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/0.png" value = "Sports/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/1.png" value = "Sports/1.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/0.png" value = "Travel&Navigation/0.png" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/1.png" value = "Travel&Navigation/1.png" style="width:48px; height:48px;"/>
            </div>
        </div>

        <div id = "colors" style="display:block;">   
            <div style = "margin-left: 100px; margin-top: 10px; position:absolute;color:Blue; font-family:Arial Baltic; font-size:100%; top: 545px; left: 5px; width: 470px; height: 150px;">
                    &nbsp;&nbsp;&nbsp;Change colors
                <br />
                <div style="width: 352px; height: 67px; margin-top: 0px;">
                <div style="width: 43px; height: 44px; margin-top: 8px;margin-left: 392px;"><img class="colorinput" id="#f0a30a" 
                        src="images/colors/amber.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 347px;"><img class="colorinput" id="#825a2c" src="images/colors/brown.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 304px;"><img  class="colorinput" id="#0050ef" src="images/colors/cobalt.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 262px;"><img  class="colorinput" id="#a20025" src="images/colors/crimson.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 217px;"><img  class="colorinput" id="#1ba1e2" src="images/colors/cyan.png" style="width: 43px; height: 44px;"/></div>       
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 0px;"><img  class="colorinput" id="#008a00" src="images/colors/emerald.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 44px;"><img  class="colorinput" id="#60a917" src="images/colors/green.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 89px;"><img  class="colorinput" id="#6a00ff" src="images/colors/indigo.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 133px;"><img  class="colorinput" id="#a4c400" src="images/colors/lime.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 174px;"><img  class="colorinput" id="#d80073" src="images/colors/magenta.png" style="width: 43px; height: 44px;"/></div>
                <br />
                <div style="width: 43px; height: 44px; margin-top: -19px;margin-left: 392px;"><img  class="colorinput" id="#76608a" src="images/colors/mauve.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 348px;"><img  class="colorinput" id="#6d8764" src="images/colors/olive.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 306px;"><img  class="colorinput" id="#FA6800" src="images/colors/orange.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 42px; height: 44px; margin-top: -44px;margin-left: 262px;"><img  class="colorinput" id="#F472D0" src="images/colors/pink.png" style="width: 42px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 218px;"><img  class="colorinput" id="#E51400" src="images/colors/red.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 174px;"><img  class="colorinput" id="#7a3b3f" src="images/colors/sienna.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 130px;"><img  class="colorinput" id="#647687" src="images/colors/steel.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 44px; height: 44px; margin-top: -44px;margin-left: 88px;"><img  class="colorinput" id="#00ABA9" src="images/colors/teal.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 43px;"><img  class="colorinput" id="#AA00FF" src="images/colors/violet.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 44px; height: 44px; margin-top: -44px;margin-left: -1px;"><img  class="colorinput" id="#d8c100" src="images/colors/yellow.png" style="width: 43px; height: 44px;"/></div>
                </div>
            </div>
        </div>

        <div id = "templates" style="display:block;">
            <div style = "margin-left: 100px; margin-top: 10px; position:absolute;color:Blue; font-family:Arial Baltic; font-size:100%; top: 439px; left: 20px; width: 486px; height: 142px;">
                <div>Change templates
                </div>
                <div style="margin-top: 12px; height: 75px;"><img class="templateinput"  id="0" src="images/templates/template1.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="1" src="images/templates/template2.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="2" src="images/templates/template3.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="3" src="images/templates/template4.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="4" src="images/templates/template5.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="5" src="images/templates/template6.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="6" src="images/templates/template7.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="7" src="images/templates/template8.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="8" src="images/templates/template9.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="9" src="images/templates/template10.png" style="width:36px; height:63px;"/>
                </div>
            </div>
            <br />
        </div>
    </div>
    <div id="starscreentiles" runat="server"></div>
    <div style="background-color:#3FA9F5;top:800px;left:60px;height:90px;width:1150px; position:absolute;" ></div>
    <form id="form_change" method="get" action="StartScreen.aspx" name="thisForm"></form>		
    </body>
</html>
