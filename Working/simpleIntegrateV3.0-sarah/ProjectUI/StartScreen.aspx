
<%@ Page Language="C#" AutoEventWireup="true" Inherits="StartScreen" Codebehind="StartScreen.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
 "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Product Test</title>
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script> 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js"></script> 
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css"/>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            generateid();
            setInterval("generateid()", 6000);

        });

        function generateid() {
            var id1 = Math.floor(Math.random() * 8 + 1);
            var id2 = Math.floor(Math.random() * 8 + 1);
            while (id2 == id1) {
                id2 = Math.floor(Math.random() * 8 + 1);
            }
            console.log(id1, id2);
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

    </script> 

</head>
<body> 
<!--<body background= "journey_images/black-wallpapers.jpg"  > -->


</body>
</html>
