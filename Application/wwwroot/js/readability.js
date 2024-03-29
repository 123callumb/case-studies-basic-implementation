﻿let isRBOpen = false;
let fontSizes = { 0: "fnt_small", 1: "fnt_medium", 2: "fnt_large" };
let colorPalettes = { 0: "col_default", 1: "col_highcontr", 2: "col_greyscale" };
let currentFontSize = 0;
let currentColorPalette = 0;
var originalElementFontSizes = [];
var originalBackgroundColors = [];
var originalFontWeights = [];

let isOpenCookie = "accessibility_o"
let fontSizeCookie = "accessibility_fs";
let colourPaletteCookie = "accessibility_cp";

//open/close accessibility container
function toggleRB() {
    if (isRBOpen == true) {
        document.getElementById('rb_content').style.display = "none";
        document.getElementById('rb_openBtn').style.display = "initial";
        isRBOpen = false;
    } else {
        document.getElementById('rb_content').style.display = "initial";
        document.getElementById('rb_openBtn').style.display = "none";
        isRBOpen = true;
    }
    createCookie(isOpenCookie, isRBOpen, 1);
}

//register buttons
window.addEventListener('load', (event) => {
    InitAccessibility();
});

function InitAccessibility() {
    originalElementFontSizes = [];
    originalBackgroundColors = [];
    originalFontWeights = [];

    var paletteBtns = document.getElementsByClassName("rb_col");
    for (var i = 0; i < paletteBtns.length; i++) {
        paletteBtns[i].addEventListener("click", selectPalette);
    }

    var fontBtns = document.getElementsByClassName("rb_fon");
    for (var i = 0; i < fontBtns.length; i++) {
        fontBtns[i].addEventListener("click", selectFontSize);
    }

    //save original elements to reference font sizes to
    var elements = document.getElementsByTagName("*");
    for (var i = 0; i < elements.length; ++i) {
        var fontSize = window.getComputedStyle(elements[i], null).getPropertyValue('font-size');
        originalElementFontSizes.push(parseFloat(fontSize));

        var fontWeight = window.getComputedStyle(elements[i], null).getPropertyValue('font-weight');
        originalFontWeights.push(parseFloat(fontWeight));

        var bgColor = window.getComputedStyle(elements[i], null).getPropertyValue('background-color');
        originalBackgroundColors.push(bgColor);
    }

    //handle cookies
    var fontCookie = readCookie(fontSizeCookie);
    if (fontCookie != null) {
        currentFontSize = fontCookie;
    } else createCookie(fontSizeCookie, currentFontSize, 1);

    var paletteCookie = readCookie(colourPaletteCookie);
    if (paletteCookie != null) {
        currentColorPalette = paletteCookie;
    } else createCookie(colourPaletteCookie, currentColorPalette, 1);

    var openCookie = readCookie(isOpenCookie);
    if (openCookie != null) {
        if (openCookie == "true") toggleRB();
    } else createCookie(isOpenCookie, isRBOpen, 1);

    //initialise settings
    document.getElementById(fontSizes[currentFontSize]).classList.add("rb_selected");
    document.getElementById(colorPalettes[currentColorPalette]).classList.add("rb_selected");
    ChangeFontSize();
    ChangeColorPalette();
}

//change selections
function selectFontSize() { //fonts
    var fontBtns = document.getElementsByClassName("rb_fon");
    for (var i = 0; i < fontBtns.length; i++) {
        fontBtns[i].classList.remove("rb_selected");
    }
    var arr = Array.from(fontBtns);
    currentFontSize = arr.findIndex(x => x.id === this.id);
    this.classList.add("rb_selected");
    ChangeFontSize();

    //edit cookie
    createCookie(fontSizeCookie, currentFontSize, 1);
} 
function selectPalette() { //palettes
    var paletteBtns = document.getElementsByClassName("rb_col");
    for (var i = 0; i < paletteBtns.length; i++) {
        paletteBtns[i].classList.remove("rb_selected");
    }
    var arr = Array.from(paletteBtns);
    currentColorPalette = arr.findIndex(x => x.id === this.id);
    this.classList.add("rb_selected"); 
    ChangeColorPalette();

    //edit cookie
    createCookie(colourPaletteCookie, currentColorPalette, 1);
}

function ChangeFontSize() {
    var elements = document.getElementsByTagName("*");
    for (var i = 0; i < elements.length; ++i) {
        elements[i].style.fontSize = (originalElementFontSizes[i] + (currentFontSize * 2)) + "px";
        if (!elements[i].classList.contains("material-icons") && !elements[i].classList.contains("material-icons-outlined")) {
            if (currentFontSize == 1) elements[i].style.fontWeight = 600;
            else if (currentFontSize == 2) elements[i].style.fontWeight = 700;
            else elements[i].style.fontWeight = originalFontWeights[i];
        }
    }
}

function ChangeColorPalette() {
    var elements = document.getElementsByTagName("*");
    
    for (var i = 0; i < elements.length; ++i) {
        elements[i].style.backgroundColor = originalBackgroundColors[i];

        var count = elements[i].classList.length;
        for (var j = 0; j < count; j++) {
            var currentClass = elements[i].classList[j];
            if (currentClass.substr(0, 3) == 'cs-') {
                if (currentClass.substr(currentClass.length - 3, currentClass.length) == "-hc") {
                    elements[i].classList.remove(currentClass);
                }
                //greyscale
                if (currentColorPalette == 2) {
                    elements[i].style.backgroundColor = '#444444';
                }
                else if (currentColorPalette == 1) {
                    if (currentClass.substr(currentClass.length - 3, currentClass.length) != "-hc") {
                        let newClassName = (currentClass + "-hc");
                        if (!elements[i].classList.contains(newClassName)) {
                            elements[i].classList.add(newClassName);
                        }
                    }
                }
            }
        }
    }
}

//cookie helpers
function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}