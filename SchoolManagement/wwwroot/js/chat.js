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