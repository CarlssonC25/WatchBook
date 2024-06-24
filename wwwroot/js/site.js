//--------------------------------------------------------------------------
// all
//--------------------------------------------------------------------------

function searchBarOnOFF(id, bool) {
    if (elem.classList.contains("display-n") != bool) {
        hiddeShowOnID(id);
    }
}

//hover opacety
function optElemHover(elem) {
    elem.getElementsByClassName("elem-hover-efk")[0].classList.remove("opt-0");
}
function optElemHoverOff(elem) {
    elem.getElementsByClassName("elem-hover-efk")[0].classList.add("opt-0");
}

// add/remove display none
function hiddeShowSwitchIDs(idOne, idTwo) {

    hiddeShowOnID(idOne);
    hiddeShowOnID(idTwo);
}

function hiddeShowOnID(id) {
    var elem = document.getElementById(id);

    if (elem.classList.contains("display-n")) {
        elem.classList.remove("display-n");
    } else {
        elem.classList.add("display-n");
    }

}

// add/remove class

function addRemoveClassToElemAtID(id, clas) {
    var elem = document.getElementById(id);
    addRemoveClassToElemAtElem(elem, clas);
}

function addRemoveClassToElemAtElem(elem, clas) {

    if (elem.classList.contains(clas)) {
        elem.classList.remove(clas);
    } else {
        elem.classList.add(clas);
    }
}


//--------------------------------------------------------------------------
//search
//--------------------------------------------------------------------------

function showSearchSelect(searchID) {
    var myElemWindow = document.getElementById(searchID);

    if (!myElemWindow.classList.contains("display-n")) {
        myElemWindow.classList.add("display-n");
        return;
    }

    var myFormWindowElems = document.getElementsByClassName('searchBox');

    Array.prototype.forEach.call(
        myFormWindowElems, item => {

            if (item !== myElemWindow) {
                if (item.classList !== "display-n") {
                    item.classList.add("display-n");
                }
            }
        }
    );

    myElemWindow.classList.remove("display-n");
}

function checkboxBackColor(id) {
    addRemoveClassToElemAtID(id, "back-col-none");
    addRemoveClassToElemAtID(id, "back-col-777");
}

function checkOnlyOne(id, className) {
    var myElem = document.getElementById(id);
    var checkboxes = document.getElementsByClassName(className);
    
    Array.prototype.forEach.call(
        checkboxes, item => {
            
            if (item !== myElem && item.checked == true) {
                item.checked = false;
                checkboxBackColor(item.id);
            }
        }
    );
    checkboxBackColor(id);
}

//--------------------------------------------------------------------------
//                              Add New Item
//--------------------------------------------------------------------------

function setHiddenValue(hiddenID, value) {
    var elem = document.getElementById(hiddenID);

    if (elem.value != value) {
        elem.value = value;
    } else {
        elem.value = "";
    }
}


function addGenre(genre) {

    const setElemID = "ID" + genre;

    if (!!document.getElementById(setElemID)) {
        document.getElementById(setElemID).remove();

    } else {

        const elemAddto = document.getElementById("add-new-show-genres");
        const newElem = document.createElement("span");

        const elemText = genre.toString().charAt(0).toUpperCase() + genre.toString().slice(1) + ", ";

        newElem.innerHTML = elemText;
        newElem.setAttribute("id", setElemID);
        elemAddto.appendChild(newElem);
    }
}


//--------------------------------------------------------------------------
//Anime / Movie
//--------------------------------------------------------------------------

function sideBoxHover(elem) {
    elem.classList.remove("right-side-item-background");
    elem.classList.add("right-side-item-background-2");
}

function sideBoxHoverOff(elem) {
    elem.classList.remove("right-side-item-background-2");
    elem.classList.add("right-side-item-background");
}

//--------------------------------------------------------------------------
//Movie
//--------------------------------------------------------------------------

function movieShowWatchLaterBox() {
    addRemoveClassToElemAtID("movie-cont-l", "col-10");
    addRemoveClassToElemAtID("movie-cont-r", "col-2");
    addRemoveClassToElemAtID("movie-cont-r", "display-n");
    movieElmesSmall();
}

function movieElmesSmall() {
    var elems = document.getElementsByClassName("movie-elem");

    Array.prototype.forEach.call(
        elems, elem => {
            addRemoveClassToElemAtElem(elem, "movie-elem-small");
        }
    );
}

//--------------------------------------------------------------------------
//Item View
//--------------------------------------------------------------------------

function itemInfoTextLength(id, clas, elem) {
    addRemoveClassToElemAtID(id, clas);

    var elem = document.getElementById(elem);

    if (elem.innerHTML == "[+]") {
        elem.innerHTML = "[-]";
    } else {
        elem.innerHTML = "[+]";
    }
}