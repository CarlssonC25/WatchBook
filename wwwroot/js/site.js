﻿//--------------------------------------------------------------------------
// all
//--------------------------------------------------------------------------

function searchBarOnOFF(id, bool) {
    var elem = document.getElementById(id);

    if (elem.classList.contains("display-n") == bool) {
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

    hiddeShowOnElem(elem);
}

function hiddeShowOnElem(elem) {
    console.log("inn"); //test
    console.log(elem); //test
    if (elem.classList.contains("display-n")) {
        elem.classList.remove("display-n");
    } else {
        elem.classList.add("display-n");
    }
}

function hiddeClass(cals, bool) {
    var elems = document.getElementsByClassName(cals);

    Array.prototype.forEach.call(
        elems, elem => {
            if (elem.classList.contains("display-n") !== bool) {
                hiddeShowOnElem(elem);
                console.log("yy"); //test
            }
        }
    );
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


// url
function getUrlValue(valueName) {
    const url = window.location.href;
    const queryParams = {};

    const queryString = url.split('?')[1];

    const pairs = queryString.includes('&') ? queryString.split('&') : [queryString];
    pairs.forEach(pair => {
        const [key, value] = pair.split('=');
        queryParams[decodeURIComponent(key)] = decodeURIComponent(value || '');
    });

    return queryParams[valueName];
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
//                              Add and Edit Item
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

function pacheContentSwitch() {
    let sendPache = getUrlValue("p").toUpperCase();

    if (sendPache == "A") {
        console.log("ist ein Anime");  // TEST

        hiddeClass("anime-cc", false);
        hiddeClass("movie-cc", true);

    } else if (sendPache == "M") {
        console.log("ist ein Film");   // TEST

        hiddeClass("movie-cc", false);
        hiddeClass("anime-cc", true);

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
    addRemoveClassToElemAtID("movie-cont-l", "width-99");
    addRemoveClassToElemAtID("movie-cont-l", "width-83");

    addRemoveClassToElemAtID("movie-cont-r", "width-01");
    addRemoveClassToElemAtID("movie-cont-r", "width-16");
    addRemoveClassToElemAtID("movie-cont-r", "mrg-l-25");

    addRemoveClassToElemAtID("movie-cont-ru", "opt-0");
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