//--------------------------------------------------------------------------
//nav bar
//--------------------------------------------------------------------------
function showSearchSelect(genre) {
    var myElemWindow = document.getElementById(genre);
    var myFormWindowElems = document.getElementsByClassName('formSelectBox');
    
    Array.prototype.forEach.call(
        myFormWindowElems, item => {

            if (item !== myElemWindow) {
                item.style.visibility = "hidden";
            }
        }
    );

    myElemWindow = myElemWindow.style;

    if (myElemWindow.visibility == "visible") {
        myElemWindow.visibility = "hidden";
        myElemWindow.opacity = "0";
    }
    else {
        myElemWindow.visibility = "visible";
        myElemWindow.opacity = "1";
    }
}


//--------------------------------------------------------------------------
//search
//--------------------------------------------------------------------------

function checkboxBackColor(id) {
    var myElem = document.getElementById(id);
    var myElemStyle = window.getComputedStyle(myElem);
    if (myElemStyle.backgroundColor === "rgb(119, 119, 119)") {
        myElem.style.backgroundColor = "transparent";
    }
    else {
        myElem.style.backgroundColor = "#777";
    }
}

function checkOnlyOne(id) {
    checkboxBackColor(id);   
    var myElem = document.getElementById(id);
    var checkboxes = document.getElementsByClassName('checkboxSearch');
    
    Array.prototype.forEach.call(
        checkboxes, item => {
            
            if (item !== myElem && item.checked == true) {
                item.checked = false;
                checkboxBackColor(item.id);
            }
        });
}


//--------------------------------------------------------------------------
//Movie
//--------------------------------------------------------------------------

function movieShowCont(elem) {
    var styleElem = elem.getElementsByTagName("div")[0].style;

    styleElem.opacity = "1";
}
function movieHideCont(elem) {
    var styleElem = elem.getElementsByTagName("div")[0].style;

    styleElem.opacity = "0";
}