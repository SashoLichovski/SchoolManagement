document.getElementById("container").classList.remove("container");

function updateScroll() {
    var element = document.getElementById("chat");
    element.scrollTop = element.scrollHeight;
}

updateScroll();

function toggleForm() {
    var form = document.getElementById("form");
    if (form.classList.contains("hide")) {
        form.classList.remove("hide");
        form.classList.add("addRoom");
    } else {
        form.classList.add("hide");
        form.classList.remove("addRoom");
    }
}

document.getElementById("formBtn").disabled = true;
function disableButton() {
    var input = document.getElementById("roomNameInput");
    if (input.value != "") {
        document.getElementById("formBtn").disabled = false;
    } else {
        document.getElementById("formBtn").disabled = true;
    }
}

var sideMenu = document.getElementById("sideMenu");
function toggleSideMenu() {
    if (sideMenu.style.display == "") {
        sideMenu.style.display = "flex";
    }
    else if (sideMenu.style.display == "flex")
    {
        sideMenu.style.display = "none";
    }
    else
    {
        sideMenu.style.display = "flex";
    }

}


var mediaQuery = window.matchMedia("(min-width : 900px)");
window.addEventListener("resize", function () {
    if (mediaQuery.matches) {
        sideMenu.style.display = "flex";
    } else if (!mediaQuery.matches) {
        sideMenu.style.display = "none";
    }
})