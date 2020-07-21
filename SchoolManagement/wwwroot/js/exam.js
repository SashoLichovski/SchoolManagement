
function setTime() {
    var startDate = document.getElementById("startDate").value;
    var endDate = document.getElementById("endDate");
    endDate.value = startDate;
    //var newDate = new Date(startDate);
    //newDate.setHours(newDate.getHours() + 2);
    //endDate.value = moment(newDate).format("yyyy-MM-DDThh:mm")

}
//function validateEndDate() {
//    var startDate = document.getElementById("startDate").value;
//    var endDate = document.getElementById("endDate").value;
//    if (new Date(endDate) >= new Date(startDate)) {
//        return confirm("You can't set finishing hour before or same as your start hour");
//    }
//}
//yyyy - MM - ddThh: mm" followed by optional ": ss" or ": ss.SS
function formatDate(stringDate) {
    let date = new Date(stringDate);
    return date.getFullYear() + '-' + ("0" + date.getMonth()) + '-' + ("0" + date.getDay()) + 'T' + date.getHours() + ':' + date.getMinutes();
}