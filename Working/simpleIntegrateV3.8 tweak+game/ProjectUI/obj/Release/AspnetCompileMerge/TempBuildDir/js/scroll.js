$(document).ready(function () {
    //levelLength is the total number of levels, levelImg is the number of picures in each pair ,2 or 8
    var levelLength = 16, levelImg = new Array(levelLength);
    var currentLevel = 0;
    //the caption text and color in each level
    var levelCaption = ["Who is your's important one?'", "Which one?", "Which one?", "Which one?", "Which one?", "Which one?", "Which one?"];
    var levelCaptionColor = ["red", "blue", "blue", "blue", "blue", "#E3C800", "#6A00FF", "#D80073", "#A20025", "#A20025", "#A20025"];



    //set all the level as 2 pictures
    for (var i = 0; i < levelLength; i++) {
        levelImg[i] = 2;
    }
    levelImg[0] = 8; levelImg[7] = 6;
    //pop up the window to get the user's name
    userName();
    // when the user click on the image he choose, it will load the next level
    $(".choiceImg").click(function () {
        loadLevel(currentLevel++, this);
    });





    function inputData(formname, formvalue) {
        var element = document.createElement("input");
        if (formname == (-1))
            formname = "useravatar";
        else if (formname == (0))
            formname = "importantavatar";            
        element.setAttribute("name", formname);
        element.setAttribute("value", formvalue);
        element.setAttribute("type", "hidden");
        var foo = document.getElementById("forsubmit");
        foo.appendChild(element);
    }

    function userName() {
        var name = prompt("Please enter your name", "Harry Potter");
        if (name != null) {
            //set the user's name to one of the input
            inputData("username", name);
        }
    }

    function importantName() {
        var name = prompt("Please enter your important one's name", "Ginny Potter");
        if (name != null) {
            //set the user's important name to one of the input
            inputData("importantname", name);
        }
    }

    function loadLevel(level, img) {
        var id = img.id;
        if (level == (levelLength + 1)) {
            inputData("color", id);
            document.forms["forsubmit"].submit();
        }
        else
            if (level == levelLength) {
                $(".choiceA").css('display', 'none');
                $(".choiceB").css('display', 'none');
                $("#colorTiles").css('display', 'block');
                inputData(currentLevel-2, id);
            }
            else {
                $("#caption").text(levelCaption[level]);
                $("#title").attr("style", "background-color:" + levelCaptionColor[level]);
                inputData(currentLevel - 2, id);
                if (currentLevel == 1) {
                    importantName();
                }
                if (levelImg[level] == 2) {
                    $("#C").css('display', 'none');
                    $("#D").css('display', 'none');
                    $("#E").css('display', 'none');
                    $("#F").css('display', 'none');
                    $("#G").css('display', 'none');
                    $("#H").css('display', 'none');
                    $(".choiceA").css('width', '45%');
                    $(".choiceB").css('width', '45%');
                    $("#A").attr('src', "journey_images/" + level + 'a.jpg');
                    $("#B").attr('src', "journey_images/" + level + 'b.jpg');
                }
                if (levelImg[level] == 6) {
                    $("#C").css('display', 'block');
                    $("#D").css('display', 'block');
                    $("#E").css('display', 'block');
                    $("#F").css('display', 'block');
                    $("#G").css('display', 'none');
                    $("#H").css('display', 'none');
                    $(".choiceA").css('width', '30%');
                    $(".choiceB").css('width', '30%');
                    $("#A").attr('src', "journey_images/" + level + 'a.jpg');
                    $("#B").attr('src', "journey_images/" + level + 'b.jpg');
                    $("#C").attr('src', "journey_images/" + level + 'c.jpg');
                    $("#D").attr('src', "journey_images/" + level + 'd.jpg');
                    $("#E").attr('src', "journey_images/" + level + 'e.jpg');
                    $("#F").attr('src', "journey_images/" + level + 'f.jpg');


                }

            }
    }
});