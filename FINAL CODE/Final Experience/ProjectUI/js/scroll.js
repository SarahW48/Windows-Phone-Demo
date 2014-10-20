var gagga=100;
var start;

$(document).ready(function() {
	//levelLength is the total number of levels, levelImg is the number of picures in each pair ,2 or 8
var levelLength=14,levelImg=new Array(levelLength);
var currentLevel=-2;
	//the caption text and color in each level
var levelCaption=new Array(levelLength),levelCaptionColor=new Array(levelLength);
var moving=false;

//set all the level as 2 pictures
for (var i=0;i<levelLength;i++){
	levelImg[i]=2;
	levelCaption[i]="Which one?"
	levelCaptionColor[i]="#A20025";
}
levelImg[0]=8;levelImg[7]=6;
levelCaption=["Which one?","Favorite animal?","Favorite animal?",
"Describes your life?","Favorite food?","Favorite food?","Favorite season?","Describe your life?",
"Favorite room?","Favorite room? ","Favorite room?","Favorite music?","Favorite music?","Favorite music?","Favorite vacation?","Favorite vacation?","Favorite color?"];


// when the user click on the image he choose, it will load the next level
$(".choiceImg").click(function () {
if (!moving){
	loadLevel(currentLevel++,this);
	}
    });

	$(".choiceImg").dblclick(function () {
if (!moving){
	loadLevel(currentLevel++,this);
	}
    });
	
//change the form data	
function inputData(formname, formvalue){
						var element = document.createElement("input");
						element.setAttribute("name", formname);
						element.setAttribute("value", formvalue);
						//element.setAttribute("type", "hidden");
						var foo = document.getElementById("forsubmit");
						foo.appendChild(element);	
}

function userName(){
				var name=prompt("What is your name?","please enter your name");
				if (name!=null){
				//set the user's name to one of the input
					inputData("username",name);
				}
}	

function importantName(){
    var name = prompt("What is his/her name?", "please enter his/her name");
				if (name!=null){
				//set the user's important name to one of the input
						inputData("importantname",name);
				}
}
//move the level up
function loadLevel(level,img){
				moving=true;
	  			changePictures(level,img);
				$("#circle"+level).css("opacity","0.8");
	  			var height="-="+$("#Content").css("height");
	  			$(".level").animate({"top":height}, 1200,function() {  
					moving=false;
				});
}

function changePictures(level,img){
	var id=img.id;
	if (level==(levelLength+1)){
		inputData("color",id);
		time=(Date.now()-start)/1000;
		inputData("time",time);
		document.forms["forsubmit"].submit();		
		}
		else if (level==levelLength){
				$("#colorTiles").css('display','block');	
				inputData(currentLevel-1,id);							
		}
		else{
			//$("#caption").text(levelCaption[level]);
			//$("#title").attr("style","background-color:"+levelCaptionColor[level]);
			if (start==undefined)
				start = Date.now();
				
			if (currentLevel==0){
				//pop up the window to get the user's name
				userName();
				inputData("useravatar",id);
                }
			else
            if (currentLevel==1){
				importantName();
				inputData("importantavatar",id);
            }
            else
                inputData(currentLevel-1, id);
		}
	
}


});