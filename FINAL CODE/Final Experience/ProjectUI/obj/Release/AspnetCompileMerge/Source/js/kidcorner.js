
$(document).ready(
function () {

    $("#unlock-pic").click(function () {
        var arrow = document.getElementById('pic'); //
        var kidcorner = document.getElementById('corner');
        var unlockArray = document.getElementById('unlock-pic');
        $("#unlock").animate({ "top": "-=380px" }, "slow");
        $("#arrow").animate({ "top": "-=380px" }, "slow"); 
        /*if (arrow != null) {
            arrow.parentNode.removeChild(arrow);
            if (kidcorner != null)//delete kidcorner
                kidcorner.parentNode.removeChild(kidcorner);
            if (unlockArray != null) 
            {
                unlockArray.parentNode.removeChild(unlockArray);

            }
        }*/
        $("#kidcorner").animate({ "top": "-=380px" }, "slow");
        $("#pichi").animate({ "top": "-=380px" }, "slow"); //pichi is the div and pic2 is the startscreen

        $("#tweakbar1").show();
        $(".tweakbar1").show('slide', { direction: 'left' }, 1000);
        $("#hovertext").show();

    });

    $("#arrow").click(function () {
        $("#pichi").animate({ "left": "-=211px" }, "slow");
        $("#unlock").animate({ "left": "-=211px" }, "slow");
        var element = document.getElementById("corner");
        var father = document.getElementById("kidcorner");
        var arrow2 = document.getElementById("pic");
        if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/tokidcorner.png") {
            //element = document.createElement("img");
            //element.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/kidcorner.png");
            //element.setAttribute("height", "380px");
            ////element.setAttribute("width", "211px");
            //element.setAttribute("id", "corner");
            //father.appendChild(element);            
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/tolockscreen.png")
        }
        else if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/tolockscreen.png") {

            //startscree.setAttribute("left", "0px"); //; top:0px);
            $("#pichi").animate({ left: "0px", top: '0px' }, "slow");
            $("#unlock").animate({ left: "0px", top: '0px' }, "slow");
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/tokidcorner.png");

        }

    });
}

); 
           