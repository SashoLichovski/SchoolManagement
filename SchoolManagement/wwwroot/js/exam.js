function setTime() {
    var startDate = document.getElementById("startDate").value;
    var endDate = document.getElementById("endDate");
    endDate.value = startDate;
    //endDate.value.setHours(endDate.value.getHours() + 2);
}