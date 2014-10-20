
$(document).ready(
function () {

    $("#piclock").click(function () {
        var arrow = document.getElementById('pic'); //
        var kidcorner = document.getElementById('corner');
        if (arrow != null) {
            arrow.parentNode.removeChild(arrow);
            if (kidcorner != null)//delete kidcorner
                kidcorner.parentNode.removeChild(kidcorner);
        }
        $("#pichi").animate({ "top": "-=380px" }, "slow"); //pichi is the div and pic2 is the startscreen
        $("#tweakbar1").show();
        $(".tweakbar1").show('slide', { direction: 'left' }, 1000);
        $("#hovertext").show();
        
    });

    $("#arrow").click(function () {
        $("#pichi").animate({ "left": "-=211px" }, "slow");
        var element = document.getElementById("corner");
        var father = document.getElementById("kidcorner");
        var arrow2 = document.getElementById("pic");
        if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/toright.png") {
            //element = document.createElement("img");
            //element.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/kidcorner.png");
            //element.setAttribute("height", "380px");
            ////element.setAttribute("width", "211px");
            //element.setAttribute("id", "corner");
            //father.appendChild(element);            
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/toleft.png");
        }
        else if (arrow2.src == "http://www.etc.cmu.edu/projects/up-plus/images/toleft.png") {

            //startscree.setAttribute("left", "0px"); //; top:0px);
            $("#pichi").animate({ left: "0px", top: '0px' }, 5);

            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/toright.png");

        }

    });
}

); 
           