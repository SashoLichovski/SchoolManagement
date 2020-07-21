function toggle(event) {
    var row = document.getElementById("row-" + event.target.id);
    if (row.classList.contains("hide")) {
        row.classList.remove("hide");
        event.target.innerText = "Hide";
    } else {
        row.classList.add("hide");
        event.target.innerText = "Schedule";
    }
}