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
    if (sideMenu.style.height == "") {
        sideMenu.style.height = "300px";
        sideMenu.style.overflow = "auto";
    }
    else if (sideMenu.style.height == "300px") {
        sideMenu.style.height = "0px";
        sideMenu.style.overflow = "hidden";
    }
    else if (sideMenu.style.height == "0px"){
        sideMenu.style.height = "300px";
        sideMenu.style.overflow = "auto";
    }

}


var mediaQuery = window.matchMedia("(min-width : 1000px)");
window.addEventListener("resize", function () {
    if (mediaQuery.matches) {
        sideMenu.style.height = "100%";
        sideMenu.style.overflow = "auto";
    } else if (!mediaQuery.matches) {
        sideMenu.style.height = "0px";
        sideMenu.style.overflow = "hidden";
    }
})


function switchRooms(event) {
    var elementText = event.target.innerText;
    if (elementText == "Enter private rooms") {
        event.target.innerText = "Enter public rooms";
        document.getElementById("publicRooms").classList.add("hide");
        document.getElementById("privateRooms").classList.remove("hide");
    } else {
        event.target.innerText = "Enter private rooms";
        document.getElementById("privateRooms").classList.add("hide");
        document.getElementById("publicRooms").classList.remove("hide");
    }
}