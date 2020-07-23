function setTime() {
    let startDate = document.getElementById("startDate").value;
    let endDate = document.getElementById("endDate");
    let newDate = new Date(startDate);
    newDate.setHours(newDate.getHours() + 4);
    endDate.value = formatDate(newDate);
}
function formatDate(date) {
    const stringDate = date.toISOString();

    return stringDate.substring(0, stringDate.indexOf(':', stringDate.indexOf(':') + 1));
}