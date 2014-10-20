
/*this file use to control the kids corner and the startacreen*/
$(document).ready(
function () {

    $("#unlock-pic").click(function () {//unlock the screen when click the lock screen
        var arrow = document.getElementById('pic'); 
        var kidcorner = document.getElementById('corner');
        var unlockArray = document.getElementById('unlock-pic');
        $("#unlock").animate({ "top": "-=380px" }, "slow");
        $("#arrow").animate({ "top": "-=380px" }, "slow"); 
        $("#kidcorner").animate({ "top": "-=380px" }, "slow");
        $("#pichi").animate({ "top": "-=380px" }, "slow"); 

        $("#tweakbar1").show();
        $(".tweakbar1").show('slide', { direction: 'left' }, 1000);
        $("#hovertext").show();

    });

    $("#arrow").click(function () {//this is trhe arrow when kid's corner shows on the screen
        $("#pichi").animate({ "left": "-=211px" }, "slow");
        $("#unlock").animate({ "left": "-=211px" }, "slow");
        var element = document.getElementById("corner");
        var father = document.getElementById("kidcorner");
        var arrow2 = document.getElementById("pic");
        if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/tokidcorner.png") {          
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/tolockscreen.png")
        }
        else if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/tolockscreen.png") {

            $("#pichi").animate({ left: "0px", top: '0px' }, "slow");
            $("#unlock").animate({ left: "0px", top: '0px' }, "slow");
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/tokidcorner.png");

        }

    });
}

); 
           