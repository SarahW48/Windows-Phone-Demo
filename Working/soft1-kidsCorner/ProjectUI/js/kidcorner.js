
$(document).ready(
function () {

    $("#pic2").click(function () {
        var arrow = document.getElementById('pic');
        if (arrow != null) {
            //document.getElementById("corner").style.display = 'none';
            //$("#pic").attr("style", "display:hidden;");

            arrow.parentNode.removeChild(arrow);
        }
        $("#pichi").animate({ "top": "-=380px" }, "slow");


    });

    $("#arrow").click(function () {
        $("#pichi").animate({ "left": "-=211px" }, "slow");
        var element = document.getElementById("corner");
        var father = document.getElementById("kidcorner");
        if (element == null) {
            element = document.createElement("img");
            element.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/kidcorner.png");
            element.setAttribute("height", "380px");
            element.setAttribute("width", "211px");
            element.setAttribute("id", "corner");
            father.appendChild(element);

            var arrow2 = document.getElementById("pic");
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/toleft.png");
        }
        else {

            var arrow2 = document.getElementById("pic");
            arrow2.setAttribute("src", "http://www.etc.cmu.edu/projects/up-plus/images/toright.png");

            father.removeChild(father.firstChild); //remove kid's corner
            //startscree.setAttribute("left", "0px"); //; top:0px);
            $("#pichi").animate({ left: "0px", top: '0px' }, 100);

        }

    });
}

); 
           