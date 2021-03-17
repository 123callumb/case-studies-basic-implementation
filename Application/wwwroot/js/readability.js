let isRBOpen = false;
let fontSizes = { 0: "small", 1: "medium", 2: "large" };
let colorPalettes = { 0: "default", 1: "high contrast", 2: "greyscale" };
let currentFontSize = 0;
let currentColorPalette = 0;

//open/close accessibility container
function toggleRB() {
    console.log(fontSizes);
    if (isRBOpen == true) {
        document.getElementById('rb_content').style.display = "none";
        document.getElementById('rb_openBtn').style.display = "initial";
        isRBOpen = false;
    } else {
        document.getElementById('rb_content').style.display = "initial";
        document.getElementById('rb_openBtn').style.display = "none";
        isRBOpen = true;
    }
}

//register buttons
window.addEventListener('load', (event) => {
    var paletteBtns = document.getElementsByClassName("rb_col");
    for (var i = 0; i < paletteBtns.length; i++) {
        paletteBtns[i].addEventListener("click", selectPalette);
    }

    var fontBtns = document.getElementsByClassName("rb_fon");
    for (var i = 0; i < fontBtns.length; i++) {
        fontBtns[i].addEventListener("click", selectFontSize);
    }
});

//change selections
function selectFontSize() { //fonts
    var fontBtns = document.getElementsByClassName("rb_fon");
    for (var i = 0; i < fontBtns.length; i++) {
        fontBtns[i].classList.remove("rb_selected");
    }
    var arr = Array.from(fontBtns);
    currentFontSize = arr.findIndex(x => x.id === this.id);
    this.classList.add("rb_selected");
} 
function selectPalette() { //palettes
    var paletteBtns = document.getElementsByClassName("rb_col");
    for (var i = 0; i < paletteBtns.length; i++) {
        paletteBtns[i].classList.remove("rb_selected");
    }
    var arr = Array.from(paletteBtns);
    currentColorPalette = arr.findIndex(x => x.id === this.id);
    this.classList.add("rb_selected"); 
}
